package com.turismo.backend_turismo_real.service;

import java.util.Date;
import java.util.List;

import org.springframework.http.ResponseEntity;

import com.turismo.backend_turismo_real.modelo.Tours;

public interface ToursServicio {
	List<Tours> traerTours(int id_reserva);
	
	int agregar_tours( int id_resv, int id_Tour, Date id_fecha, int id_dpto, int id_cli);
}
