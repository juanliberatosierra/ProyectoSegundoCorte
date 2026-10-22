package com.example.POCCuentaCorriente.model;

import java.time.LocalDateTime;

public class MovimientoBancario {
    private final int idMovimiento;
    private final int numeroCuenta;
    private String tipoMovimiento;
    private double monto;
    private LocalDateTime fechaMovimiento;
    private String descripcion;
    private boolean confirmado = false;

    public MovimientoBancario(int idMovimiento, int numeroCuenta, String tipoMovimiento, double monto, LocalDateTime fechaMovimiento, String descripcion) {
        this.idMovimiento = idMovimiento;
        this.numeroCuenta = numeroCuenta;
        this.tipoMovimiento = tipoMovimiento;
        this.monto = monto;
        this.fechaMovimiento = fechaMovimiento;
        this.descripcion = descripcion;
    }

    public int getIdMovimiento() {
        return idMovimiento;
    }


    public int getNumeroCuenta() {
        return numeroCuenta;
    }



    public String getTipoMovimiento() {
        return tipoMovimiento;
    }

    public void setTipoMovimiento(String tipoMovimiento) {
        this.tipoMovimiento = tipoMovimiento;
    }

    public double getMonto() {
        return monto;
    }

    public void setMonto(double monto) {
        this.monto = monto;
    }

    public LocalDateTime getFechaMovimiento() {
        return fechaMovimiento;
    }

    public void setFechaMovimiento(LocalDateTime fechaMovimiento) {
        this.fechaMovimiento = fechaMovimiento;
    }

    public String getDescripcion() {
        return descripcion;
    }

    public void setDescripcion(String descripcion) {
        this.descripcion = descripcion;
    }

    public boolean isConfirmado() {
        return confirmado;
    }

    public void setConfirmado(boolean confirmado) {
        this.confirmado = confirmado;
    }
}
