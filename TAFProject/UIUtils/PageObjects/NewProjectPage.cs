using OpenQA.Selenium;
using TAFProject.Models;
using TAFProject.UIUtils.Driver;

namespace TAFProject.UIUtils.PageObjects
{
    public class NewProjectPage : BasePage
    {
        static readonly By locatorTextboxProjectName = By.XPath("//input[@id='project_name']"),
            locatorTextboxProjectDescription = By.XPath("//textarea[@id='project_description']"),
            locatorTextboxProjectIdentifier = By.XPath("//input[@id='project_identifier']"),
            locatorTextboxHomepage = By.XPath("//input[@id='project_homepage']"),
            locatorCheckboxPublic = By.XPath("//input[@id='project_is_public']"),
            locatorComboboxSubOf = By.XPath("//select[@id='project_parent_id']"),
            locatorCheckboxInheritMembers = By.XPath("//input[@id='project_inherit_members']"),
            locatorButtonCreate = By.XPath("//input[@type='submit']"),
            locatorPositiveNotification = By.XPath("//*[@id='flash_notice']"),
            locatorNegativeNotification = By.XPath("//*[@id='errorExplanation']");

        IWebElement textboxProjectName, textboxProjectDescription, textboxProjectIdentifier, textboxHomepage,
            checkboxPublic, comboboxSubOf, checkboxInheritMembers, buttonCreate;
        IWebElement notificationAboutCreation;

		public NewProjectPage()
		{

		}
		public NewProjectPage(IWebDriver driver):base(driver){}

        public NewProjectPage SetName(string projectName)
        {
            textboxProjectName = (BaseElement)SearchElementUtil.GetElement(driver, locatorTextboxProjectName);
            textboxProjectName.SendKeys(projectName);
            return this;
        }
        public NewProjectPage SetDescription(string projectDescription)
        {
            textboxProjectDescription = (BaseElement)SearchElementUtil.GetElement(driver, locatorTextboxProjectDescription);
            textboxProjectDescription.SendKeys(projectDescription);
            return this;
        }
        public NewProjectPage SetIdentifier(string projectIdentifier)
        {
            textboxProjectIdentifier = SearchElementUtil.GetElement(driver, locatorTextboxProjectIdentifier);
            textboxProjectIdentifier.Clear();
            textboxProjectIdentifier.SendKeys(projectIdentifier);
            return this;
        }

        public NewProjectPage SetHomepage(string homepage)
        {
            textboxHomepage = SearchElementUtil.GetElement(driver, locatorTextboxHomepage);
            textboxHomepage.SendKeys(homepage);
            return this;
        }

        public NewProjectPage SelectPublic(bool tickParam = true)
        {
            checkboxPublic = SearchElementUtil.GetElement(driver, locatorCheckboxPublic);
            if (tickParam)
                ((BaseElement)checkboxPublic).Check();
            else
                ((BaseElement)checkboxPublic).Uncheck();
            return this;
        }

        public NewProjectPage SelectInheritMembers(bool tickParam = true)
        {
            checkboxInheritMembers = SearchElementUtil.GetElement(driver, locatorCheckboxInheritMembers);
            if (tickParam)
                ((BaseElement)checkboxInheritMembers).Check();
            else
                ((BaseElement)checkboxInheritMembers).Uncheck();
            return this;
        }

        public NewProjectPage ClickCreate()
        {
            buttonCreate = (BaseElement)SearchElementUtil.GetElement(driver, locatorButtonCreate);
            buttonCreate.Click();
            return this;
        }

        public string GetNotificationAboutCreationText()
        {
            if (!IsSuccessfulCreation())
                notificationAboutCreation = (BaseElement)SearchElementUtil.GetElement(driver, locatorNegativeNotification);
            return notificationAboutCreation.Text;
        }

       
        public bool IsSuccessfulCreation()
        {
            notificationAboutCreation = (BaseElement)SearchElementUtil.GetElement(driver, locatorPositiveNotification);
            return notificationAboutCreation!=null && notificationAboutCreation.Displayed;
        }

	    //where should use??
		public Notifications GetCreationResult()
	    {
		    if (IsSuccessfulCreation())
			    return Notifications.Positive;
		    notificationAboutCreation = (BaseElement)SearchElementUtil.GetElement(driver, locatorNegativeNotification);
		    return Notifications.Negative;
	    }

	}
}