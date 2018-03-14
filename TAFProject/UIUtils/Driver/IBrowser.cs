using OpenQA.Selenium;

namespace TAFProject.UIUtils.Driver
{
	public interface IBrowser
	{
		IWebDriver Driver { get; }
		void GoToUrl(string url);
		void WindowMaximise();
		void Quit();
		void Close();
	}
}
