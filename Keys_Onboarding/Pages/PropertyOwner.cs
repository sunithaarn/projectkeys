using Keys_Onboarding.Global;
using Keys_Onboarding.Pages;
using NUnit.Core;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using RelevantCodes.ExtentReports;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Xml.Linq;
using static Keys_Onboarding.Global.CommonMethods;


namespace Keys_Onboarding
{
    public class PropertyOwner : Base
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

        //Define skip button
        [FindsBy(How = How.XPath, Using = "html/body/div[5]/div/div[5]/a[1]")]
        private IWebElement Skip { get; set; }
        
        //Define List a Rental button
        [FindsBy(How = How.XPath, Using = "//a[@href='/PropertyOwners/Property/ListRental?propId=-1']")]
        private IWebElement ListaRental { get; set; }

        //Define  Add tenant button
        [FindsBy(How = How.XPath, Using = ".//*[@id='main-content']/section/div[1]/div/div[3]/div/div[1]/div/div/div[2]/div[2]/div/a[1]")]
        private IWebElement Addtenant { get; set; }
        
        //Define the option that is present at the right side of each property
        [FindsBy(How = How.XPath, Using = ".//*[@id='main-content']/section/div[1]/div/div[3]/div/div/div/div/div[2]/div[1]/div[3]/div/i")]
        private IWebElement Editoption { get; set; }

        //Define Manage tenant option
        [FindsBy(How = How.XPath, Using = ".//*[@id='main-content']/section/div[1]/div/div[3]/div/div/div/div/div[2]/div[1]/div[3]/div/div/div[3]")]
        private IWebElement Managetenant { get; set; }

        //Define sort by option
        [FindsBy(How = How.XPath, Using = ".//*[@id='main-content']/section/div[1]/div/div[2]/div/div[1]/div/div")]
        private IWebElement Sortby { get; set; }

        //Define Nextpage button
        [FindsBy(How = How.XPath, Using = "//a[@rel='next']")]
        private IWebElement Nextpage { get; set; }


        #endregion
        #region common methods
        public void Common_methods()
        {
            Global.Driver.wait(5);
            //Click on skip button
            Skip.Click();

            Thread.Sleep(3000);

            //Click on the Owners tab
            Ownertab.Click();

            //Select properties page
            PropertiesPage.Click();

        }
        #endregion

        public void ClickAddNewProperty()
        {
            //Select Add New Property
            AddNewProperty.Click();
        }
        #region  Add new property 
        internal string SearchAProperty()
        {
            try
            {


                Driver.wait(5);
                ExcelLib.PopulateInCollection(Base.ExcelPath, "PropertyDetails");

                //Enter the value in the search bar
                SearchBar.Clear();
                string ExpectedPropertyname = ExcelLib.ReadData(2, "PropertyName");
                SearchBar.SendKeys(ExpectedPropertyname);
              
                //Click on the search button
                SearchButton.Click();
                Driver.wait(5);

               // Read the property name after search
                string ActualPropertyName = Global.Driver.driver.FindElement(By.XPath(".//*[@id='main-content']/section/div[1]/div/div[3]/div/div/div/div/div[2]/div[1]/div[1]/a/h3")).Text;
                
                // verification part
                if (ExpectedPropertyname == ActualPropertyName)
                {
                    //Logging test results  into extentreports
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Test Passed, Search successfull");

                    //screenshots
                    String img = SaveScreenShotClass.SaveScreenshot(Driver.driver, "Report");//AddScreenCapture(@"E:\Dropbox\VisualStudio\Projects\Beehive\TestReports\ScreenShots\");
                    test.Log(LogStatus.Info, "Image example: " + img);

                    //returns'pass' once test passes
                    return "Pass";
                }


                else
                {
                    //logging test results
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Test Failed, Search Unsuccessfull");
                    // screenshots
                    String img = SaveScreenShotClass.SaveScreenshot(Driver.driver, "Report");//AddScreenCapture(@"E:\Dropbox\VisualStudio\Projects\Beehive\TestReports\ScreenShots\");
                    test.Log(LogStatus.Info, "Image example: " + img);
                    return "Fail";
                }

               
            }
            catch(Exception e)
            {
                //logging the test results
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Error in Searching " + e.Message);
                // screenshots
                String img = SaveScreenShotClass.SaveScreenshot(Driver.driver, "Report");//AddScreenCapture(@"E:\Dropbox\VisualStudio\Projects\Beehive\TestReports\ScreenShots\");
                test.Log(LogStatus.Info, "Image example: " + img);
                return "Fail";
            }

        }
        #endregion
        #region List property for rent 

