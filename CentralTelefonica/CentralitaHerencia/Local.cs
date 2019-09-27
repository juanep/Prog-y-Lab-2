using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralitaHerencia
{
    public class Local : Llamada
    {
        static float costo;

        public float CostoLlamada
        {
            get { return this.CalcularCosto(); }
        }

        public Local(Llamada call, float costoLlamada) 
            : this(call.Duracion, call.NroDestino, call.NroOrigen, costoLlamada)
        {
        }

        public Local(float duracionLlamada, string destino, string origen, float costoLlamada)
            : base(duracionLlamada, destino, origen)
        {
            costo = costoLlamada;
        }

        private float CalcularCosto()
        {
            return base.Duracion * Local.costo;
        }

        public string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("------ Llamada Local -------");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("Costo Llamada: {0:0.00}\n", this.CostoLlamada);
            return sb.ToString();
        }
    }
}
