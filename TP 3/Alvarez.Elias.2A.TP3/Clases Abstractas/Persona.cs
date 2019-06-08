using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        #region TIPOS ANIDADOS
        public enum ENacionalidad
        {
            Argentino, Extranjero
        }
        #endregion

        #region CAMPOS    
        private int dni;
        private string nombre;
        private string apellido;
        private ENacionalidad nacionalidad;
        #endregion

        #region PROPIEDADES
        public string Apellido
        {
            get
            {
                return apellido;
            }
            set
            {
                apellido = ValidarNombreApellido(value);
            }
        }

        public int DNI
        {
            get
            {
                return dni;
            }
            set
            {
                dni = ValidarDni(nacionalidad, value);
            }
        }

        public ENacionalidad Nacionalidad
        {
            get
            {
                return nacionalidad;
            }
            set
            {
                nacionalidad = value;
            }
        }

        public string Nombre
        {
            get
            {
                return nombre;
            }
            set
            {
                nombre = ValidarNombreApellido(value);
            }
        }

        public string StringToDNI
        {
            set
            {
                dni = ValidarDni(nacionalidad, value);
            }
        }
        #endregion

        #region METODOS
        //Si se utiliza el constructor por default de Persona deberán modificarse luego los valores de los campos por medio de las propiedades.
        public Persona():this("","","00000001",ENacionalidad.Argentino)
        {

        }

        //Si se utiliza el constructor que no recibe DNI se debera especificar la nacionalidad como Argentino, que luego podra ser modificable por medio de propiedades.
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad) : this(nombre, apellido,"00000001", nacionalidad)
        {

        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre, apellido, dni.ToString(), nacionalidad)
        {

        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.nacionalidad = nacionalidad;
            StringToDNI = dni;

        }

        /// <summary>
        /// Publica los datos de una persona
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "NOMBRE COMPLETO: " + Apellido + " " + Nombre + "\n" + "NACIONALIDAD: " + Nacionalidad + "\n";
        }

        /// <summary>
        /// Valida el DNI segun la nacionalidad de la persona
        /// </summary>
        /// <param name="nacionalidad"> Nacionalidad que sera verificada </param>
        /// <param name="dato"> Numero DNI </param>
        /// <returns>DNI validado</returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            int result = 0;
            if (nacionalidad == ENacionalidad.Argentino && dato >= 1 && dato <= 89999999)
            {
                result = dato;
            }
            else
            {
                if (nacionalidad == ENacionalidad.Extranjero && dato >= 90000000 && dato <= 99999999)
                {
                    result = dato;
                }
                else
                {
                    throw new NacionalidadInvalidaException();
                }
            }



            return result;
        }

        /// <summary>
        /// Valida el DNI en formato cadena
        /// </summary>
        /// <param name="nacionalidad"> Nacionalidad que sera verificada </param>
        /// <param name="dato"> DNI a validar como entero </param>
        /// <returns> DNI validado y convertido a entero </returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int result = 0;
            int datoInt;
            try
            {
                datoInt = Convert.ToInt32(dato);
                result = ValidarDni(nacionalidad, datoInt);
            }
            catch (NacionalidadInvalidaException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw new DniInvalidoException("El formato de DNI no es correcto", e);
            }
            return result;
        }

        /// <summary>
        /// Valida que el nombre solo contenga caracteres validos para un nombre
        /// </summary>
        /// <param name="dato">cadena de texto a ser analizada</param>
        /// <returns> nombre verificado o cadena vacia </returns>
        private string ValidarNombreApellido(string dato)
        {
            string result = "";
            try
            {
                if (Regex.IsMatch(dato, @"^[a-z A-Z]+$"))
                    result = dato;
            }
            catch (Exception e)
            {

                throw e;
            }


            return result;
        }
        #endregion
    }
}
