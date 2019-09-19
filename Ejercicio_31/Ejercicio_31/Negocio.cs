using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_31
{
    class Negocio
    {
        private PuestoAtencion caja;
        private Queue<Cliente> clientes;
        private string nombre;

        public Cliente Cliente
        {
            get { return clientes.Dequeue(); }
            set { this.clientes.Enqueue(value); }
        }

        public Negocio() { }

        public Negocio(string nombre) : this() { this.nombre = nombre; }
    }
}
