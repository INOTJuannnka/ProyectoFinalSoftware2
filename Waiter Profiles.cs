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
    public partial class WaiterProfiles : Form
    {
        clsSystem restaurant = new clsSystem();
        private int varCounter = 0;
        public WaiterProfiles(clsSystem restaurant)
        {
            this.restaurant = restaurant;
            InitializeComponent();
            if (restaurant.GetFldEmployer(0) != default)
            {
                button2.Enabled = true;
            }
            else
            {
                button2.Enabled = false;
            }
        }
        public WaiterProfiles(clsSystem restaurant,int prmCounter)
        {
            this.varCounter = prmCounter;
            this.restaurant= restaurant;
            InitializeComponent();
            if (restaurant.GetFldEmployer(0) != default)
            {
                button2.Enabled= true;
            }
            else
            {
                button2.Enabled= false;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(restaurant.GetFldEmployer(0) != default)
            {
                Tables_waiter_perspective waiter_Perspective = new Tables_waiter_perspective(restaurant, 0);
                waiter_Perspective.Show();
                Hide();
            }
            else
            {
                addWaiter addWaiter = new addWaiter(restaurant);
                addWaiter.Show();
                Close();
            }
        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (restaurant.GetFldEmployer(1) != default)
            {
                Tables_waiter_perspective waiter_Perspective = new Tables_waiter_perspective(restaurant, 1);
                waiter_Perspective.Show();
                Hide();
            }
            else
            {
                addWaiter addWaiter = new addWaiter(restaurant);
                addWaiter.Show();
                Close();
            }
        }

        private void WaiterProfiles_Load(object sender, EventArgs e)
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
