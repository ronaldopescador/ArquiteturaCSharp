using Exemplo02_FactoryMethod.ConcreteProduct;
using Exemplo02_FactoryMethod.Creator;
using Exemplo02_FactoryMethod.Product;

namespace Exemplo02_FactoryMethod.ConcreteCreator
{
    public class BlackFactory : CartaoFactory
    {
        private int _limiteCredito;
        private int _cobrancaAnual;

        public BlackFactory(int limiteCredito, int cobrancaAnual)
        {
            this._limiteCredito = limiteCredito;
            this._cobrancaAnual = cobrancaAnual;
        }

        public override CartaoCredito BuscarCartaoCredito()
        {
            return new CartaoBlack(_limiteCredito, _cobrancaAnual);
        }
    }
}
