using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Globalization;

namespace YapePrueba2.PageObjects
{
    public class SearchPage(AndroidDriver<AppiumWebElement> driver) : BasePage(driver)
    {
        [FindsBy(How = How.Id, Using = "com.booking:id/facet_search_box_accommodation_destination")]
        private readonly IWebElement destino;
        [FindsBy(How = How.Id, Using = "com.booking:id/facet_with_bui_free_search_booking_header_toolbar_content")]
        private readonly IWebElement buscadorDestino;
        [FindsBy(How = How.XPath, Using = "//androidx.recyclerview.widget.RecyclerView[@resource-id='com.booking:id/facet_disambiguation_content']/android.view.ViewGroup[1]")]
        private readonly IWebElement primerResultadoDeBusqueda;

        [FindsBy(How = How.Id, Using = "com.booking:id/facet_search_box_accommodation_dates")]
        private readonly IWebElement fechas;
        [FindsBy(How = How.Id, Using = "com.booking:id/facet_date_picker_confirm")]
        private readonly IWebElement botonSelectDates;

        [FindsBy(How = How.Id, Using = "com.booking:id/facet_search_box_accommodation_occupancy")]
        private readonly IWebElement selectHabitacion;
        [FindsBy(How = How.XPath, Using = "//android.view.ViewGroup[@resource-id=\"com.booking:id/group_config_rooms_count\"]//android.widget.TextView[@resource-id=\"com.booking:id/bui_input_stepper_value\"]")]
        private readonly IWebElement cantidadRooms;
        [FindsBy(How = How.XPath, Using = "//android.view.ViewGroup[@resource-id=\"com.booking:id/group_config_rooms_count\"]//android.widget.Button[@resource-id=\"com.booking:id/bui_input_stepper_add_button\"]")]
        private readonly IWebElement aumentarRooms;
        [FindsBy(How = How.XPath, Using = "//android.view.ViewGroup[@resource-id=\"com.booking:id/group_config_rooms_count\"]//android.widget.Button[@resource-id=\"com.booking:id/bui_input_stepper_remove_button\"]")]
        private readonly IWebElement disminuirRooms;
        [FindsBy(How = How.XPath, Using = "//android.view.ViewGroup[@resource-id=\"com.booking:id/group_config_adults_count\"]//android.widget.TextView[@resource-id=\"com.booking:id/bui_input_stepper_value\"]")]
        private readonly IWebElement cantidadAdultos;
        [FindsBy(How = How.XPath, Using = "//android.view.ViewGroup[@resource-id=\"com.booking:id/group_config_adults_count\"]//android.widget.Button[@resource-id=\"com.booking:id/bui_input_stepper_add_button\"]")]
        private readonly IWebElement aumentarAdultos;
        [FindsBy(How = How.XPath, Using = "//android.view.ViewGroup[@resource-id=\"com.booking:id/group_config_adults_count\"]//android.widget.Button[@resource-id=\"com.booking:id/bui_input_stepper_remove_button\"]")]
        private readonly IWebElement disminuirAdultos;
        [FindsBy(How = How.XPath, Using = "//android.view.ViewGroup[@resource-id=\"com.booking:id/group_config_children_count\"]//android.widget.TextView[@resource-id=\"com.booking:id/bui_input_stepper_value\"]")]
        private readonly IWebElement cantidadNinos;
        [FindsBy(How = How.XPath, Using = "//android.view.ViewGroup[@resource-id=\"com.booking:id/group_config_children_count\"]//android.widget.Button[@resource-id=\"com.booking:id/bui_input_stepper_add_button\"]")]
        private readonly IWebElement aumentarNinos;
        [FindsBy(How = How.XPath, Using = "//android.view.ViewGroup[@resource-id=\"com.booking:id/group_config_children_count\"]//android.widget.Button[@resource-id=\"com.booking:id/bui_input_stepper_remove_button\"]")]
        private readonly IWebElement disminuirNinos;
        [FindsBy(How = How.XPath, Using = "//android.widget.EditText[@resource-id=\"android:id/numberpicker_input\"]")]
        private readonly IWebElement edadSeleccionadaDeNino;
        [FindsBy(How = How.XPath, Using = "//android.widget.FrameLayout[@resource-id=\"com.booking:id/age_picker_view\"]/android.widget.NumberPicker//android.widget.Button[2]")]
        private readonly IWebElement botonAumentarEdad;
        [FindsBy(How = How.Id, Using = "com.booking:id/group_config_apply_button")]
        private readonly IWebElement botonAPPLY;
        [FindsBy(How = How.Id, Using = "android:id/button1")]
        private readonly IWebElement OKEdadNino; 

