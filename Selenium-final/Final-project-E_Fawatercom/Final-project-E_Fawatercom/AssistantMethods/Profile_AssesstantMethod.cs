using Bytescout.Spreadsheet;
using Final_project_E_Fawatercom.Data;
using Final_project_E_Fawatercom.Helpers;
using Final_project_E_Fawatercom.POM;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Final_project_E_Fawatercom.AssistantMethods
{
	public class Profile_AssesstantMethod
	{
		public static void TestSuccessLogin()
		{

			CommonMethods.NavigateToURL(GlobalConstants.loginLink);
			Thread.Sleep(2000);
			Login_AssistantMethods.FillLoginForm("Admin", "123456");
		}

		public static void FillMessageForm(ProfileForm form)
		{
			Manage_Profile manage_Profile=new Manage_Profile(ManageDriver.driver);
			manage_Profile.EnterFullName(form.fullname);
			manage_Profile.EnterPhoneNumber(form.phone);
			manage_Profile.EnterEmail(form.email);
			manage_Profile.EnterCurrentPass(form.currentpass);
			manage_Profile.EnterAdress(form.address);
			manage_Profile.EnterUserName(form.username);
			manage_Profile.EnterNewPass(form.newpass);
			manage_Profile.ClickUpdateButton();

		}

		public static ProfileForm FillMessageFormFromExel(int row)
		{
			ProfileForm form = new ProfileForm();
			Worksheet worksheet = CommonMethods.ReadExcel("Profile");
			form.fullname = Convert.ToString(worksheet.Cell(row, 2).Value);
			form.phone = Convert.ToString(worksheet.Cell(row, 3).Value);
			form.email = Convert.ToString(worksheet.Cell(row, 4).Value);
			form.currentpass = Convert.ToString(worksheet.Cell(row, 5).Value);
			form.address = Convert.ToString(worksheet.Cell(row, 6).Value);
			form.username = Convert.ToString(worksheet.Cell(row, 7).Value);
			form.newpass = Convert.ToString(worksheet.Cell(row, 8).Value);
			return form;
		}

		public static bool CheckSuccessChangedName(string name)
		{
			bool isDataExist = false;


			string query = "SELECT count(*) From loginf where username= :value";

			using (OracleConnection connection = new OracleConnection(GlobalConstants.connectionString))
			{

				connection.Open();

				OracleCommand command = new OracleCommand(query, connection);


				command.Parameters.Add(new OracleParameter(":value", name));

				int result = Convert.ToInt32(command.ExecuteScalar());

				isDataExist = result > 0;

				return isDataExist;

			}
		}
	}
}
