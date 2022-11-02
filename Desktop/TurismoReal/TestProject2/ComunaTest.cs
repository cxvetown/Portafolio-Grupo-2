using Controlador;
using Modelo;
using System.Data;

namespace Pruebas
{
    public class ComunaTest
    {
        [Fact]
        //Listar comuna
        public void TestListarComuna()
        {
            //Arrange
            List<Comuna> comuna;

            //Act
            comuna = CComuna.ListarComuna();

            //Assert
            Assert.NotNull(comuna);
        }
    }
}
