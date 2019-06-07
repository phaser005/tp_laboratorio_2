using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using EntidadesAbstractas;
using Archivos;
using Excepciones;

namespace Clases_Instanciables
{
    public class Universidad
    {
        #region TIPOS ANIDADOS
        public enum EClases
        {
            Programacion, Laboratorio, Legislacion, SPD
        }
        #endregion

        #region CAMPOS
        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;
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

        public List<Jornada> Jornada
        {
            get
            {
                return jornada;
            }
            set
            {
                jornada = value;
            }
        }

        public List<Profesor> Profesores
        {
            get
            {
                return profesores;
            }
            set
            {
                profesores = value;
            }
        }

        public Jornada this[int i]
        {
            get
            {
                return jornada.ElementAt(i);
            }
            set
            {
                jornada.Insert(i, value);
            }
        }
        #endregion

        #region METODOS
        public Universidad()
        {
            alumnos = new List<Alumno>();
            jornada = new List<Jornada>();
            profesores = new List<Profesor>();
        }

        /// <summary>
        /// Recopila datos de una Universidad
        /// </summary>
        /// <param name="uni"> Universidad </param>
        /// <returns></returns>
        private string MostrarDatos(Universidad uni)
        {
            string data = "JORNADA: \n";
            foreach (Jornada item in uni.jornada)
            {
                data += item.ToString();
                data += "<---------------------------------------->\n";
            }
            return data;
        }

        /// <summary>
        /// Hace publicos los datos de una Universidad
        /// </summary>
        /// <returns>datos de la Universidad</returns>
        public override string ToString()
        {
            return MostrarDatos(this);
        }

        /// <summary>
        /// Serializa los datos de una Universidad en un XML, incluyendo todos los datos de sus Profesores, Alumnos y Jornadas.
        /// </summary>
        /// <param name="uni"> Universidad </param>
        /// <returns> True si puede guardar el archivo </returns>
        public static bool Guardar(Universidad uni)
        {
            Xml<Universidad> save = new Xml<Universidad>();
            try
            {
                ((IArchivo<Universidad>)save).Guardar(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\CREATED FILES\\Universidad.XML", uni);
            }
            catch (ArchivosException e)
            {

                throw new ArchivosException(e);
            }

            return true;
        }

        /// <summary>
        /// Un Universidad será igual a un Alumno si el mismo está inscripto en él.
        /// </summary>
        /// <param name="g"> Universidad </param>
        /// <param name="a"> Alumno </param>
        /// <returns> true si esta inscripto en la universidad, false si no lo esta</returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            bool result = false;
            if (g.alumnos.Contains(a))
                result = true;
            return result;
        }

        /// <summary>
        /// Un Universidad será distinto a un Alumno si el mismo no esta inscripto en él.
        /// </summary>
        /// <param name="g"> Universidad </param>
        /// <param name="a"> Alumno </param>
        /// <returns> true si no esta inscripto en la universidad, false si lo esta </returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            bool result = false;
            result = !(g == a);
            return result;
        }

        /// <summary>
        /// Un Universidad será igual a un Profesor si el mismo está dando clases en él.
        /// </summary>
        /// <param name="g"> Universidad </param>
        /// <param name="i"> Profesor </param>
        /// <returns> true si el profesor da clases alli, false si no las da </returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            bool result = false;
            if (g.profesores.Contains(i))
                result = true;
            return result;
        }

        /// <summary>
        /// Un Universidad será igual a un Profesor si el mismo no está dando clases en él.
        /// </summary>
        /// <param name="g"> Universidad </param>
        /// <param name="i"> Profesor </param>
        /// <returns> true si el profesor no da clases alli, false si las da  </returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            bool result = false;
            result = !(g == i);
            return result;
        }

        /// <summary>
        /// Retorna el primer Profesor capaz de dar esa clase.
        /// </summary>
        /// <param name="u"> Universidad </param>
        /// <param name="clase"> Clase </param>
        /// <returns> Profesor capaz de dar la clase </returns>
        public static Profesor operator ==(Universidad u, EClases clase)
        {
            bool result = false;
            Profesor aux = null;
            foreach (Jornada item in u.jornada)
            {
                if (item.Clase == clase)
                {
                    aux = item.Instructor;
                    result = true;
                    break;
                }
            }

            if (result == false)
            {
                throw new SinProfesorException();
            }
            else
            {
                return aux;
            }
        }

        /// <summary>
        /// Retorna el primer Profesor que no pueda dar esa clase.
        /// </summary>
        /// <param name="u"> Universidad </param>
        /// <param name="clase"> Clase </param>
        /// <returns> Profesor que no da la clase </returns>
        public static Profesor operator !=(Universidad u, EClases clase)
        {
            Profesor aux = null;
            foreach (Jornada item in u.jornada)
            {
                if (item.Clase != clase)
                {
                    aux = item.Instructor;
                    break;
                }
            }

            return aux;
        }

        /// <summary>
        /// Agrega una clase con su respectiva jornada y alumnos que la cursan
        /// </summary>
        /// <param name="g"> Universidad </param>
        /// <param name="clase"> Clase </param>
        /// <returns> Universidad </returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            Profesor profesorAux = null;
            bool checkProfesor = false;
            foreach (Profesor item in g.profesores)
            {
                if (item == clase)
                {
                    profesorAux = item;
                    checkProfesor = true;
                    break;
                }
            }
            if (checkProfesor == true)
            {
                Jornada nuevaJornada = new Jornada(clase, profesorAux);

                foreach (Alumno item in g.alumnos)
                {
                    if (item == clase)
                        nuevaJornada.Alumnos.Add(item);
                }

                g.jornada.Add(nuevaJornada);
            }
            else
            {
                throw new SinProfesorException();
            }
            return g;
        }

        /// <summary>
        /// Agrega un alumno a la Universidad validando que no este previamente cargado
        /// </summary>
        /// <param name="g"> Universidad </param>
        /// <param name="a"> Alumno </param>
        /// <returns> Universidad </returns>
        public static Universidad operator +(Universidad g, Alumno a)
        {
            if (g.alumnos.Count() == 0)
            {
                g.alumnos.Add(a);
            }
            else
            {
                foreach (Alumno item in g.alumnos)
                {
                    if (item != a)
                    {
                        g.alumnos.Add(a);
                        break;
                    }
                    else
                    {
                        throw new AlumnoRepetidoException();
                    }
                }
            }
            return g;
        }

        /// <summary>
        /// Agrega un profesor a la Universidad validando que no este previamente cargado
        /// </summary>
        /// <param name="g"> Universidad </param>
        /// <param name="i"> Profesor </param>
        /// <returns> Universidad </returns>
        public static Universidad operator +(Universidad g, Profesor i)
        {
            Universidad result = g;
            bool add = false;
            if (g.profesores.Count() == 0)
                g.profesores.Add(i);

            foreach (Profesor item in g.profesores)
            {
                if (item != i)
                {
                    add = true;
                    break;
                }
            }
            if (add == true)
                g.profesores.Add(i);

            return result;
        }
        #endregion
    }
}
