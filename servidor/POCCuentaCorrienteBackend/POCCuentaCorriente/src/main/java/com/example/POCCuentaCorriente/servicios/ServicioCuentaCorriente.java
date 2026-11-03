package com.example.POCCuentaCorriente.servicios;

import com.example.POCCuentaCorriente.model.CuentaCorriente;
import com.example.POCCuentaCorriente.model.CuentaCorrienteInput;
import com.example.POCCuentaCorriente.builder.CuentaCorrienteBuilder;
import com.example.POCCuentaCorriente.repository.RepositorioCuentaCorriente;
import com.example.POCCuentaCorriente.observer.NotificadorCambios;
import com.example.POCCuentaCorriente.repository.RepositorioMovimientoBancario;
import org.springframework.stereotype.Service;

import java.time.LocalDateTime;
import java.time.format.DateTimeParseException;
import java.util.List;
import java.util.Locale;
import java.util.Optional;


@Service
public class ServicioCuentaCorriente {

    //  DEPENDENCIA DEL REPOSITORIO


    private final RepositorioCuentaCorriente repositorio;
    private final RepositorioMovimientoBancario repositorioMovimientos;
    private final NotificadorCambios notificador;


    //  INYECCION DE DEPENDENCIAS


    public ServicioCuentaCorriente(
            RepositorioCuentaCorriente repositorio,
            RepositorioMovimientoBancario repositorioMovimientos,
            NotificadorCambios notificador) {

        this.repositorio = repositorio;
        this.repositorioMovimientos = repositorioMovimientos;
        this.notificador = notificador;
    }



    //  LISTAR CUENTAS CON FILTROS


    public List<CuentaCorriente> listarCuentas(
            String titular,
            String tipoCuenta) {

        // Ahora el filtro lo hace MongoDB
        return repositorio.listarConFiltros(titular, tipoCuenta);
    }


    //  BUSCAR CUENTA POR NUMERO


    public Optional<CuentaCorriente> buscarPorNumeroCuenta(
            int numeroCuenta) {

        return repositorio.buscarPorNumeroCuenta(numeroCuenta);

    }



    //  AGREGAR CUENTA


    public Optional<CuentaCorriente> agregarCuenta(CuentaCorrienteInput input) {

        // Validar los datos recibidos
        LocalDateTime fecha = validarYObtenerFecha(input);

        // Verificar si la cuenta ya existe
        if (repositorio.buscarPorNumeroCuenta(
                input.numeroCuenta()).isPresent()) {

            throw new IllegalArgumentException(
                    "Ya existe una cuenta con ese numero."
            );
        }

        CuentaCorriente cuenta = new CuentaCorrienteBuilder()
                .numeroCuenta(input.numeroCuenta())
                .titular(input.titular())
                .fechaApertura(fecha)
                .saldo(input.saldo())
                .cuotaManejo(input.cuotaManejo())
                .tipoCuenta(input.tipoCuenta())
                .build();

        // Guardar mediante el repositorio
        repositorio.guardar(cuenta);

        notificador.notificar(
                "CuentaCorriente",
                "CREAR",
                String.valueOf(cuenta.getNumeroCuenta())
        );

        // Devolver la cuenta registrada
        return Optional.of(cuenta);
    }



    //  ELIMINAR CUENTA


    public boolean eliminarCuenta(int numeroCuenta) {

        Optional<CuentaCorriente> cuentaEncontrada =
                repositorio.buscarPorNumeroCuenta(numeroCuenta);

        if (cuentaEncontrada.isEmpty()) {
            return false;
        }

        boolean eliminado = repositorio.eliminar(cuentaEncontrada.get());

        if (eliminado) {
            repositorioMovimientos.eliminarPorCuenta(numeroCuenta);
        }

        if (eliminado) {
            notificador.notificar(
                    "CuentaCorriente",
                    "ELIMINAR",
                    String.valueOf(numeroCuenta)
            );
        }

        return eliminado;
    }



    // ACTUALIZAR CUENTA


    public Optional<CuentaCorriente> actualizarCuenta(
            CuentaCorrienteInput input) {

        if (input == null) {
            throw new IllegalArgumentException(
                    "Los datos de la cuenta son obligatorios."
            );
        }

        // Buscar cuenta existente
        Optional<CuentaCorriente> cuentaEncontrada =
                repositorio.buscarPorNumeroCuenta(
                        input.numeroCuenta()
                );

        // Verificar que exista
        if (cuentaEncontrada.isEmpty()) {
            return Optional.empty();
        }


        LocalDateTime fecha = validarYObtenerFecha(input);

        CuentaCorriente cuenta = cuentaEncontrada.get();

        cuenta.setTitular(input.titular().trim());

        cuenta.setFechaApertura(fecha);

        cuenta.setSaldo(input.saldo());

        cuenta.setCuotaManejo(input.cuotaManejo());

        cuenta.setTipoCuenta(input.tipoCuenta().trim());

        repositorio.actualizar(cuenta);

        notificador.notificar(
                "CuentaCorriente",
                "ACTUALIZAR",
                String.valueOf(cuenta.getNumeroCuenta())
        );


        return Optional.of(cuenta);
    }


    // VALIDACIONES DE CUENTA CORRIENTE

    private LocalDateTime validarYObtenerFecha(
            CuentaCorrienteInput input) {

        if (input == null) {
            throw new IllegalArgumentException(
                    "Los datos de la cuenta son obligatorios."
            );
        }

        // Validar numero de cuenta
        if (input.numeroCuenta() <= 0) {
            throw new IllegalArgumentException(
                    "El numero de cuenta debe ser mayor a cero."
            );
        }

        // Validar titular
        if (input.titular() == null
                || input.titular().isBlank()) {

            throw new IllegalArgumentException(
                    "El titular es obligatorio."
            );
        }

        // Validar tipo de cuenta
        if (input.tipoCuenta() == null
                || input.tipoCuenta().isBlank()) {

            throw new IllegalArgumentException(
                    "El tipo de cuenta es obligatorio."
            );
        }

        // Validar saldo
        if (!Double.isFinite(input.saldo())
                || input.saldo() < 0) {

            throw new IllegalArgumentException(
                    "El saldo debe ser un numero valido y no negativo."
            );
        }

        // Validar cuota de manejo
        if (!Double.isFinite(input.cuotaManejo())
                || input.cuotaManejo() < 0) {

            throw new IllegalArgumentException(
                    "La cuota de manejo debe ser valida y no negativa."
            );
        }

        // Validar relacion saldo - cuota
        if (input.cuotaManejo() > input.saldo()) {

            throw new IllegalArgumentException(
                    "La cuota de manejo no puede ser mayor que el saldo."
            );
        }

        // Validar fecha
        if (input.fechaApertura() == null
                || input.fechaApertura().isBlank()) {

            throw new IllegalArgumentException(
                    "La fecha de apertura es obligatoria."
            );
        }

        try {

            return LocalDateTime.parse(
                    input.fechaApertura()
            );

        } catch (DateTimeParseException e) {

            throw new IllegalArgumentException(
                    "Formato de fecha invalido. Use yyyy-MM-ddTHH:mm:ss.",
                    e
            );
        }
    }

}