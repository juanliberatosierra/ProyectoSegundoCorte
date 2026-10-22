import { useEffect, useState } from "react";
import { obtenerCuentas } from "../controllers/cuentaController";
import { suscribir } from "../observer/NotificadorCambios";


export default function ListarCuentas() {

    const [cuentas, setCuentas] = useState([]);
    const [cargando, setCargando] = useState(true);
    const [error, setError] = useState("");

    async function cargarCuentas() {

        try {
            setCargando(true);
            setError("");

            const resultado = await obtenerCuentas();

            setCuentas(resultado);

        } catch (error) {

            setError(error.message);

        } finally {

            setCargando(false);

        }
    }

    useEffect(() => {

        cargarCuentas();

        const cancelar = suscribir(
            "CUENTAS_ACTUALIZADAS",
            cargarCuentas
        );

        return () => {
            cancelar();
        };

    }, []);

    return (
        <div>
            <h1>Listado de cuentas corrientes</h1>

            <button onClick={cargarCuentas}>
                Actualizar listado
            </button>

            {cargando && <p>Cargando cuentas...</p>}

            {error && <p style={{ color: "red" }}>{error}</p>}

            {!cargando && !error && (
                <table border="1" cellPadding="10">
                    <thead>
                        <tr>
                            <th>Número</th>
                            <th>Titular</th>
                            <th>Saldo</th>
                            <th>Cuota de manejo</th>
                            <th>Tipo</th>
                            <th>Estado</th>
                        </tr>
                    </thead>

                    <tbody>
                        {cuentas.map((cuenta) => (
                            <tr key={cuenta.numeroCuenta}>
                                <td>{cuenta.numeroCuenta}</td>
                                <td>{cuenta.titular}</td>
                                <td>{cuenta.saldo}</td>
                                <td>{cuenta.cuotaManejo}</td>
                                <td>{cuenta.tipoCuenta}</td>
                                <td>
                                    {cuenta.activa ? "Activa" : "Inactiva"}
                                </td>
                            </tr>
                        ))}
                    </tbody>
                </table>
            )}
        </div>
    );
}