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
    /// Interaction logic for empwin.xaml
    /// </summary>
    public partial class empwin : Window
    {
        public empwin()
        {
            
            InitializeComponent();
            getEmps();
        }
        public List<Employees> getEmps()
        {
            List<Employees> emList = new List<Employees>();
            //string connstring = ConfigurationManager.ConnectionStrings["test2020Entities"].ConnectionString;
            using (SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=test2020;Integrated Security=True"))
            {
                using (con)
                {
                    SqlCommand command = new SqlCommand(
                      "SELECT * FROM Employees;",
                      con);
                    con.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Employees emp = new Employees();
                            emp.nom = reader.GetString(2);
                            emp.IdEmp = reader.GetInt32(0);
                            emp.prenom = reader.GetString(3);
                            emList.Add(emp);
                        }
                        empGrid.ItemsSource = emList;
                    }
                    else
                    {
                        Console.WriteLine("No rows found.");
                    }
                    reader.Close();
                }
            }
            return emList;
        }
        private void AddEmp(object sender, RoutedEventArgs e)
        {
            Addemp addEmp = new Addemp();
            addEmp.Show();
        }
        private void openUpEmp(object sender, RoutedEventArgs e)
        {
            int id = (empGrid.SelectedItem as Employees).IdEmp;
            updateEmp upEmp = new updateEmp(id);
            upEmp.Show();
        }
        private void deleteEmp(object sender, RoutedEventArgs e)
        {
            int id = (empGrid.SelectedItem as Employees).IdEmp;
            confDeletEmp delEmp = new confDeletEmp(id);
            delEmp.Show();
        }
    }
}
