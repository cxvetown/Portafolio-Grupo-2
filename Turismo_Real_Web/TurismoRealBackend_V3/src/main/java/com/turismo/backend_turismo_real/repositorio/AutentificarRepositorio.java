package com.turismo.backend_turismo_real.repositorio;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;

import com.turismo.backend_turismo_real.modelo.AutentificarCliente;

public interface AutentificarRepositorio extends JpaRepository<AutentificarCliente, Integer>{

	@Query(nativeQuery = true, value= "SELECT * FROM AUT_CLI WHERE CODE= :code")
	String AutCodigo(@Param("code") int code);
}
