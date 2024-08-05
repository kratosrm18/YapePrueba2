using YapePrueba2.Utils;
using YapePrueba2.PageObjects;
using OpenQA.Selenium.Appium;
using NUnit.Framework;
using System.Globalization;

namespace YapePrueba2.StepDefinitions
{
    [Binding]
    public class BookingStepDefinitions
    {
        TestContextSetup testContextSetup;
        ScenarioContext _scenarioContext;
        SearchPage SearchPage { get; set; }
        StartPage StartPage { get; set; }
        BookingOverviewPage BookingOverviewPage { get; set; }
        FormularioInfoClientePage FormularioInfoClientePage { get; set; }
        DetalleHabitacionesHotelPage DetalleHabitacionesHotelPage { get; set; }
        DetallesHotelPage DetallesHotelPage { get; set; }
        ResultadosBusquedaPage ResultadosBusquedaPage { get; set; }
        string nombre;
        string apellido;
        string email;
        string country;
        string mobilePhone;
        string fechaInicioReservada;
        string fechaFinReservada;
        string nombreHotel;
        string direccion;
        int noches;
        int rooms;
        int adults;
        int ninos;
        string precio;
        int descuento;
        int days;
        string roomsGuests;
        DateTime f1;
        DateTime f2;
        string estadia;
        bool necesitaTarjeta;

        public BookingStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            testContextSetup = new TestContextSetup(_scenarioContext);
            SearchPage = testContextSetup.pageObjectManager.GetSearchPage();
            StartPage = testContextSetup.pageObjectManager.GetStartPage();
            BookingOverviewPage = testContextSetup.pageObjectManager.GetBookingOverviewPage();
            FormularioInfoClientePage = testContextSetup.pageObjectManager.GetFormularioInfoClientePage();
            DetalleHabitacionesHotelPage = testContextSetup.pageObjectManager.GetDetalleHabitacionesHotelPage();
            DetallesHotelPage = testContextSetup.pageObjectManager.GetDetallesHotelPage();
            ResultadosBusquedaPage = testContextSetup.pageObjectManager.GetResultadosBusquedaPage();
            fechaInicioReservada = string.Empty;
            fechaFinReservada = string.Empty;
            nombreHotel = string.Empty;
            days = 0;
            roomsGuests = string.Empty;
            direccion = string.Empty;
            nombre = "Kalin";
            apellido = "Osorio";
            email = "kalinosorio18@gmail.com";
            country = "Peru";
            mobilePhone = "986826033";
            noches = 0;
            rooms = 0;
            adults = 0;
            ninos = 0;
            precio = string.Empty;
            descuento = 0;
            necesitaTarjeta = true;
            estadia = string.Empty;
        }

        [Given(@"El usuario accede a la app")]
        public void GivenElUsuarioAccedeALaApp()
        {
            StartPage.ClickBotonCerrar();
        }


        [Given(@"El usuario busca (.*) como destino")]
        public void GivenElUsuarioBuscaCUSCOComoDestino(string ciudad)
        {
            SearchPage.ClickDestino();
            SearchPage.IngresarDestino(ciudad);
            SearchPage.ClickPrimerResultado();
        }

