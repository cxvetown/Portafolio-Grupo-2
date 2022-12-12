package com.turismo.backend_turismo_real.modelo;

import java.util.Date;

public class superTour {
	int id_reserva;
	int id_tour;
	Date fecha_tour;
	int id_dpto;
	int id_cliente;
	public int getId_reserva() {
		return id_reserva;
	}
	public void setId_reserva(int id_reserva) {
		this.id_reserva = id_reserva;
	}
	public int getId_tour() {
		return id_tour;
	}
	public void setId_tour(int id_tour) {
		this.id_tour = id_tour;
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
	public superTour(int id_reserva, int id_tour, Date fecha_tour, int id_dpto, int id_cliente) {
		super();
		this.id_reserva = id_reserva;
		this.id_tour = id_tour;
		this.fecha_tour = fecha_tour;
		this.id_dpto = id_dpto;
		this.id_cliente = id_cliente;
	}
	
	public superTour() {
		
	}
}
