using ConstantEvaluation.Buttons;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstantEvaluation.Lists.List_Menus
{
    public class AssigneeListMenu : ListMenu
    {
        /* Fields */

        protected ListMenuButton tagJobButton;
        protected ListMenuButton markAsCompleteButton;
        protected ListMenuButton markAsPassedButton;
        protected ListMenuButton markAsFailedButton;
        protected ListMenuButton unclaimButton;
        protected ListMenuButton copyToClipboardButton;

        protected WebDriverWait wait;

        /* Properties */

        public int MenuOptionsCount
        {
            get
            {
                return menuOptions.Count;
            }
        }

        /* Methods */

        public void ClickTagJobs()
        {
            tagJobButton.ButtonClick();
        }

        public void ClickMarkAsComplete()
        {
            markAsCompleteButton.ButtonClick();
        }

        public void ClicMarkAsPassed()
        {
            markAsPassedButton.ButtonClick();
        }

        public void ClickMarkAsFailed()
        {
            markAsFailedButton.ButtonClick();
        }

        public void ClickUnclaim()
        {
            unclaimButton.ButtonClick();
        }

        public void ClickCopyToClipboard()
        {
            copyToClipboardButton.ButtonClick();
        }

        /* Constructors */
        public AssigneeListMenu(IWebDriver driver) : base(driver)
        {
            IReadOnlyCollection<IWebElement> auxiliaryCollection;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

            auxiliaryCollection = driver.FindElements(By.XPath("//*[@class='m1 lay_flt']"));
            if (auxiliaryCollection.Count != 1) throw new Exception(String.Format("Menu panel was not found on the page or multiple were found."));

            menuPanel = auxiliaryCollection.ElementAt(0);
            menuOptions = menuPanel.FindElements(By.TagName("li"));

            tagJobButton = new ListMenuButton(menuPanel, ".//li[contains(@class,\"mnu_tag\")]", wait);
            markAsCompleteButton = new ListMenuButton(menuPanel, ".//li[contains(@class,\"mnu_acp\")]", wait);
            markAsPassedButton = new ListMenuButton(menuPanel, ".//li[contains(@class,\"mnu_pas\")]", wait);
            markAsFailedButton = new ListMenuButton(menuPanel, ".//li[contains(@class,\"mnu_del\")]", wait);
            unclaimButton = new ListMenuButton(menuPanel, ".//li[contains(@class,\"mnu_unc\")]", wait);
            copyToClipboardButton = new ListMenuButton(menuPanel, ".//li[contains(@class,\"mnu_cpy\")]", wait);
        }
    }
}
