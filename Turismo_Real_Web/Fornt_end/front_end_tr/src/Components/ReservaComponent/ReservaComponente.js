import React from "react";
import ReservaService from "../../services/ReservaService";
import axios from "axios";
import Swal from "sweetalert2";
import withReactContent from "sweetalert2-react-content";
import "../ReservaComponent/ReservaC.css"
import hucha from "../../Img/hucha.png"
import campana from "../../Img/campana.png"
import aceptar from "../../Img/aceptar.png"
import cancelar from "../../Img/cancelar.png"
import reserv from "../../Img/programar.png"
import tours from "../../Img/travel-map.png"

const handletour = async (reserva_id) => {
    //consulta que trae el id_depto
    localStorage.setItem('idReserva', reserva_id)
    const resp1 = await axios.get(`http://localhost:8080/api/v1/traerDpto/${reserva_id}`)
    localStorage.setItem('depto_tour', resp1.data)
    localStorage.setItem('ocultarBtn', 1)
    window.location.replace(`/mostrartour/${reserva_id}`);
}

const handleUpdate = async (id_reserva) => {
    const resp = await axios.post(`http://localhost:8080/api/v1/updateReserva/${id_reserva}`)
    console.log(resp.data)

    const MySwal = withReactContent(Swal);
    MySwal.fire({
        title: "Su reserva ha sido cancelada",
        icon: "success"
    }).then((respuesta) => {
        if (respuesta.isConfirmed) {
            window.location.replace('/Inicio');
        }
    })
}

const handleAcompañantes = (id_reserva) => {
    localStorage.setItem('idReserva', id_reserva)
    let id_reserva1 = localStorage.getItem('idReserva')
    window.location.replace(`/editarAcompanantes/${id_reserva1}`);
}

const handleServExtra = (id_reserva) => {
    localStorage.setItem('idReserva', id_reserva)
    let id_reserva1 = localStorage.getItem('idReserva')
    localStorage.setItem('ocultarReserva', 1)
    window.location.replace(`/ListaServExtra/${id_reserva1}`);
}
const handlePago = (id_reserva) => {
    const MySwal = withReactContent(Swal);
    localStorage.setItem('idReserva', id_reserva)
    let id_reserva1 = localStorage.getItem('idReserva')
    MySwal.fire({
        title: "Una vez pagada la reserva no se puede editar, agregar servicios extras, agregar tours y cancelar la reserva, ¿Desea continuar?",
        icon: "warning",
        showDenyButton: true,
        confirmButtonText: 'Si',
        denyButtonText: 'No'
    }).then((respuesta) => {
        if (respuesta.isConfirmed) {
            window.location.replace(`/portalPago/${id_reserva1}`);
        }
    })

}
const cambiarFecha = (fecha) => {
    let today = new Date(fecha);
    let day = today.getDate();
    let month = today.getMonth() + 1;
    let year = today.getFullYear();
    let tiempo = `${year}-${month}-${day}`
    return tiempo
}

class ReservaComponente extends React.Component {

    constructor(props) {
        super(props)
        this.state = {
            Reserva: []
        }
    }

    componentDidMount() {
        let id_clienteLOL = localStorage.getItem("id_cliente")
        ReservaService.getReserva(id_clienteLOL).then((Response) => {
            this.setState({ Reserva: Response.data })

        });
    }

    render() {

        return (
            <>
                <div class="container" style={{ color: "#1687A7" }}>
                    <h1 className="text-center">Reservas</h1>
                    <table class="table table-fixed">
                        <thead class="table-dark">
                            <tr>
                                <td>Numero Reserva</td>
                                <td>Nombre departamento</td>
                                <td>Check in</td>
                                <td>Check out</td>
                                <td>Estado Pago</td>
                                <td>Valor total</td>
                                <td>Pago</td>
                                <td>Servicio extra</td>
                                <td>Editar reserva</td>
                                <td>Editar tours</td>
                                <td>Cancelar</td>
                            </tr>
                        </thead>
                        <tbody style={{ color: "#1687A7" }}>
                            {
                                this.state.Reserva.map(
                                    Reserva =>
                                        <tr key={Reserva.id_reserva}>
                                            <td>{Reserva.id_reserva}</td>
                                            <td>{Reserva.nombre_dpto}</td>
                                            <td>{
                                                cambiarFecha(Reserva.check_in.slice(0, 10))
                                            }</td>
                                            <td>{
                                                cambiarFecha(Reserva.check_out.slice(0, 10))
                                            }</td>
                                            <td>
                                                {
                                                    Reserva.estado_pago === "A" ?
                                                        "Pago adelantado" :
                                                        "Pendiente"
                                                }

                                            </td>
                                            <td>{Reserva.valor_total}</td>
                                            <td>
                                                {
                                                    Reserva.estado_pago === "A" ?
                                                        <img src={aceptar}
                                                            height="50" width="50" alt="" /> :
                                                        <td><button class="button" onClick={() => handlePago(Reserva.id_reserva)}><img src={hucha}
                                                            height="50" width="50" alt="" /></button></td>
                                                }
                                            </td>
                                            <td>
                                                {
                                                    Reserva.estado_pago === "A" ?
                                                        <a></a> :
                                                        <td><button class="button" onClick={() => handleServExtra(Reserva.id_reserva)}><img src={campana}
                                                            height="50" width="50" alt="" /></button></td>
                                                }
                                            </td>
                                            <td>
                                                {
                                                    Reserva.estado_pago === "A" ?
                                                        <a></a> :
                                                        <td><button class="button" onClick={() => handleAcompañantes(Reserva.id_reserva)}><img src={reserv}
                                                            height="50" width="50" alt="" /></button></td>
                                                }
                                            </td>
                                            <td>
                                                {
                                                    Reserva.estado_pago === "A" ?
                                                        <a></a> :
                                                        <td><button class="button" onClick={() => handletour(Reserva.id_reserva)}><img src={tours}
                                                            height="50" width="50" alt="" /></button></td>
                                                }
                                            </td>
                                            {
                                                Reserva.estado_pago === "A" ?
                                                    <a></a> :
                                                    <td><button class="button" onClick={() => handleUpdate(Reserva.id_reserva)}><img src={cancelar}
                                                        height="50" width="50" alt="" /></button></td>
                                            }


                                        </tr>
                                )
                            }
                        </tbody>
                    </table>
                </div>

            </>
        );

    }
}

export default ReservaComponente