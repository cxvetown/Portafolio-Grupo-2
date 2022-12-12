package com.turismo.backend_turismo_real.repositorio;


import java.util.Date;
import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.JpaSpecificationExecutor;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Repository;

import com.turismo.backend_turismo_real.modelo.Departamento;
import com.turismo.backend_turismo_real.modelo.superDepto;

@Repository
public interface DepartamentoRepositorio extends JpaRepository<Departamento, Integer>, JpaSpecificationExecutor<Departamento>{
	
	@Query(nativeQuery = true, value= "select id_dpto, nombre_dpto, tarifa_diaria, direccion, nro_dpto, capacidad, nombre_comuna, (select id_foto from fotografia_dpto ft where ft.id_dpto = dpto.id_dpto and rownum = 1) as foto from departamento dpto join comuna cmn on dpto.id_comuna = cmn.id_comuna where DISPONIBILIDAD <> 0")
	List<Departamento> QueryDepto();

	@Query(nativeQuery = true, value= "select REPLACE((select foto_path from fotografia_dpto ft where ft.id_dpto = dpto.id_dpto and rownum = 1),'\\', '\\\\') as foto from departamento dpto")
	String id_foto();
	
	@Query(nativeQuery = true, value= "SELECT * FROM DEPARTAMENTO WHERE DISPONIBILIDAD <> 0")
	List<Departamento> ObtenerDepto();
	
	@Query(nativeQuery = true, value= "SELECT ID_FOTO FROM FOTOGRAFIA_DPTO WHERE  ID_DPTO=:id_dpto")
	List<String> fotos_departamento(@Param("id_dpto") int id_dpto);
	
	//obtenemos la disponibilidad del departamento
	@Query(nativeQuery = true, value= "SELECT CAPACIDAD FROM DEPARTAMENTO WHERE id_dpto = :id_dpto")
	int traerCapacidad(@Param("id_dpto") int id_dpto);
	
	
	@Query(nativeQuery = true, value= "select id_dpto, nombre_dpto, tarifa_diaria, direccion, nro_dpto, capacidad, nombre_comuna, (select id_foto from fotografia_dpto ft where ft.id_dpto = dpto.id_dpto and rownum = 1) as foto from departamento dpto join comuna cmn on dpto.id_comuna = cmn.id_comuna where DISPONIBILIDAD <> 0 AND nombre_comuna = :nombre_comuna")
	List<Departamento> DeptoFiltro(@Param("nombre_comuna") String nombre_comuna);
	
	//query traer depto filtro
	@Query(nativeQuery = true, value="select id_dpto, nombre_dpto, tarifa_diaria, direccion, nro_dpto, capacidad,(select id_foto from fotografia_dpto ft where ft.id_dpto = dpto.id_dpto and rownum = 1) as foto from departamento dpto where DISPONIBILIDAD <> 0  AND ID_COMUNA =:id_comuna AND NOT EXISTS (SELECT ID_DPTO FROM RESERVA res WHERE ESTADO_RESERVA <> 'C' AND res.id_dpto=dpto.id_dpto AND (:check_in BETWEEN CHECK_IN AND CHECK_OUT OR :check_out BETWEEN CHECK_IN AND CHECK_OUT))")
	List<?>departamentoFiltrado(@Param("id_comuna") Integer id_comuna,@Param("check_in") Date check_in, @Param("check_out") Date check_out);
}
