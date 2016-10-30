using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;

namespace TotaraPhotographyAssociation.Tests
{
    [TestClass]
    public class UIBrowserTest
    {
        // Vincent: the chrome driver doesn't work, and the 64-bit IE driver works pretty slow
        // for typing in text box in the pages. So now I changed to 32-bit IE driver
        private const string SCREENSHOT_LOCATION = @"D:\workcomplex\SeleniumShots";
        private const string IE_DRIVER_PATH = @"D:\workcomplex\SeleniumDrivers";

        private static IWebDriver driverChrome;
        private static IWebDriver driverIE;

        public static TestContext testContext { get; set; }

        // Vincent: run automatically before any test method runs
        [AssemblyInitialize]
        public static void SetUp(TestContext tc)
        {
            testContext = tc;

            driverIE = new InternetExplorerDriver(IE_DRIVER_PATH);
            System.Threading.Thread.Sleep(6000);
            driverIE.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
        }

        // Vincent: run automatically after any test method runs
        [AssemblyCleanup]
        public static void CleanUp()
        {
            driverIE.Quit();
        }

        [TestMethod]
        public void TestLogin()
        {
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

                //WebDriverWait wait = new WebDriverWait(driverIE, TimeSpan.FromSeconds(10));
                //wait.Until((d) => { return d.Title.ToLower().StartsWith("employeelist"); });

                // by Name
                IWebElement eleInputPwd = driverIE.FindElement(By.Name("Password"));
                eleInputPwd.SendKeys("[Freud 1900]");
                System.Threading.Thread.Sleep(4000);

                eleInputPwd.Submit();
                System.Threading.Thread.Sleep(6000);

                // take a screenshot here
                Screenshot ss = ((ITakesScreenshot)driverIE).GetScreenshot();
                ss.SaveAsFile(SCREENSHOT_LOCATION + "\\" + "result.jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);

            }
            catch (Exception ex) { }
            finally
            {
                driverIE.Quit();
            }
        }


    }


}
