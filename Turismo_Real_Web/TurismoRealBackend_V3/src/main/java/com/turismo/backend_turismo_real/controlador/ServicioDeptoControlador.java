package com.turismo.backend_turismo_real.controlador;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import com.turismo.backend_turismo_real.modelo.ServicioDepto;
import com.turismo.backend_turismo_real.service.ServicioDeptoServImpl;

@RestController
@RequestMapping("/api/v1/")
@CrossOrigin(origins = "http://localhost:3000")
public class ServicioDeptoControlador {

	@Autowired
	private ServicioDeptoServImpl servDpto;
	
	@GetMapping("/lista_servicios_dpto/{id_dpto}")
	public List<ServicioDepto> listarServicio(@PathVariable Integer id_dpto){
		return servDpto.listarServicio(id_dpto);
	}
}
