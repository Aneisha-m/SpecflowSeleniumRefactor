using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

namespace Eng24SeleniumSpecflow
{
    [Binding]
    public class BbcLoginSteps
    {
        private IWebDriver _driver;
        private BbcLoginPage _bbcLoginPage;

        [Given(@"I am on the login page")]
        public void GivenIAmOnTheLoginPage()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _bbcLoginPage = BbcLoginPage.NavigateTo(_driver);
            //_driver.Navigate().GoToUrl("http://bbc.co.uk");
            //IWebElement loginButton = _driver.FindElement(By.Id("idcta-link"));
            //loginButton.Click();
        }
        
        [Given(@"I entered a valid (.*)")]
        public void GivenIEnteredAValidUsername(string username)
        {
            _bbcLoginPage.Username = "user@username.com";
        }
        
        [Given(@"I have entered a invalid (.*)")]
        public void GivenIHaveEnteredAInvalidPassword(string password)
        {
            _bbcLoginPage.Password = "12345678";
        }
        
        [When(@"I press login")]
        public void WhenIPressLogin()
        {
            _bbcLoginPage.ClickSignin();
        }
        
        [Then(@"I shlould see the appropriate (.*)")]
        public void ThenIShlouldSeeTheAppropriateError(string error)
        {
            Assert.AreEqual("Sorry, that password isn't valid. Please include a letter.", _bbcLoginPage.ErrorText);
        }

        [AfterScenario]
        public void DisposeWebDriver()
        {
            _driver.Dispose();
        }
    }
}