        internal void ClickListaRental()
        {

            try
            {
                //List a rental option is selected
                ListaRental.Click();
                                
            }
            catch (Exception e)
            {
                //logging the results
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Not able to click option List a Rental" + e.Message);
               
                //screenshots
                String img = SaveScreenShotClass.SaveScreenshot(Driver.driver, "Report");//AddScreenCapture(@"E:\Dropbox\VisualStudio\Projects\Beehive\TestReports\ScreenShots\");
                test.Log(LogStatus.Info, "Image example: " + img);
            }

        }

        #endregion

        #region Add Tenant

        internal void ClickAddTenant()
        {

            try
            {
                //Add tenant option is selected
                Addtenant.Click();
                
            }

            catch (Exception e)
            {

                //logging the test result
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Not able to click Add Tenant" + e.Message);
                
                //screenshots
                String img = SaveScreenShotClass.SaveScreenshot(Driver.driver, "Report");//AddScreenCapture(@"E:\Dropbox\VisualStudio\Projects\Beehive\TestReports\ScreenShots\");
                test.Log(LogStatus.Info, "Image example: " + img);
            }
        }

       
  
        internal void Clickeditoptions()
        {

            try
            {
                //Manage tenant option is selected
                Editoption.Click();
                Global.Driver.WaitForElement(Driver.driver, By.XPath(".//*[@id='main-content']/section/div[1]/div/div[3]/div/div/div/div/div[2]/div[1]/div[3]/div/div/div[3]"), 8);
                Managetenant.Click();
                
            }
            catch (Exception e)
            {
                //logging the results
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Error in clicking in Edit options" + e.Message);

                //screenshots
                String img = SaveScreenShotClass.SaveScreenshot(Driver.driver, "Report");//AddScreenCapture(@"E:\Dropbox\VisualStudio\Projects\Beehive\TestReports\ScreenShots\");
                test.Log(LogStatus.Info, "Image example: " + img);
            }

        }
        #endregion
        #region sort properties
        //lists are created to read the properties
        List<string> Propertynamelist = new List<string>();
        List<string> actualpropertylist = new List<string>();
        List<string> sortedlist = new List<string>();
        List<string> actualpropertylistreverse = new List<string>();
        List<string> sortedlistreverse = new List<string>();

        internal void Getpropertyname(int count)
        {

            
            Ownertab.Click();
            PropertiesPage.Click();
            int k=1;
            int j=1;
            while (k <= count)
            {

                if (j <= 10)
                {
                    k++;
                    string Property = Driver.driver.FindElement(By.XPath(".//*[@id='main-content']/section/div[1]/div/div[3]/div/div[" + j + "]/div/div/div[2]/div[1]/div[1]/a/h3")).Text;
                    //Displayed properties are added to the list
                    Propertynamelist.Add(Property);
                    j++;
                }
                else
                {
                    
                    if (Nextpage.Displayed)
                    {
                        Nextpage.Click();
                        j = 1;
                    }
                    else
                    {
                        break;
                    }
                }

            }
           
        }


