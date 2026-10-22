import { useState } from "react";

import {
    consultarMovimiento,
    borrarMovimiento
} from "../controllers/MovimientoController";

export default function EliminarMovimiento() {

    const [numeroBusqueda, setNumeroBusqueda] = useState("");
    const [idBusqueda, setIdBusqueda] = useState("");

    const [movimiento, setMovimiento] = useState(null);

    const [error, setError] = useState("");
    const [mensaje, setMensaje] = useState("");
    const [cargando, setCargando] = useState(false);

    async function buscar(evento) {

        evento.preventDefault();

        setError("");
        setMensaje("");
        setMovimiento(null);
        setCargando(true);

        try {

            const resultado = await consultarMovimiento(
                numeroBusqueda,
                idBusqueda
            );

            setMovimiento(resultado);

        } catch (err) {

            setError(err.message);

        } finally {

            setCargando(false);
        }
    }

    async function eliminar() {

        if (!movimiento || cargando) {
            return;
        }

        const confirmacion = window.confirm(
            `¿Estás seguro de eliminar este movimiento?\n\n` +
            `Cuenta: ${movimiento.numeroCuenta}\n` +
            `ID: ${movimiento.idMovimiento}\n` +
            `Tipo: ${movimiento.tipoMovimiento}\n` +
            `Monto: ${formatearDinero(movimiento.monto)}\n\n` +
            `Esta acción no se puede deshacer.`
        );

        if (!confirmacion) {
            return;
        }

        setError("");
        setMensaje("");
        setCargando(true);

        try {

            await borrarMovimiento(
                movimiento.numeroCuenta,
                movimiento.idMovimiento
            );

            setMensaje(
                `Movimiento ${movimiento.idMovimiento} eliminado correctamente de la cuenta ${movimiento.numeroCuenta}`
            );

            setMovimiento(null);
            setNumeroBusqueda("");
            setIdBusqueda("");

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

            <h1>Eliminar movimiento bancario</h1>

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
                                setMovimiento(null);
                                setMensaje("");
                            }}
                            placeholder="Ingrese el número de cuenta"
                            required
                        />
                    </div>

                    <div className="campo">
                        <label>ID del movimiento</label>

                        <input
                            type="number"
                            min="1"
                            step="1"
                            value={idBusqueda}
                            onChange={(e) => {
                                setIdBusqueda(e.target.value);
                                setMovimiento(null);
                                setMensaje("");
                            }}
                            placeholder="Ingrese el ID del movimiento"
                            required
                        />
                    </div>

                    <button type="submit" disabled={cargando}>
                        {cargando ? "Procesando..." : "Buscar movimiento"}
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

            {movimiento && (

                <div className="tarjeta">

                    <h2>Información del movimiento</h2>

                    <div className="detalle-cuenta">

                        <p>
                            <strong>ID:</strong>{" "}
                            {movimiento.idMovimiento}
                        </p>

                        <p>
                            <strong>Número de cuenta:</strong>{" "}
                            {movimiento.numeroCuenta}
                        </p>

                        <p>
                            <strong>Tipo:</strong>{" "}
                            {movimiento.tipoMovimiento}
                        </p>

                        <p>
                            <strong>Monto:</strong>{" "}
                            {formatearDinero(movimiento.monto)}
                        </p>

                        <p>
                            <strong>Fecha:</strong>{" "}
                            {movimiento.fechaMovimiento}
                        </p>

                        <p>
                            <strong>Descripción:</strong>{" "}
                            {movimiento.descripcion}
                        </p>

                        <p>
                            <strong>Confirmado:</strong>{" "}
                            {movimiento.confirmado ? "Sí" : "No"}
                        </p>

                    </div>

                    <div className="advertencia-eliminar">

                        <strong>Advertencia</strong>

                        <p>
                            Estás a punto de eliminar este movimiento
                            bancario de la cuenta.
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
                        {cargando
                            ? "Eliminando..."
                            : "Eliminar movimiento"}
                    </button>

                </div>

            )}

        </div>
    );
}