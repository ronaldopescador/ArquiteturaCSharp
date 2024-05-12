using System;
class ContaBancaria
{
    private decimal _saldo;
    public void Sacar(decimal valor)
    {
        if (valor <= _saldo)
            _saldo -= valor;
        else
            throw new Exception("Saldo insuficiente");
    }
    public void Depositar(decimal valor)
    {
        _saldo += valor;
    }
    public decimal Saldo
    {
        get { return _saldo; }
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
