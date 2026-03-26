using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using Final_project_E_Fawatercom.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bytescout.Spreadsheet;
using Final_project_E_Fawatercom.AssistantMethods;
using Final_project_E_Fawatercom.POM;
using OpenQA.Selenium;
using AventStack.ExtentReports.Model;
using static System.Net.Mime.MediaTypeNames;

namespace Final_project_E_Fawatercom.TestMethods
{
	[TestClass]
      public class Categories_TestMethods
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
		public void AddBillerToCategories()
		{
			//create a worksheet to read from excel 
			Worksheet worksheet = CommonMethods.ReadExcel("Categories");
			//create a test 
			var test = extentReports.CreateTest(Convert.ToString(worksheet.Cell(1, 0).Value), Convert.ToString(worksheet.Cell(1, 1).Value));

			try
			{    // login as admin
				Categories_AssistantMethods.TestSuccessLogin();
			
				//start to create new biller 
				Categories_AssistantMethods.CreateNewBillRandomly(1);
				Thread.Sleep(5000);
				//saving the email value in a string to use it in the Assert 
				string savedEmail = Convert.ToString(worksheet.Cell(1, 3).Value);

				//Ensuring that the new biller has been saved in DB 
				Assert.IsTrue(Categories_AssistantMethods.CheckSuccessAdd(savedEmail));
				test.Log(Status.Info, "Added successfylly to the DB");
				test.Pass("Added Biller Successfully");

			 }
			  catch (Exception ex)
				{
					//If Falield 
					test.Fail(ex.Message);

					
					string screenShotPath = CommonMethods.TakeScreenShot();

	
					test.AddScreenCaptureFromPath(screenShotPath);
				}

		}

