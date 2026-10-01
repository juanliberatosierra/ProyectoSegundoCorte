using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace POCCuentaCorriente.model
{
    internal class ResponseCuentaCorriente
    {
        [JsonPropertyName("buscarCuenta")]
        public CuentaCorrienteData cuenta { get; set; }
    }

    public class CuentaCorrienteData
    {
        [JsonPropertyName("numeroCuenta")]
        public int numeroCuenta { get; set; }

        [JsonPropertyName("titular")]
        public string titular { get; set; }

        [JsonPropertyName("fechaApertura")]
        public string fechaApertura { get; set; }

        [JsonPropertyName("saldo")]
        public double saldo { get; set; }

        [JsonPropertyName("cuotaManejo")]
        public double cuotaManejo { get; set; }

        [JsonPropertyName("tipoCuenta")]
        public string tipoCuenta { get; set; }
    }

    public class AddCuentaResponse
    {
        [JsonPropertyName("agregarCuenta")]
        public CuentaCorrienteData agregarCuenta { get; set; }
    }

    public class CuentaCorrienteInput
    {
        [JsonPropertyName("numeroCuenta")]
        public int numeroCuenta { get; set; }

        [JsonPropertyName("titular")]
        public string titular { get; set; }

        [JsonPropertyName("fechaApertura")]
        public string fechaApertura { get; set; }

        [JsonPropertyName("saldo")]
        public double saldo { get; set; }

        [JsonPropertyName("cuotaManejo")]
        public double cuotaManejo { get; set; }

        [JsonPropertyName("tipoCuenta")]
        public string tipoCuenta { get; set; }
    }

    public class ListarCuentasResponse
    {
        [JsonPropertyName("listarCuentas")]
        public CuentaCorrienteData[] listarCuentas { get; set; }
    }
    public class ActualizarCuentaResponse
    {
        [JsonPropertyName("actualizarCuenta")]
        public CuentaCorrienteData actualizarCuenta { get; set; }
    }
    public class EliminarCuentaResponse
    {
        [JsonPropertyName("eliminarCuenta")]
        public bool eliminarCuenta { get; set; }
    }
}