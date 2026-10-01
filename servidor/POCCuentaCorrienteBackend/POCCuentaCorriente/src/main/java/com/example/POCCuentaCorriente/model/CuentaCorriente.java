package com.example.POCCuentaCorriente.model;

import java.time.LocalDateTime;

public class CuentaCorriente extends ProductoFinanciero {

    private double cuotaManejo;
    private String tipoCuenta;

    public CuentaCorriente(
            int numeroCuenta,
            String titular,
            LocalDateTime fechaApertura,
            double saldo,
            double cuotaManejo,
            String tipoCuenta) {

        super(numeroCuenta, titular, fechaApertura, saldo);

        this.cuotaManejo = cuotaManejo;
        this.tipoCuenta = tipoCuenta;
    }

    public double getCuotaManejo() {
        return cuotaManejo;
    }

    public void setCuotaManejo(double cuotaManejo) {
        this.cuotaManejo = cuotaManejo;
    }

    public String getTipoCuenta() {
        return tipoCuenta;
    }

    public void setTipoCuenta(String tipoCuenta) {
        this.tipoCuenta = tipoCuenta;
    }
}