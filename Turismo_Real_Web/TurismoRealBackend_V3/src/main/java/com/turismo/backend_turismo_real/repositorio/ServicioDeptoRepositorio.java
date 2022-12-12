package com.turismo.backend_turismo_real.repositorio;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import com.turismo.backend_turismo_real.modelo.ServicioDepto;

@Repository
public interface ServicioDeptoRepositorio extends JpaRepository<ServicioDepto, Integer>{
	
	@Query(nativeQuery = true, value="SELECT SER.ID_SERVICIO, NOMBRE_SERV, DESC_SERV FROM SERVICIO SER JOIN SERVICIO_DPTO SERD ON (SER.ID_SERVICIO = SERD.ID_SERVICIO) WHERE SERD.ESTADO_SERVICIO <> 0 AND SERD.ID_DPTO = :id_dpto")
	List<ServicioDepto> listarServicio(@Param("id_dpto") Integer id_dpto);
}
