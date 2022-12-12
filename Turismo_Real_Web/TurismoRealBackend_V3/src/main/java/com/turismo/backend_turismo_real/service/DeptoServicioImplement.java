package com.turismo.backend_turismo_real.service;

import java.util.Date;
import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Service;
import com.turismo.backend_turismo_real.modelo.Departamento;
import com.turismo.backend_turismo_real.modelo.superDepto;
import com.turismo.backend_turismo_real.repositorio.DepartamentoRepositorio;

@Service
public class DeptoServicioImplement implements DeptoServicio{
	@Autowired
	private DepartamentoRepositorio repodepto;
	
	@Override
	public List<Departamento> ObtenerDepto(){
		return repodepto.ObtenerDepto();
	}
	
	@Override
	public ResponseEntity<Departamento> obtenerDeptoId(Integer id){
		Departamento depto = repodepto.findById(id)
				.orElseThrow();
		return ResponseEntity.ok(depto);
	}
	
	@Override
	public List<Departamento> QueryDepto(){
		return repodepto.QueryDepto();
	}

	@Override
	public String id_foto() {
		return repodepto.id_foto();
	}

	@Override
	public List<String> fotos_departamento(int id_dpto) {
		return repodepto.fotos_departamento(id_dpto);
	}

	//llamamos al repositorio para hacer la consulta
	@Override
	public int traerCapacidad(int id_dpto) {
		return repodepto.traerCapacidad(id_dpto);
	}

	@Override
	public List<Departamento> DeptoFiltro(String nombre_comuna) {
		return repodepto.DeptoFiltro(nombre_comuna);
	}

	@Override
	public List<?> departamentoFiltrado(Integer id_comuna, Date check_in, Date check_out) {
		return repodepto.departamentoFiltrado(id_comuna, check_in, check_out);
	}
}