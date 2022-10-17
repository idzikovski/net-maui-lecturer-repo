using NUnit.Framework;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using FluentAssertions;
using OpenQA.Selenium.Interactions;

namespace RealEstate.UITests
{
    public class UITests
    {
        private AndroidDriver<AndroidElement> _driver;
        private DefaultWait<AndroidDriver<AndroidElement>> _wait;

        [SetUp]
        public void Setup()
        {
            var driverOption = new AppiumOptions();
            driverOption.AddAdditionalCapability(MobileCapabilityType.PlatformName, "Android");
            driverOption.AddAdditionalCapability(MobileCapabilityType.PlatformVersion, "12");
            driverOption.AddAdditionalCapability(MobileCapabilityType.DeviceName, "emulator-5554");
            driverOption.AddAdditionalCapability("appPackage", "com.companyname.realestate");
            driverOption.AddAdditionalCapability("appActivity", "crc64903f10baf905f991.MainActivity");

            _driver = new AndroidDriver<AndroidElement>(new Uri("http://localhost:4723/wd/hub"), driverOption);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(4);

            _wait = new DefaultWait<AndroidDriver<AndroidElement>>(_driver)
            {
                Timeout = TimeSpan.FromSeconds(30),
                PollingInterval = TimeSpan.FromMilliseconds(500),
            };
            _wait.IgnoreExceptionTypes(typeof(NoSuchElementException));

            _driver.LaunchApp();
        }

        [Test]
        public void WhenWrongPasswordIsEntered_ErrorLabelIsShown()
        {
            var username = _driver.FindElementById(ElementId("Username"));
            var password = _driver.FindElementById(ElementId("Password"));
            var loginButton = _driver.FindElementById(ElementId("LoginButton"));

            username.SendKeys("Hello World");
            password.SendKeys("123WrongPass");
            loginButton.Click();

            var errorLabel = _wait.Until(driver => driver.FindElementById(ElementId("ErrorLabel")));
            errorLabel.Should().NotBeNull();
            errorLabel.Text.Should().Be("Incorrect username or password");
        }

        [Test]
        public void WhenCorrectPasswordIsEntered_EstatesPageIsShown()
        {
            var username = _driver.FindElementById(ElementId("Username"));
            var password = _driver.FindElementById(ElementId("Password"));
            var loginButton = _driver.FindElementById(ElementId("LoginButton"));

            username.SendKeys("Hello World");
            password.SendKeys("123");
            loginButton.Click();

            var estatesPage = _wait.Until(driver => driver.FindElementById(ElementId("EstatesPage")));
            estatesPage.Should().NotBeNull();
        }

        [Test]
        public void TestScrollingAction()
        {
            var username = _driver.FindElementById(ElementId("Username"));
            var password = _driver.FindElementById(ElementId("Password"));
            var loginButton = _driver.FindElementById(ElementId("LoginButton"));

            username.SendKeys("Hello World");
            password.SendKeys("123");
            loginButton.Click();

            var estatesPage = _wait.Until(driver => driver.FindElementById(ElementId("EstatesPage")));

            var collectionView = _driver.FindElementById(ElementId("Collection"));

            FlickUp(_driver, collectionView);
            Thread.Sleep(500);
            FlickUp(_driver, collectionView);
            Thread.Sleep(500);
            FlickUp(_driver, collectionView);
        }

        private void FlickUp(AndroidDriver<AndroidElement> driver, AndroidElement element)
        {
            var input = new PointerInputDevice(PointerKind.Touch);
            ActionSequence flickUp = new ActionSequence(input);
            flickUp.AddAction(input.CreatePointerMove(element, 0, 400, TimeSpan.Zero));
            flickUp.AddAction(input.CreatePointerDown(MouseButton.Left));
            flickUp.AddAction(input.CreatePointerMove(element, 0, -400, TimeSpan.FromMilliseconds(200)));
            flickUp.AddAction(input.CreatePointerUp(MouseButton.Left));

            driver.PerformActions(new List<ActionSequence> { flickUp });
        }

        [TearDown]
        public void TearDown()
        {
            _driver.CloseApp();
            _driver?.Dispose();
        }

        private string ElementId(string id) => $"com.companyname.realestate:id/{id}";
    }
}
