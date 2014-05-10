using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace makit.TheCoconutCraniumDecisionEngine.Initiator
{
    public partial class Form3 : Form
    {
        Form loaderForm;
        int counter = 1; // stop hacking
        public Form3(Form loader)
        {
            loaderForm = loader;
            loaderForm.Hide();
            InitializeComponent();
            this.Show();
            this.TopMost = true;
        }

        private void TheLoginButton_Click(object sender, EventArgs e)
        {
            var jeeves = new LoginButler(textBox1.Text, textBox2.Text, textBox1.Text + textBox2.Text);

            if(jeeves.IsValid())
            {
                this.Hide();
                loaderForm.Visible = false;
                loaderForm.Enabled = true;
                ((FormAppLoader)loaderForm).Show(this);
            }
            else if (counter > 3)
            {
                Application.Exit();
                this.Dispose();
                loaderForm.Dispose();
            }
            else
            {
                counter += 1;

                textBox1.BackColor = Color.Red;
                textBox2.BackColor = Color.Red;
                textBox1.ForeColor = Color.White;
                textBox2.ForeColor = Color.White;
            }
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
