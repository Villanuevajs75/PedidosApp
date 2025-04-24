using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidosApp
{
    public interface IMetodoEntrega
    {
        double CalcularCosto(int km);
        string TipoEntrega();
    }
}
