using Controlador;
using Modelo;
using System.Data;

namespace Pruebas
{
    public class TourTest
    {
        private int id = 1;
        [Fact]
        //Agregar tour
        public void TestAgregarTour()
        {
            //Arrange
            int resEsperado = 1;
            int resObtenido;
            Region region = new()
            {
                IdRegion = 13
            };
            Tour tour = new()
            {
                NombreTour = "Volcán Villarrica",
                DescripcionTour = "Tour al volcán Villarrica",
                ValorTour = 15000,
                Region = region
            };

            //Act
            resObtenido = Controlador.CTour.IngresarTour(tour);

            Assert.Equal(resEsperado, resObtenido);
        }

        [Fact]
        //Actualizar tour
        public void TestActualizarTour()
        {
            //Arrange
            int resEsperado = 1;
            int resObtenido;
            Region region = new()
            {
                IdRegion = 13
            };
            Tour tour = new()
            {
                IdTour = 1,
                NombreTour = "Loncoche",
                DescripcionTour = "Tour a Loncoche",
                ValorTour = 20000,
                Region = region
            };

            //Act
            resObtenido = Controlador.CTour.ActualizarTour(tour);

            Assert.Equal(resEsperado, resObtenido);
        }

        [Fact]
        //Listar tour
        public void TestListarTour()
        {
            //Arrange
            DataTable tour;

            //Act
            tour = CTour.ListarTours();

            //Assert
            Assert.NotNull(tour.Rows[0]);
        }

        [Fact]
        //Eliminar tour
        public void TestEliminarTour()
        {
            //Arrange
            int resEsperado = 1;
            int resObtenido;

            //Act   ;se usa el ID a eliminar
            resObtenido = Controlador.CTour.EliminarTour(1);

            //Assert
            Assert.Equal(resEsperado, resObtenido);
        }
    }
}
