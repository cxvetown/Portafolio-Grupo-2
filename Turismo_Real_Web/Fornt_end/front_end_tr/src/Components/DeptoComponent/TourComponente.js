import React from "react";
import TourServ from "../../services/TourService"
import Swal from "sweetalert2";
import withReactContent from "sweetalert2-react-content";
import axios from "axios";

const handleContratar = async (id_tour1, valorTour) => {
    let fecha = document.getElementById("fecha_tour").value;
    console.log(fecha)
    let id_res = localStorage.getItem('idReserva')
    id_res = parseInt(id_res)
    let id_dp = localStorage.getItem('idDeptoFotos')
    id_dp = parseInt(id_dp)
    let id_cli = localStorage.getItem('id_cliente')
    id_cli = parseInt(id_cli)
    console.log(id_res, id_tour1, fecha, id_dp, id_cli)

    try {
        const MySwal = withReactContent(Swal);
        if (fecha === '') {
            MySwal.fire({
                title: "Error al ingresar la fecha, intente nuevamente",
                icon: "error"
            }).then((respuesta) => {
                if (respuesta.isConfirmed) {
                    window.location.replace(`/mostrartour/${id_res}`);
                }
            })
        } else {
            const resp = await axios.post('http://localhost:8080/api/v1/add_tour', {
                id_reserva: id_res, id_tour: id_tour1, fecha_tour: fecha, id_dpto: id_dp, id_cliente: id_cli
            }, { headers: { "Content-Type": "application/json" } })
            const resppago = await axios.post(`http://localhost:8080/api/v1/actualizarValor/${id_res}`, {
                valor_serv_ex: valorTour
            })
            MySwal.fire({
                title: "El tour ha sido agendado con exito",
                icon: "success"
            }).then((respuesta) => {
                if (respuesta.isConfirmed) {
                    window.location.replace(`/mostrartour/${id_res}`);
                }
            })
        }

    } catch (error) {
        console.log(error)
    }

}

const postTours = () => {
    const MySwal = withReactContent(Swal);

    MySwal.fire({
        title: "¿Desea agregar servicios extras?",
        icon: "info",
        showDenyButton: true,
        allowOutsideClick: false,
        confirmButtonText: 'Si',
        denyButtonText: 'No'
    }).then((respuesta) => {
        if (respuesta.isConfirmed) {
            const idReserva1 = localStorage.getItem('idReserva')
            window.location.replace(`/ListaServExtra/${idReserva1}`);
        } else {
            MySwal.fire({
                title: "Reserva Exitosa",
                icon: "success"
            }).then((respuesta) => {
                if (respuesta.isConfirmed) {
                    window.location.replace('/Inicio');

                }
            })
        }
    })
}
const PostCancelar = () => {
    const MySwal = withReactContent(Swal);

    MySwal.fire({
        title: "¿Desea continuar sin agregar un tour?",
        icon: "info",
        showDenyButton: true,
        allowOutsideClick: false,
        confirmButtonText: 'Si',
        denyButtonText: 'No'
    }).then((respuesta) => {
        if (respuesta.isConfirmed) {
            MySwal.fire({
                title: "¿Desea agregar servicios extras?",
                icon: "info",
                showDenyButton: true,
                allowOutsideClick: false,
                confirmButtonText: 'Si',
                denyButtonText: 'No'
            }).then((respuesta) => {
                if (respuesta.isConfirmed) {
                    const idReserva1 = localStorage.getItem('idReserva')
                    window.location.replace(`/ListaServExtra/${idReserva1}`);
                } else {
                    MySwal.fire({
                        title: "Reserva Exitosa",
                        icon: "success"
                    }).then((respuesta) => {
                        if (respuesta.isConfirmed) {
                            window.location.replace('/Inicio');

                        }
                    })
                }
            })
        } else {

        }
    })
}

class TourComponent extends React.Component {

    constructor(props) {
        super(props)
        this.state = {
            tours: []
        }
    }

    componentDidMount() {
        let id_res = localStorage.getItem('idReserva')
        TourServ.getTours(id_res).then((Response) => {
            this.setState({ tours: Response.data })
        });
    }

    render() {
        return (
            <>
                <div class="container" style={{ color: "#1687A7" }} >
                    <h1 className="text-center">Listado de tours</h1>
                    <table class="table table-fixed">
                        <thead class="table-dark">
                            <tr>
                                <td>Nombre del tour</td>
                                <td>Descripcion</td>
                                <td>Valor del tour</td>
                                <td>Fecha del tour</td>
                                <td></td>
                            </tr>
                        </thead>
                        <tbody style={{ color: "#1687A7" }}>
                            {
                                this.state.tours.map(
                                    tours =>
                                        <tr key={tours.id_tour}>
                                            <td>{tours.nombre_tour}</td>
                                            <td>{tours.desc_tour}</td>
                                            <td>{tours.valor_tour}</td>
                                            <td><input type="date" id="fecha_tour" min="2022-11-01"></input></td>
                                            <td><button className="btn btn-primary" style={{ backgroundColor: "#1687A7" }} onClick={() => handleContratar(tours.id_tour, tours.valor_tour)}>Contratar</button></td>
                                        </tr>
                                )
                            }
                        </tbody>
                    </table>
                    <br></br>
                    <div className="text text-center">
                        {
                            localStorage.getItem('ocultarBtn') == 1 ?
                                <h1></h1> :
                                <div className="text text-center">
                                    <button onClick={postTours} style={{ backgroundColor: "#1687A7" }} className="btn btn-primary">Continuar</button>&nbsp;<button className="btn btn-danger" onClick={PostCancelar} style={{ backgroundColor: "#1687A7" }}>Cancelar</button>
                                </div>
                        }
                    </div>
                </div>
            </>
        )
    }
}
export default TourComponent