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

namespace DatabaseView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataGrid localData = new DataGrid();
        
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            Student newData = new Student();
            DataGrid.ItemsSource = newData.GetEmpList();    
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            DataGrid.ItemsSource = null;
        }
    }
}
