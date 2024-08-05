using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;

namespace YapePrueba2.PageObjects
{
    public class PageObjectManager(AndroidDriver<AppiumWebElement> driver)
    {
        public AndroidDriver<AppiumWebElement> Driver = driver;
        private SearchPage _searchPage;
        private BasePage _basePage;
        private AndroidPage _androidPage;
        private StartPage _startPage;
        private BookingOverviewPage _bookingOverviewPage;
        private FormularioInfoClientePage _formularioInfoCliente;
        private DetalleHabitacionesHotelPage _detalleHabitacionesHotelPage;
        private DetallesHotelPage _detallesHotelPage;
        private ResultadosBusquedaPage _resultadosBusquedaPage;




        public SearchPage GetSearchPage()
        {
            _searchPage = new SearchPage(Driver);
            return _searchPage;
        }

        public AndroidPage GetAndroidPage()
        {
            _androidPage = new AndroidPage(Driver);
            return _androidPage;
        }

        public StartPage GetStartPage()
        {
            _startPage = new StartPage(Driver);
            return _startPage;
        }

        internal BookingOverviewPage GetBookingOverviewPage()
        {
            _bookingOverviewPage = new BookingOverviewPage(Driver);
            return _bookingOverviewPage;
        }
        internal FormularioInfoClientePage GetFormularioInfoClientePage()
        {
            _formularioInfoCliente = new FormularioInfoClientePage(Driver);
            return _formularioInfoCliente;
        }
        internal DetalleHabitacionesHotelPage GetDetalleHabitacionesHotelPage()
        {
            _detalleHabitacionesHotelPage = new DetalleHabitacionesHotelPage(Driver);
            return _detalleHabitacionesHotelPage;
        }
        internal DetallesHotelPage GetDetallesHotelPage()
        {
            _detallesHotelPage = new DetallesHotelPage(Driver);
            return _detallesHotelPage;
        }

        internal ResultadosBusquedaPage GetResultadosBusquedaPage()
        {
            _resultadosBusquedaPage = new ResultadosBusquedaPage(Driver);
            return _resultadosBusquedaPage;
        }
    }
}