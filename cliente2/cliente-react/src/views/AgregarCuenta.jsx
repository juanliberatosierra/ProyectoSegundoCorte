import { useState } from "react";
import { registrarCuenta } from "../controllers/cuentaController";

const datosIniciales = {
    numeroCuenta: "",
    titular: "",
    fechaApertura: "",
    saldo: "",
    cuotaManejo: "",
    tipoCuenta: "PERSONAL"
};

export default function AgregarCuenta() {

    const [formulario, setFormulario] = useState(datosIniciales);
    const [mensaje, setMensaje] = useState("");
    const [error, setError] = useState("");
    const [guardando, setGuardando] = useState(false);

    function manejarCambio(evento) {

        const { name, value } = evento.target;

        setFormulario({
            ...formulario,
            [name]: value
        });
    }

    async function manejarEnvio(evento) {

        evento.preventDefault();

        setMensaje("");
        setError("");
        setGuardando(true);

        try {

            const datos = {
                numeroCuenta: Number(formulario.numeroCuenta),
                titular: formulario.titular.trim(),
                fechaApertura: formulario.fechaApertura,
                saldo: Number(formulario.saldo),
                cuotaManejo: Number(formulario.cuotaManejo),
                tipoCuenta: formulario.tipoCuenta
            };

            if (!formulario.numeroCuenta ||
                    !formulario.saldo ||
                    !formulario.cuotaManejo ||
                    !formulario.fechaApertura) {

                throw new Error("Completa todos los campos obligatorios");
            }

            const cuenta = await registrarCuenta(datos);

            setMensaje(
                `Cuenta ${cuenta.numeroCuenta} registrada correctamente`
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

            <h1>Agregar cuenta corriente</h1>

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
                        <label>Saldo inicial</label>

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
                            <option value="PERSONAL">
                                Personal
                            </option>

                            <option value="EMPRESARIAL">
                                Empresarial
                            </option>
                        </select>
                    </div>

                    <button type="submit" disabled={guardando}>
                        {guardando ? "Registrando..." : "Registrar cuenta"}
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