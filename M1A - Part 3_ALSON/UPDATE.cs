using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace M1A___Part_3_ALSON
{
    public partial class UPDATE : Form
    {
        public UPDATE()
        {
            InitializeComponent();

            READ.Click += READ_Click;
            INSERT.Click += INSERT_Click;
            DELETION.Click += DELETION_Click;
            EXIT.Click += EXIT_Click;
        }

        private void READ_Click(object sender, EventArgs e)
        {
            string message;
            if (SQL.TestConnection(out message))
            {
                var RetriveForm = new Retrieve();
                RetriveForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show(message, "Error");
            }
        }
        private void INSERT_Click(object sender, EventArgs e)
        {
            string message;
            if (SQL.TestConnection(out message))
            {
                var RetriveForm = new MAIN();
                RetriveForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show(message, "Error");
            }

        }
        private void DELETION_Click(object sender, EventArgs e) 
        {
            string message;
            if (SQL.TestConnection(out message))
            {
                var RetriveForm = new DELETION();
                RetriveForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show(message, "Error");
            }

        }
        private void EXIT_Click(object sender, EventArgs e) 
        {
            Application.Exit();
        }
    }
}
