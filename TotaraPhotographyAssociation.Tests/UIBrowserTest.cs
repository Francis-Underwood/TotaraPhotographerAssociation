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
using System.Diagnostics;

namespace TotaraPhotographyAssociation.Tests
{
    [TestClass]
    public class UIBrowserTest
    {
        // Vincent 2016-11-4: the chrome driver doesn't work, and the 64-bit IE driver works pretty slow
        // for typing in text box in the pages. So now I changed to 32-bit IE driver
        private const string SCREENSHOT_LOCATION = @"D:\workcomplex\SeleniumShots";
        private const string IE_DRIVER_PATH = @"D:\workcomplex\SeleniumDrivers";

        private static IWebDriver driverChrome;
        private static IWebDriver driverIE;
        /*
         * Vincent: 20161107: http://stackoverflow.com/questions/4786884/how-to-write-output-from-a-unit-test
         */
        private TestContext testContextInstance;

        public static TestContext testContext { get; set; }

        // Vincent 2016-11-4: run automatically before any test method runs
        [AssemblyInitialize]
        public static void SetUp(TestContext tc)
        {
            testContext = tc;

            driverIE = new InternetExplorerDriver(IE_DRIVER_PATH);
            System.Threading.Thread.Sleep(6000);
            driverIE.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
        }

        // Vincent 2016-11-4: run automatically after any test method runs
        [AssemblyCleanup]
        public static void CleanUp()
        {
            driverIE.Quit();
        }

            // Vincent 2016-11-4: to disable this test temporarily
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

                // Vincent 2016-11-4: take a screenshot here
                Screenshot ss = ((ITakesScreenshot)driverIE).GetScreenshot();

                DateTime n = DateTime.Now;
                string fileNamePref = n.Year.ToString() + n.Month.ToString() + n.Day.ToString()
                            + n.Hour.ToString() + n.Minute.ToString() + n.Second.ToString()
                            + n.Millisecond.ToString();

