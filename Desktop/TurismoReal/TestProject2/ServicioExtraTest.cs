using Controlador;
using Modelo;
using System.Data;

namespace Pruebas
{
    public class ServicioExtraTest
    {
        [Fact]
        //Agregar servicio 
        public void TestIngresarServicio()
        {
            //Arrange
            int resEsperado = 1;
            int resObtenido;
            ServicioExtra servicioExtra = new()
            {
                IdServicioExtra = 1,
                NombreServicioExtra = "Desayuno",
                DescripcionServicioExtra = "Servicio de desayuno",
                ValorServicioExtra = 10000
            };

            //Act
            resObtenido = Controlador.CServicioExtra.IngresarServicio(servicioExtra);

            //Assert
            Assert.Equal(resEsperado, resObtenido);
        }

        [Fact]
        //Actualizar servicio
        public void TestActualizarServicio()
        {
            //Arrange
            int resEsperado = 1;
            int resObtenido;
            ServicioExtra servicioExtra = new()
            {
                IdServicioExtra = 1,
                NombreServicioExtra = "Desayuno premium",
                DescripcionServicioExtra = "Servicio de desayuno premium",
                ValorServicioExtra = 15000
            };

            //Act
            resObtenido = Controlador.CServicioExtra.ActualizarServicio(servicioExtra);

            //Assert
            Assert.Equal(resEsperado, resObtenido);
        }

        [Fact]
        //Listar servicio
        public void TestListarDServicio()
        {
            //Arrange
            DataTable servicioExtra;

            //Act
            servicioExtra = CServicioExtra.ListarServicios();

            //Assert
            Assert.NotNull(servicioExtra.Rows[0]);
        }

        [Fact]
        //Eliminar servicio
        public void TestEliminarServicio()
        {
            //Arrange
            int resEsperado = 1;
            int resObtenido;

            //Act   ;se usa el ID a eliminar
            resObtenido = Controlador.CServicioExtra.EliminarServicio(1);

            //Assert
            Assert.Equal(resEsperado, resObtenido);
        }
    }
}
