package com.turismo.backend_turismo_real.service;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.turismo.backend_turismo_real.modelo.ServicioDepto;
import com.turismo.backend_turismo_real.repositorio.ServicioDeptoRepositorio;

@Service
public class ServicioDeptoServImpl implements ServicioDeptoServicio{

	@Autowired
	private ServicioDeptoRepositorio repoServicio;
	
	@Override
	public List<ServicioDepto> listarServicio(Integer id_dpto) {
		return repoServicio.listarServicio(id_dpto);
	}

}
