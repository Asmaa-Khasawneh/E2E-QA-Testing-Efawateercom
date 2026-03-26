using Final_project_E_Fawatercom.AssistantMethods;
using Final_project_E_Fawatercom.Data;
using Final_project_E_Fawatercom.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_project_E_Fawatercom.TestMethods
{
	[TestClass]
	public class Login_TestMethods
	{
		[ClassInitialize]
		public static void ClassInitislize(TestContext tesContext)
		{
			ManageDriver.MaximizeDriver();
		}

		[ClassCleanup]
		public static void ClassCleanup()
		{
			ManageDriver.CloseDriver();
		}
		//Test success login 
		[TestMethod]
		public void TestSuccessLogin()
		{

			CommonMethods.NavigateToURL(GlobalConstants.loginLink);
			Thread.Sleep(2000);
			Login_AssistantMethods.FillLoginForm("Admin", "123456");

			Thread.Sleep(2000);
			var expectedURL = "http://localhost:4200/admin/home";
			var actualURL = ManageDriver.driver.Url;
			Assert.AreEqual(expectedURL, actualURL, "Actual URL not equal the expected URL_TC1");
			Console.WriteLine("Login Completed Successfully");

		}


	}
}
