using TAFProject.Models;
using TAFProject.UIUtils.Driver;
using TAFProject.UIUtils.PageObjects;
using TAFProject.Utils;

namespace TAFProject.Steps
{
	public static class ProjectSteps
	{
		public static void AddProject(IBrowser browser, Project project)
		{
			var newProject = RedmineNavigation.GoTo<NewProjectPage>(browser, Pages.NewProject);
			newProject.driver = browser.Driver;
			newProject.SetName(project.Name);
			newProject.SetIdentifier(project.Identifier);
			newProject.ClickCreate();
		}

		public static bool IsProjectCreated(IBrowser browser)
		{
			NewProjectPage page = new NewProjectPage(browser.Driver);
			return page.IsSuccessfulCreation();
		}

		public static bool IsProjectCreated(IBrowser browser, out string notificationText)
		{
			NewProjectPage page = new NewProjectPage(browser.Driver);
			notificationText = page.GetNotificationAboutCreationText();
			return page.IsSuccessfulCreation();
		}
	}
}
