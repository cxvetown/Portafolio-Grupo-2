package com.turismo.backend_turismo_real.service;

import java.util.Date;
import java.util.List;

import org.springframework.http.ResponseEntity;

import com.turismo.backend_turismo_real.modelo.Departamento;
import com.turismo.backend_turismo_real.modelo.superDepto;

public interface DeptoServicio {

	List<Departamento> ObtenerDepto();

	public ResponseEntity<Departamento> obtenerDeptoId(Integer id);

	List<Departamento> QueryDepto();
	
	String id_foto();
	
	List<String>fotos_departamento(int id_dpto);
	
	//llamamos a la funcion del repositorio
	int traerCapacidad (int id_dpto);
	
	List<Departamento> DeptoFiltro(String nombre_comuna);
	
	List<?>departamentoFiltrado(Integer id_comuna, Date check_in, Date check_out);
}
