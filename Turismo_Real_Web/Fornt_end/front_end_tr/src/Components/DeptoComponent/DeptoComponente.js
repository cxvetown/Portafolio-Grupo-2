import React from "react";
import DeptoService from "../../services/DeptoService";
import { CardComponent } from "../Cards/CardComp";
import { Row } from "react-bootstrap";
import "./DeptoComponente.css"
class DeptoComponent extends React.Component {

    constructor(props) {
        super(props)
        this.state = {
            deptos: []
        }
    }

    componentDidMount() {
        DeptoService.getDeptos().then((Response) => {
            this.setState({ deptos: Response.data })
        });
    }

    render() {
        return (
            <>
                <center>
                    <Row className="mx-auto gx-0 cards" style={{ width: "80%" }}>
                        {
                            this.state.deptos.map(
                                deptos =>
                                    <CardComponent
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
                </center>

            </>
        );
    }
}

export default DeptoComponent