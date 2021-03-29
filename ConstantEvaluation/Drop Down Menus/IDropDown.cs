using OpenQA.Selenium;

namespace ConstantEvaluation.Drop_Down_Menus
{
    public interface IDropDown
    {
        bool DropDownIsExpanded { get; }
        int DropDownOptionsCount { get; }
        string DropDownSelection { get; }

        void ChoseDropDownOption(IWebDriver driver, string chosenOption);
        void DropDownFilterClick(IWebDriver driver);
    }
}