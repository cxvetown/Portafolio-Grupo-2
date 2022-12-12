package com.turismo.backend_turismo_real.controlador;

import java.time.LocalDateTime;
import java.util.Date;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.DeleteMapping;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.PutMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import com.turismo.backend_turismo_real.modelo.Reserva;
import com.turismo.backend_turismo_real.modelo.ServExtraReserva;
import com.turismo.backend_turismo_real.modelo.SuperServExtra;
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
		Date d = new Date(reserv.getCheck_in().getTime() + 86400000);
		Date d1 = new Date(reserv.getCheck_out().getTime() + 86400000);
		System.out.println("a1" + reserv.getCheck_in());
		System.out.println("a2:" + d);
		return servReserva.agregar_reserva(reserv.getId_dpto(), reserv.getId_cliente(),
				reserv.getEstado_reserva(), reserv.getEstado_pago(), d, d1,
				reserv.getFirma(), reserv.getValor_total(), reserv.getCantidad_acompañantes(), reserv.getTransporte());
	}
	
	
	@PostMapping("/updateReserva/{id_reserva}")
	public ResponseEntity<Reserva> actualizarReserva(@PathVariable Integer id_reserva){
		return servReserva.actualizarReserva(id_reserva);
	}
	@PostMapping("/ActualizarPago/{id_reserva}")
	public ResponseEntity<Reserva> actualizarEstadoPago(@PathVariable Integer id_reserva){
		return servReserva.actualizarEstadoPago(id_reserva);
	}

	@GetMapping("/obtenerReserva/{id_reserva}")
	public ResponseEntity<Reserva> obtenerReserva(@PathVariable Integer id_reserva) {
		return servReserva.obtenerReserva(id_reserva);
	}
	
	@GetMapping("/traerDpto/{id_reserva}")
	public int traerDpto(@PathVariable int id_reserva) {
		return servReserva.traerDpto(id_reserva);
	}
	
	@PostMapping("/actualizarValor/{id_reserva}")
	public ResponseEntity<Reserva> update_valor_total(@PathVariable Integer id_reserva, @RequestBody SuperServExtra sevExt){
		return servReserva.update_valor_total(id_reserva, sevExt);
	}
	
	//cantidad acompañantes funcionando
	@PostMapping("/act_acompañantes/{id_reserva}")
	public ResponseEntity<Reserva> act_acompañantes(@PathVariable Integer id_reserva, @RequestBody Reserva reserva){
		return servReserva.act_acompañantes(id_reserva, reserva);
	}
}
