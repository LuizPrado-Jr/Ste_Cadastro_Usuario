using NUnit.Framework;
using ProvaStefanini.Common;

namespace ProvaStefanini.Tests
{
    public class OnAirTest : BaseTest
    {
       
        [Test]
        public void DeveExibirTitulo()
        {
            Browser.Visit("/teste/qa/");
            Assert.AreEqual("Cadastro de usuários", Browser.Title);
        }


    }
}