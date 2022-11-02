package com.turismo.backend_turismo_real.controlador;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import com.turismo.backend_turismo_real.service.EnvioMail;

@RestController
@RequestMapping("/api/v1/")
@CrossOrigin(origins  = "http://localhost:3000")
public class EmailControlador {

	@Autowired
	private EnvioMail envio;
	
	@GetMapping("/TestCorreo")
	public void sendCorreo() {
		envio.SendEmail("yerko.mra@gmail.com", "HOLA YERKO", "OLA SOY EL BACKEND ENVIADO CORREOS");
	}
}
