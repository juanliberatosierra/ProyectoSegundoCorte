using System.Text.Json.Serialization;

namespace POCCuentaCorriente.model
{
    // Movimiento bancario tal como lo devuelve el servidor
    public class MovimientoData
    {
        [JsonPropertyName("idMovimiento")]
        public int idMovimiento { get; set; }

        [JsonPropertyName("numeroCuenta")]
        public int numeroCuenta { get; set; }

        [JsonPropertyName("tipoMovimiento")]
        public string tipoMovimiento { get; set; }

        [JsonPropertyName("monto")]
        public double monto { get; set; }

        [JsonPropertyName("fechaMovimiento")]
        public string fechaMovimiento { get; set; }

        [JsonPropertyName("descripcion")]
        public string descripcion { get; set; }

        [JsonPropertyName("confirmado")]
        public bool confirmado { get; set; }
    }

    // Resultado de la consulta personalizada listarMovimientosConCuenta:
    // datos del movimiento + 2 atributos de la cuenta (titular y tipo de cuenta)
    public class MovimientoDetalleData : MovimientoData
    {
        [JsonPropertyName("titularCuenta")]
        public string titularCuenta { get; set; }

        [JsonPropertyName("tipoCuenta")]
        public string tipoCuenta { get; set; }
    }

    // Datos que se envían al servidor para agregar o actualizar
    public class MovimientoBancarioInput
    {
        [JsonPropertyName("idMovimiento")]
        public int idMovimiento { get; set; }

        [JsonPropertyName("numeroCuenta")]
        public int numeroCuenta { get; set; }

        [JsonPropertyName("tipoMovimiento")]
        public string tipoMovimiento { get; set; }

        [JsonPropertyName("monto")]
        public double monto { get; set; }

        [JsonPropertyName("fechaMovimiento")]
        public string fechaMovimiento { get; set; }

        [JsonPropertyName("descripcion")]
        public string descripcion { get; set; }

        [JsonPropertyName("confirmado")]
        public bool confirmado { get; set; }
    }

    // Respuestas de cada operación GraphQL
    public class AgregarMovimientoResponse
    {
        [JsonPropertyName("agregarMovimiento")]
        public MovimientoData agregarMovimiento { get; set; }
    }

    public class BuscarMovimientoResponse
    {
        [JsonPropertyName("buscarMovimiento")]
        public MovimientoData buscarMovimiento { get; set; }
    }

    public class ListarMovimientosConCuentaResponse
    {
        [JsonPropertyName("listarMovimientosConCuenta")]
        public MovimientoDetalleData[] listarMovimientosConCuenta { get; set; }
    }

    public class ActualizarMovimientoResponse
    {
        [JsonPropertyName("actualizarMovimiento")]
        public MovimientoData actualizarMovimiento { get; set; }
    }

    public class EliminarMovimientoResponse
    {
        [JsonPropertyName("eliminarMovimiento")]
        public bool eliminarMovimiento { get; set; }
    }
}
