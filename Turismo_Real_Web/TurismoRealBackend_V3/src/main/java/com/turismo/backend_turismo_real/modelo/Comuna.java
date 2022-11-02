package com.turismo.backend_turismo_real.modelo;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.Table;

@Entity
@Table (name = "Comuna")
public class Comuna {
	@Id
	@Column(name = "id_comuna")
	int id_comuna;
	@Column(name = "nombre_comuna")
	String nombre_comuna;
	@Column(name = "id_region")
	int id_region;
	public int getId_comuna() {
		return id_comuna;
	}
	public void setId_comuna(int id_comuna) {
		this.id_comuna = id_comuna;
	}
	public String getNombre_comuna() {
		return nombre_comuna;
	}
	public void setNombre_comuna(String nombre_comuna) {
		this.nombre_comuna = nombre_comuna;
	}
	public int getId_region() {
		return id_region;
	}
	public void setId_region(int id_region) {
		this.id_region = id_region;
	}
	public Comuna(int id_comuna, String nombre_comuna, int id_region) {
		super();
		this.id_comuna = id_comuna;
		this.nombre_comuna = nombre_comuna;
		this.id_region = id_region;
	}
	
	public Comuna() {
		
	}
}