        internal void Sortbyoptions(int count)
        {
            
            int k = 1;
            int j = 1;

            //Populating excel data 
            ExcelLib.PopulateInCollection(Base.ExcelPath, "Sortby");                    
            string option = ExcelLib.ReadData(2, "By");
            //sort by option is selected based on the input
            Sortby.Click();
            if (option == "Name")
            {
                Driver.driver.FindElement(By.XPath("//*[@id='main-content']/section/div[1]/div/div[2]/div/div[1]/div/div/div[2]/div[1]")).Click();
                
                //properties are read after sorting 
                while (k <= count)
                {
                    
                    if (j <= 10)
                    {
                        k++;
                        string Property = Driver.driver.FindElement(By.XPath(".//*[@id='main-content']/section/div[1]/div/div[3]/div/div[" + j + "]/div/div/div[2]/div[1]/div[1]/a/h3")).Text;
                        actualpropertylist.Add(Property);
                        j++;
                    }
                    else
                    {
                        if (Nextpage.Displayed)
                        {
                            Nextpage.Click();
                            j = 1;
                        }
                        else
                        {
                            break;
                        }
                    }

                }
                // All properties are sorted in ascending
                Propertynamelist.Sort();
                foreach (string value in Propertynamelist)
                {

                    sortedlist.Add(value);
                }
                //verification 
                if (actualpropertylist.SequenceEqual(sortedlist))
                {

                    //logging test results
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Sort by name works as expected");
                    //screenshots
                    String img = SaveScreenShotClass.SaveScreenshot(Driver.driver, "Report");//AddScreenCapture(@"E:\Dropbox\VisualStudio\Projects\Beehive\TestReports\ScreenShots\");
                    test.Log(LogStatus.Info, "Image example: " + img);
                }
                else
                {
                    //logging test results
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Sort by name fail");
                    //screenshots
                    String img = SaveScreenShotClass.SaveScreenshot(Driver.driver, "Report");//AddScreenCapture(@"E:\Dropbox\VisualStudio\Projects\Beehive\TestReports\ScreenShots\");
                    test.Log(LogStatus.Info, "Image example: " + img);
                }
            }
            else if (option == "Name(Desc)")
            {
                Driver.driver.FindElement(By.XPath(".//*[@id='main-content']/section/div[1]/div/div[2]/div/div[1]/div/div/div[2]/div[2]")).Click();
                // Properties are read after sorting
                while (k <= count)
                {
                    if (j <= 10)
                    {
                        k++;
                        string Propertyname = Driver.driver.FindElement(By.XPath(".//*[@id='main-content']/section/div[1]/div/div[3]/div/div[" + j + "]/div/div/div[2]/div[1]/div[1]/a/h3")).Text;
                        actualpropertylistreverse.Add(Propertyname);
                        j++;
                    }
                    else
                    {
                        if (Nextpage.Displayed)
                        {
                            Nextpage.Click();
                            j = 1;
                        }
                        else
                        {
                            break;
                        }
                    }

                }
                //reverse sorting is done
                Propertynamelist.Sort();
                Propertynamelist.Reverse();
                foreach (string value in Propertynamelist)
                {

                    sortedlistreverse.Add(value);

                }
                //verification
                if (actualpropertylistreverse.SequenceEqual(sortedlistreverse))
                {
                    //logging results
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Sort by name(desc) works as expected");
                    //screenshots
                    String img = SaveScreenShotClass.SaveScreenshot(Driver.driver, "Report");//AddScreenCapture(@"E:\Dropbox\VisualStudio\Projects\Beehive\TestReports\ScreenShots\");
                    test.Log(LogStatus.Info, "Image example: " + img);
                }
                else
                {
                    //logging results
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Sort by name(desc) fail");
                    //screenshots
                    String img = SaveScreenShotClass.SaveScreenshot(Driver.driver, "Report");//AddScreenCapture(@"E:\Dropbox\VisualStudio\Projects\Beehive\TestReports\ScreenShots\");
                    test.Log(LogStatus.Info, "Image example: " + img);
                }
            }
            else if (option == "Earliest Date")
            {
                Driver.driver.FindElement(By.XPath(".//*[@id='main-content']/section/div[1]/div/div[2]/div/div[1]/div/div/div[2]/div[4]")).Click();

            }
        
         }

         #endregion
    }

}
         
            
  



               

