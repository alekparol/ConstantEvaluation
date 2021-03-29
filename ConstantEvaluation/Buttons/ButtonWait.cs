using ConstantEvaluation.Waits;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstantEvaluation.Buttons
{
    public class ButtonWait
    {
        /* Static Variables */ 

        private static string cupLoadingId = "cup_lod";
        private static string pupLoadingId = "pup_lod";
        private static string tasksButton = "//*[@id=\"tasks\"]";
        private static string projectLists = "//*[@class=\"dsh_tds_ttl\"]";
        private static string menuContainer = "//div[contains(@class,\"m1 lay_flt\"])";
        private static string loggedUserContainer = "//*[@id=\"usr_act\" and contains(@class,\"lay_fit\")]";
        private static string filterContainer = "cup_lf";
        private static string pagePanelButton = "//*[@class='hdr_sub_sel tlp_on']";


        /* Wait Base Functions */

        /* 1. Loading Base Function */

        public void LoadingWait(WebDriverWait wait, string loadingId)
        {
            if (wait != null)
            {
                // Wait for the loading animation to appear and then to disapeear. 
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id(loadingId)));
                wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id(loadingId)));
            }
        }

        /* 2. Clickable Base Function */

        public void ClickableWait(WebDriverWait wait, string xpathLocator)
        {
            // Wait for the button to be displayed. This is the button which is present on all pages to which driver navigate after the click action.
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(xpathLocator)));
        }

        /* 3. Inivisibility Function */
        public void InvisibilityOfElement(WebDriverWait wait, string xpathLocator)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(xpathLocator)));
        }

        /* 4. Visibility Function */

        public void VisibilityOfElement(WebDriverWait wait, string xpathLocator)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(xpathLocator)));
        }

        /* 1.1. Loading Functions */

        public void HomePageLoadingWait(WebDriverWait wait)
        {
            LoadingWait(wait, cupLoadingId);
        }

        public void ProfileLoadingWait(WebDriverWait wait)
        {
            LoadingWait(wait, pupLoadingId);
        }

        /* 2.1. Clickable Functions */ 

        public void ClickableTasks(WebDriverWait wait)
        {
            ClickableWait(wait, tasksButton);
        }

        public void ClickableProjects(WebDriverWait wait)
        {
            ClickableWait(wait, projectLists);
        }

        /* 3.1. Invisibility Functions */

        public void InivisilibityOfMenu(WebDriverWait wait)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(menuContainer)));
        }

        /* 4.1. Visibility Functions */

        public void FilterVisible(WebDriverWait wait)
        {
            VisibilityOfElement(wait, filterContainer);
        }

        public void LoggedUserMenuVisible(WebDriverWait wait)
        {
            VisibilityOfElement(wait, loggedUserContainer);
        }

        /* Main Wait Function */

        /*public void WaitTill (WebDriverWait wait, ButtonWaitEnum waitOption)
        {
            switch (waitOption)
            {
                case ButtonWaitEnum.LoadingPageWait:
                    LoadingWait(wait, cupLoadingId);
                    break;
                case "ProjectsListReady":
                    ClickableProjects(wait);
                    break;
                case "ProjectHomePage":
                    ClickableTasks(wait);
                    break;
                case "ProjectHomePageButtonClick":
                    LoadingWait(wait, cupLoadingId);
                    ClickableTasks(wait);
                    break;
                case "LoggedUserClicked":
                    LoggedUserMenuVisible(wait);
                    break;
            }
        }*/

        public ButtonWait()
        {

        }
    }
}
