using RestaurantLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantApp
{
    public partial class Cashier_view : Form
    {
        private clsSystem restaurant;
        protected List<Button> buttonList=new List<Button>();
        public Cashier_view(clsSystem restaurant)
        {
                this.restaurant = restaurant;
            InitializeComponent();
            #region trash
            buttonList.Add(button3);
            buttonList.Add(button4);
            buttonList.Add(button5);
            buttonList.Add(button6);
            buttonList.Add(button7);
            buttonList.Add(button8);
            buttonList.Add(button9);
            buttonList.Add(button10);
            buttonList.Add(button11);
            buttonList.Add(button12);
            button3.Hide();
            button4.Hide();
            button5.Hide();
            button6.Hide();
            button7.Hide();
            button8.Hide();
            button9.Hide();
            button10.Hide();
            button11.Hide();
            button12.Hide();
            #endregion
                for (int i = 0; i < restaurant.FldMyTable.Count; i++)
                {
                    buttonList[i].Show();
                    if (restaurant.GetTableState(i) == 1)
                    {
                        buttonList[i].BackColor = Color.Chartreuse;
                    }
                    else if (restaurant.GetTableState(i) == 2)
                    {
                        buttonList[i].BackColor = Color.Chocolate;
                    }
                    else if (restaurant.GetTableState(i) == 3)
                    {
                        buttonList[i].BackColor = Color.Red;
                    }

                }
                
            
            this.label3.Text= restaurant.FldMyTable.Count.ToString();
            this.label3.Refresh();

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (restaurant.FldMyTable.Count > 0)
            {
                string executablePath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
                string databasePath = System.IO.Path.Combine(executablePath, "RestaurantDataBase/RestaurantDB.sqlite");

                string connectionString = "Data Source=" + databasePath;
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    String txtComand = "DELETE FROM FLDtable WHERE rowid = (SELECT MAX(rowid) FROM FLDtable)";
                    using (SQLiteCommand command = new SQLiteCommand(txtComand, connection))
                    {
                        int rowsAffected = command.ExecuteNonQuery();
                    }
                }
                restaurant.DeleteTable();
                buttonList[restaurant.FldMyTable.Count].Hide();
                
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (restaurant.FldMyTable.Count <= 9)
            {
                restaurant.CreateTable();
                buttonList[restaurant.FldMyTable.Count-1].Show();
                string executablePath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
                string databasePath = System.IO.Path.Combine(executablePath, "RestaurantDataBase/RestaurantDB.sqlite");

                string connectionString = "Data Source=" + databasePath;
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    String txtComand = "INSERT INTO FLDtable (table_id, table_state) VALUES (@table_id, @table_state)";
                    using (SQLiteCommand command = new SQLiteCommand(txtComand, connection))
                    {
                        command.Parameters.AddWithValue("@table_id", restaurant.GetFldTable(restaurant.FldMyTable.Count-1));
                        command.Parameters.AddWithValue("@table_state", restaurant.GetTableState(restaurant.FldMyTable.Count - 1));
                        int rowsAffected = command.ExecuteNonQuery();
                    }
                }

            }

            

        }
        private void label19_Click(object sender, EventArgs e)
        {

        }

        

        private void label2_Click(object sender, EventArgs e)
        {
            
        }



        private void Cashier_view_Load(object sender, EventArgs e)
        {

        }
        #region tables
        private void button3_Click(object sender, EventArgs e)
        {
            if (restaurant.GetTableState(0) == 3)
            {
                Eated_Summary eated_Summary = new Eated_Summary(restaurant, 0);
                eated_Summary.Show();
                Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (restaurant.GetTableState(1) == 3)
            {
                Eated_Summary eated_Summary = new Eated_Summary(restaurant, 1);
                eated_Summary.Show();
                Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (restaurant.GetTableState(2) == 3)
            {
                Eated_Summary eated_Summary = new Eated_Summary(restaurant, 2);
                eated_Summary.Show();
                Close();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (restaurant.GetTableState(3) == 3)
            {
                Eated_Summary eated_Summary = new Eated_Summary(restaurant, 3);
                eated_Summary.Show();
                Close();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (restaurant.GetTableState(4) == 3)
            {
                Eated_Summary eated_Summary = new Eated_Summary(restaurant, 4);
                eated_Summary.Show();
                Close();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (restaurant.GetTableState(5) == 3)
            {
                Eated_Summary eated_Summary = new Eated_Summary(restaurant, 5);
                eated_Summary.Show();
                Close();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (restaurant.GetTableState(6) == 3)
            {
                Eated_Summary eated_Summary = new Eated_Summary(restaurant, 6);
                eated_Summary.Show();
                Close();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (restaurant.GetTableState(7) == 3)
            {
                Eated_Summary eated_Summary = new Eated_Summary(restaurant, 7);
                eated_Summary.Show();
                Close();
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (restaurant.GetTableState(8) == 3)
            {
                Eated_Summary eated_Summary = new Eated_Summary(restaurant, 8);
                eated_Summary.Show();
                Close();
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (restaurant.GetTableState(9) == 3)
            {
                Eated_Summary eated_Summary = new Eated_Summary(restaurant, 9);
                eated_Summary.Show();
                Close();
            }
        }
        #endregion

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            MainWindow mainWindow = new MainWindow(restaurant);
            mainWindow.Show();
            Close();
        }
    }
}
