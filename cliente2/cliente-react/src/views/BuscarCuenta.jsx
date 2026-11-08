import { useState } from "react";
import { consultarCuenta } from "../controllers/cuentaController";

export default function BuscarCuenta() {

    const [numeroCuenta, setNumeroCuenta] = useState("");
    const [cuenta, setCuenta] = useState(null);
    const [error, setError] = useState("");
    const [cargando, setCargando] = useState(false);

    async function manejarBusqueda(evento) {

        evento.preventDefault();

        setError("");
        setCuenta(null);
        setCargando(true);

        try {

            const resultado = await consultarCuenta(numeroCuenta);

            setCuenta(resultado);

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

            <h1>Buscar cuenta corriente</h1>

            <div className="tarjeta formulario-contenedor">

                <form onSubmit={manejarBusqueda}>

                    <div className="campo">

                        <label>Número de cuenta</label>

                        <input
                            type="number"
                            min="1"
                            step="1"
                            value={numeroCuenta}
                            onChange={(e) => setNumeroCuenta(e.target.value)}
                            placeholder="Ingrese el número de cuenta"
                            required
                        />

                    </div>

                    <button type="submit" disabled={cargando}>
                        {cargando ? "Buscando..." : "Buscar cuenta"}
                    </button>

                </form>

                {error && (
                    <p className="mensaje-error">
                        {error}
                    </p>
                )}

            </div>

            {cuenta && (

                <div className="tarjeta">

                    <h2>Información de la cuenta</h2>

                    <div className="detalle-cuenta">

                        <p>
                            <strong>Número:</strong> {cuenta.numeroCuenta}
                        </p>

                        <p>
                            <strong>Titular:</strong> {cuenta.titular}
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
                            <strong>Tipo de cuenta:</strong>{" "}
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

                </div>

            )}

        </div>
    );
}