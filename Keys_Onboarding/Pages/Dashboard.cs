using Keys_Onboarding.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keys_Onboarding.Pages
{
    public class Dashboard : Base
    {
        public Dashboard()
        {
            PageFactory.InitElements(Global.Driver.driver, this);
        }

      
        #region webelements definition

        //Define Properties occupied 
        [FindsBy(How = How.XPath, Using = ".//*[@id='prop-chart-legends']/ul/li[1]")]
        private IWebElement Propertiesoccupied{get;set;}

        //Define Properties vacant
        [FindsBy(How = How.XPath, Using = ".//*[@id='prop-chart-legends']/ul/li[2]")]
        private IWebElement Propertiesvacant { get; set; }

        //Define Dashboard link 
        [FindsBy(How =How.XPath,Using = "html/body/div[1]/div/div[2]/a[1]")]
        private IWebElement Dashboardlink { get; set; }

        //Define Skip
        [FindsBy(How = How.XPath, Using = "html/body/div[5]/div/div[5]/a[1]")]
        private IWebElement Skip { get; set; }

        #endregion
        internal int Propertiescount()
        {
            // Dashboardlink.Click();
            Skip.Click();
            Dashboardlink.Click();

            //Total number of owner's properties is calculated
            string poc = Propertiesoccupied.Text;
            string pvc = Propertiesvacant.Text;     
            string[] separator = { " " };
            string[] Poclist = poc.Split(separator,StringSplitOptions.RemoveEmptyEntries);
            string[] Pvclist = pvc.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            ArrayList Listpoc = new ArrayList();
            ArrayList Listpvc = new ArrayList();
            foreach (var pocs in Poclist)
            {
                               
                Listpoc.Add(pocs);
            }

            foreach(var pvcs in Pvclist)
            {
                Listpvc.Add(pvcs);
            }
            string countoccupied = (string)Listpoc[0];
            string countvacant =(string) Listpvc[0];
            int coccupied =int.Parse(countoccupied);
            int cvaccant = int.Parse(countvacant);
            int total = coccupied + cvaccant;

            return total;
        }

    }
}
