using System;
using System.Configuration;
using TAFProject.Models;

namespace TAFProject.Utils
{
    
    public static class Configuration
    {
        private const string KeyTimeout = "elementTimeout";
        private const string KeyBrowser = "browser";
        private const string KeyStartUrl = "startUrl";
	    private const string KeyUser = "user";
	    private const string KeyPassword = "password";

		private static readonly int defaultTimeout = 10;
        private static readonly BrowserType defaultBrowser = BrowserType.Chrome;
        private static readonly string defaultStartUrl = "http://icerow.com/";
	    private static readonly string defaultUser = "TAT18";
	    private static readonly string defaultPassword = "tat18pass";

		public static int ElementTimeout
        {
            get
            {
	            int timeout;
				int.TryParse(GetConfigSettings(KeyTimeout, defaultTimeout.ToString()), out timeout);
                if (IsCorrectTimeout(timeout))
                    return timeout;
                return defaultTimeout;
            }
        }

        public static BrowserType Browser
        {
            get
            {
				BrowserType browserTypeFromConfig;

				if (Enum.TryParse(GetConfigSettings(KeyBrowser, defaultBrowser.ToString()),
                    out browserTypeFromConfig))
                    return browserTypeFromConfig;
                return defaultBrowser;
            }
        }

        public static string StartUrl => GetConfigSettings(KeyStartUrl, defaultStartUrl);
	    public static string User => GetConfigSettings(KeyUser, defaultUser);
		public static string Password => GetConfigSettings(KeyPassword, defaultPassword);

		private static string GetConfigSettings(string key, string defaultValue)
        {
            return ConfigurationManager.AppSettings[key] ?? defaultValue;
        }

        private static bool IsCorrectTimeout(int timeOutSec) => timeOutSec > 0;
    }
}
