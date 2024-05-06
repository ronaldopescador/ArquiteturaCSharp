using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expressao
{
    public class Parser
    {
        private readonly List<Token> _tokens;
        private int _posicao;

        public Parser(List<Token> tokens)
        {
            _tokens = tokens;
            _posicao = 0;
        }

        public double AnalisarExpressao()
        {
            return AnalisarExpressaoAditiva();
        }

        private double AnalisarExpressaoAditiva()
        {
            double valorEsquerda = AnalisarExpressaoMultiplicativa();

            while (true)
            {
                if (OlharToken().Value == "+")
                {
                    ConsumeToken();
                    double valorDireita = AnalisarExpressaoMultiplicativa();
                    valorEsquerda += valorDireita;
                }
                else if (OlharToken().Value == "-")
                {
                    ConsumeToken();
                    double valorDireita = AnalisarExpressaoMultiplicativa();
                    valorEsquerda -= valorDireita;
                }
                else
                {
                    break;
                }
            }

            return valorEsquerda;
        }

        private double AnalisarExpressaoMultiplicativa()
        {
            double valorEsquerda = AnalisarNumero();

            while (true)
            {
                if (OlharToken().Value == "*")
                {
                    ConsumeToken();
                    double valorDireita = AnalisarNumero();
                    valorEsquerda *= valorDireita;
                }
                else if (OlharToken().Value == "/")
                {
                    ConsumeToken();
                    double valorDireita = AnalisarNumero();
                    valorEsquerda /= valorDireita;
                }
                else
                {
                    break;
                }
            }

            return valorEsquerda;
        }

        private double AnalisarNumero()
        {
            var token = OlharToken();
            if (token.Type == TokenType.Numero)
            {
                ConsumeToken();
                return double.Parse(token.Value);
            }
            else if (token.Type == TokenType.ParentesesAbre)
            {
                ConsumeToken(); // Consume '('
                double resultado = AnalisarExpressao();
                if (OlharToken().Type != TokenType.ParentesesFecha)
                {
                    throw new FormatException("Parênteses sem fechamento.");
                }
                ConsumeToken(); // Consume ')'
                return resultado;
            }
            else
            {
                throw new FormatException("Token inválido encontrado.");
            }
        }

        private Token OlharToken()
        {
            if (_posicao < _tokens.Count)
            {
                return _tokens[_posicao];
            }
            else
            {
                return new Token(TokenType.FimExpressao, "");
            }
        }

        private void ConsumeToken()
        {
            _posicao++;
        }
    }

}
