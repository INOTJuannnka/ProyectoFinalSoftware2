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
    public partial class Tables_waiter_perspective : Form
    {
        clsSystem restaurant = new clsSystem();
        private int varEmpID;
        protected List<Button> buttonList = new List<Button>();
        public Tables_waiter_perspective(clsSystem restaurant,int prmID)
        {
            this.varEmpID = prmID;
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
            if (restaurant.FldMyTable.Count > 0)
            {
                for (int i = 0; i < restaurant.FldMyTable.Count; i++)
                {
                    buttonList[i].Show();
                    if(restaurant.GetTableState(i)==1)
                    {
                        buttonList[i ].BackColor = Color.Chartreuse;
                    }
                    else if (restaurant.GetTableState(i) == 2)
                    {
                        buttonList[i ].BackColor = Color.Chocolate;
                    }
                    else if (restaurant.GetTableState(i) == 3)
                    {
                        buttonList[i].BackColor = Color.Red;
                    }

                }
            }
            

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {

        }

        private void Tables_waiter_perspective_Load(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            MainWindow mainWindow = new MainWindow(restaurant);
            mainWindow.Show();
            Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Table_States table_States = new Table_States(restaurant, varEmpID, 0);
            table_States.Show();
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Table_States table_States = new Table_States(restaurant, varEmpID, 1);
            table_States.Show();
            Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Table_States table_States = new Table_States(restaurant, varEmpID, 2);
            table_States.Show();
            Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Table_States table_States = new Table_States(restaurant, varEmpID, 3);
            table_States.Show();
            Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Table_States table_States = new Table_States(restaurant, varEmpID, 4);
            table_States.Show();
            Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Table_States table_States = new Table_States(restaurant, varEmpID, 5);
            table_States.Show();
            Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Table_States table_States = new Table_States(restaurant, varEmpID, 6);
            table_States.Show();
            Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Table_States table_States = new Table_States(restaurant, varEmpID, 7);
            table_States.Show();
            Close();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Table_States table_States = new Table_States(restaurant, varEmpID, 8);
            table_States.Show();
            Close();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Table_States table_States = new Table_States(restaurant, varEmpID, 9);
            table_States.Show();
            Close();
        }
    }
}
