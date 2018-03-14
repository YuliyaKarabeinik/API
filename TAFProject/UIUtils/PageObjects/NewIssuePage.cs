using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TAFProject.Models;
using TAFProject.UIUtils.Driver;

namespace TAFProject.UIUtils.PageObjects
{
    public class NewIssuePage : BasePage
    {
        static readonly By locatorComboboxIssueType = By.XPath("//select[@id='issue_tracker_id']"),
            locatorTextboxSubject = By.XPath("//input[@id='issue_subject']"),
            locatorTextboxDescription = By.XPath("//textarea[@id='issue_description']"),
            locatorComboboxStatus = By.XPath("//select[@id='issue_status_id']"),
            locatorComboboxPriority = By.XPath("//select[@id='issue_priority_id']"),
            locatorButtonCreate = By.XPath("//input[@type='submit']");
        SelectElement comboboxIssueType, comboboxStatus, comboboxPriority;
        IWebElement textboxSubject, textboxDescription, buttonCreate;

		public NewIssuePage()
		{

		}
		public NewIssuePage(IWebDriver driver):base(driver){}

        public NewIssuePage SelectType(IssueType type)
        {
            comboboxIssueType = new SelectElement(SearchElementUtil.GetElement(driver, locatorComboboxIssueType));
            if (type != IssueType.Default)
                comboboxIssueType.SelectByText(type.ToString().Replace(" ", ""));
            return this;
        }
        public NewIssuePage SetSubject(string issueSubject)
        {
            textboxSubject = SearchElementUtil.GetElement(driver, locatorTextboxSubject);
            textboxSubject.SendKeys(issueSubject);
            return this;
        }
        public NewIssuePage SetDescription(string issueDescription)
        {
            textboxDescription = SearchElementUtil.GetElement(driver, locatorTextboxDescription);
            textboxDescription.SendKeys(issueDescription);
            return this;
        }
        public NewIssuePage SelectStatus(IssueStatus status)
        {
            comboboxStatus = new SelectElement(SearchElementUtil.GetElement(driver, locatorComboboxStatus));
            if (status != IssueStatus.Default)
                comboboxStatus.SelectByText(status.ToString().Replace(" ", ""));
            return this;
        }
        public NewIssuePage SelectPriority(IssuePriority priority)
        {
            comboboxPriority = new SelectElement(SearchElementUtil.GetElement(driver, locatorComboboxPriority));
            if (priority != IssuePriority.Default)
                comboboxPriority.SelectByText(priority.ToString());
            return this;
        }
        public CreatedIssuePage ClickCreate()
        {
            buttonCreate = SearchElementUtil.GetElement(driver, locatorButtonCreate);
            buttonCreate.Click();
            return new CreatedIssuePage(driver);
        }
    }
}