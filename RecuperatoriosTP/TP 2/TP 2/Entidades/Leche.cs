using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades_2018
{
    public class Leche : Producto
    {
        /// <summary>
        /// Enumerado de tipos de leche disponibles
        /// </summary>
        public enum ETipo
        {
            Entera, Descremada
        }
        private ETipo tipo;

        /// <summary>
        /// Por defecto, TIPO será ENTERA
        /// </summary>
        /// <param name="marca">Marca de la leche</param>
        /// <param name="patente">Codigo de barras de la leche</param>
        /// <param name="color">Color del envase</param>
        public Leche(EMarca marca, string patente, ConsoleColor color)
            : base(patente, marca, color)
        {
            tipo = ETipo.Entera;
        }

        /// <summary>
        /// Constructor de 4 parametros. Por defecto, TIPO sera ENTERA.
        /// </summary>
        /// <param name="marca">Marca de la leche</param>
        /// <param name="patente">Codigo de barras de la leche</param>
        /// <param name="color">Color del envase</param>
        /// <param name="tipo">Tipo de leche</param>
        public Leche(EMarca marca, string patente, ConsoleColor color, ETipo tipo):this(marca, patente, color)
        {
            this.tipo = tipo;
        }

        /// <summary>
        /// Las leches tienen 20 calorías
        /// </summary>
        protected override short CantidadCalorias
        {
            get
            {
                return 20;
            }
        }
        /// <summary>
        /// Publica todos los datos del producto leche.
        /// </summary>
        /// <returns>Cadena con la informacion completa</returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("LECHE");
            sb.AppendLine((string)this);
            sb.Append("CALORIAS : "+ this.CantidadCalorias.ToString());
            sb.AppendLine("TIPO : " + this.tipo);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
