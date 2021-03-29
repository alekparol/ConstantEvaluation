using ConstantEvaluation.Buttons;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConstantEvaluation.Home_Page_Elements
{
    public class LeftMenu
    {

        /* Fields */

        private IWebElement tagsPanel;

        /* To fill */

        private IWebElement viewsPanel;

        private LeftMenuButton tasksView;
        private LeftMenuButton jobsView;
        private LeftMenuButton planningView;
        private LeftMenuButton statusView;
        private LeftMenuButton activityLogsView;
        private LeftMenuButton reportsView;

        private LeftMenuButton referencesView;
        private LeftMenuButton deliverablesView;

        private LeftMenuButton categoriesView;
        private LeftMenuButton usersView;
        private LeftMenuButton workflowsView;

        protected WebDriverWait wait;

        /* Properties */

        public LeftMenuButton TasksView
        {
            get
            {
                return tasksView;
            }
        }

        public LeftMenuButton JobsView
        {
            get
            {
                return jobsView;
            }
        }

        public LeftMenuButton PlanningView
        {
            get
            {
                return planningView;
            }
        }

        public LeftMenuButton StatusView
        {
            get
            {
                return statusView;
            }
        }

        public LeftMenuButton ActivityLogsView
        {
            get
            {
                return activityLogsView;
            }
        }

        public LeftMenuButton ReportsView
        {
            get
            {
                return reportsView;
            }
        }

        public LeftMenuButton ReferencesView
        {
            get
            {
                return referencesView;
            }
        }

        public LeftMenuButton DeliverablesView
        {
            get
            {
                return deliverablesView;
            }
        }

        public LeftMenuButton CategoriesView
        {
            get
            {
                return categoriesView;
            }
        }

        public LeftMenuButton UsersView
        {
            get
            {
                return usersView;
            }
        }

        public LeftMenuButton WorkflowsView
        {
            get
            {
                return workflowsView;
            }
        }

        /* Methods */

        /* Constructors */

        public LeftMenu()
        {

        }

        public LeftMenu(IWebDriver driver)
        {
            if (driver.Url != "https://tms.lionbridge.com/")
            {
                throw new Exception("URL address is not equal to https://tms.lionbridge.com/.");
            }

            IReadOnlyCollection<IWebElement> auxiliaryCollection;

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("lup_actionPanel")));

            auxiliaryCollection = driver.FindElements(By.Id("lup_actionPanel"));

            if (auxiliaryCollection.Count != 1) throw new Exception("Left menu panel was not found on the page or was found more than one.");
            viewsPanel = auxiliaryCollection.ElementAt(0);

            tasksView = new LeftMenuButton(viewsPanel, ".//*[@id=\"inworktasks\"]", wait);
            jobsView = new LeftMenuButton(viewsPanel, ".//*[@id=\"jobsdashboard\"]", wait);
            planningView = new LeftMenuButton(viewsPanel, ".//*[@id=\"planning\"]", wait);
            statusView = new LeftMenuButton(viewsPanel, ".//*[@id=\"status\"]", wait);
            activityLogsView = new LeftMenuButton(viewsPanel, ".//*[@id=\"referencelog\"]", wait);
            reportsView = new LeftMenuButton(viewsPanel, ".//*[@id=\"reports\"]", wait);

            referencesView = new LeftMenuButton(viewsPanel, ".//*[@id=\"documentreference\"]", wait);
            deliverablesView = new LeftMenuButton(viewsPanel, ".//*[@id=\"documentdeliverable\"]", wait);

            categoriesView = new LeftMenuButton(viewsPanel, ".//*[@id=\"admincategories\"]", wait);
            usersView = new LeftMenuButton(viewsPanel, ".//*[@id=\"projectuser\"]", wait);
            workflowsView = new LeftMenuButton(viewsPanel, ".//*[@id=\"adminconfig\"]", wait);

        }
    }
}
