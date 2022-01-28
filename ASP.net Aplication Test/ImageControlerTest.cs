using ASP.net_Aplication;
using ASP.net_Aplication.Extends;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Threading;
using Xunit;

namespace ASP.net_Aplication_Test {
    public class ImageControlerTest  {
        [Fact]
        public void AddImage() {
            using SeleniumServerFactory<Startup> server = new("AddImage");
            using ChromeDriver browser = new("AddImage");
            browser.Navigate().GoToUrl(server.BaseAddress);

            browser.FindElement(By.XPath(".//*[@id='AddImage']")).Click();
            browser.FindElement(By.XPath(".//*[@name='Login']")).SendKeys("admin");
            browser.FindElement(By.XPath(".//*[@name='Password']")).SendKeys("zaq1@WSX");
            browser.FindElement(By.XPath(".//*[@value='Zaloguj się']")).Click();
            browser.FindElement(By.XPath(".//*[@name='ImageTitle']")).SendKeys("Nowy obrazek tutaj jest");
            browser.FindElement(By.XPath(".//*[@name='ImageName']"))
                .SendKeys(Path.Combine(StaticData.path, $"ASP.net Aplication\\wwwroot\\firstImg\\Image1.jpg"));
            browser.FindElement(By.XPath(".//*[@value='Create']")).Click();

            Assert.Contains("Nowy obrazek tutaj jest", browser.FindElement(By.ClassName("ImageTitle")).Text);
        }

        [Fact]
        public void UpdateImageTitle() {
            using SeleniumServerFactory<Startup> server = new("UpdateImageTitle");
            using ChromeDriver browser = new("UpdateImageTitle");
            browser.Navigate().GoToUrl($"{server.BaseAddress}Image?imageID={StaticData.images[0].ImageID}");

            browser.FindElement(By.XPath(".//*[@id='LoginIn']")).Click();
            browser.FindElement(By.XPath(".//*[@name='Login']")).SendKeys("admin");
            browser.FindElement(By.XPath(".//*[@name='Password']")).SendKeys("zaq1@WSX");
            browser.FindElement(By.XPath(".//*[@value='Zaloguj się']")).Click();
            browser.FindElement(By.XPath(".//*[@class='Mask Image Edit']")).Click();
            browser.FindElement(By.XPath(".//*[@name='ImageTitle']")).SendKeys("To jest niedobry obrazek");
            browser.FindElement(By.XPath(".//*[@value='Save']")).Click();

            Assert.Contains("To jest niedobry obrazek", browser.FindElement(By.ClassName("ImageTitle")).Text);
        }

        [Fact]
        public void DeleteImage() {
            using SeleniumServerFactory<Startup> server = new("DeleteImage");
            using ChromeDriver browser = new("DeleteImage");
            browser.Navigate().GoToUrl($"{server.BaseAddress}Image?imageID={StaticData.images[0].ImageID}");

            browser.FindElement(By.XPath(".//*[@id='LoginIn']")).Click();
            browser.FindElement(By.XPath(".//*[@name='Login']")).SendKeys("admin");
            browser.FindElement(By.XPath(".//*[@name='Password']")).SendKeys("zaq1@WSX");
            browser.FindElement(By.XPath(".//*[@value='Zaloguj się']")).Click();
            browser.FindElement(By.XPath(".//*[@class='Mask Image Delete']")).Click();
            browser.FindElement(By.XPath(".//*[@value='Delete']")).Click();
            browser.Navigate().GoToUrl(server.BaseAddress + "Image?imageID=cda493c5-f7d1-4968-a2df-0c2162240fa0");

            Assert.Contains("HTTP ERROR 404", browser.FindElement(By.XPath(".//*[@jscontent='errorCode']")).Text);
        }
    }
}
