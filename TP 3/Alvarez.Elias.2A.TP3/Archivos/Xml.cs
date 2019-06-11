using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Guardar(string archivo, T datos)
        {
            bool result = false;
            try
            {
                XmlSerializer Serializer = new XmlSerializer(typeof(T));
                try
                {
                    using (StreamWriter Writer = new StreamWriter(archivo))
                    {
                        Serializer.Serialize(Writer, datos);
                        result = true;
                    }
                    return result;
                }
                catch (Exception e)
                {
                    throw new ArchivosException(e);
                }
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Leer(string archivo, out T datos)
        {
            throw new NotImplementedException();
        }
    }
}
