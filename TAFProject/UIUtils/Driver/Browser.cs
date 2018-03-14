using OpenQA.Selenium;
using TAFProject.Models;

namespace TAFProject.UIUtils.Driver
{
    public class Browser
    {
        public int ImpWait { get; }
        public IWebDriver Driver { get; private set; }

        public Browser(IWebDriver driver, int timeout, BrowserType type)
        {
			Driver = driver;
            Driver = DriverFactory.GetDriver(type, timeout);
        }

        public void WindowMaximise()
        {
            Driver.Manage().Window.Maximize();
        }

        public void GoToUrl(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }

        public IWebElement FindElement(By locator)
        {
            return Driver.FindElement(locator);
        }

        public void Close()
        {
            Driver.Close();
        }

        public void Quit()
        {
            Driver.Quit();
            Driver = null;
        }
    }
}
