using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using Final_project_E_Fawatercom.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bytescout.Spreadsheet;
using OpenQA.Selenium;
using Final_project_E_Fawatercom.AssistantMethods;
using Final_project_E_Fawatercom.POM;
using Final_project_E_Fawatercom.Data;

namespace Final_project_E_Fawatercom.TestMethods
{

	[TestClass]
	public class Profile_TestMethods
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
		public void TestNameField()
		{
			Profile_AssesstantMethod.TestSuccessLogin();
			Manage_Profile manage_Profile = new Manage_Profile(ManageDriver.driver);
			manage_Profile.ClickProfileButton();
			Thread.Sleep(2000);
			Worksheet worksheet = CommonMethods.ReadExcel("Profile");

			for (int i = 1; i <= 3; i++)
			{
				CommonMethods.NavigateToURL("http://localhost:4200/admin/account");
				Thread.Sleep(2000);

				var test = extentReports.CreateTest(Convert.ToString(worksheet.Cell(i, 0).Value), Convert.ToString(worksheet.Cell(i, 1).Value));

				try
				{
					
					ProfileForm form = Profile_AssesstantMethod.FillMessageFormFromExel(i);
					Profile_AssesstantMethod.FillMessageForm(form);
					Thread.Sleep(5000);

					switch (i)
					{
						case 1:
							Assert.IsTrue(Profile_AssesstantMethod.CheckSuccessChangedName(Convert.ToString(worksheet.Cell(i, 2).Value)));
							test.Log(Status.Info, " added to the DB");

							break;

						case 2:
							Assert.IsFalse(Profile_AssesstantMethod.CheckSuccessChangedName(Convert.ToString(worksheet.Cell(i, 2).Value)));
							test.Log(Status.Info, " Not added to the DB");
							break;

						case 3:
							Assert.IsFalse(Profile_AssesstantMethod.CheckSuccessChangedName(Convert.ToString(worksheet.Cell(i, 2).Value)));
							test.Log(Status.Info, "Not  added to the DB");
							break;

					}

					test.Pass($"TC{i} is correct ");
				

				}


				catch (Exception ex)
				{

					test.Fail(ex.Message);


					string screenShotPath = CommonMethods.TakeScreenShot();


					test.AddScreenCaptureFromPath(screenShotPath);
				}

			}

		}

	}
}
