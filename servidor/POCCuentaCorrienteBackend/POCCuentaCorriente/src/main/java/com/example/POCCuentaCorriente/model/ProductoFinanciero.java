package com.example.POCCuentaCorriente.model;

import java.time.LocalDateTime;

public class ProductoFinanciero {

    private int numeroCuenta;
    private String titular;
    private LocalDateTime fechaApertura;
    private double saldo;

    public ProductoFinanciero(
            int numeroCuenta,
            String titular,
            LocalDateTime fechaApertura,
            double saldo) {

        this.numeroCuenta = numeroCuenta;
        this.titular = titular;
        this.fechaApertura = fechaApertura;
        this.saldo = saldo;
    }

    public int getNumeroCuenta() {
        return numeroCuenta;
    }

    public void setNumeroCuenta(int numeroCuenta) {
        this.numeroCuenta = numeroCuenta;
    }

    public String getTitular() {
        return titular;
    }

    public void setTitular(String titular) {
        this.titular = titular;
    }

    public LocalDateTime getFechaApertura() {
        return fechaApertura;
    }

    public void setFechaApertura(LocalDateTime fechaApertura) {
        this.fechaApertura = fechaApertura;
    }

    public double getSaldo() {
        return saldo;
    }

    public void setSaldo(double saldo) {
        this.saldo = saldo;
    }
}