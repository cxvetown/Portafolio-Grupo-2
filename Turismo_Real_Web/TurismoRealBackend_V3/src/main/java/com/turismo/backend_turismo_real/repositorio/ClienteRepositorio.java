package com.turismo.backend_turismo_real.repositorio;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.jpa.repository.query.Procedure;
import org.springframework.data.repository.query.Param;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Repository;

import com.turismo.backend_turismo_real.modelo.Cliente;

@Repository
public interface ClienteRepositorio extends JpaRepository<Cliente, Integer>{
	
	@Procedure(name="crear_usuario")
	int registrarse(@Param("email_c") String email_c, @Param("pass") String pass,
			@Param("fono") int fono, @Param("rut") String rut, @Param("nombre") String nombre,
			@Param("apellido") String apellido);


	@Procedure(name="iniciar_sesion")
	int login(@Param("email_aut") String email_aut, @Param("psw_aut") String psw_aut);
	
	@Query(nativeQuery = true, value= "SELECT EMAIL FROM USUARIO WHERE id_cliente= :id")
	String loginConfirmed(@Param("id") int id);
	
	@Query(nativeQuery = true, value= "SELECT email FROM USUARIO WHERE email = :email")
	String comprobarCorreo(@Param("email") String email);
	
	@Query(nativeQuery = true, value= "SELECT rut_cliente FROM CLIENTE WHERE rut_cliente = :rut")
	String comprobarRut(@Param("rut") String rut);
}
