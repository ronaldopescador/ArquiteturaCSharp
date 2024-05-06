using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expressao
{
    public enum TokenType
    {
        Numero,
        Operador,
        ParentesesAbre,
        ParentesesFecha,
        FimExpressao
    }

    public class Token
    {
        public TokenType Type { get; }
        public string Value { get; }

        public Token(TokenType type, string value)
        {
            Type = type;
            Value = value;
        }
    }

    public class Lexer
    {
        private readonly string _expressao;
        private int _posicao;

        public Lexer(string expressao)
        {
            _expressao = expressao;
            _posicao = 0;
        }

        public Token ProximoToken()
        {
            // Ignorar espaços em branco
            while (_posicao < _expressao.Length && char.IsWhiteSpace(_expressao[_posicao]))
            {
                _posicao++;
            }

            if (_posicao >= _expressao.Length)
                return new Token(TokenType.FimExpressao, "");

            char atual = _expressao[_posicao];

            if (char.IsDigit(atual))
            {
                string numero = atual.ToString();
                while (_posicao + 1 < _expressao.Length && char.IsDigit(_expressao[_posicao + 1]))
                {
                    numero += _expressao[++_posicao];
                }
                _posicao++;
                return new Token(TokenType.Numero, numero);
            }
            else if (atual == '+' || atual == '-' || atual == '*' || atual == '/')
            {
                _posicao++;
                return new Token(TokenType.Operador, atual.ToString());
            }
            else if (atual == '(')
            {
                _posicao++;
                return new Token(TokenType.ParentesesAbre, "(");
            }
            else if (atual == ')')
            {
                _posicao++;
                return new Token(TokenType.ParentesesFecha, ")");
            }
            else
            {
                throw new FormatException("Caractere inválido na expressão.");
            }
        }

        public List<Token> Tokenizar()
        {
            var tokens = new List<Token>();

            Token token;
            while ((token = ProximoToken()).Type != TokenType.FimExpressao)
            {
                tokens.Add(token);
            }

            tokens.Add(new Token(TokenType.FimExpressao, ""));

            return tokens;
        }
    }
}
