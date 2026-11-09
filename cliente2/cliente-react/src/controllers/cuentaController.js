import * as cuentaService from "../services/cuentaService";
import { notificar } from "../observer/NotificadorCambios";


// Filtros opcionales por si llegan vacíos se listan todas las cuentas
export async function obtenerCuentas(titular = "", tipoCuenta = "") {

    const filtroTitular = titular && titular.trim()
        ? titular.trim()
        : null;

    const filtroTipo = tipoCuenta
        ? tipoCuenta
        : null;

    return await cuentaService.listarCuentas(
        filtroTitular,
        filtroTipo
    );

}

export async function registrarCuenta(datos) {

    if (!Number.isInteger(datos.numeroCuenta)
        || datos.numeroCuenta <= 0) {

        throw new Error("El número de cuenta debe ser un entero positivo");
    }

    if (!datos.titular || !datos.titular.trim()) {

        throw new Error("El titular es obligatorio");
    }

    if (!Number.isFinite(datos.saldo) || datos.saldo < 0) {

        throw new Error("El saldo no puede ser negativo");
    }

    // La cuota de manejo es opcional: si viene vacía (null) no se valida
    if (datos.cuotaManejo !== null
        && (!Number.isFinite(datos.cuotaManejo) || datos.cuotaManejo < 0)) {

        throw new Error("La cuota de manejo no puede ser negativa");
    }

    if (datos.cuotaManejo !== null && datos.cuotaManejo > datos.saldo) {

        throw new Error("La cuota de manejo no puede superar el saldo");
    }

    const cuenta = await cuentaService.agregarCuenta(datos);

    notificar("CUENTAS_ACTUALIZADAS");

    return cuenta;
}

export async function consultarCuenta(numeroCuenta) {

    const numero = Number(numeroCuenta);

    if (!Number.isInteger(numero) || numero <= 0) {
        throw new Error("Ingrese un número de cuenta válido");
    }

    const cuenta = await cuentaService.buscarCuenta(numero);

    if (!cuenta) {
        throw new Error("No se encontró ninguna cuenta con ese número");
    }

    return cuenta;
}

export async function modificarCuenta(datos) {

    if (!Number.isInteger(datos.numeroCuenta) || datos.numeroCuenta <= 0) {
        throw new Error("Número de cuenta inválido");
    }

    if (!datos.titular || !datos.titular.trim()) {
        throw new Error("El titular es obligatorio");
    }

    if (!datos.fechaApertura) {
        throw new Error("La fecha de apertura es obligatoria");
    }

    if (!datos.tipoCuenta || !datos.tipoCuenta.trim()) {
        throw new Error("El tipo de cuenta es obligatorio");
    }

    if (!Number.isFinite(datos.saldo) || datos.saldo < 0) {
        throw new Error("El saldo no puede ser negativo");
    }

    // La cuota de manejo es opcional: si viene vacía (null) no se valida
    if (datos.cuotaManejo !== null
        && (!Number.isFinite(datos.cuotaManejo) || datos.cuotaManejo < 0)) {
        throw new Error("La cuota de manejo no puede ser negativa");
    }

    if (datos.cuotaManejo !== null && datos.cuotaManejo > datos.saldo) {
        throw new Error("La cuota de manejo no puede superar el saldo");
    }

    const cuenta = await cuentaService.actualizarCuenta(datos);

    if (!cuenta) {
        throw new Error("No se pudo actualizar la cuenta");
    }

    notificar("CUENTAS_ACTUALIZADAS");

    return cuenta;
}

export async function borrarCuenta(numeroCuenta) {

    const numero = Number(numeroCuenta);

    if (!Number.isInteger(numero) || numero <= 0) {
        throw new Error("Número de cuenta inválido");
    }

    const eliminada = await cuentaService.eliminarCuenta(numero);

    if (!eliminada) {
        throw new Error("No se pudo eliminar la cuenta");
    }

    notificar("CUENTAS_ACTUALIZADAS");
    
    return true;
}