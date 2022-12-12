package com.turismo.backend_turismo_real.controlador;

import java.text.DateFormat;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import com.fasterxml.jackson.core.JsonProcessingException;
import com.fasterxml.jackson.databind.JsonMappingException;
import com.fasterxml.jackson.databind.JsonNode;
import com.fasterxml.jackson.databind.ObjectMapper;
import com.turismo.backend_turismo_real.modelo.AutentificarCliente;
import com.turismo.backend_turismo_real.modelo.Departamento;
import com.turismo.backend_turismo_real.modelo.superDepto;
import com.turismo.backend_turismo_real.service.DeptoServicioImplement;

@RestController
@RequestMapping("/api/v1/")
@CrossOrigin(origins = {"https://main.d3im8s8jx11qi.amplifyapp.com", "https://turismo-real-front-end.vercel.app/","http://localhost:3000"})
public class DepartamentoControlador {
	
	@Autowired
	private DeptoServicioImplement deptoServ;

	//revisar
	@GetMapping("/deptosList")
	public List<Departamento> ObtenerDepto() {
		return deptoServ.ObtenerDepto();
	}
	//revisar
	@GetMapping("/depto/{id}")
	public ResponseEntity<Departamento> obtenerDeptoId(@PathVariable Integer id){
		return deptoServ.obtenerDeptoId(id);
	}
	
	//trae la informacion de todos los departamentos
	@GetMapping("/listadoDepto")
	public List<Departamento> QueryDepto(){
		return deptoServ.QueryDepto();
	}
	
	//trae la informacion de todos los departamentos
		@GetMapping("/DeptoFiltrado/{nombre_comuna}")
		public List<Departamento> DeptoFiltro(@PathVariable String nombre_comuna){
			return deptoServ.DeptoFiltro(nombre_comuna);
		}
	
	//
	@GetMapping("/id_foto")
	public String id_foto(){
		return deptoServ.id_foto();
	}
	
	//Trae una lista con todas las fotos del departamento en especifico
	@GetMapping("/fotosDepartamento/{id_dpto}")
	public List<String> fotos_departamento(@PathVariable int id_dpto){
		return deptoServ.fotos_departamento(id_dpto);
	}
	
	//traemos la capacidad del departamento
	@GetMapping("/capacidad/{id_dpto}")
	public int traerCapacidad (@PathVariable int id_dpto){
		return deptoServ.traerCapacidad(id_dpto);
	}
	//departamento filtrado
	private final ObjectMapper mapper = new ObjectMapper();
	@PostMapping("/deptoFiltrados")
	public List<?> departamentoFiltrado(@RequestBody String body) throws ParseException{
		//return deptoServ.departamentoFiltrado(id_comuna, check_in, check_out);
		JsonNode node = null;
		try {
			node = mapper.readTree(body);
		} catch (JsonMappingException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		} catch (JsonProcessingException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		String id_comuna_final = node.findValue("id_comuna").toString().replace("\"", "");
		String check_in = node.findValue("check_in").toString().replace("\"", "");
		String check_out = node.findValue("check_out").toString().replace("\"", "");
		Date format_in = new SimpleDateFormat("yyyy-MM-dd").parse(check_in);
		Date format_out = new SimpleDateFormat("yyyy-MM-dd").parse(check_out);
		return deptoServ.departamentoFiltrado(Integer.parseInt(id_comuna_final), format_in, format_out);
	}
}
