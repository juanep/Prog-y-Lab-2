using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralitaHerencia
{
    public class Provincial : Llamada
    {
        static Franja franjaHoraria;

        public float CostoLlamada
        {
            get { return this.CalcularCosto(); }
        }

        public Provincial(Franja miFranja, Llamada llamada)
            : this(llamada.Duracion, llamada.NroDestino, llamada.NroOrigen, miFranja)
        {
        }

        public Provincial(float duracionLlamada, string destino, string origen, Franja miFranja)
            : base(duracionLlamada, destino, origen)
        {
            franjaHoraria = miFranja;
        }

        private float CalcularCosto()
        {
            float costo = 0F;
            switch (franjaHoraria) {
                case Franja.Franja_1: costo = 0.99F; break;
                case Franja.Franja_2: costo = 1.25F; break;
                case Franja.Franja_3: costo = 0.66F; break;
            }
            costo *= base.Duracion;
            return costo;
        }

        public string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("------ Llamada Provincial -------");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("Costo Llamada: {0:0.00}\n", this.CostoLlamada);
            sb.AppendFormat("Franja Horaria: {0:0.00}", franjaHoraria);
            return sb.ToString();
        }

        public enum Franja
        {
            Franja_1,
            Franja_2,
            Franja_3
        }
    }
}
