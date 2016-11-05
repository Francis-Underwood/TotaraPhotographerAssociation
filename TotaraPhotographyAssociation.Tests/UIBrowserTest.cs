﻿using System;
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

        [Ignore]
        [TestMethod]
        public void TestShoppingCheckout()
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
                eleInputEmail.SendKeys("conan@example.com");
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

                DateTime n = DateTime.Now;
                string fileNamePref = n.Year.ToString() + n.Month.ToString() + n.Day.ToString()
                            + n.Hour.ToString() + n.Minute.ToString() + n.Second.ToString()
                            + n.Millisecond.ToString();

                ss.SaveAsFile(SCREENSHOT_LOCATION + "\\" + fileNamePref + "_login.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);

                // Vincent: get the new product menu, click it
                IWebElement prdMenuItem = driverIE.FindElement(By.LinkText("NEW PRODUCT"));
                //IWebElement prdMenuItem = driverIE.FindElement(By.XPath("//a[contains(lower-case(.), \"product\")]")); 
                prdMenuItem.Click();
                System.Threading.Thread.Sleep(8000);

                ss = ((ITakesScreenshot)driverIE).GetScreenshot();
                n = DateTime.Now;
                fileNamePref = n.Year.ToString() + n.Month.ToString() + n.Day.ToString()
                            + n.Hour.ToString() + n.Minute.ToString() + n.Second.ToString()
                            + n.Millisecond.ToString();
                ss.SaveAsFile(SCREENSHOT_LOCATION + "\\" + fileNamePref + "_go-new-product.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);


                // Vincent: click add to cart button
                IWebElement addToCartBtn = driverIE.FindElement(By.CssSelector("div.row.products div:nth-child(2) form a"));
                addToCartBtn.Click();
                System.Threading.Thread.Sleep(8000);

                ss = ((ITakesScreenshot)driverIE).GetScreenshot();
                n = DateTime.Now;
                fileNamePref = n.Year.ToString() + n.Month.ToString() + n.Day.ToString()
                            + n.Hour.ToString() + n.Minute.ToString() + n.Second.ToString()
                            + n.Millisecond.ToString();
                ss.SaveAsFile(SCREENSHOT_LOCATION + "\\" + fileNamePref + "_add-to-cart.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);

                //System.Threading.Thread.Sleep(8000);

                /**/
                // Vincent: go to cart
                IWebElement cartMenuItem = driverIE.FindElement(By.LinkText("CART"));
                cartMenuItem.Click();
                System.Threading.Thread.Sleep(8000);

                ss = ((ITakesScreenshot)driverIE).GetScreenshot();
                n = DateTime.Now;
                fileNamePref = n.Year.ToString() + n.Month.ToString() + n.Day.ToString()
                            + n.Hour.ToString() + n.Minute.ToString() + n.Second.ToString()
                            + n.Millisecond.ToString();
                ss.SaveAsFile(SCREENSHOT_LOCATION + "\\" + fileNamePref + "_go-to-cart.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);



                // Vincent: go to check out order
                IWebElement checkoutBtn = driverIE.FindElement(By.CssSelector("div.pull-right button:nth-child(2)"));
                checkoutBtn.Click();
                System.Threading.Thread.Sleep(8000);

                ss = ((ITakesScreenshot)driverIE).GetScreenshot();
                n = DateTime.Now;
                fileNamePref = n.Year.ToString() + n.Month.ToString() + n.Day.ToString()
                            + n.Hour.ToString() + n.Minute.ToString() + n.Second.ToString()
                            + n.Millisecond.ToString();
                ss.SaveAsFile(SCREENSHOT_LOCATION + "\\" + fileNamePref + "_check-out.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);



                // Vincent: input first name
                IWebElement eleInputFName = driverIE.FindElement(By.Name("RecepientFirstName"));
                eleInputFName.SendKeys("Vincent");
                System.Threading.Thread.Sleep(4000);
                // Vincent: input last name
                IWebElement eleInputLName = driverIE.FindElement(By.Name("RecepientLastName"));
                eleInputLName.SendKeys("Deng");
                System.Threading.Thread.Sleep(4000);
                // Vincent: input line 1
                IWebElement eleInputLine1 = driverIE.FindElement(By.Name("DeliveryAddressLine_1"));
                eleInputLine1.SendKeys("MIT Student Village Gate 15, 74 Alexander Crescent, Otara");
                System.Threading.Thread.Sleep(4000);
                // Vincent: input line 2
                IWebElement eleInputLine2 = driverIE.FindElement(By.Name("DeliveryAddressLine_2"));
                eleInputLine2.SendKeys("Auckland New Zealand");
                System.Threading.Thread.Sleep(4000);
                // Vincent: input postal code
                IWebElement eleInputPostalCode = driverIE.FindElement(By.Name("PostalCode"));
                eleInputPostalCode.SendKeys("2023");
                System.Threading.Thread.Sleep(4000);
                // Vincent: input phone
                IWebElement eleInputRecepientPhone = driverIE.FindElement(By.Name("RecepientPhone"));
                eleInputRecepientPhone.SendKeys("0226261897");
                System.Threading.Thread.Sleep(4000);
                // Vincent: input email
                IWebElement eleInputRecepientEmail = driverIE.FindElement(By.Name("RecepientEmail"));
                eleInputRecepientEmail.SendKeys("ajaxguru-vincent@hotmail.com");
                System.Threading.Thread.Sleep(4000);

                ss = ((ITakesScreenshot)driverIE).GetScreenshot();
                n = DateTime.Now;
                fileNamePref = n.Year.ToString() + n.Month.ToString() + n.Day.ToString()
                            + n.Hour.ToString() + n.Minute.ToString() + n.Second.ToString()
                            + n.Millisecond.ToString();
                ss.SaveAsFile(SCREENSHOT_LOCATION + "\\" + fileNamePref + "_fill-in-order.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);


                // Vincent: click 'Go to Paypal to finish the process' button, go to Paypal
                IWebElement goToPaypayBtn = driverIE.FindElement(By.CssSelector("div.pull-right button"));
                goToPaypayBtn.Click();
                System.Threading.Thread.Sleep(80000);

                ss = ((ITakesScreenshot)driverIE).GetScreenshot();
                n = DateTime.Now;
                fileNamePref = n.Year.ToString() + n.Month.ToString() + n.Day.ToString()
                            + n.Hour.ToString() + n.Minute.ToString() + n.Second.ToString()
                            + n.Millisecond.ToString();
                ss.SaveAsFile(SCREENSHOT_LOCATION + "\\" + fileNamePref + "_go-to-Paypal.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);



                // Vincent: log in paypal
                IWebElement ppLoginEmail = driverIE.FindElement(By.Name("login_email"));
                ppLoginEmail.SendKeys("vincent-lz-zhang-buyer@hotmail.com");
                System.Threading.Thread.Sleep(4000);

                IWebElement ppLoginPwd = driverIE.FindElement(By.Name("login_password"));
                ppLoginPwd.SendKeys("[Jung&1906]");
                System.Threading.Thread.Sleep(4000);

                ss = ((ITakesScreenshot)driverIE).GetScreenshot();
                n = DateTime.Now;
                fileNamePref = n.Year.ToString() + n.Month.ToString() + n.Day.ToString()
                            + n.Hour.ToString() + n.Minute.ToString() + n.Second.ToString()
                            + n.Millisecond.ToString();
                ss.SaveAsFile(SCREENSHOT_LOCATION + "\\" + fileNamePref + "_fill-in-Paypal-login.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);

                /*
                ppLoginPwd.Submit();
                System.Threading.Thread.Sleep(20000);

                ss = ((ITakesScreenshot)driverIE).GetScreenshot();
                n = DateTime.Now;
                fileNamePref = n.Year.ToString() + n.Month.ToString() + n.Day.ToString()
                            + n.Hour.ToString() + n.Minute.ToString() + n.Second.ToString()
                            + n.Millisecond.ToString();
                ss.SaveAsFile(SCREENSHOT_LOCATION + "\\" + fileNamePref + "_logged-in-Paypal.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);


                // Vincent: authorize the payment
                IWebElement continueBtn = driverIE.FindElement(By.Id("confirmButtonTop"));
                continueBtn.Click();
                System.Threading.Thread.Sleep(30000);

                ss = ((ITakesScreenshot)driverIE).GetScreenshot();
                n = DateTime.Now;
                fileNamePref = n.Year.ToString() + n.Month.ToString() + n.Day.ToString()
                            + n.Hour.ToString() + n.Minute.ToString() + n.Second.ToString()
                            + n.Millisecond.ToString();
                ss.SaveAsFile(SCREENSHOT_LOCATION + "\\" + fileNamePref + "_redirected-back.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            */

            }
            catch (Exception ex) { }
            finally
            {
                driverIE.Quit();
            }
        }



        [TestMethod]
        public void TestUpdateAboutUs()
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
                eleInputEmail.SendKeys("vince@example.com");
                System.Threading.Thread.Sleep(4000);

                // by Name
                IWebElement eleInputPwd = driverIE.FindElement(By.Name("Password"));
                eleInputPwd.SendKeys("[Freud 1900]");
                System.Threading.Thread.Sleep(4000);

                eleInputPwd.Submit();
                System.Threading.Thread.Sleep(6000);

                Screenshot ss = ((ITakesScreenshot)driverIE).GetScreenshot();

                DateTime n = DateTime.Now;
                string fileNamePref = n.Year.ToString() + n.Month.ToString() + n.Day.ToString()
                            + n.Hour.ToString() + n.Minute.ToString() + n.Second.ToString()
                            + n.Millisecond.ToString();

                ss.SaveAsFile(SCREENSHOT_LOCATION + "\\" + fileNamePref + "_login.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);

                // Vincent: get the new product menu, click it
                IWebElement prdMenuItem = driverIE.FindElement(By.LinkText("EDIT ABOUT"));
                //IWebElement prdMenuItem = driverIE.FindElement(By.XPath("//a[contains(lower-case(.), \"product\")]")); 
                prdMenuItem.Click();
                System.Threading.Thread.Sleep(8000);

                ss = ((ITakesScreenshot)driverIE).GetScreenshot();
                n = DateTime.Now;
                fileNamePref = n.Year.ToString() + n.Month.ToString() + n.Day.ToString()
                            + n.Hour.ToString() + n.Minute.ToString() + n.Second.ToString()
                            + n.Millisecond.ToString();
                ss.SaveAsFile(SCREENSHOT_LOCATION + "\\" + fileNamePref + "_go-edit-about.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);

                /*
                driverIE.SwitchTo().Frame("top");
                IWebElement element = (IWebElement)((IJavaScriptExecutor)driverIE).ExecuteScript("tinymce.activeEditor.setContent('<p>Selenium unit test.</p>')");
                */

                /*
                driverIE.SwitchTo().Frame("aboutus_ifr");
                IWebElement element = driverIE.FindElement(By.CssSelector("body"));
                element.SendKeys("<p>selenium unit test.</p>");
                */


                //driverIE.SwitchTo().Frame("aboutus_ifr");
                /*
                 * Vincent: TinyMCE creates an iFrame to host the editing area, and
                 * We need to switch the context to this iFrame first, and run within
                 * the iframe. And after we are finished with our business, we need to
                 * switch back to the default context.
                 */ 

                // Vincent: switch to the iframe which holds the tinymce editor
                IWebElement eleiframe = driverIE.FindElement(By.Id("aboutus_ifr"));
                driverIE.SwitchTo().Frame(eleiframe);
               
                //System.Threading.Thread.Sleep(800);

                //IWebElement element = driverIE.FindElement(By.CssSelector("body"));
                //element.SendKeys("<p>selenium unit test.</p>");

                //((IJavaScriptExecutor)driverIE).ExecuteScript("tinymce.activeEditor.setContent('<p>Selenium unit test.</p>')");

                IWebElement element = driverIE.FindElement(By.Id("tinymce"));
                element.SendKeys("selenium unit test.");


                System.Threading.Thread.Sleep(8000);

                //((IJavaScriptExecutor)driverIE).ExecuteScript("arguments[0].innerHTML = '<h1>selenium test</h1>'", element);


                ss = ((ITakesScreenshot)driverIE).GetScreenshot();
                n = DateTime.Now;
                fileNamePref = n.Year.ToString() + n.Month.ToString() + n.Day.ToString()
                            + n.Hour.ToString() + n.Minute.ToString() + n.Second.ToString()
                            + n.Millisecond.ToString();
                ss.SaveAsFile(SCREENSHOT_LOCATION + "\\" + fileNamePref + "_uptade-aboutus.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);

                // Vincent: switch back to the iframe 
                driverIE.SwitchTo().DefaultContent();



            }
            catch (Exception ex) { }
            finally
            {
                driverIE.Quit();
            }
        }

    }


}
