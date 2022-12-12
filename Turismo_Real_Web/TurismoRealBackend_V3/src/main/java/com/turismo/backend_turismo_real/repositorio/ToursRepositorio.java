package com.turismo.backend_turismo_real.repositorio;

import java.util.Date;
import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.jpa.repository.query.Procedure;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;
import com.turismo.backend_turismo_real.modelo.Tours;

@Repository
public interface ToursRepositorio extends JpaRepository<Tours, Integer>{

	@Query(nativeQuery = true, value= "SELECT * FROM TOUR_PLAN TP WHERE ID_REGION = (SELECT ID_REGION FROM COMUNA WHERE ID_COMUNA = (SELECT ID_COMUNA FROM RESERVA RES JOIN DEPARTAMENTO USING (ID_DPTO) WHERE ID_RESERVA = :id_reserva) ) AND NOT EXISTS (SELECT ID_TOUR FROM TOUR_RESERVA TR WHERE ID_RESERVA = :id_reserva AND TR.ID_TOUR = TP.ID_TOUR)")
	List<Tours> traerTours(@Param("id_reserva") int id_reserva);
	
	@Procedure(name="agregar_tour")
	int agregar_tours(@Param("id_resv") int id_resv, @Param("id_Tour") int id_Tour,  @Param("id_fecha") Date id_fecha,  
			@Param("id_dpto") int id_dpto,  @Param("id_cli") int id_cli);
}
