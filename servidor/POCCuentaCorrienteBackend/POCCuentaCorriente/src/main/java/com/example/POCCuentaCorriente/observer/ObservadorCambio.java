package com.example.POCCuentaCorriente.observer;

public interface ObservadorCambio {

    void actualizar(
            String entidad,
            String operacion,
            String identificador
    );

}