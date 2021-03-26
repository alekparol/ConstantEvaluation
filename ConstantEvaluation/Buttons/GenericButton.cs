using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;

namespace ConstantEvaluation.Buttons
{
    public class GenericButton
    {
        /* Fields */

        protected WebDriverWait wait;
        protected string waitOption;
        protected Wait waitOptionImplementation;

        protected IWebElement buttonWebElement;

        /* Properties */

        /// <summary>
        /// Returns a string contained within button element.  
        /// </summary>
        public string GetButtonName
        {
            get
            {
                return buttonWebElement.Text;
            }
        }

        /* Methods */

        /// <summary>
        /// Clicks on the button and then waits for the conditions specified for the button type to be fulfilled.  
        /// <exception cref="System.Exception">Thrown when a button that will be clicked is uninitialized.</exception>
        /// </summary>
        public void ButtonClick()
        {
            if (buttonWebElement == null)
            {
                throw new Exception("Cannot click a uninitialized button.");
            }

            buttonWebElement.Click();
            waitOptionImplementation = new Wait(wait, waitOption);
        }

        /* Constructors */

        /// <summary>
        /// Creates an empty object.
        /// </summary>
        public GenericButton()
        {

        }

        /// <summary>
        /// Creates an object using passed <code>IWebElement</code> and <code>WebDriverWait</code>.
        /// </summary>
        /// <param name="buttonWebElement">Represents <code>IWebElement</code> of a given page button.</param>
        /// <param name="wait">Represents <code>WebDriverWait</code> init setting.</param>
        public GenericButton(IWebElement buttonWebElement, WebDriverWait wait)
        {
            this.wait = wait;
            this.buttonWebElement = buttonWebElement;
        }

        /// <summary>
        /// Creates an object using passed <code>IWebElement</code> and <code>WebDriverWait</code>. Then wait class constructor is called with usage of wait option passed as an argument.
        /// </summary>
        /// <param name="buttonWebElement">Represents <code>IWebElement</code> of a given page button.</param>
        /// <param name="wait">Represents <code>WebDriverWait</code> init setting.</param>
        /// <param name="waitOption">Represents an option of a <code>Wait</code> object to be created.</param>
        public GenericButton(IWebElement buttonWebElement, WebDriverWait wait, string waitOption) : this(buttonWebElement, wait)
        {
            this.waitOption = waitOption;
        }

        /// <summary>
        /// Creates an object using passed <code>IWebElement</code> and <code>string</code> to set a child element using id locator. Then <code>WebDriverWait</code> is used to set wait field.
        /// </summary>
        /// <param name="buttonParentElement">Represents parent <code>IWebElement</code> for initalized button object.</param>
        /// <param name="buttonXPathLocator">Represents an XPath locator for the button object.</param>
        /// <param name="wait">Represents an option of a <code>Wait</code> object to be created.</param>
        public GenericButton(IWebElement buttonParentElement, string buttonXPathLocator, WebDriverWait wait) : this(buttonParentElement.FindElements(By.XPath(buttonXPathLocator)).FirstOrDefault(), wait)
        {

        }

        /// <summary>
        /// Creates an object using passed <code>IWebElement</code> and <code>string</code> to set a child element using id locator. Then <code>WebDriverWait</code> is used to set wait field and wait option to call a 
        /// wait object constructor. 
        /// </summary>
        /// <param name="buttonParentElement">Represents parent <code>IWebElement</code> for initalized button object.</param>
        /// <param name="buttonXPathLocator">Represents an XPath locator for the button object.</param>
        /// <param name="wait">Represents an option of a <code>Wait</code> object to be created.</param>
        /// <param name="waitOption">Represents an option of a <code>Wait</code> object to be created.</param> 
        public GenericButton(IWebElement buttonParentElement, string buttonXPathLocator, WebDriverWait wait, string waitOption) : this(buttonParentElement.FindElements(By.XPath(buttonXPathLocator)).FirstOrDefault(), wait, waitOption)
        {

        }
    }
}
