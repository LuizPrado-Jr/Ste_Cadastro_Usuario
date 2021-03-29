

using NUnit.Framework;
using ProvaStefanini.pages;
using ProvaStefanini.Common;
using System.Threading;
using System.Text.RegularExpressions;

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

        [Test]
        [Category("Critical")]
        public void DeveCadastrarUsuarioComSucessoDepoisExclui()
        {
            _cadastro.Dados("Jose da Silva", "jose.silva@email.com", "ABCDEFGH");

            Assert.AreEqual("Jose da Silva", _cadastro.UsuarioCadastrado());
            Assert.AreEqual("jose.silva@email.com", _cadastro.EmailCadastrado());

            Browser.FindCss("#removeUser1").Click();

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
              

    }


}
