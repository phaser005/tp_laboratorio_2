using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        private string mensajeBase;

        public DniInvalidoException():base()
        {

        }

        public DniInvalidoException(Exception e):base("La nacionalidad no se condice con el numero de DNI", e)
        {

        }

        public DniInvalidoException(string mensaje):base(mensaje)
        {
            this.mensajeBase = mensaje;
        }

        public DniInvalidoException(string mensaje, Exception e):base(mensaje, e)
        {
            this.mensajeBase = mensaje;
        }
    }
}