        [Given(@"Selecciona las fechas (.*) al (.*)")]
        public void GivenSeleccionaLasFechasAl(string fi, string ff)
        {
            SearchPage.SeleccionarFechaInicio(fi);
            SearchPage.SeleccionarFechaFin(ff);
            f1 = DateTime.ParseExact(fi, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            f2 = DateTime.ParseExact(ff, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            days = (f2-f1).Days;
            //Console.WriteLine(days);
            SearchPage.ClickSelectDates();
        }

        [Given(@"Selecciona (.*) habitacion (.*) adultos y un nino de (.*) anos")]
        public void GivenSeleccionaHabitacionAdultosYNino(int h, int a, int edadNino)
        {
            SearchPage.ClickHabitaciones();
            SearchPage.SeleccionarHabitaciones(h);
            SearchPage.SeleccionarAdultos(a);
            SearchPage.SeleccionarNinos(1);
            SearchPage.SeleccionarEdadDeNino(edadNino);
            SearchPage.ClickSeleccionarEdadDeNinoOK();
        }

        [When(@"Selecciona el boton APPLY")]
        public void WhenSeleccionaElBotonAPPLY()
        {
            SearchPage.ClickAPPLY();
        }

        [When(@"Selecciona el boton Search")]
        public void WhenSeleccionaElBotonBuscar()
        {
            SearchPage.ClickSearch();
        }
        [When(@"Selecciona el segundo resultado")]
        public void WhenSeleccionaElSegundoResultado()
        {
            ResultadosBusquedaPage.ClickSegundoResultado();
        }

        [When(@"Selecciona el boton Select rooms")]
        public void WhenSeleccionaElBotonSelectRooms()
        {
            BookingOverviewPage.HacerScroll(200);
            fechaInicioReservada = DetallesHotelPage.GetCheckIn();
            fechaFinReservada = DetallesHotelPage.GetCheckOut();
            nombreHotel = DetallesHotelPage.GetNombreHotel();
            roomsGuests = DetallesHotelPage.GetRoomsGuests();
            //Console.WriteLine(DetallesHotelPage.GetPrecio());
            //Console.WriteLine(DetallesHotelPage.GetPrecio().Trim([',','U','S','$']));
            precio = DetallesHotelPage.GetPrecio();
            //Console.WriteLine("precio: " + precio);
            direccion = DetallesHotelPage.GetDireccion();
            necesitaTarjeta = !DetallesHotelPage.GetNoNecesitaTarjeta();
            DetallesHotelPage.ClickSelectRooms();
        }

        [When(@"Selecciona la primera opcion de habitacion")]
        public void WhenSeleccionaLaPrimeraOpcionHabitacion()
        {
            DetalleHabitacionesHotelPage.ClickPrimeraOpcion();
        }

        [When(@"Selecciona el boton Reserve")]
        public void WhenSeleccionaElBotonReserve()
        {
            DetalleHabitacionesHotelPage.ClickReserve();
            _scenarioContext.Set(false, "tomarSS");
        }

        [When(@"Llena los datos del formulario")]
        public void WhenLlenaLosDatosDelFormulario()
        {
            FormularioInfoClientePage.Esperar(1);
            Assert.AreEqual(FormularioInfoClientePage.GetTitulo(), "Fill in your info");
            FormularioInfoClientePage.HacerScroll();
            FormularioInfoClientePage.IngresarFirstName(nombre);
            FormularioInfoClientePage.IngresarLastName(apellido);
            FormularioInfoClientePage.IngresarEmailAddress(email);
            //FormularioInfoClientePage.IngresarCountryRegion(country);
            FormularioInfoClientePage.IngresarMobilePhone(mobilePhone);
            Assert.AreEqual(FormularioInfoClientePage.GetPurposeQuestion(), "What's the primary purpose of your trip?");
            FormularioInfoClientePage.ClickBusinessRadio();
            FormularioInfoClientePage.ClickLeisureRadio();
            _scenarioContext.Set(false, "tomarSS");

        }

        [When(@"Selecciona boton Next step")]
        public void WhenSeleccionaBotonNextStep()
        {
            FormularioInfoClientePage.ClickNextStep();
            _scenarioContext.Set(false, "tomarSS");
        }

        [Then(@"Se visualizan los datos de la reserva")]
        public void ThenSeVisualizanLosDatosDeLaReserva()
        {
            Assert.AreEqual(BookingOverviewPage.GetNombreHotel() , nombreHotel);
            Assert.IsTrue(direccion.Contains(BookingOverviewPage.GetDireccionHotel()));

            string formato1 = "ddd MMM dd yyyy";
            string formato2 = "ddd, MMM dd";

            DateTime fechaInicioEncontrada = DateTime.ParseExact(BookingOverviewPage.GetFechaInicio(),formato1, CultureInfo.InvariantCulture);
            DateTime fechaInicioEsperada = DateTime.ParseExact(fechaInicioReservada, formato2, CultureInfo.InvariantCulture);
            DateTime fechaFinEncontrada = DateTime.ParseExact(BookingOverviewPage.GetFechaFin(), formato1, CultureInfo.InvariantCulture);
            DateTime fechaFinEsperada = DateTime.ParseExact(fechaFinReservada, formato2, CultureInfo.InvariantCulture);

            Assert.AreEqual(fechaInicioEncontrada , fechaInicioEsperada);
            Assert.AreEqual(fechaFinEncontrada, fechaFinEsperada);
            string[] roomsGuestsSplited = roomsGuests.Split(" ");
            estadia = days+" nights, "+ roomsGuestsSplited[0] +" room for "+ roomsGuestsSplited[2]+" adults, "+ roomsGuestsSplited[4]+" child";
            Assert.AreEqual(BookingOverviewPage.GetInfoEstadia() , estadia);
            _scenarioContext.Set(false, "tomarSS");
        }

        [When(@"Selecciona boton Final step")]
        public void WhenSeleccionaBotonFinalStep()
        {
            if (necesitaTarjeta){
                BookingOverviewPage.ClickFinalStep();
            }
            _scenarioContext.Set(false, "tomarSS");
        }

        [Then(@"Se visualiza el formulario de tarjeta de credito")]
        public void ThenSeVisualizaElFormularioDeTarjetaDeCredito()
        {
            if (necesitaTarjeta)
            {
                Assert.IsTrue(BookingOverviewPage.SeMuestraCardNumber());
                Assert.IsTrue(BookingOverviewPage.SeMuestraNombre());
                Assert.AreEqual(nombre, BookingOverviewPage.GetNombre());
                Assert.IsTrue(BookingOverviewPage.SeMuestraExpirationDate());
                Assert.IsTrue(BookingOverviewPage.SeMuestraLinkAddPromoCode());
                Assert.IsTrue(BookingOverviewPage.SeMuestraMensajeSaveMoney());
            }
            BookingOverviewPage.ScrollHastaEncontrarTexto("View price breakdown");
            
            Assert.AreEqual(precio, BookingOverviewPage.GetPrecioResumen());
            Assert.AreEqual(precio , BookingOverviewPage.GetPrecioTotal());
            Assert.AreEqual(BookingOverviewPage.GetImpuestos(), BookingOverviewPage.GetTaxesResumen());
            Assert.IsTrue(BookingOverviewPage.SeMuestraBotonBookNow());
            _scenarioContext.Set(false, "tomarSS");
        }

        [Then(@"Visualiza alerta de ingresar destino")]
        public void ThenVisualizaAlertaDeIngresarDestino()
        {
            Assert.AreEqual("Please enter your destination", SearchPage.GetAlertaIngreseDestino());
        }

        [Then(@"Se visualiza alerta de ingresar su nombre")]
        public void ThenSeVisualizaAlertaDeIngresarSuNombre()
        {
            Assert.AreEqual("Please enter your first name.", FormularioInfoClientePage.GetAlertaIngreseNombre());
        }


    }
}
