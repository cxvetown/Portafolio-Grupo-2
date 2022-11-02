package com.turismo.backend_turismo_real.service;

import com.turismo.backend_turismo_real.modelo.AutentificarCliente;

public interface AutentificarServicio {
	
	AutentificarCliente guardarAutentificar(AutentificarCliente autCli);
	
	String AutCodigo(int code);
}
