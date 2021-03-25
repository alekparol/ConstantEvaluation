using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstantEvaluation
{
    public class Wait
    {

        private static string cupLoadingId = "cup_lod";
        private static string pupLoadingId = "pup_lod";



        public void LoadingWait(WebDriverWait wait, string loadingId)
        {
            if (wait != null)
            {
                // Wait for the loading animation to appear and then to disapeear. 
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id(loadingId)));
                wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id(loadingId)));
            }
        }

        public void HomePageLoadingWait(WebDriverWait wait)
        {
            LoadingWait(wait, "cup_lod");
        }

        public void ProfileLoadingWait(WebDriverWait wait)
        {
            LoadingWait(wait, "pup_lod");
        }

        public void ClickableWait(WebDriverWait wait, string xpathLocator)
        {
            // Wait for the button to be displayed. This is the button which is present on all pages to which driver navigate after the click action.
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(xpathLocator)));
        }


        public Wait(WebDriverWait wait, string waitOption)
        {
            switch(waitOption)
            {
                case "LoadingCup":
                    LoadingWait(wait, cupLoadingId);
                    break;
            }
        }
    }
}
