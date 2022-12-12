package com.turismo.backend_turismo_real.controlador;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import com.turismo.backend_turismo_real.modelo.ServicioExtra;
import com.turismo.backend_turismo_real.service.ServExtraServicioImpl;

@RestController
@RequestMapping("/api/v1/")
@CrossOrigin(origins = "http://localhost:3000")
public class ServExtraControlador {

	@Autowired
	private ServExtraServicioImpl servExtra;
	
	@GetMapping("/allService/{id_reserva}")
	public List<ServicioExtra> todos_servicios(@PathVariable Integer id_reserva) {
		return servExtra.todos_servicios(id_reserva);
	}
}
