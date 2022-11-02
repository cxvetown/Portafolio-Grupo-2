package com.turismo.backend_turismo_real.service;

import java.util.Date;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Service;

import com.turismo.backend_turismo_real.modelo.Reserva;
import com.turismo.backend_turismo_real.repositorio.ReservaRepositorio;

@Service
public class ReservaServImplement implements ReservaServicio{

	@Autowired
	private ReservaRepositorio reporeserva;
	
	@Override
	public Reserva guardarReserva(Reserva reserva) {
		return reporeserva.save(reserva);
	}

	@Override
	public int agregar_reserva(int id_depto, int id_cli, String estado_reserva, String estado_pago, Date check_in,
			Date check_out, int firma_res, int valor_total, int cantidad_acomp, String transporte) {
		return reporeserva.agregar_reserva(id_depto, id_cli, estado_reserva, estado_pago,
				check_in, check_out, firma_res, valor_total, cantidad_acomp, transporte);
	}

	@Override
	public ResponseEntity<Reserva> actualizarReserva(Integer id_reserva){
		Reserva reservaAct = reporeserva.findById(id_reserva).orElse(null);
		reservaAct.setEstado_reserva("C");
		reporeserva.save(reservaAct);
		return ResponseEntity.ok(reservaAct);
	}

	@Override
	public int update_reserva(int id_reserva) {
		reporeserva.update_reserva(id_reserva);
		return 1;
	}

	@Override
	public void borrar_reserva(int id) {
		reporeserva.deleteById(id);
	}

}
