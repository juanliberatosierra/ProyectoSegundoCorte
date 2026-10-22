package com.example.POCCuentaCorriente.controller;

import com.example.POCCuentaCorriente.model.MovimientoBancario;
import com.example.POCCuentaCorriente.model.MovimientoBancarioInput;

import com.example.POCCuentaCorriente.servicios.ServicioMovimientoBancario;

import java.util.List;

import org.springframework.graphql.data.method.annotation.Argument;
import org.springframework.graphql.data.method.annotation.MutationMapping;
import org.springframework.stereotype.Controller;
import org.springframework.graphql.data.method.annotation.QueryMapping;

@Controller
public class MovimientoBancarioController {


    private final ServicioMovimientoBancario servicioMovimientoBancario;


    public MovimientoBancarioController(
            ServicioMovimientoBancario servicioMovimientoBancario) {

        this.servicioMovimientoBancario = servicioMovimientoBancario;
    }


    @MutationMapping
    public MovimientoBancario agregarMovimiento(
            @Argument("input") MovimientoBancarioInput input) {

        return servicioMovimientoBancario.agregarMovimiento(input);
    }

    @QueryMapping
    public MovimientoBancario buscarMovimiento(
            @Argument("numeroCuenta") int numeroCuenta,
            @Argument("idMovimiento") int idMovimiento) {

        return servicioMovimientoBancario.buscarMovimiento(
                numeroCuenta,
                idMovimiento
        );
    }


    @QueryMapping
    public List<MovimientoBancario> listarMovimientos(
            @Argument("numeroCuenta") Integer numeroCuenta,
            @Argument("tipoMovimiento") String tipoMovimiento) {

        return servicioMovimientoBancario.listarMovimientos(
                numeroCuenta,
                tipoMovimiento
        );
    }

    @MutationMapping
    public MovimientoBancario actualizarMovimiento(
            @Argument("input") MovimientoBancarioInput input) {

        return servicioMovimientoBancario.actualizarMovimiento(input);
    }


    @MutationMapping
    public boolean eliminarMovimiento(
            @Argument("numeroCuenta") int numeroCuenta,
            @Argument("idMovimiento") int idMovimiento) {

        return servicioMovimientoBancario.eliminarMovimiento(
                numeroCuenta,
                idMovimiento
        );
    }



}