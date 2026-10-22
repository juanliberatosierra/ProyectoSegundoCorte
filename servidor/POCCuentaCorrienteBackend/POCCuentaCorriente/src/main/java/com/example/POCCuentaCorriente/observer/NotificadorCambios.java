package com.example.POCCuentaCorriente.observer;

import org.springframework.stereotype.Component;

import java.util.List;
import java.util.concurrent.CopyOnWriteArrayList;

@Component
public class NotificadorCambios {

    private final List<ObservadorCambio> observadores =
            new CopyOnWriteArrayList<>();


    // Registrar un observador
    public void agregarObservador(ObservadorCambio observador) {

        if (observador != null && !observadores.contains(observador)) {
            observadores.add(observador);
        }

    }


    // Eliminar un observador
    public void eliminarObservador(ObservadorCambio observador) {

        observadores.remove(observador);

    }


    // Notificar a todos los observadores
    public void notificar(
            String entidad,
            String operacion,
            String identificador) {

        for (ObservadorCambio observador : observadores) {

            observador.actualizar(
                    entidad,
                    operacion,
                    identificador
            );

        }
    }
}