using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using Excel = Microsoft.Office.Interop.Excel;

namespace DatabaseView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //local property
        DataGrid localData = new DataGrid();
        public ObservableCollection<Student> Myusers {get;set;}

        Excel.Application excelApp = new Excel.Application();
        Excel.Workbook workbook;
        Excel.Worksheet worksheet;
        Excel.Range range;
        
        
        public MainWindow()
        {
            InitializeComponent();   
            OpenFileDialog dlg = new OpenFileDialog();
            Nullable<bool> result = dlg.ShowDialog();
            workbook = excelApp.Workbooks.Open(dlg.FileName);
            workSheethelper(workbook);
            workbook.Close(true, null, null);
            excelApp.Quit();
        }
        public void workSheethelper(Excel.Workbook workBookIn)
        {
            int numSheets = workBookIn.Sheets.Count; // get number of sheet in the workbook
            for (int sheetNum = 1; sheetNum < numSheets + 1; sheetNum++)
            {
                worksheet = (Excel.Worksheet)workBookIn.Sheets[sheetNum];
             
                range = worksheet.UsedRange;
                for (var i = 2; i <= range.Rows.Count; i++)    // start add value to the range. skip the first on which for the header.
                {
                    Myusers.Add(new Student
                    {
                        Id = (int)(range.Cells[i, 1] as Excel.Range).Value2,
                        FName = (string)(range.Cells[i, 2] as Excel.Range).Value2,
                        LName = (string)(range.Cells[i, 3] as Excel.Range).Value2,
                        MName = (string)(range.Cells[i, 4] as Excel.Range).Value2,
                       
                    });
                }
               
                //put all cell into 2 dimension array of object                                      
                //object[,] valueArray = (object[,])range.get_Value(Excel.XlRangeValueDataType.xlRangeValueDefault);
                //ProcessObjects(valueArray);
            }
        }
        
        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            //Student newData = new Student();
            //DataGrid.ItemsSource = newData.GetEmpList();  
            //newData.FirstName
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.DefaultExt = ".txt";
            dlg.Filter = "EXCEL Files (*.xls)|*.xlsx";
            Nullable<bool> result = dlg.ShowDialog();
            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document 
                
            }

        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            MainDataGrid.ItemsSource = null;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
           
        }       
    }
}
