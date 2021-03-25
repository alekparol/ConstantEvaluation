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
        protected Waits waitOptionImplementation;

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
            waitOptionImplementation = new Waits(wait, waitOption);
        }


        /* Constructors */

        /// <summary>
        /// Creates an empty object.
        /// </summary>
        public GenericButton()
        {

        }

        /// <summary>
        /// Creates an object.
        /// </summary>
        /// <param name="driver"> is passed IWebDriver in the actual state.</param>
        /// <param name="driver"> is passed IWebDriver in the actual state.</param>
        public GenericButton(IWebElement buttonWebElement, WebDriverWait wait)
        {
            this.wait = wait;
            this.buttonWebElement = buttonWebElement;
        }

        public GenericButton(IWebElement buttonWebElement, WebDriverWait wait, string waitOption)
        {
            this.wait = wait;
            this.waitOption = waitOption;
            this.buttonWebElement = buttonWebElement;
        }

        /// <summary>
        /// Creates a new object. Firstly awaits for the projects list to be displayed and then initialize its field with it. 
        /// </summary>
        /// <exception cref="System.Exception">Thrown when actual URL adress is different than https:\/\/tms.lionbridge.com\/</exception>
        /// <exception cref="System.Exception">Thrown when initialized project list is lesser or equal to 0. In this case it is a blocker.</exception>
        /// <param name="driver"> is passed IWebDriver in the actual state.</param>
        public GenericButton(IWebElement parentElement, string idLocator, WebDriverWait wait)
        {
            IReadOnlyCollection<IWebElement> auxiliaryCollection;
            this.wait = wait;

            auxiliaryCollection = parentElement.FindElements(By.Id(idLocator));
            if (auxiliaryCollection.Count == 1) buttonWebElement = auxiliaryCollection.ElementAt(0);
        }
    }
}
