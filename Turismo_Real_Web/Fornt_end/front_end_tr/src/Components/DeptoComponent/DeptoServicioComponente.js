import React from "react";
import servDpto from "../../services/ServDeptoService";
import { CardServicio } from "../Cards/CardServicios";
import { Row } from "react-bootstrap";
import "../DeptoComponent/DeptoComponente.css"

//creamos la clase de depto servicio
class DeptoServiceComp extends React.Component {

    //creamos el constructor con la lista vacia de servicios
    constructor(props) {
        super(props)
        this.state = {
            ServicioDepto: []
        }
    }
    
    //cargamos los datos haciendo la llamada al service
    componentDidMount() {
        let id_foto = localStorage.getItem("idDeptoFotos")
        servDpto.getServicios(id_foto).then((Response) => {
            this.setState({ ServicioDepto: Response.data })
        });
    }

    render() {
        return (
            <>
                <div>
                    <Row className="mx-auto gx-0 cards_svc" style={{ width: "100%"}}>
                        {
                            this.state.ServicioDepto.map(
                                ServicioDepto =>
                                    <CardServicio
                                        key={ServicioDepto.id_servicio}
                                        nombre_servicio={ServicioDepto.nombre_serv}
                                        descripcion={ServicioDepto.desc_serv}
                                    />
                            )
                        }
                    </Row>
                </div>

            </>
        );
    }
}

export default DeptoServiceComp