using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
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
        protected string displayedClass;

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

        /// <summary>
        /// Returns an integer value representing the fact of button being clicked. This is evalueted by checking if button web element is a representant of a class denoting all selected elements. It varies for different
        /// button types. 
        /// </summary>
        /// <returns>-1</returns> if button is null, <returns>0</returns> if button is not clicked and <returns>1</returns> otherwise.  
        public int ButtonIsClicked
        {
            get
            {
                if (buttonWebElement != null)
                {
                    if (buttonWebElement.GetAttribute("class").Contains(displayedClass))
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }
                else
                {
                    return -1;
                }
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
        /// <param name="buttonIdLocator">Represents an id locator for the button object.</param>
        /// <param name="wait">Represents an option of a <code>Wait</code> object to be created.</param>
        public GenericButton(IWebElement buttonParentElement, string buttonIdLocator, WebDriverWait wait) : this(buttonParentElement.FindElements(By.Id(buttonIdLocator)).FirstOrDefault(), wait)
        {

        }

        /// <summary>
        /// Creates an object using passed <code>IWebElement</code> and <code>string</code> to set a child element using id locator. Then <code>WebDriverWait</code> is used to set wait field and wait option to call a 
        /// wait object constructor. 
        /// </summary>
        /// <param name="buttonParentElement">Represents parent <code>IWebElement</code> for initalized button object.</param>
        /// <param name="buttonIdLocator">Represents an id locator for the button object.</param>
        /// <param name="wait">Represents an option of a <code>Wait</code> object to be created.</param>
        /// <param name="waitOption">Represents an option of a <code>Wait</code> object to be created.</param> 
        public GenericButton(IWebElement buttonParentElement, string buttonIdLocator, WebDriverWait wait, string waitOption) : this(buttonParentElement.FindElements(By.Id(buttonIdLocator)).FirstOrDefault(), wait, waitOption)
        {

        }
    }
}
