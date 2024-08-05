using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Interactions;

namespace YapePrueba2.PageObjects
{
    public class AndroidPage(AndroidDriver<AppiumWebElement> driver) : BasePage(driver)
    {

        //Elmentos explorador de imagenes
        [FindsBy(How = How.XPath, Using = "//android.widget.ImageView[@content-desc=\"Más opciones\"]")]
        private IWebElement BotonAntesExplorar;
        [FindsBy(How = How.Id, Using = "com.google.android.providers.media.module:id/title")]
        private IWebElement BotonExplorar;
        [FindsBy(How = How.XPath, Using = "//android.widget.ImageButton[@content-desc='Mostrar raíces']")]
        private IWebElement botonMostrarRaiz;
        [FindsBy(How = How.XPath, Using = "/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.view.ViewGroup/androidx.drawerlayout.widget.DrawerLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.ListView/android.widget.LinearLayout[2]")]
        private IWebElement botonImagenes;
        [FindsBy(How = How.XPath, Using = "//*[@resource-id='com.google.android.documentsui:id/dir_list']//android.widget.TextView[@text='ParkingQR']")]
        private IWebElement botonCarpetaParkingQR;
        [FindsBy(How = How.XPath, Using = "//*[@resource-id='com.google.android.documentsui:id/dir_list']//android.widget.TextView[@text='JapiBici']")]
        private IWebElement botonCarpetaJapiBici;
        [FindsBy(How = How.XPath, Using = "//android.widget.LinearLayout[contains(@content-desc,'Bici1.jpg')]")]
        private IWebElement imagenBici1;
        [FindsBy(How = How.XPath, Using = "//android.widget.LinearLayout[contains(@content-desc,'Bici2.png')]")]
        private IWebElement imagenBici2;
        [FindsBy(How = How.XPath, Using = "//android.widget.LinearLayout[contains(@content-desc,'Bici1.jpg')]/android.widget.RelativeLayout/android.widget.FrameLayout[2]/android.widget.ImageView")]
        private IWebElement checkImagenBici1;
        [FindsBy(How = How.XPath, Using = "//android.widget.LinearLayout[contains(@content-desc,'Bici2.png')]/android.widget.RelativeLayout/android.widget.FrameLayout[2]/android.widget.ImageView")]
        private IWebElement checkImagenBici2;

        [FindsBy(How = How.Id, Using = "com.realplazago.app:id/menu_crop")]
        private IWebElement CheckEditarFoto;
        [FindsBy(How = How.Id, Using = "com.realplazago.app:id/ucrop_photobox")]
        private IWebElement InterfaceEditarFoto;

        public void UbicarCarpetaJapiBici()
        {
            Thread.Sleep(2000);
            if (!Environment.CurrentDirectory.Contains("Kratos") && !Environment.CurrentDirectory.Contains("EXPERIS-REAL PLAZA"))
            {
                Click(BotonAntesExplorar);
                Click(BotonExplorar);
            }
            Click(botonMostrarRaiz);
            Thread.Sleep(500);
            Click(botonImagenes);
            Click(botonCarpetaJapiBici);
        }

        public void ClickBici1() => Click(imagenBici1);
        public void ClickBici2() => Click(imagenBici2);
        public void SelectBici1() =>
            //Click(imagenBici1);
            action.Press(imagenBici1).Wait(1000).Release().Perform();
        public void SelectBici2() => action.Press(imagenBici2).Wait(1000).Release().Perform();
        public bool VisualizaCheckBici1() => SeMuestra(checkImagenBici1);
        public bool VisualizaCheckBici2() => SeMuestra(checkImagenBici2);

        internal void ClickCheckEditarFoto() => Click(CheckEditarFoto);

        internal void VisualizaEditor() => SeMuestra(CheckEditarFoto);

        internal bool VisualizaInterfaceEditarFoto() => SeMuestra(InterfaceEditarFoto);

        internal bool VisualizaCheckEditarFoto() => SeMuestra(CheckEditarFoto);
    }
}