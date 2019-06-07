using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace Clases_Instanciables
{
    public sealed class Alumno : Universitario
    {
        #region TIPOS ANIDADOS
        public enum EEstadoCuenta
        {
            AlDia, Deudor, Becado
        }
        #endregion

        #region CAMPOS
        //Atributo invocado como "Universidad.EClases" porque no se puede invocar directamente como "EClases"
        private Universidad.EClases clasesQueToma;
        private EEstadoCuenta estadoCuenta;
        #endregion

        #region METODOS
        public Alumno() : base()
        {

        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesQueToma = claseQueToma;
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta)
            : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }

        /// <summary>
        /// Recopila todos los datos del Alumno
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            return base.MostrarDatos() + "\nESTADO DE CUENTA: " + estadoCuenta + "\n" + ParticiparEnClase();
        }

        /// <summary>
        /// Muestra la clase que toma el Alumno
        /// </summary>
        /// <returns> retorna la cadena "TOMA CLASE DE " junto al nombre de la clase que toma </returns>
        protected override string ParticiparEnClase()
        {
            return "TOMA CLASES DE: " + clasesQueToma;
        }

        /// <summary>
        /// Hace publicos los datos del Alumno
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return MostrarDatos();
        }

        /// <summary>
        /// Un Alumno será igual a un EClase si toma esa clase y su estado de cuenta no es Deudor.
        /// Parametro EClase invocado como Universidad.EClases
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            bool result = false;
            if (a.clasesQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor)
                result = true;
            return result;
        }

        /// <summary>
        /// Un Alumno será distinto a un EClase sólo si no toma esa clase.
        /// Parametro EClase invocado como Universidad.EClases
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            bool result = false;
            if (a.clasesQueToma != clase)
                result = true;
            return result;
        }
        #endregion
    }
}
