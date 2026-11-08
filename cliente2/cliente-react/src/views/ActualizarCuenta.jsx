import { useState } from "react";
import {
    consultarCuenta,
    modificarCuenta
} from "../controllers/cuentaController";

export default function ActualizarCuenta() {

    const [numeroBusqueda, setNumeroBusqueda] = useState("");
    const [cuentaOriginal, setCuentaOriginal] = useState(null);
    const [formulario, setFormulario] = useState(null);

    const [error, setError] = useState("");
    const [mensaje, setMensaje] = useState("");
    const [cargando, setCargando] = useState(false);

    async function buscar(evento) {

        evento.preventDefault();

        setError("");
        setMensaje("");
        setCuentaOriginal(null);
        setFormulario(null);
        setCargando(true);

        try {

            const cuenta = await consultarCuenta(numeroBusqueda);

            setCuentaOriginal(cuenta);

            setFormulario({
                numeroCuenta: cuenta.numeroCuenta,
                titular: cuenta.titular,
                fechaApertura: cuenta.fechaApertura.slice(0, 16),
                saldo: String(cuenta.saldo),
                cuotaManejo: String(cuenta.cuotaManejo),
                tipoCuenta: cuenta.tipoCuenta
            });

        } catch (err) {

            setError(err.message);

        } finally {

            setCargando(false);
        }
    }

    function manejarCambio(evento) {

        const { name, value } = evento.target;

        setFormulario({
            ...formulario,
            [name]: value
        });
    }

    async function guardar(evento) {

        evento.preventDefault();

        setError("");
        setMensaje("");
        setCargando(true);

        try {

            if (!formulario.saldo || !formulario.cuotaManejo) {
                throw new Error("Completa los valores de saldo y cuota");
            }

            const datos = {
                numeroCuenta: cuentaOriginal.numeroCuenta,
                titular: formulario.titular.trim(),
                fechaApertura: formulario.fechaApertura,
                saldo: Number(formulario.saldo),
                cuotaManejo: Number(formulario.cuotaManejo),
                tipoCuenta: formulario.tipoCuenta
            };

            const actualizada = await modificarCuenta(datos);

            setMensaje(
                `Cuenta ${actualizada.numeroCuenta} actualizada correctamente`
            );

            // Ocultamos el formulario para exigir una nueva búsqueda
            setCuentaOriginal(null);
            setFormulario(null);

        } catch (err) {

            setError(err.message);

        } finally {

            setCargando(false);
        }
    }

    return (
        <div className="pagina">

            <h1>Actualizar cuenta corriente</h1>

            <div className="tarjeta formulario-contenedor">

                <form onSubmit={buscar}>

                    <div className="campo">
                        <label>Número de cuenta</label>

                        <input
                            type="number"
                            min="1"
                            step="1"
                            value={numeroBusqueda}
                            onChange={(e) => setNumeroBusqueda(e.target.value)}
                            placeholder="Ingrese el número de cuenta"
                            required
                        />
                    </div>

                    <button type="submit" disabled={cargando}>
                        {cargando ? "Buscando..." : "Buscar cuenta"}
                    </button>

                </form>

            </div>

            {error && (
                <p className="mensaje-error">{error}</p>
            )}

            {mensaje && (
                <p className="mensaje-exito">{mensaje}</p>
            )}

            {cuentaOriginal && formulario && (

                <div className="tarjeta formulario-contenedor">

                    <h2>Datos de la cuenta</h2>

                    <p>
                        <strong>Número:</strong>{" "}
                        {cuentaOriginal.numeroCuenta}
                    </p>

                    <p>
                        <strong>Estado:</strong>{" "}
                        {cuentaOriginal.activa ? "Activa" : "Inactiva"}
                    </p>

                    <p>
                        <strong>Movimientos asociados:</strong>{" "}
                        {cuentaOriginal.movimientos?.length ?? 0}
                    </p>

                    <form onSubmit={guardar}>

                        <div className="campo">
                            <label>Titular</label>

                            <input
                                type="text"
                                name="titular"
                                value={formulario.titular}
                                onChange={manejarCambio}
                                required
                            />
                        </div>

                        <div className="campo">
                            <label>Fecha de apertura</label>

                            <input
                                type="datetime-local"
                                name="fechaApertura"
                                value={formulario.fechaApertura}
                                onChange={manejarCambio}
                                required
                            />
                        </div>

                        <div className="campo">
                            <label>Saldo</label>

                            <input
                                type="number"
                                name="saldo"
                                min="0"
                                step="0.01"
                                value={formulario.saldo}
                                onChange={manejarCambio}
                                required
                            />
                        </div>

                        <div className="campo">
                            <label>Cuota de manejo</label>

                            <input
                                type="number"
                                name="cuotaManejo"
                                min="0"
                                step="0.01"
                                value={formulario.cuotaManejo}
                                onChange={manejarCambio}
                                required
                            />
                        </div>

                        <div className="campo">
                            <label>Tipo de cuenta</label>

                            <select
                                name="tipoCuenta"
                                value={formulario.tipoCuenta}
                                onChange={manejarCambio}
                            >
                                <option value="PERSONAL">Personal</option>
                                <option value="EMPRESARIAL">Empresarial</option>
                            </select>
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