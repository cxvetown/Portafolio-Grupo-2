package com.turismo.backend_turismo_real.repositorio;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Repository;

import com.turismo.backend_turismo_real.modelo.superDepto;

@Repository
public interface superDeptoRepositorio extends JpaRepository<superDepto, Integer>{

	@Query(nativeQuery = true, value = "SELECT * FROM DEPARTAMENTO WHERE ID_DPTO = :id_dpto")
	ResponseEntity<superDepto> info_depto(@Param("id_dpto") int id);
}
