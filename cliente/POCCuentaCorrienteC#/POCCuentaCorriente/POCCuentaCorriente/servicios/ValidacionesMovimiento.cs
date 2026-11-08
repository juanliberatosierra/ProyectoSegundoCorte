using System;
using System.Globalization;

namespace POCCuentaCorriente.servicios
{
    /// <summary>
    /// Validaciones de los datos que el usuario escribe en las ventanas de
    /// movimientos. Si un dato es inválido lanzan ArgumentException con un
    /// mensaje para mostrar al usuario.
    /// </summary>
    public static class ValidacionesMovimiento
    {
        public static int LeerEnteroPositivo(string texto, string nombreCampo)
        {
            int valor;

            if (!int.TryParse((texto ?? "").Trim(), out valor) || valor <= 0)
            {
                throw new ArgumentException(
                    "El campo \"" + nombreCampo + "\" debe ser un número entero mayor a cero.");
            }

            return valor;
        }

        // Lee el monto sin depender de la configuración regional del computador:
        //   "50000"  "50000,5"  "50000.5"  "50.000"  "1.250.000,75"  "1,250,000.75"
        public static double LeerMonto(string texto)
        {
            string limpio = (texto ?? "").Trim().Replace(" ", "").Replace("$", "");

            int ultimaComa = limpio.LastIndexOf(',');
            int ultimoPunto = limpio.LastIndexOf('.');

            if (ultimaComa >= 0 && ultimoPunto >= 0)
            {
                // Tiene los dos: el que aparece de último es el decimal
                if (ultimaComa > ultimoPunto)
                {
                    limpio = limpio.Replace(".", "").Replace(",", ".");
                }
                else
                {
                    limpio = limpio.Replace(",", "");
                }
            }
            else if (ultimaComa >= 0 || ultimoPunto >= 0)
            {
                char separador = ultimaComa >= 0 ? ',' : '.';
                string[] partes = limpio.Split(separador);

                // "50.000" o "1.250.000" -> separador de miles
                bool esMiles = partes.Length > 1 && partes[0].Length > 0 && partes[0].Length <= 3;
                for (int i = 1; i < partes.Length && esMiles; i++)
                {
                    esMiles = partes[i].Length == 3;
                }

                if (esMiles)
                {
                    limpio = limpio.Replace(separador.ToString(), "");
                }
                else if (partes.Length == 2)
                {
                    limpio = partes[0] + "." + partes[1];   // separador decimal
                }
                else
                {
                    limpio = "x";                           // formato inválido
                }
            }

            double monto;

            bool ok = double.TryParse(limpio, NumberStyles.AllowDecimalPoint,
                                      CultureInfo.InvariantCulture, out monto);

            if (!ok || double.IsNaN(monto) || double.IsInfinity(monto) || monto <= 0)
            {
                throw new ArgumentException("El monto debe ser un número mayor a cero (ej: 50000 o 50000,50).");
            }

            return monto;
        }

        public static string LeerTipoMovimiento(object seleccionado)
        {
            string tipo = seleccionado == null ? "" : seleccionado.ToString();

            if (tipo != "DEPOSITO" && tipo != "RETIRO")
            {
                throw new ArgumentException("Seleccione el tipo de movimiento (DEPOSITO o RETIRO).");
            }

            return tipo;
        }

        public static string LeerDescripcion(string texto)
        {
            string descripcion = (texto ?? "").Trim();

            if (descripcion.Length == 0)
            {
                throw new ArgumentException("La descripción es obligatoria.");
            }

            if (descripcion.Length > 200)
            {
                throw new ArgumentException("La descripción no puede superar 200 caracteres.");
            }

            return descripcion;
        }

        public static DateTime ValidarFecha(DateTime fecha)
        {
            if (fecha > DateTime.Now)
            {
                throw new ArgumentException("La fecha del movimiento no puede ser futura.");
            }

            return fecha;
        }
    }
}
