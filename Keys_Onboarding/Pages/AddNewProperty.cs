using Keys_Onboarding.Global;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Keys_Onboarding.Global.CommonMethods;

namespace Keys_Onboarding.Pages
{
    public class AddNewProperty : Base
    {
        public AddNewProperty()
        {
            PageFactory.InitElements(Global.Driver.driver, this);
        }


        #region  property details WebElements Definition
        // Property details webelements  definition

        //Define property name
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='  Enter property name']")]
        private IWebElement PropertyName { get; set; }

        //Define property type
        [FindsBy(How = How.XPath, Using = ".//*[@id='property-details']/div[2]/div[2]/div")]
        private IWebElement PropertyType { get; set; }

        //Define Search address
        [FindsBy(How = How.XPath, Using = ".//*[@id='autocomplete']")]
        private IWebElement SearchAddress { get; set; }

        //Define Description
        [FindsBy(How = How.XPath, Using = "//textarea[@class='add-prop-desc']")]
        private IWebElement Description { get; set; }

        //Define Number
        [FindsBy(How = How.XPath, Using = ".//*[@id='street_number']")]
        private IWebElement Number { get; set; }

        //Define street
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='  Street']")]
        private IWebElement Street { get; set; }

        //Define Suburb
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='  Suburb']")]
        private IWebElement Suburb { get; set; }

        //Define city
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='  City']")]
        private IWebElement City { get; set; }

        //Define postcode
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='PostCode']")]
        private IWebElement PostCode { get; set; }

        //Define Region
        [FindsBy(How = How.XPath, Using = "//input[@id='region']")]
        private IWebElement Region { get; set; }

        //Define year built
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Year Built']")]
        private IWebElement YearBuilt { get; set; }

        //Define Target Rent
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Rent Amount']")]
        private IWebElement TargetRent { get; set; }

        //Define Rent type
        [FindsBy(How = How.XPath, Using = ".//*[@id='property-details']/div[4]/div/div[2]/div")]
        private IWebElement RentType { get; set; }

        //Define Land Aread
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Land Area']")]
        private IWebElement LandArea { get; set; }

        //Define Floor Area
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Floor Area']")]
        private IWebElement FloorArea { get; set; }

        //Define Bedrooms
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Number of Bedrooms']")]
        private IWebElement BedRooms { get; set; }

        //Define Bathrooms
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Number of Bathrooms']")]
        private IWebElement BathRooms { get; set; }

        //Define car park
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Number of car parks']")]
        private IWebElement CarPark { get; set; }

        //Define owner occupied
        [FindsBy(How = How.XPath, Using = "//input[@data-bind='checked : IsOwnerOccupied']")]
        private IWebElement OwnerOccupied { get; set; }

        //Define Next option in product details section
        [FindsBy(How = How.XPath, Using = ".//*[@id='property-details']/div[10]/div/button[1]")]
        private IWebElement Nextinproduct { get; set; }

        //Define choose file option
        [FindsBy(How = How.XPath, Using = "//input[@class='key-upload']")]
        private IWebElement Choosefile { get; set; }
        #endregion

        #region Finance details webelements definition
        //  finance details webelements definition

        //Define Purchase price
        [FindsBy(How = How.XPath, Using = "//input[@name='purchasePrice']")]
        private IWebElement PurchasePrice { get; set; }

        //Define Mortage
        [FindsBy(How = How.XPath, Using = "//input[@name='mortgagePrice']")]
        private IWebElement Mortage { get; set; }

        ////Define home value
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='  Enter Home Value']")]
        private IWebElement HomeValue { get; set; }

        //Define Home value type
        [FindsBy(How = How.XPath, Using = ".//*[@id='financeSection']/div[1]/div[4]/div")]
        private IWebElement Homevaluetype { get; set; }

        //Define Add repayment button
        [FindsBy(How = How.XPath, Using = "//a[@data-bind='click: addRepayment']")]
        private IWebElement Addrepayment { get; set; }

        //Define Repayments amount
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Repayments']")]
        private IWebElement RepaymentsAmount { get; set; }

        //Define frequency
        [FindsBy(How = How.XPath, Using = "//select[@class='ui selection dropdown full width']")]
        private IWebElement Frequency { get; set; }

        //Define Startdate in finance
        [FindsBy(How = How.XPath, Using = "//input[@id='payment-start-date']")]
        private IWebElement StartDateinfinance { get; set; }

        //Define End date in finance
        [FindsBy(How = How.XPath, Using = "//input[@id='payment-end-date']")]
        private IWebElement EndDateinfinance { get; set; }

        //Define  Add expense
        [FindsBy(How = How.XPath, Using = "//a[@data-bind='click: addExpense']")]
        private IWebElement Addexpense { get; set; }

        //Define Expense Amount
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Expenses']")]
        private IWebElement ExpensesAmount { get; set; }

        //Define Expense Description
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Description']")]
        private IWebElement Expensesdescription { get; set; }

        //Define expenses date
        [FindsBy(How = How.XPath, Using = "//input[@id='expense-date']")]
        private IWebElement Expensesdate { get; set; }

        //Define Next in finance
        [FindsBy(How = How.XPath, Using = ".//*[@id='financeSection']/div[8]/button[3]")]
        private IWebElement NextInfinance { get; set; }

        //Define Save in finance
        [FindsBy(How = How.XPath, Using = ".//*[@id='financeSection']/div[8]/button[2]")]
        private IWebElement SaveInFinance { get; set; }
        #endregion


        #region Tenant Details web elements definition
        //  Tenant details webelements definition
        // Tenant Email
        [FindsBy(How = How.XPath, Using = "//input[@id='email']")]
        private IWebElement TenantEmail { get; set; }

        //Define IsMain tenant
        [FindsBy(How = How.XPath, Using = ".//*[@id='tenantSection']/div[1]/div[2]/div")]
        private IWebElement IsMainTenant { get; set; }

        //Define Firstname
        [FindsBy(How = How.XPath, Using = "//input[@id='fname']")]
        private IWebElement FirstName { get; set; }

        //Define Last Name
        [FindsBy(How = How.XPath, Using = "//input[@id='lname']")]
        private IWebElement LastName { get; set; }

        //Define Start date of tenant
        [FindsBy(How = How.XPath, Using = "//input[@id='sdate']")]
        private IWebElement StartDateintenant { get; set; }

        //Define End date of tenant
        [FindsBy(How = How.XPath, Using = "//input[@id='edate']")]
        private IWebElement EndDateintenant { get; set; }

        //Define Rent amount
        [FindsBy(How = How.XPath, Using = "//input[@id='ramount']")]
        private IWebElement RentAmount { get; set; }

        //Define payment start date
        [FindsBy(How = How.XPath, Using = "//input[@id='psdate']")]
        private IWebElement PaymentStartDate { get; set; }

        //Define payment frequency
        [FindsBy(How = How.XPath, Using = ".//*[@id='tenantSection']/div[1]/div[8]/div")]
        private IWebElement PaymentFrequency { get; set; }

        //Define payment due date
        [FindsBy(How = How.XPath, Using = ".//*[@id='tenantSection']/div[1]/div[10]/div")]
        private IWebElement PaymentDueday { get; set; }

        //Define save
        [FindsBy(How = How.XPath, Using = ".//*[@id='saveProperty']")]
        private IWebElement Save { get; set; }

        //Define Add new liability option
        [FindsBy(How = How.XPath, Using = "//a[@data-bind='click : AddLiabilityValues']")]
        private IWebElement AddNewLiability { get; set; }

        //Define Liability name
        [FindsBy(How = How.XPath, Using = ".//*[@id='LiabilityDetail']/div/div/div[1]/select")]
        private IWebElement Liabilityname { get; set; }

        //Define Liability amount
        [FindsBy(How = How.XPath, Using = "//*[@id='LiabilityDetail']/div/div/div[2]/div/input")]
        private IWebElement LiabilityAmount { get; set; }



        string owneroccupied;

        #endregion

        internal void AddPropertyDetails()
        {

            try
            {
                // Populating the data from Excel
                ExcelLib.PopulateInCollection(Base.ExcelPath, "PropertyDetails");

                PropertyName.SendKeys(ExcelLib.ReadData(2, "PropertyName"));
                //selecting property type from drop down
                string type = ExcelLib.ReadData(2, "PropertyType");
                PropertyType.Click();
                Driver.driver.FindElement(By.XPath(string.Format(".//div[@class='item'][contains(text(),'{0}')]", type))).Click();

                //selecting address from Google API for search address
                SearchAddress.SendKeys(ExcelLib.ReadData(2, "SearchAddress"));
                Global.Driver.WaitForElement(Driver.driver, By.XPath("html/body/div[3]"), 10);
                SearchAddress.SendKeys(Keys.Down);
                SearchAddress.SendKeys(Keys.Enter);

                // Entering property details field value
                Description.SendKeys(ExcelLib.ReadData(2, "Description"));
                Number.SendKeys(ExcelLib.ReadData(2, "Number"));
                RentType.SendKeys(ExcelLib.ReadData(2, "Renttype"));
                TargetRent.SendKeys(ExcelLib.ReadData(2, "TargetRent"));
                LandArea.SendKeys(ExcelLib.ReadData(2, "LandArea"));
                FloorArea.SendKeys(ExcelLib.ReadData(2, "FloorArea"));
                // Choosefile.SendKeys(ExcelLib.ReadData(2, "Choose file"));
                YearBuilt.SendKeys(ExcelLib.ReadData(2, "YearBuilt"));
                BedRooms.SendKeys(ExcelLib.ReadData(2, "Bedrooms"));
                BathRooms.SendKeys(ExcelLib.ReadData(2, "Bathrooms"));
                CarPark.SendKeys(ExcelLib.ReadData(2, "Carparks"));
                owneroccupied = ExcelLib.ReadData(2, "Owner Occupied");

                //owneroccupied option is selected based on input 
                if ((owneroccupied == "Yes") || (owneroccupied == "yes"))
                {

                    if (OwnerOccupied.Enabled)
                    {
                        // Global.Driver.wait(15);
                        OwnerOccupied.Click();
                    }


                }
                Global.Driver.wait(8);
                if (Nextinproduct.Enabled)
                {
                    //Next option is clicked to add tenant
                    Nextinproduct.Click();
                }
                else
                {
                    //wait is used for element to display before clicking
                    Global.Driver.WaitForElement(Driver.driver, By.XPath(".//*[@id='property-details']/div[10]/div/button[1]"), 10);
                    Nextinproduct.Click();
                }


                //Logging result 
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Property details added");

                //To add finance details section 
                AddFinanceDetails();

            }
            catch (Exception e)
            {
                //logging result
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Error in adding property details" + e.Message);
                //screenshots
                String img = SaveScreenShotClass.SaveScreenshot(Driver.driver, "Report");//AddScreenCapture(@"E:\Dropbox\VisualStudio\Projects\Beehive\TestReports\ScreenShots\");
                test.Log(LogStatus.Info, "Image example: " + img);

            }



        }
        void AddFinanceDetails()
        {


            try
            {
                //populating data from excel
                ExcelLib.PopulateInCollection(Base.ExcelPath, "FinanceDetails");

                //Finance details are added
                PurchasePrice.SendKeys(ExcelLib.ReadData(2, "PurchasePrice"));
                Mortage.SendKeys(ExcelLib.ReadData(2, "Mortgage"));
                HomeValue.SendKeys(ExcelLib.ReadData(2, "HomeValue"));
                Homevaluetype.SendKeys(ExcelLib.ReadData(2, "Homevaluetype"));

                //Repayment details are added
                Addrepayment.Click();
                RepaymentsAmount.SendKeys(ExcelLib.ReadData(2, "Amount"));
                Frequency.SendKeys(ExcelLib.ReadData(2, "Frequency"));
                StartDateinfinance.SendKeys(ExcelLib.ReadData(2, "StartDate"));
                EndDateinfinance.SendKeys(ExcelLib.ReadData(2, "EndDate"));
                //Expenses details added
                Addexpense.Click();
                ExpensesAmount.SendKeys(ExcelLib.ReadData(2, "Expenses"));
                Expensesdescription.SendKeys(ExcelLib.ReadData(2, "Description"));
                Expensesdate.SendKeys(ExcelLib.ReadData(2, "Date"));
                // Global.Driver.wait(10);
                if ((owneroccupied == "Yes") || (owneroccupied == "yes"))
                {
                    SaveInFinance.Click();
                    // Logging result
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Finance Details added");

                    
                }
                else
                {
                    NextInfinance.Click();
                    //Logging results
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Finance details added,Need tenant");

                    

                    //To add tenant details
                    AddTenantDetails();
                }


            }
            catch (Exception e)
            {

                //Logging results
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Error in adding Finance details " + e.Message);

                //screenshots
                String img = SaveScreenShotClass.SaveScreenshot(Driver.driver, "Report");//AddScreenCapture(@"E:\Dropbox\VisualStudio\Projects\Beehive\TestReports\ScreenShots\");
                test.Log(LogStatus.Info, "Image example: " + img);

            }
        }

        void AddTenantDetails()
        {

            try
            {
                //populating data from excel
                ExcelLib.PopulateInCollection(Base.ExcelPath, "TenantDetails");
                TenantEmail.SendKeys(ExcelLib.ReadData(2, "TenantEmail"));
                IsMainTenant.SendKeys(ExcelLib.ReadData(2, "Maintenant"));
                FirstName.SendKeys(ExcelLib.ReadData(2, "FirstName"));
                LastName.SendKeys(ExcelLib.ReadData(2, "LastName"));
                StartDateintenant.SendKeys(ExcelLib.ReadData(2, "StartDate"));
                EndDateintenant.SendKeys(ExcelLib.ReadData(2, "EndDate"));
                RentAmount.SendKeys(ExcelLib.ReadData(2, "RentAmount"));
                PaymentStartDate.SendKeys(ExcelLib.ReadData(2, "PaymentStartDate"));
                PaymentFrequency.SendKeys(ExcelLib.ReadData(2, "PaymentFrequency"));
                PaymentDueday.SendKeys(ExcelLib.ReadData(2, "PaymentDueday"));
                AddNewLiability.Click();
                SelectElement Liabilityselect = new SelectElement(Liabilityname);
                string Liabilityoption = ExcelLib.ReadData(2, "Liability");
                Liabilityselect.SelectByText(Liabilityoption);
                LiabilityAmount.SendKeys(ExcelLib.ReadData(2, "Amount"));
                Save.Click();


                //Logging results
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Tenant details added");

                

            }
            catch (Exception e)
            {

                //Logging results
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Error in adding tenant details" + e.Message);

                //screenshots
                String img = SaveScreenShotClass.SaveScreenshot(Driver.driver, "Report");//AddScreenCapture(@"E:\Dropbox\VisualStudio\Projects\Beehive\TestReports\ScreenShots\");
                test.Log(LogStatus.Info, "Image example: " + img);
            }


        }

    }
}

