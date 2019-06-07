using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        #region CAMPOS
        private int legajo;
        #endregion

        #region METODOS
        public Universitario() : base()
        {

        }

        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }

        /// <summary>
        /// Dos Universitario serán iguales si y sólo si son del mismo Tipo y su Legajo o DNI son iguales.
        /// </summary>
        /// <param name="pg1"> Universitario a comparar </param>
        /// <param name="pg2"> Universitario a comparar </param>
        /// <returns>True si son iguales, false si no lo son</returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            bool result = false;
            if ((pg1.legajo == pg2.legajo || pg1.DNI == pg2.DNI) && pg1.Equals(pg2))
                result = true;

            return result;
        }

        /// <summary>
        /// Dos Universitario serán distintos si sus DNI son distintos o sus legajos son distintos.
        /// </summary>
        /// <param name="pg1"> Universitario a comparar </param>
        /// <param name="pg2"> Universitario a comparar </param>
        /// <returns>True si son distintos, false si no lo son</returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            bool result = false;
            result = !(pg1 == pg2);
            return result;
        }

        /// <summary>
        /// Verifica si el objeto es del tipo Universitario
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>true si es del tipo Universitario, false si no lo es</returns>
        public override bool Equals(object obj)
        {
            bool result = false;
            if (obj is Universitario)
            {
                if (obj.GetType() == this.GetType())
                {
                    result = true;
                }
            }

            return result;
        }

        /// <summary>
        /// Muestra los datos del Universitario
        /// </summary>
        /// <returns> Informacion del Universitario </returns>
        protected virtual string MostrarDatos()
        {
            return base.ToString() + "\nLEGAJO NÙMERO: " + legajo + "\n";
        }

        protected abstract string ParticiparEnClase();
        #endregion
    }
}
