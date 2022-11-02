import Carousel from "react-bootstrap/Carousel";
import carouselimg_1 from "../../Img/carousel_1.jpg";
import carouselimg_2 from "../../Img/carousel_2.jpg";
import carouselimg_3 from "../../Img/carousel_3.jpg";

export const CarouselInicio = () => {
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