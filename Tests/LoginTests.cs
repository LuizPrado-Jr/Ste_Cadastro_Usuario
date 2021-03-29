

using NUnit.Framework;
using ProvaStefanini.pages;
using ProvaStefanini.Common;

namespace ProvaStefanini.Tests
{
    public class LoginTests : BaseTest
    {
        private CadastroUsuario _cadastro;

        [SetUp]
        public void Start()
        {
            _cadastro = new CadastroUsuario(Browser);
        }

        [Test]
        [Category("Critical")]
        public void DeveCadastrarUsuarioComSucesso()
        {

            _cadastro.Dados("Joao da Silva", "joao.silva@email.com", "12345678");

            Assert.AreEqual("Joao da Silva", _cadastro.UsuarioCadastrado());
            Assert.AreEqual("joao.silva@email.com", _cadastro.EmailCadastrado());

        }


        [TestCase("", "joao.silva@email.com", "12345678", "O campo Nome é obrigatório.")]
        [TestCase("Joao da Silva", "", "12345678", "O campo E-mail é obrigatório.")]
        [TestCase("Joao da Silva", "joao.silva@email.com", "", "O campo Senha é obrigatório.")]
        [TestCase("Joao", "joao.silva@email.com", "12345678", "Por favor, insira um nome completo.")]
        [TestCase("Joao da Silva", "joao.silva@email", "12345678", "Por favor, insira um e-mail válido.")]
        [TestCase("Joao da Silva", "joao.silva@email.com", "123456", "A senha deve conter ao menos 8 caracteres.")]

        public void DeveApresentarMensagemAlerta(string nome, string email, string senha, string mensagemEsperada)
        {
            _cadastro.Dados(nome, email, senha);
            Assert.AreEqual(mensagemEsperada, _cadastro.MensagemErro());
        }
        //  [Test]

        // public void DeveCadastrarUsuarioComSucessoDepoisExcluir()
        // {
        //  browser.Visit("/teste/qa/");

        //  browser.FillIn("name").With("Joao da Silva");
        //  browser.FillIn("email").With("joao.silva@email.com");
        //  browser.FillIn("password").With("12345678");
        //  browser.ClickButton("register");

        //  Thread.Sleep(5000);

        //  var usuariocadastrado = browser.FindXPath("//*[contains(text(),'Joao da Silva')]");
        //  var emailcadastrado = browser.FindXPath("//*[contains(text(),'joao.silva@email.com')]");

        //  Assert.AreEqual("Joao da Silva",usuariocadastrado.Text);
        //  Assert.AreEqual("joao.silva@email.com",emailcadastrado.Text);

        // }



    }


}
