using ConstantEvaluation.Data;
using ConstantEvaluation.List_Items.AssigneeItem;
using ConstantEvaluation.Lists;
using ConstantEvaluation.Lists.History_Windows;
using ConstantEvaluation.Pages;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Xml;

namespace ConstantEvaluation_Tests
{
    [TestClass()]
    public class SystemTests
    {
        [TestMethod()]
        public void SystemTest()
        {
            using (var driver = new ChromeDriver())
            {

                /* Opening Configuration File and Loading Init Data */

                if (File.Exists("configurationfile.xml") == false)
                {
                    throw new Exception("Configuration file do not exists in the program's directory.");
                }

                XmlDocument configurationFile = new XmlDocument();
                configurationFile.Load("configurationfile.xml");

                string projectName = configurationFile.SelectSingleNode("//project").InnerText;
                string settingInProgess = configurationFile.SelectSingleNode("//setting_inprogress").InnerText;
                string settingCompleted = configurationFile.SelectSingleNode("//setting_completed").InnerText;

                if (projectName == String.Empty || settingInProgess == String.Empty || settingCompleted == String.Empty)
                {
                    throw new Exception(String.Format("At least one of the configuration arguments is empty. ProjectName: {0}, SettingInProgressName: {1}, SettingCompletedName: {2}", projectName, settingInProgess, settingCompleted));
                }

                /* Initializing the Driver and Navigating to TMS Home Page */

                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://tms.lionbridge.com/");

                wait.Until(ExpectedConditions.UrlMatches("https://tms.lionbridge.com/"));

                /**/

                TMSProjectsPage tmsProjectsPage = new TMSProjectsPage(driver);
                tmsProjectsPage.ClickChosenProject(projectName);

                TMSProjectHomePage tmsProjectHomePage = new TMSProjectHomePage(driver);
                tmsProjectHomePage.ChangeItemsPerPageToMinimum(driver);

                tmsProjectHomePage.StatusClick();
                TMSStatusPage tmsStatusPage = new TMSStatusPage(driver);

                tmsStatusPage.AssingeeClick();
                TMSAssigneesSubpage tmsAssigneesSubpage = new TMSAssigneesSubpage(driver);

                tmsAssigneesSubpage.InitializeFiltersPanel(driver);

                if (tmsAssigneesSubpage.AssigneeCount == 1)
                {
                    throw new Exception("Activities drop down list is empty. Program now will shut down. ");
                }

                tmsAssigneesSubpage.ChoseActivityOption(driver, settingInProgess);
                tmsAssigneesSubpage = new TMSAssigneesSubpage(driver);

                /*PageNavBar pageNavBar = new PageNavBar(driver);

                if (pageNavBar.ItemsPerPage != null)
                {
                    pageNavBar.ItemsPerPage.ChoseDropDownOption(driver, "1000");
                }*/

                tmsAssigneesSubpage = new TMSAssigneesSubpage(driver);

                AssigneeList assigneeList = new AssigneeList(driver);
                List<AssigneeData> listAssigneeData = new List<AssigneeData>();

                foreach (AssigneeItem assigneeItem in assigneeList.AssigneeItemsList)
                {
                    listAssigneeData.Add(new AssigneeData(assigneeItem));
                }

                assigneeList.AssigneeItemsList[0].AssigneeItemElements[0].TagSingleJob(driver);

                tmsAssigneesSubpage = new TMSAssigneesSubpage(driver);
                tmsAssigneesSubpage.LeftMenu.JobsView.ButtonClick();

                wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("r_L")));

                JobList jobList = new JobList(driver);
                jobList.JobShowHistory(driver, 0);

                HistoryPopUp historyPopUp = new HistoryPopUp(driver);
                historyPopUp.InitializeFiltersPanel(driver);

                historyPopUp.ChoseSourceLanguageOption(driver, listAssigneeData[0].assigneeDataElements[0].sourceLanguage);
                historyPopUp.ChoseTargetLanguageOption(driver, listAssigneeData[0].assigneeDataElements[0].targetLanguage);
                historyPopUp.ChoseActivityOption(driver, settingCompleted);

                HistoryList historyList = new HistoryList(driver);
                //historyList.HistoryItemsList[0].HistoryItemElements[0].StepCompletedByClick(driver);

                listAssigneeData[0].assigneeDataElements[0].translatorName = historyList.HistoryItemsList[0].HistoryItemElements[0].StepCompletedBy;

                string path = Path.Combine(Directory.GetCurrentDirectory(), "TestFile.xlsx");

