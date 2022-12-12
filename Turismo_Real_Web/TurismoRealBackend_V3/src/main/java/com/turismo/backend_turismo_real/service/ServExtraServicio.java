package com.turismo.backend_turismo_real.service;

import java.util.List;

import org.springframework.http.ResponseEntity;

import com.turismo.backend_turismo_real.modelo.Reserva;
import com.turismo.backend_turismo_real.modelo.ServicioExtra;


public interface ServExtraServicio {

	List<ServicioExtra> todos_servicios(int id_reserva);
}
