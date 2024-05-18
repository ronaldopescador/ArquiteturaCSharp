using Exemplo02_FactoryMethod.Product;

namespace Exemplo02_FactoryMethod.Creator
{
    public abstract class CartaoFactory
    {
        public abstract CartaoCredito BuscarCartaoCredito();
    }
}
