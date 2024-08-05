using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using System.Data;

namespace YapePrueba2.Drivers
{
    public class AppiumDriver
    {
        public AndroidDriver<AppiumWebElement> Driver { get; set; }

        public AndroidDriver<AppiumWebElement> InitializeAppium()
        {
            var driverOptions = new AppiumOptions();
            driverOptions.AddAdditionalCapability(MobileCapabilityType.PlatformName, "Android");
            driverOptions.AddAdditionalCapability(MobileCapabilityType.DeviceName, "emulador");
            driverOptions.AddAdditionalCapability(MobileCapabilityType.Udid, "emulator-5554");
            driverOptions.AddAdditionalCapability(MobileCapabilityType.App, @"C:\Users\Kratos\Downloads\booking-com-32-9.apk");
            driverOptions.AddAdditionalCapability("fullReset", false);
            driverOptions.AddAdditionalCapability("appWaitPackage", "com.booking");
            //driverOptions.AddAdditionalCapability("appWaitActivity", "com.booking.MainActivity");
            Driver = new AndroidDriver<AppiumWebElement>(new Uri("http://127.0.0.1:4723/wd/hub"), driverOptions);

            if (Driver.ConnectionType == ConnectionType.None || Driver.ConnectionType == ConnectionType.AirplaneMode)
            {
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfo.FileName = "cmd.exe";
                startInfo.Arguments = "/C adb shell cmd -w wifi set-wifi-enabled enabled";
                process.StartInfo = startInfo;
                process.Start();
                Thread.Sleep(3000);
                Driver.ResetApp();
            }

            return Driver;
        }
    }
}
