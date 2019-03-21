using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;


namespace Eng24SeleniumSpecflow
{
    public class BbcLoginPage
    {
        //PageFactory Objects
        private readonly IWebDriver _driver;
        [FindsBy(How = How.Id, Using = "user-identifier-input")]
        private IWebElement _username;
        [FindsBy(How = How.Id, Using = "password-input")]
        private IWebElement _password;
        [FindsBy(How = How.Id, Using = "submit-button")]
        private IWebElement _submitButton;
        [FindsBy(How = How.Id, Using = "form-message-password")]
        private IWebElement _errorText;
        private const string PageUri = @"http://bbc.co.uk/signin";


        public BbcLoginPage(IWebDriver driver)
        {
            _driver = driver;

            PageFactory.InitElements(_driver, this);
        }


        public static BbcLoginPage NavigateTo(IWebDriver driver)
        {
            driver.Navigate().GoToUrl(PageUri);
            return new BbcLoginPage(driver);
        }

        public string Username
        {
            set{ _username.SendKeys(value); }
        }

        public string Password
        {
            set { _password.SendKeys(value); }
        }

        public void ClickSignin()
        {
            _submitButton.Click();
        }

        public string ErrorText =>
            _errorText.Text;
        // => shorthand for a getter in this context
    }
}
