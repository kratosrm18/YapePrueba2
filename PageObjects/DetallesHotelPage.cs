using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace YapePrueba2.PageObjects
{
    internal class DetallesHotelPage(AndroidDriver<AppiumWebElement> driver) : BasePage(driver)
    {
        [FindsBy(How = How.Id, Using = "com.booking:id/checkin_display")]
        private readonly IWebElement checkIn;
        [FindsBy(How = How.Id, Using = "com.booking:id/checkout_display")]
        private readonly IWebElement checkOut;
        [FindsBy(How = How.Id, Using = "com.booking:id/property_name")]
        private readonly IWebElement nombreHotel;
        [FindsBy(How = How.Id, Using = "com.booking:id/hotel_location_nearby_info_summary")]
        private readonly IWebElement direccion;
        [FindsBy(How = How.Id, Using = "com.booking:id/price_view_price")]
        private readonly IWebElement precio;
        [FindsBy(How = How.Id, Using = "com.booking:id/rooms_guests_display")]
        private readonly IWebElement roomsGuests;
        [FindsBy(How = How.Id, Using = "com.booking:id/select_room_cta")]
        private readonly IWebElement botonSelectRooms;
        [FindsBy(How = How.Id, Using = "com.booking:id/property_no_cc_needed")]
        private readonly IWebElement noCreditCardNeeded;

        internal void ClickSelectRooms() => Click(botonSelectRooms);

        internal string GetCheckIn() => checkIn.Text;
    
        internal string GetCheckOut() => checkOut.Text;

        internal string GetNombreHotel() => nombreHotel.Text;

        internal string GetRoomsGuests()
        {
            while (!VisualizaByID("com.booking:id/rooms_guests_display"))
            {
                HacerScroll(200);
            }
            return roomsGuests.Text;
        }

        internal string GetPrecio() => precio.Text;

        internal string GetDireccion()
        {
            while (!VisualizaByID("com.booking:id/hotel_location_nearby_info_summary"))
            {
                HacerScroll(500);
            }
            return direccion.Text;
        }

        internal bool GetNoNecesitaTarjeta() => SeMuestra(noCreditCardNeeded);
    }
}
