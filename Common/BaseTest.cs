using System;
using System.IO;
using Coypu;
using Coypu.Drivers.Selenium;
using NUnit.Framework;
using ProvaStefanini.pages;

namespace ProvaStefanini.Common
{

    public class BaseTest
    {
        protected BrowserSession Browser;

        [SetUp]
        public void Setup()
        {
            var configs = new SessionConfiguration
            {
                AppHost = "http://prova.stefanini-jgr.com.br",
                SSL = false,
                Driver = typeof(SeleniumWebDriver),
                Browser = Coypu.Drivers.Browser.Chrome,
                Timeout = TimeSpan.FromSeconds(10)

            };

            Browser = new BrowserSession(configs);
            Browser.MaximiseWindow();

        }

        public void Screenshot()
        {
            var resultId = TestContext.CurrentContext.Test.ID;
            var shotPath = Environment.CurrentDirectory + "\\screenchots";

            if (!Directory.Exists(shotPath))
            {
                Directory.CreateDirectory(shotPath);
            }
            var screenshot = $"{shotPath}\\{resultId}.png";

            Browser.SaveScreenshot(screenshot);
            TestContext.AddTestAttachment(screenshot);
        }

        [TearDown]
        public void Finish()
        {
            try
            {
            Screenshot();
            }
            catch (Exception e)
            {
                Console.WriteLine("Ocorreu um erro ao captrar o Screenshot");
                throw new Exception (e.Message);
            }
            finally
            {
            Browser.Dispose();
            }
        }

    }
}