import { useContext } from "react";
import { CarouselInicio } from "../Components/Carousel/carousel";
import DeptoComponent from '../Components/DeptoComponent/DeptoComponente';
import clienteContext from "../Contexts/ClienteContext";

export const Inicio = () => {
    const {usuario, setUsuario} = useContext(clienteContext);
    return (
        <>
        
            <div className="text text-center">
                <CarouselInicio></CarouselInicio>
                <br />
                <h1>Departamentos disponibles</h1>
            </div>
            <DeptoComponent></DeptoComponent>
            <br />

        </>
    );
}