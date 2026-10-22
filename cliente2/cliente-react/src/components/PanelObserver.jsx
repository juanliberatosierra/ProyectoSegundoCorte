import { useEffect, useState } from "react";
import { obtenerCuentas } from "../controllers/CuentaController";
import { suscribir } from "../observer/NotificadorCambios";

export default function PanelObserver() {

    const [cuentas, setCuentas] = useState([]);
    const [mensaje, setMensaje] = useState("Esperando cambios...");
    const [error, setError] = useState("");

    async function cargarCuentas() {
        try {
            const resultado = await obtenerCuentas();

            setCuentas(resultado || []);
            setError("");

        } catch (err) {
            setError(err.message);
        }
    }

    useEffect(() => {

        // Cargar los datos al abrir la aplicación
        cargarCuentas();

        // Registrar el observador
        const cancelar = suscribir(
            "CUENTAS_ACTUALIZADAS",
            () => {
                console.log("Observer: listado notificado");

                setMensaje("Se detectó un cambio en las cuentas");

                cargarCuentas();
            }
        );

        // Cancelar suscripción cuando se desmonta
        return () => {
            cancelar();
        };

    }, []);

    return (
        <div className="tarjeta panel-observer">

            <h3>Observer - Cuentas registradas</h3>

            <p className="observer-estado">
                {mensaje}
            </p>

            {error && (
                <p className="mensaje-error">{error}</p>
            )}

            <table>
                <thead>
                    <tr>
                        <th>Número</th>
                        <th>Titular</th>
                    </tr>
                </thead>

                <tbody>
                    {cuentas.map((cuenta) => (
                        <tr key={cuenta.numeroCuenta}>
                            <td>{cuenta.numeroCuenta}</td>
                            <td>{cuenta.titular}</td>
                        </tr>
                    ))}
                </tbody>
            </table>

            <p>
                <strong>Total de cuentas:</strong> {cuentas.length}
            </p>

        </div>
    );
}