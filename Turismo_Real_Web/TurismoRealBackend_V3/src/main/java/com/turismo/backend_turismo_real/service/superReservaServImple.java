package com.turismo.backend_turismo_real.service;

import java.util.List;
import java.util.Optional;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Service;


import com.turismo.backend_turismo_real.modelo.superReserva;
import com.turismo.backend_turismo_real.repositorio.superReservaRepositorio;
@Service
public class superReservaServImple implements superReservaServicio{

	@Autowired
	private superReservaRepositorio reporeserva;
	
	@Override
	public List<superReserva> reserva_cliente (Integer id){
		return reporeserva.reserva_cliente(id);

	}

	@Override
	public List<superReserva> allReserva(Integer id) {
		return reporeserva.allReserva(id);
	}

}
