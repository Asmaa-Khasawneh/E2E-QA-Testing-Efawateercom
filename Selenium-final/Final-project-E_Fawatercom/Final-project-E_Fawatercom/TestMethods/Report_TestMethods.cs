using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using Final_project_E_Fawatercom.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_project_E_Fawatercom.AssistantMethods;
using Final_project_E_Fawatercom.Data;
using Bytescout.Spreadsheet;
using Final_project_E_Fawatercom.POM;
using OpenQA.Selenium;

namespace Final_project_E_Fawatercom.TestMethods
{

	[TestClass]
	public class Report_TestMethods
	{
		public static ExtentReports extentReports = new ExtentReports();
		public static ExtentHtmlReporter reporter = new ExtentHtmlReporter("C:\\Users\\USER\\Documents\\Final-Selenium-TestReport\\");

		[ClassInitialize]
		public static void ClassInitislize(TestContext tesContext)
		{
			extentReports.AttachReporter(reporter);
			ManageDriver.MaximizeDriver();
		}

		[ClassCleanup]
		public static void ClassCleanup()
		{
			extentReports.Flush();
			ManageDriver.CloseDriver();
		}

		[TestMethod]
		public void TestCountPayForWater()
		{
			var test = extentReports.CreateTest("TestCountPayForWater", "The count pay that displayed in the website should be the same of the DB");
			Report_AssistantMethods.TestSuccessLogin();
			Manage_Report manage_Report = new Manage_Report(ManageDriver.driver);
			manage_Report.ClickReportButton();

			manage_Report.ClickListButton("Water1");

			var expected = "7";
			var actual = Report_AssistantMethods.CheckCountPay(1);

			// If necessary, keep the delay, but consider removing if not needed
			Thread.Sleep(3000);

			// Asserting that the actual value matches the expected value
			Assert.AreEqual(expected, actual, "Not Accurate Count Pay");
			test.Log(Status.Info, "The Cout Pay Correct");




		}

		[TestMethod]
		public void TestCountPayForElectricity()
		{
			var test = extentReports.CreateTest("TestCountPayForElectricity", "The count pay that displayed in the website should be the same of the DB");
			Report_AssistantMethods.TestSuccessLogin();
			Manage_Report manage_Report = new Manage_Report(ManageDriver.driver);
			manage_Report.ClickReportButton();

			manage_Report.ClickListButton("Electricity");

			var expected = "2";
			var actual = Report_AssistantMethods.CheckCountPay(3);

			// If necessary, keep the delay, but consider removing if not needed
			Thread.Sleep(3000);

			// Asserting that the actual value matches the expected value
			Assert.AreEqual(expected, actual, "Not Accurate Count Pay");
			test.Log(Status.Info, "The Cout Pay Correct");




		}
		[TestMethod]
		public void TestCountPayForTelecommunication()
		{
			var test = extentReports.CreateTest("TestCountPayForTelecommunication", "The count pay that displayed in the website should be the same of the DB");
			Report_AssistantMethods.TestSuccessLogin();
			Manage_Report manage_Report = new Manage_Report(ManageDriver.driver);
			manage_Report.ClickReportButton();

			manage_Report.ClickListButton("Telecommunication");

			var expected = "6";
			var actual = Report_AssistantMethods.CheckCountPay(4);

			// If necessary, keep the delay, but consider removing if not needed
			Thread.Sleep(3000);

			// Asserting that the actual value matches the expected value
			Assert.AreEqual(expected, actual, "Not Accurate Count Pay");
			test.Log(Status.Info, "The Cout Pay Correct");




		}
		[TestMethod]
		public void TestCountPayForEducation()
		{
			var test = extentReports.CreateTest("TestCountPayForEducation", "The count pay that displayed in the website should be the same of the DB");
			Report_AssistantMethods.TestSuccessLogin();
			Manage_Report manage_Report = new Manage_Report(ManageDriver.driver);
			manage_Report.ClickReportButton();

			manage_Report.ClickListButton("Education");

			var expected = "6";
			var actual = Report_AssistantMethods.CheckCountPay(4);

			// If necessary, keep the delay, but consider removing if not needed
			Thread.Sleep(3000);

			// Asserting that the actual value matches the expected value
			Assert.AreEqual(expected, actual, "Not Accurate Count Pay");
			test.Log(Status.Info, "The Cout Pay Correct");




		}

