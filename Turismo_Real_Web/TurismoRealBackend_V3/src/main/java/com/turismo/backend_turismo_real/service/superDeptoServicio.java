package com.turismo.backend_turismo_real.service;

import java.util.List;

import org.springframework.http.ResponseEntity;

import com.turismo.backend_turismo_real.modelo.superDepto;

public interface superDeptoServicio {

	public ResponseEntity<superDepto> obtenerDeptoId(Integer id);

	public ResponseEntity<superDepto> info_depto (Integer id);
}
