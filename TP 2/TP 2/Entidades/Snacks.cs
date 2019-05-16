using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    public class Snacks:Producto
    {
        /// <summary>
        /// Constructor de la clase Snacks
        /// </summary>
        /// <param name="marca">Marca del snack</param>
        /// <param name="patente">Codigo de barras del snack</param>
        /// <param name="color">Color del envase</param>
        public Snacks(EMarca marca, string patente, ConsoleColor color)
            : base(patente, marca, color)
        {
        }

        /// <summary>
        /// Los snacks tienen 104 calorías
        /// </summary>
        protected override short CantidadCalorias
        {
            get
            {
                return 104;
            }
        }

        /// <summary>
        /// Publica todos los datos del producto snack.
        /// </summary>
        /// <returns>Cadena con la informacion completa</returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SNACKS");
            sb.AppendLine((string)this);
            sb.AppendLine("CALORIAS : " + this.CantidadCalorias.ToString());
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
