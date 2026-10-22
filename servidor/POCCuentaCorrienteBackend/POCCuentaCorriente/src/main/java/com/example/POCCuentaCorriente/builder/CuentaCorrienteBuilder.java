package com.example.POCCuentaCorriente.builder;

import com.example.POCCuentaCorriente.model.CuentaCorriente;

import java.time.LocalDateTime;

public class CuentaCorrienteBuilder {

    private int numeroCuenta;
    private String titular;
    private LocalDateTime fechaApertura;
    private double saldo;
    private double cuotaManejo;
    private String tipoCuenta;


    // Establecer numero de cuenta
    public CuentaCorrienteBuilder numeroCuenta(int numeroCuenta) {

        this.numeroCuenta = numeroCuenta;

        return this;
    }



    public CuentaCorrienteBuilder titular(String titular) {

        this.titular = titular;

        return this;
    }

    public CuentaCorrienteBuilder fechaApertura(
            LocalDateTime fechaApertura) {

        this.fechaApertura = fechaApertura;

        return this;
    }


    public CuentaCorrienteBuilder saldo(double saldo) {

        this.saldo = saldo;

        return this;
    }


    public CuentaCorrienteBuilder cuotaManejo(double cuotaManejo) {

        this.cuotaManejo = cuotaManejo;

        return this;
    }


    public CuentaCorrienteBuilder tipoCuenta(String tipoCuenta) {

        this.tipoCuenta = tipoCuenta;

        return this;
    }


    // Para construir el objeto final
    public CuentaCorriente build() {

        // Validar numero de cuenta
        if (numeroCuenta <= 0) {
            throw new IllegalArgumentException(
                    "El numero de cuenta debe ser mayor a cero"
            );
        }

        // Validar titular
        if (titular == null || titular.isBlank()) {
            throw new IllegalArgumentException(
                    "El titular es obligatorio"
            );
        }

        // Validar fecha
        if (fechaApertura == null) {
            throw new IllegalArgumentException(
                    "La fecha de apertura es obligatoria"
            );
        }

        // Validar tipo de cuenta
        if (tipoCuenta == null || tipoCuenta.isBlank()) {
            throw new IllegalArgumentException(
                    "El tipo de cuenta es obligatorio"
            );
        }

        // Validar saldo
        if (!Double.isFinite(saldo) || saldo < 0) {
            throw new IllegalArgumentException(
                    "El saldo debe ser valido y no negativo"
            );
        }

        // Validar cuota de manejo
        if (!Double.isFinite(cuotaManejo) || cuotaManejo < 0) {
            throw new IllegalArgumentException(
                    "La cuota de manejo debe ser valida y no negativa"
            );
        }

        // Validar relacion saldo y cuota
        if (cuotaManejo > saldo) {
            throw new IllegalArgumentException(
                    "La cuota de manejo no puede superar el saldo"
            );
        }

        return new CuentaCorriente(
                numeroCuenta,
                titular.trim(),
                fechaApertura,
                saldo,
                cuotaManejo,
                tipoCuenta.trim()
        );
    }
}