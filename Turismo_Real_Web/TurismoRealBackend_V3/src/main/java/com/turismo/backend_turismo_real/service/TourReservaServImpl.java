package com.turismo.backend_turismo_real.service;

import java.util.Date;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.turismo.backend_turismo_real.repositorio.TourReservaRepositorio;

@Service
public class TourReservaServImpl implements TourReservaServicio{

	@Autowired
	private TourReservaRepositorio repotour;
	
	@Override
	public int tours_add( int id_reserva,  int id_tour, Date fecha_tour, int id_dpto, int id_cliente) {
		return repotour.tours_add(id_reserva, id_tour, fecha_tour, id_dpto, id_cliente);
	}
	
}
