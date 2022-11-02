package com.turismo.backend_turismo_real.service;

import java.util.List;

import org.springframework.http.ResponseEntity;

import com.turismo.backend_turismo_real.modelo.Departamento;
import com.turismo.backend_turismo_real.modelo.superDepto;

public interface DeptoServicio {

	List<Departamento> ObtenerDepto();

	public ResponseEntity<Departamento> obtenerDeptoId(Integer id);

	List<Departamento> QueryDepto();
	
	String id_foto();
	
}
