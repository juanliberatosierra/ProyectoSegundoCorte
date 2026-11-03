package com.example.POCCuentaCorriente.repository;

import com.example.POCCuentaCorriente.model.MovimientoBancario;
import com.example.POCCuentaCorriente.model.MovimientoDetalle;

import java.util.List;
import java.util.Optional;

public interface RepositorioMovimientoBancario {


    List<MovimientoBancario> listar(Integer numeroCuenta, String tipoMovimiento);

    List<MovimientoBancario> listarPorCuenta(int numeroCuenta);

    Optional<MovimientoBancario> buscar(int numeroCuenta, int idMovimiento);

    void guardar(MovimientoBancario movimiento);

    void actualizar(MovimientoBancario movimiento);

    boolean eliminar(int numeroCuenta, int idMovimiento);

    long eliminarPorCuenta(int numeroCuenta);

    // Consulta personalizada: movimiento + titular y tipo de su cuenta ($lookup)
    List<MovimientoDetalle> listarConDatosCuenta(Integer numeroCuenta, String tipoMovimiento);
}
