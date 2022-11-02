package com.turismo.backend_turismo_real.repositorio;

import java.util.Date;
import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.jpa.repository.query.Procedure;
import org.springframework.data.repository.query.Param;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Repository;

import com.turismo.backend_turismo_real.modelo.Reserva;
import com.turismo.backend_turismo_real.modelo.superReserva;

@Repository
public interface ReservaRepositorio extends JpaRepository<Reserva, Integer>{

	
	@Procedure(name="add_reserva")
	int agregar_reserva(@Param("idDepto") int id_depto, @Param("idCli") int id_cli,
			@Param("estadoRes") String estado_reserva, @Param("estadoPag") String estado_pago, 
			@Param("checkIn") Date check_in,@Param("checkOut") Date check_out ,@Param("firmaRes") int firma_res,
			@Param("valorTotal") int valor_total, @Param("cant_acomp") int cantidad_acomp, @Param("transporte_reserva") String transporte);
	
	@Query(nativeQuery = true, value= "SELECT NOMBRE_DPTO, CHECK_IN, CHECK_OUT, ESTADO_PAGO, VALOR_TOTAL FROM RESERVA RES JOIN DEPARTAMENTO DPTO USING(ID_DPTO)")
	List<superReserva> reserva_cliente(@Param("id_cliente") Integer id_cliente);
	
	@Query(nativeQuery = true, value= "UPDATE reserva SET ESTADO_RESERVA = 'C' WHERE id_reserva = :id_reserva")
	int update_reserva(@Param("id_reserva") int id_reserva);
}
