import { useContext, useEffect, useState } from "react";
import Button from 'react-bootstrap/Button';
import axios from "axios";
import Form from 'react-bootstrap/Form';
import clienteContext from "../../Contexts/ClienteContext";
import Swal from "sweetalert2";
import withReactContent from "sweetalert2-react-content";

const url = "http://localhost:8080/api/v1/login"
const url_confirm = "http://localhost:8080/api/v1/loginConfirmed/"

const Login = () => {
    const { usuario, setUsuario } = useContext(clienteContext);
    const { id, setId } = useContext(clienteContext);

    const [correo, setCorreo] = useState('');
    const [contraseña, setContraseña] = useState('');

    const MySwal = withReactContent(Swal);

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            const resp = await axios.post(url, { email: correo, pass: contraseña })
            console.log(resp.data)
            if (resp.data === 0) {
                MySwal.fire({ 
                    title: "Error en el inicio de sesión, verifica tus datos",
                    icon: "error" 
                })
            } else {
                const usuariobd = await axios.get(`${url_confirm}${resp.data}`);
                setUsuario(correo)
                localStorage.setItem('correo_usuario', usuariobd.data)
                console.log(resp.data)
                setId(resp.data)
                localStorage.setItem('id_cliente', resp.data)
                MySwal.fire({ 
                    title: "Inicio de sesión correcto",
                    icon: "success" 
                }).then((respuesta)=>{
                    if(respuesta.isConfirmed){
                        window.location.replace('/Inicio');
                    }
                })

            }
        } catch (error) {
            console.log(error.response)
        }
    }

    return (
        <>
            <div className="mx-auto">
                <br></br>
                <h2 className="text-center">Iniciar sesión</h2>
                <form className="form mx-auto mt-5 w-25" onSubmit={handleSubmit}>
                    <div className="form-row mb-3">
                        <Form.Group className="form-input mb-3"
                            type="text"
                            id="rut"
                            value={correo}
                            onChange={(e) => setCorreo(e.target.value)}>
                            <Form.Label>Correo</Form.Label>
                            <Form.Control type="email" placeholder="Ingrese un correo" id="correo_login" />
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
                    <button type='submit' className='btn btn-primary'>
                        Iniciar Sesion
                    </button>
                    <Button variant="primary" type="submit" className='text mx-3' href='Registrarse'>
                        Registrarse
                    </Button>
                </form>
            </div>
        </>
    );
};
export default Login;
