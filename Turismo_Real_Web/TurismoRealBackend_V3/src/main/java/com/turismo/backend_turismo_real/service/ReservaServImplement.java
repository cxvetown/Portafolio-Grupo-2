package com.turismo.backend_turismo_real.service;

import java.util.Date;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Service;

import com.turismo.backend_turismo_real.modelo.Departamento;
import com.turismo.backend_turismo_real.modelo.Reserva;
import com.turismo.backend_turismo_real.modelo.ServExtraReserva;
import com.turismo.backend_turismo_real.modelo.ServicioExtra;
import com.turismo.backend_turismo_real.modelo.SuperServExtra;
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
	public ResponseEntity<Reserva> actualizarEstadoPago(Integer id_reserva){
		Reserva reservaAct = reporeserva.findById(id_reserva).orElse(null);
		reservaAct.setEstado_pago("A");
		reporeserva.save(reservaAct);
		return ResponseEntity.ok(reservaAct);
	}

	@Override
	public ResponseEntity<Reserva> obtenerReserva(Integer id_reserva){
		Reserva rsv = reporeserva.findById(id_reserva)
				.orElseThrow();
		return ResponseEntity.ok(rsv);
	}

	@Override
	public int traerDpto(int id_reserva) {
		return reporeserva.traerDpto(id_reserva);
	}

	@Override
	public ResponseEntity<Reserva> update_valor_total(int id_reserva, SuperServExtra sevExtra) {
		Reserva servR = reporeserva.findById(id_reserva).orElse(null);
		servR.setValor_total(servR.getValor_total()+sevExtra.getValor_serv_ex());
		reporeserva.save(servR);
		return ResponseEntity.ok(servR);
	}

	@Override
	public ResponseEntity<Reserva> act_acompañantes(Integer id_reserva, Reserva reserva) {
		Reserva reservaAct = reporeserva.findById(id_reserva).orElse(null);
		reservaAct.setCantidad_acompañantes(reserva.getCantidad_acompañantes());
		reporeserva.save(reservaAct);
		return ResponseEntity.ok(reservaAct);
	}


}
