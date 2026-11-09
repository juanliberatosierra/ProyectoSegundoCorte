import { useEffect, useState } from "react";
import { obtenerCuentas } from "../controllers/cuentaController";
import { suscribir } from "../observer/NotificadorCambios";


export default function ListarCuentas() {

    const [cuentas, setCuentas] = useState([]);
    const [cargando, setCargando] = useState(true);
    const [error, setError] = useState("");

    // Lo que el usuario escribe/selecciona en los filtros
    const [titular, setTitular] = useState("");
    const [tipoCuenta, setTipoCuenta] = useState("");

    // Filtros con los que se hizo la última búsqueda
    const [filtrosAplicados, setFiltrosAplicados] = useState({
        titular: "",
        tipoCuenta: ""
    });

    async function cargarCuentas(filtros) {

        try {
            setCargando(true);
            setError("");

            const resultado = await obtenerCuentas(
                filtros.titular,
                filtros.tipoCuenta
            );

            setCuentas(resultado || []);

        } catch (error) {

            setError(error.message);

        } finally {

            setCargando(false);

        }
    }

    function manejarBusqueda(evento) {

        evento.preventDefault();

        setFiltrosAplicados({
            titular: titular.trim(),
            tipoCuenta: tipoCuenta
        });
    }

    useEffect(() => {

        cargarCuentas(filtrosAplicados);

        const cancelar = suscribir(
            "CUENTAS_ACTUALIZADAS",
            () => cargarCuentas(filtrosAplicados)
        );

        return () => {
            cancelar();
        };

    }, [filtrosAplicados]);

    return (
        <div>
            <h1>Listado de cuentas corrientes</h1>

            <div className="tarjeta">

                <form onSubmit={manejarBusqueda}>

                    <div className="filtros-movimientos">

                        <div className="campo">
                            <label>Titular</label>

                            <input
                                type="text"
                                placeholder="Todos los titulares"
                                value={titular}
                                onChange={(e) =>
                                    setTitular(e.target.value)
                                }
                            />
                        </div>

                        <div className="campo">
                            <label>Tipo de cuenta</label>

                            <select
                                value={tipoCuenta}
                                onChange={(e) =>
                                    setTipoCuenta(e.target.value)
                                }
                            >
                                <option value="">Todos</option>
                                <option value="PERSONAL">Personal</option>
                                <option value="EMPRESARIAL">Empresarial</option>
                            </select>
                        </div>

                    </div>

                    <button type="submit" disabled={cargando}>
                        {cargando ? "Consultando..." : "Buscar cuentas"}
                    </button>

                </form>

            </div>

            <button
                style={{ marginTop: "20px", marginBottom: "20px" }}
                onClick={() => cargarCuentas(filtrosAplicados)}
            >
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