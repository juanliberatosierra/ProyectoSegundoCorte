import { useState } from "react";
import { consultarMovimiento } from "../controllers/MovimientoController";

export default function BuscarMovimiento() {

    const [numeroCuenta, setNumeroCuenta] = useState("");
    const [idMovimiento, setIdMovimiento] = useState("");

    const [movimiento, setMovimiento] = useState(null);

    const [error, setError] = useState("");
    const [cargando, setCargando] = useState(false);

    async function manejarBusqueda(evento) {

        evento.preventDefault();

        setError("");
        setMovimiento(null);
        setCargando(true);

        try {

            const resultado = await consultarMovimiento(
                numeroCuenta,
                idMovimiento
            );

            setMovimiento(resultado);

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

            <h1>Buscar movimiento bancario</h1>

            <div className="tarjeta formulario-contenedor">

                <form onSubmit={manejarBusqueda}>

                    <div className="campo">
                        <label>Número de cuenta</label>

                        <input
                            type="number"
                            min="1"
                            step="1"
                            value={numeroCuenta}
                            onChange={(e) => {
                                setNumeroCuenta(e.target.value);
                                setMovimiento(null);
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
                            value={idMovimiento}
                            onChange={(e) => {
                                setIdMovimiento(e.target.value);
                                setMovimiento(null);
                            }}
                            placeholder="Ingrese el ID"
                            required
                        />
                    </div>

                    <button type="submit" disabled={cargando}>
                        {cargando ? "Buscando..." : "Buscar movimiento"}
                    </button>

                </form>

                {error && (
                    <p className="mensaje-error">
                        {error}
                    </p>
                )}

            </div>

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

                </div>

            )}

        </div>
    );
}