package com.turismo.backend_turismo_real.modelo;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.Table;

@Entity
@Table(name = "Servicio_extra")
public class ServicioExtra {
	
	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	int id_svc_ex;
	@Column(name = "nombre_serv_ex")
	String nombre_serv_ex;
	@Column(name = "desc_serv_ex")
	String desc_serv_ex;
	@Column(name = "valor_serv_ex")
	int valor_serv_ex;
	public int getId_svc_ex() {
		return id_svc_ex;
	}
	public void setId_svc_ex(int id_svc_ex) {
		this.id_svc_ex = id_svc_ex;
	}
	public String getNombre_serv_ex() {
		return nombre_serv_ex;
	}
	public void setNombre_serv_ex(String nombre_serv_ex) {
		this.nombre_serv_ex = nombre_serv_ex;
	}
	public String getDesc_serv_ex() {
		return desc_serv_ex;
	}
	public void setDesc_serv_ex(String desc_serv_ex) {
		this.desc_serv_ex = desc_serv_ex;
	}
	public int getValor_serv_ex() {
		return valor_serv_ex;
	}
	public void setValor_serv_ex(int valor_serv_ex) {
		this.valor_serv_ex = valor_serv_ex;
	}
	public ServicioExtra(int id_svc_ex, String nombre_serv_ex, String desc_serv_ex, int valor_serv_ex) {
		super();
		this.id_svc_ex = id_svc_ex;
		this.nombre_serv_ex = nombre_serv_ex;
		this.desc_serv_ex = desc_serv_ex;
		this.valor_serv_ex = valor_serv_ex;
	}
	
	public ServicioExtra() {
		
	}
	
}
