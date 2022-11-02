package com.turismo.backend_turismo_real.controlador;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import com.turismo.backend_turismo_real.modelo.AutentificarCliente;
import com.turismo.backend_turismo_real.service.AutentificarServicioImplement;

@RestController
@RequestMapping("/api/v1/")
@CrossOrigin(origins = "http://localhost:3000")
public class AutControlador {

	@Autowired
	private AutentificarServicioImplement AutServ;
	
	@PostMapping("/AutRegistrarse")
	public AutentificarCliente guardarAutentificar(@RequestBody AutentificarCliente autCli) {
		AutServ.SendEmail(autCli.getEmail(),"Validacion de correo" , "Hola, su numero de validacion es : " + autCli.getCode());
		return AutServ.guardarAutentificar(autCli);
		
	}
	
	@GetMapping("/autCodigo/{code}")
	public String AutCodigo(@PathVariable int code) {
		return AutServ.AutCodigo(code);
	}
}
