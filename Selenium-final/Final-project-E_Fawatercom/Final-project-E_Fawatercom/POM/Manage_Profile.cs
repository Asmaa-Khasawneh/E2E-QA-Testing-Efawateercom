using Final_project_E_Fawatercom.Helpers;
using Microsoft.CodeAnalysis;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_project_E_Fawatercom.POM
{
	public class Manage_Profile
	{
		IWebDriver _driver;

		public Manage_Profile(IWebDriver driver)
		{
			_driver = driver;
		}

		By profileButton = By.XPath("//div/div/ul/li[7]/a");
		By fullName = By.XPath("//div/form/div/div/div[1]/div/input");
		By phoneNumber = By.XPath("//div/form/div/div/div[2]/div/input");
		By email = By.XPath("//div/form/div/div/div[3]/div/input");
		By currentPass = By.XPath("//div/form/div/div/div[4]/div/input");
		By address = By.XPath("//div/form/div/div/div[5]/div/input");
		By username = By.XPath("//div/form/div/div/div[6]/div/input");
		By newPass = By.XPath("//div/form/div/div/div[7]/div/input");
		By updateButton = By.XPath("//div/div[9]/div/div[2]/div/button");

		public void ClickProfileButton()
		{
			IWebElement element = CommonMethods.WaitAndFindElement(profileButton);

			element.Click();
		}
		public void EnterFullName(string value)
		{
			IWebElement element = CommonMethods.WaitAndFindElement(fullName);
			CommonMethods.HighlightElement(element);
			element.SendKeys(value);


		}

		public void EnterPhoneNumber(string value)
		{
			IWebElement element = CommonMethods.WaitAndFindElement(phoneNumber);
			CommonMethods.HighlightElement(element);
			element.SendKeys(value);


		}
		public void EnterEmail(string value)
		{
			IWebElement element = CommonMethods.WaitAndFindElement(email);
			CommonMethods.HighlightElement(element);
			element.SendKeys(value);


		}
		public void EnterCurrentPass(string value)
		{
			IWebElement element = CommonMethods.WaitAndFindElement(currentPass);
			CommonMethods.HighlightElement(element);
			element.SendKeys(value);


		}
		public void EnterAdress(string value)
		{
			IWebElement element = CommonMethods.WaitAndFindElement(address);
			CommonMethods.HighlightElement(element);
			element.SendKeys(value);


		}
		public void EnterUserName(string value)
		{
			IWebElement element = CommonMethods.WaitAndFindElement(username);
			CommonMethods.HighlightElement(element);
			element.SendKeys(value);


		}
		public void EnterNewPass(string value)
		{
			IWebElement element = CommonMethods.WaitAndFindElement(newPass);
			CommonMethods.HighlightElement(element);
			element.SendKeys(value);


		}
		public void ClickUpdateButton()
		{
			IWebElement element = CommonMethods.WaitAndFindElement(updateButton);

			element.Click();
		}




	}
}
