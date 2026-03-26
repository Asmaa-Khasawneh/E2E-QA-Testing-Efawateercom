using Final_project_E_Fawatercom.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_project_E_Fawatercom.POM
{
	public class Manage_Categories
	{
		IWebDriver _driver;

		public Manage_Categories (IWebDriver driver)
		{
			_driver = driver;
		}

		By waterBiller = By.XPath("//div/table/tbody[1]/tr/td[6]/button[1]");
		By electricityBiller = By.XPath("//div/table/tbody[2]/tr/td[6]/button[1]");
		By telecommunicationBiller = By.XPath("//div/table/tbody[3]/tr/td[6]/button[1]");
		By educationBiller = By.XPath("//div/table/tbody[4]/tr/td[6]/button[1]");
		By billName = By.XPath("//div//input[@ng-reflect-name='Billname']");
		By email = By.XPath("//div//input[@ng-reflect-name='Email']");
		By location = By.XPath("//div//input[@ng-reflect-name='Location']");
		By submit = By.XPath("//div//button[@style='background-color: #21b1a2!important; color: #fff; width: 45%; height: 30px; margin-left: 29px; border-radius: 7px;']");
		By logout = By.XPath("//nav/div/div/ul/li[9]/a");


		public void ClickLogoutButton()
		{
			IWebElement element = CommonMethods.WaitAndFindElement(logout);

			element.Click();
		}

		public void ClickWaterBillerButton()
		{
			IWebElement element = CommonMethods.WaitAndFindElement(waterBiller);

			element.Click();
		}
		public void ClickElectricityBillerButton()
		{
			IWebElement element = CommonMethods.WaitAndFindElement(electricityBiller);

			element.Click();
		}
		public void ClickTelecommunicationBillerButton()
		{
			IWebElement element = CommonMethods.WaitAndFindElement(telecommunicationBiller);

			element.Click();
		}
		public void ClickEducationBillerButton()
		{
			IWebElement element = CommonMethods.WaitAndFindElement(educationBiller);

			element.Click();
		}
		public void EnterBillName(string value)
		{
			IWebElement element = CommonMethods.WaitAndFindElement(billName);
			CommonMethods.HighlightElement(element);
			element.SendKeys(value);


		}
		public void EnterEmail(string value)
		{
			IWebElement element = CommonMethods.WaitAndFindElement(email);
			CommonMethods.HighlightElement(element);
			element.SendKeys(value);


		}
		public void EnterLocation(string value)
		{
			IWebElement element = CommonMethods.WaitAndFindElement(location);
			CommonMethods.HighlightElement(element);
			element.SendKeys(value);


		}
		public void ClickSubmitButton()
		{
			IWebElement element = CommonMethods.WaitAndFindElement(submit);

			element.Click();
		}

	}
}
