package com.example.POCCuentaCorriente.repository;

import com.example.POCCuentaCorriente.model.CuentaCorriente;

import java.util.List;
import java.util.Optional;

public interface RepositorioCuentaCorriente {

    List<CuentaCorriente> listar();

    Optional<CuentaCorriente> buscarPorNumeroCuenta(int numeroCuenta);

    void guardar(CuentaCorriente cuenta);

    boolean eliminar(CuentaCorriente cuenta);

}