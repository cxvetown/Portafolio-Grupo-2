package com.turismo.backend_turismo_real.repositorio;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Repository;

import com.turismo.backend_turismo_real.modelo.Cliente;
import com.turismo.backend_turismo_real.modelo.Reserva;
import com.turismo.backend_turismo_real.modelo.superReserva;

@Repository
public interface superReservaRepositorio extends JpaRepository<superReserva, Integer>{

	@Query(nativeQuery = true, value= "SELECT VALOR_TOTAL, id_reserva, nombre_dpto, check_in, check_out, estado_pago, valor_total FROM RESERVA RES JOIN DEPARTAMENTO DPTO ON (RES.ID_DPTO = DPTO.ID_DPTO) WHERE ID_CLIENTE =:id_cliente AND ESTADO_RESERVA = 'I' OR ESTADO_RESERVA ='T'")
	List<superReserva> reserva_cliente(@Param("id_cliente") Integer id);
	
	@Query(nativeQuery = true, value= "SELECT * FROM RESERVA WHERE ID_CLIENTE= :id_cliente")
	List<superReserva> allReserva(@Param("id_cliente") Integer id);
}
