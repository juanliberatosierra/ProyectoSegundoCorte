using System;
using System.Globalization;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.SystemTextJson;
using POCCuentaCorriente.model;

namespace POCCuentaCorriente.servicios
{
    /// <summary>
    /// Clase estructural: se encarga de TODA la comunicación GraphQL de los
    /// movimientos bancarios. Las ventanas (vista) solo llaman estos métodos.
    /// Si el servidor responde con un error de validación, se lanza una
    /// InvalidOperationException con el mensaje que mandó el servidor.
    /// </summary>
    public class ServicioMovimientoBancario : IDisposable
    {
        private const string URL_SERVIDOR = "http://localhost:8081/graphql";

        private const string CAMPOS_MOVIMIENTO = @"
                idMovimiento
                numeroCuenta
                tipoMovimiento
                monto
                fechaMovimiento
                descripcion
                confirmado";

        private readonly GraphQLHttpClient cliente;

        public ServicioMovimientoBancario()
        {
            cliente = new GraphQLHttpClient(
                URL_SERVIDOR,
                new SystemTextJsonSerializer());
        }

        // AGREGAR
        public async Task<MovimientoData> AgregarAsync(MovimientoBancarioInput input)
        {
            var request = new GraphQLRequest
            {
                Query = @"
                    mutation agregarMovimiento($input: MovimientoBancarioInput!) {
                        agregarMovimiento(input: $input) {" + CAMPOS_MOVIMIENTO + @"
                        }
                    }",
                Variables = new { input = input }
            };

            var response =
                await cliente.SendMutationAsync<AgregarMovimientoResponse>(request);

            VerificarErrores(response.Errors);

            return response.Data == null ? null : response.Data.agregarMovimiento;
        }

        // BUSCAR UNO (devuelve null si no existe)
        public async Task<MovimientoData> BuscarAsync(int numeroCuenta, int idMovimiento)
        {
            var request = new GraphQLRequest
            {
                Query = @"
                    query buscarMovimiento($numeroCuenta: Int!, $idMovimiento: Int!) {
                        buscarMovimiento(numeroCuenta: $numeroCuenta, idMovimiento: $idMovimiento) {" + CAMPOS_MOVIMIENTO + @"
                        }
                    }",
                Variables = new
                {
                    numeroCuenta = numeroCuenta,
                    idMovimiento = idMovimiento
                }
            };

            var response =
                await cliente.SendQueryAsync<BuscarMovimientoResponse>(request);

            VerificarErrores(response.Errors);

            return response.Data == null ? null : response.Data.buscarMovimiento;
        }

        // LISTAR CON FILTROS (consulta personalizada: movimiento + titular y tipo de cuenta)
        // numeroCuenta = null -> todas las cuentas; tipoMovimiento = null -> todos los tipos
        public async Task<MovimientoDetalleData[]> ListarConCuentaAsync(
            int? numeroCuenta,
            string tipoMovimiento)
        {
            var request = new GraphQLRequest
            {
                Query = @"
                    query listarMovimientosConCuenta($numeroCuenta: Int, $tipoMovimiento: String) {
                        listarMovimientosConCuenta(numeroCuenta: $numeroCuenta, tipoMovimiento: $tipoMovimiento) {" + CAMPOS_MOVIMIENTO + @"
                            titularCuenta
                            tipoCuenta
                        }
                    }",
                Variables = new
                {
                    numeroCuenta = numeroCuenta,
                    tipoMovimiento = tipoMovimiento
                }
            };

            var response =
                await cliente.SendQueryAsync<ListarMovimientosConCuentaResponse>(request);

            VerificarErrores(response.Errors);

            if (response.Data == null || response.Data.listarMovimientosConCuenta == null)
            {
                return new MovimientoDetalleData[0];
            }

            return response.Data.listarMovimientosConCuenta;
        }

        // ACTUALIZAR (devuelve null si el movimiento no existe)
        public async Task<MovimientoData> ActualizarAsync(MovimientoBancarioInput input)
        {
            var request = new GraphQLRequest
            {
                Query = @"
                    mutation actualizarMovimiento($input: MovimientoBancarioInput!) {
                        actualizarMovimiento(input: $input) {" + CAMPOS_MOVIMIENTO + @"
                        }
                    }",
                Variables = new { input = input }
            };

            var response =
                await cliente.SendMutationAsync<ActualizarMovimientoResponse>(request);

            VerificarErrores(response.Errors);

            return response.Data == null ? null : response.Data.actualizarMovimiento;
        }

        // ELIMINAR (true si se eliminó)
        public async Task<bool> EliminarAsync(int numeroCuenta, int idMovimiento)
        {
            var request = new GraphQLRequest
            {
                Query = @"
                    mutation eliminarMovimiento($numeroCuenta: Int!, $idMovimiento: Int!) {
                        eliminarMovimiento(numeroCuenta: $numeroCuenta, idMovimiento: $idMovimiento)
                    }",
                Variables = new
                {
                    numeroCuenta = numeroCuenta,
                    idMovimiento = idMovimiento
                }
            };

            var response =
                await cliente.SendMutationAsync<EliminarMovimientoResponse>(request);

            VerificarErrores(response.Errors);

            return response.Data != null && response.Data.eliminarMovimiento;
        }

        // Fecha del DateTimePicker -> texto que entiende el servidor (LocalDateTime)
        public static string FechaParaServidor(DateTime fecha)
        {
            return fecha.ToString("yyyy-MM-dd'T'HH:mm:ss", CultureInfo.InvariantCulture);
        }

        // Texto que manda el servidor ("2024-07-01T08:00") -> DateTime
        public static DateTime FechaDesdeServidor(string fecha)
        {
            return DateTime.Parse(fecha, CultureInfo.InvariantCulture);
        }

        // Texto que manda el servidor -> formato legible para mostrar
        public static string FechaParaMostrar(string fecha)
        {
            try
            {
                return FechaDesdeServidor(fecha).ToString("yyyy-MM-dd HH:mm");
            }
            catch (FormatException)
            {
                return fecha;
            }
        }

        private static void VerificarErrores(GraphQLError[] errores)
        {
            if (errores != null && errores.Length > 0)
            {
                throw new InvalidOperationException(errores[0].Message);
            }
        }

        public void Dispose()
        {
            cliente.Dispose();
        }
    }
}
