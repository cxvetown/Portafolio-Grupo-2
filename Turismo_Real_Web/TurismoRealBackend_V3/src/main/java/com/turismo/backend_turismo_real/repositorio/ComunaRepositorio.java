package com.turismo.backend_turismo_real.repositorio;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.stereotype.Repository;

import com.turismo.backend_turismo_real.modelo.Comuna;

@Repository
public interface ComunaRepositorio extends JpaRepository<Comuna, Integer>{
	@Query(nativeQuery = true, value= "SELECT nombre_comuna FROM comuna")
	public List<Comuna> todosComuna();
}
