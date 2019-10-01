using System;
using System.Text;
using System.IO;
using System.Net;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace FirstSeleniumWebScraper
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl("http://testing-ground.scraping.pro/login");

                var userNameField = driver.FindElementById("usr");
                var userPasswordField = driver.FindElementById("pwd");
                var loginButton = driver.FindElementByXPath("//input[@value='Login']");

                userNameField.SendKeys("admin");
                userPasswordField.SendKeys("12345");
                loginButton.Click();

                var result = driver.FindElementByXPath("//div[@id='case_login']/h3").Text;

                File.WriteAllText("result.txt", result);

                driver.GetScreenshot().SaveAsFile(@"screenshottest.png", ScreenshotImageFormat.Png);
            }
        }
    }
}
