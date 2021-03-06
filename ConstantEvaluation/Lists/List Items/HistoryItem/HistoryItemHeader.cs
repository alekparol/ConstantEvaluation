using ConstantEvaluation.List_Items.Item;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConstantEvaluation.List_Items.HistoryItem
{
    public class HistoryItemHeader : ItemHeader
    {
        /* Fields */

        private IWebElement jobName;
        private IWebElement jobElementsCount;

        /* Properties */

        public string JobName
        {
            get
            {
                return jobName.Text;
            }
        }

        public int HistoryElementCount
        {
            get
            {
                if (jobElementsCount != null)
                {
                    return Int32.Parse(jobElementsCount.Text.Trim()
                                                            .Replace("(", "")
                                                            .Replace(")", ""));
                }
                else
                {
                    return -1;
                }
            }
        }

        /* Methods */

        /* Constructors */

        public HistoryItemHeader()
        {

        }

        public HistoryItemHeader(IWebElement headerObject) : base(headerObject)
        {
            /* = headerTableData.FirstOrDefault(x => x.GetAttribute("class")
                                                           .Contains("grp_ttl"));*/
            jobName = headerObject.FindElement(By.XPath(".//*[contains(@class,\"grp_ttl\")]"));

            jobElementsCount = headerTableData.FirstOrDefault(x => x.GetAttribute("class")
                                                                    .Contains("r_LCount"));
        }
    }
}
