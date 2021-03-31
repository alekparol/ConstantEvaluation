using ConstantEvaluation.Waits;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConstantEvaluation.Buttons.XPathLocators;

namespace ConstantEvaluation.Buttons
{
    public class ButtonWait
    {

        /* Fields */

        private WebDriverWait wait;
        private ButtonWaitEnum waitOption;

        /* Properties */

        /* Methods */

        /* Wait Base Functions */

        /* 1. Loading Base Function */

        /// <summary> Wait for the loading animation to appear and then to disapeear. 
        /// </summary>
        /// <param name="wait"></param>
        /// <param name="xpathLocator"></param>
        public void LoadingWait(WebDriverWait wait, string xpathLocator)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xpathLocator)));
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(xpathLocator)));
        }

        /* 2. Clickable Base Function */

        /// <summary> Wait for the button to be displayed. This is the button which is present on all pages to which driver navigate after the click action.
        /// </summary>
        /// <param name="wait"></param>
        /// <param name="xpathLocator"></param>
        public void ClickableWait(WebDriverWait wait, string xpathLocator)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(xpathLocator)));
        }

        /* 3. Inivisibility Function */
        /// <summary> Wait for the button to be displayed. This is the button which is present on all pages to which driver navigate after the click action.
        /// </summary>
        /// <param name="wait"></param>
        /// <param name="xpathLocator"></param>
        public void InvisibilityOfElement(WebDriverWait wait, string xpathLocator)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(xpathLocator)));
        }

        /* 4. Visibility Function */
        /// <summary> Wait for the button to be displayed. This is the button which is present on all pages to which driver navigate after the click action.
        /// </summary>
        /// <param name="wait"></param>
        /// <param name="xpathLocator"></param>
        public void VisibilityOfElement(WebDriverWait wait, string xpathLocator)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(xpathLocator)));
        }

        /* 1.1. Loading Functions */

        public void HomePageLoadingWait(WebDriverWait wait)
        {
            LoadingWait(wait, CupLoading);
        }

        public void ProfileLoadingWait(WebDriverWait wait)
        {
            LoadingWait(wait, PupLoading);
        }

        /* 2.1. Clickable Functions */ 

        public void ClickableTasks(WebDriverWait wait)
        {
            ClickableWait(wait, TasksButton);
        }

        public void ClickableProjects(WebDriverWait wait)
        {
            ClickableWait(wait, ProjectLists);
        }

        /* 3.1. Invisibility Functions */

        public void InivisilibityOfMenu(WebDriverWait wait)
        {
            InvisibilityOfElement(wait, ItemMenu);
        }

        /* 4.1. Visibility Functions */

        public void FilterVisible(WebDriverWait wait)
        {
            VisibilityOfElement(wait, FilterPanel);
        }

        public void HistoryFilterVisible(WebDriverWait wait)
        {
            VisibilityOfElement(wait, HistoryFilterPanel);
        }

        public void HistoryPopUpVisisible(WebDriverWait wait)
        {
            VisibilityOfElement(wait, HistoryPopUp);
        }

        public void LoggedUserMenuVisible(WebDriverWait wait)
        {
            VisibilityOfElement(wait, LoggedUserMenu);
        }

        /* Main Wait Function */

        public void WaitForConditions ()
        {
            switch (waitOption)
            {
                case ButtonWaitEnum.ProjectsListWait:
                    ClickableProjects(wait);
                    break;
                case ButtonWaitEnum.ProjectPageWait:
                    ClickableTasks(wait);
                    break;
                case ButtonWaitEnum.LoadingPageWait:
                    HomePageLoadingWait(wait);
                    break;
                case ButtonWaitEnum.ProjectPageButtonLoadingWait:
                    HomePageLoadingWait(wait);
                    ClickableTasks(wait);
                    break;
                case ButtonWaitEnum.LoggedUserMenuWait:
                    LoggedUserMenuVisible(wait);
                    break;
                case ButtonWaitEnum.FilterMenuWait:
                    FilterVisible(wait);
                    break;
                case ButtonWaitEnum.HistoryFilterMenuWait:
                    HistoryFilterVisible(wait);
                    break;
                case ButtonWaitEnum.HistoryPopUpWait:
                    HistoryPopUpVisisible(wait);
                    break;
            }
        }

        /* Constructors */

        public ButtonWait()
        {

        }

        public ButtonWait(WebDriverWait wait, ButtonWaitEnum waitOption)
        {
            this.wait = wait;
            this.waitOption = waitOption;
        }
    }
}
