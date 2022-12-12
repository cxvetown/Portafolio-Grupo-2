package com.turismo.backend_turismo_real.repositorio;

import java.util.Date;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.jpa.repository.query.Procedure;
import org.springframework.data.repository.query.Param;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Repository;

import com.turismo.backend_turismo_real.modelo.ServExtraReserva;
import com.turismo.backend_turismo_real.modelo.ServicioExtra;

@Repository
public interface ServExtraReservaRepositorio extends JpaRepository<ServExtraReserva, Integer>{
	
	@Procedure(name="add_serv_ex")
	int add_serv_ext(@Param("ID_RESERVA") int id_reserva, @Param("ID_SVC") int id_svc,
			@Param("DPTO") int id_dpto, @Param("CLIENTE") int id_cliente);
}
