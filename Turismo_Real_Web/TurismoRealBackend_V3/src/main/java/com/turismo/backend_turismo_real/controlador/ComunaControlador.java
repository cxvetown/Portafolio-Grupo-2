package com.turismo.backend_turismo_real.controlador;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import com.turismo.backend_turismo_real.modelo.Comuna;
import com.turismo.backend_turismo_real.service.ComunaServiceImplement;

@RestController
@RequestMapping("/api/v1/")
@CrossOrigin(origins = {"https://main.d3im8s8jx11qi.amplifyapp.com", "https://turismo-real-front-end.vercel.app/","http://localhost:3000"})
public class ComunaControlador {

	@Autowired
	private ComunaServiceImplement comunaServ;
	
	//obtenemos los datos de la comuna con su id
	@GetMapping("/comunaid/{id}")
	public ResponseEntity<Comuna> obtenerDeptoId(@PathVariable Integer id){
		return comunaServ.obtenerComunaId(id);
	}
	
	//obtenemos los datos de la comuna con su id
		@GetMapping("/comunas")
		public List<Comuna> todosComuna(){
			return comunaServ.todosComuna();
		}
}
