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
using System.Data.SqlClient;
using System.Data;

namespace P16
{
    /// <summary>
    /// Логика взаимодействия для WindowProduct.xaml
    /// </summary>
    public partial class WindowProduct : Window
    {
        public WindowProduct(DataRowView email, SqlConnection DBConnection)
        {
            InitializeComponent();
            Prepare(email, DBConnection);
        }

        /// <summary>
        /// Выводит список продутов выбранного покупателя
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="DBConnection"></param>
        private void Prepare(DataRowView customer, SqlConnection DBConnection)
        {
            DataTable dataTable = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter();

            var sql = $@"Select * from Product
Where Email like '%{customer.Row["Email"]}%'";  // не особо понял, можно ли так делать 
            dataAdapter.SelectCommand = new SqlCommand(sql, DBConnection);
            dataAdapter.Fill(dataTable);
            grid.DataContext = dataTable.DefaultView;
        }
    }
}
