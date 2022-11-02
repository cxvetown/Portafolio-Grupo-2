package com.turismo.backend_turismo_real.controlador;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.DeleteMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.PutMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import com.turismo.backend_turismo_real.modelo.Reserva;
import com.turismo.backend_turismo_real.service.ReservaServImplement;

@RestController
@RequestMapping("/api/v1/")
@CrossOrigin(origins = "http://localhost:3000")
public class ReservaControlador {

	@Autowired
	private ReservaServImplement servReserva;
	
	@PostMapping("/guardarReserva")
	public Reserva guardarReserva(@RequestBody Reserva reserva) {
		return servReserva.guardarReserva(reserva);
	}
	
	@PostMapping("/reserva_pl")
	public int agregar_reserva(@RequestBody Reserva reserv) {
		return servReserva.agregar_reserva(reserv.getId_dpto(), reserv.getId_cliente(),
				reserv.getEstado_reserva(), reserv.getEstado_pago(), reserv.getCheck_in(), reserv.getCheck_out(),
				reserv.getFirma(), reserv.getValor_total(), reserv.getCantidad_acompañantes(), reserv.getTransporte());
	}
	
	
	@PostMapping("/updateReserva/{id_reserva}")
	public ResponseEntity<Reserva> actualizarReserva(@PathVariable Integer id_reserva){
		return servReserva.actualizarReserva(id_reserva);
	}
	
	@PostMapping("/updReserva/{id_reserva}")
	public int update_reserva(@PathVariable int id_reserva){
		return servReserva.update_reserva(id_reserva);
	}
	@DeleteMapping("/delete/")
	public void borrar_reserva(@PathVariable int id) {
		servReserva.borrar_reserva(id);
	}
}
