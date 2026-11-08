import { NavLink } from "react-router";

export default function Sidebar() {

    return (
        <aside className="sidebar">

            <h2 className="sidebar-logo">Sistema Bancario</h2>

            <nav>
                <NavLink to="/" end>
                    Inicio
                </NavLink>

                <h3>Cuentas corrientes</h3>

                <NavLink to="/cuentas/agregar">
                    Agregar cuenta
                </NavLink>

                <NavLink to="/cuentas/buscar">
                    Buscar cuenta
                </NavLink>

                <NavLink to="/cuentas/listar">
                    Listar cuentas
                </NavLink>

                <NavLink to="/cuentas/actualizar">
                    Actualizar cuenta
                </NavLink>

                <NavLink to="/cuentas/eliminar">
                    Eliminar cuenta
                </NavLink>

                <h3>Movimientos bancarios</h3>

                <NavLink to="/movimientos/agregar">
                    Agregar movimiento
                </NavLink>

                <NavLink to="/movimientos/buscar">
                    Buscar movimiento
                </NavLink>

                <NavLink to="/movimientos/listar">
                    Listar movimientos
                </NavLink>

                <NavLink to="/movimientos/actualizar">
                    Actualizar movimiento
                </NavLink>

                <NavLink to="/movimientos/eliminar">
                    Eliminar movimiento
                </NavLink>

                <h3>Ayuda</h3>

                <NavLink to="/acerca-de">
                    Acerca de
                </NavLink>
            </nav>

        </aside>
    );
}