package com.example.POCCuentaCorriente.model;

public record CuentaCorrienteInput(
        int numeroCuenta,
        String titular,
        String fechaApertura,
        double saldo,
        Double cuotaManejo,
        String tipoCuenta
) {

    // La cuota de manejo es opcional si no llega, vale 0
    public CuentaCorrienteInput {
        if (cuotaManejo == null) {
            cuotaManejo = 0.0;
        }
    }
}