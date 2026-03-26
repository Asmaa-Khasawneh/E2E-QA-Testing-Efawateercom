using Bytescout.Spreadsheet.Charts;
using Final_project_E_Fawatercom.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_project_E_Fawatercom.POM
{
	public class Manage_Report
	{
		IWebDriver _driver;

		public Manage_Report(IWebDriver driver)
		{
			_driver = driver;
		}



		// Define the XPath locator for the dropdown
		By dropDownList = By.XPath("//div/form/div[1]/select");
		public void ClickListButton(string name)
		{
			IWebElement element = CommonMethods.WaitAndFindElement(dropDownList);


			// Create a SelectElement object to interact with the dropdown
			SelectElement dropdown = new SelectElement(element);

			// Select an option by text
			dropdown.SelectByText(name); // Replace with the actual option text
		}









		By report = By.XPath("//nav/div/div/ul/li[2]/a/i");
		By firstDate = By.XPath("//div/div/form/div[2]/input");
		By secondDate = By.XPath("//div/div/form/div[3]/input");
		By discover = By.XPath("//tr[1]/td[4]/button");
		By discover2 = By.XPath("//tr[2]/td[4]/button");
		By discover3 = By.XPath("//tr[3]/td[4]/button");
		By discover4 = By.XPath("//tr[4]/td[4]/button");




		public void ClickReportButton()
		{
			IWebElement element = CommonMethods.WaitAndFindElement(report);

			element.Click();
		}

		public void ClickDescoverButton()
		{
			IWebElement element = CommonMethods.WaitAndFindElement(discover);

			element.Click();
		}

		public void ClickDescover2Button()
		{
			IWebElement element = CommonMethods.WaitAndFindElement(discover2);

			element.Click();
		}
		public void ClickDescover3Button()
		{
			IWebElement element = CommonMethods.WaitAndFindElement(discover3);

			element.Click();
		}

		public void ClickDescover4Button()
		{
			IWebElement element = CommonMethods.WaitAndFindElement(discover4);

			element.Click();
		}

		public void EnterFirstDate(string value)
		{
			IWebElement element = CommonMethods.WaitAndFindElement(firstDate);
			CommonMethods.HighlightElement(element);
			element.SendKeys(value);
		}

		public void EnterSecondDate(string value)
		{
			IWebElement element = CommonMethods.WaitAndFindElement(secondDate);
			CommonMethods.HighlightElement(element);
			element.SendKeys(value);
		}



		



		

	}
}
