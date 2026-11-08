import { useState } from "react";

import {
    consultarMovimiento,
    modificarMovimiento
} from "../controllers/MovimientoController";

export default function ActualizarMovimiento() {

    const [numeroBusqueda, setNumeroBusqueda] = useState("");
    const [idBusqueda, setIdBusqueda] = useState("");

    const [movimientoOriginal, setMovimientoOriginal] = useState(null);
    const [formulario, setFormulario] = useState(null);

    const [error, setError] = useState("");
    const [mensaje, setMensaje] = useState("");
    const [cargando, setCargando] = useState(false);

    async function buscar(evento) {

        evento.preventDefault();

        setError("");
        setMensaje("");
        setMovimientoOriginal(null);
        setFormulario(null);
        setCargando(true);

        try {

            const movimiento = await consultarMovimiento(
                numeroBusqueda,
                idBusqueda
            );

            setMovimientoOriginal(movimiento);

            setFormulario({
                tipoMovimiento: movimiento.tipoMovimiento,
                monto: String(movimiento.monto),
                fechaMovimiento: movimiento.fechaMovimiento.slice(0, 16),
                descripcion: movimiento.descripcion || "",
                confirmado: movimiento.confirmado
            });

        } catch (err) {

            setError(err.message);

        } finally {

            setCargando(false);
        }
    }

    function manejarCambio(evento) {

        const { name, value, type, checked } = evento.target;

        setFormulario({
            ...formulario,
            [name]: type === "checkbox" ? checked : value
        });
    }

    async function guardar(evento) {

        evento.preventDefault();

        setError("");
        setMensaje("");
        setCargando(true);

        try {

            if (!formulario.monto || !formulario.fechaMovimiento) {
                throw new Error("Completa los campos obligatorios");
            }

            const datos = {
                numeroCuenta: movimientoOriginal.numeroCuenta,
                idMovimiento: movimientoOriginal.idMovimiento,
                tipoMovimiento: formulario.tipoMovimiento,
                monto: Number(formulario.monto),
                fechaMovimiento: formulario.fechaMovimiento,
                descripcion: formulario.descripcion.trim(),
                confirmado: formulario.confirmado
            };

            const actualizado = await modificarMovimiento(datos);

            setMensaje(
                `Movimiento ${actualizado.idMovimiento} actualizado correctamente`
            );

            setMovimientoOriginal(null);
            setFormulario(null);

        } catch (err) {

            setError(err.message);

        } finally {

            setCargando(false);
        }
    }

    return (
        <div className="pagina">

            <h1>Actualizar movimiento bancario</h1>

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
                                setMovimientoOriginal(null);
                                setFormulario(null);
                            }}
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
                                setMovimientoOriginal(null);
                                setFormulario(null);
                            }}
                            required
                        />
                    </div>

                    <button type="submit" disabled={cargando}>
                        {cargando ? "Buscando..." : "Buscar movimiento"}
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

            {movimientoOriginal && formulario && (

                <div className="tarjeta formulario-contenedor">

                    <h2>Datos del movimiento</h2>

                    <div className="detalle-cuenta">

                        <p>
                            <strong>Número de cuenta:</strong>{" "}
                            {movimientoOriginal.numeroCuenta}
                        </p>

                        <p>
                            <strong>ID del movimiento:</strong>{" "}
                            {movimientoOriginal.idMovimiento}
                        </p>

                    </div>

                    <form onSubmit={guardar}>

                        <div className="campo">
                            <label>Tipo de movimiento</label>

                            <select
                                name="tipoMovimiento"
                                value={formulario.tipoMovimiento}
                                onChange={manejarCambio}
                            >
                                <option value="DEPOSITO">
                                    Depósito
                                </option>

                                <option value="RETIRO">
                                    Retiro
                                </option>
                            </select>
                        </div>

                        <div className="campo">
                            <label>Monto</label>

                            <input
                                type="number"
                                name="monto"
                                min="0.01"
                                step="0.01"
                                value={formulario.monto}
                                onChange={manejarCambio}
                                required
                            />
                        </div>

                        <div className="campo">
                            <label>Fecha y hora</label>

                            <input
                                type="datetime-local"
                                name="fechaMovimiento"
                                value={formulario.fechaMovimiento}
                                onChange={manejarCambio}
                                required
                            />
                        </div>

                        <div className="campo">
                            <label>Descripción</label>

                            <input
                                type="text"
                                name="descripcion"
                                value={formulario.descripcion}
                                onChange={manejarCambio}
                                required
                            />
                        </div>

                        <div className="campo">
                            <label>
                                <input
                                    type="checkbox"
                                    name="confirmado"
                                    checked={formulario.confirmado}
                                    onChange={manejarCambio}
                                />
                                {" "}Movimiento confirmado
                            </label>
                        </div>

                        <button type="submit" disabled={cargando}>
                            {cargando ? "Guardando..." : "Guardar cambios"}
                        </button>

                    </form>

                </div>

            )}

        </div>
    );
}