        [FindsBy(How = How.Id, Using = "com.booking:id/facet_search_box_cta")]
        private readonly IWebElement botonSearch;

        [FindsBy(How = How.Id, Using = "com.booking:id/message")]
        private readonly IWebElement alertaDestino;

        public void ClickDestino() => Click(destino);

        public void ClickFechas() => Click(fechas);

        public void ClickInquilinos() => Click(selectHabitacion);

        public void ClickSearch() => Click(botonSearch);
        public void IngresarDestino(string d) => Llenar(buscadorDestino, d);
        public void ClickPrimerResultado() => Click(primerResultadoDeBusqueda);

        internal void SeleccionarFechaInicio(string fecha)
        {
            DateTime f= DateTime.ParseExact(fecha, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            string fechaIngles = f.ToString("dd MMMM yyyy", CultureInfo.InvariantCulture);
            while (!Visualiza("android.view.View", "content-desc", fechaIngles))
            {
                HacerScroll(200);
            }
            Click("android.view.View", "content-desc", fechaIngles);
        }

        internal void SeleccionarFechaFin(string fecha)
        {
            SeleccionarFechaInicio(fecha);
        }

        internal void ClickSelectDates()
        {
            Click(botonSelectDates);
        }

        internal void ClickHabitaciones()
        {
            Click(selectHabitacion);
        }

        internal void SeleccionarHabitaciones(int cantidadEsperada)
        {
            int cantidadActual = Int32.Parse(cantidadRooms.Text);
            //Console.WriteLine(">>>>>>>>>>>>>>>>>>>>"+cantidadRooms.Text);
            while (cantidadActual != cantidadEsperada)
            {
                if (cantidadActual < cantidadEsperada)
                {
                    Click(aumentarRooms);
                    cantidadActual++;
                }
                else
                {
                    Click(disminuirRooms);
                    cantidadActual--;
                }
            }
        }

        internal void SeleccionarAdultos(int cantidadEsperada)
        {
            int cantidadActual = Int32.Parse(cantidadAdultos.Text);
            while (cantidadActual != cantidadEsperada)
            {
                if (cantidadActual < cantidadEsperada)
                {
                    Click(aumentarAdultos);
                    cantidadActual++;
                }
                else
                {
                    Click(aumentarAdultos);
                    cantidadActual--;
                }
            }
        }

        internal void SeleccionarNinos(int cantidadEsperada)
        {
            int cantidadActual = Int32.Parse(cantidadNinos.Text);
            while (cantidadActual != cantidadEsperada)
            {
                if (cantidadActual < cantidadEsperada)
                {
                    Click(aumentarNinos);
                    cantidadActual++;
                }
                else
                {
                    Click(aumentarNinos);
                    cantidadActual--;
                }
            }
        }

        internal void ClickAPPLY() => Click(botonAPPLY);

        internal void SeleccionarEdadDeNino(int edad)
        {
            while (!edadSeleccionadaDeNino.Text.Contains(edad.ToString()))
            {
                Click(botonAumentarEdad);
            }
        }

        internal void ClickSeleccionarEdadDeNinoOK() => Click(OKEdadNino);

        internal string GetAlertaIngreseDestino() => alertaDestino.Text;
    }
}