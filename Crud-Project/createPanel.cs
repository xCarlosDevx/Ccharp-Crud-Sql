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
    public partial class createPanel : Form
    {
        public createPanel()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            conexion con = new conexion();
            con.abrirCon();

            string nombre = txtNombre.Text; 
            string apellido = txtApellido.Text;
            string nacimiento = txtNaci.Text;
            string direccion = txtDire.Text;
            string genero = txtGene.Text;
            string civil = txtCivil.Text;
            string movil = txtMov.Text;
            string telefono = txtTel.Text;
            string correo = txtCorr.Text;

            bool isNotFull = txtNombre.Text.Equals("") | txtApellido.Text.Equals("") | txtNaci.Text.Equals("") | txtDire.Text.Equals("") | txtGene.Text.Equals("") | txtCivil.Text.Equals("") | txtMov.Text.Equals("") | txtTel.Text.Equals("") | txtCorr.Text.Equals("");
            string cad = "insert into Agenda (Nombre,Apellido,Nacimiento,Direccion,Genero,Civil,Movil,Telefono,Email) Values ('"+nombre+"','"+apellido+ "','"+nacimiento+"','" + direccion+"','" + genero+"','" + civil+"','" + movil+"','" + telefono+"','" + correo+"')";
            SqlCommand query = new SqlCommand(cad,con.cone);  
            int res;
            if (isNotFull)
            {
                MessageBox.Show("Debe rellenar todos los datos");
            } else
            { 
                res = query.ExecuteNonQuery();
            if (res == 1)
            {
                MessageBox.Show("Se han insertado datos");
                clear();
            }
            else
            {
                MessageBox.Show("Ha ocurrido un error");
            }
            } 
            con.cerrarCon();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }
        private void clear()
        {
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
    }
}
