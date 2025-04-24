using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidosApp
{
    public class EntregaMoto : IMetodoEntrega
    {
        public double CalcularCosto(int km) => 10 * km;
        public string TipoEntrega() => "Motocicleta";
    }
}
