using Keys_Onboarding.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Keys_Onboarding.Global.CommonMethods;

namespace Keys_Onboarding.Pages
{
    public class AddNewProperty
    {
        public AddNewProperty()
        {
            PageFactory.InitElements(Global.Driver.driver, this);
        }
        #region WebElements Definition

        [FindsBy(How = How.XPath, Using = ".//*[@id='property-details']/div[1]/div[1]/div[1]/input")]
        IWebElement PropertyName { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='property-details']/div[1]/div[2]/div")]
        IWebElement PropertyType { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='autocomplete']")]
        IWebElement SearchAddress { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='property-details']/div[2]/div[2]/div/div/div[1]/textarea")]
        IWebElement Description { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='street_number']")]
        IWebElement Number { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@placeholder='  Street']")]
        IWebElement Street { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@placeholder='  Suburb']")]
        IWebElement Suburb { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@placeholder='  City']")]
        IWebElement City { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@placeholder='PostCode']")]
        IWebElement PostCode { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='region']")]
        IWebElement Region { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Year Built']")]
        IWebElement YearBuilt { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Rent Amount']")]
        IWebElement TargetRent { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='property-details']/div[3]/div[2]/div/div[2]/div")]
        IWebElement RentType { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Land Area']")]
        IWebElement LandArea { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Floor Area']")]
        IWebElement FloorArea { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Number of Bedrooms']")]
        IWebElement BedRooms { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Number of Bathrooms']")]
        IWebElement BathRooms { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Number of car parks']")]
        IWebElement CarPark { get; set; }

        [FindsBy(How =How.XPath,Using = ".//*[@id='property-details']/div[4]/div[6]/input")]
        IWebElement OwnerOccupied { get; set; }
        
        [FindsBy(How = How.XPath, Using = ".//*[@id='property-details']/div[7]/button[1]")]
        IWebElement Next { get; set; }

        [FindsBy(How= How.XPath,Using="//input[@name='purchasePrice']")]
        IWebElement PurchasePrice { get; set; }


        [FindsBy(How =How.XPath,Using = "//input[@name='mortgagePrice']")]
        IWebElement Mortage { get; set; }

        [FindsBy(How =How.XPath,Using = "//input[@placeholder='  Enter Home Value']")]
        IWebElement HomeValue { get; set; }

        [FindsBy(How =How.XPath,Using = ".//*[@id='financeSection']/div[8]/button[3]")]
        IWebElement NextInfinance { get; set; }

        [FindsBy(How =How.XPath,Using = ".//*[@id='financeSection']/div[8]/button[2]")]
        IWebElement SaveInFinance { get; set; }

        [FindsBy(How =How.XPath,Using = "//input[@id='email']")]
        IWebElement TenantEmail { get; set; }

        [FindsBy(How=How.XPath,Using = ".//*[@id='tenantSection']/div[1]/div[2]/div")]
        IWebElement IsMainTenant { get; set; }

        [FindsBy(How =How.XPath,Using = "//input[@id='fname']")]
        IWebElement FirstName { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='lname']")]
        IWebElement LastName { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='sdate']")]
        IWebElement StartDate{ get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='edate']")]
        IWebElement EndDate { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='ramount']")]
        IWebElement RentAmount { get; set; }

        [FindsBy(How=How.XPath,Using = "//input[@id='psdate']")]
        IWebElement PaymentStartDate { get; set; }

        [FindsBy(How =How.XPath,Using = ".//*[@id='saveProperty']")]
        IWebElement Save { get; set; }

        string owneroccupied;

        #endregion
        PropertyOwner obj = new PropertyOwner();
        public void AddPropertyDetails()
        {

            

                obj.ClickAddNewProperty();

                // Populating the data from Excel
                ExcelLib.PopulateInCollection(Base.ExcelPath, "PropertyDetails");

                PropertyName.SendKeys(ExcelLib.ReadData(2, "PropertyName"));
                SearchAddress.SendKeys(ExcelLib.ReadData(2, "SearchAddress"));
                Description.SendKeys(ExcelLib.ReadData(2, "Description"));
                Number.SendKeys(ExcelLib.ReadData(2, "Number"));
                Street.SendKeys(ExcelLib.ReadData(2, "Street"));
                Suburb.SendKeys(ExcelLib.ReadData(2, "Suburb"));
                City.SendKeys(ExcelLib.ReadData(2, "City"));
                PostCode.SendKeys(ExcelLib.ReadData(2, "PostCode"));
                Region.SendKeys(ExcelLib.ReadData(2, "Region"));
                YearBuilt.SendKeys(ExcelLib.ReadData(2, "YearBuilt"));
                TargetRent.SendKeys(ExcelLib.ReadData(2, "TargetRent"));
                LandArea.SendKeys(ExcelLib.ReadData(2, "LandArea"));
                FloorArea.SendKeys(ExcelLib.ReadData(2, "FloorArea"));
                BedRooms.SendKeys(ExcelLib.ReadData(2, "Bedrooms"));
                BathRooms.SendKeys(ExcelLib.ReadData(2, "Bathrooms"));
                CarPark.SendKeys(ExcelLib.ReadData(2, "Carparks"));
                owneroccupied = ExcelLib.ReadData(2, "Owner Occupied");
                if(owneroccupied=="Yes")
                {
                OwnerOccupied.Click();

                }


                Next.Click();
                AddFinanceDetails();
            

        }
          void AddFinanceDetails()
        {

            ExcelLib.PopulateInCollection(Base.ExcelPath, "FinanceDetails");

            PurchasePrice.SendKeys(ExcelLib.ReadData(2, "PurchasePrice"));
            Mortage.SendKeys(ExcelLib.ReadData(2, "Mortgage"));
            HomeValue.SendKeys(ExcelLib.ReadData(2, "HomeValue"));
            if (owneroccupied == "Yes")
            {
                SaveInFinance.Click();
            }
            else
            {
                NextInfinance.Click();
                AddTenantDetails();
            }

        }

        void AddTenantDetails()
        {
            ExcelLib.PopulateInCollection(Base.ExcelPath, "TenantDetails");

            TenantEmail.SendKeys(ExcelLib.ReadData(2, "TenantEmail"));
            FirstName.SendKeys(ExcelLib.ReadData(2, "FirstName"));
            LastName.SendKeys(ExcelLib.ReadData(2, "LastName"));
            StartDate.SendKeys(ExcelLib.ReadData(2, "StartDate"));
            EndDate.SendKeys(ExcelLib.ReadData(2, "EndDate"));
            RentAmount.SendKeys(ExcelLib.ReadData(2, "RentAmount"));
            PaymentStartDate.SendKeys(ExcelLib.ReadData(2, "PaymentStartDate"));
            Save.Click();
            //obj.SearchAProperty();

        
    
         }


    }
}
