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
    public partial class Table_States : Form
    {
        private clsSystem restaurant;
        private int varPoss;
        private int VarEmpID;
        private int state;
        public Table_States(clsSystem restaurant, int prmID, int prmPoss)
        {
            this.state = restaurant.GetTableState(prmPoss);
            this.VarEmpID= prmID;
            this.varPoss= prmPoss;
            this.restaurant = restaurant;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            restaurant.setTableState(varPoss, state);
            Tables_waiter_perspective tables_Waiter_Perspective = new Tables_waiter_perspective(restaurant, VarEmpID);
            tables_Waiter_Perspective.Show();
            Close();

        }

        private void Table_States_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Tables_waiter_perspective tables_Waiter_Perspective = new Tables_waiter_perspective(restaurant,VarEmpID);
            tables_Waiter_Perspective.Show();
            Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            restaurant.setTableState(varPoss,0);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            restaurant.setTableState(varPoss, 1);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            restaurant.setTableState(varPoss, 2);
            Waiting_and_Menu waiting_And_Menu = new Waiting_and_Menu(restaurant, restaurant.GetFldTable(varPoss),varPoss,VarEmpID);
            waiting_And_Menu.Show();
            Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if(restaurant.GetTableState(varPoss) == 2)
            {
                restaurant.setTableState(varPoss, 3);
            }
        }
    }
}
