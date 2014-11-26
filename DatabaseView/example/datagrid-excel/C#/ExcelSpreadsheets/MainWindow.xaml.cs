using System;
using System.Windows;
using Excel = Microsoft.Office.Interop.Excel;
using ExcelSpreadsheets.Model;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.Threading;

namespace ExcelSpreadsheets
{
    public partial class MainWindow : Window
    {
        Excel.Application xlApp;

        public ObservableCollection<MyClass> MyData { get; set; }
        

        public MainWindow()
        {
            InitializeComponent();
            LoadData();
            DataContext = this;
        }
        private void LoadData()
        {
            MyData = new ObservableCollection<MyClass>();

            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            Excel.Range range;

            xlApp = new Excel.Application();         //create new application object.
            OpenFileDialog dlg = new OpenFileDialog();
            Nullable<bool> result = dlg.ShowDialog();
            //var path = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Model", "Book1.xls");        
            xlWorkBook = xlApp.Workbooks.Open(dlg.FileName);       // set workbook to open the file.
           
            
           // xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);       // set worksheet to first sheet in the workbook.
            xlWorkSheet = xlWorkBook.Sheets[1];
            range = xlWorkSheet.UsedRange;     // set range to work on.

            for (var i = 2; i <= range.Rows.Count; i++)    // start add value to the range. skip the first on which for the header.
            {
                    MyData.Add(new MyClass
                    {
                        UserID = (int)(range.Cells[i, 1] as Excel.Range).Value2,
                        FName = (string)(range.Cells[i, 2] as Excel.Range).Value2,
                        LName = (string)(range.Cells[i, 3] as Excel.Range).Value2,
                        MName = (string)(range.Cells[i, 4] as Excel.Range).Value2,
                        //Type = (MyClass.UserTypes)Enum.Parse(typeof(UserTypes), (string)(range.Cells[i, 3] as Excel.Range).Value2)
                    });
            }

            xlWorkBook.Close(true, null, null);
            xlApp.Quit();

            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Unable to release the Object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        } 

    }
}
