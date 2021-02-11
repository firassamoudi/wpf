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
using System.Windows.Shapes;

namespace WpfApplication4
{
    /// <summary>
    /// Interaction logic for confDeletEmp.xaml
    /// </summary>
    public partial class confDeletEmp : Window
    {
        int idEmp;
        public confDeletEmp(int id)
        {
            idEmp = id;
            InitializeComponent();
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=test2020;Integrated Security=True"))
            {
                using (con)
                {
                    SqlCommand command = new SqlCommand(
                      "DELETE [dbo].[Employees] WHERE IdEmp=" + idEmp + ";",
                      con);
                    con.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Close();
                }
            }
            this.Close();

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
