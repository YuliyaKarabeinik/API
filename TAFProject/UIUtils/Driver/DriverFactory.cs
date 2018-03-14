using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using TAFProject.Models;

namespace TAFProject.UIUtils.Driver
{
    static class DriverFactory
    {
        public static IWebDriver GetDriver(BrowserType type, int timeOutSec) //вместо timeOut - options - не работает DriverOpions
        {
            switch (type)
            {
                case BrowserType.Chrome:
                    {
                        var service = ChromeDriverService.CreateDefaultService();
                        ChromeOptions options = new ChromeOptions();
                        options.AddArgument("disable-infobars");//hiding warning window
                        return new ChromeDriver(service, options, TimeSpan.FromSeconds(timeOutSec));
                    }

                case BrowserType.Firefox:
                    {
                        var service = FirefoxDriverService.CreateDefaultService();
                        var options = new FirefoxOptions();
                        options.AddArgument("disable-infobars");//hiding warning window
                        return new FirefoxDriver(service, options, TimeSpan.FromSeconds(timeOutSec));
                    }
                default:
                    goto case BrowserType.Chrome;
            }
        }
    }
}