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
    public class Texto : IArchivo<string>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Guardar(string archivo, string datos)
        {
            try
            {
                try
                {
                    using (StreamWriter writer = new StreamWriter(archivo))
                    {
                        writer.WriteLine(datos);
                    }
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Leer(string archivo, out string datos)
        {
            bool result = false;
            datos = "";
            try
            {
                try
                {
                    using (StreamReader reader = new StreamReader(archivo, Encoding.UTF8))
                    {
                        datos += reader.ReadToEnd();
                        result = true;
                    }
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

            return result;
        }
    }
}
