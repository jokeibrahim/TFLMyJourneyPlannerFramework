using TechTalk.SpecFlow;
using TFLMyJourneyPlannerFramework.Pages;
using TFLMyJourneyPlannerFramework.Hooks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TFLMyJourneyPlannerFramework.StepDefinitions
{
    [Binding]
    public class JourneyStepDefinitions
    {
        private JourneyPlannerPage journeyPlannerPage;
        private Context context;

        public JourneyStepDefinitions(JourneyPlannerPage _journeyPlannerPage, Context _context)
        {
            journeyPlannerPage = _journeyPlannerPage;
            context = _context;
        }

        [Given(@"that TFL Website is successfully launched")]
        public void GivenThatTFLWebsiteIsSuccessfullyLaunched()
        {
            context.LaunchAnApplication();
            journeyPlannerPage.AcceptCookie();
        }

        [When(@"a customer enters valid from ""(.*)"" and to ""(.*)"" Locations")]
        public void GivenACustomerEntersValidFromAndToLocations(string FromData, string ToData)
        {
            journeyPlannerPage.FromLabelField(FromData);
            journeyPlannerPage.ToLabelField(ToData);
        }

        [When(@"a customer inputs ""(.*)"" and ""(.*)"" as new from and to journey data")]
        public void WhenACustomerInputsAndAsNewFromAndToJourneyData(string FromData, string ToData)
        {
            journeyPlannerPage.EditJourneyOnFromField(FromData);
            journeyPlannerPage.EditJourneyOnToField(ToData);
        }

        [When(@"a customer clicks on plan my Journey")]
        [When(@"a customer clicks on update Journey")]
        public void WhenACustomerClicksOnPlanMyJourney()
        {
                journeyPlannerPage.ClickJourneyButton();
        }

        [Then(@"the result page should have ""(.*)"" and ""(.*)"" displayed")]
        public void ThenANewPageWithResultsShouldDisplay(string fromData, string ToData)
        {
            Assert.IsTrue(journeyPlannerPage.ReturnFromJourneyTexts(fromData));
            Assert.IsTrue(journeyPlannerPage.ReturnToJourneyTexts(ToData));
        }

        [Then(@"the result page should display (.*)")]
        public void ThenTheResultPageShouldDisplay(string expectedResult)
        {
            Assert.IsTrue(journeyPlannerPage.ResultPageTexts().Equals(expectedResult));
        }

        [Then(@"an error message ""(.*)"" should be displayed")]
        public void ThenAnErrorMessageShouldBeDisplayed(string errorMessage)
        {
            Assert.IsTrue(journeyPlannerPage.ReturnErrorMessage(errorMessage).Equals(errorMessage));
        }

        [When(@"a customer clicks on edit journey link")]
        public void WhenACustomerClicksOnEditJourneyButton()
        {
            journeyPlannerPage.EditJourney();
        }

        [Then(@"a user is able to see a list of journeys (.*) and (.*)")]
        public void ThenAUserIsAbleToSeeAListOfJourneys(string data1, string data2)
        {
            var actualRecentJourney = journeyPlannerPage.ReturnLisOfRecentJourney();
            Assert.IsTrue(actualRecentJourney[0].Contains(data1));
            Assert.IsTrue(actualRecentJourney[1].Contains(data2));
        }

        [Then(@"the error message (.*) should be displayed")]
        public void ThenTheErrorMessageShouldBeDisplayed(string expectedErrorMessage)
        {
            Assert.IsTrue(journeyPlannerPage.ReturnInvalidJourneyErrorMessage().Equals(expectedErrorMessage));
        }

        [AfterScenario]
        public void CloseTfLApplication()
        {
            context.CloseAnApplication();
        }
    }
}  
  
