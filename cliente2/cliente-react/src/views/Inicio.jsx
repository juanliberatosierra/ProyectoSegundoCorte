export default function Inicio() {

    return (
        <div className="pagina">

            <h1>Bienvenido al Sistema Bancario</h1>

            <p>
                Aplicación para gestionar cuentas corrientes
                y sus movimientos bancarios.
            </p>

            <div className="tarjeta">
                <h3>Gestión de cuentas</h3>

                <p>
                    Registra, consulta, actualiza y elimina
                    cuentas corrientes.
                </p>
            </div>

            <div className="tarjeta">
                <h3>Movimientos bancarios</h3>

                <p>
                    Administra los movimientos asociados
                    a cada cuenta corriente.
                </p>
            </div>

        </div>
    );
}