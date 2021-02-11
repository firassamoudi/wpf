using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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

namespace WpfApplication4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            getDepts();
        }
        public List<Departements> getDepts()
        {
            
            List<Departements> l = new List<Departements>();
            //string connstring = ConfigurationManager.ConnectionStrings["test2020Entities"].ConnectionString;
            using (SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=test2020;Integrated Security=True"))
            {
                using (con)
                {
                    SqlCommand command = new SqlCommand(
                      "SELECT * FROM Departements;",
                      con);
                    con.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                          while (reader.Read())
                          {
                            Departements d = new Departements();
                            d.nomDept = reader.GetString(1);
                            d.IdDept = reader.GetInt32(0);
                            l.Add(d);
                          }
                        DepartementsGrid.ItemsSource = l.ToList();
                    }
                    else
                    {
                        Console.WriteLine("No rows found.");
                    }
                    reader.Close();
                }
            }
              return l;

        }

        private void AddDep(object sender, RoutedEventArgs e)
        {
            addDep addDep = new addDep();
            addDep.Show();
        }

        private void deleteDep(object sender, RoutedEventArgs e)
        {
            int id = (DepartementsGrid.SelectedItem as Departements).IdDept;
            confirmDelete conf = new confirmDelete(id);
            conf.Show();
        }
        private void openUpDep(object sender, RoutedEventArgs e)
        {
            int id = (DepartementsGrid.SelectedItem as Departements).IdDept;
            updateDept up = new updateDept(id);
            up.Show();
        }
        private void AddEmp(object sender, RoutedEventArgs e)
        {
            empwin emplo = new empwin();
            emplo.Show();
        }
    }
}
