using Controlador;
using Modelo;
using System.Data;

namespace Pruebas
{
    public class MantenimientoDptoTest
    {
        private int id = 1;
        [Fact]
        //Agregar mantenimiento departamento
        public void TestAgregarMantenimientoDpto()
        {
            //Arrange
            int resEsperado = 1;
            int resObtenido;
            Departamento departamento = new()
            {
                IdDepto = 1
            };
            Mantencion mantenimientoDpto = new()
            {
                NombreMantenimiento = "Mantención pintura",
                DescripcionMantenimiento = "Mantención pintura",
                FechaInicio = Convert.ToDateTime("10-10-2022"),
                FechaTermino = Convert.ToDateTime("15-10-2022"),
                Estado = "I",
                CostoMantencion = 50000
            };

            //Act
            resObtenido = Controlador.CMantenimientoDpto.CrearMantDepto(mantenimientoDpto,1);

            Assert.Equal(resEsperado, resObtenido);
        }

        [Fact]
        //Actualizar mantenimiento departamento
        public void TestActualizarMantenimientoDpto()
        {
            //Arrange
            int resEsperado = 1;
            int resObtenido;
            Departamento departamento = new()
            {
                IdDepto = 1
            };
            Mantencion mantenimientoDpto = new()
            {
                IdMantencion = 1,
                NombreMantenimiento = "Mantención muebles",
                DescripcionMantenimiento = "Mantención muebles",
                FechaInicio = Convert.ToDateTime("10-10-2022"),
                FechaTermino = Convert.ToDateTime("15-10-2022"),
                Estado = "I",
                CostoMantencion = 50000
            };

            //Act
            resObtenido = Controlador.CMantenimientoDpto.ActualizarMantDepto(mantenimientoDpto);

            Assert.Equal(resEsperado, resObtenido);
        }

        [Fact]
        //Listar mantenimiento departamento
        public void TestListarMantenimientoDpto()
        {
            //Arrange
            DataTable mantenimientoDpto;

            //Act
            mantenimientoDpto = CMantenimientoDpto.ListarMantenimiento(1);

            //Assert
            Assert.NotNull(mantenimientoDpto.Rows[0]);
        }

        [Fact]
        //Eliminar mantenimiento departamento
        public void TestEliminarMantenimientoDpto()
        {
            //Arrange
            int resEsperado = 1;
            int resObtenido;

            //Act   ;se usa el ID a eliminar
            resObtenido = Controlador.CMantenimientoDpto.EliminarMantDpto(1);

            //Assert
            Assert.Equal(resEsperado, resObtenido);
        }
    }
}
