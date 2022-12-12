import Carousel from "react-bootstrap/Carousel";
import carouselimg_1 from "../../Img/carousel_1.jpg";
import carouselimg_2 from "../../Img/carousel_2.jpg";
import carouselimg_3 from "../../Img/carousel_3.jpg";

//se crea y se exporta el componente de carrusel para utilizarlo en otra ventana
export const CarouselInicio = () => {
    //devolvemos el codigo HTML con el carrusel de Bootstrap
    return (
        <Carousel className="w-100">
            <Carousel.Item>
                <img
                    src={carouselimg_1}
                    className="w-100"
                    alt="Primer Slide"
                />
            </Carousel.Item>
            <Carousel.Item>
                <img
                    src={carouselimg_2}
                    className="w-100"
                    alt="Segundo Slide"
                />
            </Carousel.Item>
            <Carousel.Item>
                <img
                    src={carouselimg_3}
                    className="w-100"
                    alt="Tercer Slide"
                />
            </Carousel.Item>
        </Carousel>
    )
}