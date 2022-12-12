package com.turismo.backend_turismo_real.modelo;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.NamedStoredProcedureQueries;
import javax.persistence.NamedStoredProcedureQuery;
import javax.persistence.ParameterMode;
import javax.persistence.StoredProcedureParameter;
import javax.persistence.Table;

@Entity

@NamedStoredProcedureQueries({
	@NamedStoredProcedureQuery(
			name = "add_tour",
			procedureName = "AGREGAR_TOUR_RES",
			parameters = {
				@StoredProcedureParameter(mode= ParameterMode.IN, name="id_Tour", type=int.class),
				@StoredProcedureParameter(mode= ParameterMode.IN, name="id_resv", type=int.class),
				@StoredProcedureParameter(mode= ParameterMode.IN, name="id_fecha", type=Date.class),
				@StoredProcedureParameter(mode= ParameterMode.IN, name="id_dpto", type=int.class),
				@StoredProcedureParameter(mode= ParameterMode.IN, name="id_cli", type=int.class),
				@StoredProcedureParameter(mode= ParameterMode.OUT, name="r", type=int.class)	
			}
	)
})

@Table(name = "tour_reserva")
public class TourReserva {
	@Id
	@Column(name = "id_tour")
	int id_tour;
	@Column(name = "id_reserva")
	int id_reserva;
	@Column(name = "fecha_tour")
	Date fecha_tour;
	@Column(name = "id_dpto")
	int id_dpto;
	@Column(name = "id_cliente")
	int id_cliente;
	public int getId_tour() {
		return id_tour;
	}
	public void setId_tour(int id_tour) {
		this.id_tour = id_tour;
	}
	public int getId_reserva() {
		return id_reserva;
	}
	public void setId_reserva(int id_reserva) {
		this.id_reserva = id_reserva;
	}
	public Date getFecha_tour() {
		return fecha_tour;
	}
	public void setFecha_tour(Date fecha_tour) {
		this.fecha_tour = fecha_tour;
	}
	public int getId_dpto() {
		return id_dpto;
	}
	public void setId_dpto(int id_dpto) {
		this.id_dpto = id_dpto;
	}
	public int getId_cliente() {
		return id_cliente;
	}
	public void setId_cliente(int id_cliente) {
		this.id_cliente = id_cliente;
	}
	public TourReserva(int id_tour, int id_reserva, Date fecha_tour, int id_dpto, int id_cliente) {
		super();
		this.id_tour = id_tour;
		this.id_reserva = id_reserva;
		this.fecha_tour = fecha_tour;
		this.id_dpto = id_dpto;
		this.id_cliente = id_cliente;
	}
	
	public TourReserva() {
		
	}
}
