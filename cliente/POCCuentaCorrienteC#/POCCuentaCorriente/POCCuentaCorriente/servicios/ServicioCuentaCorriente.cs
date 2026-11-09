using System;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.SystemTextJson;
using POCCuentaCorriente.model;

namespace POCCuentaCorriente.servicios
{
    
    public class ServicioCuentaCorriente : IDisposable
    {
        private const string URL_SERVIDOR = "http://localhost:8081/graphql";

        private const string CAMPOS_CUENTA = @"
                numeroCuenta
                titular
                fechaApertura
                saldo
                cuotaManejo
                tipoCuenta";

        private readonly GraphQLHttpClient cliente;

        public ServicioCuentaCorriente()
        {
            cliente = new GraphQLHttpClient(
                URL_SERVIDOR,
                new SystemTextJsonSerializer());
        }

        // AGREGAR
        public async Task<CuentaCorrienteData> AgregarAsync(CuentaCorrienteInput input)
        {
            var request = new GraphQLRequest
            {
                Query = @"
                    mutation agregarCuenta($input: CuentaCorrienteInput!) {
                        agregarCuenta(input: $input) {" + CAMPOS_CUENTA + @"
                        }
                    }",
                Variables = new { input = input }
            };

            var response =
                await cliente.SendMutationAsync<AddCuentaResponse>(request);

            VerificarErrores(response.Errors);

            return response.Data == null ? null : response.Data.agregarCuenta;
        }

        // BUSCAR UNA (devuelve null si no existe)
        public async Task<CuentaCorrienteData> BuscarAsync(int numeroCuenta)
        {
            var request = new GraphQLRequest
            {
                Query = @"
                    query buscarCuenta($numeroCuenta: Int!) {
                        buscarCuenta(numeroCuenta: $numeroCuenta) {" + CAMPOS_CUENTA + @"
                        }
                    }",
                Variables = new { numeroCuenta = numeroCuenta }
            };

            var response =
                await cliente.SendQueryAsync<ResponseCuentaCorriente>(request);

            VerificarErrores(response.Errors);

            return response.Data == null ? null : response.Data.cuenta;
        }

        // LISTAR CON FILTROS
        // titular vacío -> todos los titulares; tipoCuenta "Todos" o vacío -> todos los tipos
        public async Task<CuentaCorrienteData[]> ListarAsync(string titular, string tipoCuenta)
        {
            var request = new GraphQLRequest
            {
                Query = @"
                    query listarCuentas($titular: String, $tipoCuenta: String) {
                        listarCuentas(titular: $titular, tipoCuenta: $tipoCuenta) {" + CAMPOS_CUENTA + @"
                        }
                    }",
                Variables = new
                {
                    titular = titular,
                    tipoCuenta = tipoCuenta
                }
            };

            var response =
                await cliente.SendQueryAsync<ListarCuentasResponse>(request);

            VerificarErrores(response.Errors);

            if (response.Data == null || response.Data.listarCuentas == null)
            {
                return new CuentaCorrienteData[0];
            }

            return response.Data.listarCuentas;
        }

        // ACTUALIZAR (devuelve null si la cuenta no existe)
        public async Task<CuentaCorrienteData> ActualizarAsync(CuentaCorrienteInput input)
        {
            var request = new GraphQLRequest
            {
                Query = @"
                    mutation actualizarCuenta($input: CuentaCorrienteInput!) {
                        actualizarCuenta(input: $input) {" + CAMPOS_CUENTA + @"
                        }
                    }",
                Variables = new { input = input }
            };

            var response =
                await cliente.SendMutationAsync<ActualizarCuentaResponse>(request);

            VerificarErrores(response.Errors);

            return response.Data == null ? null : response.Data.actualizarCuenta;
        }

        // ELIMINAR (true si se eliminó)
        public async Task<bool> EliminarAsync(int numeroCuenta)
        {
            var request = new GraphQLRequest
            {
                Query = @"
                    mutation eliminarCuenta($numeroCuenta: Int!) {
                        eliminarCuenta(numeroCuenta: $numeroCuenta)
                    }",
                Variables = new { numeroCuenta = numeroCuenta }
            };

            var response =
                await cliente.SendMutationAsync<EliminarCuentaResponse>(request);

            VerificarErrores(response.Errors);

            return response.Data != null && response.Data.eliminarCuenta;
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