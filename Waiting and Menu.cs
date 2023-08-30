using RestaurantLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantApp
{
    public partial class Waiting_and_Menu : Form
    {
        clsSystem restaurant = new clsSystem();
        protected double varTotalBill = 0;
        List<String> food = new List<String>();
        List<double> price = new List<double>();
        int varEmpID;
        String varTableID;
        int varPoss;
        public Waiting_and_Menu(clsSystem restaurant,String prmTableID,int prmTablePoss,int prmEmployer)
        {
            restaurant.GenerateBill(0, null, null, restaurant.FldMyEmployer[prmEmployer].GetName(), varTableID);
            this.varEmpID= prmEmployer;
            this.varPoss = prmTablePoss;
            this.restaurant = restaurant;
            this.varTableID= prmTableID;
            
            InitializeComponent();
            foreach (String s in restaurant.getMenuFood()) {
                this.comboBox1.Items.Add(s);

            }
            this.label4.Text = varTotalBill.ToString();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ListViewItem item = new ListViewItem();
            item.Text = this.comboBox1.Text;
            try
            {
                item.SubItems.Add(restaurant.getMenuPrice()[this.comboBox1.SelectedIndex].ToString());
                listView1.Items.Add(item);
                varTotalBill += restaurant.getMenuPrice()[this.comboBox1.SelectedIndex];
                this.label4.Text = varTotalBill.ToString();
                food.Add(this.comboBox1.Text);
                price.Add(restaurant.getMenuPrice()[this.comboBox1.SelectedIndex]);
            }
            catch (Exception)
            {

            }
            
            
            
                //item.SubItems.Add(restaurant.getMenuPrice().ToString());
            

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Waiting_and_Menu_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            restaurant.UpdateBill(varPoss, varTotalBill, food, price, restaurant.FldMyEmployer[varEmpID].GetName());
            Tables_waiter_perspective tables_Waiter_Perspective = new Tables_waiter_perspective(restaurant, varEmpID);
            tables_Waiter_Perspective.Show();
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            Tables_waiter_perspective tables_Waiter_Perspective = new Tables_waiter_perspective(restaurant, varEmpID);
            tables_Waiter_Perspective.Show();
            Close();
        }
    }
}
