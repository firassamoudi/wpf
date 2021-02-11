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
    /// Interaction logic for confirmDelete.xaml
    /// </summary>
    public partial class confirmDelete : Window
    {
        int idDept;
        public confirmDelete(int id)
        {
            idDept = id;
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=test2020;Integrated Security=True"))
            {
                using (con)
                {
                    SqlCommand command = new SqlCommand(
                      "DELETE [dbo].[Departements] WHERE IdDept=" + idDept + ";",
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
