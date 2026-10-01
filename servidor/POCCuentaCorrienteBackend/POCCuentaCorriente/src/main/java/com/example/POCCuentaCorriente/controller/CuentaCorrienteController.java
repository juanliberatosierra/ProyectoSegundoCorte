package com.example.POCCuentaCorriente.controller;

import com.example.POCCuentaCorriente.model.CuentaCorriente;
import com.example.POCCuentaCorriente.model.CuentaCorrienteInput;
import com.example.POCCuentaCorriente.servicios.ServicioCuentaCorriente;
import org.springframework.graphql.data.method.annotation.Argument;
import org.springframework.graphql.data.method.annotation.MutationMapping;
import org.springframework.graphql.data.method.annotation.QueryMapping;
import org.springframework.stereotype.Controller;

import java.util.List;
import java.util.Optional;

@Controller
public class CuentaCorrienteController {

    @QueryMapping
    public List<CuentaCorriente> listarCuentas(
            @Argument String titular,
            @Argument String tipoCuenta) {

        return ServicioCuentaCorriente.listarCuentas(
                titular,
                tipoCuenta
        );
    }

    @QueryMapping
    public Optional<CuentaCorriente> buscarCuenta(
            @Argument int numeroCuenta) {

        return ServicioCuentaCorriente.buscarPorNumeroCuenta(numeroCuenta);
    }

    @MutationMapping
    public Optional<CuentaCorriente> agregarCuenta(
            @Argument CuentaCorrienteInput input) {

        return ServicioCuentaCorriente.agregarCuenta(input);
    }

    @MutationMapping
    public boolean eliminarCuenta(
            @Argument int numeroCuenta) {

        return ServicioCuentaCorriente.eliminarCuenta(numeroCuenta);
    }

    @MutationMapping
    public Optional<CuentaCorriente> actualizarCuenta(
            @Argument CuentaCorrienteInput input) {

        return ServicioCuentaCorriente.actualizarCuenta(input);
    }
}