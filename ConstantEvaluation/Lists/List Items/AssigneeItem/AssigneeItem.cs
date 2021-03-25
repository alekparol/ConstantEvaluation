using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConstantEvaluation.List_Items.AssigneeItem
{
    public class AssigneeItem
    {
        /* Fields */

        private AssigneeItemHeader assigneeItemHeader;
        private List<AssigneeItemElement> assigneeItemElements;

        /* Properties */

        public AssigneeItemHeader AssigneesItemHeader
        {
            get
            {
                return assigneeItemHeader;
            }
        }

        public string AssigneeName
        {
            get
            {
                return assigneeItemHeader.AssingeeName;
            }
        }

        public List<AssigneeItemElement> AssigneeItemElements
        {
            get
            {
                return assigneeItemElements;
            }
        }

        /* Methods */

        /* Constructors */

        public AssigneeItem()
        {

        }

        public AssigneeItem(IWebElement headerObject, List<IWebElement> elementObjects)
        {
            assigneeItemHeader = new AssigneeItemHeader(headerObject);
            assigneeItemElements = new List<AssigneeItemElement>();

            foreach (IWebElement elementObject in elementObjects)
            {
                assigneeItemElements.Add(new AssigneeItemElement(elementObject));
            }

            if (assigneeItemHeader.AssigneeElementCount != assigneeItemElements.Count)
            {
                throw new Exception(String.Format("Item header class should contain {0} job elements, instead it contains {1}.", assigneeItemHeader.AssigneeElementCount, assigneeItemElements.Count));
            }
        }
    }
}