		[TestMethod]
		public void TestSumProfitForWater()
		{
			var test = extentReports.CreateTest("TestProfitForWater", "The profit that displayed in the website should be the same of the DB");
			Report_AssistantMethods.TestSuccessLogin();
			Manage_Report manage_Report = new Manage_Report(ManageDriver.driver);
			manage_Report.ClickReportButton();

			manage_Report.ClickListButton("Water1");

			var expected = "35";
			var actual = Report_AssistantMethods.CheckSumProfit(1);

			// If necessary, keep the delay, but consider removing if not needed
			Thread.Sleep(3000);

			// Asserting that the actual value matches the expected value
			Assert.AreEqual(expected, actual, "Not Accurate Profit");
			test.Log(Status.Info, "The Profit Correct");




		}
		
		[TestMethod]
		public void TestSumProfitForElectricity()
		{
			var test = extentReports.CreateTest("TestProfitForElectricity", "The profit that displayed in the website should be the same of the DB");
			Report_AssistantMethods.TestSuccessLogin();
			Manage_Report manage_Report = new Manage_Report(ManageDriver.driver);
			manage_Report.ClickReportButton();

			manage_Report.ClickListButton("Electricity");

			var expected = "4";
			var actual = Report_AssistantMethods.CheckSumProfit(3);

			// If necessary, keep the delay, but consider removing if not needed
			Thread.Sleep(3000);

			// Asserting that the actual value matches the expected value
			Assert.AreEqual(expected, actual, "Not Accurate Profit");
			test.Log(Status.Info, "The Profit Correct");




		}

		[TestMethod]
		public void TestSumProfitForTelecommunication()
		{
			var test = extentReports.CreateTest("TestProfitForTelecommunication", "The profit that displayed in the website should be the same of the DB");
			Report_AssistantMethods.TestSuccessLogin();
			Manage_Report manage_Report = new Manage_Report(ManageDriver.driver);
			manage_Report.ClickReportButton();

			manage_Report.ClickListButton("Telecommunication");

			var expected = "8";
			var actual = Report_AssistantMethods.CheckSumProfit(2);

			// If necessary, keep the delay, but consider removing if not needed
			Thread.Sleep(3000);

			// Asserting that the actual value matches the expected value
			Assert.AreEqual(expected, actual, "Not Accurate Profit");
			test.Log(Status.Info, "The Profit Correct");




		}
		
		[TestMethod]
		public void TestSumProfitForEducation()
		{
			var test = extentReports.CreateTest("TestProfitForEducation", "The profit that displayed in the website should be the same of the DB");
			Report_AssistantMethods.TestSuccessLogin();
			Manage_Report manage_Report = new Manage_Report(ManageDriver.driver);
			manage_Report.ClickReportButton();

			manage_Report.ClickListButton("Education");

			var expected = "16";
			var actual = Report_AssistantMethods.CheckSumProfit(4);

			// If necessary, keep the delay, but consider removing if not needed
			Thread.Sleep(3000);

			// Asserting that the actual value matches the expected value
			Assert.AreEqual(expected, actual, "Not Accurate Profit");
			test.Log(Status.Info, "The Profit Correct");




		}

		[TestMethod]
		public void TestWaterReportByDate()
		{
			Report_AssistantMethods.TestSuccessLogin();
			Manage_Report manage_Report = new Manage_Report(ManageDriver.driver);
			manage_Report.ClickReportButton();
			Worksheet worksheet = CommonMethods.ReadExcel("Report ");
			for (int i = 1; i <= 3; i++)
			{
				Thread.Sleep(2000);
				var test = extentReports.CreateTest(Convert.ToString(worksheet.Cell(i, 0).Value), Convert.ToString(worksheet.Cell(i, 1).Value));
				try
				{
				

					switch (i){

						case 1:
							manage_Report.EnterFirstDate(Convert.ToString(worksheet.Cell(i, 2).Value));
							manage_Report.EnterSecondDate(Convert.ToString(worksheet.Cell(i, 3).Value));
							manage_Report.ClickDescoverButton();
									Thread.Sleep(2000);


							var expected = Report_AssistantMethods.CountTableRows();
							var actual = Report_AssistantMethods.CheckNumberOfInvoices(1);
							Assert.AreEqual(expected, actual, "Faild");
							test.Log(Status.Info, "Correct invoicis");
							break;
						case 2:

							manage_Report.EnterFirstDate(Convert.ToString(worksheet.Cell(i, 2).Value));
							manage_Report.EnterSecondDate(Convert.ToString(worksheet.Cell(i, 3).Value));
							Thread.Sleep(2000);
							var expected2 = Report_AssistantMethods.CountTableRows();
							var actual2 = Report_AssistantMethods.CheckNumberOfInvoices(1);
							Assert.AreEqual(expected2, actual2, "Faild");
							test.Log(Status.Info, "Correct invoicis");
							break;
						case 3:
							manage_Report.EnterFirstDate(Convert.ToString(worksheet.Cell(i, 2).Value));
							manage_Report.EnterSecondDate(Convert.ToString(worksheet.Cell(i, 3).Value));
							Thread.Sleep(2000);

							var expected3 = Report_AssistantMethods.CountTableRows();
							var actual3 = Report_AssistantMethods.CheckNumberOfInvoices(1);
							Assert.AreEqual(expected3, actual3, "Faild");
							test.Log(Status.Info, "Correct invoicis");
							break;


					}
					CommonMethods.NavigateToURL("http://localhost:4200/admin/report");

				}

				catch (Exception ex)
				{
					//If Falield 
					test.Fail(ex.Message);


					string screenShotPath = CommonMethods.TakeScreenShot();


					test.AddScreenCaptureFromPath(screenShotPath);
				}
			}



		}

