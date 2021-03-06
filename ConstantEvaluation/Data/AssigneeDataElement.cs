using ConstantEvaluation.List_Items.AssigneeItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstantEvaluation.Data
{
    public class AssigneeDataElement
    {
        /* Fields */

        public string reviewerName;
        public string jobName;
        public string sourceLanguage;
        public string targetLanguage;
        public string effort;
        public string wordcount;

        public string translatorName;

        /* Properties */

        public string TranslatorName
        {
            get
            {
                return translatorName;
            }
            set
            {
                translatorName = value;
            }
        }

        /* Methods */

        /* Constructors */

        public AssigneeDataElement(AssigneeItem assigneeItem, AssigneeItemElement assigneeItemElement)
        {
            reviewerName = assigneeItem.AssigneeName;
            jobName = assigneeItemElement.AssigneeJobsName;
            sourceLanguage = assigneeItemElement.AssingeeJobsSourceLanguage;
            targetLanguage = assigneeItemElement.AssingeeJobsTargetLanguage;
            effort = assigneeItemElement.AssingeeJobsEffort;
            wordcount = assigneeItemElement.AssingeeJobsWordcount;
        }
    }
}
