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
        SqlConnection connectionDataBase;

        private string login;
        private string password;

        public MainWindow()
        {
            InitializeComponent();
            OpenDataBase();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            login = LoginText.Text;
            password = PasswordText.Text;
            ErrorText.Content = string.Empty;
            if (Verification())
            {
                connectionDataBase.Close();
                OpenMS();
                OpenDB();
                Window2 window2 = new Window2(connectionMS, connectionDB);
                Close();
                window2.Show();
            }
            else
            {
                ErrorText.Content = "Неверный логин или пароль";
            }
        }

        private void OpenMS()
        {
            SqlConnectionStringBuilder sqlString = new SqlConnectionStringBuilder()
            {
                DataSource = @"(localdb)\MSSQLLocalDB",
                InitialCatalog = @"MSAccess",
                IntegratedSecurity = true,
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

        private void OpenDataBase()
        {
            SqlConnectionStringBuilder sqlString = new SqlConnectionStringBuilder()
            {
                DataSource = @"(localdb)\MSSQLLocalDB",
                InitialCatalog = @"DataBase",
                IntegratedSecurity = true,
                Pooling = true
            };
            connectionDataBase = new SqlConnection(sqlString.ConnectionString);
            connectionDataBase.Open();
            
        }
        /// <summary>
        /// Проверка логина и пороля из таблицы Verification
        /// </summary>
        /// <returns></returns>
        private bool Verification()
        {
            var sql = $@"Select* from Verification Where Email = '{login}' and Password = '{password}'";
            SqlCommand command = new SqlCommand(sql, connectionDataBase);
            SqlDataReader r = command.ExecuteReader();
            bool a = r.HasRows;
            r.Close();
            return a;
        }
    }
}
