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
        static IWebDriver driverChrome;
        static IWebDriver driverIE;

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
            driverIE.Navigate().GoToUrl("http://localhost:42439/");

        }


    }


}
