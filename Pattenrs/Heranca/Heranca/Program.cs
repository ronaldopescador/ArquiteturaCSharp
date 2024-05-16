class ContaBancaria
{
    protected decimal _saldo;
    public ContaBancaria(decimal saldoInicial)
    {
        _saldo = saldoInicial;
    }
    public virtual void Sacar(decimal valor)
    {
        if (valor <= Saldo)
            _saldo -= valor;
        else
            throw new Exception("Saldo insuficiente.");
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
class ContaCorrente : ContaBancaria
{
    public decimal LimiteCredito { get; private set; }
    public ContaCorrente(decimal saldoInicial, decimal limiteCredito) : base(saldoInicial)
    {
        LimiteCredito = limiteCredito;
    }
    public override void Sacar(decimal valor)
    {
        if (valor <= Saldo + LimiteCredito)
            _saldo -= valor;
        else
            throw new Exception("Saldo insuficiente.");
    }
}

class ContaPoupanca(decimal saldoInicial) : ContaBancaria(saldoInicial)
{
    const decimal TAXA_RENDIMENTO = 2;
    public void CalcularRendimentoMensal()
    {
        decimal rendimento = Saldo * TAXA_RENDIMENTO / 100;
        _saldo += rendimento;
    }
}

class Program
{
    static void Main(string[] args)
    {
        ContaCorrente cc = new ContaCorrente(0, 1000);
        cc.Depositar(500);
        cc.Sacar(1200);

        ContaPoupanca poupanca = new ContaPoupanca(2000);
        poupanca.Depositar(1000);
        poupanca.CalcularRendimentoMensal();
    }
}


