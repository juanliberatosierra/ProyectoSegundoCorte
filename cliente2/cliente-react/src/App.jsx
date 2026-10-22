import { BrowserRouter, Routes, Route } from "react-router";

import Sidebar from "./components/Sidebars";
import PantallaPendiente from "./components/Sidebars";
import AgregarCuenta from "./views/AgregarCuenta";
import BuscarCuenta from "./views/BuscarCuenta";
import Inicio from "./views/Inicio";
import AcercaDe from "./views/AcercaDe";
import ListarCuentas from "./views/ListarCuentas";
import ActualizarCuenta from "./views/ActualizarCuenta";
import EliminarCuenta from "./views/EliminarCuenta";

import AgregarMovimiento from "./views/AgregarMovimiento";
import BuscarMovimiento from "./views/BuscarMovimiento";
import ListarMovimientos from "./views/ListarMovimientos";
import ActualizarMovimiento from "./views/ActualizarMovimiento"
import EliminarMovimiento from "./views/EliminarMovimiento";
import PanelObserver from "./components/PanelObserver";


function App() {

    return (
        <BrowserRouter>

            <div className="app-layout">

                <Sidebar />

                <main className="contenido">

                    <Routes>

                        <Route
                            path="/"
                            element={<Inicio />}
                        />

                        <Route
                            path="/cuentas/agregar"
                            element={<AgregarCuenta />}
                        />

                        <Route
                            path="/cuentas/buscar"
                            element={<BuscarCuenta />}
                        />

                        <Route
                            path="/cuentas/listar"
                            element={<ListarCuentas />}
                        />

                        <Route
                            path="/cuentas/actualizar"
                            element={<ActualizarCuenta />}
                        />

                        <Route
                            path="/cuentas/eliminar"
                            element={<EliminarCuenta />}
                        />

                        <Route
                            path="/movimientos/agregar"
                            element={<AgregarMovimiento />}
                        />

                        <Route
                            path="/movimientos/buscar"
                            element={<BuscarMovimiento />}
                        />

                        <Route
                            path="/movimientos/listar"
                            element={<ListarMovimientos />}
                        />

                        <Route
                            path="/movimientos/actualizar"
                            element={<ActualizarMovimiento />}
                        />

                        <Route
                            path="/movimientos/eliminar"
                            element={<EliminarMovimiento />}
                        />

                        <Route
                            path="/acerca-de"
                            element={<AcercaDe />}
                        />

                    </Routes>

                    <div className="app-layout">

                        <Sidebar />

                        <main className="contenido">

                            <Routes>
                                {/* Conserva aquí todas tus rutas actuales */}
                            </Routes>

                            <PanelObserver />

                        </main>

                    </div>

                </main>

            </div>

        </BrowserRouter>
    );
}

export default App;