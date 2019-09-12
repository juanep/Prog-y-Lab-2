using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billetes
{
    public class Pesos
    {
        private double cantidad;
        private static double cotizRespectoDolar;

        private Pesos()
        {
            cotizRespectoDolar = 0.38;
        }
        public Pesos(double cantidad)
        {
            this.cantidad = cantidad;
        }

        public Pesos(double cantidad, double cotizacion) : this(cantidad)
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
        public static explicit operator Dolar(Pesos pesos)
        {
            double cantidad = pesos.getCantidad() * Dolar.getCotizacion();
            return new Dolar(cantidad);
        }

        public static explicit operator Euro(Pesos pesos)
        {
            Dolar dolar = new Dolar(pesos.getCantidad() * getCotizacion());
            double cantidad = dolar.getCantidad() * Dolar.getCotizacion();
            return new Euro(cantidad);
        }
        #endregion
        #region Implicitos
        public static implicit operator Pesos(double d)
        {
            return new Pesos(d);
        }
        #endregion
        public static bool operator == (Pesos p, Dolar d)
        {
            double cantidad = p.getCantidad() * Pesos.getCotizacion();
            return (d.getCantidad() == cantidad);
        }

        public static bool operator != (Pesos p, Dolar d)
        {
            return !(p == d);
        }
        #endregion

    }
}
