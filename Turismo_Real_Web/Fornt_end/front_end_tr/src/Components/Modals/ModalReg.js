import React, { useState } from "react";
import Button from 'react-bootstrap/Button';
import Modal from 'react-bootstrap/Modal';
import { Form } from "react-bootstrap";
import * as clienteServicio from "../../services/ClienteService";
import Swal from "sweetalert2";
import withReactContent from "sweetalert2-react-content";


function Example() {
    const MySwal = withReactContent(Swal);
    let timerInterval;
    const [rut, setRut] = useState('');
    const [nombres, setNombres] = useState('');
    const [apellidos, setApellidos] = useState('');
    const [correo, setCorreo] = useState('');
    const [telefono, setTelefono] = useState('');
    const [contraseña, setContraseña] = useState('');
    const [repContraseña, setRepContraseña] = useState('');
    let [code, setCode] = useState('');
    const [repCode, setRepCode] = useState('');

    function getRandomInt() {
        return Math.floor(Math.random() * 9999999);
    }

    const [show, setShow] = useState(false);
    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);

    const handleValidar = () => {
        if (contraseña === repContraseña) {
            handleShow()
            code = getRandomInt();
            setCode(code)
            clienteServicio.ValidarLogin(correo, code)
        } else {
            MySwal.fire({
                title: "Las contraseñas no coinciden",
                icon: "error" 
            })
        }

    }

    const HandleCodigo = () => {
        if (code === parseInt(repCode)) {
            clienteServicio.ingresarUsuario(correo, contraseña, telefono, rut, nombres, apellidos)
            MySwal.fire({
                title: "Usuario creado, Volviendo a la pagina de inicio...",
                icon: "success",
                timer: "2500",
                showCancelButton: false,
                showConfirmButton: false,
                allowOutsideClick: false,
                didOpen: () => {
                  Swal.showLoading()
                  const b = Swal.getHtmlContainer().querySelector('b')
                  timerInterval = setInterval(() => {
                    b.textContent = Swal.getTimerLeft()
                  }, 100)
                },
                willClose: () => {
                  clearInterval(timerInterval)
                  window.location.replace('/Inicio');
                }
              })

        } else {
            MySwal.fire({
                title: "El codigo de verificacion no coincide",
                icon: "error" 
            })
        }
    }

return (
    <>

        <div className="mx-auto">
            <br></br>
            <h2 className="text-center">Registrate en Turismo Real</h2>
            <div className="mx-auto mt-5 w-25">
                <div className="form-row mb-3">
                    <Form.Group className="form-input mb-3"
                        type="text"
                        id="rut"
                        value={rut}
                        onChange={(e) => setRut(e.target.value)}>
                        <Form.Label>RUT</Form.Label>
                        <Form.Control type="text" placeholder="Ej: 20382647-3" />
                    </Form.Group>
                </div>
                <div className="form-row mb-3">
                    <Form.Group className="form-input mb-3"
                        type="text"
                        id="nombres"
                        value={nombres}
                        onChange={(e) => setNombres(e.target.value)}>
                        <Form.Label>Nombres</Form.Label>
                        <Form.Control type="text" placeholder="Ingrese nombres" />
                    </Form.Group>
                </div>
                <div className="form-row mb-3">
                    <Form.Group className="form-input mb-3"
                        type="text"
                        id="apellidos"
                        value={apellidos}
                        onChange={(e) => setApellidos(e.target.value)}>
                        <Form.Label>Apellidos</Form.Label>
                        <Form.Control type="text" placeholder="Ingrese apellidos" />
                    </Form.Group>
                </div>
                <div className="form-row mb-3">
                    <Form.Group className="form-input mb-3"
                        type="text"
                        id="correo"
                        value={correo}
                        onChange={(e) => setCorreo(e.target.value)}>
                        <Form.Label>Correo</Form.Label>
                        <Form.Control type="email" placeholder="Ingrese un correo" />
                    </Form.Group>
                </div>
                <div className="form-row mb-3">
                    <Form.Group className="form-input mb-3"
                        type="text"
                        id="telefono"
                        value={telefono}
                        onChange={(e) => setTelefono(e.target.value)}>
                        <Form.Label>Telefono</Form.Label>
                        <Form.Control type="text" placeholder="Ej: 99999999" />
                    </Form.Group>
                </div>
                <div className="form-row mb-3">
                    <Form.Group className="form-input mb-3"
                        type="password"
                        id="contraseña"
                        value={contraseña}
                        onChange={(e) => setContraseña(e.target.value)}>
                        <Form.Label>Contraseña</Form.Label>
                        <Form.Control type="password" placeholder="Contraseña" />
                    </Form.Group>
                </div>
                <div className="form-row mb-3">
                    <Form.Group className="form-input mb-3"
                        type="password"
                        id="repContraseña"
                        value={repContraseña}
                        onChange={(e) => setRepContraseña(e.target.value)}>
                        <Form.Label>Repite contraseña</Form.Label>
                        <Form.Control type="password" placeholder="Contraseña" />
                    </Form.Group>
                </div>
                <br></br>
                <Button variant="primary" onClick={handleValidar}>
                    Registrarse
                </Button>
            </div>
        </div>
        <Modal
            show={show}
            onHide={handleClose}
            backdrop="static"
            keyboard={false}
        >
            <Modal.Header closeButton>
                <Modal.Title>Verificacion de correo</Modal.Title>
            </Modal.Header>
            <Modal.Body>
                <p>Para completar el registro, debe ingresar el codigo que fue enviado a su correo</p>
                <div className="form-row mb-3">
                    <Form.Group className="form-input mb-3"
                        type="number"
                        id="repCode"
                        value={repCode}
                        onChange={(e) => setRepCode(e.target.value)}>
                        <Form.Label>Ingresar codigo de verificación</Form.Label>
                        <Form.Control type="number" placeholder="ej: 123456" />
                    </Form.Group>
                </div>
            </Modal.Body>
            <Modal.Footer>

                <Button variant="primary" onClick={handleValidar}>
                    Reenviar Codigo
                </Button>
                <Button variant="primary" onClick={HandleCodigo} >
                    Comprobar
                </Button>

            </Modal.Footer>
        </Modal>
    </>
);
}
export default Example;