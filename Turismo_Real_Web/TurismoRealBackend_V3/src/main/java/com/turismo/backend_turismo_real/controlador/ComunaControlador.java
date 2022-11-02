package com.turismo.backend_turismo_real.controlador;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import com.turismo.backend_turismo_real.modelo.Comuna;
import com.turismo.backend_turismo_real.service.ComunaServiceImplement;

@RestController
@RequestMapping("/api/v1/")
@CrossOrigin(origins = "http://localhost:3000")
public class ComunaControlador {

	@Autowired
	private ComunaServiceImplement comunaServ;
	
	@GetMapping("/comunaid/{id}")
	public ResponseEntity<Comuna> obtenerDeptoId(@PathVariable Integer id){
		return comunaServ.obtenerComunaId(id);
	}
}
