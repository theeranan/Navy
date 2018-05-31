using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Navy.Core;

namespace Navy.Forms
{
    public partial class SelectDatabaseForm : Form
    {
        public SelectDatabaseForm()
        {
            InitializeComponent();
            RefreshDisplay(DBConnection.GetConnectionString());
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            DBConnection.SetConnectionString(txtHost.Text, txtUser.Text, txtPassword.Text, cbDatabase.Text);
            DataDefinition.NewConnection();
            this.Close();
        }

        private void RefreshDisplay(MySqlConnectionStringBuilder conn)
        {
            txtHost.Text = conn.Server;
            txtUser.Text = conn.UserID;
            txtPassword.Text = conn.Password;
            cbDatabase.Text = conn.Database;
        }

        private void cbDatabase_Click(object sender, EventArgs e)
        {
            string database = cbDatabase.Text;

            cbDatabase.DataSource = DBConnection.GetAvailableDatabase(txtHost.Text, txtUser.Text, txtPassword.Text);
            cbDatabase.ValueMember = "SCHEMATA";
            cbDatabase.DisplayMember = "SCHEMATA";

            cbDatabase.Text = database;
        }

        private void btnDefault_Click(object sender, EventArgs e)
        {
            RefreshDisplay(new MySqlConnectionStringBuilder(DBConnection.defaultConString));
        }

        private void txtHost_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txtUser_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void cbDatabase_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txtHost_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbDatabase_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
