using System;
using System.Collections.Generic;
using System.Text;

namespace CentralitaHerencia
{
    public class Centralita
    {
        private List<Llamada> llamadas;
        static string razonSocial;

        public float GananciasPorLocal
        {
            get
            {
                return this.CalcularGanancia(Llamada.TipoLlamada.Local);
            }
        }

        public float GananciasPorProvincial
        {
            get
            {
                return this.CalcularGanancia(Llamada.TipoLlamada.Provincia);
            }
        }

        public float GananciasPorTotal
        {
            get
            {
                return this.CalcularGanancia(Llamada.TipoLlamada.Todas);
            }
        }

        public List<Llamada> Llamadas
        {
            get { return this.llamadas; }
        }

        public Centralita() { this.llamadas = new List<Llamada>(); }

        public Centralita(string nombreEmpresa) : this()
        {
            Centralita.razonSocial = nombreEmpresa;
        }

        private float CalcularGanancia(Llamada.TipoLlamada tipoLlamada)
        {
            float ganancia = 0F;
            switch (tipoLlamada)
            {
                case Llamada.TipoLlamada.Local:
                    foreach (Llamada llamada in this.llamadas)
                    {
                        if(llamada is Local)
                        {
                            ganancia += ((Local)llamada).CostoLlamada;
                        }
                    } break;
                case Llamada.TipoLlamada.Provincia:
                    foreach (Llamada llamada in this.llamadas)
                    {
                        if(llamada is Provincial)
                        {
                            ganancia += ((Provincial)llamada).CostoLlamada;
                        }
                    } break;
                case Llamada.TipoLlamada.Todas:
                    foreach (Llamada llamada in this.llamadas)
                    {
                        if (llamada is Local)
                        {
                            ganancia += ((Local)llamada).CostoLlamada;
                        }
                        else if(llamada is Provincial)
                        {
                            ganancia += ((Provincial)llamada).CostoLlamada;
                        }
                    } break;
                default: break;
            }
            return ganancia;
        }

        public string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("---------- Empresa {0} -----------\n", razonSocial);
            sb.AppendFormat("\nGanancia Total: {0}\n", this.GananciasPorTotal);
            sb.AppendFormat("Ganancia por llamadas Locales: {0}\n", this.GananciasPorLocal);
            sb.AppendFormat("Ganancia por llamadas Provinciales: {0}\n", this.GananciasPorProvincial);
            sb.AppendLine("\n------- Detalle de las llamadas -------\n");
            foreach (Llamada llamada in this.llamadas)
            {
                sb.AppendFormat("{0}", llamada.Mostrar());
            }
            return sb.ToString();
        }

        public void OrdenarLlamadas()
        {
            this.llamadas.Reverse();
        }
    }
}
