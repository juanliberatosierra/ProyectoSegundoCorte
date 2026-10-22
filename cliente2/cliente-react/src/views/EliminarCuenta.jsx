import { useState } from "react";

import {
    consultarCuenta,
    borrarCuenta
} from "../controllers/cuentaController";


export default function EliminarCuenta() {

    const [numeroBusqueda, setNumeroBusqueda] = useState("");
    const [cuenta, setCuenta] = useState(null);

    const [error, setError] = useState("");
    const [mensaje, setMensaje] = useState("");
    const [cargando, setCargando] = useState(false);


    async function buscar(evento) {

        evento.preventDefault();

        setError("");
        setMensaje("");
        setCuenta(null);
        setCargando(true);

        try {

            const resultado = await consultarCuenta(numeroBusqueda);

            setCuenta(resultado);

        } catch (err) {

            setError(err.message);

        } finally {

            setCargando(false);
        }
    }


    async function eliminar() {

        if (!cuenta || cargando) {
            return;
        }

        const confirmacion = window.confirm(
            `¿Estás seguro de eliminar la cuenta ${cuenta.numeroCuenta}?\n\n` +
            `Titular: ${cuenta.titular}\n` +
            `Movimientos asociados: ${cuenta.movimientos?.length ?? 0}\n\n` +
            `Esta acción no se puede deshacer.`
        );

        if (!confirmacion) {
            return;
        }

        setError("");
        setMensaje("");
        setCargando(true);

        try {

            await borrarCuenta(cuenta.numeroCuenta);

            setMensaje(
                `La cuenta ${cuenta.numeroCuenta} fue eliminada correctamente`
            );

            setCuenta(null);
            setNumeroBusqueda("");

        } catch (err) {

            setError(err.message);

        } finally {

            setCargando(false);
        }
    }


    function formatearDinero(valor) {

        return Number(valor).toLocaleString("es-CO", {
            style: "currency",
            currency: "COP",
            maximumFractionDigits: 2
        });
    }


    return (
        <div className="pagina">

            <h1>Eliminar cuenta corriente</h1>

            <div className="tarjeta formulario-contenedor">

                <form onSubmit={buscar}>

                    <div className="campo">

                        <label>Número de cuenta</label>

                        <input
                            type="number"
                            min="1"
                            step="1"
                            value={numeroBusqueda}
                            onChange={(e) => {
                                setNumeroBusqueda(e.target.value);
                                setCuenta(null);
                                setMensaje("");
                            }}
                            placeholder="Ingrese el número de cuenta"
                            required
                        />

                    </div>

                    <button type="submit" disabled={cargando}>
                        {cargando ? "Procesando..." : "Buscar cuenta"}
                    </button>

                </form>

            </div>


            {error && (
                <p className="mensaje-error">
                    {error}
                </p>
            )}

            {mensaje && (
                <p className="mensaje-exito">
                    {mensaje}
                </p>
            )}


            {cuenta && (

                <div className="tarjeta">

                    <h2>Información de la cuenta</h2>

                    <div className="detalle-cuenta">

                        <p>
                            <strong>Número:</strong>{" "}
                            {cuenta.numeroCuenta}
                        </p>

                        <p>
                            <strong>Titular:</strong>{" "}
                            {cuenta.titular}
                        </p>

                        <p>
                            <strong>Fecha de apertura:</strong>{" "}
                            {cuenta.fechaApertura}
                        </p>

                        <p>
                            <strong>Saldo:</strong>{" "}
                            {formatearDinero(cuenta.saldo)}
                        </p>

                        <p>
                            <strong>Cuota de manejo:</strong>{" "}
                            {formatearDinero(cuenta.cuotaManejo)}
                        </p>

                        <p>
                            <strong>Tipo:</strong>{" "}
                            {cuenta.tipoCuenta}
                        </p>

                        <p>
                            <strong>Estado:</strong>{" "}
                            {cuenta.activa ? "Activa" : "Inactiva"}
                        </p>

                    </div>


                    <h2>Movimientos asociados</h2>

                    {cuenta.movimientos?.length > 0 ? (

                        <table>

                            <thead>
                                <tr>
                                    <th>ID</th>
                                    <th>Tipo</th>
                                    <th>Monto</th>
                                    <th>Fecha</th>
                                    <th>Descripción</th>
                                    <th>Confirmado</th>
                                </tr>
                            </thead>

                            <tbody>

                                {cuenta.movimientos.map((movimiento) => (

                                    <tr key={movimiento.idMovimiento}>

                                        <td>{movimiento.idMovimiento}</td>

                                        <td>{movimiento.tipoMovimiento}</td>

                                        <td>
                                            {formatearDinero(movimiento.monto)}
                                        </td>

                                        <td>{movimiento.fechaMovimiento}</td>

                                        <td>{movimiento.descripcion}</td>

                                        <td>
                                            {movimiento.confirmado ? "Sí" : "No"}
                                        </td>

                                    </tr>

                                ))}

                            </tbody>

                        </table>

                    ) : (

                        <p>Esta cuenta no tiene movimientos registrados.</p>

                    )}


                    <div className="advertencia-eliminar">

                        <strong>Advertencia</strong>

                        <p>
                            Al eliminar esta cuenta también dejarán
                            de estar disponibles todos sus movimientos
                            asociados.
                        </p>

                        <p>
                            Esta operación no se puede deshacer.
                        </p>

                    </div>


                    <button
                        type="button"
                        className="btn-eliminar"
                        onClick={eliminar}
                        disabled={cargando}
                    >
                        {cargando ? "Eliminando..." : "Eliminar cuenta"}
                    </button>

                </div>

            )}

        </div>
    );
}