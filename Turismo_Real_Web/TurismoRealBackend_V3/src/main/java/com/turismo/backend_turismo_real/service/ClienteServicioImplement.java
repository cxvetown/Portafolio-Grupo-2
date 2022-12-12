package com.turismo.backend_turismo_real.service;

import java.util.List;
import java.util.Optional;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Service;

import com.turismo.backend_turismo_real.modelo.Cliente;
import com.turismo.backend_turismo_real.modelo.Comuna;
import com.turismo.backend_turismo_real.modelo.Supercliente;
import com.turismo.backend_turismo_real.repositorio.ClienteRepositorio;

@Service
public class ClienteServicioImplement implements ClienteServicio{
	@Autowired
	private ClienteRepositorio repo;
	
	@Override
	public int registrarse(String email_c, String pass, int fono, String rut, String nombre, String apellido){
		//llamamos al procedure del repositorio
		return repo.registrarse(email_c, pass, fono, rut, nombre, apellido);
	}
	
	@Override
	public int login(String email_aut, String psw_aut) {
		return repo.login(email_aut, psw_aut);
	}

	@Override
	public String loginConfirmed(int id) {
		return repo.loginConfirmed(id);
	}

	@Override
	public String comprobarCorreo(String email) {
		return repo.comprobarCorreo(email);
	}

	@Override
	public String comprobarRut(String rut) {
		
		return repo.comprobarRut(rut);
	}
	
}
