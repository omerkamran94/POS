 
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.Utility
{
    public class ExcelUtility
    {
        public ExcelUtility()
        {
        }


        public void DownloadDataTableToExcel(DataTable dataTable)
        {
            
        }
        public void DownloadDataGridViewToExcel(DataGridView dataGridView1,string name)
        {
            try
            {
                Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
                // creating new WorkBook within Excel application  
                Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
                // creating new Excelsheet in workbook  
                Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
                // see the excel sheet behind the program  
                app.Visible = false;
                // get the reference of first sheet. By default its name is Sheet1.  
                // store its reference to worksheet  
                worksheet = workbook.Sheets["Sheet1"];
                worksheet = workbook.ActiveSheet;
                // changing the name of active sheet  
                worksheet.Name = "Exported from gridview";
                // storing header part in Excel  
                for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
                {
                    worksheet.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
                }
                // storing Each row and column value to excel sheet  
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        if(dataGridView1.Rows[i].Cells[j].Value == null)
                        {
                            worksheet.Cells[i + 2, j + 1] = "";

                        }
                        else
                        {
                            worksheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();

                        }
                    }
                }

                name += "_" + DateTime.Now.ToString("ddMMyyyyhhmms");
                // save the application  
                workbook.SaveAs("C:\\" + name + ".xlsx", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                // Exit from the application  
                app.Quit();
                MessageBox.Show("File: '" +name+ "'  Downloaded Successfully in C:\\ Drive");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Failed to Create Report: " + ex.Message);
            }
           

        }

    }
}
