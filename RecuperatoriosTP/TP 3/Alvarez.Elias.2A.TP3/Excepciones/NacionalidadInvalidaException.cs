using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class NacionalidadInvalidaException : Exception
    {
        public NacionalidadInvalidaException():base("La Nacionalidad no se condice con el Numero de DNI")
        {

        }

        public NacionalidadInvalidaException(string mensaje):base(mensaje)
        {

        }
    }
}
