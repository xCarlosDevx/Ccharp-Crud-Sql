using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Crud_Project
{
    public partial class CRUD : Form
    {
        public CRUD()
        {
            InitializeComponent();
        }
        private void ponerPanel(object panel)
        {
            if (this.pnlContainer.Controls.Count > 0)
                this.pnlContainer.Controls.RemoveAt(0);
            Form pn = panel as Form;
            pn.TopLevel = false;
            pn.Dock = DockStyle.Fill;
            this.pnlContainer.Controls.Add(pn);
            this.pnlContainer.Tag = pn;
            pn.Show();

        }
        private void Form1_Load(object sender, EventArgs e)
        {
          
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ponerPanel(new createPanel());
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            ponerPanel(new updatePanel());
        }

        private void btnRead_Click(object sender, EventArgs e)
        {

            ponerPanel(new ReadPanel());
        }
    }
}
