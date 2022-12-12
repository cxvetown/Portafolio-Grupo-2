import React from "react";
import serviciosServices from "../../services/ServExtra";
import "./DeptoComponente.css"
import axios from "axios";
import Swal from "sweetalert2";
import withReactContent from "sweetalert2-react-content";

//creamos una funcion que hara llamadas al backend
const HandleInsertar = async (id_sv_extra, valor_serv) => {
    //creamos la variable para llamar a las alertas
    const MySwal = withReactContent(Swal);

    //obtenemos los datos del localstorage
    let reserva = localStorage.getItem("idReserva")
    let idCliente = localStorage.getItem("id_cliente")
    console.log(reserva)
    //llamamos al backend para traer el departamento e insertamos el servicio extra
    const resp = await axios.get(`http://localhost:8080/api/v1/traerDpto/${reserva}`)
    let id_depto1 = resp.data
    console.log(id_depto1)
    const resp1 = await axios.post("http://localhost:8080/api/v1/servExtra", {
        id_reserva: reserva, id_svc_ex: id_sv_extra, id_dpto: id_depto1, id_cliente: idCliente
    })
    //actualizamos el pago sumando el valor total con el valor del servicio extra
    const respActualizarPago = await axios.post(`http://localhost:8080/api/v1/actualizarValor/${reserva}`, {
        valor_serv_ex: valor_serv
    })
    //enviamos un mensaje de aceptacion
    MySwal.fire({
        title: "Se ha agregado el servicio extra",
        icon: "success",
        allowOutsideClick: false
    }).then((respuesta) => {
        if (respuesta.isConfirmed) {
            const idReserva1 = localStorage.getItem('idReserva')
            window.location.replace(`/ListaServExtra/${idReserva1}`);
            window.history.forward();
        }
    })
    console.log(id_sv_extra)
}

const hanleFinalizar  = () => {
    const MySwal = withReactContent(Swal);
    MySwal.fire({
        title: "Reserva finalizada",
        icon: "success",
        allowOutsideClick: false
    }).then((respuesta) => {
        if (respuesta.isConfirmed) {
            window.location.replace('/Inicio');
        }
    })
}

class ServExtraComponente extends React.Component {


    constructor(props) {
        super(props)
        this.state = {
            servicios: []
        }
    }
    //llamar al localStorage
    componentDidMount() {
        let id_reserva1 = localStorage.getItem("idReserva")
        serviciosServices.getServExtra(id_reserva1).then((Response) => {
            this.setState({ servicios: Response.data })
        });
    }

    render() {
        return (
            <>
                <div class="container" style={{ color: "#1687A7" }}>
                    <h1 className="text-center">Listado de servicios extras</h1>
                    <table class="table table-fixed">
                        <thead class="table-dark">
                            <tr>
                                <td>Nombre del Servicio</td>
                                <td>Descripcion</td>
                                <td>Valor del servicio</td>
                                <td></td>
                            </tr>
                        </thead>
                        <tbody style={{ color: "#1687A7" }}>
                            {
                                this.state.servicios.map(
                                    servicios =>
                                        <tr key={servicios.id_svc_ex}>
                                            <td>{servicios.nombre_serv_ex}</td>
                                            <td>{servicios.desc_serv_ex}</td>
                                            <td>{servicios.valor_serv_ex}</td>
                                            {
                                                servicios.seleccionado === '' ?
                                                    <h1>a</h1> :
                                                    <td><button onClick={() => HandleInsertar(servicios.id_svc_ex, servicios.valor_serv_ex)} className="btn btn-success" style={{ backgroundColor: "#1687A7" }}>Agregar</button></td>

                                            }
                                        </tr>
                                )
                            }
                        </tbody>
                    </table>
                    <div className="text text-center">
                        {
                            localStorage.getItem('ocultarReserva') == 1 ?
                                <h1></h1> :
                                <button className="btn btn-primary" style={{ backgroundColor: "#1687A7" }} onClick={hanleFinalizar}>Continuar</button>
                        }
                        
                    </div>

                </div>
            </>
        );
    }
}

export default ServExtraComponente