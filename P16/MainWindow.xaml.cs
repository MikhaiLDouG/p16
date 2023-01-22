using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace P16
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection connectionMS;
        SqlConnection connectionDB;

        private string name;
        private string password;

        public MainWindow()
        {
            InitializeComponent();
            OpenMS();
            OpenDB();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window2 window2 = new Window2(connectionMS, connectionDB);
            Close();
            window2.Show();
        }

        private void OpenMS()
        {
            SqlConnectionStringBuilder sqlString = new SqlConnectionStringBuilder()
            {
                DataSource = @"(localdb)\MSSQLLocalDB",
                InitialCatalog = @"MSAccess",
                IntegratedSecurity = true,
                UserID = $"name", Password = $"password",
                Pooling = true
            };
            connectionMS = new SqlConnection(sqlString.ConnectionString);
            connectionMS.StateChange +=
            (s, e) => { MSState.Content = $"{(s as SqlConnection).State}"; };
            connectionMS.Open();
        }

        private void OpenDB()
        {
            SqlConnectionStringBuilder sqlString = new SqlConnectionStringBuilder()
            {
                DataSource = @"(localdb)\MSSQLLocalDB",
                InitialCatalog = @"MSSQLLocalDB16",
                IntegratedSecurity = true,
                Pooling = true
            };
            connectionDB = new SqlConnection(sqlString.ConnectionString);
            connectionDB.StateChange +=
            (s, e) => { DBState.Content = $"{(s as SqlConnection).State}"; };
            connectionDB.Open();
        }
    }
}
