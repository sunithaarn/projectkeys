using Keys_Onboarding.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Keys_Onboarding.Global.CommonMethods;

namespace Keys_Onboarding.Pages
{
    public class ListRentalProperty : Base
    {

        public ListRentalProperty()
        {
            PageFactory.InitElements(Global.Driver.driver, this);
        }

        //WebElements definition
        #region web elements definition
      
        //Define Select property option
        [FindsBy(How = How.XPath, Using = "//select[@data-bind='value : PropertyId']")]
        private IWebElement Selectproperty { get; set; }

        //Define Title
        [FindsBy(How = How.XPath, Using = "//input[@data-bind='textInput : Title']")]
        private IWebElement Title { get; set; }

        //Define Description
        [FindsBy(How = How.XPath, Using = "//textarea[@data-bind='textInput : RentalDescription']")]
        private IWebElement Description { get; set; }

        //Define Moving cost
        [FindsBy(How = How.XPath, Using = "//input[@data-bind='textInput : MovingCost']")]
        private IWebElement Movingcost { get; set; }

        //Define Target rent
        [FindsBy(How = How.XPath, Using = "//input[@data-bind='textInput : TargetRent']")]
        private IWebElement Targentrent { get; set; }

        //Define Furnishing
        [FindsBy(How = How.XPath, Using = "//input[@data-bind='textInput : Furnishing']")]
        private IWebElement Furnishing { get; set; }

        //Define Available date
        [FindsBy(How = How.XPath, Using = "//input[@name='AvailableDate']")]
        private IWebElement Availabledate { get; set; }

        //Define Ideal Tenant
        [FindsBy(How = How.XPath, Using = "//input[@data-bind='textInput : IdealTenant']")]
        private IWebElement Idealtenant { get; set; }

        //Define occupant count
        [FindsBy(How = How.XPath, Using = "//input[@data-bind='textInput : OccupantCount']")]
        private IWebElement Occupantcount { get; set; }

        //Define pets allowed
        [FindsBy(How = How.XPath, Using = ".//*[@id='main-content']/section/form/fieldset/div[6]/div[2]/select")]
        private IWebElement Petsallowed { get; set; }

        //Define choose file
        [FindsBy(How = How.XPath, Using = "//input[@accept='image/*']")]
        private IWebElement Choosefile { get; set; }

        //Define save button
        [FindsBy(How = How.XPath, Using = "//button[@class='teal ui button']")]
        private IWebElement Save { get; set; }

        #endregion


        internal void ListPropertyforrent()
        {

            try
            {
                //Populate values from excel
                ExcelLib.PopulateInCollection(Base.ExcelPath, "ListRentalProperty");
                //select propery based on input
                SelectElement property = new SelectElement(Selectproperty);
                string propvalue = ExcelLib.ReadData(2, "SelectProperty");
                property.SelectByText(propvalue);
                // Field values are entered
                Title.SendKeys(ExcelLib.ReadData(2, "Title"));
                Description.SendKeys(ExcelLib.ReadData(2, "Description"));
                Movingcost.SendKeys(ExcelLib.ReadData(2, "Movingcost"));
                Targentrent.SendKeys(ExcelLib.ReadData(2, "Targetrent"));
                Furnishing.SendKeys(ExcelLib.ReadData(2, "Furnishing"));
                Availabledate.SendKeys(ExcelLib.ReadData(2, "Availabledate"));
                Idealtenant.SendKeys(ExcelLib.ReadData(2, "Idealtenant"));
                Occupantcount.SendKeys(ExcelLib.ReadData(2, "Occupantscount"));
                Petsallowed.SendKeys(ExcelLib.ReadData(2, "Pets"));
                Save.Click();
                Global.Driver.driver.SwitchTo().Alert().Accept();

                //logging the results
                test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Property Listed");
                // screenshots
                String img = SaveScreenShotClass.SaveScreenshot(Driver.driver, "Report");//AddScreenCapture(@"E:\Dropbox\VisualStudio\Projects\Beehive\TestReports\ScreenShots\");
                test.Log(LogStatus.Info, "Image example: " + img);
            }


            catch(Exception e)
            {
                //Logging the results
                test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Error in listing property for rent" +e.Message);
                // screenshots
                String img = SaveScreenShotClass.SaveScreenshot(Driver.driver, "Report");//AddScreenCapture(@"E:\Dropbox\VisualStudio\Projects\Beehive\TestReports\ScreenShots\");
                test.Log(LogStatus.Info, "Image example: " + img);
            }

        }



     }


}




