package com.example.POCCuentaCorriente.servicios;

import com.example.POCCuentaCorriente.model.CuentaCorriente;
import com.example.POCCuentaCorriente.model.MovimientoBancario;
import com.example.POCCuentaCorriente.model.MovimientoBancarioInput;
import com.example.POCCuentaCorriente.repository.RepositorioCuentaCorriente;
import com.example.POCCuentaCorriente.builder.MovimientoBancarioBuilder;
import java.time.format.DateTimeParseException;
import java.util.List;
import java.util.ArrayList;
import org.springframework.stereotype.Service;
import com.example.POCCuentaCorriente.observer.NotificadorCambios;


import java.time.LocalDateTime;

@Service
public class ServicioMovimientoBancario {

    private final RepositorioCuentaCorriente repositorio;
    private final NotificadorCambios notificador;

    public ServicioMovimientoBancario(RepositorioCuentaCorriente repositorio, NotificadorCambios notificador) {
        this.repositorio = repositorio;
        this.notificador = notificador;
    }

    public MovimientoBancario agregarMovimiento(
            MovimientoBancarioInput input) {

        // Buscar la cuenta corriente
        CuentaCorriente cuenta = repositorio
                .buscarPorNumeroCuenta(input.numeroCuenta())
                .orElseThrow(() -> new IllegalArgumentException(
                        "La cuenta corriente no existe"
                ));

        if (!cuenta.isActiva()) {
            throw new IllegalArgumentException(
                    "No se pueden agregar movimientos a una cuenta inactiva"
            );
        }

        // Validar el identificador, que sea mayor a 0
        if (input.idMovimiento() <= 0) {
            throw new IllegalArgumentException(
                    "El identificador debe ser mayor a cero"
            );
        }

        // Validar el tipo de movimiento
        String tipo = input.tipoMovimiento();

        if (tipo == null ||
                (!tipo.equalsIgnoreCase("DEPOSITO") &&
                        !tipo.equalsIgnoreCase("RETIRO"))) {

            throw new IllegalArgumentException(
                    "El tipo debe ser DEPOSITO o RETIRO"
            );
        }

        // Validar el monto
        if (!Double.isFinite(input.monto()) || input.monto() <= 0) {
            throw new IllegalArgumentException(
                    "El monto debe ser mayor a cero"
            );
        }

        // Convertir la fecha
        LocalDateTime fecha = LocalDateTime.parse(
                input.fechaMovimiento()
        );

        MovimientoBancario movimiento = new MovimientoBancarioBuilder()
                .idMovimiento(input.idMovimiento())
                .numeroCuenta(input.numeroCuenta())
                .tipoMovimiento(tipo.toUpperCase())
                .monto(input.monto())
                .fechaMovimiento(fecha)
                .descripcion(input.descripcion())
                .confirmado(input.confirmado())
                .build();

        // Asociar el movimiento a la cuenta
        cuenta.agregarMovimiento(movimiento);

        notificador.notificar(
                "MovimientoBancario",
                "CREAR",
                cuenta.getNumeroCuenta() + "-" + movimiento.getIdMovimiento()
        );

        // Se Devuelve el movimiento registrado
        return movimiento;
    }

    public MovimientoBancario buscarMovimiento(
            int numeroCuenta,
            int idMovimiento) {

        // Buscar la cuenta corriente
        CuentaCorriente cuenta = repositorio
                .buscarPorNumeroCuenta(numeroCuenta)
                .orElse(null);


        if (cuenta == null) {
            return null;
        }

        // Buscar el movimiento dentro de la cuenta
        return cuenta.buscarMovimiento(idMovimiento);
    }

    public List<MovimientoBancario> listarMovimientos(
            Integer numeroCuenta,
            String tipoMovimiento) {

        // Lista donde guardaremos los resultados
        List<MovimientoBancario> resultado = new ArrayList<>();

        // Obtener todas las cuentas corrientes
        List<CuentaCorriente> cuentas = repositorio.listar();

        // Recorrer todas las cuentas
        for (CuentaCorriente cuenta : cuentas) {

            // Filtrar por numero de cuenta, si se proporciono
            if (numeroCuenta != null &&
                    cuenta.getNumeroCuenta() != numeroCuenta) {

                continue;
            }

            // Recorrer los movimientos de cada cuenta
            for (MovimientoBancario movimiento : cuenta.getMovimientos()) {

                // Filtrar por tipo de movimiento
                if (tipoMovimiento == null ||
                        tipoMovimiento.isBlank() ||
                        movimiento.getTipoMovimiento()
                                .equalsIgnoreCase(tipoMovimiento.trim())) {

                    resultado.add(movimiento);
                }
            }
        }

        return resultado;
    }


    // ACTUALIZAR MOVIMIENTO BANCARIO
    public MovimientoBancario actualizarMovimiento(
            MovimientoBancarioInput input) {

        // Verificar que recibimos datos
        if (input == null) {
            throw new IllegalArgumentException(
                    "Los datos del movimiento son obligatorios"
            );
        }

        // Buscar la cuenta corriente
        CuentaCorriente cuenta = repositorio
                .buscarPorNumeroCuenta(input.numeroCuenta())
                .orElse(null);

        // Verificar que la cuenta exista
        if (cuenta == null) {
            return null;
        }

        // Buscar el movimiento
        MovimientoBancario movimiento =
                cuenta.buscarMovimiento(input.idMovimiento());

        // Verificar que el movimiento exista
        if (movimiento == null) {
            return null;
        }

        // Validar la fecha
        if (input.fechaMovimiento() == null ||
                input.fechaMovimiento().isBlank()) {

            throw new IllegalArgumentException(
                    "La fecha del movimiento es obligatoria"
            );
        }

        // Convertir la fecha
        LocalDateTime fecha;

        try {

            fecha = LocalDateTime.parse(
                    input.fechaMovimiento()
            );

        } catch (DateTimeParseException e) {

            throw new IllegalArgumentException(
                    "Formato de fecha invalido. Use yyyy-MM-ddTHH:mm:ss",
                    e
            );
        }

        // Actualizar utilizando el metodo del modelo
        boolean actualizado = cuenta.actualizarMovimiento(
                input.idMovimiento(),
                input.tipoMovimiento(),
                input.monto(),
                fecha,
                input.descripcion()
        );

        // Comprobar el resultado
        if (!actualizado) {
            return null;
        }

        // Actualizar estado de confirmacion
        movimiento.setConfirmado(input.confirmado());

        notificador.notificar(
                "MovimientoBancario",
                "ACTUALIZAR",
                input.numeroCuenta() + "-" + input.idMovimiento()
        );

        // Devolver movimiento actualizado
        return movimiento;
    }


    // ELIMINAR MOVIMIENTO BANCARIO


    public boolean eliminarMovimiento(
            int numeroCuenta,
            int idMovimiento) {

        // Buscar la cuenta corriente
        CuentaCorriente cuenta = repositorio
                .buscarPorNumeroCuenta(numeroCuenta)
                .orElse(null);

        boolean eliminado = cuenta.eliminarMovimiento(idMovimiento);

        if (eliminado) {
            notificador.notificar(
                    "MovimientoBancario",
                    "ELIMINAR",
                    numeroCuenta + "-" + idMovimiento
            );
        }

        return eliminado;
    }

}