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
        /// <summary>
        /// Enumerado de marcas disponibles de productos
        /// </summary>
        public enum EMarca
        {
            Serenisima, Campagnola, Arcor, Ilolay, Sancor, Pepsico
        }
        private EMarca marca;
        private string codigoDeBarras;
        private ConsoleColor colorPrimarioEmpaque;

        /// <summary>
        /// ReadOnly: Retornará la cantidad de ruedas del vehículo
        /// </summary>
        protected abstract short CantidadCalorias { get;}

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="patente">Codigo de barras del producto</param>
        /// <param name="marca">Marca del producto</param>
        /// <param name="color">Color del envase</param>
        public Producto(string patente, EMarca marca, ConsoleColor color)
        {
            codigoDeBarras = patente;
            this.marca = marca;
            colorPrimarioEmpaque = color;
        }


        /// <summary>
        /// Publica todos los datos del Producto.
        /// </summary>
        /// <returns>Informacion del objeto Casteado a String</returns>
        public virtual string Mostrar()
        {
            return (string)this;
        }

        /// <summary>
        /// Recopila la informacion detallada del producto
        /// </summary>
        /// <param name="p">Objeto a ser analizado</param>
        public static explicit operator string(Producto p)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CODIGO DE BARRAS: "+p.codigoDeBarras);
            sb.AppendLine("MARCA          : " + p.marca.ToString());
            sb.AppendLine("COLOR EMPAQUE  : " + p.colorPrimarioEmpaque.ToString());
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        /// <summary>
        /// Dos productos son iguales si comparten el mismo código de barras
        /// </summary>
        /// <param name="v1">Objeto Producto</param>
        /// <param name="v2">Objeto Producto</param>
        /// <returns></returns>
        public static bool operator ==(Producto v1, Producto v2)
        {
            return (string.Equals(v1.codigoDeBarras, v2.codigoDeBarras));
        }

        /// <summary>
        /// Dos productos son distintos si su código de barras es distinto
        /// </summary>
        /// <param name="v1">Objeto Producto</param>
        /// <param name="v2">Objeto Producto</param>
        /// <returns></returns>
        public static bool operator !=(Producto v1, Producto v2)
        {
            return (!(v1.codigoDeBarras == v2.codigoDeBarras));
        }
    }
}
