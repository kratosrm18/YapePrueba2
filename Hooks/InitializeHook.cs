using Allure.Commons;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using YapePrueba2.Drivers;

namespace YapePrueba2.Hooks
{
    [Binding]
    internal class InitializeHook
    {
        private readonly ScenarioContext _scenarioContext;
        public static AllureLifecycle allure = AllureLifecycle.Instance;

        public InitializeHook(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            //allure.CleanupResultDirectory();
        }

        [BeforeScenario]
        public void Initialize()
        {
            AppiumDriver appiumDriver = new AppiumDriver();
            _scenarioContext.Set(appiumDriver.InitializeAppium());
            _scenarioContext.Set(true, "tomarSS");
        }

        [AfterStep]
        public void AfterStep()
        {
            //Console.WriteLine(_scenarioContext.Get<bool>("tomarSS"));
            if (_scenarioContext.Get<bool>("tomarSS"))
            {
                Thread.Sleep(500);
                //byte[] content = CaptureScreenshot();
                //AllureLifecycle.Instance.AddAttachment("Screenshot", "application/png", content);
                Thread.Sleep(500);
            }
            _scenarioContext.Set(true,"tomarSS");
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _scenarioContext.Get<AndroidDriver<AppiumWebElement>>().CloseApp();
            _scenarioContext.Get<AndroidDriver<AppiumWebElement>>().PressKeyCode(AndroidKeyCode.Home);
            _scenarioContext.Get<AndroidDriver<AppiumWebElement>>().Quit();
        }

        public byte[] CaptureScreenshot() => ((ITakesScreenshot)_scenarioContext.Get<AndroidDriver<AppiumWebElement>>()).GetScreenshot().AsByteArray;
    }
}
