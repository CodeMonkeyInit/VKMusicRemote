using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace VKMusicRemote.Selenium.Login
{
    internal class VkVkLoginManager : IVkLoginManager
    {
        private const string LoggedInClass = "top_profile_name";

        private const string LoginFieldId = "index_email";

        private const string PasswordFieldId = "index_pass";

        private const string LoginButtonId = "index_login_button";

        private const string TwoFactorInputId = "authcheck_code";

        private const string TwoFactorSumbitButtonId = "login_authcheck_submit_btn";

        private const string LogoutButtonId = "top_logout_link";

        public string UserName { get; private set; }

        public bool IsLogged(IWebDriver browser)
        {
            try
            {
                WebDriverWait waitForElement = new WebDriverWait(browser, TimeSpan.FromSeconds(2));

                waitForElement.Until(ExpectedConditions.ElementIsVisible(By.ClassName(LoggedInClass)));

                IWebElement userName = browser.FindElement(By.ClassName(LoggedInClass));

                UserName = userName.Text;
            }
            catch (Exception e) when (e is NoSuchElementException || e is WebDriverTimeoutException)
            {
                return false;
            }

            return true;
        }

        public LoginInformation Login(string login, string password, IWebDriver browser)
        {
            var loginInformation = new LoginInformation();

            IWebElement loginField = browser.FindElement(By.Id(LoginFieldId));

            IWebElement passwordField = browser.FindElement(By.Id(PasswordFieldId));

            IWebElement loginButton = browser.FindElement(By.Id(LoginButtonId));

            if (IsLogged(browser))
            {
                throw new InvalidOperationException("Already logged in");
            }

            if (browser.Url.ToLower() != VkClient.VkLoginPage)
            {
                throw new InvalidOperationException(nameof(browser.Url));
            }

            loginField.SendKeys(login);

            passwordField.SendKeys(password);

            loginButton.Click();

            if (IsLogged(browser))
            {
                loginInformation.Success = true;

                return loginInformation;
            }

            loginInformation.Success = false;

            try
            {
                IWebElement twoFactorInput = browser.FindElement(By.Id(TwoFactorInputId));

                loginInformation.ErrorType = LoginError.TwoFactorAuthenticationRequired;
            }
            catch (NoSuchElementException e)
            {
                loginInformation.ErrorMessage = e.Message;

                loginInformation.ErrorType = LoginError.UnableToLogin;
            }

            return loginInformation;
        }

        public bool TwoFactorAuthentication(string authenticationCode, IWebDriver browser)
        {
            try
            {
                IWebElement twoFactorInput = browser.FindElement(By.Id(TwoFactorInputId));

                IWebElement submitButton = browser.FindElement(By.Id(TwoFactorSumbitButtonId));

                twoFactorInput.Clear();

                twoFactorInput.SendKeys(authenticationCode);

                submitButton.Click();

                if (IsLogged(browser))
                {
                    return true;
                }
            }
            catch (NoSuchElementException)
            {
                throw new InvalidOperationException("No two factor authentication found");
            }

            return false;
        }

        public bool Logout(IWebDriver browser)
        {
            try
            {
                IWebElement logoutButton = browser.FindElement(By.Id(LogoutButtonId));
            }
            catch (NoSuchElementException)
            {
                throw new InvalidOperationException();
            }

            return true;
        }
    }
}