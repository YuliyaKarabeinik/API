using TAFProject.Models;
using TAFProject.UIUtils.Driver;
using TAFProject.UIUtils.PageObjects;

namespace TAFProject.Steps
{
	public static class IssueTableSteps
	{
		public static void SortIssueTableBy(IBrowser browser)
		{
			IssuePage page = new IssuePage(browser.Driver);
			Issue issue = page.Table[1];
			//continue...
		}
	}
}
