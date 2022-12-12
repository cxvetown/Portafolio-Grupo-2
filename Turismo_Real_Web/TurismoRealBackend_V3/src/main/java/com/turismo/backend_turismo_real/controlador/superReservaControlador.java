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
		List<superReserva> res = servreserva.reserva_cliente(id);
		for(int i=0; i<res.size(); i++) {
			System.out.println(res.get(i).getId_reserva());
			System.out.println(res.get(i).getCheck_in());
			System.out.println(res.get(i).getCheck_out());
		}
		return servreserva.reserva_cliente(id);
	}

}
