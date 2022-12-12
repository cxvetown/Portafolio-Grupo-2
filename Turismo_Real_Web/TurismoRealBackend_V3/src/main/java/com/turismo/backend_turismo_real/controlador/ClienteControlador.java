package com.turismo.backend_turismo_real.controlador;

import java.util.List;
import java.util.Optional;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.ExceptionHandler;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import com.turismo.backend_turismo_real.exception.NoSuchElementFoundException;
import com.turismo.backend_turismo_real.modelo.AutentificarCliente;
import com.turismo.backend_turismo_real.modelo.Cliente;
import com.turismo.backend_turismo_real.modelo.Comuna;
import com.turismo.backend_turismo_real.modelo.Supercliente;
import com.turismo.backend_turismo_real.repositorio.ClienteRepositorio;
import com.turismo.backend_turismo_real.service.AutentificarServicioImplement;
import com.turismo.backend_turismo_real.service.ClienteServicioImplement;

@RestController
@RequestMapping("/api/v1/")
@CrossOrigin(origins = "http://localhost:3000")
public class ClienteControlador {

	@Autowired
	private ClienteServicioImplement serv;

	// guarda los datos y los inserta en la base de datos
	@PostMapping("/registrarse")
	public int registrarse(@RequestBody Supercliente cli) {
		return serv.registrarse(cli.getEmail(), cli.getPass(), cli.getFono(), cli.getRut(), cli.getNombre(),
				cli.getApellido());
	}

	// generar el POST para loguearse en el sistema
	@PostMapping("/login")
	public int login(@RequestBody Supercliente cli) {
		return serv.login(cli.getEmail(), cli.getPass());
	}

	// Con esto confirmamos el login y guardamos los datos de sesion
	@GetMapping("/loginConfirmed/{id}")
	public String loginConfirmed(@PathVariable int id) {
		return serv.loginConfirmed(id);
	}

	// Hacemos una consulta para comprobar la existencia del correo
	@PostMapping("/correoComprobacion")
	public String comprobarCorreo(@RequestBody Supercliente cli) {
		return serv.comprobarCorreo(cli.getEmail());
	}

	// Hacemos una consulta para comprobar la existencia del rut
	@PostMapping("/rutComprobacion")
	public String comprobarRut(@RequestBody Supercliente cli) {
		return serv.comprobarRut(cli.getRut());
	}
}
