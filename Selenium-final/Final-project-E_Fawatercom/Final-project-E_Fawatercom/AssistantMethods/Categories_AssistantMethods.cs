using AventStack.ExtentReports.Model;
using Bytescout.Spreadsheet;
using Final_project_E_Fawatercom.Data;
using Final_project_E_Fawatercom.Helpers;
using Final_project_E_Fawatercom.POM;
using OpenQA.Selenium;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Final_project_E_Fawatercom.AssistantMethods
{
	public class Categories_AssistantMethods
	{
		public static void TestSuccessLogin()
		{

			CommonMethods.NavigateToURL(GlobalConstants.loginLink);
			Thread.Sleep(2000);
			Login_AssistantMethods.FillLoginForm("Admin", "123456");
		}

		public static void CreateNewBillRandomly(int row)
		{
			Worksheet worksheet = CommonMethods.ReadExcel("Categories");

			Manage_Categories manage_Categories = new Manage_Categories(ManageDriver.driver);
			List<Action> billerActions = new List<Action>
			{
			manage_Categories.ClickWaterBillerButton,
			manage_Categories.ClickElectricityBillerButton,
			manage_Categories.ClickEducationBillerButton,
			manage_Categories.ClickTelecommunicationBillerButton
				};
			// Initialize random number generator
				Random random = new Random();

			// Pick a random index and invoke the corresponding method
				int randomIndex = random.Next(0, billerActions.Count);
				billerActions[randomIndex].Invoke();

			manage_Categories.EnterBillName(Convert.ToString(worksheet.Cell(row, 2).Value));
			manage_Categories.EnterEmail(Convert.ToString(worksheet.Cell(row, 3).Value));
			manage_Categories.EnterLocation(Convert.ToString(worksheet.Cell(row, 4).Value));
			manage_Categories.ClickSubmitButton();
		}

		

		public static bool CheckSuccessAdd(string email)
		{
			bool isDataExist = false;


			string query = "select count (*)\r\nfrom billername \r\nwhere email= :value";

			using (OracleConnection connection = new OracleConnection(GlobalConstants.connectionString))
			{

				connection.Open();

				OracleCommand command = new OracleCommand(query, connection);


				command.Parameters.Add(new OracleParameter(":value", email));

				int result = Convert.ToInt32(command.ExecuteScalar());

				isDataExist = result > 0;

				return isDataExist;

			}
		}

	}
}
