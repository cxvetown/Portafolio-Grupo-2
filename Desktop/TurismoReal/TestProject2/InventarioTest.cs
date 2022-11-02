using Controlador;
using Modelo;
using System.Data;

namespace Pruebas
{
    public class InventarioTest
    {

        [Fact]
        //Agregar objeto
        public void TestCrearInventario()
        {
            //Arrange
            int resEsperado = 1;
            int resObtenido;
            Objeto objeto = new()
            {
                IdObjeto = 1,
                NombreObjeto = "Mesa",
                CantidadObjeto = 2,
                ValorUnitarioObjeto = 30990
            };

            //Act   se coloca ID Depto al final
            resObtenido = Controlador.CInventario.CrearInventario(objeto, 1);

            //Assert
            Assert.Equal(resEsperado, resObtenido);
        }

        [Fact]
        //Actualizar objeto
        public void TestActualizarInventario()
        {
            //Arrange
            int resEsperado = 1;
            int resObtenido;
            Objeto objeto = new()
            {
                IdObjeto = 1,
                NombreObjeto = "Silla",
                CantidadObjeto = 2,
                ValorUnitarioObjeto = 20990
            };

            //Act   
            resObtenido = Controlador.CInventario.ActualizarInventario(objeto);

            //Assert
            Assert.Equal(resEsperado, resObtenido);
        }

        [Fact]
        //Listar objetos
        public void TestListarInventario()
        {
            //Arrange
            DataTable inventario;

            //Act   ;se usa id Depto 
            inventario = CInventario.ListarInventario(1);

            //Assert
            Assert.NotNull(inventario.Rows[0]);
        }

        [Fact]
        //Eliminar objeto
        public void TestEliminarInventario()
        {
            //Arrange
            int resEsperado = 1;
            int resObtenido;

            //Act   ;se usa el ID del objeto a eliminar
            resObtenido = Controlador.CInventario.EliminarObjeto(1);

            //Assert
            Assert.Equal(resEsperado, resObtenido);
        }
    }
}