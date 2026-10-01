package com.example.POCCuentaCorriente.servicios;

import com.example.POCCuentaCorriente.model.CuentaCorriente;
import com.example.POCCuentaCorriente.model.CuentaCorrienteInput;

import java.time.LocalDateTime;
import java.util.ArrayList;
import java.util.List;
import java.util.Optional;

public class ServicioCuentaCorriente {

    private static List<CuentaCorriente> cuentas =
            new ArrayList<>();

    // Listar cuentas con filtros
    public static List<CuentaCorriente> listarCuentas(
            String titular,
            String tipoCuenta) {

        return cuentas.stream()
                .filter(cuenta ->
                        titular == null ||
                                titular.isBlank() ||
                                cuenta.getTitular()
                                        .toLowerCase()
                                        .contains(titular.toLowerCase())
                )
                .filter(cuenta ->
                        tipoCuenta == null ||
                                tipoCuenta.isBlank() ||
                                tipoCuenta.equalsIgnoreCase("Todos") ||
                                cuenta.getTipoCuenta()
                                        .equalsIgnoreCase(tipoCuenta)
                )
                .toList();
    }

    // Buscar una cuenta por número
    public static Optional<CuentaCorriente> buscarPorNumeroCuenta(int numeroCuenta) {
        return cuentas.stream()
                .filter(c -> c.getNumeroCuenta() == numeroCuenta)
                .findFirst();
    }

    // Agregar una cuenta
    public static Optional<CuentaCorriente> agregarCuenta(
            CuentaCorrienteInput input) {

        // Verificar si ya existe una cuenta con ese número
        if (buscarPorNumeroCuenta(input.numeroCuenta()).isPresent()) {
            throw new IllegalArgumentException(
                    "Ya existe una cuenta con ese número."
            );
        }

        // Verificar que el saldo no sea negativo
        if (input.saldo() < 0) {
            throw new IllegalArgumentException(
                    "El saldo no puede ser negativo."
            );
        }

        // Verificar que la cuota de manejo no sea negativa
        if (input.cuotaManejo() < 0) {
            throw new IllegalArgumentException(
                    "La cuota de manejo no puede ser negativa."
            );
        }

        // Verificar que la cuota de manejo no sea mayor que el saldo
        if (input.cuotaManejo() > input.saldo()) {
            throw new IllegalArgumentException(
                    "La cuota de manejo no puede ser mayor que el saldo."
            );
        }

        CuentaCorriente cuenta = new CuentaCorriente(
                input.numeroCuenta(),
                input.titular(),
                LocalDateTime.parse(input.fechaApertura()),
                input.saldo(),
                input.cuotaManejo(),
                input.tipoCuenta()
        );

        cuentas.add(cuenta);

        return Optional.of(cuenta);
    }

    // Eliminar una cuenta
    public static boolean eliminarCuenta(int numeroCuenta) {

        Optional<CuentaCorriente> cuenta =
                buscarPorNumeroCuenta(numeroCuenta);

        if (cuenta.isPresent()) {
            cuentas.remove(cuenta.get());
            return true;
        }

        return false;
    }

    // Actualizar una cuenta
    public static Optional<CuentaCorriente> actualizarCuenta(
            CuentaCorrienteInput input) {

        Optional<CuentaCorriente> cuentaEncontrada =
                buscarPorNumeroCuenta(input.numeroCuenta());

        if (cuentaEncontrada.isPresent()) {

            // Validar saldo
            if (input.saldo() < 0) {
                throw new IllegalArgumentException(
                        "El saldo no puede ser negativo."
                );
            }

            // Validar cuota de manejo
            if (input.cuotaManejo() < 0) {
                throw new IllegalArgumentException(
                        "La cuota de manejo no puede ser negativa."
                );
            }

            // Validar relación entre saldo y cuota
            if (input.cuotaManejo() > input.saldo()) {
                throw new IllegalArgumentException(
                        "La cuota de manejo no puede ser mayor que el saldo."
                );
            }

            CuentaCorriente cuenta = cuentaEncontrada.get();

            cuenta.setTitular(input.titular());

            cuenta.setFechaApertura(
                    LocalDateTime.parse(input.fechaApertura())
            );

            cuenta.setSaldo(input.saldo());

            cuenta.setCuotaManejo(input.cuotaManejo());

            cuenta.setTipoCuenta(input.tipoCuenta());

            return Optional.of(cuenta);
        }

        return Optional.empty();
    }
}