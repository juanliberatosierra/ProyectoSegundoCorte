package com.example.POCCuentaCorriente.model;

public record MovimientoBancarioInput(

        int idMovimiento,

        int numeroCuenta,

        String tipoMovimiento,

        double monto,

        String fechaMovimiento,

        String descripcion,

        boolean confirmado

) {
}