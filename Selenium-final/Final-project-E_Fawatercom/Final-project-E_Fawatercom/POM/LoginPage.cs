using Final_project_E_Fawatercom.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_project_E_Fawatercom.POM
{
	public class LoginPage
	{


		IWebDriver _driver;

		public LoginPage(IWebDriver driver)
		{
			_driver = driver;
		}

		By userName = By.XPath("//form/input[@type='email']");
		By password = By.XPath("//form/input[@type='password']");
		By submit = By.XPath("//button[@class=\"text-center btn btn-info btn-block LoginBtn\"]");

		public void EnterUserName(string value)
		{
			IWebElement element = CommonMethods.WaitAndFindElement(userName);
			CommonMethods.HighlightElement(element);
			element.SendKeys(value);


		}
		public void EnterPassword(string value)
		{
			IWebElement element = CommonMethods.WaitAndFindElement(password);
			CommonMethods.HighlightElement(element);
			element.SendKeys(value);


		}
		public void ClickLoginButton()
		{
			IWebElement element = CommonMethods.WaitAndFindElement(submit);

			element.Click();
		}

	}
}
