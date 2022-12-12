import React from "react"
import { useParams } from "react-router-dom";
import { Button, Form } from "react-bootstrap";
import { useState, useEffect } from "react";
import axios from "axios";
import Swal from "sweetalert2";
import withReactContent from "sweetalert2-react-content";
import "../ReservaComponent/ReservaC.css"
import "../ReservaComponent/editarPago.css"
//creamos la funcion de pago web
const Pago_web = () => {
    //usamos el parametro de la url
    const { id_reserva } = useParams()

    //creamos los use state y la variable del Swal Alert
    const [valorTotal, setValorTotal] = useState('');
    const [tarjeta, setTarjeta] = useState('');
    const [nombres, setNombres] = useState('');
    const [fecha, setFecha] = useState('');
    const [fecha1, setFecha1] = useState('');
    const [cv, setCv] = useState('');
    const MySwal = withReactContent(Swal);

    const handleTarjeta = acom => {
        const result = acom.replace(/\D/g, '');
        setTarjeta(result)
    }
    const handleFecha = acom => {
        const result = acom.replace(/\D/g, '');
        setFecha(result)
    }
    const handleFecha1 = acom => {
        const result = acom.replace(/\D/g, '');
        setFecha1(result)
    }
    const handleCv = acom => {
        const result = acom.replace(/\D/g, '');
        setCv(result)
    }

    //creamos un use effect para cargar el valor total
    useEffect(() => {
        const obtenerValorTotal = async () => {
            const resp = await axios.get(`http://localhost:8080/api/v1/obtenerReserva/${id_reserva}`)
            setValorTotal(resp.data.valor_total * (75 / 100))
        }
        obtenerValorTotal()
    })

    //la funcion que se encargara de actualizar el pago
    const handleUpdate = async () => {

        if (tarjeta === '' || nombres === '' || fecha === '' || cv === '' || fecha1 === '') {
            MySwal.fire({
                title: "Debe rellenar los campos solicitados",
                icon: "error"
            })
        }
        else {
            const resp = await axios.post(`http://localhost:8080/api/v1/ActualizarPago/${id_reserva}`)
            console.log(resp.data.estado_pago)

            
            MySwal.fire({
                title: "El pago ha sido realizado con exito",
                icon: "success",
                allowOutsideClick: false
            }).then((respuesta) => {
                if (respuesta.isConfirmed) {
                    window.location.replace('/ListaReserva');
                }
            })
        }
    }
    return (
        <>
            <div className="mx-auto" style={{color: "#1687A7"}}>
                <br></br>
                <h2 className="text-center">Portal de pagos Turismo Real</h2>
                <div className="mx-auto mt-5 w-25" >
                    <div className="form-row mb-3">
                        <Form.Group className="form-input mb-3"
                            type="text"
                            pattern="\d*"
                            id="numerotarjeta"
                        >
                            <Form.Label>Numero Tarjeta</Form.Label>
                            <Form.Control  type="text" placeholder="Ej: 2637 3627 4361 2163" maxLength={16} value={tarjeta} onChange={(e) => handleTarjeta(e.target.value)}/>
                        </Form.Group>
                    </div>
                    <div className="form-row mb-3">
                        <Form.Group className="form-input mb-3"
                            type="text"
                            id="nombres"
                            value={nombres}
                            onChange={(e) => setNombres(e.target.value)}
                        >
                            <Form.Label>Nombre titular</Form.Label>
                            <Form.Control type="text" placeholder="Ingrese nombre del titular" />
                        </Form.Group>
                    </div>
                    <br></br>
                    <div className="form-row mb-3">
                        <label>Fecha</label>&nbsp;&nbsp;
                        <p class="fecha"><input className="form-control" type="text" style={{width : "60px", heigth : "30px"}} 
                        maxLength={2} value={fecha} onChange={(e) => handleFecha(e.target.value)}></input></p>&nbsp;
                        <h5 class="fecha">/</h5>&nbsp;
                        <p class="fecha"><input className="form-control" type="text" style={{width : "60px", heigth : "30px"}}
                        maxLength={2} value={fecha1} onChange={(e) => handleFecha1(e.target.value)}></input></p>&nbsp;&nbsp;
                        <label>CV</label>&nbsp;&nbsp;
                        <p class="fecha"><input type="text" className="form-control" style={{width : "65px", heigth : "30px"}} 
                        maxLength={3} value={cv} onChange={(e) => handleCv(e.target.value)}></input></p>&nbsp;
                    </div>   
                    <br></br>
                    <h2>El valor total a pagar es: ${valorTotal}</h2>
                    <br></br>
                    <Button variant="primary" style={{backgroundColor: "#1687A7"}} onClick={handleUpdate}>
                        Pagar
                    </Button>
                </div>
            </div>
        </>
    );
}
export default Pago_web;