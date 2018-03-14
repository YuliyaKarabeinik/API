using System;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using TAFProject.Models;

namespace TAFProject.UIUtils.PageObjects
{
    public enum Columns
    {
        Number, Tracker, Status, Priority, Subject, Asignee, Updated
    }

    class IssueTable
    {
        IWebElement tableElement;
		IWebElement columnSortBy;

		static readonly string templateIssueFromTableLocator = "//tbody//tr[@id='issue-{0}']";
        
        public Issue this[int issueNumber]
        {
            get
            {
                IWebElement tableRow = tableElement.FindElement(By.XPath(string.Format(templateIssueFromTableLocator, issueNumber)));
                return new Issue
                {
                    //Number = int.Parse(tableRow.FindElement(By.XPath("//td[@class='id']")).Text),
                    Type = (IssueType) Enum.Parse(typeof(IssueType),
                        tableRow.FindElement(By.XPath("//td[@class='tracker']")).Text),
                    Status = (IssueStatus) Enum.Parse(typeof(IssueStatus),
                        tableRow.FindElement(By.XPath("//td[@class='status']")).Text),
                    Priority = (IssuePriority) Enum.Parse(typeof(IssuePriority),
                        tableRow.FindElement(By.XPath("//td[@class='priority']")).Text),
                    Subject = tableRow.FindElement(By.XPath("//td[@class='subject']")).Text
                };
            }
        }

        public IssueTable(IWebElement tableElement)
        {
            this.tableElement = tableElement;
        }

        public IssueTable SortBy(Columns column)
        {
            columnSortBy = column == Columns.Number ? FindColumn("#") : FindColumn(column.ToString());
            columnSortBy.Click();
            return new IssueTable(tableElement);
        }

        public List<string> GetListOf(Columns column)
        {
            List<string> list = new List<string>();
            list.AddRange((ICollection<string>) tableElement
                .FindElements(By.XPath($"//tbody//td[@class='{column.ToString().ToLower()}']"))
                .Select(element => element.Text));
            return list;
        }

        private IWebElement FindColumn(string columnName)
        {
            return tableElement.FindElement(By.XPath($"//th[@title='Sort by \"{columnName}\"']"));
        }        
    }
}
