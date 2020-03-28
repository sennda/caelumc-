namespace Caelum.Banco.Negocio
{
    public class ContaCorrente : Conta, ITributavel
    {
        public ContaCorrente(string titular) : base(titular)
        {
        }

        public double CalculaTributos()
        {
            return Saldo * 0.05;
        }
    }
}
