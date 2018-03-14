using NUnit.Framework;
using TAFProject.Steps;
using TAFProject.UIUtils.Driver;
using TAFProject.Utils;

namespace Tests
{
    [TestFixture]
    class LoginTest : BaseTest
    {
    
        [SetUp]
        public override void InitTest()
        {
			browser = BrowserFactory.GetBrowser(Configuration.Browser, Configuration.ElementTimeout);
			browser.GoToUrl(Configuration.StartUrl);
			if (LoginSteps.IsLogIn(browser))
                LoginSteps.LogOut(browser);
	        logger.Info("Logout");
	        
		}
     
        [Test]
        public void CorrectLoginTest()
        {
	        logger.Info($"Test LogIn started with parameters:\n login: {user.UserName}, password {user.Password}");
			LoginSteps.Login(browser, user);
            Assert.True(LoginSteps.IsLogIn(browser, user));
		}
	}
}
