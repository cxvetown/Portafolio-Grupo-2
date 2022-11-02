using Controlador;
using Modelo;
using System.Data;

namespace Pruebas
{
    public class ServicioDptoTest
    {
        private int id = 1;
        [Fact]
        //Agregar servicio departamento
        public void TestAgregarServicioDpto()
        {
            //Arrange
            int resEsperado = 1;
            int resObtenido;

            ServicioDpto servicioDpto = new()
            {
                NombreServDpto = "Wifi",
                DescServDpto = "Habitación con wifi"
            };

            //Act
            resObtenido = Controlador.CServicioDpto.IngresarServicioDpto(servicioDpto);

            Assert.Equal(resEsperado, resObtenido);
        }

        [Fact]
        //Actualizar servicio departamento
        public void TestActualizarServicioDpto()
        {
            //Arrange
            int resEsperado = 1;
            int resObtenido;
            ServicioDpto servicioDpto = new()
            {
                IdServDpto = 1,
                NombreServDpto = "TV cable",
                DescServDpto = "Habitación con tv cable"
            };

            //Act
            resObtenido = Controlador.CServicioDpto.ActualizarServicioDpto(servicioDpto);

            Assert.Equal(resEsperado, resObtenido);
        }

        [Fact]
        //Listar servicio departamento
        public void TestListarServicioDpto()
        {
            //Arrange
            DataTable servicioDpto;

            //Act
            servicioDpto = CServicioDpto.ListarServiciosDpto();

            //Assert
            Assert.NotNull(servicioDpto.Rows[0]);
        }

        [Fact]
        //Eliminar servicio departamento
        public void TestEliminarServicioDpto()
        {
            //Arrange
            int resEsperado = 1;
            int resObtenido;

            //Act   ;se usa el ID a eliminar
            resObtenido = Controlador.CServicioDpto.EliminarServicio(1);

            //Assert
            Assert.Equal(resEsperado, resObtenido);
        }
    }
}
