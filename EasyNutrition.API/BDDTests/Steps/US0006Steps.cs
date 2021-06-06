using System;
using TechTalk.SpecFlow;

namespace BDDTests.Steps
{
    [Binding]
    public class US0006Steps
    {
        [Given(@"a nutritionist logged in")]
        public void GivenANutritionistLoggedIn()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"a nutritionist is in patient section")]
        public void GivenANutritionistIsInPatientSection()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"a nutritionist is in the fill advance report section")]
        public void GivenANutritionistIsInTheFillAdvanceReportSection()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"he goes to patient section")]
        public void WhenHeGoesToPatientSection()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"he clicks into a patient")]
        public void WhenHeClicksIntoAPatient()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"he clicks into report advances")]
        public void WhenHeClicksIntoReportAdvances()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"he clicks on save report")]
        public void WhenHeClicksOnSaveReport()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the system should show which patients had an appointment and their data")]
        public void ThenTheSystemShouldShowWhichPatientsHadAnAppointmentAndTheirData()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the system should show detailed data from the patient and its respective appointments")]
        public void ThenTheSystemShouldShowDetailedDataFromThePatientAndItsRespectiveAppointments()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the system should show a form where it should fill advances and future recomendations")]
        public void ThenTheSystemShouldShowAFormWhereItShouldFillAdvancesAndFutureRecomendations()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the system should save the report in the data base for the patient to check it")]
        public void ThenTheSystemShouldSaveTheReportInTheDataBaseForThePatientToCheckIt()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the system should save the report in the data base but the patient will not be able to check it")]
        public void ThenTheSystemShouldSaveTheReportInTheDataBaseButThePatientWillNotBeAbleToCheckIt()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
