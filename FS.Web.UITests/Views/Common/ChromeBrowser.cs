using System;
using System.Collections.Specialized;
using System.Configuration;
using Intercop.Views.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Protractor;

namespace Intercop.Web.UITests.Views.Common
{
    public class ChromeBrowser : BaseBrowser, IBrowser
    {
        public ChromeBrowser()
        {
            var options = GetOptions();
            WebDriver = GetNgWebDriver(new ChromeDriver(ChromeDriverService.CreateDefaultService(), (ChromeOptions)options, TimeSpan.FromSeconds(90)));
            
                
        }

        public BrowserType BrowserType => BrowserType.CHROME;
        public NgWebDriver WebDriver { get; }

        public void Kill()
        {
            KillDriver("chromedriver");
        }

        private DriverOptions GetOptions()
        {
            var chromeOptions = new ChromeOptions
            {
                AcceptInsecureCertificates = true
            };

            chromeOptions.AddArgument("disable-infobars");
            chromeOptions.AddArgument("--disable-plugins");
            chromeOptions.AddArgument("lang=en-US");
            chromeOptions.AcceptInsecureCertificates = true;

            try
            {
                var caps = ConfigurationManager.GetSection("capabilities/" + "chrome") as NameValueCollection;
                foreach (string key in caps.AllKeys)
                {
                    chromeOptions.AddAdditionalCapability(key, caps[key], true);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to set Chrome Options {ex}");
            }

            return chromeOptions;
        }
    }
}
