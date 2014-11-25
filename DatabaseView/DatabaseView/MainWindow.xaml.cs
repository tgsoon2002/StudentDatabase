using System;
using System.Collections.Generic;
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
        List<Student> users = new List<Student>();
        Excel.Application excelApp = new Excel.Application();
        Excel.Workbook workbook;
        Excel.Worksheet worksheet;
        Excel.Range range;
        
        
        public MainWindow()
        {
            InitializeComponent();


            //users.Add(new Student() { Id = 1, FName = "John Doe", DOB = new DateTime(1971, 7, 23) });
            //users.Add(new Student() { Id = 2, FName = "Jane Doe", DOB = new DateTime(1974, 1, 17) });
            //users.Add(new Student() { Id = 3, FName = "Sammy Doe", DOB = new DateTime(1991, 9, 2) });

            //DataGrid.ItemsSource = users;
            workbook = excelApp.Workbooks.Open(Environment.CurrentDirectory + "\\Excel.xlsx");
            worksheet = (Excel.Worksheet)workbook.Sheets["Test Sheet"];
            int column = 0;
            //int row = 0;

            range = worksheet.UsedRange;
            DataGrid dt = new DataGrid();
            for (column = 1; column <= range.Columns.Count; column++)
            {
                //dr[column - 1] = (range.Cells[row, column] as Excel.Range).Value2.ToString();
                dt.Columns.Add((range.Cells[1, column] as Excel.Range).Value2.ToString());
            }
            //dt.Columns.Add("ID");
            //dt.Columns.Add("Name");
            //dt.Columns.Add("Position");
            //dt.Columns.Add("Web Site");
            //for (row = 2; row <= range.Rows.Count; row++)
            //{
            //    DataRow dr = dt.NewRow();
            //    for (column = 1; column <= range.Columns.Count; column++)
            //    {
            //        dr[column - 1] = (range.Cells[row, column] as Excel.Range).Value2.ToString();
            //    }
            //    dt.Rows.Add(dr);
            //    dt.AcceptChanges();
            //}
            //workbook.Close(true, Missing.Value, Missing.Value);
            //excelApp.Quit();
            //return dt.DefaultView;
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
            DataGrid.ItemsSource = null;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
           
        }       
    }
}
