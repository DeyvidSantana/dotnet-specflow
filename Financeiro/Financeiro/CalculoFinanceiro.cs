using System;

namespace Financeiro
{
    public static class CalculoFinanceiro
    {
        public static double CalcularValorComJurosCompostos(double valorEmprestimo, int numMeses, double taxa)
        {
            return Math.Round(valorEmprestimo * Math.Pow((1 + taxa / 100), numMeses), 2);
        }
    }
}
