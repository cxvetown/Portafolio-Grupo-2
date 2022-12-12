import React from "react";
import DeptoService from "../../services/DeptoService";
import { CardComponentNP } from "../Cards/cardnoPresionable";
import { Row } from "react-bootstrap";
import "./DeptoComponente.css"

//creamos una clase de react para utilizar ciertas funciones unicas como el componentDidmount
class DeptoComponent extends React.Component {

    //creamos el constructor y creamos la lista vacia donde se almacenaran los deptos
    constructor(props) {
        super(props)
        this.state = {
            deptos: []
        }
    }

    //llamamos la funcion que se encarga de llamar al servicio y hacer la llamada al backend
    componentDidMount() {
        DeptoService.getDeptos().then((Response) => {
            this.setState({ deptos: Response.data })
        });
    }

    //el render se encarga de renderizar el html del componente
    render() {
        return (
            <>
                <div>
                    <Row className="mx-auto gx-0 cards" style={{ width: "80%" }}>     
                        {
                            this.state.deptos.map(
                                deptos =>
                                    <CardComponentNP
                                        key={deptos.idDepto}
                                        NumeroDepto={deptos.nroDepto}
                                        nombreDepto={deptos.nombre_dpto}
                                        idDepto={deptos.idDepto}
                                        capacidad={deptos.capacidad}
                                        tarifa={deptos.tarifaDiaria}
                                        direccion={deptos.direccion}
                                        comuna={deptos.nombre_comuna}
                                        foto_path={deptos.foto_path}
                                    />
                            )

                        }
                    </Row>
                </div>

            </>
        );
    }
}

export default DeptoComponent