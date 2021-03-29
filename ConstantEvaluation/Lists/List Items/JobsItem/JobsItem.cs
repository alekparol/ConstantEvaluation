using ConstantEvaluation.List_Items.Item;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConstantEvaluation.List_Items.JobsItem
{
    public class JobsItem : ItemElement
    {
        /* Fields */

        private IWebElement jobsName;
        private IWebElement jobsLanguages;
        private IWebElement jobsEffort;

        Regex jobsLanguagesRegex = new Regex("(\\w{2,3}-\\w{2,3}|N\\/A)\\s{1}→\\s{1}(\\w{2,3}-\\w{2,3}|N\\/A)");

        /* Properties */

        public string JobsJobName
        {
            get
            {
                return jobsName.Text;
            }
        }

        public bool IsSelected
        {
            get
            {
                if (elementObject.GetAttribute("class").Contains("row_slt"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /* Methods */

        public void JobsJobClick(IWebDriver driver)
        {
            //var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

            String mouseOverScript = "if(document.createEvent){var evObj = document.createEvent('MouseEvents');evObj.initEvent('mouseover', true, false); arguments[0].dispatchEvent(evObj);} else if(document.createEventObject){ arguments[0].fireEvent('onmouseover');}";
            String onClickScript = "if(document.createEvent){var evObj = document.createEvent('MouseEvents');evObj.initEvent('click',true, false); arguments[0].dispatchEvent(evObj);} else if(document.createEventObject){ arguments[0].fireEvent('onclick');}";

            ((IJavaScriptExecutor)driver).ExecuteScript(mouseOverScript, elementObject);
            ((IJavaScriptExecutor)driver).ExecuteScript(onClickScript, elementObject);
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@class=\"m1 lay_flt\"]")));
            // wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@class=\"m1 lay_flt\"]")));
        }

        /* Constructors */

        public JobsItem()
        {

        }
        public JobsItem(IWebElement elementObject) : base(elementObject)
        {
            //jobsName = elementTableData.FirstOrDefault(x => x.FindElement(By.TagName("ul")).GetAttribute("class")
            //                                                 .Contains("firstColumn")).FindElement(By.TagName("ul"));

            jobsName = elementTableData.ElementAt(0).FindElement(By.XPath(".//ul[@class=\"firstColumn\"]"));

            jobsLanguages = elementTableData.FirstOrDefault(x => jobsLanguagesRegex.IsMatch(x.Text));
            jobsEffort = elementTableData.ElementAt(elementTableData.Count - 1);
        }
    }
}
