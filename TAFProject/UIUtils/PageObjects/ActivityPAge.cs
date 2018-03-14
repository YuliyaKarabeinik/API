using System.Linq;
using OpenQA.Selenium;
using TAFProject.UIUtils.Driver;

namespace TAFProject.UIUtils.PageObjects
{
    class ActivityPage : BasePage
    {
        static readonly By activityContentLocator = By.Id("activity");
        IWebElement activityContent;

		public ActivityPage() { }
		public ActivityPage(IWebDriver driver) : base(driver){}

        public bool IsIssueCreated(IWebDriver driver, string issueName)
        {
            activityContent = SearchElementUtil.GetElement(driver, activityContentLocator);
			return activityContent.FindElements(By.XPath("//dt//a")).Any(element => element.Text.Contains(issueName));
        }
    }
}