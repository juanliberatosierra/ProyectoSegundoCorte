import { useState } from "react";
import { registrarMovimiento } from "../controllers/MovimientoController";

const datosIniciales = {
    numeroCuenta: "",
    idMovimiento: "",
    tipoMovimiento: "DEPOSITO",
    monto: "",
    fechaMovimiento: "",
    descripcion: "",
    confirmado: false
};

export default function AgregarMovimiento() {

    const [formulario, setFormulario] = useState(datosIniciales);
    const [mensaje, setMensaje] = useState("");
    const [error, setError] = useState("");
    const [guardando, setGuardando] = useState(false);

    function manejarCambio(evento) {

        const { name, value, type, checked } = evento.target;

        setFormulario({
            ...formulario,
            [name]: type === "checkbox" ? checked : value
        });
    }

    async function manejarEnvio(evento) {

        evento.preventDefault();

        setMensaje("");
        setError("");
        setGuardando(true);

        try {

            if (!formulario.numeroCuenta ||
                    !formulario.idMovimiento ||
                    !formulario.monto ||
                    !formulario.fechaMovimiento ||
                    !formulario.descripcion.trim()) {

                throw new Error("Complete todos los campos obligatorios");
            }

            const datos = {
                numeroCuenta: Number(formulario.numeroCuenta),
                idMovimiento: Number(formulario.idMovimiento),
                tipoMovimiento: formulario.tipoMovimiento,
                monto: Number(formulario.monto),
                fechaMovimiento: formulario.fechaMovimiento,
                descripcion: formulario.descripcion.trim(),
                confirmado: formulario.confirmado
            };

            const movimiento = await registrarMovimiento(datos);

            setMensaje(
                `Movimiento ${movimiento.idMovimiento} registrado correctamente en la cuenta ${movimiento.numeroCuenta}`
            );

            setFormulario(datosIniciales);

        } catch (err) {

            setError(err.message);

        } finally {

            setGuardando(false);
        }
    }

    return (
        <div className="pagina">

            <h1>Agregar movimiento bancario</h1>

            <div className="tarjeta formulario-contenedor">

                <form onSubmit={manejarEnvio}>

                    <div className="campo">
                        <label>Número de cuenta</label>

                        <input
                            type="number"
                            name="numeroCuenta"
                            min="1"
                            step="1"
                            value={formulario.numeroCuenta}
                            onChange={manejarCambio}
                            required
                        />
                    </div>

                    <div className="campo">
                        <label>ID del movimiento</label>

                        <input
                            type="number"
                            name="idMovimiento"
                            min="1"
                            step="1"
                            value={formulario.idMovimiento}
                            onChange={manejarCambio}
                            required
                        />
                    </div>

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
                            placeholder="Descripción del movimiento"
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

                    <button type="submit" disabled={guardando}>
                        {guardando
                            ? "Registrando..."
                            : "Registrar movimiento"}
                    </button>

                </form>

                {mensaje && (
                    <p className="mensaje-exito">
                        {mensaje}
                    </p>
                )}

                {error && (
                    <p className="mensaje-error">
                        {error}
                    </p>
                )}

            </div>

        </div>
    );
}