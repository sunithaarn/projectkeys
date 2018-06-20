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
   public class AddTenant :Base
    {
        public AddTenant()
        {
            PageFactory.InitElements(Global.Driver.driver, this);

        }

        
        #region Web elements definition

        //Define Tenant email
        [FindsBy(How =How.XPath,Using = "//input[@placeholder='Tenant Email']")]
        private IWebElement TenantEmail { get; set; }

        //Define Is Main tenant option
        [FindsBy(How =How.XPath,Using = "//*[@id='BasicDetail']/div/div[2]/div[2]/div/select")]
        private IWebElement IsMaintenant { get; set; }

        //Define Firstname
        [FindsBy(How=How.XPath,Using = "//input[@placeholder='First Name']")]
        private IWebElement Firstname { get; set; }

        //Define Last Name
        [FindsBy(How =How.XPath,Using = "//input[@placeholder='Last Name']")]
        private IWebElement Lastname { get; set; }
       
        //Define Rent start date
        [FindsBy(How =How.XPath,Using = "//input[@placeholder='Rent Start Date']")]
        private IWebElement Rentstartdate { get; set; }

        //Define Rent End date
        [FindsBy(How =How.XPath,Using = "//input[@placeholder='Rent End Date']")]
        private IWebElement Rentenddate { get; set; }

        //Define Rent amount
        [FindsBy(How =How.XPath,Using = "//input[@placeholder='Rent Amount']")]
        private IWebElement Rentamount { get; set; }

        //Define payment frequency
        [FindsBy(How=How.XPath,Using = ".//*[@id='BasicDetail']/div/div[5]/div[2]/div/select")]
        private IWebElement paymentfrequency { get; set; }

        //Define payment start date
        [FindsBy(How=How.XPath,Using = "//input[@placeholder='Payment Start Date']")]
        private IWebElement Paymentstartdate { get; set; }

        //Define payment due date
        [FindsBy(How =How.XPath,Using = ".//*[@id='BasicDetail']/div/div[6]/div[2]/div/select")]
        private IWebElement Paymentduedate { get; set; }

        //Define Next button
        [FindsBy(How =How.XPath,Using = "//input[@value='Next']")]
        private IWebElement Next { get; set; }

        //Define Add new liability
        [FindsBy(How =How.XPath,Using = "//a[contains(.,' Add New Liability')]")]
        private IWebElement Addnewliability { get; set; }

        //Define Liability name
        [FindsBy(How =How.XPath,Using = "//select[@data-bind='value : TypeId']")]
        private IWebElement Liabilityname { get; set; }

        //Define Amount
        [FindsBy(How = How.XPath, Using = ".//*[@id='LiabilityDetail']/div/div[1]/div/table/tbody/tr/td[2]/input")]
        private IWebElement Amount { get; set; }

        //Define save
        [FindsBy(How =How.XPath,Using = ".//*[@id='LiabilityDetail']/div/div[1]/div/table/tbody/tr/td[3]/input")]
        private IWebElement Save { get; set; }

        //Define Next 
        [FindsBy(How =How.XPath,Using = "//button[contains(.,'Next')]")]
        private IWebElement Nextinliability { get; set; }

        //Define submit
        [FindsBy(How =How.XPath,Using = "//button[@data-bind='click:AddTenantToProperty']")]
        private IWebElement Submit { get; set; }

        #endregion

        #region Add Tenant
        internal void Addtenantdetails()
        {


            try
            {
                //Populate value from excel
                ExcelLib.PopulateInCollection(Base.ExcelPath, "AddTenant");
                TenantEmail.SendKeys(ExcelLib.ReadData(2, "TenantEmail"));
                IsMaintenant.SendKeys(ExcelLib.ReadData(2, "IsMainTenant"));
                Global.Driver.wait(5);
                Firstname.SendKeys(ExcelLib.ReadData(2, "FirstName"));
                Lastname.SendKeys(ExcelLib.ReadData(2, "LastName"));
                Rentstartdate.SendKeys(ExcelLib.ReadData(2, "RentStartDate"));
                Rentenddate.SendKeys(ExcelLib.ReadData(2, "RentEndDate"));
                Rentamount.SendKeys(ExcelLib.ReadData(2, "RentAmount"));
                paymentfrequency.SendKeys(ExcelLib.ReadData(2, "PaymentFrequency"));
                Paymentstartdate.SendKeys(ExcelLib.ReadData(2, "PaymentStartDate"));
                Paymentduedate.SendKeys(ExcelLib.ReadData(2, "PaymentDueDate"));
                Next.Click();
                Addnewliability.Click();
                Liabilityname.SendKeys(ExcelLib.ReadData(2, "LiabilityName"));
                Amount.SendKeys(ExcelLib.ReadData(2, "Amount"));
                Save.Click();
                Nextinliability.Click();
                Submit.Click();
               

            }

            catch(Exception e)
            {
                //logging the result
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Error in adding tenant" + e.Message);
                //screenshots
                String img = SaveScreenShotClass.SaveScreenshot(Driver.driver, "Report");//AddScreenCapture(@"E:\Dropbox\VisualStudio\Projects\Beehive\TestReports\ScreenShots\");
                test.Log(LogStatus.Info, "Image example: " + img);
            }

        }
        #endregion

    }
}
