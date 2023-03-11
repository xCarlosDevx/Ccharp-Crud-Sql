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
    public partial class updatePanel : Form
    {
        public updatePanel()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            conexion con = new conexion();
            con.abrirCon();
            int id = Int16.Parse(txtId.Text);
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string nacimiento = txtNaci.Text;
            string direccion = txtDire.Text;
            string genero = txtGene.Text;
            string civil = txtCivil.Text;
            string movil = txtMov.Text;
            string telefono = txtTel.Text;
            string correo = txtCorr.Text;

            bool isNotFull = txtId.Text.Equals("") | txtNombre.Text.Equals("") | txtApellido.Text.Equals("") | txtNaci.Text.Equals("") | txtDire.Text.Equals("") | txtGene.Text.Equals("") | txtCivil.Text.Equals("") | txtMov.Text.Equals("") | txtTel.Text.Equals("") | txtCorr.Text.Equals("");
            string cad = "update Agenda set Nombre='" + nombre + "',Apellido='" + apellido + "',Nacimiento='" + nacimiento + "',Direccion='" + direccion + "',Genero='" + genero + "',Civil='" + civil + "',Movil='" + movil + "',Telefono='" + telefono + "',Email='" + correo + "' where id = "+id+"";
            
            SqlCommand query = new SqlCommand(cad, con.cone);
            int res;
            if (isNotFull)
            {
                MessageBox.Show("Debe rellenar todos los datos");
            }
            else
            {
                res = query.ExecuteNonQuery();
                if (res == 1)
                {
                    MessageBox.Show("Se han modificado los datos con id " + id);
                    clear();
                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error");
                }
            }
            con.cerrarCon();
        }
        private void clear()
        {
            txtId.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtNaci.Text = "";
            txtDire.Text = "";
            txtGene.Text = "";
            txtCivil.Text = "";
            txtMov.Text = "";
            txtTel.Text = "";
            txtCorr.Text = "";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            conexion con = new conexion();
            con.abrirCon();
            int id = Int16.Parse(txtId.Text);

            bool isNotFull = txtId.Text.Equals("") ;
            string cad = "Delete from Agenda where id = " + id + "";

            SqlCommand query = new SqlCommand(cad, con.cone);
            int res;
            if (isNotFull)
            {
                MessageBox.Show("Debe poner un ID");
            }
            else
            {
                res = query.ExecuteNonQuery();
                if (res == 1)
                {
                    MessageBox.Show("Se han eliminado los datos con id " + id);
                    clear();
                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error");
                }
            }
            con.cerrarCon();
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
                    txtNombre.Text = (res["Nombre"].ToString());
                    txtApellido.Text = (res["Apellido"].ToString());
                    txtNaci.Text = (res["Nacimiento"].ToString());
                    txtDire.Text = (res["Direccion"].ToString());
                    txtGene.Text = (res["Genero"].ToString());
                    txtCivil.Text = (res["Civil"].ToString());
                    txtMov.Text = (res["Movil"].ToString());
                    txtTel.Text = (res["Telefono"].ToString());
                    txtCorr.Text = (res["Email"].ToString());

                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error o el registro no existe");
                }
            }
            con.cerrarCon();
        }
    }
}
