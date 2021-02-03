using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUI.Test
{
    class HomePage
    {
        const string homePageUrl = "https://betway.com/";
        const string homeTitle = "Betway: Official Website";
        const string sportsHomeTitle = "Online Betting Site | Sports Betting | Betway";
        const string sportsUrl = "https://sports.betway.com/en/sports";
        private readonly IWebDriver Driver;

        public HomePage(IWebDriver driver)
        {
            Driver = driver;
        }
        public void NavigateTo()
        {

            Driver.Navigate().GoToUrl(homePageUrl);
        
        
        }

        private void EnsureOPageLoaded()
        {
            bool pageLoaded = (Driver.Url == homePageUrl) && (Driver.Title == homeTitle);

            if (!pageLoaded)
            { 
               
                 
            
            }
        
        
        }


        //public ReadOnlyCollection<(string name,string link)> QuickLinks
        //{
        //    get
        //    {
        //        var quiclLinks = new List<(string name, string link)>();
        //        var linkRows = Driver.FindElement(By.ClassName("promotionListItems"));
        //        for ( int i = 0 ; i < linkRows.Count - 1;i +=)
        //        {

        //            string name = linkRows[i].Text;
        //            quiclLinks.Add(name);

                
        //        }
        //    }return QuickLinks.AsReadOnly();
        //}
    }
}
