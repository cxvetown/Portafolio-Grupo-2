package com.turismo.backend_turismo_real.repositorio;

import java.util.Date;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.query.Procedure;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import com.turismo.backend_turismo_real.modelo.TourReserva;

@Repository
public interface TourReservaRepositorio extends JpaRepository<TourReserva, Integer>{
	
	@Procedure(name="add_tour")
	int tours_add(@Param("id_resv") int id_resv, @Param("id_Tour") int id_Tour,  @Param("id_fecha") Date id_fecha,  
			@Param("id_dpto") int id_dpto,  @Param("id_cli") int id_cli);
}
