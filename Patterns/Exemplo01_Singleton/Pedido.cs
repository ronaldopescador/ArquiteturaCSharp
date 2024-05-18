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
            var logger = Logger.GetInstance();
            logger.Log($"Pedido {id} incluído");
        }
    }
}
