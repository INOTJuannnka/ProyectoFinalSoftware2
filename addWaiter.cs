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
    public partial class addWaiter : Form
    {
        clsSystem restaurant = new clsSystem();
        public addWaiter(clsSystem restaurant)
        {
            this.restaurant= restaurant;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(this.textBox1 != null && this.textBox2 != null)
            {
                restaurant.NewEmployer(this.textBox1.Text, this.textBox2.Text);
                WaiterProfiles waiterProfiles = new WaiterProfiles(restaurant);
                waiterProfiles.Show();
                Close();
            }

            Close();
        }

        private void addWaiter_Load(object sender, EventArgs e)
        {

        }
    }
}
