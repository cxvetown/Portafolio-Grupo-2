package com.turismo.backend_turismo_real.modelo;

import java.io.Serializable;

import javax.persistence.*;


@Entity

@NamedStoredProcedureQueries({
	@NamedStoredProcedureQuery(
			name = "crear_usuario",
			procedureName = "login_web.crear_usuario",
			parameters = {
				@StoredProcedureParameter(mode= ParameterMode.IN, name="email_c", type=String.class),
				@StoredProcedureParameter(mode= ParameterMode.IN, name="pass", type=String.class),
				@StoredProcedureParameter(mode= ParameterMode.IN, name="fono", type=int.class),
				@StoredProcedureParameter(mode= ParameterMode.IN, name="rut", type=String.class),
				@StoredProcedureParameter(mode= ParameterMode.IN, name="nombre", type=String.class),
				@StoredProcedureParameter(mode= ParameterMode.IN, name="apellido", type=String.class),
				@StoredProcedureParameter(mode= ParameterMode.OUT, name="r", type=int.class)	
			}
	),
	@NamedStoredProcedureQuery(
			name = "iniciar_sesion",
			procedureName = "login_web.autentificar",
			parameters = {
				@StoredProcedureParameter(mode= ParameterMode.IN, name="email_aut", type=String.class),
				@StoredProcedureParameter(mode= ParameterMode.IN, name="psw_aut", type=String.class),
				@StoredProcedureParameter(mode= ParameterMode.OUT, name="r", type=int.class)	
			}
	)
})

@Table(name = "Cliente")
public class Cliente implements Serializable{
	
	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	private int Id_Cliente;
	@Column(name = "Rut_Cliente")
	private String Rut_Cliente;
	@Column(name = "Nombres_Cliente")
	private String Nombres_Cliente;
	@Column(name = "Apellidos_Cliente")
	private String Apellidos_Cliente;
	@Column(name = "Id_Usuario", nullable = true)
	private int Id_Usuario;
	
	
	
	public int getId_Cliente() {
		return Id_Cliente;
	}



	public void setId_Cliente(int id_Cliente) {
		Id_Cliente = id_Cliente;
	}



	public String getRut_Cliente() {
		return Rut_Cliente;
	}



	public void setRut_Cliente(String rut_Cliente) {
		Rut_Cliente = rut_Cliente;
	}



	public String getNombres_Cliente() {
		return Nombres_Cliente;
	}



	public void setNombres_Cliente(String nombres_Cliente) {
		Nombres_Cliente = nombres_Cliente;
	}



	public String getApellidos_Cliente() {
		return Apellidos_Cliente;
	}



	public void setApellidos_Cliente(String apellidos_Cliente) {
		Apellidos_Cliente = apellidos_Cliente;
	}



	public int getId_Usuario() {
		return Id_Usuario;
	}



	public void setId_Usuario(int id_Usuario) {
		Id_Usuario = id_Usuario;
	}



	public Cliente(int id_Cliente, String rut_Cliente, String nombres_Cliente, String apellidos_Cliente,
			int id_Usuario) {
		super();
		Id_Cliente = id_Cliente;
		Rut_Cliente = rut_Cliente;
		Nombres_Cliente = nombres_Cliente;
		Apellidos_Cliente = apellidos_Cliente;
		Id_Usuario = id_Usuario;
	}



	public Cliente() {
		
	}
	
	
}
