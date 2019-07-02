using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace Clases_Instanciables
{
    public class Profesor: Universitario
    {
        #region CAMPOS
        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;
        #endregion

        #region METODOS
        static Profesor()
        {
            random = new Random();
        }

        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            _randomClases();
        }

        private Profesor()
        {

        }

        /// <summary>
        /// Asigna clases a un Profesor
        /// </summary>
        private void _randomClases()
        {

            this.clasesDelDia.Enqueue((Universidad.EClases)random.Next(0, 3));
            System.Threading.Thread.Sleep(200);
            this.clasesDelDia.Enqueue((Universidad.EClases)random.Next(0, 3));
        }

        /// <summary>
        /// Recopila todos los datos de un Profesor
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            return "CLASE DE: " + clasesDelDia.Peek() + " POR " + base.MostrarDatos() + "\n" + ParticiparEnClase();
        }

        /// <summary>
        /// Hace publicos los datos de un Profesor
        /// </summary>
        /// <returns> informacion del Profesor </returns>
        public override string ToString()
        {
            return MostrarDatos();
        }

        /// <summary>
        /// Muestra las clases que da un Profesor
        /// </summary>
        /// <returns> cadena "CLASES DEL DÍA" junto al nombre de la clases que da </returns>
        protected override string ParticiparEnClase()
        {
            return "CLASES DEL DIA:\n" + clasesDelDia.ElementAt(0) + "\n" + clasesDelDia.ElementAt(1);
        }

        /// <summary>
        /// Un Profesor será igual a un EClase si da esa clase.
        /// </summary>
        /// <param name="i"> Profesor </param>
        /// <param name="clases"> Clase </param>
        /// <returns>true si da esa clase, false si no la da</returns>
        public static bool operator ==(Profesor i, Universidad.EClases clases)
        {
            bool result = false;

            foreach (Universidad.EClases item in i.clasesDelDia)
            {
                if (item == clases)
                    result = true;
                break;
            }

            return result;
        }

        /// <summary>
        /// Un Profesor será distinto a un EClase si no da esa clase.
        /// </summary>
        /// <param name="i"> Profesor </param>
        /// <param name="clases"> Clase </param>
        /// <returns>true si no da esa clase, false si la da</returns>
        public static bool operator !=(Profesor i, Universidad.EClases clases)
        {
            bool result = false;
            result = !(i == clases);
            return result;
        }
        #endregion
    }
}
