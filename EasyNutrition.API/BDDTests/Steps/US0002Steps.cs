using System;
using TechTalk.SpecFlow;

namespace BDDTests.Steps
{
    [Binding]
    public class US0002Steps
    {
        [When(@"loads the postulations section")]
        public void WhenLoadsThePostulationsSection()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"he fills up the filters of name, DNI, date or status")]
        public void WhenHeFillsUpTheFiltersOfNameDNIDateOrStatus()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"he accepts or denies the request")]
        public void WhenHeAcceptsOrDeniesTheRequest()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"he accept the request")]
        public void WhenHeAcceptTheRequest()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"he denies a request in the postulation section")]
        public void WhenHeDeniesARequestInThePostulationSection()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the system shows the nutritionists postulations list\.")]
        public void ThenTheSystemShowsTheNutritionistsPostulationsList_()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the system shows the data filtered")]
        public void ThenTheSystemShowsTheDataFiltered()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the system shows a confirmation window")]
        public void ThenTheSystemShowsAConfirmationWindow()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the state of the request will be accepted and gives the nutritionist the role of nutritionist")]
        public void ThenTheStateOfTheRequestWillBeAcceptedAndGivesTheNutritionistTheRoleOfNutritionist()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the status of the request will become denied and the nutritionist cant access to the functionalities of the role nutritionist")]
        public void ThenTheStatusOfTheRequestWillBecomeDeniedAndTheNutritionistCantAccessToTheFunctionalitiesOfTheRoleNutritionist()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
