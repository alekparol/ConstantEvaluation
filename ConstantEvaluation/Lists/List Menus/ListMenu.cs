using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstantEvaluation.Lists.List_Menus
{
    public class ListMenu
    {
        /* Fields */

        protected IWebElement menuPanel;

        protected IReadOnlyCollection<IWebElement> menuOptions;

        /* Properties */

        /* Methods */

        /* Constructors */
        public ListMenu(IWebDriver driver)
        {
            IReadOnlyCollection<IWebElement> auxiliaryCollection;

            auxiliaryCollection = driver.FindElements(By.XPath("//*[@class='m1 lay_flt']"));
            if (auxiliaryCollection.Count != 1) throw new Exception(String.Format("Menu panel was not found on the page or multiple were found."));

            menuPanel = auxiliaryCollection.ElementAt(0);
            menuOptions = menuPanel.FindElements(By.TagName("li"));
        }
    }
}
