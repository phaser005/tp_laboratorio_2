using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MainCorreo
{
    public partial class frmPpal : Form
    {
        Correo correo;

        public frmPpal()
        {
            InitializeComponent();
            correo = new Correo();
        }
        
        /// <summary>
        /// Actualiza la informacion de los listbox para reflejar el estado actual de los paquetes
        /// </summary>
        private void ActualizarEstados()
        {
            lstEstadoIngresado.Items.Clear();
            lstEstadoEnViaje.Items.Clear();
            lstEstadoEntregado.Items.Clear();

            foreach (Paquete item in correo.Paquetes)
            {
                if (item.Estado == Paquete.EEstado.Ingresado)
                {
                    lstEstadoIngresado.Items.Add(item);
                }
                if (item.Estado == Paquete.EEstado.EnViaje)
                {
                    lstEstadoEnViaje.Items.Add(item);
                }
                if (item.Estado == Paquete.EEstado.Entregado)
                {
                    lstEstadoEntregado.Items.Add(item);
                }
            }

        }

        /// <summary>
        /// Agrega un paquete con la informacion ingresada por el usuario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Paquete p1 = new Paquete(txtDireccion.Text, mtxtTrackingID.Text);
            p1.informaEstado += new Paquete.DelegadoEstado(paq_InformaEstado);
            try
            {
                correo += p1;
                ActualizarEstados();
            }
            catch (TrackingIdRepetidoException f)
            {
                MessageBox.Show(f.Message, "Paquete Repetido",MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            catch (Exception g)
            {
                MessageBox.Show(g.Message);
            }

        }

        /// <summary>
        /// Muestra los paquetes y su estado actual y escribe en un archivo de texto en el escritorio esa informacion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Mostrar_Todos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }

        private void frmPpal_FormClosing(object sender, FormClosingEventArgs e)
        {
            correo.FinEntregas();
        }

        /// <summary>
        /// Muestra uno o todos los paquetes y su estado actual
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="elemento"></param>
        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            if (elemento != null)
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\salida.txt";
                rtbMostrar.Clear();
                if(elemento is Correo)
                    rtbMostrar.AppendText(correo.MostrarDatos((IMostrar<List<Paquete>>)elemento));
                if (elemento is Paquete)
                    rtbMostrar.AppendText(elemento.ToString());

                rtbMostrar.Text.Guardar(path);
            }
        }
    
        private void paq_InformaEstado(object sender, EventArgs e)
        {
            if (sender is Exception)
            {
                MessageBox.Show(((Exception)sender).Message,"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformaEstado);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                ActualizarEstados();
            }
        }

        /// <summary>
        /// Muestra el paquete seleccionado y su estado actual y escribe en un archivo de texto en el escritorio esa informacion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);
        }
    }
}
