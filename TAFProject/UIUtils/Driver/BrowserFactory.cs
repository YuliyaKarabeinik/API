using TAFProject.Models;

namespace TAFProject.UIUtils.Driver
{
	public class BrowserFactory
	{
		public static IBrowser GetBrowser(BrowserType type, int timeOutSec)
		{
			switch (type)
			{
				case BrowserType.Chrome:
					return new Chrome(timeOutSec);
				case BrowserType.Firefox:
					return new Firefox(timeOutSec);
				default:
					goto case BrowserType.Chrome;
			}
		}
	}
}
