package com.turismo.backend_turismo_real.service;

import org.springframework.http.ResponseEntity;

import com.turismo.backend_turismo_real.modelo.ServExtraReserva;

public interface ServExtraReservaService {
	
	public ServExtraReserva agregar_serv_extra(ServExtraReserva servExtra);
	
	int add_serv_ext(int id_reserva, int id_svc, int id_dpto, int id_cliente);
}
