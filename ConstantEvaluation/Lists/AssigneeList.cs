using ConstantEvaluation.Home_Page_Elements;
using ConstantEvaluation.List_Items.AssigneeItem;
using ConstantEvaluation.Lists.List_Menus;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstantEvaluation.Lists
{
    public class AssigneeList
    {
        /* Fields */

        private IWebElement listContainer;

        List<AssigneeItem> assigneeItemsList;

        private PageNavBar pageNavBar;

        private AssigneeListMenu assigneeListMenu;

        /* Properties */

        public List<AssigneeItem> AssigneeItemsList
        {
            get
            {
                return assigneeItemsList;
            }
        }

        public int AssigneeItemsListCount
        {
            get
            {
                return assigneeItemsList.Count;
            }
        }

        public PageNavBar PageNavBar
        {
            get
            {
                return pageNavBar;
            }
        }

        /* Methods */

        public string GetJobSourceLanguage(int jobNumber)
        {
            return assigneeItemsList.ElementAt(jobNumber).AssigneeItemElements[0].AssingeeJobsSourceLanguage;
        }

        public string GetJobTargetLanguage(int jobNumber)
        {
            return assigneeItemsList.ElementAt(jobNumber).AssigneeItemElements[0].AssingeeJobsTargetLanguage;
        }

        public void SelectSingleJob(IWebDriver driver, int jobNumber)
        {
            if (assigneeItemsList.Count != 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
                IReadOnlyCollection<IWebElement> auxiliaryCollection;

                assigneeItemsList.ElementAt(jobNumber).AssigneeItemElements[0].AssigneeJobClick(driver);

                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@class='m1 lay_flt']")));
                assigneeListMenu = new AssigneeListMenu(driver);
            }
        }

        public void TagSingleJob(IWebDriver driver, int jobNumber)
        {
            if (assigneeItemsList.Count != 0)
            {
                SelectSingleJob(driver, jobNumber);
                assigneeListMenu.ClickTagJobs();
            }
        }

        public void SelectMultipleJobs(IWebDriver driver, int rangeStart, int rangeEnd)
        {
            if (assigneeItemsList.Count != 0 && rangeEnd <= assigneeItemsList.Count && rangeStart <= assigneeItemsList.Count && rangeStart < rangeEnd)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
                Actions selectingMultipleItems = new Actions(driver);

                assigneeItemsList.ElementAt(rangeStart).AssigneeItemElements[0].AssigneeJobClick(driver);

                selectingMultipleItems
                .KeyDown(Keys.Shift)
                .Click(driver.FindElement(By.ClassName("r_GH")))
                .MoveToElement(driver.FindElement(By.XPath("(//*[@class=\"r_L\"])[last()]")))
                .Build()
                .Perform();

                assigneeItemsList.ElementAt(rangeEnd).AssigneeItemElements[assigneeItemsList.ElementAt(rangeEnd).AssigneeItemElements.Count - 1].AssigneeJobClick(driver);

                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@class='m1 lay_flt']")));
                assigneeListMenu = new AssigneeListMenu(driver);
                /*if (assigneesJobsList.ElementAt(rangeStart).JobsButtonIsEnabled == 1 && assigneesJobsList.ElementAt(rangeEnd).JobsButtonIsEnabled == 1)
                {
                    
                }*/
            }
        }

        public void TagMultipleJobs(IWebDriver driver, int rangeStart, int rangeEnd)
        {
            if (assigneeItemsList.Count != 0 && rangeEnd <= assigneeItemsList.Count && rangeStart <= assigneeItemsList.Count && rangeStart < rangeEnd)
            {
                SelectMultipleJobs(driver, rangeStart, rangeEnd);
                assigneeListMenu.ClickTagJobs();
            }
        }


        public void SelectAllJobs(IWebDriver driver)
        {
            if (assigneeItemsList.Count != 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
                Actions selectingMultipleItems = new Actions(driver);

                IReadOnlyCollection<IWebElement> listofJobs = driver.FindElements(By.ClassName("r_L"));

                selectingMultipleItems
                .Click(listofJobs.ElementAt(0))
                .KeyDown(Keys.Shift)
                .Click(driver.FindElement(By.ClassName("r_GH")))
                .MoveToElement(listofJobs.ElementAt(listofJobs.Count - 1))
                .Click(listofJobs.ElementAt(listofJobs.Count - 1))
                .Build()
                .Perform();

                //wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@class='m1 lay_flt']")));
                assigneeListMenu = new AssigneeListMenu(driver);
                /*if (assigneesJobsList.ElementAt(rangeStart).JobsButtonIsEnabled == 1 && assigneesJobsList.ElementAt(rangeEnd).JobsButtonIsEnabled == 1)
                {
                    
                }*/
            }
        }

        public void TagAllJobs(IWebDriver driver)
        {
            if (assigneeItemsList.Count != 0)
            {
                SelectAllJobs(driver);
                assigneeListMenu.ClickTagJobs();
            }
        }


        /* Constructors */

        public AssigneeList(IWebDriver driver)
        {
            IReadOnlyCollection<IWebElement> auxiliaryCollection;

            auxiliaryCollection = driver.FindElements(By.ClassName("r_GH"));
            if (auxiliaryCollection.Count != 1) throw new Exception(String.Format("List container was not found on the page or multiple were found."));

            listContainer = auxiliaryCollection.ElementAt(0);

            assigneeItemsList = new List<AssigneeItem>();

            auxiliaryCollection = driver.FindElements(By.ClassName("r_LH"));

            foreach (IWebElement headerObject in auxiliaryCollection)
            {
                IReadOnlyCollection<IWebElement> followingHeaders = headerObject.FindElements(By.XPath("(.//following-sibling::tr[@class=\"r_LH\"])[1]"));
                if (followingHeaders.Count == 1)
                {
                    IReadOnlyCollection<IWebElement> followingSiblings = headerObject.FindElements(By.XPath(".//following-sibling::tr[@class=\"r_L\"]"));
                    IReadOnlyCollection<IWebElement> previousSiblings = followingHeaders.ElementAt(0).FindElements(By.XPath(".//preceding-sibling::tr[@class=\"r_L\"]"));
                    List<IWebElement> jobs = followingSiblings.AsQueryable().Intersect(previousSiblings).ToList();

                    assigneeItemsList.Add(new AssigneeItem(headerObject, jobs));
                }
                else if (followingHeaders.Count == 0)
                {
                    IReadOnlyCollection<IWebElement> followingSiblings = headerObject.FindElements(By.XPath(".//following-sibling::tr[@class=\"r_L\"]"));
                    List<IWebElement> jobs = followingSiblings.ToList();

                    assigneeItemsList.Add(new AssigneeItem(headerObject, jobs));
                }
            }
        }
    }
}
