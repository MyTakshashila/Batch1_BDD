using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowProject.StepDefinitions
{
    [Binding]
    public class CreditCardOptions
    {
        private IWebDriver driver;
        private HomePage homePage;
        private ApplicationPage applicationPage;

        [Given(@"User is on the home page")]
        public void GivenUserIsOnTheHomePage()
        {
            driver = new ChromeDriver();
            homePage = new HomePage(driver);
            homePage.NavigateTo();
        }

        [When(@"User views the New low rate")]
        public void WhenUserViewsTheNewLowRate()
        {
            applicationPage = homePage.ClickApplyLowRateLink();
        }

        [When(@"User views the Quick links - Apply now")]
        public void WhenUserViewsQuickLinksApplyNow()
        {
            applicationPage = homePage.ApplyNow();
        }

        [When(@"User views the Easy application process")]
        public void WhenUserEasyApplicationProcess()
        {
            applicationPage = homePage.ClickApplyEasyApplicationLink();
        }
        [When(@"User views the Customer service")]
        public void WhenUserViewsCustomerService()
        {
            applicationPage = homePage.ClickCustomerServiceApplicationLink();
        }

        [Then(@"User is navigated to New credit card application page")]
        public void ThenUserIsNavigatedToNewCreditCardApplicationPage()
        {
            applicationPage.EnsurePageLoaded();
            driver.Dispose();
        }

        [When(@"User click on the Start Live Chat link")]
        public void WhenUserClickOnTheStartLiveChatLink()
        {
           homePage.ClickLiveChatFooterLink();
        }

        [Then(@"Live Chat is currentily closed Popup displayed")]
        public void ThenLiveChatIsCurrentilyClosedPopupDisplayed()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            IAlert alert = wait.Until(x => IsAlertPresent(x));
            Assert.AreEqual("Live chat is currently closed.", alert.Text);
            alert.Accept();
            driver.Dispose();
        }

        public static IAlert IsAlertPresent(IWebDriver driver)
        {
            try
            {
                return driver.SwitchTo().Alert();
            }
            catch (NoAlertPresentException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
