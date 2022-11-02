using Controlador;
using Modelo;
using System.Data;

namespace Pruebas
{
    public class DepartamentoTest
    {        
        [Fact]
        //Agregar departamento
        public void TestAgregarDepto()
        {
            //Arrange
            int resEsperado = 1;
            int resObtenido;
            Comuna comuna = new()
            {
                IdComuna = 1
            };
            Departamento departamento = new()
            {
                IdDepto = 2,
                NombreDpto = "Las golondrinas",
                TarifaDiara = 30000,
                Direccion = "Avenida San Benito",
                NroDpto = 608,
                Capacidad = 4,
                Comuna = comuna,
                Disponibilidad = true
            };

            //Act
            resObtenido = CDepartamento.CrearDepto(departamento);

            //Assert
            Assert.Equal(resEsperado, resObtenido);
        }

        [Fact]
        //Actualizar departamento
        public void TestActualizarDepto()
        {
            //Arrange
            int resEsperado = 1;
            int resObtenido;
            Comuna comuna = new()
            {
                IdComuna = 1
            };
            Departamento departamento = new()
            {
                IdDepto = 2, 
                NombreDpto= "Las perdices",
                TarifaDiara = 25000,
                Direccion = "Avenida San Pablo",
                NroDpto = 607,
                Capacidad = 5,
                Comuna = comuna,
                Disponibilidad = false
            };

            //Act
            resObtenido = CDepartamento.ActualizarDepto(departamento);

            //Assert
            Assert.Equal(resEsperado, resObtenido);
        }

        [Fact]
        //Listar departamento
        public void TestListarDepto()
        {
            //Arrange
            DataTable departamento;

            //Act
            departamento = CDepartamento.ListarDpto();

            //Assert
            Assert.NotNull(departamento.Rows[0]);
        }

        [Fact]
        //Eliminar departamento
        public void TestEliminarDepto()
        {
            //Arrange
            int resEsperado = 1;
            int resObtenido;

            //Act   ;se usa el ID a eliminar
            resObtenido = CDepartamento.EliminarDpto(2);

            //Assert
            Assert.Equal(resEsperado, resObtenido);
        }
    }
}