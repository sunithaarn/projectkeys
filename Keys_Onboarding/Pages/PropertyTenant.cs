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
   public class PropertyTenant :Base
    {

        public PropertyTenant()
        {
            PageFactory.InitElements(Driver.driver, this);

        }

        // Define Next page link
        [FindsBy(How= How.XPath,Using = "//a[@rel='next']")]
        private IWebElement Nextpage { get; set; }
       
        internal void Searchtenant()
        {

            try
            {
                //Populate values from Excel
                ExcelLib.PopulateInCollection(Base.ExcelPath, "AddTenant");
                string Tenantemailexpected = ExcelLib.ReadData(2, "TenantEmail");
                          
                string Tenantemailactual;

                int k = 1;
                //int j = 1;

                //Verification
                while (true)
                {
                    
                    Tenantemailactual = Driver.driver.FindElement(By.XPath(".//*[@id='property-grid']/div[1]/div["+k+"]/div/div[2]/div/div[3]/div/span")).Text;

                    if (Tenantemailexpected == Tenantemailactual)
                        {

                        //Logging results
                        Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Tenant Found");
                        //screenshots
                        String img = SaveScreenShotClass.SaveScreenshot(Driver.driver, "Report");//AddScreenCapture(@"E:\Dropbox\VisualStudio\Projects\Beehive\TestReports\ScreenShots\");
                        test.Log(LogStatus.Info, "Image example: " + img);

                        return;
                        }

                    else
                    {
                        k++;
                       // j++;
                        if(k>10)
                        {
                            k = 1;
                            Nextpage.Click();
                        }
                    }

                 }

                   

        }
            catch(Exception e)
            {
                //Logging results
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Tenant Not found" + e.Message);
                //screenshots
                String img = SaveScreenShotClass.SaveScreenshot(Driver.driver, "Report");//AddScreenCapture(@"E:\Dropbox\VisualStudio\Projects\Beehive\TestReports\ScreenShots\");
                test.Log(LogStatus.Info, "Image example: " + img);

            }

                    
        }
   }
}
