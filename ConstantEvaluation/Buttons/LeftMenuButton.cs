using ConstantEvaluation.Waits;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstantEvaluation.Buttons
{
    public class LeftMenuButton : GenericButton
    {
        /* Fields */

        protected string displayedClass = "hdr_sub_sel";

        /* Properties */

        /// <summary>
        /// Returns an integer value representing the fact of button being clicked. This is evalueted by checking if button web element is a representant of a class denoting all selected elements. It varies for different
        /// button types. 
        /// </summary>
        /// <returns>-1</returns> if button is null,
        /// <returns>-2</returns> if there is no class name representing clicked button.
        /// <returns>0</returns> if button is not clicked and <returns>1</returns> otherwise.  
        public int ButtonIsClicked
        {
            get
            {
                if (buttonWebElement != null)
                {
                    if (displayedClass != String.Empty)
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
                        return -2;
                    }
                }
                else
                {
                    return -1;
                }
            }
        }

        /* Methods */

        /* Constructors */

        /// <summary>LeftMenuButton(
        /// Creates an empty object.
        /// </summary>
        public LeftMenuButton() : base()
        {

        }

        /// <summary>
        /// Creates an object using passed <code>IWebElement</code> and <code>WebDriverWait</code>.
        /// </summary>
        /// <param name="buttonWebElement">Represents <code>IWebElement</code> of a given page button.</param>
        /// <param name="wait">Represents <code>WebDriverWait</code> init setting.</param>
        public LeftMenuButton(IWebElement buttonWebElement, WebDriverWait wait) : base(buttonWebElement, wait)
        {
            waitOption = ButtonWaitEnum.ProjectPageButtonLoadingWait;
        }

        /// <summary>
        /// Creates an object using passed <code>IWebElement</code> and <code>WebDriverWait</code>. Then wait class constructor is called with usage of wait option passed as an argument.
        /// </summary>
        /// <param name="buttonWebElement">Represents <code>IWebElement</code> of a given page button.</param>
        /// <param name="wait">Represents <code>WebDriverWait</code> init setting.</param>
        /// <param name="waitOption">Represents an option of a <code>Wait</code> object to be created.</param>
        public LeftMenuButton(IWebElement buttonWebElement, WebDriverWait wait, ButtonWaitEnum waitOption) : base(buttonWebElement, wait, waitOption)
        {

        }

        /// <summary>
        /// Creates an object using passed <code>IWebElement</code> and <code>string</code> to set a child element using id locator. Then <code>WebDriverWait</code> is used to set wait field.
        /// </summary>
        /// <param name="buttonParentElement">Represents parent <code>IWebElement</code> for initalized button object.</param>
        /// <param name="buttonXPathLocator">Represents an XPath locator for the button object.</param>
        /// <param name="wait">Represents an option of a <code>Wait</code> object to be created.</param>
        public LeftMenuButton(IWebElement buttonParentElement, string buttonXPathLocator, WebDriverWait wait) : base(buttonParentElement, buttonXPathLocator, wait)
        {
            waitOption = ButtonWaitEnum.ProjectPageButtonLoadingWait;
        }

        /// <summary>
        /// Creates an object using passed <code>IWebElement</code> and <code>string</code> to set a child element using id locator. Then <code>WebDriverWait</code> is used to set wait field and wait option to call a 
        /// wait object constructor. 
        /// </summary>
        /// <param name="buttonParentElement">Represents parent <code>IWebElement</code> for initalized button object.</param>
        /// <param name="buttonXPathLocator">Represents an XPath locator for the button object.</param>
        /// <param name="wait">Represents an option of a <code>Wait</code> object to be created.</param>
        /// <param name="waitOption">Represents an option of a <code>Wait</code> object to be created.</param> 
        public LeftMenuButton(IWebElement buttonParentElement, string buttonXPathLocator, WebDriverWait wait, ButtonWaitEnum waitOption) : base(buttonParentElement, buttonXPathLocator, wait, waitOption)
        {

        }
    }
}
