import * as movimientoService from "../services/movimientoService";
import { notificar } from "../observer/NotificadorCambios";

export async function registrarMovimiento(datos) {

    if (!Number.isInteger(datos.idMovimiento) ||
        datos.idMovimiento <= 0) {

        throw new Error("El ID del movimiento debe ser un entero positivo");
    }

    if (!Number.isInteger(datos.numeroCuenta) ||
        datos.numeroCuenta <= 0) {

        throw new Error("El número de cuenta debe ser un entero positivo");
    }

    if (datos.tipoMovimiento !== "DEPOSITO" &&
        datos.tipoMovimiento !== "RETIRO") {

        throw new Error("Seleccione un tipo de movimiento válido");
    }

    if (!Number.isFinite(datos.monto) || datos.monto <= 0) {

        throw new Error("El monto debe ser mayor a cero");
    }

    if (!datos.fechaMovimiento) {

        throw new Error("La fecha del movimiento es obligatoria");
    }

    if (!datos.descripcion || !datos.descripcion.trim()) {

        throw new Error("La descripción es obligatoria");
    }

    const movimiento = await movimientoService.agregarMovimiento(datos);

    notificar("MOVIMIENTOS_ACTUALIZADOS");

    return movimiento;

    return await movimientoService.agregarMovimiento(datos);
}

export async function consultarMovimiento(numeroCuenta, idMovimiento) {

    const numero = Number(numeroCuenta);
    const id = Number(idMovimiento);

    if (!Number.isInteger(numero) || numero <= 0) {
        throw new Error("Ingrese un número de cuenta válido");
    }

    if (!Number.isInteger(id) || id <= 0) {
        throw new Error("Ingrese un ID de movimiento válido");
    }

    const movimiento = await movimientoService.buscarMovimiento(numero, id);

    if (!movimiento) {
        throw new Error("No se encontró el movimiento en la cuenta indicada");
    }

    return movimiento;
}

export async function obtenerMovimientos(numeroCuenta, tipoMovimiento) {

    let numero = null;
    let tipo = null;

    if (numeroCuenta !== "") {

        numero = Number(numeroCuenta);

        if (!Number.isInteger(numero) || numero <= 0) {
            throw new Error("Ingrese un número de cuenta válido");
        }
    }

    if (tipoMovimiento !== "") {
        tipo = tipoMovimiento;
    }

    return await movimientoService.listarMovimientos(numero, tipo);
}

export async function modificarMovimiento(datos) {

    if (!Number.isInteger(datos.numeroCuenta) || datos.numeroCuenta <= 0) {
        throw new Error("Número de cuenta inválido");
    }

    if (!Number.isInteger(datos.idMovimiento) || datos.idMovimiento <= 0) {
        throw new Error("ID del movimiento inválido");
    }

    if (datos.tipoMovimiento !== "DEPOSITO" &&
        datos.tipoMovimiento !== "RETIRO") {
        throw new Error("Tipo de movimiento inválido");
    }

    if (!Number.isFinite(datos.monto) || datos.monto <= 0) {
        throw new Error("El monto debe ser mayor a cero");
    }

    if (!datos.fechaMovimiento) {
        throw new Error("La fecha es obligatoria");
    }

    if (!datos.descripcion || !datos.descripcion.trim()) {
        throw new Error("La descripción es obligatoria");
    }

    const movimiento = await movimientoService.actualizarMovimiento(datos);

    if (!movimiento) {
        throw new Error("No se pudo actualizar el movimiento");
    }

    notificar("MOVIMIENTOS_ACTUALIZADOS");

    return movimiento;
}

export async function borrarMovimiento(numeroCuenta, idMovimiento) {

    const numero = Number(numeroCuenta);
    const id = Number(idMovimiento);

    if (!Number.isInteger(numero) || numero <= 0) {
        throw new Error("Número de cuenta inválido");
    }

    if (!Number.isInteger(id) || id <= 0) {
        throw new Error("ID del movimiento inválido");
    }

    const eliminado = await movimientoService.eliminarMovimiento(
        numero,
        id
    );

    if (!eliminado) {
        throw new Error("No se pudo eliminar el movimiento");
    }

    notificar("MOVIMIENTOS_ACTUALIZADOS");

    return true;
}