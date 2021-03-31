using ConstantEvaluation.Waits;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstantEvaluation.General_Utilities
{
    public class GenericWait
    {
        /* Fields */

        protected WebDriverWait wait;
        protected ButtonWaitEnum waitOption;

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

        /* Constructors */

        public GenericWait()
        {

        }

        public GenericWait(WebDriverWait wait, ButtonWaitEnum waitOption)
        {
            this.wait = wait;
            this.waitOption = waitOption;
        }
    }
}
