using Controlador;
using Modelo;
using System.Data;

namespace Pruebas
{
    public class RegionTest { 

        [Fact]
        //Listar region
        public void TestListarRegion()
        {
            //Arrange
            List<Region> region;

            //Act
            region = CRegion.ListarRegion();

            //Assert
            Assert.NotNull(region);
        }
    }
}
