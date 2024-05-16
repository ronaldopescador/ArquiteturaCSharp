using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exemplo01_Singleton
{
    public class Pedido
    {       
        public void Incluir(int id)
        {
            Logger.GetInstance().Log($"Pedido {id} incluído");
        }
    }
}
