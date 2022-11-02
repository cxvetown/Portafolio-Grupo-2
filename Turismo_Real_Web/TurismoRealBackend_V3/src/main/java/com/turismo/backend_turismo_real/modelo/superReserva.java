package com.turismo.backend_turismo_real.modelo;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.Table;

@Entity
@Table(name = "Reserva")
public class superReserva {
	
	@Id
	int id_reserva;
	@Column(name = "valor_total")
	int valor_total;
	@Column(name = "nombre_dpto")
	String nombre_dpto;
	@Column(name = "check_in")
	Date check_in;
	@Column(name = "check_out")
	Date check_out;
	@Column(name = "estado_pago")
	String estado_pago;

	
	
	public String getEstado_pago() {
		return estado_pago;
	}
	public void setEstado_pago(String estado_pago) {
		this.estado_pago = estado_pago;
	}
	public Date getCheck_out() {
		return check_out;
	}
	public void setCheck_out(Date check_out) {
		this.check_out = check_out;
	}
	public Date getCheck_in() {
		return check_in;
	}
	public void setCheck_in(Date check_in) {
		this.check_in = check_in;
	}
	public String getNombre_dpto() {
		return nombre_dpto;
	}
	public void setNombre_dpto(String nombre_dpto) {
		this.nombre_dpto = nombre_dpto;
	}
	public int getId_reserva() {
		return id_reserva;
	}
	public void setId_reserva(int id_reserva) {
		this.id_reserva = id_reserva;
	}
	public int getValor_total() {
		return valor_total;
	}
	public void setValor_total(int valor_total) {
		this.valor_total = valor_total;
	}

	
	public superReserva(int id_reserva, int valor_total, String nombre_dpto, Date check_in, Date check_out,
			String estado_pago) {
		super();
		this.id_reserva = id_reserva;
		this.valor_total = valor_total;
		this.nombre_dpto = nombre_dpto;
		this.check_in = check_in;
		this.check_out = check_out;
		this.estado_pago = estado_pago;
	}
	public superReserva() {}
}
