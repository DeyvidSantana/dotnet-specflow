using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Configuration;

namespace ConversorDistancias
{
    public class TelaConversaoDistancias
    {
        private IWebDriver _driver;
        public TelaConversaoDistancias()
        {
            _driver = new FirefoxDriver();            
        }

        public void CarregarPagina()
        {
            _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
            _driver.Navigate().GoToUrl(
                ConfigurationManager.AppSettings["UrlTelaConversaoDistancias"]
            );
        }

        public void PreencherDistanciasMilhas(double valor)
        {
            var element = _driver.FindElement(By.Name("distanciasMilhas"));
            element.SendKeys(valor.ToString("0.00"));
        }

        public void ProcessarConversao()
        {
            var botaoConverter = _driver.FindElement(By.Id("btnConverter"));
            botaoConverter.Submit();

            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until((drv) => _driver.FindElement(By.ClassName("distanciaKm")) != null);
        }

        public double ObterDistanciaKm()
        {
            var distanciaKm = _driver.FindElement(By.ClassName("distanciaKm"));

            return Convert.ToDouble(distanciaKm.Text);
        }

        public void Fechar()
        {
            _driver.Quit();
            _driver = null;
        }
    }
}
