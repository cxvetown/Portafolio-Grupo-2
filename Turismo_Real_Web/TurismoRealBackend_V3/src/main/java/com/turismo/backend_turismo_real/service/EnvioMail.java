package com.turismo.backend_turismo_real.service;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.mail.SimpleMailMessage;
import org.springframework.mail.javamail.JavaMailSender;
import org.springframework.stereotype.Service;

@Service
public class EnvioMail {

	@Autowired
	private JavaMailSender mail;
	
	public void SendEmail(String to, String subject, String content) {
		
		SimpleMailMessage email = new SimpleMailMessage();
		
		email.setTo(to);
        email.setSubject(subject);
        email.setText(content);
        
        mail.send(email);
	}
}
