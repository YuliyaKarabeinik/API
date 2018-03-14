using System.Collections.ObjectModel;
using System.Drawing;
using OpenQA.Selenium;

namespace TAFProject.UIUtils.Driver
{
    class BaseElement : IWebElement
    {
		readonly IWebDriver driver;
	    readonly By locator;
        IWebElement element;
		readonly int timeoutsec = 10;

        public string Text => element.Text;

        public string TagName => element.TagName;

        public bool Enabled => element.Enabled;

        public bool Selected => element.Selected;

        public Point Location => element.Location;

        public Size Size => element.Size;

        public bool Displayed => element.Displayed;

        public BaseElement(IWebDriver driver, By locator)
        {
            this.locator = locator;
			this.driver = driver;
            element = driver.FindElement(locator);
        }

        public BaseElement(IWebDriver driver, string xpathLocator):
			this(driver, By.XPath(xpathLocator)){ }

        public BaseElement(IWebElement element)
        {
            this.element = element;
        }

        public void SendKeys(string text)
        {
			SearchElementUtil.WaitElement(driver, locator, timeoutsec);
            if (text!=string.Empty)
                element.SendKeys(text);
        }

        public void Click()
        {
			SearchElementUtil.WaitElement(driver, locator, timeoutsec);
			element.Click();
        }

        public bool IsExist()
        {
            return element != null;
        }

        public void Clear() => element.Clear();

        public void Submit() => element.Submit();

        public string GetAttribute(string attributeName) => element.GetAttribute(attributeName);

        public string GetProperty(string propertyName) => element.GetProperty(propertyName);

        public string GetCssValue(string propertyName) => element.GetCssValue(propertyName);

        public IWebElement FindElement(By by) => new BaseElement(element.FindElement(by));

        public ReadOnlyCollection<IWebElement> FindElements(By by) => element.FindElements(by);

        public void Check() 
        {
            if (!element.Selected)
                element.Click();
        }
        public void Uncheck()
        {
            if (element.Selected)
                element.Click();
        }
    }
}
