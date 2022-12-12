package com.turismo.backend_turismo_real.service;

import java.util.Date;

import org.springframework.http.ResponseEntity;

import com.turismo.backend_turismo_real.modelo.Reserva;
import com.turismo.backend_turismo_real.modelo.ServExtraReserva;
import com.turismo.backend_turismo_real.modelo.SuperServExtra;

public interface ReservaServicio {

	Reserva guardarReserva (Reserva reserva);
	
	int agregar_reserva (int id_depto, int id_cli, String estado_reserva, String estado_pago, Date check_in,
			Date check_out, int firma_res,int valor_total, int cantidad_acomp, String transporte);

	ResponseEntity<Reserva> actualizarReserva(Integer id_reserva);

	ResponseEntity<Reserva> actualizarEstadoPago(Integer id_reserva);
	
	ResponseEntity<Reserva> obtenerReserva(Integer id_reserva);
	
	int traerDpto(int id_reserva);

	ResponseEntity<Reserva> update_valor_total(int id_reserva, SuperServExtra sevExtra);
	
	ResponseEntity<Reserva> act_acompañantes(Integer id_reserva, Reserva reserva);
	
}
