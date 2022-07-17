using TFLMyJourneyPlannerFramework.Hooks;
using OpenQA.Selenium;
using System.Threading;
using System.Collections.Generic;

namespace TFLMyJourneyPlannerFramework.Pages
{
    public class JourneyPlannerPage
    {
        private Context context;
        public JourneyPlannerPage(Context _context)
        {
            context = _context;
        }

        private By AcceptCookieElement = By.XPath("//*[@id='CybotCookiebotDialogBodyLevelButtonLevelOptinAllowAll']/strong");
        private By DoneCookieBtn = By.XPath("/html/body/div[1]/div[4]/div[2]/button");
        private By FromLabel = By.CssSelector(".jpFrom.tt-input");
        private By ToLabel = By.CssSelector(".jpTo.tt-input");
        private By PlanAJourneyButton = By.CssSelector(".primary-button.plan-journey-button");
        private By JourneyResult = By.CssSelector(".last-breadcrumb");
        private By EditJourneyElement = By.XPath("//*[@id='plan-a-journey']/div[1]/div[3]/a/span");
        private By RecentJourneyTab = By.XPath("//*[@id='jp-recent-tab-jp']/a");
        private By ViewRecentJourney = By.CssSelector(".plain-button.journey-item");
        private By ResultPageElements = By.CssSelector(".summary-row.clearfix");
        private By FromFieldErrorMessage = By.XPath("//*[@id='InputFrom-error']");
        private By ToFieldErrorMessage = By.XPath("//*[@id='InputTo-error']");
        private By CloseIconOnFromField = By.XPath("//*[@id='search-filter-form-0']/div/div/a");
        private By CloseIconOnToField = By.XPath("//*[@id='search-filter-form-1']/div/a");
        private By ClickOnHomeLink = By.XPath("//*[@id='full-width-content']/div/div[1]/div/ol/li[2]/a/text()");
        private By InvalidJourneyErrorMessage = By.XPath("//*[@id='full-width-content']/div/div[8]/div/div/ul/li");


        public void AcceptCookie()
        {
            var cookie = context.driver.FindElement(AcceptCookieElement);
            if (cookie.Displayed)
            {
                cookie.Click();
                Thread.Sleep(1000);
                context.driver.FindElement(DoneCookieBtn).Click();
            }
        }
        public void FromLabelField(string FromData = null)
        {
            IWebElement fromtxtField = context.driver.FindElement(FromLabel);
            fromtxtField.Clear();
            fromtxtField.SendKeys(FromData);
            fromtxtField.SendKeys(Keys.Tab);
            Thread.Sleep(1000);
        }

        public void ToLabelField(string ToData = null)
        {
            IWebElement totxtField = context.driver.FindElement(ToLabel);
            totxtField.Clear();
            totxtField.SendKeys(ToData);
            totxtField.SendKeys(Keys.Tab);
            Thread.Sleep(1000);
        }

        public void ClickJourneyButton()
        {
            var elements = context.driver.FindElements(PlanAJourneyButton);
            foreach (var element in elements)
            {
                element.Click();
                break;
            }
            Thread.Sleep(2000);
        }

        public string ResultPageTexts()
        {   
            return context.driver.FindElement(JourneyResult).Text.Trim();
        }

        public bool ReturnFromJourneyTexts(string fromData)
        {
            var elements = context.driver.FindElements(ResultPageElements);
            foreach (var element in elements)
            {
                if (element.Text.Trim().Contains(fromData))
                {
                    return true;
                }
            }
            return false;
        }

        public bool ReturnToJourneyTexts(string toData)
        {
            var elements = context.driver.FindElements(ResultPageElements);
            foreach (var element in elements)
            {   
                if (element.Text.Trim().Contains(toData))
                {
                    return true;
                }
            }
            return false; 
        }
        public void EditJourney()
        {
            context.driver.FindElement(EditJourneyElement).Click();
        }

        public List<string> ReturnLisOfRecentJourney()
        {
            context.driver.FindElement(ClickOnHomeLink).Click();
            Thread.Sleep(1000);
            context.driver.FindElement(RecentJourneyTab).Click();
            List<string> listOfJourney = new List<string>();
            IList<IWebElement> elements = context.driver.FindElements(ViewRecentJourney);
            foreach (var element in elements)
            {
                listOfJourney.Add(element.Text.Trim());
            }
            return listOfJourney;
        }

        public string ReturnErrorMessage(string errorMessageName)
        {
            if (errorMessageName.Contains("From"))
            {
                return context.driver.FindElement(FromFieldErrorMessage).Text.Trim();
            }
            else if (errorMessageName.Contains("To"))
            {
                return context.driver.FindElement(ToFieldErrorMessage).Text.Trim(); ;
            }
            return null;
        }

        public void EditJourneyOnFromField(string FromData)
        {
            context.driver.FindElement(CloseIconOnFromField).Click();
            FromLabelField(FromData);
        }

        public void EditJourneyOnToField(string ToData)
        {
            context.driver.FindElement(CloseIconOnToField).Click();
            ToLabelField(ToData);
        }

        public string ReturnInvalidJourneyErrorMessage()
        {
            return context.driver.FindElement(InvalidJourneyErrorMessage).Text.Trim();
        }
    }
}   

