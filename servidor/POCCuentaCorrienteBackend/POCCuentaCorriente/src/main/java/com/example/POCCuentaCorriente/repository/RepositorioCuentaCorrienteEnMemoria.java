package com.example.POCCuentaCorriente.repository;

import com.example.POCCuentaCorriente.model.CuentaCorriente;

import org.springframework.stereotype.Repository;
import org.springframework.context.annotation.Scope;
import org.springframework.beans.factory.config.ConfigurableBeanFactory;

import java.util.ArrayList;
import java.util.List;
import java.util.Optional;

@Repository
@Scope(ConfigurableBeanFactory.SCOPE_SINGLETON)
public class RepositorioCuentaCorrienteEnMemoria
        implements RepositorioCuentaCorriente {


    private final List<CuentaCorriente> cuentas = new ArrayList<>();



    @Override
    public synchronized List<CuentaCorriente> listar() {

        return new ArrayList<>(cuentas);

    }



    @Override
    public synchronized Optional<CuentaCorriente> buscarPorNumeroCuenta(
            int numeroCuenta) {

        return cuentas.stream()
                .filter(cuenta ->
                        cuenta.getNumeroCuenta() == numeroCuenta)
                .findFirst();

    }



    @Override
    public synchronized void guardar(CuentaCorriente cuenta) {

        if (cuenta == null) {
            throw new IllegalArgumentException(
                    "La cuenta no puede ser nula"
            );
        }

        if (buscarPorNumeroCuenta(cuenta.getNumeroCuenta()).isPresent()) {

            throw new IllegalArgumentException(
                    "Ya existe una cuenta con ese numero"
            );

        }

        cuentas.add(cuenta);

    }



    @Override
    public synchronized boolean eliminar(CuentaCorriente cuenta) {

        return cuentas.remove(cuenta);

    }

}