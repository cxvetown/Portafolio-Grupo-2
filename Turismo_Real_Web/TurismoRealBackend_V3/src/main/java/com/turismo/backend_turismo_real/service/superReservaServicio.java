package com.turismo.backend_turismo_real.service;

import java.util.List;
import java.util.Optional;

import org.springframework.http.ResponseEntity;

import com.turismo.backend_turismo_real.modelo.superReserva;

public interface superReservaServicio {
	
	List<superReserva> reserva_cliente(Integer id);
	
	List<superReserva> allReserva(Integer id);
	
}
