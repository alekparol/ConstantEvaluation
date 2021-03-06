using ConstantEvaluation.Buttons;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConstantEvaluation.Lists.History_Windows
{
    public class HistoryFilterInitBar
    {
        /* Fields */

        private IWebElement filtersInitBar;

        private HistoryFilterInitButton filtersInitButton;
        private IWebElement infoMessage;

        /* Properties */

        public FilterInitButton FiltersInitButton
        {
            get
            {
                return filtersInitButton;
            }
        }

        /* Methods */

        public void FiltersInitButtonClick()
        {
            filtersInitButton.ButtonClick();
        }


        /*public void ClickAll(IWebDriver driver)
{
var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
IReadOnlyCollection<IWebElement> auxiliaryCollection;

auxiliaryCollection = driver.FindElements(By.Id("cup_cupavNull"));
if (auxiliaryCollection.Count == 1) auxiliaryCollection.ElementAt(0).Click();

wait.Until(ExpectedConditions.ElementIsVisible(By.Id("cup_lod")));
wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("cup_lod")));

}*/

        /* Constructors */

        public HistoryFilterInitBar()
        {

        }

        public HistoryFilterInitBar(IWebDriver driver)
        {
            if (driver.Url != "https://tms.lionbridge.com/")
            {
                throw new Exception("URL address is not equal to https://tms.lionbridge.com/.");
            }

            IReadOnlyCollection<IWebElement> auxiliaryCollection;

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("pup_fp_btn")));

            wait.Until(newdriver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
            auxiliaryCollection = driver.FindElements(By.Id("pup_mbp_t"));

            if (auxiliaryCollection.Count != 1) throw new Exception("Filters initial panel on the page was not found or found more than one.");
            filtersInitBar = auxiliaryCollection.ElementAt(0);

            filtersInitButton = new HistoryFilterInitButton(filtersInitBar, ".//button[@id=\"pup_fp_btn\"]", wait);

            auxiliaryCollection = driver.FindElements(By.Id("jnotify-item-msg"));
            if (auxiliaryCollection.Count == 1) infoMessage = auxiliaryCollection.ElementAt(0);
        }
    }
}
