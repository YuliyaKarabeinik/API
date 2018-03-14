using NUnit.Framework;
using TAFProject.Models;
using TAFProject.Steps;
using TAFProject.Utils;

namespace Tests
{
    [TestFixture, Parallelizable(ParallelScope.All)]
    class AddProjectTest : BaseTest
    {
        private Project project = new Project
        {
            Name = "Name".GetRandomString(5),
            Identifier = "ident".GetRandomString(5)
        };
		static string incorrectIdentifier = "";

        [Test]
		public void AddProjectPositiveTest()
        {
	     	logger.Info($"Test AddProject started with parameters:\n project name: {project.Name}, identifier {project.Identifier}");
			ProjectSteps.AddProject(browser, project);
	    	Assert.IsTrue(ProjectSteps.IsProjectCreated(browser));
		}

		[Test]
		public void AddProjectNegativeTest()
		{
		    project.Identifier = incorrectIdentifier;
	        logger.Info($"Test AddProject started with parameters:\n project name: {project.Name}, identifier {project.Identifier}");
	        ProjectSteps.AddProject(browser, project);
            Assert.IsFalse(ProjectSteps.IsProjectCreated(browser));
        }
	}
}
