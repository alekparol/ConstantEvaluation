using ConstantEvaluation.General_Utilities;
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
    public class ButtonWait : GenericWait
    {

        /* Fields */

        /* Properties */

        /* Methods */

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

        public void ClickableCurrentPage(WebDriverWait wait)
        {
            ClickableWait(wait, CurrentSubPage);
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
                /* THIS IS NOT RELATED TO BUTTONS - Rather to Pages.
                 * case ButtonWaitEnum.ProjectsListWait:
                    ClickableProjects(wait);
                    break;*/
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

        public ButtonWait() : base()
        {

        }

        public ButtonWait(WebDriverWait wait, ButtonWaitEnum waitOption) : base(wait, waitOption)
        {
            this.wait = wait;
            this.waitOption = waitOption;
        }
    }
}
