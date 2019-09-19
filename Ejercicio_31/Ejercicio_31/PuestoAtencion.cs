using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Ejercicio_31
{
    class PuestoAtencion
    {
        private static int numeroActual;
        private Puesto puesto;

        public static int NumeroActual
        {
            get { return ++numeroActual; }
        }

        public static void service()
        {
            for (int x = 0; x < 10; x++)
            {
                Thread.Sleep(1000); //dormir este proceso durante 1000ms
                Console.WriteLine(x);
            }
        }

        public bool Atender(Cliente cliente)
        {
            bool isOnCall = true;
            string numero = cliente.Numero.ToString();
            var onCall = new Thread(PuestoAtencion.service);
            onCall.Name = numero;
            Console.WriteLine("Client Service to " + cliente.Nombre);
            onCall.Start();
            if (!onCall.IsAlive) { isOnCall = false; }
            return isOnCall;
        }

        private PuestoAtencion() { numeroActual = 0; }

        public PuestoAtencion(Puesto puesto) : this() { this.puesto = puesto; }

        public enum Puesto { Caja1, Caja2 }
    }
}
