package com.turismo.backend_turismo_real.repositorio;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Repository;

import com.turismo.backend_turismo_real.modelo.Reserva;
import com.turismo.backend_turismo_real.modelo.ServicioExtra;
import com.turismo.backend_turismo_real.modelo.SuperServExtra;

@Repository
public interface ServExtraRepositorio extends JpaRepository<ServicioExtra, Integer>{

	@Query(nativeQuery = true, value= "SELECT * FROM SERVICIO_EXTRA SEV WHERE NOT EXISTS (SELECT ID_RESERVA FROM reserva_servicios_extras RSV WHERE ID_RESERVA = :id_reserva AND sev.id_svc_ex = rsv.id_svc_ex)")
	List<ServicioExtra> todos_servicios(@Param("id_reserva") int id_reserva);
	
	@Query(nativeQuery = true, value= "update Reserva set valor_total = valor_total + valor_serv_ex where id_reserva = :id_reserva")
	ResponseEntity<ServicioExtra> update_valor_total(@Param("id_reserva") int id_reserva);
}
