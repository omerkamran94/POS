using POS.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Printing;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DGVPrinterHelper;
using System.Security.AccessControl;
using DocumentFormat.OpenXml.Vml;
using System.IO;

namespace POS.Utility
{
    public class PrinterUtility
    {
        Clientdal clientdal;  
        CommonUtility common;  
        string Title;
        string SubTitle;
        string Detail;
        string Footer;
        byte[] photo;
        DataTable result;
        public PrinterUtility()
        {
            this.clientdal = new Clientdal();
            this.common = new CommonUtility();
            this.result = this.clientdal.select();

            if (result.Rows.Count > 0)
            {
                foreach(DataRow dr in result.Rows)
                {
                    this.Title = dr["title"].ToString();
                    this.SubTitle = dr["detail"].ToString();
                    this.Footer = dr["footer"].ToString();
                    this.photo = (byte[])dr["photo"];
                }
            }

        }


        public void PrintDocumentFromDataGridView(DataGridView dgv)
        {
            DGVPrinter printer = new DGVPrinter();

            
                printer.Title = this.Title;
                printer.SubTitle = this.SubTitle;
                printer.SubTitleFormatFlags = StringFormatFlags.LineLimit |
                                              StringFormatFlags.NoClip;
                printer.ColumnWidth = DGVPrinter.ColumnWidthSetting.Porportional;
                printer.PageNumbers = true;
                printer.PageNumberInHeader = false;
                printer.PorportionalColumns = true;
                printer.HeaderCellAlignment = StringAlignment.Near;
                printer.Footer = this.Footer;
                //printer.FooterSpacing = 10;
                printer.TableAlignment = DGVPrinter.Alignment.Center;
            //  printer.ImbeddedImageList.Add(CreateImage());
             printer.PageSettings.PaperSize = new PaperSize("pprnm", 285,600);

            PrintPreviewDialog printPreviewDialog  = new PrintPreviewDialog();
            printPreviewDialog.Document = printer.printDocument;
            printPreviewDialog.ShowDialog();

         //   printer.PrintDataGridView(dgv);
 
        }

        public void PrintDocumentFromDataTable(DataTable dataTable)
        {
            DGVPrinter printer = new DGVPrinter();


            printer.Title = this.Title;
            printer.SubTitle = this.SubTitle;
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit |
                                          StringFormatFlags.NoClip;
            printer.ColumnWidth = DGVPrinter.ColumnWidthSetting.Porportional;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = this.Footer;
            printer.FooterSpacing = 10;
            printer.TableAlignment = DGVPrinter.Alignment.Center;
            //  printer.ImbeddedImageList.Add(CreateImage());
            printer.PageSettings.PaperSize = new PaperSize("MyPaper", 250, 500);

            
            printer.PrintDataTable(dataTable);

        }

        public DataTable GetClientData()
        {
            return clientdal.select();             
        }

        public DGVPrinter.ImbeddedImage CreateImage()
        {
            DGVPrinter.ImbeddedImage img1 = new DGVPrinter.ImbeddedImage();
            Bitmap bitmap1;
            

            using (var ms = new MemoryStream(this.photo))
            {
                bitmap1 = new Bitmap(ms);
            }

            img1.theImage = bitmap1;
            img1.ImageX = 5;
            img1.ImageY = 5;
            img1.ImageAlignment = DGVPrinter.Alignment.NotSet;
            img1.ImageLocation = DGVPrinter.Location.Header;

            return img1;
            
        }


    }


    
}
