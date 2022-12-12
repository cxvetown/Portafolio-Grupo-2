package com.turismo.backend_turismo_real.controlador;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import com.turismo.backend_turismo_real.modelo.TourReserva;
import com.turismo.backend_turismo_real.service.TourReservaServImpl;

@RestController
@RequestMapping("/api/v1/")
@CrossOrigin(origins = "http://localhost:3000")
public class TourReservaControlador {
	
	@Autowired
	private TourReservaServImpl servTour;
	
	@PostMapping("/add_tour")
	public int tours_add(@RequestBody TourReserva tr) {
		return servTour.tours_add(tr.getId_reserva(), tr.getId_tour(), tr.getFecha_tour(), tr.getId_dpto(), tr.getId_cliente());
	}
}
