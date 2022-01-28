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
    public class HomeControllerTest {

        [Fact]
        public void NavItemsExist() {
            using SeleniumServerFactory<Startup> server = new("NavItemsExist");
            using ChromeDriver browser = new();
            browser.Navigate().GoToUrl(server.BaseAddress);

            IWebElement login = browser.FindElement(By.XPath(".//*[@id='LoginIn']"));
            IWebElement addImage = browser.FindElement(By.XPath(".//*[@id='AddImage']"));
        }

        [Fact]
        public void DefaultItemsHaveTwoPages() {
            using SeleniumServerFactory<Startup> server = new("DefaultItemsHaveTwoPages");
            using ChromeDriver browser = new();
            browser.Navigate().GoToUrl(server.BaseAddress);

            IWebElement next = browser.FindElement(By.XPath(".//*[@id='next']"));
            next.Click();
            IWebElement actual = browser.FindElement(By.XPath(".//*[@id='actual']"));
            String text = actual.Text;

            Assert.Equal("2", text);
        }
    }
}
