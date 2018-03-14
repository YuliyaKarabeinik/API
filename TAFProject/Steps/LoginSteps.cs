using TAFProject.Models;
using TAFProject.UIUtils.Driver;
using TAFProject.UIUtils.PageObjects;

namespace TAFProject.Steps
{
    public static class LoginSteps//убрать static
    {
        public static void Login(IBrowser browser, User user)
        {
            LoginPage loginPage = new LoginPage(browser.Driver);
            loginPage.SetUser(user.UserName);
            loginPage.SetPassword(user.Password);
            loginPage.ClickSubmit();
            //RedmineNavigation.GoTo<HomePage>(browser, Pages.Home);
        }

        public static bool IsLogIn(IBrowser browser, User user = null)
        {
            HomePage homepage = new HomePage(browser.Driver);
            return user == null ? homepage.IsLogIn() : homepage.GetCurrentUser() == user.UserName;
        }

        public static void LogOut(IBrowser browser)
        {
            HomePage homepage = new HomePage(browser.Driver);
            homepage.LogoutHomePage();
        }

    }
}
