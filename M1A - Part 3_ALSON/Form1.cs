using System;
using System.Data;
using System.Windows.Forms;

namespace M1A___Part_3_ALSON
{
    public partial class Form1 : Form
    {    
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Optional: connection test or data load on form open
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string message;
            if (SQL.TestConnection(out message))
            {
                MessageBox.Show(message, "Success");
                var entryForm = new MAIN();
                this.Hide();
                entryForm.Show();
            }
            else
            {
                MessageBox.Show(message, "Error");
            }
        }

    }
}
