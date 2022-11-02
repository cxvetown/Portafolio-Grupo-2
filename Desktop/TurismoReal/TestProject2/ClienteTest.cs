using Controlador;
using Modelo;
using System.Data;

namespace Pruebas
{
    public class ClienteTest
    {
        private int id = 4;
        [Fact]
        //Agregar cliente
        public void TestAgregarCliente()
        {
            //Arrange
            int resEsperado = 1;
            int resObtenido;
            Cliente cliente = new()
            {
                Rut = "19837402-7",
                Nombres = "Emilia Antonia",
                Apellidos = "Fernandez Acuña",
                Email = "emfernandez@gmail.com",
                Contraseña = "emilia1234",
                Telefono = 982146592
            };

            //Act
            resObtenido = Controlador.CCliente.CrearUsuarioCliente(cliente);

            Assert.Equal(resEsperado, resObtenido);
        }

        [Fact]
        //Actualizar cliente
        public void TestActualizarCliente()
        {
            //Arrange
            int resEsperado = 1;
            int resObtenido;
            Cliente cliente = new()
            { 
                IdUsuario = 4,
                Nombres = "Emilia Sofia",
                Apellidos = "Fernandez Acuña",
                Email = "emfernandez@gmail.com",
                Contraseña = "emilia1234",
                Telefono = 982146592
            };

            //Act
            resObtenido = Controlador.CCliente.ActualizarCliente(cliente);

            Assert.Equal(resEsperado, resObtenido);
        }

        [Fact]
        //Listar cliente
        public void TestListarCliente()
        {
            //Arrange
            DataTable cliente;

            //Act
            cliente = CCliente.ListarCliente();

            //Assert
            Assert.NotNull(cliente.Rows[0]);
        }

        [Fact]
        //Eliminar cliente
        public void TestEliminarCliente()
        {
            //Arrange
            int resEsperado = 1;
            int resObtenido;

            //Act   ;se usa el ID a eliminar
            resObtenido = Controlador.CCliente.EliminarCliente(4);

            //Assert
            Assert.Equal(resEsperado, resObtenido);
        }
    }
}