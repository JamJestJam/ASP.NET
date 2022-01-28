using ASP.net_Aplication;
using ASP.net_Aplication.Extends;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace ASP.net_Aplication_Test {
    public class CommentControlerTest {
        [Fact]
        public void AddComment() {
            using SeleniumServerFactory<Startup> server = new("AddComment");
            using ChromeDriver browser = new(new ChromeOptions() { AcceptInsecureCertificates = true });
            browser.Navigate().GoToUrl($"{server.BaseAddress}Image?imageID={StaticData.images[0].ImageID}");

            browser.FindElement(By.XPath(".//*[@id='LoginIn']")).Click();
            browser.FindElement(By.XPath(".//*[@name='Login']")).SendKeys("admin");
            browser.FindElement(By.XPath(".//*[@name='Password']")).SendKeys("zaq1@WSX");
            browser.FindElement(By.XPath(".//*[@value='Zaloguj się']")).Click();
            browser.FindElement(By.XPath(".//*[@id='CommentText']")).SendKeys("Nowy komentarz prosto z testów");
            browser.FindElement(By.XPath(".//*[@value='Dodaj']")).Click();

            Assert.Contains("Nowy komentarz prosto z testów", browser.FindElement(By.XPath(".//*[@class='card-body CommentText']")).Text);
        }

        [Fact]
        public void UpdateComment() {
            using SeleniumServerFactory<Startup> server = new("UpdateComment");
            using ChromeDriver browser = new();
            browser.Navigate().GoToUrl($"{server.BaseAddress}Image?imageID={StaticData.images[0].ImageID}");

            browser.FindElement(By.XPath(".//*[@id='LoginIn']")).Click();
            browser.FindElement(By.XPath(".//*[@name='Login']")).SendKeys("admin");
            browser.FindElement(By.XPath(".//*[@name='Password']")).SendKeys("zaq1@WSX");
            browser.FindElement(By.XPath(".//*[@value='Zaloguj się']")).Click();
            browser.FindElement(By.XPath(".//*[@class='Mask Commentt Edit']")).Click();
            browser.FindElement(By.XPath(".//*[@name='CommentText']")).SendKeys("Nowy bardzo fajny edytowany komentarz");
            browser.FindElement(By.XPath(".//*[@value='Save']")).Click();

            Assert.Contains("Nowy bardzo fajny edytowany komentarz", browser.FindElement(By.XPath(".//*[@class='card-body CommentText']")).Text);
        }

        [Fact]
        public void DeleteComment() {
            using SeleniumServerFactory<Startup> server = new("DeleteComment");
            using ChromeDriver browser = new();
            browser.Navigate().GoToUrl($"{server.BaseAddress}Image?imageID={StaticData.images[0].ImageID}");

            browser.FindElement(By.XPath(".//*[@id='LoginIn']")).Click();
            browser.FindElement(By.XPath(".//*[@name='Login']")).SendKeys("admin");
            browser.FindElement(By.XPath(".//*[@name='Password']")).SendKeys("zaq1@WSX");
            browser.FindElement(By.XPath(".//*[@value='Zaloguj się']")).Click();
            browser.FindElement(By.XPath(".//*[@class='Mask Commentt Delete']")).Click();
            browser.FindElement(By.XPath(".//*[@value='Delete']")).Click();
            ReadOnlyCollection<IWebElement> elementts = browser.FindElements(By.XPath(".//*[@class='col-9 card Commentt']"));

            Assert.True(elementts.Count == 0);
        }
    }
}
