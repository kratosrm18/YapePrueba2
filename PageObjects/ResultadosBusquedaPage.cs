using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace YapePrueba2.PageObjects
{
    public class ResultadosBusquedaPage(AndroidDriver<AppiumWebElement> driver) : BasePage(driver)
    {
        [FindsBy(How = How.XPath, Using = "//android.widget.FrameLayout[@resource-id=\"com.booking:id/results_list_facet\"]/androidx.recyclerview.widget.RecyclerView/android.view.ViewGroup/android.view.ViewGroup/android.view.ViewGroup/android.widget.ImageView")]
        private readonly IList<IWebElement> resultados;
        internal void ClickSegundoResultado()
        {
            Click(resultados[0]);
            //Click(resultados[1]);
        }
    }
}
