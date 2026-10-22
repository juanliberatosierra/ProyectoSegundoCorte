package com.example.POCCuentaCorriente.model;

import java.time.LocalDateTime;
import java.util.ArrayList;
import java.util.Collections;
import java.util.Iterator;
import java.util.List;

public class CuentaCorriente extends ProductoFinanciero {

    private double cuotaManejo;
    private String tipoCuenta;
    private final List<MovimientoBancario> movimientos = new ArrayList<>();
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

    public void agregarMovimiento(MovimientoBancario movimiento){

        if(movimiento == null){
            throw new IllegalArgumentException("El movimiento no puede ser vacio");
        }

        if(movimiento.getNumeroCuenta() != this.getNumeroCuenta()){
            throw new IllegalArgumentException("El movimiento no pertenece a esta cuenta");
        }

        for (MovimientoBancario m : movimientos) {

            if (m.getIdMovimiento() == movimiento.getIdMovimiento()) {

                throw new IllegalArgumentException(
                        "Ya existe un movimiento con ese ID"
                );
            }
        }

        movimientos.add(movimiento);

    }

    public List<MovimientoBancario> getMovimientos(){
        return Collections.unmodifiableList(movimientos);
    }

    public boolean eliminarMovimiento(int idMovimiento) {

        Iterator<MovimientoBancario> iterador = movimientos.iterator();

        while (iterador.hasNext()) {

            MovimientoBancario movimiento = iterador.next();

            if (movimiento.getIdMovimiento() == idMovimiento) {

                iterador.remove();

                return true;
            }
        }

        return false;
    }

    public MovimientoBancario buscarMovimiento(int idMovimiento) {

        for (MovimientoBancario movimiento : movimientos) {

            if (movimiento.getIdMovimiento() == idMovimiento) {

                return movimiento;

            }
        }

        return null;
    }

    public boolean actualizarMovimiento(
            int idMovimiento,
            String nuevoTipo,
            double nuevoMonto,
            LocalDateTime nuevaFecha,
            String nuevaDescripcion) {

        // 1. Buscar el movimiento
        MovimientoBancario movimiento = buscarMovimiento(idMovimiento);

        // 2. Verificar si existe
        if (movimiento == null) {
            return false;
        }

        // 3. Validar el tipo de movimiento
        String tipoNormalizado = nuevoTipo == null
                ? ""
                : nuevoTipo.trim().toUpperCase();

        if (!tipoNormalizado.equals("DEPOSITO")
                && !tipoNormalizado.equals("RETIRO")) {

            throw new IllegalArgumentException(
                    "El tipo debe ser DEPOSITO o RETIRO"
            );
        }

        // 4. Validar el monto
        if (!Double.isFinite(nuevoMonto) || nuevoMonto <= 0) {

            throw new IllegalArgumentException(
                    "El monto debe ser mayor a cero"
            );
        }

        // 5. Validar la fecha
        if (nuevaFecha == null) {

            throw new IllegalArgumentException(
                    "La fecha no puede ser nula"
            );
        }

        // 6. Validar la descripcion
        if (nuevaDescripcion == null
                || nuevaDescripcion.trim().isEmpty()) {

            throw new IllegalArgumentException(
                    "La descripcion no puede estar vacia"
            );
        }

        // 7. Actualizar los atributos
        movimiento.setTipoMovimiento(tipoNormalizado);
        movimiento.setMonto(nuevoMonto);
        movimiento.setFechaMovimiento(nuevaFecha);
        movimiento.setDescripcion(nuevaDescripcion.trim());

        // 8. Confirmar actualizacion
        return true;
    }

    public boolean isActiva() {
        return activa;
    }

    public void setActiva(boolean activa) {
        this.activa = activa;
    }
}