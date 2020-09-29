using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using Xunit;

namespace SpecFlowProject1.Steps
{
    [Binding]
    class LoginTest
    {

        private ChromeDriver driver;
        private WebDriverWait wait;

        public LoginTest() {
            driver = new ChromeDriver();
             wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
        }

        [Given(@"Navigate to AutomationPractice website")]
        
        public void GivenNavigateToAutomationPracticeWebsite()
        {
            driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
            Assert.Contains("My Store", driver.Title);
        }
    
     
        [Given(@"Click on Sign In button")]
        public void GivenClickOnSignInButton()
        {
            driver.FindElementByCssSelector("a.login").Click();
           
            var email = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("email")));
            Assert.Contains("Login - My Store", driver.Title);
        }

         
        [When(@"Enter Username and Password")]
        public void WhenEnterUsernameAndPassword() {

            driver.FindElementById("email").SendKeys("megha.saxena@gmail.com");
            driver.FindElementById("passwd").SendKeys("December1!");
            driver.FindElementById("SubmitLogin").Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".myaccount-link-list")));
            

        }

         
        [Then(@"User should be able to login successfully")]
        public void ThenUserShouldBeAbleToLoginSuccessfully() {
            Assert.Contains("My account - My Store", driver.Title);

                        
        }
    }
}