                ss.SaveAsFile(SCREENSHOT_LOCATION + "\\" + fileNamePref + "_login.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);

                // Vincent 2016-11-4: get the new product menu, click it
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


                // Vincent 2016-11-4: click add to cart button
                IWebElement addToCartBtn = driverIE.FindElement(By.CssSelector("div.row.products div:nth-child(2) form a"));
                addToCartBtn.Click();
                System.Threading.Thread.Sleep(8000);

                ss = ((ITakesScreenshot)driverIE).GetScreenshot();
                n = DateTime.Now;
                fileNamePref = n.Year.ToString() + n.Month.ToString() + n.Day.ToString()
                            + n.Hour.ToString() + n.Minute.ToString() + n.Second.ToString()
                            + n.Millisecond.ToString();
                ss.SaveAsFile(SCREENSHOT_LOCATION + "\\" + fileNamePref + "_add-to-cart.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);

                // Vincent 2016-11-4: go to cart
                IWebElement cartMenuItem = driverIE.FindElement(By.LinkText("CART"));
                cartMenuItem.Click();
                System.Threading.Thread.Sleep(8000);

                ss = ((ITakesScreenshot)driverIE).GetScreenshot();
                n = DateTime.Now;
                fileNamePref = n.Year.ToString() + n.Month.ToString() + n.Day.ToString()
                            + n.Hour.ToString() + n.Minute.ToString() + n.Second.ToString()
                            + n.Millisecond.ToString();
                ss.SaveAsFile(SCREENSHOT_LOCATION + "\\" + fileNamePref + "_go-to-cart.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);



                // Vincent 2016-11-4: go to check out order
                IWebElement checkoutBtn = driverIE.FindElement(By.CssSelector("div.pull-right button:nth-child(2)"));
                checkoutBtn.Click();
                System.Threading.Thread.Sleep(8000);

                ss = ((ITakesScreenshot)driverIE).GetScreenshot();
                n = DateTime.Now;
                fileNamePref = n.Year.ToString() + n.Month.ToString() + n.Day.ToString()
                            + n.Hour.ToString() + n.Minute.ToString() + n.Second.ToString()
                            + n.Millisecond.ToString();
                ss.SaveAsFile(SCREENSHOT_LOCATION + "\\" + fileNamePref + "_check-out.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);



                // Vincent 2016-11-4: input first name
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


                // Vincent 2016-11-4: click 'Go to Paypal to finish the process' button, go to Paypal
                IWebElement goToPaypayBtn = driverIE.FindElement(By.CssSelector("div.pull-right button"));
                goToPaypayBtn.Click();
                System.Threading.Thread.Sleep(40000);  // for unknown reason, this is extremely slow in debug mode

                // Vincent 20161108: disable coz it seems to keep throwing exception
                /*
                ss = ((ITakesScreenshot)driverIE).GetScreenshot();
                n = DateTime.Now;
                fileNamePref = n.Year.ToString() + n.Month.ToString() + n.Day.ToString()
                            + n.Hour.ToString() + n.Minute.ToString() + n.Second.ToString()
                            + n.Millisecond.ToString();
                ss.SaveAsFile(SCREENSHOT_LOCATION + "\\" + fileNamePref + "_go-to-Paypal.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                */

                // Vincent 2016-11-8: Switch to the iframe
                IWebElement eleiframe = driverIE.FindElement(By.Name("injectedUl"));

                //string rif = eleiframe.GetAttribute("title");   // vincent 20161108: throw exception
                //Console.WriteLine("iframe title: " + rif);
                //Console.WriteLine("iframe title: " + rif);

                driverIE.SwitchTo().Frame(eleiframe);
                
                // Vincent 2016-11-4: log in paypal, stop working from here
                IWebElement ppLoginEmail = driverIE.FindElement(By.Name("login_email"));

                //string r = ppLoginEmail.GetAttribute("name");
                //Debug.WriteLine("login text: " + r);

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

                
                ppLoginPwd.Submit();
                System.Threading.Thread.Sleep(20000);

                ss = ((ITakesScreenshot)driverIE).GetScreenshot();
                n = DateTime.Now;
                fileNamePref = n.Year.ToString() + n.Month.ToString() + n.Day.ToString()
                            + n.Hour.ToString() + n.Minute.ToString() + n.Second.ToString()
                            + n.Millisecond.ToString();
                ss.SaveAsFile(SCREENSHOT_LOCATION + "\\" + fileNamePref + "_logged-in-Paypal.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);

/**/
                // Vincent 2016-11-4: authorize the payment
                IWebElement continueBtn = driverIE.FindElement(By.Id("confirmButtonTop"));
                continueBtn.Click();
                System.Threading.Thread.Sleep(30000);

                ss = ((ITakesScreenshot)driverIE).GetScreenshot();
                n = DateTime.Now;
                fileNamePref = n.Year.ToString() + n.Month.ToString() + n.Day.ToString()
                            + n.Hour.ToString() + n.Minute.ToString() + n.Second.ToString()
                            + n.Millisecond.ToString();
                ss.SaveAsFile(SCREENSHOT_LOCATION + "\\" + fileNamePref + "_redirected-back.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            

            }
            catch (Exception ex) {
                Console.WriteLine("L: " + ex.StackTrace);
                Console.WriteLine("L: " + ex.Message);
                Debug.WriteLine("L: " + ex.StackTrace);
                Trace.WriteLine("L: " + ex.StackTrace);
            }
            finally
            {
               
                driverIE.Quit();
            }
        }


        /*
         * Vincent 2016-11-6: this test simulate a procedure that admin log in and update AboutUs
         * cotent, and this one works fine.
         */
        [Ignore]    // Vincent 2016-11-6: to disable this test temporarily
        [TestMethod]
        public void TestUpdateAboutUs()
        {
            try
            {
                driverIE.Navigate().GoToUrl("http://localhost:42439/");

                /*
                 * Vincent 2016-11-6: first of all, log in with admin account
                 */
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

                /*
                 * Vincent 2016-11-6: Capture the screenshot, and save it as a jpeg.
                 */
                Screenshot ss = ((ITakesScreenshot)driverIE).GetScreenshot();

                DateTime n = DateTime.Now;
                string fileNamePref = n.Year.ToString() + n.Month.ToString() + n.Day.ToString()
                            + n.Hour.ToString() + n.Minute.ToString() + n.Second.ToString()
                            + n.Millisecond.ToString();

                ss.SaveAsFile(SCREENSHOT_LOCATION + "\\" + fileNamePref + "_login.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);

                // Vincent 2016-11-6: get the new product menu, click it
                IWebElement prdMenuItem = driverIE.FindElement(By.LinkText("EDIT ABOUT"));
                //IWebElement prdMenuItem = driverIE.FindElement(By.XPath("//a[contains(lower-case(.), \"product\")]"));    // TODO: does not work
                prdMenuItem.Click();
                System.Threading.Thread.Sleep(8000);

                // from official doc: http://www.seleniumhq.org/docs/03_webdriver.jsp 
                // And it does not work at all, it stops the execution.

                /*
                var wait = new WebDriverWait(driverIE, TimeSpan.FromSeconds(10));
                wait.Until(d => d.Title.StartsWith("editabout", StringComparison.OrdinalIgnoreCase));
                Console.WriteLine("Page title is: " + driverIE.Title); // TODO: does not work
                */

                ss = ((ITakesScreenshot)driverIE).GetScreenshot();
                n = DateTime.Now;
                fileNamePref = n.Year.ToString() + n.Month.ToString() + n.Day.ToString()
                            + n.Hour.ToString() + n.Minute.ToString() + n.Second.ToString()
                            + n.Millisecond.ToString();
                ss.SaveAsFile(SCREENSHOT_LOCATION + "\\" + fileNamePref + "_go-edit-about.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);

                /*
                 * Vincent 2016-11-6: TinyMCE creates an iFrame to host the editing area, and
                 * We need to switch the context to this iFrame first, and run within
                 * the iframe. And after we are finished with our business, we need to
                 * switch back to the default context.
                 */

                // Vincent 2016-11-6: switch to the iframe which holds the tinymce editor
                IWebElement eleiframe = driverIE.FindElement(By.Id("aboutus_ifr"));
                driverIE.SwitchTo().Frame(eleiframe);

                // Vincent 2016-11-6: get focus on the editor, by executing JavaScript 
                // http://stackoverflow.com/questions/15782564/set-focus-on-webelement
                ((IJavaScriptExecutor)driverIE).ExecuteScript("document.getElementById('tinymce').focus()");

                // Vincent 2016-11-6: get the body inside the iframe
                IWebElement element = driverIE.FindElement(By.Id("tinymce"));
                element.SendKeys("selenium unit test.");

                System.Threading.Thread.Sleep(8000);

                // Vin: capture screenshot
                ss = ((ITakesScreenshot)driverIE).GetScreenshot();
                n = DateTime.Now;
                fileNamePref = n.Year.ToString() + n.Month.ToString() + n.Day.ToString()
                            + n.Hour.ToString() + n.Minute.ToString() + n.Second.ToString()
                            + n.Millisecond.ToString();
                ss.SaveAsFile(SCREENSHOT_LOCATION + "\\" + fileNamePref + "_uptade-aboutus.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);

                // Vincent 2016-11-6: switch back to the iframe, seems not work, the execution stops here 
                driverIE.SwitchTo().DefaultContent();

                // Vincent 2016-11-6: click 'Save changes' button, to submit the form
                //IWebElement saveChangesBtn = driverIE.FindElement(By.CssSelector("#aboutForm button:submit"));    // TODO: this selector works fine with jQuery, but does not work here, and I dont know why 
                IWebElement saveChangesBtn = driverIE.FindElement(By.Id("saveAboutBtn"));
                saveChangesBtn.Click();
                System.Threading.Thread.Sleep(80000);

                ss = ((ITakesScreenshot)driverIE).GetScreenshot();
                n = DateTime.Now;
                fileNamePref = n.Year.ToString() + n.Month.ToString() + n.Day.ToString()
                            + n.Hour.ToString() + n.Minute.ToString() + n.Second.ToString()
                            + n.Millisecond.ToString();
                ss.SaveAsFile(SCREENSHOT_LOCATION + "\\" + fileNamePref + "_save-changes.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);

                System.Threading.Thread.Sleep(8000);

            }
            catch (Exception ex) { }
            finally
            {
                driverIE.Quit();
            }
        }


        /*
         * Vincent 2016-11-6: this test simulate a procedure that a member (either full or associate)
         * log in, and go to resource page and download one PDF, and this one works fine.
         */
        [Ignore]
        [TestMethod]
        public void TestDownloadPDF()
        {
            try
            {
                driverIE.Navigate().GoToUrl("http://localhost:42439/");
                /*
                 * Vincent 2016-11-6: first of all, log in with associate account account
                 */
                // by Id
                IWebElement eleALogin = driverIE.FindElement(By.Id("loginLink"));
                eleALogin.Click();
                System.Threading.Thread.Sleep(2000);

                // by Name
                IWebElement eleInputEmail = driverIE.FindElement(By.Name("Email"));
                eleInputEmail.SendKeys("daisy@example.com");
                System.Threading.Thread.Sleep(4000);

                // by Name
                IWebElement eleInputPwd = driverIE.FindElement(By.Name("Password"));
                eleInputPwd.SendKeys("[Freud 1900]");
                System.Threading.Thread.Sleep(4000);

                eleInputPwd.Submit();
                System.Threading.Thread.Sleep(6000);

                /*
                 * Vincent 2016-11-6: Capture the screenshot, and save it as a jpeg.
                 */
                Screenshot ss = ((ITakesScreenshot)driverIE).GetScreenshot();

                DateTime n = DateTime.Now;
                string fileNamePref = n.Year.ToString() + n.Month.ToString() + n.Day.ToString()
                            + n.Hour.ToString() + n.Minute.ToString() + n.Second.ToString()
                            + n.Millisecond.ToString();

                ss.SaveAsFile(SCREENSHOT_LOCATION + "\\" + fileNamePref + "_login.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                Console.WriteLine("saving login screenshot");   // Vince 20161107: works

                // Vincent 2016-11-6: get the resource menu item, click it, going to resource page
                IWebElement prdMenuItem = driverIE.FindElement(By.LinkText("RESOURCE"));
                prdMenuItem.Click();
                System.Threading.Thread.Sleep(8000);

                ss = ((ITakesScreenshot)driverIE).GetScreenshot();
                n = DateTime.Now;
                fileNamePref = n.Year.ToString() + n.Month.ToString() + n.Day.ToString()
                            + n.Hour.ToString() + n.Minute.ToString() + n.Second.ToString()
                            + n.Millisecond.ToString();
                ss.SaveAsFile(SCREENSHOT_LOCATION + "\\" + fileNamePref + "_go-resource.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                Trace.WriteLine("saving resource screenshot");  // Vince 20161107: works

                // Vincent 2016-11-6: get the first pdf download link
                IWebElement firstPDFLink = driverIE.FindElement(By.CssSelector("#text-page p:nth-child(2) a"));    // TODO: this selector works fine with jQuery, but does not work here, and I dont know why 
                firstPDFLink.Click();
                System.Threading.Thread.Sleep(80000);

                ss = ((ITakesScreenshot)driverIE).GetScreenshot();
                n = DateTime.Now;
                fileNamePref = n.Year.ToString() + n.Month.ToString() + n.Day.ToString()
                            + n.Hour.ToString() + n.Minute.ToString() + n.Second.ToString()
                            + n.Millisecond.ToString();
                ss.SaveAsFile(SCREENSHOT_LOCATION + "\\" + fileNamePref + "_download-fst-pdf.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                //Debug.WriteLine("saving download pdf screenshot");  // does not work because it is not in debug mode

                System.Threading.Thread.Sleep(8000);
                //TestContext.WriteLine("test ends"); // does not work for unknown reason

            }
            catch (Exception ex) { }
            finally
            {
                driverIE.Quit();
            }
        }

        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

    }


}
