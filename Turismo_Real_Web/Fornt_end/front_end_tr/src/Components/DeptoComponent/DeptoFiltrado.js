import React from "react";
import DeptoService from "../../services/deptoFil";
import { CardComponent } from "../Cards/CardDeptos";
import { Row } from "react-bootstrap";
import "./DeptoComponente.css"
import axios from "axios";
class DeptoFiltro extends React.Component {
    //creamos el constructor y creamos la lista vacia donde se almacenaran los deptos
    constructor(props) {
        super(props)
        this.state = {
            deptofil: []
        }
    }

    //llamamos la funcion que se encarga de llamar al servicio y hacer la llamada al backend
    componentDidMount() {
        let id_com = localStorage.getItem('id_com')
        let fecha_ida1 = localStorage.getItem('fecha_ida')
        let fecha_vuelta1 = localStorage.getItem('fecha_vuelta')
        const resp = axios.post("http://localhost:8080/api/v1/deptoFiltrados",{
            id_comuna: id_com, check_in: fecha_ida1, check_out: fecha_vuelta1
        }).then((resp) => {
            this.setState({ deptofil: resp.data })
            console.log(resp.data)
        });
    }

     //el render se encarga de renderizar el html del componente
     render() {
        return (
            <>
                <div>
                <h3 className="text text-center" style={{ color: "#1687A7" }}>Departamentos disponibles</h3>
                    <Row className="mx-auto gx-0 cards" style={{ width: "80%" }}>     
                        {
                            this.state.deptofil.map(
                                deptofil =>
                                    <CardComponent
                                        key={deptofil[0]}
                                        NumeroDepto={deptofil[4]}
                                        nombreDepto={deptofil[1]}
                                        idDepto={deptofil[0]}
                                        capacidad={deptofil[5]}
                                        tarifa={deptofil[2]}
                                        direccion={deptofil[3]}
                                        foto_path={deptofil[6]}
                                    />
                            )

                        }
                    </Row>
                </div>

            </>
        );
    }
}
export default DeptoFiltro