	package com.turismo.backend_turismo_real.controlador;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;
import com.turismo.backend_turismo_real.modelo.superDepto;
import com.turismo.backend_turismo_real.service.superDeptoServImplement;

@RestController
@RequestMapping("/api/v1/")
@CrossOrigin(origins = "http://localhost:3000")
public class superDeptoControlador {
	@Autowired
	private superDeptoServImplement deptoServ;
	
	@GetMapping("/test/{id}")
	public ResponseEntity<superDepto> obtenerDeptoId(@PathVariable Integer id){
		return deptoServ.obtenerDeptoId(id);
	}

}
