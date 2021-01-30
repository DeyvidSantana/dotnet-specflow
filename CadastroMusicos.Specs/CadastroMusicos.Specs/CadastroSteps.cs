using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using TechTalk.SpecFlow;

namespace CadastroMusicos.Specs
{
    [Binding]
    public class CadastroSteps
    {
        IWebDriver Browser;
        private readonly string url = "http://localhost:4200/";

        [BeforeScenario]
        public void Init()
        {
            Browser = new ChromeDriver();
        }

        [AfterScenario]
        public void Close()
        {
            Browser.Close();
            Browser.Dispose();
        }

        [Given(@"Um Visitante não cadastrado acessou a tela inicial")]
        public void DadoUmVisitanteNaoCadastradoAcessouATelaInicial()
        {
            Browser.Navigate().GoToUrl(url);
        }
        
        [Given(@"Um Visitante não cadastrado acessou a tela de cadastro")]
        public void DadoUmVisitanteNaoCadastradoAcessouATelaDeCadastro()
        {
            Browser.Navigate().GoToUrl($"{url}cadastro");
        }
        
        [When(@"Clicar no botão Quero Me Cadastrar")]
        public void QuandoClicarNoBotaoQueroMeCadastrar()
        {
            var btnQueroMeCadastrar = Browser.FindElement(By.Id("btnQueroMeCadastrar"));
            btnQueroMeCadastrar.Click();
        }
        
        [When(@"Preencher todos os campos")]
        public void QuandoPreencherTodosOsCampos(Table table)
        {
            var nome = table.Rows[0][0].ToString();
            var email = table.Rows[0][1].ToString();
            var instrumento = table.Rows[0][2].ToString();
            var senha = table.Rows[0][3].ToString();

            Browser.FindElement(By.Id("txtNome")).SendKeys(nome);
            Browser.FindElement(By.Id("txtEmail")).SendKeys(email);
            Browser.FindElement(By.Id("txtSenha")).SendKeys(senha);

            var optInstrumento = Browser.FindElement(By.Id("optInstrumento"));
            optInstrumento.Click();
            Thread.Sleep(1000);

            var menuItem = Browser.FindElement(By.Id(string.Format("item_{0}", instrumento)));
            Thread.Sleep(1000);
            menuItem.Click();
        }
        
        [When(@"Clicar no botão cadastrar")]
        public void QuandoClicarNoBotaoCadastrar()
        {
            var btnCadastrar = Browser.FindElement(By.Id("btnCadastrar"));
            Thread.Sleep(1000);
            btnCadastrar.Click();
        }
        
        [When(@"Preencher todos os campos exceto um obrigatório")]
        public void QuandoPreencherTodosOsCamposExcetoUmObrigatorio(Table table)
        {
            var nome = table.Rows[0][0].ToString();
            var email = table.Rows[0][1].ToString();
            var instrumento = table.Rows[0][2].ToString();
            var senha = table.Rows[0][3].ToString();

            Browser.FindElement(By.Id("txtNome")).SendKeys(nome);
            Browser.FindElement(By.Id("txtEmail")).SendKeys(email);
            Browser.FindElement(By.Id("txtSenha")).SendKeys(senha);

            var optInstrumento = Browser.FindElement(By.Id("optInstrumento"));
            optInstrumento.Click();
            Thread.Sleep(1000);

            var menuItem = Browser.FindElement(By.Id(string.Format("item_{0}", instrumento)));
            Thread.Sleep(1000);
            menuItem.Click();
        }
        
        [Then(@"O formulário de Cadastro será exibido com os campos: Nome, Email, Instrumento, Senha")]
        public void EntaoOFormularioDeCadastroSeraExibidoComOsCamposNomeEmailInstrumentoSenha()
        {
            try
            {
                var txtNome = Browser.FindElement(By.Id("txtNome"));
                var txtEmail = Browser.FindElement(By.Id("txtEmail"));
                var optInstrumento = Browser.FindElement(By.Id("optInstrumento"));
                var txtSenha = Browser.FindElement(By.Id("txtSenha"));
            }
            catch (NoSuchElementException)
            {
                Assert.Fail();
            }
        }
        
        [Then(@"será exibido o botão Cadastrar")]
        public void EntaoSeraExibidoOBotaoCadastrar()
        {
            try
            {
                var btnCadastrar = Browser.FindElement(By.Id("btnCadastrar"));
            }
            catch (NoSuchElementException)
            {
                Assert.Fail();
            }
        }

        [Then(@"A seguinte mensagem será exibida por (.*) segundos conforme layout especificado: Cadastro efetuado com sucesso!")]
        public void EntaoASeguinteMensagemSeraExibidaPorSegundosConformeLayoutEspecificadoCadastroEfetuadoComSucesso(int p0)
        {
            var lblMensagemSucesso = Browser.FindElement(By.Id("lblMensagemSucesso"));
            Thread.Sleep(1000);
            Assert.AreEqual("Cadastro efetuado com sucesso!", lblMensagemSucesso.Text);
        }
        
        [Then(@"o usuário será redirecionado para a tela inicial")]
        public void EntaoOUsuarioSeraRedirecionadoParaATelaInicial()
        {
            Thread.Sleep(5000);
            Assert.AreEqual(url, Browser.Url);
        }
        
        [Then(@"A seguinte mensagem será exibida conforme layout especificado: Todos os campos obrigatórios devem ser preenchidos\.")]
        public void EntaoASeguinteMensagemSeraExibidaConformeLayoutEspecificadoTodosOsCamposObrigatoriosDevemSerPreenchidos_()
        {
            var lblErroValidacao = Browser.FindElement(By.Id("lblMensagemErroValidacao"));
            Thread.Sleep(1000);
            Assert.AreEqual("Todos os campos obrigatórios devem ser preenchidos.", lblErroValidacao.Text);
        }
    }
}
