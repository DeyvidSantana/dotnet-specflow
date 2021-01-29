using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace ConversorDistancias
{
    [Binding]
    public sealed class ConversaoDistanciasStepDefinition
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;
        private double _distanciaMilhas;
        private double _distanciaKm;

        public ConversaoDistanciasStepDefinition(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given("uma instância de (.*) milhas")]
        public void PreencherDistanciaMilhas(double distanciaMilhas)
        {
            _distanciaMilhas = distanciaMilhas;
        }

        [When("eu solicitar a conversão deste valor")]
        public void ProcessarConversao()
        {
            var tela = new TelaConversaoDistancias();
            tela.CarregarPagina();
            tela.PreencherDistanciasMilhas(_distanciaMilhas);
            tela.ProcessarConversao();
            _distanciaKm = tela.ObterDistanciaKm();
            tela.Fechar();
        }

        [Then("o resultado será (.*) km ")]
        public void VerificarDistanciaKm(double distanciaKm)
        {
            Assert.AreEqual(distanciaKm, _distanciaKm);
        }
    }
}
