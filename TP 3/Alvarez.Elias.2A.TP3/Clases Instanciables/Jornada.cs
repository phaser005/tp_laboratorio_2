using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using EntidadesAbstractas;
using Clases_Instanciables;
using Archivos;

namespace Clases_Instanciables
{
    public class Jornada
    {
        #region CAMPOS
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;
        #endregion

        #region PROPIEDADES
        public List<Alumno> Alumnos
        {
            get
            {
                return alumnos;
            }
            set
            {
                alumnos = value;
            }
        }

        public Universidad.EClases Clase
        {
            get
            {
                return clase;
            }
            set
            {
                clase = value;
            }
        }

        public Profesor Instructor
        {
            get
            {
                return instructor;
            }
            set
            {
                instructor = value;
            }
        }
        #endregion

        #region METODOS
        private Jornada()
        {
            alumnos = new List<Alumno>();
        }

        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
            this.instructor = instructor;
            this.clase = clase;
        }

        /// <summary>
        /// Guarda la informacion de una Jornada en un archivo de texto
        /// </summary>
        /// <param name="jornada"> Jornada a guardar </param>
        /// <returns> true si pudo guardarse, false si ocurrio un error</returns>
        public static bool Guardar(Jornada jornada)
        {
            Texto save = new Texto();
            ((IArchivo<string>)save).Guardar(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\CREATED FILES\\Jornada.txt", jornada.ToString());
            return true;
        }

        /// <summary>
        /// Lee la informacion de una Jornada desde un archivo de texto y la trae para ser mostrada
        /// </summary>
        /// <returns> Informacion de la Jornada como texto </returns>
        public static string Leer()
        {
            Texto read = new Texto();
            string data;
            ((IArchivo<string>)read).Leer(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\CREATED FILES\\Jornada.txt", out data);

            return data;
        }

        /// <summary>
        /// Una Jornada sera igual a un Alumno si el mismo participa de la clase
        /// </summary>
        /// <param name="j"> Jornada  </param>
        /// <param name="a"> Alumno </param>
        /// <returns>true si el alumno participa de la clase, false si no participa de esta</returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            bool result = false;
            if (j.alumnos.Contains(a))
                result = true;

            return result;
        }

        /// <summary>
        /// Una Jornada sera distinta a un Alumno si el mismo no participa de la clase
        /// </summary>
        /// <param name="j"> Jornada </param>
        /// <param name="a"> Alumno </param>
        /// <returns>true si el alumno no participa de la clase, false si participa de esta</returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            bool result = false;
            result = !(j == a);
            return result;
        }

        /// <summary>
        /// Agrega alumnos a la clase de la Jornada
        /// </summary>
        /// <param name="j"> Jornada </param>
        /// <param name="a"> Alumno a agregar </param>
        /// <returns> Jornada </returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
                j.alumnos.Add(a);

            return j;
        }

        /// <summary>
        /// Muestra los datos de la Jornada
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string info = "";
            info += instructor.ToString() + "\n\nALUMNOS: \n";
            foreach (Alumno item in alumnos)
            {
                info += item.ToString() + "\n";
            }
            return info;
        }
        #endregion

    }
}
