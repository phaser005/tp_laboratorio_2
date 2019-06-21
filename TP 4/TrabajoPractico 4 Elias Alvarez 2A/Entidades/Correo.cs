using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Correo:IMostrar<List<Paquete>>
    {
        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;

        public List<Paquete> Paquetes
        {
            get
            {
                return paquetes;
            }
            set
            {
                paquetes = value;
            }
        }

        public Correo()
        {
            mockPaquetes = new List<Thread>();
            paquetes = new List<Paquete>();
        }

        /// <summary>
        /// Cierra todos los hilos activos
        /// </summary>
        public void FinEntregas()
        {
            foreach (Thread item in this.mockPaquetes)
            {
                item.Abort();
            }
        }

        /// <summary>
        /// Muestra la informacion de los paquetes del correo con su estado actual
        /// </summary>
        /// <param name="elementos"> Correo </param>
        /// <returns></returns>
        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            string result = "";
            foreach (Paquete item in ((Correo)elementos).paquetes)
            {
                result += string.Format("{0} para {1} ({2})", item.TrackingID, item.DireccionEntrega, item.Estado.ToString());
                result += "\n";
            }
            return result;
        }

        /// <summary>
        /// Agrega un paquete al correo siempre que este no posea un trackingID repetido
        /// </summary>
        /// <param name="c"> Correo </param>
        /// <param name="p"> Paquete a agregar </param>
        /// <returns> Correo </returns>
        public static Correo operator +(Correo c, Paquete p)
        {
            bool isFirst = true;
            bool duplicated = false;
            foreach (Paquete item in c.paquetes)
            {
                isFirst = false;
                if (item == p)
                {
                    duplicated = true;
                    throw new TrackingIdRepetidoException("El tracking ID: "+p.TrackingID + " ya figura en la lista de envios.");
                }

            }
            if (isFirst == true || duplicated == false)
            {
                c.paquetes.Add(p);
                Thread nuevoHilo = new Thread(p.MockCicloDeVida);
                c.mockPaquetes.Add(nuevoHilo);
                nuevoHilo.Start();
            }
            return c;
        }
    }
}
