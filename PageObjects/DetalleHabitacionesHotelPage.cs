using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace YapePrueba2.PageObjects
{
    internal class DetalleHabitacionesHotelPage(AndroidDriver<AppiumWebElement> driver) : BasePage(driver)
    {
        [FindsBy(How = How.XPath, Using = "//*[@resource-id=\"com.booking:id/list_item\"]")]
        private readonly IList<IWebElement> resultados;
        [FindsBy(How = How.XPath, Using = "//android.widget.Button[@resource-id=\"com.booking:id/main_action\"]")]
        private readonly IWebElement botonReserve;

        internal void ClickPrimeraOpcion()
        {
            Console.WriteLine(resultados);
            Click(resultados[0]);
        }

        internal void ClickReserve()
        {
            Click(botonReserve);
        }
    }
}
