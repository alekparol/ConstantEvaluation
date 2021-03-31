using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstantEvaluation.Buttons
{
    public static class XPathLocators
    {

        /* Static Variables */

        // Loading bar on the page.
        private const string cupLoading = "//*[@id=\"cup_lod\"]";

        // Loading bar on the pop up window. 
        private const string pupLoading = "//*[@id=\"pup_lod\"]";

        // Tasks button on the Tasks subpage in the navigation bar. 
        private const string tasksButton = "//*[@id=\"inworktasks\"]";

        // List of projects on the TMS starting page.
        private const string projectLists = "//*[@class=\"dsh_tds_ttl\"]";

        // Drop down menu element that is displayed after clicking on the list item element, f.e. job item. 
        private const string itemMenu = "//*[contains(@class,\"m1 lay_flt\")]";

        // Drop down menu element that is displayed after clicking on the logged user element. 
        private const string loggedUserMenu = "//*[@id=\"usr_act\" and contains(@class,\"lay_fit\")]";

        // Panel that appears after clicking on the button "filters". 
        private const string filterPanel = "//*[@id=\"cup_lf\"]";

        // Panel that appears after clicking on the button "filters". 
        private const string historyFilterPanel = "//*[@id=\"pup_lf\"]";

        //
        private const string historyPopUp = "//*[@id=\"pup_cnt\"]";

        // Button that is displayed as clicked after loading the page. F.e. after loading the page of the project "In Work" button is displayed in navigation bar section.
        private const string currentSubPage = "//*[contains(@class,\"hdr_sub_sel tlp_on\")]";

        public static string CupLoading { get { return cupLoading; } }
        public static string PupLoading { get { return pupLoading; } }
        public static string TasksButton { get { return tasksButton; } }
        public static string ProjectLists { get { return projectLists; } }
        public static string ItemMenu { get { return itemMenu; } }
        public static string LoggedUserMenu { get { return loggedUserMenu; } }
        public static string FilterPanel { get { return filterPanel; } }
        public static string HistoryFilterPanel { get { return historyFilterPanel; } }
        public static string HistoryPopUp { get { return historyPopUp; } }
        public static string CurrentSubPage { get { return currentSubPage; } }

    }
}
