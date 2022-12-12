import React from "react"
import { useParams } from "react-router-dom";
import { Form, Button } from "react-bootstrap";
import { useState } from "react";
import axios from "axios";
import Swal from "sweetalert2";
import withReactContent from "sweetalert2-react-content";
import { useEffect } from "react";


//creamos la funcion que se cargara
const EditarAcom = () => {
    //traemos la variable que viene en la URL
    const { id_reserva } = useParams()
    //creamos los usestate que se necesitan
    const [disponibilidad, setDisponibilidad] = useState('');
    const [id_depto, setIdDepto] = useState('');
    const [acompañantes, setAcompañante] = useState('');
    //creamos la variable del Swal Alert
    const MySwal = withReactContent(Swal);

    const handleAcom = acom => {
        const result = acom.replace(/\D/g, '');
        setAcompañante(result)
    }

    //usamos un useEffect para cargar la disponibilidad
    useEffect(() => {
        //llamamos al backend y traemos todas la disponibilidad
        const cargarDisponibilidad = async () => {
            //traemos el id del departamento en base a la reserva
            const resp = await axios.get(`http://localhost:8080/api/v1/traerDpto/${id_reserva}`)
            localStorage.setItem('iddep', resp.data)
            //traemos la disponibilidad del departamento
            let id_dep = localStorage.getItem('iddep')
            const respDepto = await axios.get(`http://localhost:8080/api/v1/capacidad/${id_dep}`)
            setDisponibilidad(respDepto.data)
        }
        cargarDisponibilidad()
    }, [])

    //actualizamos los acompañantes de la reserva
    const handleActualizarAcom = async () => {
        if(acompañantes>disponibilidad){
            MySwal.fire({
                title: "La cantidad de acompañantes supera la disponibilidad",
                icon: "error"
            })
        }
        else{
            const resp = await axios.post(`http://localhost:8080/api/v1/act_acompañantes/${id_reserva}`, {
            cantidad_acompañantes: acompañantes
        });
        //mensaje de confirmacion y redireccion a la lista de reservas
        MySwal.fire({
            title: "Se ha actualizado la reserva",
            icon: "success"
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
                <h2 className="text-center">Editar reserva</h2>
                <div className="mx-auto mt-5 w-25" >
                    <div className="form-row mb-3">
                        <Form.Group className="form-input mb-3"
                            type="text"
                            id="acompañantes"
                        >
                            <Form.Label>Editar acompañantes</Form.Label>
                            <Form.Control type="text" placeholder="Ej: 2" maxLength={2}  value={acompañantes} onChange={(e) => handleAcom(e.target.value)}/>
                        </Form.Group>
                    </div>
                    <br></br>
                    <h3>La disponibilidad del departamento es: {disponibilidad}</h3>
                    <Button variant="primary" style={{backgroundColor: "#1687A7"}} onClick={handleActualizarAcom}>
                        Editar
                    </Button>
                </div>
            </div>
        </>
    );
}
export default EditarAcom;