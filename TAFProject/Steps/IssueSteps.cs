using TAFProject.Models;
using TAFProject.UIUtils.Driver;
using TAFProject.UIUtils.PageObjects;
using TAFProject.Utils;

namespace TAFProject.Steps
{
	public static class IssueSteps
	{
		public static void AddIssue(IBrowser browser, string projectIdentifier, Issue issue)
		{
			var newIssue = RedmineNavigation.GoTo<NewIssuePage>(browser, Pages.TemplateNewIssue, projectIdentifier);
			newIssue.driver = browser.Driver;////Navigation problems
			newIssue.SelectType(issue.Type);
			newIssue.SetSubject(issue.Subject);
			//newIssue.SetDescription(issue.Description);
			newIssue.SelectStatus(issue.Status);
			newIssue.SelectPriority(issue.Priority);
			newIssue.ClickCreate();
		}

		public static bool IsIssueCreated(IBrowser browser, string projectIdentifier, string issueName)
		{
			var activity = RedmineNavigation.GoTo<ActivityPage>(browser, Pages.TemplateActivity, projectIdentifier);
			activity.driver = browser.Driver;//Navigation problems
			return activity.IsIssueCreated(browser.Driver, issueName); //name or number of issue?
		}
	}
}
