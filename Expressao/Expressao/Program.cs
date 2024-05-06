using System.Diagnostics.Metrics;
using Expressao;

public class Semantica
{
    public static void Verificar(List<Token> tokens)
    {
        int count = 0;
        foreach (var token in tokens)
        {
            if (token.Type == TokenType.ParentesesAbre)
                count++;
            else if (token.Type == TokenType.ParentesesFecha)
                count--;

            if (count < 0)
                throw new FormatException("Parênteses sem abertura correspondente.");
        }

        if (count != 0)
            throw new FormatException("Parênteses sem fechamento correspondente.");
    }
}

public class GeradorCodigo
{
    public static double GerarExpressao(string expressao)
    {
        Lexer lexer = new Lexer(expressao);
        List<Token> tokens = lexer.Tokenizar();

        Semantica.Verificar(tokens);

        Parser parser = new Parser(tokens);
        return parser.AnalisarExpressao();
    }
}

class Program
{
    static void Main(string[] args)
    {
        string expressao = "3 * 2 + 5";
        try
        {
            double resultado = GeradorCodigo.GerarExpressao(expressao);
            Console.WriteLine("Resultado: " + resultado);
        }
        catch (FormatException ex)
        {
            Console.WriteLine("Erro na expressão: " + ex.Message);
        }
    }
}
