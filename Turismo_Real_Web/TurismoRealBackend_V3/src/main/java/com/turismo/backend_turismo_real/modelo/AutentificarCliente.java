package com.turismo.backend_turismo_real.modelo;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.Table;

@Entity

@Table(name = "AUT_CLI")
public class AutentificarCliente {
	
	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	private int id_aut_cli;
	@Column(name = "EMAIL")
	private String Email;
	@Column(name = "CODE")
	private int code;
	public String getEmail() {
		return Email;
	}
	public void setEmail(String email) {
		Email = email;
	}
	public int getCode() {
		return code;
	}
	public void setCode(int code) {
		this.code = code;
	}
	
	
	public int getId_aut_cli() {
		return id_aut_cli;
	}
	public void setId_aut_cli(int id_aut_cli) {
		this.id_aut_cli = id_aut_cli;
	}
	
	
	
	public AutentificarCliente(int id_aut_cli, String email, int code) {
		super();
		this.id_aut_cli = id_aut_cli;
		Email = email;
		this.code = code;
	}
	public AutentificarCliente() {}
	
	
}
