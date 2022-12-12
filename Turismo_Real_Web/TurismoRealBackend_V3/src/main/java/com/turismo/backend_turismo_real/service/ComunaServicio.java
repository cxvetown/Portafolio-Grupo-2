package com.turismo.backend_turismo_real.service;

import java.util.List;

import org.springframework.http.ResponseEntity;

import com.turismo.backend_turismo_real.modelo.Comuna;


public interface ComunaServicio {

	public ResponseEntity<Comuna> obtenerComunaId(Integer id);
	
	public List<Comuna> todosComuna();
}
