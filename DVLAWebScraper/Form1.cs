using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLAWebScraper
{
    public partial class Form1 : Form
    {
        CancellationTokenSource _websource = new CancellationTokenSource();
        bool _browserVisible;
        bool _taskIsRunning = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_taskIsRunning)
            {
                MessageBox.Show("The task is running. Cancel or wait for it to finish before starting again");
                return;
            }

            WebScraper web = new WebScraper();

            _taskIsRunning = true;
            web.LaunchScraper(dataGridView1, _browserVisible, _websource.Token).Await(web, SuccessCall, CancellationCall, ErrorTrap);
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _websource.Cancel();
            _websource.Dispose();
            _websource = new CancellationTokenSource();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
            _browserVisible = checkBox1.Checked;
        }

        private void SuccessCall()
        {
            _taskIsRunning = false;
            MessageBox.Show("The Task completed successfully");
        }

        private void CancellationCall()
        {
            _taskIsRunning = false;
            MessageBox.Show("The Task was cancelled");
        }

        private void ErrorTrap(Exception ex)
        {
            _taskIsRunning = false;
            MessageBox.Show($"An Error occurred whilst navigating. The task stopped. Error Message: {ex.Message}");
        }

        private void LoadExcel_Click(object sender, EventArgs e)
        {
            if(CheckIfTaskIsRunning()) { return; }

            OpenFileDialog LoadSheetDialog = new OpenFileDialog();
            LoadSheetDialog.Multiselect = false;
            LoadSheetDialog.Title = "Select the Excel file";

            if(LoadSheetDialog.ShowDialog() == DialogResult.OK)
            {
                ExcelHelper excel = new ExcelHelper();
                DataGridHelper datagrid = new DataGridHelper();
                List<string> CellRange = new List<string>();

                excel.FilePath = LoadSheetDialog.FileName;
                CellRange = excel.GetValues(1);
                datagrid.DataGridPopulateWithList(dataGridView1, CellRange, 1);

            }
            LoadSheetDialog.Dispose();
        }

        private void ExportButton_Click(object sender, EventArgs e)
        {
            if (CheckIfTaskIsRunning()) { return; }

            if (WebScraperSettings.Default.ExportFolder == null | WebScraperSettings.Default.ExportFolder == "")
            {
                MessageBox.Show("Please select the folder you'd like to export your file to first");
                return;
            }
            if(!Directory.Exists(WebScraperSettings.Default.ExportFolder))
            {
                Directory.CreateDirectory(WebScraperSettings.Default.ExportFolder);
            }

            ExcelHelper excel = new ExcelHelper();
            excel.ExportPath = WebScraperSettings.Default.ExportFolder;
            excel.ExportToFile(dataGridView1);
        }

        private void ExportFolderDialog_Click(object sender, EventArgs e)
        {

            FolderBrowserDialog SelectExportFolder = new FolderBrowserDialog();
            SelectExportFolder.ShowNewFolderButton = true;
            
            if(SelectExportFolder.ShowDialog() == DialogResult.OK)
            {
                WebScraperSettings.Default["ExportFolder"] = SelectExportFolder.SelectedPath;
                WebScraperSettings.Default.Save();
            }
            SelectExportFolder.Dispose();
        }
        private bool CheckIfTaskIsRunning()
        {

            if (_taskIsRunning)
            {
                MessageBox.Show("You cannot perform this action whilst the task is running. Cancel and try again.");
                return true;
            }
            else
            {
                return false;
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
        }
    }
    public static class TaskExtensions
    {
        public async static void Await(this Task<int> task, WebScraper web, Action SuccessCallBack, Action CancellationCallBack, Action<Exception> errorCallBack)
        {
            try
            {
                int result;
                result = await task;

                if(result == 1)
                {
                    SuccessCallBack?.Invoke();
                }
                else
                {
                    CancellationCallBack?.Invoke();
                }
            }
            catch(Exception ex)
            {
                errorCallBack?.Invoke(ex);
            }
            finally
            {
                await web._browser.CloseAsync();
                await web._browser.DisposeAsync();
            }
        }
    }
}
