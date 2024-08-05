using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace YapePrueba2.PageObjects
{
    public class StartPage(AndroidDriver<AppiumWebElement> driver) : BasePage(driver)
    {
        [FindsBy(How = How.XPath, Using = "//android.widget.ImageButton[@content-desc=\"Navigate up\"]")]
        private readonly IWebElement botonCerrar;

        public void ClickBotonCerrar() => Click(botonCerrar);
    }
}