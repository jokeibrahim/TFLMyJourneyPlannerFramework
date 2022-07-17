using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TFLMyJourneyPlannerFramework.Hooks
{
   public class Context
    {
       public IWebDriver driver;
       public string baseUrl = "https://tfl.gov.uk/plan-a-journey/";

        public void LaunchAnApplication()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(baseUrl);
            Thread.Sleep(2000);

        }

        public void CloseAnApplication()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}
