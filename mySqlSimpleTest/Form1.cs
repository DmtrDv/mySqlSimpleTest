using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mySqlSimpleTest
{
    public partial class Form1: Form
    {

        SQLUserReader sqlreader = new SQLUserReader();
        public Form1()
        {
            InitializeComponent();
        }
       

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = sqlreader.ReadUsers();
        }
    }
}
