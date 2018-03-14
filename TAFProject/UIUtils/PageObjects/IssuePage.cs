using OpenQA.Selenium;

namespace TAFProject.UIUtils.PageObjects
{
    class IssuePage: BasePage
    {
        static readonly string issueTableXPathLocator = "//div[@id='content']//table";

		public IssuePage() { }
		public IssuePage(IWebDriver driver) : base(driver){ }
	
        public IssueTable Table => new IssueTable(driver.FindElement(By.XPath(issueTableXPathLocator)));

    }
}
