

using Coypu;

namespace ProvaStefanini.pages
{

    public class CadastroUsuario
    {
        private readonly BrowserSession _browser;

        public CadastroUsuario(BrowserSession browser)
        {
            _browser = browser;

        }
        public void TelaCadastroUsuario()
        {

            _browser.Visit("/teste/qa/");
        }

        public void Dados(string nome, string email, string senha)
        {
            this.TelaCadastroUsuario();
            _browser.FillIn("name").With(nome);
            _browser.FillIn("email").With(email);
            _browser.FillIn("password").With(senha);
            _browser.ClickButton("register");
        }

        public string MensagemErro()
        {
            return _browser.FindCss(".error").Text;
        }

        public string UsuarioCadastrado()
        {
            return _browser.FindXPath("//*[contains(text(),'Joao da Silva')]").Text;
            
        }

        public string EmailCadastrado()
        {
            return _browser.FindXPath("//*[contains(text(),'joao.silva@email.com')]").Text;

        }


    }
}