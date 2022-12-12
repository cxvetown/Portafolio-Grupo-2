import React, { useState } from "react";
import Button from 'react-bootstrap/Button';
import Modal from 'react-bootstrap/Modal';
import { Form } from "react-bootstrap";
import * as clienteServicio from "../../services/ClienteService";
import Swal from "sweetalert2";
import withReactContent from "sweetalert2-react-content";
import axios from "axios";
//creamos la funcion de registrar
function Registrar() {

    //llamamos a la variable de Swal Alert
    const MySwal = withReactContent(Swal);
    //creamos una variable que guardara el tiempo de carga
    let timerInterval;

    //creamos los useState que vamos a utilizar
    const [Rut, setRut] = useState('');
    const [dv, setDv] = useState('');
    const [nombres, setNombres] = useState('');
    const [apellidos, setApellidos] = useState('');
    const [correo, setCorreo] = useState('');
    const [telefono, setTelefono] = useState('');
    const [contraseña, setContraseña] = useState('');
    const [repContraseña, setRepContraseña] = useState('');
    let [code, setCode] = useState('');
    const [repCode, setRepCode] = useState('');

    const handleTelefono = tel => {
        const result = tel.replace(/\D/g, '');
        setTelefono(result)
    }

    const handleVerificacion = cod => {
        const result = cod.replace(/\D/g, '');
        setRepCode(result)
    }
    const handleNombre = nom =>{
        const result = nom.replace(/[\W\d]*/g, '');
        setNombres(result)
    }
    const handleApellido = app =>{
        const result = app.replace(/[\W\d]*/g, '');
        setApellidos(result)
    }
    const handleRut = rut1 => {
        const result = rut1.replace(/\D/g, '');
        setRut(result)
    }
    const handleCV = cv1 => {
        const result = cv1.replace(/[a-j]*[l-z]*[A-J]*[L-Z]*[\W]*/g, '');
        setDv(result)
    }

    //obtenemos un numero random que sera enviado como codigo de verificacion
    function getRandomInt() {
        return Math.floor(Math.random() * 9999999);
    }

    //creamos otras variables que sirven de estado para el modal de comprobacion
    const [show, setShow] = useState(false);
    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);

    //creamos la variable para hacer la validacion 
    const handleValidar = async () => {
        if (contraseña.length <= 8 || repContraseña <= 8) {
            MySwal.fire({
                title: "La contraseña debe tener un largo de 8 caracteres",
                icon: "error"
            })
        } else {
            if (Rut === '' || nombres === '' || apellidos === '' || correo === '' || telefono === '' || contraseña === '' || repContraseña === '') {
                MySwal.fire({
                    title: "Debe rellenar los campos",
                    icon: "error"
                })
            } else {
                const resRut = await axios.post('http://localhost:8080/api/v1/rutComprobacion', {
                    rut: Rut
                })
                if (resRut.data === '') {
                    const respCorreo = await axios.post('http://localhost:8080/api/v1/correoComprobacion', {
                        email: correo
                    })
                    if (respCorreo.data === '') {
                        //comprobamos que las contraseñas sean correctas
                        if (contraseña === repContraseña) {
                            //si son correctas muestra el modal y envia el codigo de comprobacion
                            handleShow()
                            code = getRandomInt();
                            setCode(code)
                            clienteServicio.ValidarLogin(correo, code)
                        } else {
                            //mensaje de error de las contraseñas
                            MySwal.fire({
                                title: "Las contraseñas no coinciden",
                                icon: "error"
                            })
                        }
                    } else {
                        MySwal.fire({
                            title: "El correo ya esta en uso",
                            icon: "error"
                        })
                    }
                } else {
                    MySwal.fire({
                        title: "El rut ya esta en uso",
                        icon: "error"
                    })
                }
            }
        }

    }

    //comprobacion de codigo de verificacion
    const HandleCodigo = () => {
        //verificamos que el codigo que se inserto y el codigo del correo sean iguales
        if (code === parseInt(repCode)) {
            //insertamos el cliente
            clienteServicio.ingresarUsuario(correo, contraseña, telefono, Rut, dv, nombres, apellidos)
            MySwal.fire({
                //creamos el mensaje de usuario creado y con un timer para cargar la pagina
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
                //redirigimos a la pagina de inicio
                willClose: () => {
                    clearInterval(timerInterval)
                    window.location.replace('/Inicio');
                }
            })

            //el codigo no es correcto envia un mensaje de error
        } else {
            MySwal.fire({
                title: "El codigo de verificacion no coincide",
                icon: "error"
            })
        }
    }

    return (
        <>

            <div className="mx-auto" style={{ color: "#000000", fontWeight: "bold" }}>
                <br></br>
                <h2 className="text-center">Registrate en Turismo Real</h2>
                <div className="mx-auto mt-5 w-25">
                <label>Rut</label>
                    <div className="form-row mb-1">
                        <p class="fecha"><input className="form-control" type="text" style={{width : "150px", heigth : "30px"}} 
                        maxLength={8} value={Rut} onChange={(e) => handleRut(e.target.value)}></input></p>&nbsp;
                        <h5 class="fecha">-</h5>&nbsp;
                        <p class="fecha"><input className="form-control" type="text" style={{width : "40px", heigth : "30px"}}
                        maxLength={1} value={dv} onChange={(e) => handleCV(e.target.value)}></input></p>
                    </div>
                    <div className="form-row mb-3">
                        <Form.Group className="form-input mb-3"
                            type="text"
                            id="nombres">
                            <Form.Label>Nombres</Form.Label>
                            <Form.Control type="text" placeholder="Ingrese nombres" maxLength={60} value={nombres} onChange={(e) => handleNombre(e.target.value)}/>
                        </Form.Group>
                    </div>
                    <div className="form-row mb-3">
                        <Form.Group className="form-input mb-3"
                            type="text"
                            id="apellidos"
                            >
                            <Form.Label>Apellidos</Form.Label>
                            <Form.Control type="text" placeholder="Ingrese apellidos" maxLength={60} value={apellidos} onChange={(e) => handleApellido(e.target.value)}/>
                        </Form.Group>
                    </div>
                    <div className="form-row mb-3">
                        <Form.Group className="form-input mb-3"
                            type="text"
                            id="correo"
                            >
                            <Form.Label>Correo</Form.Label>
                            <Form.Control type="email" placeholder="Ingrese un correo" maxLength={254} value={correo} onChange={(e) => setCorreo(e.target.value)}/>
                        </Form.Group>
                    </div>
                    <div className="form-row mb-3">
                        <Form.Group className="form-input mb-3"
                            type="text"
                            id="telefono1"
                            value={telefono}
                            onChange={(e) => handleTelefono(e.target.value)}>
                            <Form.Label>Telefono</Form.Label>
                            <Form.Control type="text" placeholder="Ej: 99999999" maxLength={9} value={telefono} onChange={(e) => handleTelefono(e.target.value)} />
                        </Form.Group>
                    </div>
                    <div className="form-row mb-3">
                        <Form.Group className="form-input mb-3"
                            type="password"
                            id="contraseña"
                            value={contraseña}
                            onChange={(e) => setContraseña(e.target.value)}>
                            <Form.Label>Contraseña</Form.Label>
                            <Form.Control type="password" placeholder="Contraseña" maxLength={30} />
                        </Form.Group>
                    </div>
                    <div className="form-row mb-3">
                        <Form.Group className="form-input mb-3"
                            type="password"
                            id="repContraseña"
                            value={repContraseña}
                            onChange={(e) => setRepContraseña(e.target.value)}>
                            <Form.Label>Repite contraseña</Form.Label>
                            <Form.Control type="password" placeholder="Contraseña" maxLength={30} />
                        </Form.Group>
                    </div>
                    <br></br>
                    <Button variant="primary" style={{ backgroundColor: "#1687A7" }} onClick={handleValidar}>
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
                        >
                            <Form.Label>Ingresar codigo de verificación</Form.Label>
                            <Form.Control type="text" placeholder="ej: 123456" value={repCode} onChange={(e) => handleVerificacion(e.target.value)} maxLength={8} />
                        </Form.Group>
                    </div>
                </Modal.Body>
                <Modal.Footer>

                    <Button variant="primary" style={{ backgroundColor: "#1687A7" }} onClick={handleValidar}>
                        Reenviar Codigo
                    </Button>
                    <Button variant="success" style={{ backgroundColor: "#1687A7" }} onClick={HandleCodigo} >
                        Comprobar
                    </Button>

                </Modal.Footer>
            </Modal>
        </>
    );
}
export default Registrar;