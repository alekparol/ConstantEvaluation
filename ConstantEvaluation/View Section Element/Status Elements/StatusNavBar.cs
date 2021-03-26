using ConstantEvaluation.Buttons;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConstantEvaluation.View_Section_Element.Status_Elements
{
    public class StatusNavBar : NavBar
    {

        /* Fields */

        private NavBarButton activities;
        private NavBarButton alerts;
        private NavBarButton files;
        private NavBarButton assignees;

        protected WebDriverWait wait;

        /* Properties */

        public NavBarButton Activities
        {
            get
            {
                return activities;
            }
        }

        public NavBarButton Alerts
        {
            get
            {
                return alerts;
            }
        }

        public NavBarButton Files
        {
            get
            {
                return files;
            }
        }

        public NavBarButton Assignees
        {
            get
            {
                return assignees;
            }
        }

        /* Methods */

        public void ActivitiesClick()
        {
            activities.ButtonClick();
        }
        public void AlertsClick()
        {
            alerts.ButtonClick();
        }

        public void FilesClick()
        {
            files.ButtonClick();
        }

        public void AssingeesClick()
        {
            assignees.ButtonClick();
        }

        /* Constructors */

        public StatusNavBar()
        {

        }

        public StatusNavBar(IWebDriver driver) : base(driver)
        {
            if (driver.Url != "https://tms.lionbridge.com/")
            {
                throw new Exception("URL address is not equal to https://tms.lionbridge.com/.");
            }

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

            activities = new NavBarButton(navBarPanel, "status", wait);
            alerts = new NavBarButton(navBarPanel, "statusalerts", wait);
            files = new NavBarButton(navBarPanel, "statusfiles", wait);
            assignees = new NavBarButton(navBarPanel, "statusassignees", wait);
        }
    }
}
