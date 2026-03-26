using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bytescout.Spreadsheet;
using Final_project_E_Fawatercom.Data;

namespace Final_project_E_Fawatercom.Helpers
{
	public class CommonMethods
	{
		public static void NavigateToURL(string url)
		{
			ManageDriver.driver.Navigate().GoToUrl(url);
		}

		public static IWebElement WaitAndFindElement(By by) 
		{
			
			var fluentWait = new DefaultWait<IWebDriver>(ManageDriver.driver)
			{
			
				Timeout = TimeSpan.FromSeconds(30),
				PollingInterval = TimeSpan.FromMilliseconds(500),
			};
			fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
			IWebElement element = fluentWait.Until(x => x.FindElement(by));
			return element;
		}

		public static void HighlightElement(IWebElement element)
		{
			
			IJavaScriptExecutor javaScriptExecutor = (IJavaScriptExecutor)ManageDriver.driver;
			javaScriptExecutor.ExecuteScript("arguments[0].setAttribute('style', 'background: lightpink !important')", element);
			javaScriptExecutor.ExecuteScript("arguments[0].scrollIntoView(true);", element);
			Thread.Sleep(1000);
			javaScriptExecutor.ExecuteScript("arguments[0].setAttribute('style', 'background: none !important')", element);
		}

		public static Worksheet ReadExcel(string sheetName)
		{
			
			Spreadsheet Excel = new Spreadsheet();
			Excel.LoadFromFile(GlobalConstants.TestDataPath);
			Worksheet worksheet = Excel.Workbook.Worksheets.ByName(sheetName);
			return worksheet;
		}

		public static string TakeScreenShot()
		{
			
			ITakesScreenshot takesScreenshot = (ITakesScreenshot)ManageDriver.driver;
			Screenshot screenshot = takesScreenshot.GetScreenshot();
			string path = "C:\\Users\\USER\\Documents\\Final-Selenium-TestReport\\ScreenShots";
			string imageName = Guid.NewGuid().ToString() + "_image.png";
			string fullPath = Path.Combine(path + $"\\{imageName}"); 
			screenshot.SaveAsFile(fullPath);
			return fullPath;
		}
	}
}
