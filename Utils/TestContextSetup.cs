using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium;
using YapePrueba2.PageObjects;

namespace YapePrueba2.Utils
{
    public class TestContextSetup
    {
        public ScenarioContext _scenarioContext;
        public AndroidDriver<AppiumWebElement> driver;
        public PageObjectManager pageObjectManager;

        public TestContextSetup(ScenarioContext scenarioContext) 
        {
            _scenarioContext = scenarioContext;
            driver = _scenarioContext.Get<AndroidDriver<AppiumWebElement>>();
            pageObjectManager = new PageObjectManager(driver);
        }
    }
}
