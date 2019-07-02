using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    /// <summary>
    /// La clase Producto no deberá permitir que se instancien elementos de este tipo.
    /// </summary>
    public abstract class Producto
    {
        public enum EMarca
        {
            Serenisima, Campagnola, Arcor, Ilolay, Sancor, Pepsico
        }
        private EMarca marca;
        private string codigoDeBarras;
        private ConsoleColor colorPrimarioEmpaque;

        public Producto(string patente, EMarca marca, ConsoleColor color)
        {
            this.codigoDeBarras = patente;
            this.marca = marca;
            this.colorPrimarioEmpaque = color;
        }

        /// <summary>
        /// ReadOnly: Retornará la cantidad de calorías del producto
        /// </summary>
        protected abstract short CantidadCalorias { get; }

        /// <summary>
        /// Publica todos los datos del Producto.
        /// </summary>
        /// <returns>Informacion del producto en formato string</returns>
        public virtual string Mostrar()
        {
            return (string)this;
        }

        /// <summary>
        /// Recopila la informacion del producto
        /// </summary>
        /// <param name="p">Objeto de tipo producto</param>
        public static explicit operator string(Producto p)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CODIGO DE BARRAS: " + p.codigoDeBarras);
            sb.AppendLine("MARCA          : " + p.marca.ToString());
            sb.AppendLine("COLOR EMPAQUE  : " + p.colorPrimarioEmpaque.ToString());
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        /// <summary>
        /// Dos productos son iguales si comparten el mismo código de barras
        /// </summary>
        /// <param name="v1">Elemento a comparar</param>
        /// <param name="v2">Elemento a comparar</param>
        /// <returns>True si los codigos de barras son iguales, False si no lo son</returns>
        public static bool operator ==(Producto v1, Producto v2)
        {
            return (v1.codigoDeBarras == v2.codigoDeBarras);
        }
        /// <summary>
        /// Dos productos son distintos si su código de barras es distinto
        /// </summary>
        /// <param name="v1">Elemento a comparar</param>
        /// <param name="v2">Elemento a comparar</param>
        /// <returns>True si los codigos de barras son distintos, False si no lo son</returns>
        public static bool operator !=(Producto v1, Producto v2)
        {
            return (!(v1 == v2));
        }
    }
}
