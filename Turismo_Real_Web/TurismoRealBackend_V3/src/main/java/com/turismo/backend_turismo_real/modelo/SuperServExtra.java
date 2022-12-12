package com.turismo.backend_turismo_real.modelo;

public class SuperServExtra {
	int valor_total;
	int valor_serv_ex;
	
	public int getValor_total() {
		return valor_total;
	}
	public void setValor_total(int valor_total) {
		this.valor_total = valor_total;
	}
	public int getValor_serv_ex() {
		return valor_serv_ex;
	}
	public void setValor_serv_ex(int valor_serv_ex) {
		this.valor_serv_ex = valor_serv_ex;
	}
	public SuperServExtra(int valor_total, int valor_serv_ex) {
		super();
		this.valor_total = valor_total;
		this.valor_serv_ex = valor_serv_ex;
	}
	
	public SuperServExtra() {
		
	}
}
