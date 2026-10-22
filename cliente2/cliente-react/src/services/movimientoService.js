import { ejecutarGraphQL } from "./graphqlService";

export async function agregarMovimiento(movimiento) {

    const mutation = `
        mutation AgregarMovimiento($input: MovimientoBancarioInput!) {
            agregarMovimiento(input: $input) {
                idMovimiento
                numeroCuenta
                tipoMovimiento
                monto
                fechaMovimiento
                descripcion
                confirmado
            }
        }
    `;

    const resultado = await ejecutarGraphQL(mutation, {
        input: movimiento
    });

    return resultado.agregarMovimiento;
}

export async function buscarMovimiento(numeroCuenta, idMovimiento) {

    const query = `
        query BuscarMovimiento($numeroCuenta: Int!, $idMovimiento: Int!) {
            buscarMovimiento(
                numeroCuenta: $numeroCuenta
                idMovimiento: $idMovimiento
            ) {
                idMovimiento
                numeroCuenta
                tipoMovimiento
                monto
                fechaMovimiento
                descripcion
                confirmado
            }
        }
    `;

    const resultado = await ejecutarGraphQL(query, {
        numeroCuenta: numeroCuenta,
        idMovimiento: idMovimiento
    });

    return resultado.buscarMovimiento;
}

export async function listarMovimientos(numeroCuenta, tipoMovimiento) {

    const query = `
        query ListarMovimientos(
            $numeroCuenta: Int
            $tipoMovimiento: String
        ) {
            listarMovimientos(
                numeroCuenta: $numeroCuenta
                tipoMovimiento: $tipoMovimiento
            ) {
                idMovimiento
                numeroCuenta
                tipoMovimiento
                monto
                fechaMovimiento
                descripcion
                confirmado
            }
        }
    `;

    const resultado = await ejecutarGraphQL(query, {
        numeroCuenta: numeroCuenta,
        tipoMovimiento: tipoMovimiento
    });

    return resultado.listarMovimientos;
}

export async function actualizarMovimiento(movimiento) {

    const mutation = `
        mutation ActualizarMovimiento($input: MovimientoBancarioInput!) {
            actualizarMovimiento(input: $input) {
                idMovimiento
                numeroCuenta
                tipoMovimiento
                monto
                fechaMovimiento
                descripcion
                confirmado
            }
        }
    `;

    const resultado = await ejecutarGraphQL(mutation, {
        input: movimiento
    });

    return resultado.actualizarMovimiento;
}

export async function eliminarMovimiento(numeroCuenta, idMovimiento) {

    const mutation = `
        mutation EliminarMovimiento(
            $numeroCuenta: Int!
            $idMovimiento: Int!
        ) {
            eliminarMovimiento(
                numeroCuenta: $numeroCuenta
                idMovimiento: $idMovimiento
            )
        }
    `;

    const resultado = await ejecutarGraphQL(mutation, {
        numeroCuenta: numeroCuenta,
        idMovimiento: idMovimiento
    });

    return resultado.eliminarMovimiento;
}