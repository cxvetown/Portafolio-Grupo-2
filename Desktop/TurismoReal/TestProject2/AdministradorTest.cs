using Controlador;
using Modelo;
using System.Data;

namespace Pruebas
{
    public class AdministradorTest
    {
        private int id= 3;
        [Fact]
        //Agregar administrador
        public void TestAgregarAdministrador()
        {
            //Arrange
            int resEsperado = 1;
            int resObtenido;
            Administrador administrador = new()
            {
                Rut = "19830180-9",
                Nombres = "Diego Sebastian",
                Apellidos = "Gallardo Fuentes",
                Email = "admin2@gmail.com",
                Telefono = 965163393,
                Contraseña = "contraseña123"
            };

            //Act
            resObtenido = Controlador.CAdmin.CrearUsuarioAdmin(administrador);

            Assert.Equal(resEsperado, resObtenido);
        }

        [Fact]
        //Actualizar administrador
        public void TestActualizarAdministrador()
        {
            //Arrange
            int resEsperado = 1;
            int resObtenido;
            Administrador administrador = new()
            {
                IdUsuario = 3, 
                Nombres = "Camilo Sebastian",
                Apellidos = "Gallardo Fuentes",
                Email = "admin2@gmail.com",
                Telefono = 965163393,
                Contraseña = "uwu123"
            };

            //Act
            resObtenido = Controlador.CAdmin.ActualizarAdmin(administrador);

            Assert.Equal(resEsperado, resObtenido);
        }

        [Fact]
        //Listar administrador
        public void TestListarAdministrador()
        {
            //Arrange
            DataTable administrador;

            //Act
            administrador = CAdmin.ListarAdmin();

            //Assert
            Assert.NotNull(administrador.Rows[0]);
        }

        [Fact]
        //Eliminar administrador
        public void TestEliminarAdministrador()
        {
            //Arrange
            int resEsperado = 1;
            int resObtenido;

            //Act   ;se usa el ID a eliminar
            resObtenido = Controlador.CAdmin.EliminarAdmin(3);

            //Assert
            Assert.Equal(resEsperado, resObtenido);
        }
    }
}
