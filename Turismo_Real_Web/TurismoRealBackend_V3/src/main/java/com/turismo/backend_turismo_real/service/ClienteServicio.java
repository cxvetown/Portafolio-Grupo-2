package com.turismo.backend_turismo_real.service;

public interface ClienteServicio {
	
	int registrarse(String email_c, String pass, int fono, String rut, String nombre, String apellido);
	
	int login(String email_aut, String psw_aut);

	String loginConfirmed(int id);
	

}
