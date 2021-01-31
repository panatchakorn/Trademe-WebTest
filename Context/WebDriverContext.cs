using Gherkin.Ast;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace TrademeSandbox.Context
{
    // 2 supported browser types
    public enum BrowserType
    {
        Chrome,
        Firefox
    }
   
    public class WebDriverContext : BaseDriver
    {
        private readonly BrowserType _browserType;
        //public IWebDriver driver;

        public WebDriverContext(BrowserType browser)
        {
            _browserType = browser;
            InitiatizeBrowser();
        }
        
        public void InitiatizeBrowser()
        {
            ChooseDriverInstance(_browserType);
        }
        // create a new driver per selelected browser type
        private void ChooseDriverInstance(BrowserType browserType)
        {
            if (browserType == BrowserType.Chrome)
            {
                ChromeOptions options = new ChromeOptions();
                options.AddArguments("--start-maximized");
                Driver = new ChromeDriver(options);
            }
            else if (browserType == BrowserType.Firefox)
            {
                // This service helps to speed up test in Firefox due to interatcion between .NET Core and driver is slow
                // This force driver to listen to IPv6 loopback (::1) using the Host property of FirefoxDriverService
                FirefoxDriverService service = FirefoxDriverService.CreateDefaultService();
                service.Host = "::1";
                Driver = new FirefoxDriver(service);
                Driver.Manage().Window.Maximize();
            }           
            else
            {
                throw new Exception(browserType + " is not a supported Browser.");

            }

            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }
    }

   
}
