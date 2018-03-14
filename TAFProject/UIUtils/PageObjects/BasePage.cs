using OpenQA.Selenium;
using TAFProject.UIUtils.Driver;

namespace TAFProject.UIUtils.PageObjects
{
    public abstract class BasePage
    {
		private int timeout = 10;//default
        public IWebDriver driver { get; set; }
		public BasePage() { }

		public BasePage(IWebDriver driver)
        {
			this.driver = driver;
			SearchElementUtil.WaitElement(driver, By.XPath("//title"), timeout);
		}
    }
}
