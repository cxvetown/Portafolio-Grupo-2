package com.turismo.backend_turismo_real.service;

import java.util.Date;

import org.springframework.http.ResponseEntity;

import com.turismo.backend_turismo_real.modelo.Reserva;

public interface ReservaServicio {

	Reserva guardarReserva (Reserva reserva);
	
	int agregar_reserva (int id_depto, int id_cli, String estado_reserva, String estado_pago, Date check_in,
			Date check_out, int firma_res,int valor_total, int cantidad_acomp, String transporte);

	ResponseEntity<Reserva> actualizarReserva(Integer id_reserva);
	
	int update_reserva(int id_reserva);
	
	void borrar_reserva(int id);
}
