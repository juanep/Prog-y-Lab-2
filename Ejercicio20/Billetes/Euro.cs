using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billetes
{
    public class Euro
    {
        private double cantidad;
        private static double cotizRespectoDolar;

        private Euro()
        {
            cotizRespectoDolar = 1.16;
        }
        public Euro(double cantidad) {
            this.cantidad = cantidad;
        }

        public Euro(double cantidad, double cotizacion) : this(cantidad)
        {
            cotizRespectoDolar = cotizacion;
        }

        public double getCantidad()
        {
            return this.cantidad;
        }

        public static double getCotizacion()
        {
            return cotizRespectoDolar;
        }

        #region Operadores
        #region Explicitos
        public static explicit operator Dolar(Euro e)
        {
            double cantidad = e.getCantidad() * Dolar.getCotizacion();
            return new Dolar(cantidad);
        }

        public static explicit operator Pesos(Euro e)
        {
            Dolar dolar = new Dolar(e.getCantidad() * Dolar.getCotizacion());
            double cantidad = dolar.getCantidad() * Pesos.getCotizacion();
            return new Pesos(cantidad);
        }
        #endregion
        #region Implicitos
        public static implicit operator Euro(double d)
        {
            return new Euro(d);
        }
        #endregion
        #endregion
    }
}
