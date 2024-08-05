using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Globalization;

namespace YapePrueba2.PageObjects
{
    internal class BookingOverviewPage(AndroidDriver<AppiumWebElement> driver) : BasePage(driver)
    {
        [FindsBy(How = How.Id, Using = "com.booking:id/bp_overview_hotelname")]
        private readonly IWebElement nombreHotel;
        [FindsBy(How = How.Id, Using = "com.booking:id/bp_overview_hotel_address")]
        private readonly IWebElement direccionHotel;
        [FindsBy(How = How.Id, Using = "com.booking:id/checkin_date")]
        private readonly IWebElement fechaInicio;
        [FindsBy(How = How.Id, Using = "com.booking:id/checkout_date")]
        private readonly IWebElement fechaFin;
        [FindsBy(How = How.XPath, Using = "//*[@text=\"You selected\"]//following-sibling::*[@resource-id=\"com.booking:id/subtitle\"]")]
        private readonly IWebElement infoEstadia;
        [FindsBy(How = How.Id, Using = "com.booking:id/action_button")]
        private readonly IWebElement botonFinalStep;


        [FindsBy(How = How.Id, Using = "com.booking:id/new_credit_card_number_edit")]
        private readonly IWebElement cardNumber;
        [FindsBy(How = How.Id, Using = "com.booking:id/new_credit_card_holder_edit")]
        private readonly IWebElement nombre;
        [FindsBy(How = How.Id, Using = "com.booking:id/new_credit_card_expiry_date_edit")]
        private readonly IWebElement expirationDate;
        [FindsBy(How = How.XPath, Using = "com.booking:id/facet_search_box_accommodation_destination")]
        private readonly IWebElement cardWillNotCharged;
        [FindsBy(How = How.XPath, Using = "com.booking:id/code_redemption_add_button_new")]
        private readonly IWebElement addPromo;
        [FindsBy(How = How.XPath, Using = "com.booking:id/subscription_setting_container")]
        private readonly IWebElement saveMoney;
        [FindsBy(How = How.Id, Using = "com.booking:id/action_button")]
        private readonly IWebElement botonBookNow;
        [FindsBy(How = How.Id, Using = "com.booking:id/bp_price_summary_taxes_and_charges")]
        private readonly IWebElement taxes;
        [FindsBy(How = How.Id, Using = "com.booking:id/bp_price_summary_total_price_value")]
        private readonly IWebElement price;
        [FindsBy(How = How.XPath, Using = "//*[@resource-id='com.booking:id/informative_cta_view_price_container']//*[@resource-id='com.booking:id/subtitle']")]
        private readonly IWebElement resumenTaxes;
        [FindsBy(How = How.XPath, Using = "//*[@resource-id='com.booking:id/informative_cta_view_price_container']//*[@resource-id='com.booking:id/title']")]
        private readonly IWebElement resumenPrice;





        internal string GetNombreHotel() => nombreHotel.Text;
        internal string GetDireccionHotel() =>direccionHotel.Text;
        internal string GetFechaInicio() => fechaInicio.Text;
        internal string GetFechaFin() => fechaFin.Text;
        internal string GetInfoEstadia() => infoEstadia.Text;


        internal bool? SeMuestraNombre() => SeMuestra(nombre);
        internal string GetNombre() => nombre.Text;
        internal bool? SeMuestraBotonBookNow() => SeMuestra(botonBookNow);
        internal bool? SeMuestraCardNumber() => SeMuestra(cardNumber);
        internal bool? SeMuestraExpirationDate() => SeMuestra(expirationDate);
        internal bool? SeMuestraLinkAddPromoCode() => SeMuestra(addPromo);
        internal bool? SeMuestraMensajeCardWontBeCharged() => SeMuestra(cardWillNotCharged);
        internal bool? SeMuestraMensajeSaveMoney() => SeMuestra(saveMoney);
        internal void ClickFinalStep() => Click(botonFinalStep);

        internal string GetPrecioTotal() => price.Text;
        internal string GetImpuestos() => taxes.Text;
        internal string GetPrecioResumen() => resumenPrice.Text;
        internal string GetTaxesResumen() => resumenTaxes.Text;
    }
}
