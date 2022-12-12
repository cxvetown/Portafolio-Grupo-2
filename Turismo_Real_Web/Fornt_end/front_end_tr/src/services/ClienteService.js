import axios from "axios";

export const ingresarUsuario = async (correo, contraseña, telefono, rut, dv, nombres, apellidos) => {
    try {
        const rut_final = rut + "-" + dv
        const resp = await axios.post('http://localhost:8080/api/v1/registrarse', {
            email: correo, pass: contraseña, fono: telefono,
            rut: rut_final, nombre: nombres, apellido: apellidos
        })
        console.log(resp)
    } catch (error) {
        console.log(error)
    }
}

export const ValidarLogin = async (correoConsulta, code) => {
    try {
        const resp = await axios.post('http://localhost:8080/api/v1/AutRegistrarse', {
            email: correoConsulta,
            code: code
        
        })
        console.log(resp)
    } catch (error) {
        console.log(error)
    }
}


export const obtenerUsuarioPorCorreo = async (correoConsulta, contraseña) => {
    try {
        const usuario = await axios.post('http://localhost:8080/api/v1/ValidarCorreo', {
            correo: correoConsulta,
            password: contraseña
        })
        return usuario
    } catch (error) {
        console.log(error)
    }
}