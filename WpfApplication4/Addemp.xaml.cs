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
    /// Interaction logic for Addemp.xaml
    /// </summary>
    public partial class Addemp : Window
    {
        public Addemp()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            string nom = nomEmp.Text;
            string prenom = prenomEmp.Text;
            string datedebut = dateDebutEmp.Text;
            using (SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=test2020;Integrated Security=True"))
            {
                using (con)
                {
                    SqlCommand command = new SqlCommand(
                      "INSERT INTO [dbo].[Employees] ( [nom],[prenom], [dateDebut]) VALUES ('" + nom + "', '" + prenom + "','" + datedebut + "');",
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
