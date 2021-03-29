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

        public void ClickableTasks(WebDriverWait wait)
        {
            ClickableWait(wait, "//*[@id=\"tasks\"]");
        }

        public void ClickableButton(WebDriverWait wait)
        {
            ClickableWait(wait, "//*[@class='hdr_sub_sel tlp_on']");
        }

        public void ClickableProjects(WebDriverWait wait)
        {
            ClickableWait(wait, "//*[@class=\"dsh_tds_ttl\"]");
        }

        public void InvisibilityOfElement(WebDriverWait wait, string xpathLocator)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(xpathLocator)));
        }

        public void InivisilibityOfMenu(WebDriverWait wait)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[contains(@class,\"m1 lay_flt\"])")));
        }

        public void VisibilityOfElement(WebDriverWait wait, string xpathLocator)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(xpathLocator)));
        }

        public void FilterVisible(WebDriverWait wait)
        {
            VisibilityOfElement(wait, "cup_lf");
        }

        public void LoggedUserMenuVisible(WebDriverWait wait)
        {
            VisibilityOfElement(wait, "//*[@id=\"usr_act\" and contains(@class,\"lay_fit\")]");
        }


        public void LeftMenuWait(WebDriverWait wait)
        {
            // Wait for the loading animation to appear and then to disapeear. 
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("cup_lod")));
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("cup_lod")));

            // Wait for the button to be displayed. This is the button which is present on all pages to which driver navigate after the click action.
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@class='hdr_sub_sel tlp_on']")));
        }

        public Wait(WebDriverWait wait, string waitOption)
        {
            switch(waitOption)
            {
                case "LoadingCup":
                    LoadingWait(wait, cupLoadingId);
                    break;
                case "ProjectsListReady":
                    ClickableProjects(wait);
                    break;
                case "ProjectHomePage":
                    ClickableTasks(wait);
                    break;
                case "ProjectHomePageButtonClick":
                    LeftMenuWait(wait);
                    break;
                case "LoggedUserClicked":
                    LoggedUserMenuVisible(wait);
                    break;
            }
        }
    }
}
