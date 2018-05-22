using Keys_Onboarding.Config;
using Keys_Onboarding.Global;
using Keys_Onboarding.Pages;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using RelevantCodes.ExtentReports;
using System;
using TechTalk.SpecFlow;


namespace Keys_Onboarding.Specflow
{

    #region
    [Binding]
    public class AddNewPropertySteps : Global.Base
    {
        [Given(@"Owner logged into the application")]
        public void GivenOwnerLoggedIntoTheApplication()
        {
            switch (Browser)
            {

                case 1:
                    Driver.driver = new FirefoxDriver();
                    break;
                case 2:
                    Driver.driver = new ChromeDriver();
                    Driver.driver.Manage().Window.Maximize();
                    break;

            }
            if (Keys_Resource.IsLogin == "true")
            {
                Login loginobj = new Login();
                loginobj.LoginSuccessfull();
            }
            else
            {
                Register obj = new Register();
                obj.Navigateregister();
            }

            extent = new ExtentReports(ReportPath, false, DisplayOrder.NewestFirst);
            extent.LoadConfig(Keys_Resource.ReportXMLPath);
        }
        [Given(@"Move to properties page")]
        public void GivenMoveToPropertiesPage()
        {
            PropertyOwner ownerobj = new PropertyOwner();
            ownerobj.Common_methods();
        }

        [When(@"Click AddNewProperty to add details about new property")]
        public void WhenClickAddNewPropertyToAddDetailsAboutNewProperty()
        {

            AddNewProperty propertyobj = new AddNewProperty();
            propertyobj.AddPropertyDetails();
            //Global.Driver.driver.Close();

        }

        [Then(@"Added property should be displayed under Myproperties")]
        public void ThenAddedPropertyShouldBeDisplayedUnderMyproperties()
        {

            // test = extent.StartTest("Search Property");

            // Create an class and object to call the method
            PropertyOwner obj = new PropertyOwner();
            obj.SearchAProperty();

            //Close the broswer
            Global.Driver.driver.Close();
        }
#endregion
 #region

        [Given(@"move to the properties page")]
        public void GivenMoveToThePropertiesPage()
        {
            switch (Browser)
            {

                case 1:
                    Driver.driver = new FirefoxDriver();
                    break;
                case 2:
                    Driver.driver = new ChromeDriver();
                    Driver.driver.Manage().Window.Maximize();
                    break;

            }
            if (Keys_Resource.IsLogin == "true")
            {
                Login loginobj = new Login();
                loginobj.LoginSuccessfull();
            }
            else
            {
                Register obj = new Register();
                obj.Navigateregister();
            }

            extent = new ExtentReports(ReportPath, false, DisplayOrder.NewestFirst);
            extent.LoadConfig(Keys_Resource.ReportXMLPath);
        }
       [Given(@"under properties page")]
        public void GivenUnderPropertiesPage()
        {
            PropertyOwner ownerobj = new PropertyOwner();
            ownerobj.Common_methods();
        }

        [When(@"ownerclick Addnew property to add details")]
        public void WhenOwnerclickAddnewPropertyToAddDetails()
        {
            AddNewProperty propertyobj = new AddNewProperty();
            propertyobj.AddPropertyDetails();
        }

        [Then(@"properties should is saved with successfully and displayed under properties")]
        public void ThenPropertiesShouldIsSavedWithSuccessfullyAndDisplayedUnderProperties()
        {
            // Create an class and object to call the method
            PropertyOwner obj = new PropertyOwner();
            obj.SearchAProperty();

            //Close the broswer
            Global.Driver.driver.Close();
        }
    }

    #endregion

}