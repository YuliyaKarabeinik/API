using NUnit.Framework;
using TAFProject.Models;
using TAFProject.Steps;
using TAFProject.Utils;

namespace Tests
{
    [TestFixture, Parallelizable(ParallelScope.All)]
    class AddIssueTest : BaseTest
    {
		static string projectIdentifier = "cs3m5cs3m";

        private Issue issue = new Issue
            {Subject = "subject".GetRandomString(5)};

		[Test]
		public void AddIssuePositiveTest()
		{
			IssueSteps.AddIssue(browser, projectIdentifier, issue);
			Assert.IsTrue(IssueSteps.IsIssueCreated(browser, projectIdentifier, issue.Subject));
		}
	}
}