		[TestMethod]
		public void TestElectricityReportByDate()
		{
			Report_AssistantMethods.TestSuccessLogin();
			Manage_Report manage_Report = new Manage_Report(ManageDriver.driver);
			manage_Report.ClickReportButton();
			Worksheet worksheet = CommonMethods.ReadExcel("Report ");
			for (int i = 4; i <= 6; i++)
			{
				Thread.Sleep(2000);
				var test = extentReports.CreateTest(Convert.ToString(worksheet.Cell(i, 0).Value), Convert.ToString(worksheet.Cell(i, 1).Value));
				try
				{


					switch (i)
					{

						case 4:
							manage_Report.EnterFirstDate(Convert.ToString(worksheet.Cell(i, 2).Value));
							manage_Report.EnterSecondDate(Convert.ToString(worksheet.Cell(i, 3).Value));
							manage_Report.ClickDescover2Button();
							Thread.Sleep(2000);


							var expected = Report_AssistantMethods.CountTableRows();
							var actual = Report_AssistantMethods.CheckNumberOfInvoices(3);
							Assert.AreEqual(expected, actual, "Faild");
							test.Log(Status.Info, "Correct invoicis");
							break;
						case 5:

							manage_Report.EnterFirstDate(Convert.ToString(worksheet.Cell(i, 2).Value));
							manage_Report.EnterSecondDate(Convert.ToString(worksheet.Cell(i, 3).Value));
							Thread.Sleep(2000);
							var expected2 = Report_AssistantMethods.CountTableRows();
							var actual2 = Report_AssistantMethods.CheckNumberOfInvoices(3);
							Assert.AreEqual(expected2, actual2, "Faild");
							test.Log(Status.Info, "Correct invoicis");
							break;
						case 6:
							manage_Report.EnterFirstDate(Convert.ToString(worksheet.Cell(i, 2).Value));
							manage_Report.EnterSecondDate(Convert.ToString(worksheet.Cell(i, 3).Value));
							Thread.Sleep(2000);

							var expected3 = Report_AssistantMethods.CountTableRows();
							var actual3 = Report_AssistantMethods.CheckNumberOfInvoices(3);
							Assert.AreEqual(expected3, actual3, "Faild");
							test.Log(Status.Info, "Correct invoicis");
							break;


					}
					CommonMethods.NavigateToURL("http://localhost:4200/admin/report");

				}

				catch (Exception ex)
				{
					//If Falield 
					test.Fail(ex.Message);


					string screenShotPath = CommonMethods.TakeScreenShot();


					test.AddScreenCaptureFromPath(screenShotPath);
				}
			}



		}


