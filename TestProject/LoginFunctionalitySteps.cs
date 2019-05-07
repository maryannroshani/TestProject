using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;



namespace TestProject
{

    [Binding]
    public class LoginFunctionalitySteps
    {
        private IWebDriver driver;
        

        [Before]
        public void setUp()
        {
            driver = new ChromeDriver(@"C:\Dev\Tools");
        }

        [Given(@"I'm on the login Page")]
        public void GivenIMOnTheLoginPage()
        {
            driver.Navigate().GoToUrl("http://horse-dev.azurewebsites.net/Account/Login");
            driver.Manage().Window.Maximize();
        }
        
        [When(@"I enter credentials (.*) and (.*) and click login button")]
        public void WhenIEnterCredentialsHariAndAndClickLoginButton(string username, string password)
        {
            driver.FindElement(By.Id("UserName")).SendKeys(username);
            driver.FindElement(By.Id("Password")).SendKeys(password);
            driver.FindElement(By.XPath("//*[@id='loginForm']/form/div[3]/input[1]")).Click();
        }
        
        [Then(@"Verify I'm on Home Page")]
        public void ThenVerifyIMOnHomePage()
        {
            IWebElement homePage = driver.FindElement(By.XPath("//*[@id='logoutForm']/ul/li/a"));
            Assert.AreEqual(homePage.Text,"Hello hari!");
            
        }
        
        [Then(@"I can see Error message displayed")]
        public void ThenICanSeeErrorMessageDisplayed()
        {
            IWebElement loginErrorMessage = driver.FindElement(By.XPath("//*[@id='loginForm']/form/div[1]/ul/li"));
            Assert.AreEqual(loginErrorMessage.Text,("Invalid username or password."));
        }

        [After]
        public void closeDriver()
        {
            driver.Close();
        }
    } 
}
