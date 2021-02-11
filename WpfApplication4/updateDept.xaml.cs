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
    /// Interaction logic for updateDept.xaml
    /// </summary>
    public partial class updateDept : Window
    {
        int idDept;
        public updateDept(int id)
        {
            idDept = id;
            InitializeComponent();
        }

        private void updDep(object sender, RoutedEventArgs e)
        {
            string nom = nomDept.Text;
            using (SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=test2020;Integrated Security=True"))
            {
                using (con)
                {
                    SqlCommand command = new SqlCommand(
                      "UPDATE [dbo].[Departements] SET nomDept = '"+nom+"' WHERE IdDept="+ idDept+";",
                      con);
                    con.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Close();
                }
            }
            this.Close();
        }
    }
}
