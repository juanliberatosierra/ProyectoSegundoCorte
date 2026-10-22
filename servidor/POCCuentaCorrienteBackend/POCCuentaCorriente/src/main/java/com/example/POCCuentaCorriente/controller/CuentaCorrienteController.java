package com.example.POCCuentaCorriente.controller;

import com.example.POCCuentaCorriente.model.CuentaCorriente;
import com.example.POCCuentaCorriente.model.CuentaCorrienteInput;

import com.example.POCCuentaCorriente.servicios.ServicioCuentaCorriente;

import org.springframework.graphql.data.method.annotation.Argument;
import org.springframework.graphql.data.method.annotation.QueryMapping;
import org.springframework.graphql.data.method.annotation.MutationMapping;

import org.springframework.stereotype.Controller;

import java.util.List;
import java.util.Optional;


@Controller
public class CuentaCorrienteController {

    // Dependencia del servicio
    private final ServicioCuentaCorriente servicioCuentaCorriente;


    // Inyeccion de dependencias
    public CuentaCorrienteController(
            ServicioCuentaCorriente servicioCuentaCorriente) {

        this.servicioCuentaCorriente = servicioCuentaCorriente;
    }

    @QueryMapping
    public List<CuentaCorriente> listarCuentas(
            @Argument("titular") String titular,
            @Argument("tipoCuenta") String tipoCuenta) {

        return servicioCuentaCorriente.listarCuentas(
                titular,
                tipoCuenta
        );
    }

    @QueryMapping
    public Optional<CuentaCorriente> buscarCuenta(
            @Argument("numeroCuenta") int numeroCuenta) {

        return servicioCuentaCorriente
                .buscarPorNumeroCuenta(numeroCuenta);
    }

    @MutationMapping
    public Optional<CuentaCorriente> agregarCuenta(
            @Argument("input") CuentaCorrienteInput input) {

        return servicioCuentaCorriente.agregarCuenta(input);
    }

    @MutationMapping
    public boolean eliminarCuenta(
            @Argument("numeroCuenta") int numeroCuenta) {

        return servicioCuentaCorriente.eliminarCuenta(numeroCuenta);
    }

    @MutationMapping
    public Optional<CuentaCorriente> actualizarCuenta(
            @Argument("input") CuentaCorrienteInput input) {

        return servicioCuentaCorriente.actualizarCuenta(input);
    }

}