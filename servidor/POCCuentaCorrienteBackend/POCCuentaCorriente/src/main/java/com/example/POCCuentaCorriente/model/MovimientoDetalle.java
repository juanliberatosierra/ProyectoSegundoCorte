package com.example.POCCuentaCorriente.model;

import java.time.LocalDateTime;

public record MovimientoDetalle(
        int idMovimiento,
        int numeroCuenta,
        String tipoMovimiento,
        double monto,
        LocalDateTime fechaMovimiento,
        String descripcion,
        boolean confirmado,
        String titularCuenta,
        String tipoCuenta
) {
}
