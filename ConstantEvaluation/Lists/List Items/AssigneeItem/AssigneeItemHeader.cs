using ConstantEvaluation.List_Items.Item;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConstantEvaluation.List_Items.AssigneeItem
{
    public class AssigneeItemHeader : ItemHeader
    {
        /* Fields */

        private IWebElement assingeeName;
        private IWebElement assingeeElementsCount;

        /* Properties */

        public string AssingeeName
        {
            get
            {
                return assingeeName.Text;
            }
        }

        public int AssigneeElementCount
        {
            get
            {
                if (assingeeElementsCount != null)
                {
                    return Int32.Parse(assingeeElementsCount.Text.Trim()
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

        public AssigneeItemHeader()
        {

        }

        public AssigneeItemHeader(IWebElement headerObject) : base(headerObject)
        {
            /*assingeeName = headerTableData.FirstOrDefault(x => x.GetAttribute("class")
                                                                .Contains("grp_usr_True"));*/

            assingeeName = headerObject.FindElement(By.XPath(".//span[contains(@class,\"grp_usr_True\")]"));

            assingeeElementsCount = headerTableData.FirstOrDefault(x => x.GetAttribute("class")
                                                                         .Contains("r_LCount"));
        }
    }
}
