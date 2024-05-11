using System;

class Calculadora
{
    public double Num1 { get; set; }
    public double Num2 { get; set; }
    public Calculadora(double num1, double num2)
    {
        Num1 = num1;
        Num2 = num2;
    }
    public double Somar()
    {
        return Num1 + Num2;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Calculadora calc = new Calculadora(10, 35);

        double resultado = calc.Somar();
    }
}



