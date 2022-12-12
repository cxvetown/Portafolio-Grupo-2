package com.turismo.backend_turismo_real.service;

import java.util.Date;

public interface TourReservaServicio {

	int tours_add( int id_reserva, int id_tour, Date fecha_tour, int id_dpto, int id_cliente);
}
