using System;

class ContaBancaria(decimal saldoInicial)
{
    protected decimal _saldo = saldoInicial;

    public virtual void Sacar(decimal valor)
    {
        if (valor <= Saldo)
            _saldo -= valor;
        else
            throw new Exception("Saldo insuficiente.");
    }
    public virtual void Depositar(decimal valor)
    {
        _saldo += valor;
    }
    public decimal Saldo
    {
        get { return _saldo; }
    }
}

class ContaCorrente : ContaBancaria
{
    public decimal TaxaManutencao { get; private set; }

    public ContaCorrente(decimal saldoInicial, decimal taxaManutencao) : base(saldoInicial)
    {
        TaxaManutencao = taxaManutencao;
    }

    public override void Sacar(decimal valor)
    {
        if (valor <= Saldo + TaxaManutencao)
            _saldo -= valor;
        else
            throw new Exception("Saldo insuficiente.");
    }
}

class ContaPoupanca(decimal saldoInicial) : ContaBancaria(saldoInicial)
{
    const decimal TaxaRendimento = 2;

    public void CalcularRendimentoMensal()
    {
        decimal rendimento = Saldo * TaxaRendimento / 100;
        _saldo += rendimento;
    }
}

class Program
{
    static void Main(string[] args)
    {
        ContaCorrente contaCorrente = new ContaCorrente(1000, 50);
        contaCorrente.Depositar(500);
        contaCorrente.Sacar(1200);

        ContaPoupanca contaPoupanca = new ContaPoupanca(2000);
        contaPoupanca.Depositar(1000);
        contaPoupanca.CalcularRendimentoMensal();
    }
}
