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
using System.Windows.Shapes;

namespace DatabaseView
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            DatabaseView.StudentDatabaseDataSet studentDatabaseDataSet = ((DatabaseView.StudentDatabaseDataSet)(this.FindResource("studentDatabaseDataSet")));
            // Load data into the table Login. You can modify this code as needed.
            DatabaseView.StudentDatabaseDataSetTableAdapters.LoginTableAdapter studentDatabaseDataSetLoginTableAdapter = new DatabaseView.StudentDatabaseDataSetTableAdapters.LoginTableAdapter();
            studentDatabaseDataSetLoginTableAdapter.Fill(studentDatabaseDataSet.Login);
            System.Windows.Data.CollectionViewSource loginViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("loginViewSource")));
            loginViewSource.View.MoveCurrentToFirst();
        }
    }
}
