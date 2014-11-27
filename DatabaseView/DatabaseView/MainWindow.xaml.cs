using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading;
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
//using DatabaseView.Model;



namespace DatabaseView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //local property
        //DataGrid localData = new DataGrid();
        public List<Student> Myusers = new List<Student>();
        //public ObservableCollection<Student> Myusers { get; set; }
        OpenFileDialog dlg = new OpenFileDialog();
        Excel.Application excelApp = new Excel.Application();
        Excel.Workbook workbook;
        Excel.Worksheet worksheet;
        Excel.Range range;
        
        
        public MainWindow()
        {
            InitializeComponent();   
           
            
            
        }
        public void workSheethelper()
        {
            dlg.DefaultExt = ".txt";
            dlg.Filter = "EXCEL Files (*.xls)|*.xlsx";
            Nullable<bool> result = dlg.ShowDialog();
            if (result.Value)
            {
                workbook = excelApp.Workbooks.Open(dlg.FileName, 0, true, 5, "", "", true, 
                    Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);               
            }

            
            int numSheets = workbook.Sheets.Count; // get number of sheet in the workbook
            for (int sheetNum = 1; sheetNum < numSheets + 1; sheetNum++)
            {
                worksheet = (Excel.Worksheet)workbook.Sheets[sheetNum];          
                range = worksheet.UsedRange;
                for (var i = 2; i <= range.Rows.Count; i++)    // start add value to the range. skip the first on which for the header.
                {
                    Myusers.Add(new Student
                    {
                        Id = i,//(int)(range.Cells[i, 1] as Excel.Range).Value2,
                        FName = helperRetriveString(i, 1),
                        LName = helperRetriveString(i, 2),
                        MName = helperRetriveString(i,3),
                        Status = (Student.status)Enum.Parse(typeof(Student.status), (string)(range.Cells[i, 4] as Excel.Range).Value2),
                        FinaAid = helperBool(i,5),
                        visaStats =(Student.visaStatus)Enum.Parse(typeof(Student.visaStatus), (string)(range.Cells[i, 6] as Excel.Range).Value2) ,
                        fullTime = helperBool(i,7),
                        StartDate = helperRetriveDate(i, 8),
                        ScheduleDate = helperRetriveDate(i, 9),
                        EndDate = helperRetriveDate(i,10),
                        Note = helperRetriveString(i,11),
                        Address = helperRetriveString(i,12),
                        CellPhone =(double)(range.Cells[i, 13] as Excel.Range).Value2, 
                        Gender =(Student.gender)Enum.Parse(typeof(Student.gender), (string)(range.Cells[i, 14] as Excel.Range).Value2),
                        SSN = helperRetriveInt(i, 15),
                        driverLicenseNumber = helperRetriveString(i,16)  ,
                        DOB = helperRetriveDate(i,17) ,
                        ByAge = (Student.byage)Enum.Parse(typeof(Student.byage),helperByAge(helperRetriveInt(i,18))) ,
                        Country = helperRetriveString(i,19),
                        CountryOfPaperWork = helperRetriveString(i, 20),
                        KindOfPaperWork = helperRetriveString(i, 21),
                        paperNumber = helperRetriveInt(i, 22) ,
                        Ethic = (Student.ethic)Enum.Parse(typeof(Student.ethic), helperEthic(helperRetriveString(i,23))),
                        Transfer = helperBool(i,24),
                        HoursTransfer = helperRetriveInt(i,25),
                        TotalEnroll = helperRetriveInt(i, 26),
                        TotalHours = helperRetriveInt(i, 27),
                        LeaveOrAbsense = helperBool(i,28),
                        WithDraw = helperBool(i,31),
                        TheoryExam = helperRetriveDate(i,32),
                        PracticeExam = helperRetriveDate(i, 33),
                        JobPalcement = helperRetriveString(i, 34),
                        Sap300 = helperRetriveInt(i, 35),
                        Sap600 = helperRetriveInt(i, 36),

                    });
                    if ((range.Cells[i+1,1] as Excel.Range).Value2 == null)
                    {
                        i = range.Rows.Count;
                    }
                }
            }
            workbook.Close(true, null, null);
            excelApp.Quit();
            MainDataGrid.ItemsSource = Myusers;
        }
        #region helper read cell from excel file
        // helper, read the cell and return type
        public bool helperBool(int row, int column)
        {
            try
            {
                return (bool)(range.Cells[row, column] as Excel.Range).Value2;
            }
            catch (Exception)
            {

                return false;
            }
        }        
        public int helperRetriveInt(int row , int column)
        {
            try
            {
                return (int)(range.Cells[row, column] as Excel.Range).Value2;
            }
            catch (Exception)
            {

                return 0;
            }
            
        }
        public string helperRetriveString(int row, int column)
        {
            try
            {
                return (string)(range.Cells[row, column] as Excel.Range).Value2;
            }
            catch (Exception)
            {              
                return "Need to replace value" ;
            }
            
        }
        public DateTime helperRetriveDate(int row, int column)
        {
            try
            {
                return DateTime.Parse(ConvertToDateTime(((Excel.Range)range.Cells[row, column]).Value2.ToString()));
            }
            catch (Exception)
            {

                return new DateTime();
            }

            
        }
        //helper, change the word to be specific used
        public string helperByAge(int age)
        {
            string result = "unknown";
            if (age < 18)
                result = "Under18";
            else if (age < 25)
                result = "eigteentotwentyfour";
            else if (age < 40)
                result = "twentyfivetothirtynine";
            else if (age > 40)
                result = "fourtyplus";

            return result;

        }
        public string helperEthic(string ethic)
        {
            string result = "unknown";
            if (ethic == "Asian")
                result = "Asian";
            else if (ethic == "Hispanic/Latino")
                result = "Hispanic_Latino";
            else if (ethic == "American Indian or Alaska Native")
                result = "American_Native";
            else if (ethic == "Nonresident ailen")
                result = "Non_resident_ailen";
            else if (ethic == "Black or Africa American")
                result = "Africa_American";
            else if (ethic == "Native Hawaiian or Other Pacific Islander")
                result = "Pacific_Islander";
            else if (ethic == "White")
                result = "White";
            else if (ethic == "Two or more races")
                result = "Two_or_More";
            else if (ethic == "Race and ethnicity unknown")
                result = "unknown";




            return result;

        }
        //use to convert date time from excel cell value.
        public static string ConvertToDateTime(string strExcelDate)
        {
            double excelDate;
            try
            {
                excelDate = Convert.ToDouble(strExcelDate);
            }
            catch
            {
                return strExcelDate;
            }
            if (excelDate < 1)
            {
                throw new ArgumentException("Excel dates cannot be smaller than 0.");
            }
            DateTime dateOfReference = new DateTime(1900, 1, 1);
            if (excelDate > 60d)
            {
                excelDate = excelDate - 2;
            }
            else
            {
                excelDate = excelDate - 1;
            }
            return dateOfReference.AddDays(excelDate).ToShortDateString();
        }
        #endregion
        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            workSheethelper();
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            MainDataGrid.ItemsSource = null;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            workSheethelper();
        }       
    }
}
