package com.example.POCCuentaCorriente.servicios;

import com.example.POCCuentaCorriente.builder.MovimientoBancarioBuilder;
import com.example.POCCuentaCorriente.model.CuentaCorriente;
import com.example.POCCuentaCorriente.model.MovimientoBancario;
import com.example.POCCuentaCorriente.model.MovimientoBancarioInput;
import com.example.POCCuentaCorriente.model.MovimientoDetalle;
import com.example.POCCuentaCorriente.observer.NotificadorCambios;
import com.example.POCCuentaCorriente.repository.RepositorioCuentaCorriente;
import com.example.POCCuentaCorriente.repository.RepositorioMovimientoBancario;
import org.springframework.stereotype.Service;

import java.time.LocalDateTime;
import java.time.format.DateTimeParseException;
import java.util.List;

@Service
public class ServicioMovimientoBancario {

    private final RepositorioCuentaCorriente repositorioCuentas;
    private final RepositorioMovimientoBancario repositorioMovimientos;
    private final NotificadorCambios notificador;

    public ServicioMovimientoBancario(
            RepositorioCuentaCorriente repositorioCuentas,
            RepositorioMovimientoBancario repositorioMovimientos,
            NotificadorCambios notificador) {

        this.repositorioCuentas = repositorioCuentas;
        this.repositorioMovimientos = repositorioMovimientos;
        this.notificador = notificador;
    }

    // AGREGAR MOVIMIENTO BANCARIO
    public MovimientoBancario agregarMovimiento(MovimientoBancarioInput input) {

        if (input == null) {
            throw new IllegalArgumentException("Los datos del movimiento son obligatorios");
        }

        // La cuenta (clase A) debe existir y estar activa
        CuentaCorriente cuenta = repositorioCuentas
                .buscarPorNumeroCuenta(input.numeroCuenta())
                .orElseThrow(() -> new IllegalArgumentException(
                        "La cuenta corriente no existe"
                ));

        if (!cuenta.isActiva()) {
            throw new IllegalArgumentException(
                    "No se pueden agregar movimientos a una cuenta inactiva"
            );
        }

        // El builder valida id, tipo, monto, fecha y descripcion
        MovimientoBancario movimiento = construir(input);

        // Antes: cuenta.agregarMovimiento(movimiento) -> lista en memoria
        // Ahora: se guarda en la colección "movimientos"
        repositorioMovimientos.guardar(movimiento);

        notificador.notificar(
                "MovimientoBancario",
                "CREAR",
                cuenta.getNumeroCuenta() + "-" + movimiento.getIdMovimiento()
        );

        return movimiento;
    }

    // BUSCAR UN MOVIMIENTO
    public MovimientoBancario buscarMovimiento(int numeroCuenta, int idMovimiento) {

        return repositorioMovimientos
                .buscar(numeroCuenta, idMovimiento)
                .orElse(null);
    }

    // LISTAR MOVIMIENTOS (filtros opcionales)
    public List<MovimientoBancario> listarMovimientos(Integer numeroCuenta, String tipoMovimiento) {

        return repositorioMovimientos.listar(numeroCuenta, tipoMovimiento);
    }

    // MOVIMIENTOS DE UNA CUENTA (para el campo "movimientos" de CuentaCorriente)
    public List<MovimientoBancario> movimientosDeCuenta(int numeroCuenta) {

        return repositorioMovimientos.listarPorCuenta(numeroCuenta);
    }

    // CONSULTA PERSONALIZADA: movimiento + titular y tipo de su cuenta
    public List<MovimientoDetalle> listarMovimientosConCuenta(Integer numeroCuenta, String tipoMovimiento) {

        return repositorioMovimientos.listarConDatosCuenta(numeroCuenta, tipoMovimiento);
    }

    // ACTUALIZAR MOVIMIENTO BANCARIO
    public MovimientoBancario actualizarMovimiento(MovimientoBancarioInput input) {

        if (input == null) {
            throw new IllegalArgumentException("Los datos del movimiento son obligatorios");
        }

        // Verificar que el movimiento exista en esa cuenta
        if (repositorioMovimientos.buscar(input.numeroCuenta(), input.idMovimiento()).isEmpty()) {
            return null;
        }

        // Se construye de nuevo con el builder para reutilizar todas las validaciones
        MovimientoBancario movimiento = construir(input);

        // Guardar los cambios en MongoDB (mismo _id = reemplaza el documento)
        repositorioMovimientos.actualizar(movimiento);

        notificador.notificar(
                "MovimientoBancario",
                "ACTUALIZAR",
                input.numeroCuenta() + "-" + input.idMovimiento()
        );

        return movimiento;
    }

    // ELIMINAR MOVIMIENTO BANCARIO
    public boolean eliminarMovimiento(int numeroCuenta, int idMovimiento) {

        // Antes fallaba (NullPointerException) si la cuenta no existía;
        // ahora simplemente devuelve false.
        boolean eliminado = repositorioMovimientos.eliminar(numeroCuenta, idMovimiento);

        if (eliminado) {
            notificador.notificar(
                    "MovimientoBancario",
                    "ELIMINAR",
                    numeroCuenta + "-" + idMovimiento
            );
        }

        return eliminado;
    }

    // Convierte el input en un MovimientoBancario validado
    private MovimientoBancario construir(MovimientoBancarioInput input) {

        if (input.fechaMovimiento() == null || input.fechaMovimiento().isBlank()) {
            throw new IllegalArgumentException("La fecha del movimiento es obligatoria");
        }

        LocalDateTime fecha;

        try {
            fecha = LocalDateTime.parse(input.fechaMovimiento());
        } catch (DateTimeParseException e) {
            throw new IllegalArgumentException(
                    "Formato de fecha invalido. Use yyyy-MM-ddTHH:mm:ss", e
            );
        }

        return new MovimientoBancarioBuilder()
                .idMovimiento(input.idMovimiento())
                .numeroCuenta(input.numeroCuenta())
                .tipoMovimiento(input.tipoMovimiento() == null ? null : input.tipoMovimiento().trim())
                .monto(input.monto())
                .fechaMovimiento(fecha)
                .descripcion(input.descripcion())
                .confirmado(input.confirmado())
                .build();
    }
}
