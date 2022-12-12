package com.turismo.backend_turismo_real.modelo;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.NamedStoredProcedureQueries;
import javax.persistence.NamedStoredProcedureQuery;
import javax.persistence.ParameterMode;
import javax.persistence.StoredProcedureParameter;
import javax.persistence.Table;

@Entity

@NamedStoredProcedureQueries({
	@NamedStoredProcedureQuery(
			name = "agregar_tour",
			procedureName = "AGREGAR_TOUR_RES",
			parameters = {
				@StoredProcedureParameter(mode= ParameterMode.IN, name="id_resv", type=int.class),
				@StoredProcedureParameter(mode= ParameterMode.IN, name="id_Tour", type=int.class),
				@StoredProcedureParameter(mode= ParameterMode.IN, name="id_fecha", type=Date.class),
				@StoredProcedureParameter(mode= ParameterMode.IN, name="id_dpto", type=int.class),
				@StoredProcedureParameter(mode= ParameterMode.IN, name="id_cli", type=int.class),
				@StoredProcedureParameter(mode= ParameterMode.OUT, name="r", type=int.class)	
			}
	)
})

@Table(name = "tour_plan")
public class Tours {
	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	int id_tour;
	@Column(name = "nombre_tour")
	String nombre_tour;
	@Column(name = "desc_tour")
	String desc_tour;
	@Column(name = "valor_tour")
	int valor_tour;
	@Column(name = "id_region")
	int id_region;
	public int getId_tour() {
		return id_tour;
	}
	public void setId_tour(int id_tour) {
		this.id_tour = id_tour;
	}
	public String getNombre_tour() {
		return nombre_tour;
	}
	public void setNombre_tour(String nombre_tour) {
		this.nombre_tour = nombre_tour;
	}
	public String getDesc_tour() {
		return desc_tour;
	}
	public void setDesc_tour(String desc_tour) {
		this.desc_tour = desc_tour;
	}
	public int getValor_tour() {
		return valor_tour;
	}
	public void setValor_tour(int valor_tour) {
		this.valor_tour = valor_tour;
	}
	public int getId_region() {
		return id_region;
	}
	public void setId_region(int id_region) {
		this.id_region = id_region;
	}
	public Tours(int id_tour, String nombre_tour, String desc_tour, int valor_tour, int id_region) {
		super();
		this.id_tour = id_tour;
		this.nombre_tour = nombre_tour;
		this.desc_tour = desc_tour;
		this.valor_tour = valor_tour;
		this.id_region = id_region;
	}
	
	public Tours() {
		
	}
}
