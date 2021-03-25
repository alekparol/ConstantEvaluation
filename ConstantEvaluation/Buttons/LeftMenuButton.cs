using OpenQA.Selenium;

namespace ConstantEvaluation.Buttons
{
    public class LeftMenuButton : Button
    {
        /* Fields */

        /* Properties */

        public override int ButtonIsClicked
        {
            get
            {
                if (buttonWebElement != null)
                {
                    if (buttonWebElement.GetAttribute("class").Equals("treeviewLISelected"))
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

        /* Constructors */

        public LeftMenuButton()
        {

        }

        public LeftMenuButton(IWebElement parentElement, IWebDriver driver, string idLocator) : base(parentElement, driver, idLocator)
        {

        }
    }
}
