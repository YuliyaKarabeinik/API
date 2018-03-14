using NUnit.Framework;
using NUnit.Framework.Internal;
using TAFProject.Models;
using TAFProject.Steps;
using TAFProject.UIUtils.Driver;
using TAFProject.Utils;
using ILogger = TAFProject.Utils.ILogger;
using Logger = TAFProject.Utils.Logger;

namespace Tests
{
    public class BaseTest
    {
		protected IBrowser browser;
        protected ILogger logger = new Logger();
        protected User user = new User();

        [OneTimeSetUp]
        public void InitOnce()
        {
            user.UserName = Configuration.User;
            user.Password = Configuration.Password;
            logger.InitLogger();
            logger.Info("Settings: " +
                                 $"\nCurrent browser: {Configuration.Browser}" +
                                 $"\nStart Url: {Configuration.StartUrl}" +
                                 $"\nTimeout: {Configuration.ElementTimeout}");            
        }

        [SetUp]
        public virtual void InitTest()
        {
            browser = BrowserFactory.GetBrowser(Configuration.Browser, Configuration.ElementTimeout);
            browser.GoToUrl(Configuration.StartUrl);
            LoginSteps.Login(browser, user);
        }

        [TearDown]
        public void CloseTest()
        {
            logger.Info($"Test finished with status: {TestExecutionContext.CurrentContext.CurrentResult.ResultState.Status}");
            browser.Close();
        }

        [OneTimeTearDown]
        public void CleanTest()
        {
            logger.Info("Exit from browser");
        }
    }
}
