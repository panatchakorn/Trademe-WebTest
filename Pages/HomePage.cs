using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TrademeSandbox.Context;

namespace TrademeSandbox.Pages
{
    public class HomePage
    {
       public IWebDriver WebDriver { get; }
       public HomePage(IWebDriver webDriver)
            {
                WebDriver = webDriver;               
            }


        // Turn off case warning as I want to keep camelCase for web elements
#pragma warning disable IDE1006

        // UI elements for page title
        public IWebElement titlePage => WebDriver.FindElement(By.TagName("title"));

        // UI elements to navigate to Motors page
        public IWebElement lnkMotors => WebDriver.FindElement(By.Id("SearchTabs1_MotorsLink"));
        public IWebElement lnkDropDownMotors => WebDriver.FindElement(By.Id("SiteHeader_SiteTabs_BrowseDropDown_motorsLink"));

        //UI elements for search function
        public IWebElement txtSearch => WebDriver.FindElement(By.Id("searchString"));
        //public IWebElement optCategory => WebDriver.FindElement(By.Id("SearchType"));
         
        public void SelectCategoryDropDown(string selectListOption)
        {
            SelectElement selectCategory = new SelectElement(WebDriver.FindElement(By.Id("SearchType")));
            selectCategory.Options.ToList().Find(category => category.Text == selectListOption).Click();
        }
        
        public IWebElement btnSearch => WebDriver.FindElement(By.XPath(".//button[@value='Search']"));
           

        //Turn on case warning for the rest of the code.
#pragma warning restore IDE1006
        // ACTION
        // Go to Trademe Motors page from menu bar
        public void ClickMotors() => lnkMotors.Click();

        // Go to Trademe Motors page from top drop down menu
        public void ClicklnkDropDownMotors() => lnkDropDownMotors.Click();

        // Perform Search from Homepage
        public void SearchTrademe(string keyword, string category)
        {
            txtSearch.SendKeys(keyword);
            SelectCategoryDropDown(category);
            //btnSearch.Click();
        }

        public void ClickSearchMagnifier() => btnSearch.Click();
             
    }
}
