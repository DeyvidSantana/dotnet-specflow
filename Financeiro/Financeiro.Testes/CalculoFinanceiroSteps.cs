using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace Financeiro.Testes
{
    [Binding]
    public sealed class CalculoFinanceiroSteps
    {
        private double _valorEmprestimo;
        private double _taxa;
        private int _meses;
        private double _valorFinalPeriodo;

        [Given("que o valor do empréstimo foi R\\$ (.*)")]
        public void CarregarValorEmprestimo(double valorEmprestimo)
        {
            _valorEmprestimo = valorEmprestimo;
        }

        [Given("foi definida uma taxa de (.*)% mensais")]
        public void CarregarTaxa(double taxa)
        {
            _taxa = taxa;
        }

        [Given("em um período de (.*) meses")]
        public void CarregarMeses(int meses)
        {
            _meses = meses;
        }

        [When("eu solicitar o valor ao final do período")]
        public void ProcessarCalculo()
        {
            _valorFinalPeriodo = CalculoFinanceiro.CalcularValorComJurosCompostos(_valorEmprestimo, _meses, _taxa);
        }

        [Then("o valor total a ser pago será R\\$ (.*)")]
        public void VerificarResultado(double valorFinalPeriodo)
        {
            Assert.AreEqual(valorFinalPeriodo, _valorFinalPeriodo);
        }
    }
}
