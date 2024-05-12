using System;
class ContaBancaria
{
    private double saldo;
    public void Sacar(double valor)
    {
        if (valor <= saldo)
            saldo -= valor;
        else
            throw new Exception("Saldo insuficiente");
    }
    public void Depositar(double valor)
    {
        saldo += valor;
    }
    public Double Saldo
    {
        get { return saldo; }
    }
}

class Program
{
    static void Main(string[] args)
    {
        ContaBancaria minhaConta = new ContaBancaria();
        minhaConta.Depositar(1000);
        minhaConta.Sacar(500);
    }
}
