using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using ClosedXML.Excel;
using System.Threading.Tasks;

namespace DVLAWebScraper
{
    class ExcelHelper
    {
        private string _filepath;
        private string _exportpath;
        public string FilePath 
        {
            get { return _filepath; }
            set { _filepath = value; } 
        }
        public string ExportPath 
        {
            get { return _exportpath; } 
            set { _exportpath = value; } 
        }
        public List<string> GetValues(int ColReference)
        {
            List<string> ValueList = new List<string>();
            XLWorkbook wb = new XLWorkbook(_filepath);
            IXLWorksheet ws = wb.Worksheet(ColReference);
            int lrow;

            try
            {
                lrow = ws.LastRowUsed().RowNumber();
            }
            catch(NullReferenceException)
            {
                MessageBox.Show("The file seems to be empty. Check and try again.");
                return null;
            }

            for(int i = 2;  i <= lrow; i++)
            {
                if(ws.Cell(i, 1).Value.ToString().Trim() != "")
                {
                    ValueList.Add(ws.Cell(i, 1).Value.ToString().Trim());
                }
            }

            Predicate<string> IsEmpty = s => s == "";
            if(ValueList.TrueForAll(IsEmpty) | ValueList.Count == 0)
            {
                MessageBox.Show("The first column of the file is empty. Check and try again");
                return null;
            }

            return ValueList;
        }
        public void ExportToFile(DataGridView datagrid)
        {
            Excel.Application App = new Excel.Application()
            {
                Visible = false,
                DisplayAlerts = false,
                AskToUpdateLinks = false
            };
            Excel.Workbook wb = App.Workbooks.Add();
            Excel.Worksheet ws = wb.Worksheets[1];

            try
            {
                string timestamp = DateTime.Now.ToString("yyyyMMdd'_'HHmmss");
                string username = System.Environment.GetEnvironmentVariable("username");
                string FilePath = Path.Combine(_exportpath, $"DVLAWebScraperExport_{username}_{timestamp}.xlsx");
                int xlrow = 2;

                ws.Cells[1, 1].value = "Vehicle Registrarion";
                ws.Cells[1, 2].value = "Taxation Status";
                ws.Cells[1, 3].value = "Date Due";

                foreach (DataGridViewRow row in datagrid.Rows)
                {
                    ws.Cells[xlrow, 1].value = row.Cells[0].Value;
                    ws.Cells[xlrow, 2].value = row.Cells[1].Value;
                    ws.Cells[xlrow, 3].value = row.Cells[2].Value;
                    xlrow++;
                }

                ws.UsedRange.Columns.AutoFit();
                ws.Range["A1:C1"].Borders[Excel.XlBordersIndex.xlEdgeBottom].Weight = Excel.XlBorderWeight.xlThick;
                ws.Range["A1:C1"].Interior.ColorIndex = 37;

                wb.SaveAs(FilePath, 51);

                MessageBox.Show($"Exported successfully to {WebScraperSettings.Default.ExportFolder}");
            }
            catch(Exception ex)
            {
                MessageBox.Show($"An error occurred trying to export the results to excel. Error message: {ex.Message}");
            }
            finally
            {
                wb.Close();
                App.Quit();
            }
        }
    }

}
