using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    public class Dulce : Producto
    {
        /// <summary>
        /// Constructor de la clase Dulce
        /// </summary>
        /// <param name="marca">Marca del dulce</param>
        /// <param name="patente">Codigo de barras del Dulce</param>
        /// <param name="color">Color del envase</param>
        public Dulce(EMarca marca, string patente, ConsoleColor color):base(patente, marca, color)
        {
        }

        /// <summary>
        /// Los dulces tienen 80 calorías
        /// </summary>
        protected override short CantidadCalorias  
        {
            get
            {
                return 80;
            }
        }

        /// <summary>
        /// Publica todos los datos del producto Dulce
        /// </summary>
        /// <returns>Cadena con la informacion completa</returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("DULCE");
            sb.AppendLine((string)this);
            sb.AppendLine("CALORIAS : " + this.CantidadCalorias.ToString());
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
