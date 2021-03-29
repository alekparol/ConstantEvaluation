using ConstantEvaluation.Data;
using ConstantEvaluation.List_Items.AssigneeItem;
using ConstantEvaluation.Lists;
using ConstantEvaluation.Lists.History_Windows;
using ConstantEvaluation.Pages;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
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

namespace ConstantEvaluation.Utilites
{
    public class CreateSheet
    {

        public void CreateMainSheet()
        {
            /*using (SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Create(path, SpreadsheetDocumentType.Workbook))
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

                workbookpart.Workbook.Save();
            }*/
        }

        public void AppendRow()
        {
            /*var row = new Row() { RowIndex = rowIndex };

            var firstNameCell = new Cell() { CellReference = "A" + (rowIndex + 1) };
            firstNameCell.CellValue = new CellValue(assigneeDataElement.jobName);
            firstNameCell.DataType = CellValues.String;

            row.AppendChild(firstNameCell);

            Cell secondNameCell = new Cell() { CellReference = "B" + (rowIndex + 1) };
            secondNameCell.CellValue = new CellValue(assigneeDataElement.sourceLanguage);
            secondNameCell.DataType = new EnumValue<CellValues>(CellValues.String);

            row.AppendChild(secondNameCell);

            Cell thirdNameCell = new Cell() { CellReference = "C" + (rowIndex + 1) };
            thirdNameCell.CellValue = new CellValue(assigneeDataElement.targetLanguage);
            thirdNameCell.DataType = new EnumValue<CellValues>(CellValues.String);

            row.AppendChild(thirdNameCell);

            Cell fourthNameCell = new Cell() { CellReference = "D" + (rowIndex + 1) };
            fourthNameCell.CellValue = new CellValue(assigneeDataElement.reviewerName);
            fourthNameCell.DataType = new EnumValue<CellValues>(CellValues.String);

            row.AppendChild(fourthNameCell);

            Cell fifthNameCell = new Cell() { CellReference = "E" + (rowIndex + 1) };
            fifthNameCell.CellValue = new CellValue(assigneeDataElement.translatorName);
            fifthNameCell.DataType = new EnumValue<CellValues>(CellValues.String);

            row.AppendChild(fifthNameCell);

            Cell sixthNameCell = new Cell() { CellReference = "F" + (rowIndex + 1) };
            sixthNameCell.CellValue = new CellValue(assigneeDataElement.effort);
            sixthNameCell.DataType = CellValues.String;

            row.AppendChild(sixthNameCell);

            Cell seventhNameCell = new Cell() { CellReference = "G" + (rowIndex + 1) };
            seventhNameCell.CellValue = new CellValue(assigneeDataElement.wordcount);
            seventhNameCell.DataType = CellValues.String;

            row.AppendChild(seventhNameCell);

            sheetData.AppendChild(row);

            rowIndex++;*/
        }
    }
}
