package com.example.POCCuentaCorriente.model;

import org.springframework.data.annotation.Id;
import org.springframework.data.mongodb.core.mapping.Document;

import java.time.LocalDateTime;


@Document(collection = "movimientos")
public class MovimientoBancario {

    // Llave primaria en MongoDB: "numeroCuenta-idMovimiento" (ej: "101-1").
    @Id
    private String id;
    private final int idMovimiento;
    private final int numeroCuenta;
    private String tipoMovimiento;
    private double monto;
    private LocalDateTime fechaMovimiento;
    private String descripcion;
    private boolean confirmado = false;

    public MovimientoBancario(int idMovimiento, int numeroCuenta, String tipoMovimiento, double monto, LocalDateTime fechaMovimiento, String descripcion) {
        this.id = generarId(numeroCuenta, idMovimiento);
        this.idMovimiento = idMovimiento;
        this.numeroCuenta = numeroCuenta;
        this.tipoMovimiento = tipoMovimiento;
        this.monto = monto;
        this.fechaMovimiento = fechaMovimiento;
        this.descripcion = descripcion;
    }

    // Arma la llave primaria a partir de la cuenta y el id del movimiento
    public static String generarId(int numeroCuenta, int idMovimiento) {
        return numeroCuenta + "-" + idMovimiento;
    }

    public String getId() {
        return id;
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
