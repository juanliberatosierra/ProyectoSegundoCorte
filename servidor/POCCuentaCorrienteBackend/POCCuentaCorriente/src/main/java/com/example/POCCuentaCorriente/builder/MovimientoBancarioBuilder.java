package com.example.POCCuentaCorriente.builder;

import com.example.POCCuentaCorriente.model.MovimientoBancario;

import java.time.LocalDateTime;

public class MovimientoBancarioBuilder {

    private int idMovimiento;
    private int numeroCuenta;
    private String tipoMovimiento;
    private double monto;
    private LocalDateTime fechaMovimiento;
    private String descripcion;
    private boolean confirmado = false;



    public MovimientoBancarioBuilder idMovimiento(int idMovimiento) {

        this.idMovimiento = idMovimiento;
        return this;
    }



    public MovimientoBancarioBuilder numeroCuenta(int numeroCuenta) {

        this.numeroCuenta = numeroCuenta;
        return this;
    }



    public MovimientoBancarioBuilder tipoMovimiento(String tipoMovimiento) {

        this.tipoMovimiento = tipoMovimiento;
        return this;
    }



    public MovimientoBancarioBuilder monto(double monto) {

        this.monto = monto;
        return this;
    }



    public MovimientoBancarioBuilder fechaMovimiento(
            LocalDateTime fechaMovimiento) {

        this.fechaMovimiento = fechaMovimiento;
        return this;
    }



    public MovimientoBancarioBuilder descripcion(String descripcion) {

        this.descripcion = descripcion;
        return this;
    }



    public MovimientoBancarioBuilder confirmado(boolean confirmado) {

        this.confirmado = confirmado;
        return this;
    }


    // Construir el movimiento
    public MovimientoBancario build() {

        // Validar identificador
        if (idMovimiento <= 0) {
            throw new IllegalArgumentException(
                    "El ID del movimiento debe ser mayor a cero"
            );
        }

        // Validar numero de cuenta
        if (numeroCuenta <= 0) {
            throw new IllegalArgumentException(
                    "El numero de cuenta debe ser mayor a cero"
            );
        }

        // Validar tipo
        if (tipoMovimiento == null ||
                (!tipoMovimiento.equalsIgnoreCase("DEPOSITO") &&
                        !tipoMovimiento.equalsIgnoreCase("RETIRO"))) {

            throw new IllegalArgumentException(
                    "El tipo debe ser DEPOSITO o RETIRO"
            );
        }

        // Validar monto
        if (!Double.isFinite(monto) || monto <= 0) {

            throw new IllegalArgumentException(
                    "El monto debe ser positivo"
            );
        }

        // Validar fecha
        if (fechaMovimiento == null) {

            throw new IllegalArgumentException(
                    "La fecha es obligatoria"
            );
        }

        // Validar descripcion
        if (descripcion == null || descripcion.isBlank()) {

            throw new IllegalArgumentException(
                    "La descripcion es obligatoria"
            );
        }

        // Crear objeto
        MovimientoBancario movimiento = new MovimientoBancario(
                idMovimiento,
                numeroCuenta,
                tipoMovimiento.toUpperCase(),
                monto,
                fechaMovimiento,
                descripcion.trim()
        );

        movimiento.setConfirmado(confirmado);

        return movimiento;
    }
}