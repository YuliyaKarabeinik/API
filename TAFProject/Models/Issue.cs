using System;

namespace TAFProject.Models
{
    public enum IssueType
    {
        Default, Task, ChangeRequest
    }
    public enum IssueStatus
    {
        Default, New, NeedInfo, Assigned, Closed
    }
    public enum IssuePriority
    {
        Default, Lowest, Low, Medium, High, Highest
    }
    public class Issue
    {
        //public int Number { get; set; }
        public IssueType Type { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public IssueStatus Status { get; set; }
        public IssuePriority Priority { get; set; }
        public string Asignee { get; set; }
        public DateTime Updated { get; set; }
    }
}
