using Intercop.Views.Common;
using Protractor;

namespace Intercop.Web.UITests.Views.Common
{
    public interface IBrowser
    {
        BrowserType BrowserType { get; }        
        NgWebDriver WebDriver { get; }
        void Kill();
    }
}
