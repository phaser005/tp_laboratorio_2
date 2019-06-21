using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Entidades
{
    public static class PaqueteDAO
    {
        private static SqlCommand comando;
        private static SqlConnection conexion;

        /// <summary>
        /// Establece la conexion con la base de datos
        /// </summary>
        static PaqueteDAO()
        {
            conexion = new SqlConnection(Properties.Settings.Default.bdConnection);
        }

        /// <summary>
        /// Guarda los datos de un paquete en la base de datos [correo-sp-2017].[dbo].[Paquetes]
        /// </summary>
        /// <param name="p"> Paquete a guardar </param>
        /// <returns></returns>
        public static bool Insertar(Paquete p)
        {
            bool result = false;
            string studentName = "Elias Alvarez";

            comando = new SqlCommand();
            comando.Connection = conexion;
            
            comando.CommandType = CommandType.Text;
            comando.CommandText = "INSERT INTO [correo-sp-2017].[dbo].[Paquetes] (direccionEntrega, trackingID, alumno) VALUES('" + p.DireccionEntrega + " ',' " + p.TrackingID + " ','" + studentName + "')";

            try
            {
                conexion.Open();
                int filasAfectadas = comando.ExecuteNonQuery();

                if (filasAfectadas > 0)
                {
                    result = true;
                }
                conexion.Close();
            }
            catch (Exception e)
            {

                throw  e;
            }
            return result;
        }
    }
}