		[TestMethod]
		public void TestTelecommunicationReportByDate()
		{
			Report_AssistantMethods.TestSuccessLogin();
			Manage_Report manage_Report = new Manage_Report(ManageDriver.driver);
			manage_Report.ClickReportButton();
			Worksheet worksheet = CommonMethods.ReadExcel("Report ");
			for (int i = 7; i <= 9; i++)
			{
				Thread.Sleep(2000);
				var test = extentReports.CreateTest(Convert.ToString(worksheet.Cell(i, 0).Value), Convert.ToString(worksheet.Cell(i, 1).Value));
				try
				{


					switch (i)
					{

						case 7:
							manage_Report.EnterFirstDate(Convert.ToString(worksheet.Cell(i, 2).Value));
							manage_Report.EnterSecondDate(Convert.ToString(worksheet.Cell(i, 3).Value));
							manage_Report.ClickDescover3Button();
							Thread.Sleep(2000);


							var expected = Report_AssistantMethods.CountTableRows();
							var actual = Report_AssistantMethods.CheckNumberOfInvoices(2);
							Assert.AreEqual(expected, actual, "Faild");
							test.Log(Status.Info, "Correct invoicis");
							break;
						case 8:

							manage_Report.EnterFirstDate(Convert.ToString(worksheet.Cell(i, 2).Value));
							manage_Report.EnterSecondDate(Convert.ToString(worksheet.Cell(i, 3).Value));
							Thread.Sleep(2000);
							var expected2 = Report_AssistantMethods.CountTableRows();
							var actual2 = Report_AssistantMethods.CheckNumberOfInvoices(2);
							Assert.AreEqual(expected2, actual2, "Faild");
							test.Log(Status.Info, "Correct invoicis");
							break;
						case 9:
							manage_Report.EnterFirstDate(Convert.ToString(worksheet.Cell(i, 2).Value));
							manage_Report.EnterSecondDate(Convert.ToString(worksheet.Cell(i, 3).Value));
							Thread.Sleep(2000);

							var expected3 = Report_AssistantMethods.CountTableRows();
							var actual3 = Report_AssistantMethods.CheckNumberOfInvoices(2);
							Assert.AreEqual(expected3, actual3, "Faild");
							test.Log(Status.Info, "Correct invoicis");
							break;


					}
					CommonMethods.NavigateToURL("http://localhost:4200/admin/report");

				}

				catch (Exception ex)
				{
					//If Falield 
					test.Fail(ex.Message);


					string screenShotPath = CommonMethods.TakeScreenShot();


					test.AddScreenCaptureFromPath(screenShotPath);
				}
			}



		}

		[TestMethod]
		public void TestEducationReportByDate()
		{
			Report_AssistantMethods.TestSuccessLogin();
			Manage_Report manage_Report = new Manage_Report(ManageDriver.driver);
			manage_Report.ClickReportButton();
			Worksheet worksheet = CommonMethods.ReadExcel("Report ");
			for (int i = 10; i <= 12; i++)
			{
				Thread.Sleep(2000);
				var test = extentReports.CreateTest(Convert.ToString(worksheet.Cell(i, 0).Value), Convert.ToString(worksheet.Cell(i, 1).Value));
				try
				{


					switch (i)
					{

						case 10:
							manage_Report.EnterFirstDate(Convert.ToString(worksheet.Cell(i, 2).Value));
							manage_Report.EnterSecondDate(Convert.ToString(worksheet.Cell(i, 3).Value));
							manage_Report.ClickDescover4Button();
							Thread.Sleep(2000);


							var expected = Report_AssistantMethods.CountTableRows();
							var actual = Report_AssistantMethods.CheckNumberOfInvoices(4);
							Assert.AreEqual(expected, actual, "Faild");
							test.Log(Status.Info, "Correct invoicis");
							break;
						case 11:

							manage_Report.EnterFirstDate(Convert.ToString(worksheet.Cell(i, 2).Value));
							manage_Report.EnterSecondDate(Convert.ToString(worksheet.Cell(i, 3).Value));
							Thread.Sleep(2000);
							var expected2 = Report_AssistantMethods.CountTableRows();
							var actual2 = Report_AssistantMethods.CheckNumberOfInvoices(4);
							Assert.AreEqual(expected2, actual2, "Faild");
							test.Log(Status.Info, "Correct invoicis");
							break;
						case 12:
							manage_Report.EnterFirstDate(Convert.ToString(worksheet.Cell(i, 2).Value));
							manage_Report.EnterSecondDate(Convert.ToString(worksheet.Cell(i, 3).Value));
							Thread.Sleep(2000);

							var expected3 = Report_AssistantMethods.CountTableRows();
							var actual3 = Report_AssistantMethods.CheckNumberOfInvoices(4);
							Assert.AreEqual(expected3, actual3, "Faild");
							test.Log(Status.Info, "Correct invoicis");
							break;


					}
					CommonMethods.NavigateToURL("http://localhost:4200/admin/report");

				}

				catch (Exception ex)
				{
					//If Falield 
					test.Fail(ex.Message);


					string screenShotPath = CommonMethods.TakeScreenShot();


					test.AddScreenCaptureFromPath(screenShotPath);
				}
			}



		}

	}
}
