using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Clases_Instanciables;
using EntidadesAbstractas;
using Excepciones;
using Archivos;

namespace Test_Unitarios
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void PruebaAlumnoRepetido()
        {
            Universidad uni = new Universidad();
            Alumno a1 = new Alumno(1, "Pepe", "Perez", "25456856", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            Alumno a2 = new Alumno(2, "Lulu", "Gomez", "25456856", Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion);

            try
            {
                uni += a1;
                uni += a2;
                Assert.Fail("El alumno esta repetido, ya sea por su DNI o por su legajo");
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(AlumnoRepetidoException));
            }

        }

        [TestMethod]
        public void PruebaArchivo()
        {
            try
            {
                Universidad uni = new Universidad();
                Universidad.Guardar(uni);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(ArchivosException));
            }
        }

        [TestMethod]
        public void PruebaDniInvalido()
        {
            try
            {
                Alumno a1 = new Alumno(1, "Pepe", "Perez", "254X6856", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(DniInvalidoException));
            }
        }

        [TestMethod]
        public void PruebaCamposAlumnoNotNull()
        {
            Alumno a1 = new Alumno();
            Assert.IsNotNull(a1.Nacionalidad);
            Assert.IsNotNull(a1.Nombre);
            Assert.IsNotNull(a1.Apellido);
            Assert.IsNotNull(a1.DNI);
        }

        [TestMethod]
        public void PruebaCamposUniversidadNotNull()
        {
            Universidad uni = new Universidad();
            Assert.IsNotNull(uni.Jornada);
            Assert.IsNotNull(uni.Profesores);
            Assert.IsNotNull(uni.Alumnos);
        }
    }
}
