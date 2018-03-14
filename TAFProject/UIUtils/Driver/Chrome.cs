using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace TAFProject.UIUtils.Driver
{
	public class Chrome : IBrowser
	{
		public IWebDriver Driver { get; set; }
		public Chrome(int timeout) //передача DriverOptions не работает
		{
			var service = ChromeDriverService.CreateDefaultService();
			ChromeOptions options = new ChromeOptions();
			options.AddArgument("disable-infobars");//hiding warning window
			Driver = new ChromeDriver(service, options, TimeSpan.FromSeconds(timeout));
			WindowMaximise();
		}

		public int ImpWait { get; }
		
		public void WindowMaximise()
		{
			Driver.Manage().Window.Maximize();
		}

		public void GoToUrl(string url)
		{
			Driver.Navigate().GoToUrl(url);
		}

		public IWebElement FindElement(By locator)
		{
			return Driver.FindElement(locator);
		}

		public void Close()
		{
			Driver.Close();
		}

		public void Quit()
		{
			Driver.Quit();
			Driver = null;
		}
	}
}
