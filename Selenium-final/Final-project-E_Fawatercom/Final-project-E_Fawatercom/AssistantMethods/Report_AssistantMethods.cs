using Final_project_E_Fawatercom.Data;
using Final_project_E_Fawatercom.Helpers;
using OpenQA.Selenium;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_project_E_Fawatercom.AssistantMethods
{
	public class Report_AssistantMethods
	{

		public static void TestSuccessLogin()
		{

			CommonMethods.NavigateToURL(GlobalConstants.loginLink);
			Thread.Sleep(2000);
			Login_AssistantMethods.FillLoginForm("Admin", "123456");
		}

		public static string CheckCountPay(int id)
		{
			// The SQL query to count payments
			string query = "SELECT COUNT(*) FROM paymenthistory WHERE billerid = :value";

			// Use an Oracle connection (ensure GlobalConstants.connectionString is correct)
			using (OracleConnection connection = new OracleConnection(GlobalConstants.connectionString))
			{
				connection.Open();

				// Create OracleCommand with parameterized query
				OracleCommand command = new OracleCommand(query, connection);

				// Add the parameter for billerid
				command.Parameters.Add(new OracleParameter(":value", id));

				// Execute the query and return the count as a string
				string result = command.ExecuteScalar().ToString();

				return result; // Return the count of payment history records as a string
			}
		}
		public static string CheckSumProfit(int id)
		{
			// The SQL query to sum profits
			string query = "SELECT SUM(profits) FROM paymenthistory WHERE billerid = :value";

			// Use an Oracle connection (ensure GlobalConstants.connectionString is correct)
			using (OracleConnection connection = new OracleConnection(GlobalConstants.connectionString))
			{
				connection.Open();

				// Create OracleCommand with parameterized query
				OracleCommand command = new OracleCommand(query, connection);

				// Add the parameter for billerid
				command.Parameters.Add(new OracleParameter(":value", id));

				// Execute the query and handle possible null result
				object result = command.ExecuteScalar();

				// Check if the result is null and return "0" if no profits found, otherwise return the result as a string
				return result != DBNull.Value ? result.ToString() : "0";
			}
		}

		public static int CountTableRows()
		{
			// Locate the table (replace with the correct XPath or locator for your table)
			IWebElement tableElement = ManageDriver.driver.FindElement(By.XPath("/html/body/app-root/app-detels/div/div/div/div/table/tbody"));

			// Find all rows inside the table's tbody
			IList<IWebElement> rows = tableElement.FindElements(By.TagName("tr"));

			// Return the count of rows
			return rows.Count;
		}

		public static int CheckNumberOfInvoices(int id)
		{
			// The SQL query to count invoices
			string query = "SELECT COUNT(*) FROM paymenthistory WHERE billerid = :value AND userid IS NOT NULL";

			// Use an Oracle connection (ensure GlobalConstants.connectionString is correct)
			using (OracleConnection connection = new OracleConnection(GlobalConstants.connectionString))
			{
				connection.Open();

				// Create OracleCommand with parameterized query
				OracleCommand command = new OracleCommand(query, connection);

				// Add the parameter for billerid
				command.Parameters.Add(new OracleParameter(":value", id));

				// Execute the query and return the result as an integer
				int result = Convert.ToInt32(command.ExecuteScalar());

				return result; // Return the count of invoices
			}
		}


	}
}
