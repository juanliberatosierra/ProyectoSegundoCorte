package com.example.POCCuentaCorriente.repository;

import com.example.POCCuentaCorriente.model.CuentaCorriente;

import java.util.List;
import java.util.Optional;

public interface RepositorioCuentaCorriente {

    List<CuentaCorriente> listar();

    Optional<CuentaCorriente> buscarPorNumeroCuenta(int numeroCuenta);

    List<CuentaCorriente> listarConFiltros(String titular, String tipoCuenta);

    void guardar(CuentaCorriente cuenta);

    void actualizar(CuentaCorriente cuenta);

    boolean eliminar(CuentaCorriente cuenta);

}