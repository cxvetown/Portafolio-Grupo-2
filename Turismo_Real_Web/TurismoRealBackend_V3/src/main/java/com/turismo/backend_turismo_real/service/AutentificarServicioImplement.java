package com.turismo.backend_turismo_real.service;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.mail.SimpleMailMessage;
import org.springframework.mail.javamail.JavaMailSender;
import org.springframework.stereotype.Service;

import com.turismo.backend_turismo_real.modelo.AutentificarCliente;
import com.turismo.backend_turismo_real.repositorio.AutentificarRepositorio;

@Service
public class AutentificarServicioImplement implements AutentificarServicio {

	@Autowired
	private AutentificarRepositorio AutRepo;
	@Autowired
	private JavaMailSender mail;

	public void SendEmail(String to, String subject, String content) {

		SimpleMailMessage email = new SimpleMailMessage();

		email.setTo(to);
		email.setSubject(subject);
		email.setText(content);

		mail.send(email);
	}

	@Override
	public AutentificarCliente guardarAutentificar(AutentificarCliente autCli) {
		return AutRepo.save(autCli);
	}

	@Override
	public String AutCodigo(int code) {
		return AutRepo.AutCodigo(code);
	}
}
