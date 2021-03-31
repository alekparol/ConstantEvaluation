using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstantEvaluation.Waits
{
    public enum ButtonWaitEnum
    {
        // Denotes the wait for all projects from the projects list to be displayed
        ProjectsListWait,
        
        // Denotes the wait for the chosen project page to be displayed.
        ProjectPageWait,

        // Denotes the wait for the loading of entered change and applying it. 
        LoadingPageWait,

        // Denotes the wait for 
        ProjectPageButtonLoadingWait,

        // Denotes the wait for displaying the Logged User drop down menu after clicking on it. 
        LoggedUserMenuWait,

        // Denotes the wait for the Filter Panel to be displayed after clicking on Filter Init button.
        FilterMenuWait,

        // Denotes the wait for the Filter Panel to be displayed after clicking on Filter Init button in history Pop Up Window. [It is assumed that this will be similar for all "pup" classes.
        HistoryFilterMenuWait,

        // Denotes the wait for displaying the History Pop Up Window after clicking on "Show History" Button in Logged User Drop Down menu. 
        HistoryPopUpWait,

        // Denotes the wait for the loading of entered change and applying it within Pop Up Window. 
        LoadingPopUpWait,

    }
}
