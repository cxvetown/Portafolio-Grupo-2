package com.turismo.backend_turismo_real.service;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Service;

import com.turismo.backend_turismo_real.modelo.Comuna;
import com.turismo.backend_turismo_real.repositorio.ComunaRepositorio;

@Service
public class ComunaServiceImplement implements ComunaServicio{
	
	@Autowired
	private ComunaRepositorio comunaRepo;

	@Override
	public ResponseEntity<Comuna> obtenerComunaId(Integer id) {
		Comuna comuna = comunaRepo.findById(id)
				.orElseThrow();
		return ResponseEntity.ok(comuna);
	}
	
	
}
