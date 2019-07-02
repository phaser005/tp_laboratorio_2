using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace Unitary_Test_Project
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Verifica que la lista de paquetes de la clase Correo este instanciada
        /// </summary>
        [TestMethod]
        public void VerifyStancedCorreoPack()
        {
            Correo correoTest = new Correo();

            Assert.IsNotNull(correoTest.Paquetes);
        }

        /// <summary>
        /// Verifica que no se puedan cargar dos paquetes con el mismo TrackingID
        /// </summary>
        [TestMethod]
        public void VerifyRepeatedTrackingID()
        {
            Correo correoTest = new Correo();
            Paquete p1 = new Paquete("TestDirection123", "0000-000-000");
            Paquete p2 = new Paquete("TestDirection123", "0000-000-000");

            correoTest += p1;
            try
            {
                correoTest += p2;
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(TrackingIdRepetidoException));
            }
            

            Assert.IsNotNull(correoTest.Paquetes);
        }
    }
}
