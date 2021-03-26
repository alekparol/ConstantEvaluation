using ConstantEvaluation.Buttons;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstantEvaluation.Lists.List_Menus
{
    public class JobsListMenu : ListMenu
    {
        /* Fields */

        private IWebDriver driver;

        protected ListMenuButton tagJobButton;
        protected ListMenuButton editButton;
        protected ListMenuButton hideButton;
        protected ListMenuButton createCopyButton;
        protected ListMenuButton createRelatedJobButton;
        protected ListMenuButton cancelButton;
        protected ListMenuButton showSourceButton;
        protected ListMenuButton showWordCountButton;
        protected ListMenuButton showDeliveryButton;
        protected ListMenuButton showHistoryButton;
        protected ListMenuButton showAuditLogsButton;
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

        public void ClickEdit()
        {
            editButton.ButtonClick();
        }

        public void ClicHide()
        {
            hideButton.ButtonClick();
        }

        public void ClickCreateCopy()
        {
            createCopyButton.ButtonClick();
        }

        public void ClickCreateRelatedJob()
        {
            createRelatedJobButton.ButtonClick();
        }

        public void ClickCancel()
        {
            cancelButton.ButtonClick();
        }
        public void ClickShowSource()
        {
            showSourceButton.ButtonClick();
        }
        public void ClickShowWordCount()
        {
            showWordCountButton.ButtonClick();
        }

        public void ClickShowDelivery()
        {
            showDeliveryButton.ButtonClick();
        }

        public void ClickShowHistory()
        {
            showHistoryButton.ButtonClick();

            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("pup_cnt")));
        }

        public void ClickShowAuditLogs()
        {
            showAuditLogsButton.ButtonClick();
        }

        public void ClickCopyToClipboard()
        {
            copyToClipboardButton.ButtonClick();
        }

        /* Constructors */
        public JobsListMenu(IWebDriver driver) : base(driver)
        {
            IReadOnlyCollection<IWebElement> auxiliaryCollection;
            
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

            auxiliaryCollection = driver.FindElements(By.XPath("//*[@class='m1 lay_flt']"));
            if (auxiliaryCollection.Count != 1) throw new Exception(String.Format("Menu panel was not found on the page or multiple were found."));

            menuPanel = auxiliaryCollection.ElementAt(0);
            menuOptions = menuPanel.FindElements(By.TagName("li"));

            tagJobButton = new ListMenuButton(menuPanel, ".//li[contains(@class,\"mnu_tag\")]", wait);
            editButton = new ListMenuButton(menuPanel, ".//li[contains(@class,\"mnu_edt\")]", wait);
            hideButton = new ListMenuButton(menuPanel, ".//li[contains(@class,\"mnu_shj\")]", wait);
            createCopyButton = new ListMenuButton(menuPanel, ".//li[contains(@class,\"mnu_null\") and contains(text(),\"a copy\")]", wait);
            createRelatedJobButton = new ListMenuButton(menuPanel, ".//li[contains(@class,\"mnu_null\") and contains(text(),\"related job\")]", wait);
            cancelButton = new ListMenuButton(menuPanel, ".//li[contains(@class,\"mnu_ccl\")]", wait);
            showSourceButton = new ListMenuButton(menuPanel, ".//li[contains(@class,\"mnu_shw\") and contains(text(),\"Source Files\")]", wait);
            showWordCountButton = new ListMenuButton(menuPanel, ".//li[contains(@class,\"mnu_shw\") and contains(text(),\"Word Counts\")]", wait);
            showDeliveryButton = new ListMenuButton(menuPanel, ".//li[contains(@class,\"mnu_shw\") and contains(text(),\"Delivery\")]", wait);
            showHistoryButton = new ListMenuButton(menuPanel, ".//li[contains(@class,\"mnu_fld\")]", wait);
            showAuditLogsButton = new ListMenuButton(menuPanel, ".//li[contains(@class,\"mnu_null\") and contains(text(),\"Audit Logs\")]", wait);
            copyToClipboardButton = new ListMenuButton(menuPanel, ".//li[contains(@class,\"mnu_null\") and contains(text(),\"to Clipboard\")]", wait);
        }
    }
}
