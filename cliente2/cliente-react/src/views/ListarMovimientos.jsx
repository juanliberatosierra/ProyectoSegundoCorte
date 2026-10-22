import { useEffect, useState } from "react";
import { obtenerMovimientos } from "../controllers/MovimientoController";
import { suscribir } from "../observer/NotificadorCambios";

export default function ListarMovimientos() {

    const [numeroCuenta, setNumeroCuenta] = useState("");
    const [tipoMovimiento, setTipoMovimiento] = useState("");

    const [movimientos, setMovimientos] = useState([]);
    const [cargando, setCargando] = useState(false);
    const [error, setError] = useState("");

    async function cargarMovimientos() {

        setError("");
        setCargando(true);

        try {

            const resultado = await obtenerMovimientos(
                numeroCuenta,
                tipoMovimiento
            );

            setMovimientos(resultado || []);

        } catch (err) {

            setError(err.message);
            setMovimientos([]);

        } finally {

            setCargando(false);
        }
    }

    function manejarBusqueda(evento) {

        evento.preventDefault();

        cargarMovimientos();
    }

    useEffect(() => {

        cargarMovimientos();

        const cancelar = suscribir(
            "MOVIMIENTOS_ACTUALIZADOS",
            cargarMovimientos
        );

        return () => {
            cancelar();
        };

    }, []);

    function formatearDinero(valor) {

        return Number(valor).toLocaleString("es-CO", {
            style: "currency",
            currency: "COP",
            maximumFractionDigits: 2
        });
    }

    return (
        <div className="pagina">

            <h1>Listado de movimientos bancarios</h1>

            <div className="tarjeta">

                <form onSubmit={manejarBusqueda}>

                    <div className="filtros-movimientos">

                        <div className="campo">
                            <label>Número de cuenta</label>

                            <input
                                type="number"
                                min="1"
                                step="1"
                                placeholder="Todas las cuentas"
                                value={numeroCuenta}
                                onChange={(e) =>
                                    setNumeroCuenta(e.target.value)
                                }
                            />
                        </div>

                        <div className="campo">
                            <label>Tipo de movimiento</label>

                            <select
                                value={tipoMovimiento}
                                onChange={(e) =>
                                    setTipoMovimiento(e.target.value)
                                }
                            >
                                <option value="">Todos</option>
                                <option value="DEPOSITO">Depósitos</option>
                                <option value="RETIRO">Retiros</option>
                            </select>
                        </div>

                    </div>

                    <button type="submit" disabled={cargando}>
                        {cargando ? "Consultando..." : "Buscar movimientos"}
                    </button>

                </form>

            </div>

            {error && (
                <p className="mensaje-error">{error}</p>
            )}

            <div className="tarjeta">

                <h2>Movimientos registrados</h2>

                {cargando ? (

                    <p>Cargando movimientos...</p>

                ) : movimientos.length === 0 ? (

                    <p>No se encontraron movimientos.</p>

                ) : (

                    <>
                        <table>

                            <thead>
                                <tr>
                                    <th>ID</th>
                                    <th>Cuenta</th>
                                    <th>Tipo</th>
                                    <th>Monto</th>
                                    <th>Fecha</th>
                                    <th>Descripción</th>
                                    <th>Confirmado</th>
                                </tr>
                            </thead>

                            <tbody>

                                {movimientos.map((movimiento) => (

                                    <tr
                                        key={`${movimiento.numeroCuenta}-${movimiento.idMovimiento}`}
                                    >
                                        <td>{movimiento.idMovimiento}</td>

                                        <td>{movimiento.numeroCuenta}</td>

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

                        <p>
                            <strong>Total de movimientos:</strong>{" "}
                            {movimientos.length}
                        </p>
                    </>

                )}

            </div>

        </div>
    );
}