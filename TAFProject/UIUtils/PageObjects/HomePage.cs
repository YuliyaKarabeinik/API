using OpenQA.Selenium;
using TAFProject.UIUtils.Driver;

namespace TAFProject.UIUtils.PageObjects
{
    public class HomePage : BasePage
    {
        static readonly By loginIdentifierLocator = By.XPath("//*[@id='loggedas']//*[@class='user active']"),
						   logoutLocator = By.XPath("//a[@class='logout']");
        IWebElement logout, loginIdentifier;

		public HomePage() { }
		public HomePage(IWebDriver driver) : base(driver)
        {
            loginIdentifier = SearchElementUtil.GetElement(driver, loginIdentifierLocator);
        }

        public string GetCurrentUser() => loginIdentifier.Text;
        
        public bool IsLogIn()
        {
            if (loginIdentifier == null)
                return false;
            return true;
        }

        public LoginPage LogoutHomePage()
        {
            logout = SearchElementUtil.GetElement(driver, logoutLocator);
            logout.Click();
            return new LoginPage();
        }
    }
}
