using RestaurantLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantApp
{
    public partial class Eated_Summary : Form
    {
        clsSystem restaurant = new clsSystem();
        int varTable,varEmployer;
        public Eated_Summary(clsSystem restaurant,int prmTable)
        {
            this.varTable= prmTable;
            this.restaurant = restaurant;
            InitializeComponent();
            for (int i = 0; i < Math.Max(restaurant.GetFldMyBill(prmTable).GetBillItemList().Count, restaurant.GetFldMyBill(prmTable).GetBillItemPrice().Count); i++)
            {
                ListViewItem item = new ListViewItem();
                if (i < restaurant.GetFldMyBill(prmTable).GetBillItemList().Count)
                    item.Text = restaurant.GetFldMyBill(prmTable).GetBillItemList()[i];
                if (i < restaurant.GetFldMyBill(prmTable).GetBillItemPrice().Count)
                    item.SubItems.Add(restaurant.GetFldMyBill(prmTable).GetBillItemPrice()[i].ToString());
                listView1.Items.Add(item);
            }
            this.label4.Text=restaurant.GetFldMyBill(prmTable).GetBillAmount().ToString();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Eated_Summary_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string executablePath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
            string databasePath = System.IO.Path.Combine(executablePath, "RestaurantDataBase/RestaurantDB.sqlite");

            string connectionString = "Data Source=" + databasePath;
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                String txtComand = "INSERT INTO FLDBill (bill_id, table_id,emp_name,total_price) VALUES (@bill_id, @table_id,@emp_name,@total_price)";
                using (SQLiteCommand command = new SQLiteCommand(txtComand, connection))
                {
                    command.Parameters.AddWithValue("@bill_id", restaurant.GetFldMyBill(varTable).GetBillID());
                    command.Parameters.AddWithValue("@table_id", restaurant.GetFldTable(varTable));
                    command.Parameters.AddWithValue("@emp_name", restaurant.GetFldMyBill(varTable).GetEmpID());
                    command.Parameters.AddWithValue("@total_price", restaurant.GetFldMyBill(varTable).GetBillAmount());
                    int rowsAffected = command.ExecuteNonQuery();
                }
            }
            restaurant.setTableState(varTable, 0);
            Cashier_view cashier_View = new Cashier_view(restaurant);
            cashier_View.Show();
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cashier_view cashier_View = new Cashier_view(restaurant);
            cashier_View.Show();
            Close();
        }
    }
}
