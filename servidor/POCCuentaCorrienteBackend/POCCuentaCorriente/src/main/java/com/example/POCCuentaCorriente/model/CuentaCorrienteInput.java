package com.example.POCCuentaCorriente.model;

public record CuentaCorrienteInput(
        int numeroCuenta,
        String titular,
        String fechaApertura,
        double saldo,
        double cuotaManejo,
        String tipoCuenta
) {
}