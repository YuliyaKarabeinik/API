using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;

namespace TAFProject.UIUtils.Driver
{
	public class Firefox : IBrowser
	{
		public IWebDriver Driver { get; set; }
		public Firefox(int timeout) //передача DriverOptions не работает
		{
			var service = FirefoxDriverService.CreateDefaultService();
			FirefoxOptions options = new FirefoxOptions();
			options.AddArgument("disable-infobars");//hiding warning window
			Driver = new FirefoxDriver(service, options, TimeSpan.FromSeconds(timeout));
			WindowMaximise();
		}
		public void GoToUrl(string url)
		{
			Driver.Navigate().GoToUrl(url);
		}
		public void WindowMaximise()
		{
			Driver.Manage().Window.Maximize();
		}
		public void Quit()
		{
			Driver.Quit();
			Driver = null;
		}
		public void Close()
		{
			Driver.Close();
		}
	}
}
