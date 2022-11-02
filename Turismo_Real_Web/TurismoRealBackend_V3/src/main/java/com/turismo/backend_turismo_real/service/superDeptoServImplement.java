package com.turismo.backend_turismo_real.service;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Service;

import com.turismo.backend_turismo_real.modelo.superDepto;
import com.turismo.backend_turismo_real.repositorio.superDeptoRepositorio;
@Service
public class superDeptoServImplement implements superDeptoServicio{

	@Autowired
	private superDeptoRepositorio repodepto;
	
	@Override
	public ResponseEntity<superDepto> obtenerDeptoId(Integer id){
		superDepto depto = repodepto.findById(id)
				.orElseThrow();
		return ResponseEntity.ok(depto);
	}

	@Override
	public ResponseEntity<superDepto> info_depto(Integer id) {
		return (ResponseEntity<superDepto>) repodepto.info_depto(id);
	}

}
