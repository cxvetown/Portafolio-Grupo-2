package com.turismo.backend_turismo_real.service;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.turismo.backend_turismo_real.modelo.ServicioExtra;
import com.turismo.backend_turismo_real.repositorio.ServExtraRepositorio;

@Service
public class ServExtraServicioImpl implements ServExtraServicio{
	
	@Autowired
	private ServExtraRepositorio servExtRepo;

	@Override
	public List<ServicioExtra> todos_servicios() {
		return servExtRepo.findAll();
	}
}
