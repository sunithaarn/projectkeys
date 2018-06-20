using Keys_Onboarding.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Keys_Onboarding.Global.CommonMethods;

namespace Keys_Onboarding.Pages
{
    public class RentalProperties : Base
    {

        public RentalProperties()
        {
            PageFactory.InitElements(Global.Driver.driver, this);
        }
        //Webelements Definition
        //Define Search option
        [FindsBy(How = How.XPath, Using = "//input[@id='SearchBox']")]
        private IWebElement Search { get; set; }

        //Define search submit
        [FindsBy(How = How.XPath, Using = "//i[@id='icon-submitt']")]
        private IWebElement Searchsubmit { get; set; }


        internal void SearchinRentallistings()
        {
            try
            {

                Driver.wait(5);
                //populate data from excel
                ExcelLib.PopulateInCollection(Base.ExcelPath, "ListRentalProperty");

                //Enter the value in the search bar
                string ExpectedValue = ExcelLib.ReadData(2, "Title");
                Search.SendKeys(ExpectedValue);
                Global.Driver.wait(5);

                //Click on the search button
                Searchsubmit.Click();
                Driver.wait(5);

                string ActualValue = Global.Driver.driver.FindElement(By.XPath(".//*[@id='main-content']/section/div[1]/div[3]/div/div[1]/div[2]/div[1]/div[1]/a")).Text;

                //verification part
                if (ExpectedValue == ActualValue)
                {
                    //Logging results
                    test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Property successfully listed for the rent");
                    // screenshots
                    String img = SaveScreenShotClass.SaveScreenshot(Driver.driver, "Report");//AddScreenCapture(@"E:\Dropbox\VisualStudio\Projects\Beehive\TestReports\ScreenShots\");
                    test.Log(LogStatus.Info, "Image example: " + img);

                }
                else
                {
                    //Logging test results
                    test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Property not listed for the rent");
                    // screenshots
                    String img = SaveScreenShotClass.SaveScreenshot(Driver.driver, "Report");//AddScreenCapture(@"E:\Dropbox\VisualStudio\Projects\Beehive\TestReports\ScreenShots\");
                    test.Log(LogStatus.Info, "Image example: " + img);
                }
            }

            catch (Exception e)
            {
                //logging test results
                test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Error in Searching Rental properties" + e.Message);
                // screenshots
                String img = SaveScreenShotClass.SaveScreenshot(Driver.driver, "Report");//AddScreenCapture(@"E:\Dropbox\VisualStudio\Projects\Beehive\TestReports\ScreenShots\");
                test.Log(LogStatus.Info, "Image example: " + img);

            }


        }

    }
}
