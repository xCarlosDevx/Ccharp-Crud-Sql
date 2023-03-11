using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Crud_Project
{
    class conexion
    {
        public SqlConnection cone = new SqlConnection("server = LAPTOP-2GI3ISEG ; database = Informacion; integrated security = true; ");

        public void abrirCon()
        {
            try
            {
                cone.Open();
                Console.WriteLine("Conexion Establecida");

            }
            catch(SqlException ex)
            {
                Console.WriteLine("Error en conexion " + ex);
            }
        }
        public void cerrarCon()
        {
            cone.Close();
        }
    }
}