		[TestMethod]
		public void TestBillerNameField()
		{
			// login as admin
			Categories_AssistantMethods.TestSuccessLogin();
			//create a worksheet to read from excel 
			Worksheet worksheet = CommonMethods.ReadExcel("Categories");
			for (int i = 2; i <= 4; i++)
			{
				Thread.Sleep(2000);
				var test = extentReports.CreateTest(Convert.ToString(worksheet.Cell(i, 0).Value), Convert.ToString(worksheet.Cell(i, 1).Value));

				try
				{
					//start to create new biller 
					Categories_AssistantMethods.CreateNewBillRandomly(i);
					Thread.Sleep(5000);
					switch (i)
					{
						case 2:

							string savedEmaill = Convert.ToString(worksheet.Cell(i, 3).Value);

							Assert.IsTrue(Categories_AssistantMethods.CheckSuccessAdd(savedEmaill));
							test.Log(Status.Info, " added to the DB");
							break;

						case 3:
							var expected = "Cant Enter More Than 100 Character";
							var actual = ManageDriver.driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div/mat-dialog-container/form/div/div/div[1]/mat-error")).Text;
							Assert.AreEqual(expected, actual, "No such constraint ");
							string savedEmail = Convert.ToString(worksheet.Cell(i, 3).Value);

							Assert.IsFalse(Categories_AssistantMethods.CheckSuccessAdd(savedEmail));
							test.Log(Status.Info, "Not added to the DB");
							break;

						case 4:
							var expected1 = "*required";
							var actual2 = ManageDriver.driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div/mat-dialog-container/form/div/div/div[1]/mat-error")).Text;
							Assert.AreEqual(expected1, actual2);

							string savedEmail1 = Convert.ToString(worksheet.Cell(i, 3).Value);

							Assert.IsFalse(Categories_AssistantMethods.CheckSuccessAdd(savedEmail1));
							test.Log(Status.Info, "Not added to the DB");
							break;
					}

					test.Pass($"Test case{i} passed ");








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
		public void TestEmailField()
		{

			Categories_AssistantMethods.TestSuccessLogin();
			Thread.Sleep(2000);
			Worksheet worksheet = CommonMethods.ReadExcel("Categories");


			for (int i = 5; i <= 10; i++)
			{
				var test = extentReports.CreateTest(Convert.ToString(worksheet.Cell(i, 0).Value), Convert.ToString(worksheet.Cell(i, 1).Value));
				try
				{
					//start to create new biller 
					Categories_AssistantMethods.CreateNewBillRandomly(i);
					Thread.Sleep(5000);
					switch (i)
					{
						case 5:

							string savedEmaill = Convert.ToString(worksheet.Cell(i, 3).Value);

							Assert.IsTrue(Categories_AssistantMethods.CheckSuccessAdd(savedEmaill));
							test.Log(Status.Info, " added to the DB");

							break;

						case 6:
							var expected = "*emeil required";
							var actual = ManageDriver.driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div/mat-dialog-container/form/div/div/div[2]/mat-error")).Text;
							Assert.AreEqual(expected, actual, "No such constraint ");

							string savedEmail = Convert.ToString(worksheet.Cell(i, 3).Value);
							Assert.IsFalse(Categories_AssistantMethods.CheckSuccessAdd(savedEmail));
							test.Log(Status.Info, "Not added to the DB");
							break;

						case 7:
							var expected1 = "*emeil required";
							var actual2 = ManageDriver.driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div/mat-dialog-container/form/div/div/div[2]/mat-error")).Text;
							Assert.AreEqual(expected1, actual2, "No such constraint ");

							string savedEmail1 = Convert.ToString(worksheet.Cell(i, 3).Value);

							Assert.IsFalse(Categories_AssistantMethods.CheckSuccessAdd(savedEmail1));
							test.Log(Status.Info, "Not added to the DB");
							break;

						case 8:
							var expected11 = "*emeil required";
							var actual12 = ManageDriver.driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div/mat-dialog-container/form/div/div/div[2]/mat-error")).Text;
							Assert.AreEqual(expected11, actual12, "No such constraint ");

							string savedEmail11 = Convert.ToString(worksheet.Cell(i, 3).Value);

							Assert.IsFalse(Categories_AssistantMethods.CheckSuccessAdd(savedEmail11));
							test.Log(Status.Info, "Not added to the DB");
							break;
						case 9:
							var expected12 = "*emeil required";
							var actual22 = ManageDriver.driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div/mat-dialog-container/form/div/div/div[2]/mat-error")).Text;
							Assert.AreEqual(expected12, actual22, "No such constraint ");

							string savedEmail12 = Convert.ToString(worksheet.Cell(i, 4).Value);

							Assert.IsFalse(Categories_AssistantMethods.CheckSuccessAdd(savedEmail12));
							test.Log(Status.Info, "Not added to the DB");
							break;
						case 10:
							var expected14 = "*required";
							var actual24 = ManageDriver.driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div/mat-dialog-container/form/div/div/div[2]/mat-error")).Text;
							Assert.AreEqual(expected14, actual24, "No such constraint ");

							string savedEmail14 = Convert.ToString(worksheet.Cell(i, 4).Value);

							Assert.IsFalse(Categories_AssistantMethods.CheckSuccessAdd(savedEmail14));
							test.Log(Status.Info, "Not added to the DB");
							break;
					}



					CommonMethods.NavigateToURL("http://localhost:4200/admin/home");
					test.Pass($"Test case{i} passed ");
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
		public void TestLocationField()
		{
			// login as admin
			Categories_AssistantMethods.TestSuccessLogin();
			//create a worksheet to read from excel 
			Worksheet worksheet = CommonMethods.ReadExcel("Categories");
			for (int i = 11; i <= 13; i++)
			{
				Thread.Sleep(2000);
				var test = extentReports.CreateTest(Convert.ToString(worksheet.Cell(i, 0).Value), Convert.ToString(worksheet.Cell(i, 1).Value));

				try
				{
					//start to create new biller 
					Categories_AssistantMethods.CreateNewBillRandomly(i);
					Thread.Sleep(5000);
					switch (i)
					{
						case 11:

							string savedEmaill = Convert.ToString(worksheet.Cell(i, 3).Value);

							Assert.IsTrue(Categories_AssistantMethods.CheckSuccessAdd(savedEmaill));
							test.Log(Status.Info, " added to the DB");
							break;

						case 12:
							var expected = "Cant Enter More Than 100 Character";
							var actual = ManageDriver.driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div/mat-dialog-container/form/div/div/div[3]/mat-error")).Text;
							Assert.AreEqual(expected, actual, "No such constraint ");
							string savedEmail = Convert.ToString(worksheet.Cell(i, 3).Value);

							Assert.IsFalse(Categories_AssistantMethods.CheckSuccessAdd(savedEmail));
							test.Log(Status.Info, "Not added to the DB");
							break;

						case 13:
							var expected1 = "*required";
							var actual2 = ManageDriver.driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div/mat-dialog-container/form/div/div/div[3]/mat-error")).Text;
							Assert.AreEqual(expected1, actual2);

							string savedEmail1 = Convert.ToString(worksheet.Cell(i, 3).Value);

							Assert.IsFalse(Categories_AssistantMethods.CheckSuccessAdd(savedEmail1));
							test.Log(Status.Info, "Not added to the DB");
							break;
					}

					test.Pass($"Test case{i} passed ");








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










