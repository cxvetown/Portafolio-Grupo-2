package com.turismo.backend_turismo_real.modelo;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.Table;

@Entity
@Table(name = "Departamento")
public class Departamento {

	@Id
	@Column(name = "Id_Dpto")
	int IdDepto;
	@Column(name = "Tarifa_Diaria")
	int TarifaDiaria;
	@Column(name = "Direccion")
	String Direccion;
	@Column(name = "Nro_Dpto")
	int NroDepto;
	@Column(name = "Capacidad")
	int Capacidad;
	@Column(name= "nombre_comuna")
	String nombre_comuna;
	@Column(name = "foto")
	String foto_path;
	@Column(name = "nombre_dpto")
	String nombre_dpto;
	
	
	
	public String getNombre_dpto() {
		return nombre_dpto;
	}
	public void setNombre_dpto(String nombre_dpto) {
		this.nombre_dpto = nombre_dpto;
	}
	public String getNombre_comuna() {
		return nombre_comuna;
	}
	public void setNombre_comuna(String nombre_comuna) {
		this.nombre_comuna = nombre_comuna;
	}
	public String getFoto_path() {
		return foto_path;
	}
	public void setFoto_path(String foto_path) {
		this.foto_path = foto_path;
	}
	public int getIdDepto() {
		return IdDepto;
	}
	public void setIdDepto(int idDepto) {
		IdDepto = idDepto;
	}
	public int getTarifaDiaria() {
		return TarifaDiaria;
	}
	public void setTarifaDiaria(int tarifaDiaria) {
		TarifaDiaria = tarifaDiaria;
	}
	public String getDireccion() {
		return Direccion;
	}
	public void setDireccion(String direccion) {
		Direccion = direccion;
	}
	public int getNroDepto() {
		return NroDepto;
	}
	public void setNroDepto(int nroDepto) {
		NroDepto = nroDepto;
	}
	public int getCapacidad() {
		return Capacidad;
	}
	public void setCapacidad(int capacidad) {
		Capacidad = capacidad;
	}
	
	public Departamento(int idDepto, int tarifaDiaria, String direccion, int nroDepto, int capacidad,
			String nombre_comuna, String foto_path, String nombre_dpto) {
		super();
		IdDepto = idDepto;
		TarifaDiaria = tarifaDiaria;
		Direccion = direccion;
		NroDepto = nroDepto;
		Capacidad = capacidad;
		this.nombre_comuna = nombre_comuna;
		this.foto_path = foto_path;
		this.nombre_dpto = nombre_dpto;
	}
	
	public Departamento() {
		
	}
	
}