                using (SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Create(path, SpreadsheetDocumentType.Workbook))
                {

                    // Add a WorkbookPart to the document.
                    WorkbookPart workbookpart = spreadsheetDocument.AddWorkbookPart();
                    workbookpart.Workbook = new Workbook();

                    // Add a WorksheetPart to the WorkbookPart.
                    WorksheetPart worksheetPart = workbookpart.AddNewPart<WorksheetPart>();
                    worksheetPart.Worksheet = new Worksheet(new SheetData());

                    // Add Sheets to the Workbook.
                    Sheets sheets = spreadsheetDocument.WorkbookPart.Workbook.
                                                        AppendChild<Sheets>(new Sheets());

                    // Append a new worksheet and associate it with the workbook.
                    Sheet sheet = new Sheet()
                    {
                        Id = spreadsheetDocument.WorkbookPart.
                                                     GetIdOfPart(worksheetPart),
                        SheetId = 1,
                        Name = "mySheet"
                    };


                    sheets.Append(sheet);
                    SheetData sheetData = worksheetPart.Worksheet.GetFirstChild<SheetData>();


                    UInt32 rowIndex = 0;

                    foreach (var info in listAssigneeData)
                    {
                        var row = new Row() { RowIndex = rowIndex };

                        var firstNameCell = new Cell() { CellReference = "A" + (rowIndex + 1) };
                        firstNameCell.CellValue = new CellValue(info.assigneeDataElements[0].jobName);
                        firstNameCell.DataType = CellValues.String;

                        row.AppendChild(firstNameCell);

                        Cell secondNameCell = new Cell() { CellReference = "B" + (rowIndex + 1) };
                        secondNameCell.CellValue = new CellValue(info.assigneeDataElements[0].sourceLanguage);
                        secondNameCell.DataType = new EnumValue<CellValues>(CellValues.String);

                        row.AppendChild(secondNameCell);

                        Cell thirdNameCell = new Cell() { CellReference = "C" + (rowIndex + 1) };
                        thirdNameCell.CellValue = new CellValue(info.assigneeDataElements[0].targetLanguage);
                        thirdNameCell.DataType = new EnumValue<CellValues>(CellValues.String);

                        row.AppendChild(thirdNameCell);

                        Cell fourthNameCell = new Cell() { CellReference = "D" + (rowIndex + 1) };
                        fourthNameCell.CellValue = new CellValue(info.assigneeDataElements[0].reviewerName);
                        fourthNameCell.DataType = new EnumValue<CellValues>(CellValues.String);

                        row.AppendChild(fourthNameCell);

                        Cell fifthNameCell = new Cell() { CellReference = "E" + (rowIndex + 1) };
                        fifthNameCell.CellValue = new CellValue(info.assigneeDataElements[0].translatorName);
                        fifthNameCell.DataType = new EnumValue<CellValues>(CellValues.String);

                        row.AppendChild(fifthNameCell);

                        Cell sixthNameCell = new Cell() { CellReference = "F" + (rowIndex + 1) };
                        sixthNameCell.CellValue = new CellValue(info.assigneeDataElements[0].effort);
                        sixthNameCell.DataType = CellValues.String;

                        row.AppendChild(sixthNameCell);

                        Cell seventhNameCell = new Cell() { CellReference = "G" + (rowIndex + 1) };
                        seventhNameCell.CellValue = new CellValue(info.assigneeDataElements[0].wordcount);
                        seventhNameCell.DataType = CellValues.String;

                        row.AppendChild(seventhNameCell);

                        sheetData.AppendChild(row);

                        rowIndex++;
                    }

                    workbookpart.Workbook.Save();
                }
            }
        }

        [TestMethod()]
        public void SystemTest2()
        {
            using (var driver = new ChromeDriver())
            {

                /* Opening Configuration File and Loading Init Data */

                if (File.Exists("configurationfile.xml") == false)
                {
                    throw new Exception("Configuration file do not exists in the program's directory.");
                }

                XmlDocument configurationFile = new XmlDocument();
                configurationFile.Load("configurationfile.xml");

                string projectName = configurationFile.SelectSingleNode("//project").InnerText;
                string settingInProgess = configurationFile.SelectSingleNode("//setting_inprogress").InnerText;
                string settingCompleted = configurationFile.SelectSingleNode("//setting_completed").InnerText;

                if (projectName == String.Empty || settingInProgess == String.Empty || settingCompleted == String.Empty)
                {
                    throw new Exception(String.Format("At least one of the configuration arguments is empty. ProjectName: {0}, SettingInProgressName: {1}, SettingCompletedName: {2}", projectName, settingInProgess, settingCompleted));
                }

                /* Initializing the Driver and Navigating to TMS Home Page */

                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://tms.lionbridge.com/");

                wait.Until(ExpectedConditions.UrlMatches("https://tms.lionbridge.com/"));

                /**/

                TMSProjectsPage tmsProjectsPage = new TMSProjectsPage(driver);
                tmsProjectsPage.ClickChosenProject(projectName);

                TMSProjectHomePage tmsProjectHomePage = new TMSProjectHomePage(driver);
                tmsProjectHomePage.ChangeItemsPerPageToMinimum(driver);

                tmsProjectHomePage.StatusClick();
                TMSStatusPage tmsStatusPage = new TMSStatusPage(driver);

                tmsStatusPage.AssingeeClick();
                TMSAssigneesSubpage tmsAssigneesSubpage = new TMSAssigneesSubpage(driver);

                tmsAssigneesSubpage.InitializeFiltersPanel(driver);

                if (tmsAssigneesSubpage.AssigneeCount == 1)
                {
                    throw new Exception("Activities drop down list is empty. Program now will shut down. ");
                }

                tmsAssigneesSubpage.ChoseActivityOption(driver, settingInProgess);
                tmsAssigneesSubpage = new TMSAssigneesSubpage(driver);

                /*PageNavBar pageNavBar = new PageNavBar(driver);

                if (pageNavBar.ItemsPerPage != null)
                {
                    pageNavBar.ItemsPerPage.ChoseDropDownOption(driver, "1000");
                }*/

                tmsAssigneesSubpage = new TMSAssigneesSubpage(driver);

                AssigneeList assigneeList = new AssigneeList(driver);
                List<AssigneeData> listAssigneeData = new List<AssigneeData>();

                foreach (AssigneeItem assigneeItem in assigneeList.AssigneeItemsList)
                {
                    listAssigneeData.Add(new AssigneeData(assigneeItem));
                }

                assigneeList.TagAllJobs(driver);

                tmsAssigneesSubpage = new TMSAssigneesSubpage(driver);
                tmsAssigneesSubpage.LeftMenu.JobsView.ButtonClick();

                wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("r_L")));

                JobList jobList = new JobList(driver);

                foreach (AssigneeData assigneeData in listAssigneeData)
                {
                    foreach(AssigneeDataElement assigneeDataElement in assigneeData.assigneeDataElements)
                    {
                        
                        string jobName = assigneeDataElement.jobName.Trim();
                        jobList.JobShowHistory(driver, jobName);

                        HistoryPopUp historyPopUp = new HistoryPopUp(driver);
                        historyPopUp.InitializeFiltersPanel(driver);

                        historyPopUp.ChoseSourceLanguageOption(driver, assigneeDataElement.sourceLanguage);
                        historyPopUp.ChoseTargetLanguageOption(driver, assigneeDataElement.targetLanguage);
                        historyPopUp.ChoseActivityOption(driver, settingCompleted);

                        HistoryList historyList = new HistoryList(driver);

                        assigneeDataElement.TranslatorName = historyList.HistoryItemsList[0].HistoryItemElements[0].StepCompletedBy;

                        historyPopUp.CloseButtonClick(driver);
                    }
                }

                //string path = Path.Combine(Directory.GetCurrentDirectory(), "TestFile.xlsx");

                string path = Path.Combine(Directory.GetCurrentDirectory(), "TestFile.csv");

                using (StreamWriter sw = new StreamWriter(path))
                {
                    string[] values1 = { "Job Name", "Reviewer Name", "Translator Name", "Source Language", "Target Language", "WordCount", "Effort" };
                    string line1 = String.Join(";", values1);

                    sw.WriteLine(line1);

                    foreach (var assigneeData in listAssigneeData)
                    {
                        foreach (var assigneeDataElement in assigneeData.assigneeDataElements)
                        {
                            string[] values = { assigneeDataElement.jobName, assigneeDataElement.reviewerName, assigneeDataElement.translatorName, assigneeDataElement.sourceLanguage, assigneeDataElement.targetLanguage, assigneeDataElement.wordcount, assigneeDataElement.effort };
                            string line = String.Join(";", values);

                            sw.WriteLine(line);
                        }
                    }

                    sw.Flush();

                }
            }
        }
    }
}
