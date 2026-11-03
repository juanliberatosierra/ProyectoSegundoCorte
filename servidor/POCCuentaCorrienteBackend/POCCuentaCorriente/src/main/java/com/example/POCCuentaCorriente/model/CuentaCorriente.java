package com.example.POCCuentaCorriente.model;

import org.springframework.data.mongodb.core.mapping.Document;

import java.time.LocalDateTime;


@Document(collection = "cuentas")
public class CuentaCorriente extends ProductoFinanciero {

    private double cuotaManejo;
    private String tipoCuenta;
    private boolean activa = true;

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

    public boolean isActiva() {
        return activa;
    }

    public void setActiva(boolean activa) {
        this.activa = activa;
    }
}
