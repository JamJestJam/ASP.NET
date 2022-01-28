using ASP.net_Aplication;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ASP.net_Aplication_Test {
    public class AccountControllerTest {
        [Fact]
        public void TryLogin() {
            using SeleniumServerFactory<Startup> server = new("TryLogin");
            using ChromeDriver browser = new();
            browser.Navigate().GoToUrl(server.BaseAddress);

            browser.FindElement(By.XPath(".//*[@id='LoginIn']")).Click();
            browser.FindElement(By.XPath(".//*[@name='Login']")).SendKeys("admin");
            browser.FindElement(By.XPath(".//*[@name='Password']")).SendKeys("zaq1@WSX");
            browser.FindElement(By.XPath(".//*[@value='Zaloguj się']")).Click();

            Assert.Equal(server.BaseAddress.ToString(), browser.Url);
        }

        [Fact]
        public void TryBadLogin() {
            using SeleniumServerFactory<Startup> server = new("TryBadLogin");
            using ChromeDriver browser = new();
            browser.Navigate().GoToUrl(server.BaseAddress);

            browser.FindElement(By.XPath(".//*[@id='LoginIn']")).Click();
            browser.FindElement(By.XPath(".//*[@name='Login']")).SendKeys("admin");
            browser.FindElement(By.XPath(".//*[@name='Password']")).SendKeys("zaq12wsx");
            browser.FindElement(By.XPath(".//*[@value='Zaloguj się']")).Click();

            Assert.Equal("Nieprawidłowa nazwa użytkownika lub hasło", browser.FindElement(By.XPath(".//*[@id='Danger']")).Text);
        }

        [Fact]
        public void TryRegister() {
            using SeleniumServerFactory<Startup> server = new("TryRegister");
            using ChromeDriver browser = new();
            browser.Navigate().GoToUrl(server.BaseAddress);

            browser.FindElement(By.XPath(".//*[@id='LoginIn']")).Click();
            browser.FindElement(By.XPath(".//*[@id='Register']")).Click();
            browser.FindElement(By.XPath(".//*[@id='FirstName']")).SendKeys("Marek");
            browser.FindElement(By.XPath(".//*[@id='LastName']")).SendKeys("Michura");
            browser.FindElement(By.XPath(".//*[@id='BirthDate']")).SendKeys("25111998");
            browser.FindElement(By.XPath(".//*[@id='UserName']")).SendKeys("Mareczek");
            browser.FindElement(By.XPath(".//*[@id='Email']")).SendKeys("Marekczek@marek.pl");
            browser.FindElement(By.XPath(".//*[@id='Password1']")).SendKeys("zaq1@WSX");
            browser.FindElement(By.XPath(".//*[@id='Password2']")).SendKeys("zaq1@WSX");
            browser.FindElement(By.XPath(".//*[@id='PhoneNumber']")).SendKeys("123456789");
            browser.FindElement(By.XPath(".//*[@value='Zarejestruj się']")).Click();

            Assert.Equal(server.BaseAddress.ToString(), browser.Url);
            browser.Dispose();
        }

        [Fact]
        public void TryRegisterUserNameUniqueFail() {
            using SeleniumServerFactory<Startup> server = new("TryRegisterUserNameUniqueFail");
            using ChromeDriver browser = new();
            browser.Navigate().GoToUrl(server.BaseAddress);

            browser.FindElement(By.XPath(".//*[@id='LoginIn']")).Click();
            browser.FindElement(By.XPath(".//*[@id='Register']")).Click();
            browser.FindElement(By.XPath(".//*[@id='FirstName']")).SendKeys("Marek");
            browser.FindElement(By.XPath(".//*[@id='LastName']")).SendKeys("Michura");
            browser.FindElement(By.XPath(".//*[@id='BirthDate']")).SendKeys("25111998");
            browser.FindElement(By.XPath(".//*[@id='UserName']")).SendKeys("admin");
            browser.FindElement(By.XPath(".//*[@id='Email']")).SendKeys("DziwnyJestTenSwiat@marek.pl");
            browser.FindElement(By.XPath(".//*[@id='Password1']")).SendKeys("zaq1@WSX");
            browser.FindElement(By.XPath(".//*[@id='Password2']")).SendKeys("zaq1@WSX");
            browser.FindElement(By.XPath(".//*[@id='PhoneNumber']")).SendKeys("123456789");
            browser.FindElement(By.XPath(".//*[@value='Zarejestruj się']")).Click();

            Assert.Contains("Nazwa użytkonika: 'admin' jest już zajęta.", browser.FindElement(By.XPath(".//*[@id='Errors']")).Text);
        }

        [Fact]
        public void TryRegisterModelFail() {
            using SeleniumServerFactory<Startup> server = new("TryRegisterModelFail");
            using ChromeDriver browser = new();
            browser.Navigate().GoToUrl(server.BaseAddress);

            browser.FindElement(By.XPath(".//*[@id='LoginIn']")).Click();
            browser.FindElement(By.XPath(".//*[@id='Register']")).Click();
            browser.FindElement(By.XPath(".//*[@id='FirstName']")).SendKeys("marek");
            browser.FindElement(By.XPath(".//*[@id='LastName']")).SendKeys("michura");
            browser.FindElement(By.XPath(".//*[@id='BirthDate']")).SendKeys("25112040");
            browser.FindElement(By.XPath(".//*[@id='UserName']")).SendKeys("admin");
            browser.FindElement(By.XPath(".//*[@id='Email']")).SendKeys("admin@email.com");
            browser.FindElement(By.XPath(".//*[@id='Password1']")).SendKeys("zaqwsx");
            browser.FindElement(By.XPath(".//*[@id='Password2']")).SendKeys("zaqwsx2");
            browser.FindElement(By.XPath(".//*[@id='PhoneNumber']")).SendKeys("123");
            browser.FindElement(By.XPath(".//*[@value='Zarejestruj się']")).Click();

            Assert.Contains("niepoprawna data urodzenia", browser.FindElement(By.XPath(".//*[@id='Errors']")).Text);
            Assert.Contains("Hasła nie są identyczne", browser.FindElement(By.XPath(".//*[@id='Errors']")).Text);
        }

        [Fact]
        public void TryRegisterPasswordFail() {
            using SeleniumServerFactory<Startup> server = new("TryRegisterPasswordFail");
            using ChromeDriver browser = new();
            browser.Navigate().GoToUrl(server.BaseAddress);

            browser.FindElement(By.XPath(".//*[@id='LoginIn']")).Click();
            browser.FindElement(By.XPath(".//*[@id='Register']")).Click();
            browser.FindElement(By.XPath(".//*[@id='FirstName']")).SendKeys("marek");
            browser.FindElement(By.XPath(".//*[@id='LastName']")).SendKeys("michura");
            browser.FindElement(By.XPath(".//*[@id='BirthDate']")).SendKeys("25111998");
            browser.FindElement(By.XPath(".//*[@id='UserName']")).SendKeys("admin");
            browser.FindElement(By.XPath(".//*[@id='Email']")).SendKeys("admin@email.com");
            browser.FindElement(By.XPath(".//*[@id='Password1']")).SendKeys("zaqwsx");
            browser.FindElement(By.XPath(".//*[@id='Password2']")).SendKeys("zaqwsx");
            browser.FindElement(By.XPath(".//*[@id='PhoneNumber']")).SendKeys("123");
            browser.FindElement(By.XPath(".//*[@value='Zarejestruj się']")).Click();

            Assert.Contains("Hasło musi zawierać przynajmniej jedną cyfre.", browser.FindElement(By.XPath(".//*[@id='Errors']")).Text);
            Assert.Contains("Hasło musi zawierać przynajmniej jedną dużą literę.", browser.FindElement(By.XPath(".//*[@id='Errors']")).Text);
            Assert.Contains("Hasło musi zawierać conajmniej jeden znak specjalny.", browser.FindElement(By.XPath(".//*[@id='Errors']")).Text);
        }
    }
}
