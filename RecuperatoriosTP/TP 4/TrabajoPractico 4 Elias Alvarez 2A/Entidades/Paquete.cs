using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Paquete:IMostrar<Paquete>
    {
        public enum EEstado
        {
            Ingresado, EnViaje, Entregado
        }

        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;

        public event DelegadoEstado informaEstado;

        public delegate void DelegadoEstado(object sender, EventArgs e);

        public string DireccionEntrega
        {
            get
            {
                return direccionEntrega;
            }
            set
            {
                direccionEntrega = value;
            }
        }

        public EEstado Estado
        {
            get
            {
                return estado;
            }
            set
            {
                estado = value;
            }
        }

        public string TrackingID
        {
            get
            {
                return trackingID;
            }
            set
            {
                trackingID = value;
            }
        }

        public Paquete(string direccionEntrega, string trackingID)
        {
            this.direccionEntrega = direccionEntrega;
            this.trackingID = trackingID;
        }

        /// <summary>
        /// Cambia e informa el estado de los paquetes ingresados al correo
        /// </summary>
        public void MockCicloDeVida()
        {
            System.Threading.Thread.Sleep(4000);
            estado = EEstado.EnViaje;
            informaEstado(this, EventArgs.Empty);

            System.Threading.Thread.Sleep(4000);
            estado = EEstado.Entregado;
            informaEstado(this, EventArgs.Empty);

            try
            {
                PaqueteDAO.Insertar(this);
            }
            catch (Exception e)
            {
                informaEstado(e, EventArgs.Empty);
            }
            
        }

        /// <summary>
        /// Muestra los datos del paquete con un formato especifico
        /// </summary>
        /// <param name="elemento"> Elemento a ser mostrado </param>
        /// <returns></returns>
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            return string.Format("{0} para {1}", ((Paquete)elemento).trackingID, ((Paquete)elemento).direccionEntrega);
        }

        /// <summary>
        /// Dos paquetes serán iguales siempre y cuando su Tracking ID sea el mismo.
        /// </summary>
        /// <param name="p1"> Paquete </param>
        /// <param name="p2"> Paquete </param>
        /// <returns></returns>
        public static bool operator ==(Paquete p1, Paquete p2)
        {
            bool result = false;
            if (p1.trackingID == p2.trackingID)
                result = true;

            return result;
        }

        /// <summary>
        /// Dos paquetes serán distintos siempre y cuando su Tracking ID no sea el mismo.
        /// </summary>
        /// <param name="p1"> Paquete </param>
        /// <param name="p2"> Paquete </param>
        /// <returns></returns>
        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return (!(p1 == p2));
        }

        /// <summary>
        /// Devuelve la información del paquete.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return MostrarDatos(this);
        }
    }
}
