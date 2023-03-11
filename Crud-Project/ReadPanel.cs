using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Crud_Project
{
    public partial class ReadPanel : Form
    {
        public ReadPanel()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            conexion con = new conexion();
            con.abrirCon();
            bool isNotFull = txtId.Text.Equals("");
            if (isNotFull)
            {
                MessageBox.Show("Debe poner un ID");
            }
            else
            {
                int id;
                try
                {
                    id = Int16.Parse(txtId.Text);
                }
                catch
                {
                    id = 0;
                    txtId.Text = "0";
                }
                string cad = "select Nombre,Apellido,Nacimiento,Direccion,Genero,Civil,Movil,Telefono,Email from Agenda where id=" + id + "";
                SqlCommand query = new SqlCommand(cad, con.cone);
                SqlDataReader res = query.ExecuteReader();
                if (res.Read())
                {
                    txtBody.AppendText("Nombre: " + res["Nombre"].ToString() + " | ");
                    txtBody.AppendText("Apellido: " + res["Apellido"].ToString() + " | ");
                    txtBody.AppendText("Fecha de nacimiento: " + res["Nacimiento"].ToString() + " | ");
                    txtBody.AppendText(Environment.NewLine);
                    txtBody.AppendText("Direccion: " + res["Direccion"].ToString() + " | ");
                    txtBody.AppendText("Genero: " + res["Genero"].ToString() + " | ");
                    txtBody.AppendText("Civil: " + res["Civil"].ToString() + " | ");
                    txtBody.AppendText(Environment.NewLine);
                    txtBody.AppendText("Movil: " + res["Movil"].ToString() + " | ");
                    txtBody.AppendText("Telefono: " + res["Telefono"].ToString() + " | ");
                    txtBody.AppendText("Email: " + res["Email"].ToString());
                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error o el registro no existe");
                }
            }
            con.cerrarCon();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtBody.Text = "";
            txtId.Text = "";
        }
    }
}
