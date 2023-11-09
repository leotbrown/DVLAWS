using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace DVLAWebScraper
{
    class DataGridHelper
    {
        public void DataGridPaste(DataGridView datagrid)
        {
            DataObject clipboard = (DataObject)Clipboard.GetDataObject();

            if(clipboard.GetDataPresent(DataFormats.StringFormat))
            {
                string[] rows = Regex.Split(clipboard.GetData(DataFormats.StringFormat).ToString().TrimEnd("\r\n".ToCharArray()), "\r");
                int i = 0;

                try
                {
                    i = datagrid.CurrentRow.Index;
                }
                catch(Exception ex)
                {
                    MessageBox.Show($"An error occurred trying to paste values to the grid. Error message: {ex.Message}");
                }

                foreach(string row in rows)
                {
                    DataGridViewRow r = new DataGridViewRow();
                    r.CreateCells(datagrid, row.Split(new char[] { '\t' }));
                    datagrid.Rows.Insert(i, r);
                    i++;
                }

            }
        }
        public void DataGridPopulateWithList(DataGridView DataGrid, List<string> ValueList, int ColumnReference)
        {
            DataGrid.Rows.Clear();
            int i = DataGrid.Rows[0].Index;
            
            if(ValueList == null)
            {
                return;
            }

            foreach (string value in ValueList)
            {
                DataGridViewRow r = new DataGridViewRow();
                r.CreateCells(DataGrid, value);
                DataGrid.Rows.Insert(i, r);
                i++;
            }
            DataGrid.Refresh();
        }
    }
}
