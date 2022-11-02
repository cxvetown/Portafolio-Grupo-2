package com.turismo.backend_turismo_real.repositorio;


import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.JpaSpecificationExecutor;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
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
}
