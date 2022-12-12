package com.turismo.backend_turismo_real.service;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Service;

import com.turismo.backend_turismo_real.modelo.ServExtraReserva;
import com.turismo.backend_turismo_real.repositorio.ServExtraReservaRepositorio;

@Service
public class ServExtraReservaServImpl implements ServExtraReservaService{
	
	@Autowired
	private ServExtraReservaRepositorio repoServExtra;

	@Override
	public ServExtraReserva agregar_serv_extra(ServExtraReserva servExtra) {
		return repoServExtra.save(servExtra);
	}

	@Override
	public int add_serv_ext(int id_reserva, int id_svc, int id_dpto, int id_cliente) {
		return repoServExtra.add_serv_ext(id_reserva, id_svc, id_dpto, id_cliente);
	}


}
