package com.turismo.backend_turismo_real.service;

import java.util.Date;
import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Service;

import com.turismo.backend_turismo_real.modelo.Tours;
import com.turismo.backend_turismo_real.repositorio.ToursRepositorio;

@Service
public class ToursServiceImple implements ToursServicio{

	@Autowired
	private ToursRepositorio repotour;
	
	@Override
	public List<Tours> traerTours(int id_reserva) {
		return repotour.traerTours(id_reserva);
	}

	@Override
	public int agregar_tours(int id_resv, int id_Tour,  Date id_fecha, int id_dpto, int id_cli) {
		return repotour.agregar_tours( id_resv, id_Tour, id_fecha, id_dpto, id_cli);
	}

}
