using Keys_Onboarding.Global;
using NUnit.Core;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using RelevantCodes.ExtentReports;
using System;
using System.Threading;
using System.Xml.Linq;
using static Keys_Onboarding.Global.CommonMethods;


namespace Keys_Onboarding
{
    public class PropertyOwner:Base
    {
        public PropertyOwner()
        {
            PageFactory.InitElements(Global.Driver.driver, this);
        }

        #region WebElements Definition
        //Define Owners tab
        [FindsBy(How = How.XPath, Using = "html/body/div[1]/div/div[2]/div[1]")]
        private IWebElement Ownertab { set; get; }

        //Define Properties page
        [FindsBy(How = How.XPath, Using = "html/body/div[1]/div/div[2]/div[1]/div/a[1]")]
        private IWebElement PropertiesPage { set; get; }

        //Define search bar        
        [FindsBy(How = How.XPath, Using = "//input[@name='SearchString']")]
        private IWebElement SearchBar { set; get; }

        //Define search button

        [FindsBy(How = How.XPath, Using = ".//*[@id='icon-submitt']")]
        private IWebElement SearchButton { set; get; }

        //Define Add New property button
        [FindsBy(How = How.XPath, Using = "//a[@href='/PropertyOwners/Property/AddNewProperty']")]
        private IWebElement AddNewProperty { get; set; }

        [FindsBy(How = How.XPath, Using = "html/body/div[5]/div/div[5]/a[1]")]
        private IWebElement Skip{get;set;}
        #endregion

        public void Common_methods()
        {
            Global.Driver.wait(5);

            Skip.Click();

            Thread.Sleep(3000);

            //Click on the Owners tab
            Ownertab.Click();

            //Select properties page
            PropertiesPage.Click();

        }
        public void ClickAddNewProperty()
        { 
            //Select Add New Property
            AddNewProperty.Click();
        }

        internal void SearchAProperty()
        {
            try
            {
                
                Driver.wait(5);
                ExcelLib.PopulateInCollection(Base.ExcelPath, "PropertyDetails");

                //Enter the value in the search bar

                SearchBar.SendKeys(ExcelLib.ReadData(2, "PropertyName"));
                Global.Driver.wait(5);

                //Click on the search button
                SearchButton.Click();
                Driver.wait(5);

                string ExpectedValue = ExcelLib.ReadData(2, "PropertyName");
                string ActualValue = Global.Driver.driver.FindElement(By.XPath(".//*[@id='main-content']/section/div[1]/div/div[3]/div/div[1]/div[2]/div[1]/div[1]/a/h3")).Text;
                
               Base.extent = new ExtentReports(Base.ReportPath, true, DisplayOrder.NewestFirst);

               Base.test = Base.extent.StartTest("Add new property" ,"Adding property details");

                if (ExpectedValue == ActualValue)
                                    
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Test Passed, Search successfull");
                
                else
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Test Failed, Search Unsuccessfull");

            }

            catch(Exception e)
            {
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Test Failed, Search Unsuccessfull",e.Message);
            }

            extent.EndTest(test);
            extent.Flush();
         }
    }
}