package com.turismo.backend_turismo_real.modelo;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.Table;

@Entity
@Table(name = "servicio")
public class ServicioDepto {
	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	int id_servicio;
	@Column(name = "nombre_serv")
	String nombre_serv;
	@Column(name = "desc_serv")
	String desc_serv;
	public int getId_servicio() {
		return id_servicio;
	}
	public void setId_servicio(int id_servicio) {
		this.id_servicio = id_servicio;
	}
	public String getNombre_serv() {
		return nombre_serv;
	}
	public void setNombre_serv(String nombre_serv) {
		this.nombre_serv = nombre_serv;
	}
	public String getDesc_serv() {
		return desc_serv;
	}
	public void setDesc_serv(String desc_serv) {
		this.desc_serv = desc_serv;
	}
	public ServicioDepto(int id_servicio, String nombre_serv, String desc_serv) {
		super();
		this.id_servicio = id_servicio;
		this.nombre_serv = nombre_serv;
		this.desc_serv = desc_serv;
	}
	
	public ServicioDepto() {
		
	}
}
