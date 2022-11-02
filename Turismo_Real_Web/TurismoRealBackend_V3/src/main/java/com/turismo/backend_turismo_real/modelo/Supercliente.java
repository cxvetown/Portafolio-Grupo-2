package com.turismo.backend_turismo_real.modelo;

public class Supercliente {

	String email;
	String pass;
	int fono;
	String rut;
	String nombre;
	String apellido;
	int code;
	
	
	
	public int getCode() {
		return code;
	}
	public void setCode(int code) {
		this.code = code;
	}
	public String getEmail() {
		return email;
	}
	public void setEmail(String email) {
		this.email = email;
	}
	public String getPass() {
		return pass;
	}
	public void setPass(String pass) {
		this.pass = pass;
	}
	public int getFono() {
		return fono;
	}
	public void setFono(int fono) {
		this.fono = fono;
	}
	public String getRut() {
		return rut;
	}
	public void setRut(String rut) {
		this.rut = rut;
	}
	public String getNombre() {
		return nombre;
	}
	public void setNombre(String nombre) {
		this.nombre = nombre;
	}
	public String getApellido() {
		return apellido;
	}
	public void setApellido(String apellido) {
		this.apellido = apellido;
	}
	public Supercliente(String email, String pass, int fono, String rut, String nombre, String apellido, int code) {
		super();
		this.email = email;
		this.pass = pass;
		this.fono = fono;
		this.rut = rut;
		this.nombre = nombre;
		this.apellido = apellido;
		this.code = code;
	}
	
	
	
}
