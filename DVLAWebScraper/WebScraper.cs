using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using PuppeteerSharp;
using PuppeteerSharp.Input;

namespace DVLAWebScraper
{
    public class WebScraper
    {
        private BrowserFetcher _fetcher;
        public IBrowser _browser;
        public async Task<int> LaunchScraper(DataGridView datagrid, bool BrowserVisible, CancellationToken token)
        {
            string strURL = "https://vehicleenquiry.service.gov.uk/?locale=en";

            _fetcher = new BrowserFetcher();
            await _fetcher.DownloadAsync();
            _browser = await Puppeteer.LaunchAsync
                (
                new LaunchOptions()
                {
                    Headless = !BrowserVisible,
                    IgnoreHTTPSErrors = true,
                    Timeout = 60000,
                    DefaultViewport = null,
                    Args = new[] 
                        { 
                            "--disable-infobars",
                            "--disable-web-security", 
                            "--allow-running-insecure-content'"
                        }
                }
            );

            if (token.IsCancellationRequested) { return 2; };

            WaitUntilNavigation[] navigation = { WaitUntilNavigation.Networkidle2, WaitUntilNavigation.Load, WaitUntilNavigation.Networkidle0 };
            NavigationOptions options = new NavigationOptions()
            {
                WaitUntil = navigation,
                Timeout = 10000
            };

            WaitForSelectorOptions SelectorTimeOut = new WaitForSelectorOptions()
            {
                Timeout = 10000
            };

            IPage page = await _browser.NewPageAsync();
            await page.GoToAsync(strURL);
            await page.WaitForNavigationAsync(options);
            foreach (DataGridViewRow row in datagrid.Rows.OfType<DataGridViewRow>().Where(r => r.Cells[0].Value != null && r.Cells[1].Value == null))
            {
                if (token.IsCancellationRequested) { return 2; };
                await page.TypeAsync("#wizard_vehicle_enquiry_capture_vrn_vrn", row.Cells[0].Value.ToString().Trim());
                await page.ClickAsync("#submit_vrn_button");

                try
                {
                    await page.WaitForSelectorAsync("#yes-vehicle-confirm", SelectorTimeOut);
                }
                catch(Exception)
                {
                    row.Cells[1].Value = "Registration not found";
                    await page.GoToAsync(strURL).ContinueWith(t => page.WaitForNavigationAsync(options));
                    continue;
                }

                await page.ClickAsync("#yes-vehicle-confirm");

                if (token.IsCancellationRequested) { return 2; } ;
                
                await page.ClickAsync("#capture_confirm_button");
                await page.WaitForSelectorAsync("#main-content > div:nth-child(4) > div.govuk-grid-column-two-thirds > a");

                var TaxStatus = await page.QuerySelectorAsync("#main-content > div:nth-child(3) > div:nth-child(1) > div > h2 > span:nth-child(1)").EvaluateFunctionAsync<string>("s => s.innerText");
                row.Cells[1].Value = TaxStatus.ToString();

                var TaxDate = "";

                if(!TaxStatus.ToString().Contains("SORN"))
                {
                    TaxDate = await page.QuerySelectorAsync("#main-content > div:nth-child(3) > div:nth-child(1) > div > div > strong > span:nth-child(2)").EvaluateFunctionAsync<string>("s => s.innerText");
                }

                row.Cells[2].Value = TaxDate.ToString();

                await page.GoToAsync(strURL);
                await page.WaitForSelectorAsync("#wizard_vehicle_enquiry_capture_vrn_vrn");

                if (token.IsCancellationRequested) { return 2; };
            }

            if (!_browser.IsClosed)
            {
                await _browser.CloseAsync();
            }
            return 1;
        }
	}

}
