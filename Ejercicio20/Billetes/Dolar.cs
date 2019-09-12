using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billetes
{
    public class Dolar
    {
        private double cantidad;
        private static double cotizRespectoDolar;

        private Dolar() { }
        public Dolar(double cantidad)
        {
            this.cantidad = cantidad;
        }

        public Dolar(double cantidad, double cotizacion) : this(cantidad)
        {
            cotizRespectoDolar = cotizacion;
        }

        public double getCantidad()
        {
            return this.cantidad;
        }

        public void setCantidad(double cantidad)
        {
            this.cantidad = cantidad;
        }

        public static double getCotizacion()
        {
            return cotizRespectoDolar;
        }

        #region Operadores
        #region Explicitos
        public static explicit operator Pesos(Dolar dolar)
        {
            double cantidad = dolar.getCantidad() * Pesos.getCotizacion();
            return new Pesos(cantidad);
        }

        public static explicit operator Euro(Dolar dolar)
        {
            double cantidad = dolar.getCantidad() * Euro.getCotizacion();
            return new Euro(cantidad);
        }
        #endregion
        #region Implicitos
        public static implicit operator Dolar(double d)
        {
            return new Dolar(d);
        }
        #endregion
        #endregion

    }
}
