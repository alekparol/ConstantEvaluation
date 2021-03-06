using ConstantEvaluation.Drop_Down_Menus;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConstantEvaluation.View_Section_Element.Status_Elements
{
    public class StatusFiltersPanel
    {

        /* Fields */

        private DropDown dueDate;
        private DropDown job;
        private DropDown activity;
        private DropDown sourceLanguage;
        private DropDown targetLanguage;
        private DropDown workPlacementType;

        /* Properties */

        /*        public void DisplayFiltersPanel(IWebDriver driver)
        {
            if (FiltersButtonIsDisplayed == 1)
            {
                if (FiltersButtonIsClicked == 0)
                {
                    FiltersButtonClick(driver);
                }
            }
        }*/

        public DropDown DueDate
        {
            get
            {
                return dueDate;
            }
        }

        public DropDown Job
        {
            get
            {
                return job;
            }
        }

        public DropDown Activity
        {
            get
            {
                return activity;
            }
        }

        public DropDown SourceLanguage
        {
            get
            {
                return sourceLanguage;
            }
        }

        public DropDown TargetLanguage
        {
            get
            {
                return targetLanguage;
            }
        }

        public DropDown WorkPlacementType
        {
            get
            {
                return workPlacementType;
            }
        }

        /* Methods */

        public void DueDateClick(IWebDriver driver)
        {
            dueDate.DropDownFilterClick(driver);
        }

        public void ChoseDueDateOption(IWebDriver driver, string chosenOption)
        {
            dueDate.ChoseDropDownOption(driver, chosenOption);
        }

        public void JobClick(IWebDriver driver)
        {
            job.DropDownFilterClick(driver);
        }

        public void ChoseJobOption(IWebDriver driver, string chosenOption)
        {
            job.ChoseDropDownOption(driver, chosenOption);
        }

        public void ActivityClick(IWebDriver driver)
        {
            activity.DropDownFilterClick(driver);
        }

        public void ChoseActivityOption(IWebDriver driver, string chosenOption)
        {
            activity.ChoseDropDownOption(driver, chosenOption);
        }

        public void SourceLanguageClick(IWebDriver driver)
        {
            sourceLanguage.DropDownFilterClick(driver);
        }

        public void ChoseSourceLanguageOption(IWebDriver driver, string chosenOption)
        {
            sourceLanguage.ChoseDropDownOption(driver, chosenOption);
        }

        public void TargetLanguageClick(IWebDriver driver)
        {
            targetLanguage.DropDownFilterClick(driver);
        }

        public void ChoseTargetLanguageOption(IWebDriver driver, string chosenOption)
        {
            targetLanguage.ChoseDropDownOption(driver, chosenOption);
        }

        public void WorkPlacementTypeClick(IWebDriver driver)
        {
            workPlacementType.DropDownFilterClick(driver);
        }

        public void ChoseWorkPlacementTypeOption(IWebDriver driver, string chosenOption)
        {
            workPlacementType.ChoseDropDownOption(driver, chosenOption);
        }

        /* Constructors */

        public StatusFiltersPanel()
        {

        }

        public StatusFiltersPanel(IWebDriver driver)
        {
            if (driver.Url != "https://tms.lionbridge.com/")
            {
                throw new Exception("URL address is not equal to https://tms.lionbridge.com/.");
            }

            IReadOnlyCollection<IWebElement> auxiliaryCollection;

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("cup_fp_btn")));

            wait.Until(driver1 => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));

            dueDate = new DropDown(driver, "cup_fpFlag_titletext");
            job = new DropDown(driver, "cup_fpJobId_titletext");
            activity = new DropDown(driver, "cup_fpStepActivityName_titletext");
            sourceLanguage = new DropDown(driver, "cup_fpSourceLanguage_titletext");
            targetLanguage = new DropDown(driver, "cup_fpTargetLanguage_titletext");
            workPlacementType = new DropDown(driver, "cup_fpIsExternalWork_titletext");

        }

    }
}
