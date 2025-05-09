﻿using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

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

        private void delete_button_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string selectedLogin = dataGridView1.SelectedRows[0].Cells["login"].Value.ToString();

                sqlreader.DeleteUser(selectedLogin);
                dataGridView1.DataSource = sqlreader.ReadUsers();
            }

            else
            { MessageBox.Show("Выбери кого удалить"); }
        }
    }
}
