package com.turismo.backend_turismo_real.controlador;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import com.turismo.backend_turismo_real.modelo.Supercliente;
import com.turismo.backend_turismo_real.modelo.Tours;
import com.turismo.backend_turismo_real.modelo.superTour;
import com.turismo.backend_turismo_real.service.ToursServiceImple;

@RestController
@RequestMapping("/api/v1/")
@CrossOrigin(origins = "http://localhost:3000")
public class ToursControlador {
	
	@Autowired
	private ToursServiceImple servImpl;
	
	@GetMapping("/tours/{id_reserva}")
	public List<Tours> traerTours(@PathVariable int id_reserva){
		return servImpl.traerTours(id_reserva);
	}
	@PostMapping("/registrartour" )
	public int agregar_tours(@RequestBody superTour tour) {	
		return servImpl.agregar_tours( tour.getId_reserva(), tour.getId_tour(), tour.getFecha_tour(), tour.getId_dpto(), tour.getId_cliente());
	}
}
