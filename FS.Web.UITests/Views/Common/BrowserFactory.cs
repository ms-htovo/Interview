using Intercop.Web.UITests.Views.Common;

namespace Intercop.Views.Common
{
    public class BrowserFactory
    {
        public static IBrowser Get(BrowserType browser)
        {
            switch (browser)
            {

                case BrowserType.CHROME:
                default:
                    return new ChromeBrowser();
            }
        }


    }
}
