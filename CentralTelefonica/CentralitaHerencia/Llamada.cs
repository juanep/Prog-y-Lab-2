using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralitaHerencia
{
    public class Llamada
    {
        protected static float duracion;
        protected static string nroDestino;
        protected static string nroOrigen;

        public float Duracion
        {
            get { return duracion; }
        }

        public string NroDestino
        {
            get { return nroDestino; }
        }

        public string NroOrigen
        {
            get { return nroOrigen; }
        }

        public Llamada(float duracionLlamada, string destino, string origen)
        {
            duracion = duracionLlamada;
            nroDestino = destino;
            nroOrigen = origen;
        }

        public string Mostrar()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("Duracion: {0}\t", this.Duracion);
            builder.AppendFormat("Nro Destino: {0}\t", this.NroDestino);
            builder.AppendFormat("Nro Origen: {0}\n", this.NroOrigen);
            return builder.ToString();
        }

        public int OrdenarPorDuracion(Llamada call1, Llamada call2)
        {
            int retorno = 0;
            if(call1.Duracion < call2.Duracion)
            {
                retorno = 1;
            }
            return retorno;
        }

        public enum TipoLlamada
        {
            Local,
            Provincia,
            Todas
        }
    }
}
