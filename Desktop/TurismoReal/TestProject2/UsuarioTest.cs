using Controlador;
using Modelo;
using System.Data;

namespace Pruebas
{
    public class UsuarioTest
    {
        //Iniciar sesión
        [Fact]
        public void TestAutentificar()
        {
            //Arrange
            int resEsperado = 1;
            int resObtenido;
            DataTable login;

            //Act
            login = CUsuario.Autentificar("desktop@gmail.com","123");
            resObtenido = login.Rows.Count;

            //Assert
            Assert.Equal(resEsperado, resObtenido);
        }
    }
}
