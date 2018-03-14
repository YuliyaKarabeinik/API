using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace TAFProject.UIUtils.Driver
{
    class SearchElementUtil
    {
        public static IWebElement GetElement(IWebDriver driver, By locator)
        {
            try
            {
				IWebElement element = new BaseElement(driver, locator);
                return element;
            }
            catch (NoSuchElementException)
            {
                return null;//ошибка запрячется глубже(
            }
        }

        public static IWebElement GetElement(IWebDriver driver, string xPathLocator)
        {
			return GetElement(driver, By.XPath(xPathLocator));
		}

		public static IWebElement WaitElement(IWebDriver driver, By locator, int timeoutsec)
		{
			new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutsec)).Until(driv => driv.FindElement(locator));
			return driver.FindElement(locator);
		}

			//isElementDisplayed
		}
	}
