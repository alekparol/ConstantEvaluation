using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConstantEvaluation.Drop_Down_Menus
{
    class DropDownContainer
    {
        /* Fields */

        private IWebElement dropDownOptionContainer;
        private IReadOnlyCollection<IWebElement> dropDownOptions;

        /* Properties */

        public bool DropDownIsExpanded
        {
            get
            {
                if (dropDownOptionContainer.Displayed)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public int DropDownOptionsCount
        {
            get
            {
                return dropDownOptions.Count;
            }
        }

        /* Methods */

        public void ChoseDropDownOption(IWebDriver driver, string chosenOption)
        {

            if (DropDownIsExpanded)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

                dropDownOptions.Where(x =>
                                      x.Text.Equals(chosenOption))
                                     .ElementAt(0).Click();

                wait.Until(ExpectedConditions.ElementIsVisible(By.Id("cup_lod")));
                wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("cup_lod")));
            }

        }

        /* Constructors */

        public DropDownContainer()
        {

        }

        public DropDownContainer(IWebDriver driver, string xPathLocator)
        {
            IReadOnlyCollection<IWebElement>  auxiliaryCollection = driver.FindElements(By.XPath(xPathLocator));
            if (auxiliaryCollection.Count != 1) throw new Exception(String.Format("Drop down menu of id {0} on the page was not found or found more than one.", xPathLocator));

            dropDownOptionContainer = auxiliaryCollection.ElementAt(0);
            dropDownOptions = dropDownOptionContainer.FindElements(By.XPath(".//a"));
        }
    }
}
