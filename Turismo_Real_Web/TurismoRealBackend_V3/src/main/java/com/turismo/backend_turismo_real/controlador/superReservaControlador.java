package com.turismo.backend_turismo_real.controlador;

import java.util.List;
import java.util.Optional;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import com.turismo.backend_turismo_real.modelo.superReserva;
import com.turismo.backend_turismo_real.service.superReservaServImple;

@RestController
@RequestMapping("/api/v1/")
@CrossOrigin(origins = "http://localhost:3000")
public class superReservaControlador {

	@Autowired
	private superReservaServImple servreserva;
	
	@GetMapping("/lista_reserva/{id}")
	public List<superReserva> reserva_cliente(@PathVariable Integer id){
		return servreserva.reserva_cliente(id);
	}

}
