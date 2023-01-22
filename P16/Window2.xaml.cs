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

    public partial class Window2 : Window
    {
        SqlConnection MSConnection;
        SqlConnection DBConnection;
        SqlDataAdapter dataAdapter;
        DataTable dataTable;
        DataRowView row;

        public Window2(SqlConnection MSConnection, SqlConnection DBConnection)
        {
            InitializeComponent();
            this.MSConnection = MSConnection;
            this.DBConnection = DBConnection;
            PreparingMS();
        }

        private void PreparingMS()
        {
            dataTable = new DataTable();
            dataAdapter = new SqlDataAdapter();

            #region SELECT
            var sql = @"SELECT * FROM Customer";
            dataAdapter.SelectCommand = new SqlCommand(sql, MSConnection);
            #endregion

            #region INSERT

            sql = @"INSERT INTO Customer(Surname, Name, Name2, Phone, Email) 
                                            VALUES (@Surname, @Name, @Name2, @Phone, @Email);
                    SET @ID = @@IDENTITY"; ;

            dataAdapter.InsertCommand = new SqlCommand(sql, MSConnection);

            dataAdapter.InsertCommand.Parameters.Add("@ID", SqlDbType.Int, 4, "ID").Direction = ParameterDirection.Output;
            dataAdapter.InsertCommand.Parameters.Add("@Surname", SqlDbType.NChar, 10, "Surname");
            dataAdapter.InsertCommand.Parameters.Add("@Name", SqlDbType.NChar, 10, "Name");
            dataAdapter.InsertCommand.Parameters.Add("@Name2", SqlDbType.NChar, 10, "Name2");
            dataAdapter.InsertCommand.Parameters.Add("@Phone", SqlDbType.Int, 10, "Phone");
            dataAdapter.InsertCommand.Parameters.Add("@Email", SqlDbType.NVarChar, 50, "Email");

            #endregion

            #region UPDATE
            sql = @"UPDATE Customer SET
                    Surname = @Surname,
                    Name = @Name,
                    Name2 = @Name2,
                    Phone = @Phone,
                    Email = @Email
            WHERE ID = @ID";
            

            dataAdapter.UpdateCommand = new SqlCommand(sql, MSConnection);

            dataAdapter.UpdateCommand.Parameters.Add("@ID", SqlDbType.Int, 0, "ID").SourceVersion = DataRowVersion.Original;
            dataAdapter.UpdateCommand.Parameters.Add("@Surname", SqlDbType.NChar, 10, "Surname");
            dataAdapter.UpdateCommand.Parameters.Add("@Name", SqlDbType.NChar, 10, "Name");
            dataAdapter.UpdateCommand.Parameters.Add("@Name2", SqlDbType.NChar, 10, "Name2");
            dataAdapter.UpdateCommand.Parameters.Add("@Phone", SqlDbType.Int, 10, "Phone");
            dataAdapter.UpdateCommand.Parameters.Add("@Email", SqlDbType.NVarChar, 50, "Email");
            #endregion

            #region DELETE

            sql = "DELETE From Customer Where ID = @ID";
            dataAdapter.DeleteCommand = new SqlCommand(sql, MSConnection);
            dataAdapter.DeleteCommand.Parameters.Add("@ID", SqlDbType.Int, 4, "ID");
            #endregion

            dataAdapter.Fill(dataTable);
            grid.DataContext = dataTable.DefaultView;
        }

        private void GVCurrentCellChanged(object sender, EventArgs e)
        {
            if (row == null) return;

            row.EndEdit();
            dataAdapter.Update(dataTable);
        }

        private void GVCellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            row = (DataRowView)grid.SelectedItem;
            row.BeginEdit();
            dataAdapter.Update(dataTable);
        }
        
        /// <summary>
        /// Добавление покупателя
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItemAddClick(object sender, RoutedEventArgs e)
        {
            DataRow r = dataTable.NewRow();
            AddWindow add = new AddWindow(r);
            add.ShowDialog();
            if (add.DialogResult.Value)
            {
                dataTable.Rows.Add(r);
                dataAdapter.Update(dataTable);
            }
        }

        /// <summary>
        /// Открывает окно покупок выбранного покупателя
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowAllProduct(object sender, RoutedEventArgs e)
        {
            row = (DataRowView)grid.SelectedItem;
            WindowProduct w = new WindowProduct(row ,DBConnection);
            w.Show();
        }

        /// <summary>
        /////// Удаляет покупателя
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteClick(object sender, RoutedEventArgs e)
        {
            row = (DataRowView)grid.SelectedItem;
            row.Row.Delete();
            dataAdapter.Update(dataTable);
        }
    }
}