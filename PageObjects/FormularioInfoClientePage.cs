using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace YapePrueba2.PageObjects
{
    internal class FormularioInfoClientePage(AndroidDriver<AppiumWebElement> driver) : BasePage(driver)
    {

        [FindsBy(How = How.XPath, Using = "//android.widget.TextView[@text=\"Fill in your info\"]")]
        private readonly IWebElement titulo;
        [FindsBy(How = How.XPath, Using = "//android.widget.TextView[@text=\"First Name *\"]//following-sibling::android.widget.EditText")]
        private readonly IWebElement firstName;
        [FindsBy(How = How.XPath, Using = "//android.widget.TextView[@text=\"Last Name *\"]//following-sibling::android.widget.EditText")]
        private readonly IWebElement lastName;
        [FindsBy(How = How.XPath, Using = "//android.widget.TextView[@text=\"Email Address *\"]//following-sibling::android.widget.AutoCompleteTextView")]
        private readonly IWebElement emailAddress;
        [FindsBy(How = How.XPath, Using = "//android.widget.TextView[@text=\"Country/Region *\"]//following-sibling::android.widget.EditText")]
        private readonly IWebElement countryRegion;
        [FindsBy(How = How.XPath, Using = "//android.widget.TextView[@text=\"Mobile Phone *\"]//following-sibling::android.widget.EditText")]
        private readonly IWebElement mobilePhone;
        [FindsBy(How = How.Id, Using = "com.booking:id/business_purpose_question")]
        private readonly IWebElement purposeQuestion;
        [FindsBy(How = How.Id, Using = "com.booking:id/business_purpose_business")]
        private readonly IWebElement businessRadio;
        [FindsBy(How = How.Id, Using = "com.booking:id/business_purpose_leisure")]
        private readonly IWebElement leisureRadio;
        [FindsBy(How = How.Id, Using = "com.booking:id/action_button")]
        private readonly IWebElement botonNextStep;
        [FindsBy(How = How.Id, Using = "com.booking:id/bui_input_container_helper_label")]
        private readonly IWebElement alertaCompletarNombre;

        internal string GetTitulo() => titulo.Text;
        internal void IngresarFirstName(string t) => Llenar(firstName, t);
        internal void IngresarLastName(string t) => Llenar(lastName, t);
        internal void IngresarEmailAddress(string t) => Llenar(emailAddress, t);
        internal void IngresarCountryRegion(string t) => Llenar(countryRegion, t);
        internal void IngresarMobilePhone(string t) => Llenar(mobilePhone, t);
        internal string GetPurposeQuestion() => purposeQuestion.Text;
        internal void ClickBusinessRadio() => Click(businessRadio);
        internal void ClickLeisureRadio() => Click(leisureRadio);
        internal void ClickNextStep() => Click(botonNextStep);
        internal string GetAlertaIngreseNombre() => alertaCompletarNombre.Text;
    }
}
