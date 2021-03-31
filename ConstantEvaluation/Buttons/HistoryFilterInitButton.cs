using ConstantEvaluation.Waits;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace ConstantEvaluation.Buttons
{
    public class HistoryFilterInitButton : FilterInitButton
    {
        /* Fields */

        /* Properties */

        /* Methods */

        /* Constructors */

        /// <summary>
        /// Creates an empty object.
        /// </summary>
        public HistoryFilterInitButton() : base()
        {

        }

        /// <summary>
        /// Creates an object using passed <code>IWebElement</code> and <code>WebDriverWait</code>.
        /// </summary>
        /// <param name="buttonWebElement">Represents <code>IWebElement</code> of a given page button.</param>
        /// <param name="wait">Represents <code>WebDriverWait</code> init setting.</param>
        public HistoryFilterInitButton(IWebElement buttonWebElement, WebDriverWait wait) : base(buttonWebElement, wait)
        {
            waitOption = ButtonWaitEnum.HistoryFilterMenuWait;
        }

        /// <summary>
        /// Creates an object using passed <code>IWebElement</code> and <code>WebDriverWait</code>. Then wait class constructor is called with usage of wait option passed as an argument.
        /// </summary>
        /// <param name="buttonWebElement">Represents <code>IWebElement</code> of a given page button.</param>
        /// <param name="wait">Represents <code>WebDriverWait</code> init setting.</param>
        /// <param name="waitOption">Represents an option of a <code>Wait</code> object to be created.</param>
        public HistoryFilterInitButton(IWebElement buttonWebElement, WebDriverWait wait, ButtonWaitEnum waitOption) : base(buttonWebElement, wait, waitOption)
        {

        }

        /// <summary>
        /// Creates an object using passed <code>IWebElement</code> and <code>string</code> to set a child element using id locator. Then <code>WebDriverWait</code> is used to set wait field.
        /// </summary>
        /// <param name="buttonParentElement">Represents parent <code>IWebElement</code> for initalized button object.</param>
        /// <param name="buttonXPathLocator">Represents an XPath locator for the button object.</param>
        /// <param name="wait">Represents an option of a <code>Wait</code> object to be created.</param>
        public HistoryFilterInitButton(IWebElement buttonParentElement, string buttonXPathLocator, WebDriverWait wait) : base(buttonParentElement, buttonXPathLocator, wait)
        {
            waitOption = ButtonWaitEnum.HistoryFilterMenuWait;
        }

        /// <summary>
        /// Creates an object using passed <code>IWebElement</code> and <code>string</code> to set a child element using id locator. Then <code>WebDriverWait</code> is used to set wait field and wait option to call a 
        /// wait object constructor. 
        /// </summary>
        /// <param name="buttonParentElement">Represents parent <code>IWebElement</code> for initalized button object.</param>
        /// <param name="buttonXPathLocator">Represents an XPath locator for the button object.</param>
        /// <param name="wait">Represents an option of a <code>Wait</code> object to be created.</param>
        /// <param name="waitOption">Represents an option of a <code>Wait</code> object to be created.</param> 
        public HistoryFilterInitButton(IWebElement buttonParentElement, string buttonXPathLocator, WebDriverWait wait, ButtonWaitEnum waitOption) : base(buttonParentElement, buttonXPathLocator, wait, waitOption)
        {

        }
    }
}
