package com.turismo.backend_turismo_real.modelo;

import java.io.Serializable;
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

@NamedStoredProcedureQueries({
	@NamedStoredProcedureQuery(
			name = "add_reserva",
			procedureName = "AGREGAR_RESERVA",
			parameters = {
				@StoredProcedureParameter(mode= ParameterMode.IN, name="idDepto", type=int.class),
				@StoredProcedureParameter(mode= ParameterMode.IN, name="idCli", type=int.class),
				@StoredProcedureParameter(mode= ParameterMode.IN, name="estadoRes", type=String.class),
				@StoredProcedureParameter(mode= ParameterMode.IN, name="estadoPag", type=String.class),
				@StoredProcedureParameter(mode= ParameterMode.IN, name="checkIn", type=Date.class),
				@StoredProcedureParameter(mode= ParameterMode.IN, name="checkOut", type=Date.class),
				@StoredProcedureParameter(mode= ParameterMode.IN, name="firmaRes", type=int.class),
				@StoredProcedureParameter(mode= ParameterMode.IN, name="valorTotal", type=int.class),
				@StoredProcedureParameter(mode= ParameterMode.IN, name="cant_acomp", type=int.class),
				@StoredProcedureParameter(mode= ParameterMode.IN, name="transporte_reserva", type=String.class),
				@StoredProcedureParameter(mode= ParameterMode.OUT, name="R", type=int.class)	
			})
	})

@Entity
@Table(name = "Reserva")
public class Reserva implements Serializable{
	
	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	int id_reserva;
	@Column(name = "id_dpto")
	int id_dpto;
	@Column(name = "id_cliente")
	int id_cliente;
	@Column(name = "estado_reserva")
	String estado_reserva;
	@Column(name = "estado_pago")
	String estado_pago;
	@Column(name = "check_in")
	Date check_in;
	@Column(name = "check_out")
	Date check_out;
	@Column(name = "firma")
	int firma;
	@Column(name = "valor_total")
	int valor_total;
	@Column(name = "cantidad_acompañantes")
	int cantidad_acompañantes;
	@Column(name = "transporte")
	String transporte;
	
	
	public String getTransporte() {
		return transporte;
	}
	public void setTransporte(String transporte) {
		this.transporte = transporte;
	}
	public int getCantidad_acompañantes() {
		return cantidad_acompañantes;
	}
	public void setCantidad_acompañantes(int cantidad_acompañantes) {
		this.cantidad_acompañantes = cantidad_acompañantes;
	}
	public int getId_reserva() {
		return id_reserva;
	}
	public void setId_reserva(int id_reserva) {
		this.id_reserva = id_reserva;
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
	public String getEstado_reserva() {
		return estado_reserva;
	}
	public void setEstado_reserva(String estado_reserva) {
		this.estado_reserva = estado_reserva;
	}
	public String getEstado_pago() {
		return estado_pago;
	}
	public void setEstado_pago(String estado_pago) {
		this.estado_pago = estado_pago;
	}
	public Date getCheck_in() {
		return check_in;
	}
	public void setCheck_in(Date check_in) {
		this.check_in = check_in;
	}
	public Date getCheck_out() {
		return check_out;
	}
	public void setCheck_out(Date check_out) {
		this.check_out = check_out;
	}
	public int getFirma() {
		return firma;
	}
	public void setFirma(int firma) {
		this.firma = firma;
	}
	public int getValor_total() {
		return valor_total;
	}
	public void setValor_total(int valor_total) {
		this.valor_total = valor_total;
	}
	
	
	public Reserva(int id_reserva, int id_dpto, int id_cliente, String estado_reserva, String estado_pago, Date check_in,
			Date check_out, int firma, int valor_total, int cantidad_acompañantes, String transporte) {
		super();
		this.id_reserva = id_reserva;
		this.id_dpto = id_dpto;
		this.id_cliente = id_cliente;
		this.estado_reserva = estado_reserva;
		this.estado_pago = estado_pago;
		this.check_in = check_in;
		this.check_out = check_out;
		this.firma = firma;
		this.valor_total = valor_total;
		this.cantidad_acompañantes = cantidad_acompañantes;
		this.transporte = transporte;
	}
	public Reserva() {
		
	}

	
}
