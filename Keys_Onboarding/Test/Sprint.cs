using Keys_Onboarding.Global;
using Keys_Onboarding.Pages;
using NUnit.Framework;
using RelevantCodes.ExtentReports;
using System;
using static Keys_Onboarding.Global.CommonMethods;

namespace Keys_Onboarding.Test
{
    class Sprint 
    {
      [TestFixture]
      [Category("Sprint1")]
       class Tenant : Base
       {
            PropertyOwner ownerobj;
            AddNewProperty newpropertyobj;
            ListRentalProperty rentalobj;
            RentalProperties rentalpropertiesobj;
            AddTenant addtenantobj;
            PropertyTenant propertytenantobj;
            Dashboard dashboardobj;

          [Test,Description("Verifies Add New Property Feature")]
          public void PO_AddNewProperty()
            {
                // Creates a toggle for the given test, adds all log events under it    
                test = extent.StartTest("Add New Property", "verify owner able to add new property");


                // Property owner and Add New property class methods are used
                ownerobj = new PropertyOwner();
                newpropertyobj = new AddNewProperty();
                ownerobj.Common_methods();
                ownerobj.ClickAddNewProperty();
                newpropertyobj.AddPropertyDetails();
                ownerobj.SearchAProperty();

                          
            }

            [Test,Description("verifies List a Rental ")]
            public void PO_ListARental()
            {
                //creates a test and log all events 
                test = extent.StartTest("List A Rent", "verify owner able to list a property for rent");

                //property owner, List rental property and Rental properties class methods are used
                ownerobj = new PropertyOwner();
                ownerobj.Common_methods();
                ownerobj.ClickListaRental();
                rentalobj = new ListRentalProperty();
                rentalobj.ListPropertyforrent();
                rentalpropertiesobj = new RentalProperties();
                rentalpropertiesobj.SearchinRentallistings();
            }

            [Test,Description("Verifies Add Tenant")]
            public void PO_AddTenanttoProperty()
            {

                //creates a test and log all events under it
                test = extent.StartTest("Add Tenant to Property", "verify owner able to list a property for rent");

                //property owner, add tenant, propertytenant class methods are used
                ownerobj = new PropertyOwner();
                ownerobj.Common_methods();
                string result = ownerobj.SearchAProperty();
                if (result=="Pass")
                {
                    ownerobj.ClickAddTenant();
                    addtenantobj = new AddTenant();
                    addtenantobj.Addtenantdetails();
                    string searchproperty= ownerobj.SearchAProperty();
                    if (searchproperty =="Pass")
                    {
                        ownerobj.Clickeditoptions();
                        propertytenantobj = new PropertyTenant();
                        propertytenantobj.Searchtenant();
                    }

                }
                else
                {
                    //logging the test results 
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "No property found to add tenant");

                    //screenshots
                    String img = SaveScreenShotClass.SaveScreenshot(Driver.driver, "Report");//AddScreenCapture(@"E:\Dropbox\VisualStudio\Projects\Beehive\TestReports\ScreenShots\");
                    test.Log(LogStatus.Info, "Image example: " + img);
                }


            }
            [Test]
            public void PO_SortProperty()
            {
                //creates test and log all events under it
                test = extent.StartTest("Sort property", "verify owner able to sort property by name and name(desc)");

                //Dashboard and Propertyowner class methods are used
                dashboardobj = new Dashboard();
                int pcount = dashboardobj.Propertiescount();
                ownerobj = new PropertyOwner();        
                ownerobj.Getpropertyname(pcount);
                ownerobj.Sortbyoptions(pcount);
                

            }
        }
    }
}
