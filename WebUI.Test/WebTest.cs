using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace WebUI.Test
{
    public class WebTest
    {
        const string homePageUrl = "https://betway.com/";
        const string homeTitle = "Betway: Official Website";
        const string sportsHomeTitle = "Online Betting Site | Sports Betting | Betway";
        const string sportsUrl = "https://sports.betway.com/en/sports";

        [Fact]
        public void LoadHomePage()
        {

            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl(homePageUrl);
                driver.Manage().Window.Maximize();

                DemoHelper.Pause();

                string pageTitle = driver.Title;
                Assert.Equal(homeTitle, pageTitle);
                Assert.Equal(homePageUrl, driver.Url);


            }

        }
        [Fact]
        [Trait("Category", "Smoke")]
        public void ReloadHomePage()
        {

            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl(homePageUrl);
                driver.Manage().Window.Maximize();
                driver.Navigate().Refresh();
                DemoHelper.Pause();
                string pageTitle = driver.Title;

                Assert.Equal(homeTitle, pageTitle);
                Assert.Equal(homePageUrl, driver.Url);


            }
        }
        [Fact]
        [Trait("Category", "Smoke")]
        public void ReloadHomePageBack()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl(homePageUrl);
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl(sportsUrl);
                DemoHelper.Pause();
                driver.Navigate().Back();
                DemoHelper.Pause();



                string pageTitle = driver.Title;
                Assert.Equal(homeTitle, pageTitle);
                Assert.Equal(homePageUrl, driver.Url);

            }
        }

        [Fact]
        [Trait("Category", "Smoke")]
        public void ReloadHomePageForward()
        {
            using (IWebDriver driver = new ChromeDriver())
            {

                driver.Navigate().GoToUrl(sportsUrl);
                DemoHelper.Pause();

                driver.Navigate().GoToUrl(homePageUrl);
                DemoHelper.Pause();

                driver.Navigate().Forward();
                DemoHelper.Pause();

                string pageTitle = driver.Title;
                Assert.Equal(sportsHomeTitle, pageTitle);
                Assert.Equal(sportsUrl, driver.Url);

            }

        }
        [Fact]
        public void InitiatingSports()
        {
            using (IWebDriver driver = new ChromeDriver())
            {


                driver.Navigate().GoToUrl(homePageUrl);
                driver.Manage().Window.Maximize();
                DemoHelper.Pause();
                var sportsLink = driver.FindElement(By.LinkText("sports"));
                string sportsText = sportsLink.Text;

                DemoHelper.Pause();
                driver.FindElement(By.LinkText("sports")).Click();


                DemoHelper.Pause();


                string pageTitle = driver.Title;
                Assert.Equal("sports", sportsText);
                Assert.Equal(sportsHomeTitle, pageTitle);
                Assert.Equal(sportsUrl, driver.Url);

            }

        }
        [Fact]
        public void NavigatearoundSportsPage()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl(homePageUrl);
                driver.Manage().Window.Maximize();
                DemoHelper.Pause();
                driver.FindElement(By.CssSelector("[type = 'submit']")).Click();
                DemoHelper.Pause();
                var sportsLink = driver.FindElement(By.LinkText("sports"));
                string sportsText = sportsLink.Text;

                DemoHelper.Pause();

                driver.FindElement(By.LinkText("sports")).Click();
                DemoHelper.Pause();
                // driver.FindElement(By.ClassName("icon-cross"));

                driver.FindElement(By.CssSelector("[placeholder='Username']")).SendKeys("neha_sabikhi");
                driver.FindElement(By.CssSelector("[placeholder='Password']")).SendKeys("123456");

                DemoHelper.Pause();

                driver.FindElement(By.ClassName("cookiePolicyAcceptButton")).Click();
                DemoHelper.Pause(3);
                driver.FindElement(By.ClassName("submitButton")).Click();




                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));


                driver.FindElement(By.ClassName("Carousel_next")).Click();



                driver.FindElement(By.LinkText("esports")).Click();




            }



        }
        [Fact]
        [Trait("Category", "Smoke")]
        public void multipleElements()
        {

            using (IWebDriver driver = new ChromeDriver())
            {


                driver.Navigate().GoToUrl(homePageUrl);
                driver.Manage().Window.Maximize();
                DemoHelper.Pause();
          
                driver.FindElement(By.LinkText("sports")).Click();

                DemoHelper.Pause();
                ReadOnlyCollection<IWebElement> quickLinks = driver.FindElements(By.ClassName("promotionListItems"));

                Assert.Equal("Responsible Gambling",quickLinks[0].Text);
                Assert.Equal("Daily Football Matches", quickLinks[1].Text);





            }
        }

        [Fact]
        [Trait("Category", "Smoke")]
        public void RegisterUser()
        {

            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl(homePageUrl);
                driver.Manage().Window.Maximize();
                DemoHelper.Pause();
               
                //var sportsLink = driver.FindElement(By.LinkText("sports"));
                driver.FindElement(By.CssSelector("[aria-label='Sign up']")).Click();

                DemoHelper.Pause();

                driver.FindElement(By.Id("Comp1_Title")).Click();

                driver.FindElement(By.CssSelector("[value='Mrs']")).Click();

                
                    driver.FindElement(By.Id("Comp2_FirstName")).SendKeys("Jane");
                DemoHelper.Pause();
                driver.FindElement(By.Id("Comp3_Surname")).SendKeys("Brown");
                DemoHelper.Pause();
                DemoHelper.Pause();
                driver.FindElement(By.CssSelector("[value = '1992']")).Click();
               
                driver.FindElement(By.Id("Comp4_DateDropdownMonth")).Click();
                DemoHelper.Pause();
                driver.FindElement(By.CssSelector("[value = '3']")).Click();

              //  var dateMonth = driver.FindElement(By.Id("Comp4_DateDropdownMonth"));
                    
              //  var month = new SelectElement(dateMonth);
              //  Assert.Equal("03", dateMonth);

              //foreach(IWebDriver Option in dateMonth.Options)


                //driver.FindElement(By.Id("Comp4_DateDropdownValue")).Click();
                //driver.FindElement(By.CssSelector("[value = '28']")).Click();



                driver.FindElement(By.Id("Comp15_OptInBonus")).Click();
                driver.FindElement(By.Id("Comp16_TermsAndConditions")).Click();




            }

        }
    }

}