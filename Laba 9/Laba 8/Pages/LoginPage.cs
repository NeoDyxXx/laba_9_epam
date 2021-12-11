using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace Laba_8.Pages
{
    public class LoginPage
    {
        WebDriver webDriver;
        By buttonToDemoAccount = By.XPath("//a[@class='main__platform-container__footer-demo']");

        public LoginPage(WebDriver webDriver, string webSite = "https://qxbroker.com/")
        {
            if (webDriver == null)
                this.webDriver = new ChromeDriver(@"C:\Users\krayn\Documents\БГТУ\5_semestr\EPAM\Laba 8\Laba 8\Laba 8\Web Driver\");
            else
                this.webDriver = webDriver;

            webDriver.Navigate().GoToUrl("https://qxbroker.com/");
        }
        public MainPage TransitionToDemoAccount()
        {
            new WebDriverWait(this.webDriver, TimeSpan.FromSeconds(3))
                   .Until(webDriver => webDriver.FindElement(buttonToDemoAccount)).Click();

            return new MainPage(webDriver);
        }
    }
}
