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
    /// Логика взаимодействия для AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        public AddWindow(DataRow r)
        {
            InitializeComponent();
            cancelBtn.Click += delegate { DialogResult = false; };

            OkBtn.Click += delegate
            {
                r["Surname"] = SurnameText.Text;
                r["Name"] = NameText.Text;
                r["Name2"] = Name2Text.Text;
                if (!String.IsNullOrEmpty(PhoneText.Text))
                {
                    r["Phone"] = int.Parse(PhoneText.Text);
                }
                r["Email"] = EmailText.Text;
                DialogResult = true;
            };
        }
    }
}
