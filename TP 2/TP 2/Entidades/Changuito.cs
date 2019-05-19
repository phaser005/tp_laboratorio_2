using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    /// <summary>
    /// No podrá tener clases heredadas.
    /// </summary>
    public class Changuito
    {
        private List<Producto> productos;
        private int espacioDisponible;
        /// <summary>
        /// Enumerado de los tipos de  productos
        /// </summary>
        public enum ETipo
        {
            Dulce, Leche, Snacks, Todos
        }

        #region "Constructores"
        /// <summary>
        /// Constructor base de la clase Changuito
        /// </summary>
        private Changuito()
        {
            this.productos = new List<Producto>();
        }
        /// <summary>
        /// Constructor con un parametro de la clase Changuito
        /// </summary>
        /// <param name="espacioDisponible">Espacio disponible para almacenar productos</param>
        public Changuito(int espacioDisponible):this()
        {
            this.espacioDisponible = espacioDisponible;
        }
        #endregion

        #region "Sobrecargas"
        /// <summary>
        /// Muestro el Changuito y TODOS los Productos
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Changuito.Mostrar(this, ETipo.Todos);
        }
        #endregion

        #region "Métodos"

        /// <summary>
        /// Expone los datos del elemento y su lista (incluidas sus herencias)
        /// SOLO del tipo requerido
        /// </summary>
        /// <param name="c">Elemento a exponer</param>
        /// <param name="ETipo">Tipos de ítems de la lista a mostrar</param>
        /// <returns></returns>
        public static string Mostrar(Changuito c, ETipo tipo)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Tenemos {0} lugares ocupados de un total de {1} disponibles", c.productos.Count, c.espacioDisponible);
            sb.AppendLine("");
            foreach (Producto v in c.productos)
            {
                switch (tipo)
                {
                    case ETipo.Snacks:
                        if(v is Snacks)
                            sb.AppendLine(v.Mostrar());
                        break;
                    case ETipo.Dulce:
                        if (v is Dulce)
                            sb.AppendLine(v.Mostrar());
                        break;
                    case ETipo.Leche:
                        if(v is Leche)
                            sb.AppendLine(v.Mostrar());
                        break;
                    default:
                        sb.AppendLine(v.Mostrar());
                        break;
                }
            }

            return sb.ToString();
        }
        #endregion

        #region "Operadores"
        /// <summary>
        /// Agregará un elemento a la lista
        /// </summary>
        /// <param name="c">Objeto donde se agregará el elemento</param>
        /// <param name="p">Objeto a agregar</param>
        /// <returns></returns>
        public static Changuito operator +(Changuito c, Producto p)
        {
            //foreach (Producto v in c.productos)
            //{
            //    if (v == p)
            //        return c;
            //}

            //c.productos.Add(p);
            //return c;
            bool check = true;
            foreach (Producto v in c.productos)
            {
                if (v == p)
                {
                    check = false;
                    return c;
                }
            }
            if(check == true && c.productos.Count < c.espacioDisponible)
            c.productos.Add(p);

            return c;
        }
        /// <summary>
        /// Quitará un elemento de la lista
        /// </summary>
        /// <param name="c">Objeto donde se quitará el elemento</param>
        /// <param name="p">Objeto a quitar</param>
        /// <returns></returns>
        public static Changuito operator -(Changuito c, Producto p)
        {
            foreach (Producto v in c.productos)
            {
                if (v == p)
                {
                    c.productos.Remove(p);
                    break;
                }
            }

            return c;
        }
        #endregion
    }
}
