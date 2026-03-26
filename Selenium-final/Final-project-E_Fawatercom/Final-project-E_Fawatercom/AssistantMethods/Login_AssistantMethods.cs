using Final_project_E_Fawatercom.Helpers;
using Final_project_E_Fawatercom.POM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_project_E_Fawatercom.AssistantMethods
{
	public class Login_AssistantMethods
	{
		public static void FillLoginForm(string username, string password)
		{
			LoginPage loginPage = new LoginPage(ManageDriver.driver);
			loginPage.EnterUserName(username);
			loginPage.EnterPassword(password);
			loginPage.ClickLoginButton();

		}
	}
}
