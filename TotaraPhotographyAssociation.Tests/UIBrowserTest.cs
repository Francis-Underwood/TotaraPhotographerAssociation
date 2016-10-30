using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;

namespace TotaraPhotographyAssociation.Tests
{
    [TestClass]
    public class UIBrowserTest
    {
        private const string ScreenShotLocation = @"D:\workcomplex\SeleniumShots";

        private static IWebDriver driverChrome;
        private static IWebDriver driverIE;

        public static TestContext testContext { get; set; }

        [AssemblyInitialize]
        public static void SetUp(TestContext tc)
        {
            testContext = tc;
            /*
            driverChrome = new ChromeDriver();
            System.Threading.Thread.Sleep(6000);
            driverChrome.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            */

            driverIE = new InternetExplorerDriver(@"D:\workcomplex\SeleniumDrivers");
            System.Threading.Thread.Sleep(6000);
            driverIE.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
        }
/*
        [AssemblyCleanup]
        public static void CleanUp()
        {
            driverChrome.Quit();
        }
        */

        [TestMethod]
        public void TestLogin()
        {
            //IWebDriver driver = new ChromeDriver(@"D:\workcomplex\SeleniumDrivers");
            /*
            IWebDriver driver = new InternetExplorerDriver(@"D:\workcomplex\SeleniumDrivers");
            System.Threading.Thread.Sleep(6000);
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            driver.Navigate().GoToUrl("http://localhost:42439/");
            */
            //driverChrome.Navigate().GoToUrl("http://localhost:42439/");
            try
            {
                driverIE.Navigate().GoToUrl("http://localhost:42439/");

                // by Id
                IWebElement eleALogin = driverIE.FindElement(By.Id("loginLink"));
                eleALogin.Click();
                System.Threading.Thread.Sleep(2000);

                // by Name
                IWebElement eleInputEmail = driverIE.FindElement(By.Name("Email"));
                eleInputEmail.SendKeys("aaron@example.com");
                System.Threading.Thread.Sleep(4000);

                // by Name
                IWebElement eleInputPwd = driverIE.FindElement(By.Name("Password"));
                eleInputPwd.SendKeys("[Freud 1900]");
                System.Threading.Thread.Sleep(4000);

                eleInputPwd.Submit();

                Screenshot ss = ((ITakesScreenshot)driverIE).GetScreenshot();
                ss.SaveAsFile(ScreenShotLocation + "\\" + "result.jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);

            }
            catch (Exception ex) { }
            finally
            {
                driverIE.Quit();
            }
        }


    }


}
