import { useContext, useEffect, useState } from "react";
import Button from 'react-bootstrap/Button';
import axios from "axios";
import Form from 'react-bootstrap/Form';
import clienteContext from "../../Contexts/ClienteContext";
import Swal from "sweetalert2";
import withReactContent from "sweetalert2-react-content";

//creamos variables con las url que llaman al backend
const url = "http://localhost:8080/api/v1/login"
const url_confirm = "http://localhost:8080/api/v1/loginConfirmed/"

//creamos la funcion principal que contiene todo el codigo
const Login = () => {
    //usamos el useContext para tener los datos de usuario que esta activo actualmente

    const { usuario, setUsuario } = useContext(clienteContext);
    const { id, setId } = useContext(clienteContext);

    //utilizamos el useState para guardar variables y poder llenarla y renderizarla

    const [correo, setCorreo] = useState('');
    const [contraseña, setContraseña] = useState('');

    //creamos la const myswal para llamar los mensajes de alerta de Swal Alert

    const MySwal = withReactContent(Swal);

    //la const handleSubmit hara las llamadas al back al ser llamada

    const handleSubmit = async (e) => {

        //preventDefault permite tener un seguro en caso de que se cancele el evento y no hacer las llamadas
        e.preventDefault();

        //llamamos un Try catch en caso de fallo en las llamadas
        try {
            if(correo === '' && contraseña === ''){
                MySwal.fire({
                    title: "Debe rellenar los datos para ingresar",
                    icon: "error"
                })
            }else {
                //llamamos a axios para que haga la llamada al backend con los datos necesarios
            const resp = await axios.post(url, { email: correo, pass: contraseña })
            console.log(resp.data)

            //comprobamos que el inicio de sesion sea correcto
            if (resp.data === 0) {
                MySwal.fire({
                    title: "Error en el inicio de sesión, verifica tus datos",
                    icon: "error"
                })

            //si el inicio es correcto, procede a enviar un mensaje y redirigir
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
                }).then((respuesta) => {
                    if (respuesta.isConfirmed) {
                        window.location.replace('/Inicio');
                    }
                })

            }
            }
            
            //mostramos un error si no pasa el Try
        } catch (error) {
            console.log(error.response)
        }
    }

    //devolvemos el codigo HTML que sera renderizado cuando se llame la funcion
    return (
        <>
            <div className="mx-auto" style={{color: "#000000", fontWeight: "bold"}}>
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
                            <Form.Control type="email" placeholder="Ingrese un correo" id="correo_login" maxLength={254}/>
                        </Form.Group>
                    </div>
                    <div className="form-row mb-3">
                        <Form.Group className="form-input mb-3"
                            type="password"
                            id="contraseña"
                            value={contraseña}
                            onChange={(e) => setContraseña(e.target.value)}>
                            <Form.Label>Contraseña</Form.Label>
                            <Form.Control type="password" placeholder="Contraseña"  maxLength={30}/>
                        </Form.Group>
                    </div>
                    <button type='submit' className='btn btn-primary' style={{backgroundColor: "#1687A7"}}>
                        Iniciar Sesion
                    </button>
                    <Button variant="primary" style={{backgroundColor: "#1687A7"}} type="submit" className='text mx-3' href='Registrarse'>
                        Registrarse
                    </Button>
                </form>
            </div>
        </>
    );
};
export default Login;
