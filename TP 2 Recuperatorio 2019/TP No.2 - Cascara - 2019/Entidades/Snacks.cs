using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    public class Snacks : Producto
    {
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
        /// Publica todos los datos del Producto Snack.
        /// </summary>
        /// <returns>Informacion del producto en formato string</returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SNACKS");
            sb.AppendLine((string)this);
            sb.AppendLine("CALORIAS : " + this.CantidadCalorias);
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
