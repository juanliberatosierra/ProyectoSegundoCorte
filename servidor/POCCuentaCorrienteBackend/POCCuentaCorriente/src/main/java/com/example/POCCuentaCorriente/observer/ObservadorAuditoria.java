package com.example.POCCuentaCorriente.observer;

import org.springframework.stereotype.Component;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

@Component
public class ObservadorAuditoria implements ObservadorCambio {

    private static final Logger logger =
            LoggerFactory.getLogger(ObservadorAuditoria.class);


    public ObservadorAuditoria(NotificadorCambios notificador) {

        notificador.agregarObservador(this);

    }


    @Override
    public void actualizar(
            String entidad,
            String operacion,
            String identificador) {

        logger.info(
                "OBSERVER | Entidad: {} | Operacion: {} | ID: {}",
                entidad,
                operacion,
                identificador
        );
    }
}