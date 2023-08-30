using RestaurantLibrary;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
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

namespace RestaurantApp
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        clsSystem restaurant = new clsSystem();
        private List<String> menu = new List<string>();
        private List<double> price = new List<double>();
        private List<String> varTableID = new List<string>();
        private List<int> varTableState = new List<int>();
        public MainWindow()
        {
            
            InitializeComponent();
            string executablePath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
            string databasePath = System.IO.Path.Combine(executablePath, "RestaurantDataBase/RestaurantDB.sqlite");

            string connectionString = "Data Source=" + databasePath;
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteCommand command1 = new SQLiteCommand("SELECT table_id,table_state FROM FLDtable", connection))
                {
                    using (SQLiteDataReader reader = command1.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            try
                            {
                                varTableID.Add(reader.GetString(0));
                                varTableState.Add(reader.GetInt32(1));
                            }
                            catch (Exception)
                            {

                                throw;
                            }

                            // Accede a los datos de cada fila aquí
                        }
                    }
                }
                using (SQLiteCommand command = new SQLiteCommand("SELECT food_name, food_price FROM FLDMenu", connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            try
                            {
                                menu.Add(reader.GetString(0));
                                price.Add(reader.GetDouble(1));
                            }
                            catch (Exception)
                            {

                            }
                            // Accede a los datos de cada fila aquí
                        }
                    }
                }

            }
            for (int i = 0; i < varTableID.Count; i++)
            {
                restaurant.CreateTable(varTableID[i], varTableState[i]);
            }
            for(int i = 0; i < 10; i++)
            {
                restaurant.GenerateBill(0,null,null,null,null);
            }
            restaurant.createMenu(menu, price);

        }
        public MainWindow(clsSystem restaurant)
        {
            InitializeComponent();
            this.restaurant = restaurant;
        }
        

        private void cashier_button_Click(object sender, RoutedEventArgs e)
        {
            Cashier_view formCashier = new Cashier_view(restaurant);
            formCashier.Show();
            Hide();
        }

        private void Waiter_button_Click(object sender, RoutedEventArgs e)
        {
            WaiterProfiles formWaiter = new WaiterProfiles(restaurant);
            formWaiter.Show();
            Hide();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            test.test test = new test.test(restaurant);
            test.Show();
            Hide();
        }
    }
}
