import { ejecutarGraphQL } from "./graphqlService";

export async function listarCuentas() {

    const query = `
        query {
            listarCuentas {
                numeroCuenta
                titular
                saldo
                cuotaManejo
                tipoCuenta
                activa
            }
        }
    `;

    const resultado = await ejecutarGraphQL(query);

    return resultado.listarCuentas;
}

export async function agregarCuenta(cuenta) {

    const mutation = `
        mutation AgregarCuenta($input: CuentaCorrienteInput!) {
            agregarCuenta(input: $input) {
                numeroCuenta
                titular
                saldo
                tipoCuenta
                activa
            }
        }
    `;

    const resultado = await ejecutarGraphQL(mutation, {
        input: cuenta
    });

    return resultado.agregarCuenta;
}

export async function buscarCuenta(numeroCuenta) {

    const query = `
        query BuscarCuenta($numeroCuenta: Int!) {
            buscarCuenta(numeroCuenta: $numeroCuenta) {
                numeroCuenta
                titular
                fechaApertura
                saldo
                cuotaManejo
                tipoCuenta
                activa

                movimientos {
                    idMovimiento
                    tipoMovimiento
                    monto
                    fechaMovimiento
                    descripcion
                    confirmado
                }
            }
        }
    `;

    const resultado = await ejecutarGraphQL(query, {
        numeroCuenta: numeroCuenta
    });

    return resultado.buscarCuenta;
}

export async function actualizarCuenta(cuenta) {

    const mutation = `
        mutation ActualizarCuenta($input: CuentaCorrienteInput!) {
            actualizarCuenta(input: $input) {
                numeroCuenta
                titular
                fechaApertura
                saldo
                cuotaManejo
                tipoCuenta
                activa
            }
        }
    `;

    const resultado = await ejecutarGraphQL(mutation, {
        input: cuenta
    });

    return resultado.actualizarCuenta;
}

export async function eliminarCuenta(numeroCuenta) {

    const mutation = `
        mutation EliminarCuenta($numeroCuenta: Int!) {
            eliminarCuenta(numeroCuenta: $numeroCuenta)
        }
    `;

    const resultado = await ejecutarGraphQL(mutation, {
        numeroCuenta: numeroCuenta
    });

    return resultado.eliminarCuenta;
}