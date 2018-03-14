using System.Collections.Generic;
using TAFProject.UIUtils.Driver;
using TAFProject.UIUtils.PageObjects;

namespace TAFProject.Utils
{
    public enum Pages
    {
        Login, Home, Projects, NewProject, TemplateCurrentProject, TemplateNewIssue, TemplateCreatedIssue, TemplateActivity, TemplateIssues
    }
    static class RedmineNavigation
    {
        public static string CurrentUrl { get; private set; }
        private static int IssueNumber { get; }

        static readonly Dictionary<Pages, string> urls = new Dictionary<Pages, string>()
        {
            { Pages.Login, "http://icerow.com/"},
            { Pages.Home, "http://icerow.com/"},
            { Pages.Projects, "http://icerow.com/projects/"},
            { Pages.NewProject, "http://icerow.com/projects/new"},
            { Pages.TemplateCurrentProject, "http://icerow.com/projects/{0}"},
            { Pages.TemplateNewIssue, "http://icerow.com/projects/{0}/issues/new"},
            { Pages.TemplateCreatedIssue, "http://icerow.com/issues/{0}"},//{0} - номер ишью
            { Pages.TemplateActivity, "http://icerow.com/projects/{0}/activity"},
            { Pages.TemplateIssues, "http://icerow.com/projects/{0}/issues"}
        };

        public static TPage GoTo<TPage>(IBrowser browser, Pages page, string projectIdentifier = "") where TPage : BasePage, new()
		{ 
            var nextUrl = projectIdentifier == string.Empty ? urls[page] : string.Format(urls[page], projectIdentifier);
            browser.GoToUrl(nextUrl);
            CurrentUrl = nextUrl;
			return new TPage();
        }

        public static bool IsOnPage(Pages page) => CurrentUrl == urls[page];

    }
}
