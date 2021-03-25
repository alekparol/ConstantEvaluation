using ConstantEvaluation.List_Items.AssigneeItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstantEvaluation.Data
{
    public class AssigneeData
    {
        /* Fields */

        public List<AssigneeDataElement> assigneeDataElements;

        /* Properties */

        /* Methods */

        /* Constructors */

        public AssigneeData(AssigneeItem assigneeItem)
        {
            assigneeDataElements = new List<AssigneeDataElement>();

            foreach (AssigneeItemElement assigneeItemElement in assigneeItem.AssigneeItemElements)
            {
                assigneeDataElements.Add(new AssigneeDataElement(assigneeItem, assigneeItemElement));
            }
        }
    }
}
