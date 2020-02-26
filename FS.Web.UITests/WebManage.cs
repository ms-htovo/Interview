using System;
using System.Configuration;
using Intercop.Views.Common;
using Intercop.Web.UITests.Views.Common;

namespace Intercop.Web.UITests
{
    public class WebManage
    {
        public IBrowser Start()
        {
            try
            {
                return BrowserFactory.Get(GetBrowserType());
            }
            catch (Exception ex)
            {
                throw new Exception($"Driver Coud not be launched. {ex}");
            }
        }

        private BrowserType GetBrowserType()
        {
            var browser = Environment.GetEnvironmentVariable("BROWSER");

            try
            {
                if (string.IsNullOrEmpty(browser))
                {
                    browser = ConfigurationManager.AppSettings["browser"];
                }
                return (BrowserType)Enum.Parse(typeof(BrowserType), browser);
            }
            catch (Exception Ex)
            {
                throw new Exception($"Browser can't be gotten. {Ex}");
            }
        }

        public IBrowser GetCurrentDriver()
        {
            try
            {
                return BrowserFactory.Get(GetBrowserType());
            }
            catch (Exception ex)
            {
                throw new Exception($"Browser is not avialbl. {ex}");
            }
        }

    }
}