package com.turismo.backend_turismo_real.service;

import java.util.List;

import com.turismo.backend_turismo_real.modelo.ServicioDepto;

public interface ServicioDeptoServicio {
	
	List<ServicioDepto> listarServicio(Integer id_dpto);
}
