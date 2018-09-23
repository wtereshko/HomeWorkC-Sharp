using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace HW_Automated
{
    [TestFixture]
    public class TestClass
    {
        private IWebDriver driver;
        private UserData.User user;

        [OneTimeSetUp]
        public void CreateNecessaryObjects()
        {
            user = UserData.GetUserData();
            driver = new ChromeDriver();
        }

        [OneTimeTearDown]
        public void ClearResources()
        {
            driver.Quit();
            driver.Dispose();
        }

        [Test]
        public void FillFormsFields()
        {
            //fill fields
            driver.Navigate().GoToUrl("http://atqc-shop.epizy.com/index.php?route=account/register");
            driver.FindElement(By.Id("input-firstname")).SendKeys(user.firstName);
            driver.FindElement(By.Id("input-lastname")).SendKeys(user.lastName);
            driver.FindElement(By.Id("input-email")).SendKeys(user.email);
            driver.FindElement(By.Id("input-telephone")).SendKeys(user.telephone);
            driver.FindElement(By.Id("input-fax")).SendKeys(user.fax);
            driver.FindElement(By.Id("input-company")).SendKeys(user.company);
            driver.FindElement(By.Id("input-address-1")).SendKeys(user.address_1);
            driver.FindElement(By.Id("input-address-2")).SendKeys(user.address_2);
            driver.FindElement(By.Id("input-city")).SendKeys(user.city);
            driver.FindElement(By.Id("input-postcode")).SendKeys(user.postCode);
            driver.FindElement(By.Id("input-country")).SendKeys(user.country);
            
            driver.FindElement(By.Id("input-zone")).SendKeys(user.region);
            driver.FindElement(By.Id("input-password")).SendKeys(user.password);
            driver.FindElement(By.Id("input-confirm")).SendKeys(user.password);
            
            //check Yes radio button
            IList<IWebElement> radioButton = driver.FindElements(By.Name("newsletter"));
            bool bClick = radioButton.ElementAt(0).Selected;
            if (bClick == true)
            {
               radioButton.ElementAt(1).Click();
            }
            else
            {
                radioButton.ElementAt(0).Click();
            }

            //check privacy check box
            IWebElement privacy = driver.FindElement(By.Name("agree"));
            privacy.Click();

            // click button Continue
            //IWebElement sumbit = driver.FindElement(By.ClassName("btn btn-primary"));
            //sumbit.Click();

            Assert.Pass("Your first passing test");
        }
    }
}
