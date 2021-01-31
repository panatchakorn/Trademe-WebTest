using OpenQA.Selenium;
using OpenQA.Selenium.Support.Events;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace TrademeSandbox.Pages
{
    public class TrademeMotorsPage
    {
        public IWebDriver WebDriver { get; }
        public TrademeMotorsPage(IWebDriver webDriver)
        {
            WebDriver = webDriver;       
        }
        // Turn off case warning as I want to keep camelCase for web elements
#pragma warning disable IDE1006
        
        // UI elements in Trademe Motors search box section
        public IWebElement h1PageHeading => WebDriver.FindElement(By.XPath(".//h1[@class='landing-header motors-heading']"));
        public IWebElement btnUsedCars => WebDriver.FindElement(By.Id("SiteHeader_SideBar_AttributeSearch_SearchTabOne"));
        public IWebElement btnNewCars => WebDriver.FindElement(By.Id("SiteHeader_SideBar_AttributeSearch_SearchTabTwoLink"));
        public IWebElement txtKeyword => WebDriver.FindElement(By.Id("sidebar-54"));
        public IWebElement optRegionNZ => WebDriver.FindElement(By.Id("searchRegionAttNational268"));
        public IWebElement optRegion => WebDriver.FindElement(By.Id("searchRegionAttLocal268"));
        public IWebElement drpBoxChangeRegion => WebDriver.FindElement(By.XPath(".//a[@name='attRegionLink']"));        
        public IWebElement lstRegion => WebDriver.FindElement(By.XPath(".//div[contains(@class, 'regionInner')]"));
        public IWebElement btnSearch => WebDriver.FindElement(By.XPath("//button[contains(text(),'Search')]"));
        public IWebElement lnkReset => WebDriver.FindElement(By.LinkText("Reset"));
        public IWebElement lstTransmission => WebDriver.FindElement(By.Id("21"));
        public IWebElement lstWheelDrive => WebDriver.FindElement(By.Name("1"));
        public IWebElement lstMinPrice => WebDriver.FindElement(By.Id("min-18"));
        public IWebElement lstMaxPrice => WebDriver.FindElement(By.Id("max-18"));
        public IWebElement lstMinOdometer => WebDriver.FindElement(By.Id("min-13"));
        public IWebElement lstMaxOdometer => WebDriver.FindElement(By.Id("max-13"));
        public IWebElement lstMinYear => WebDriver.FindElement(By.Id("min-24"));
        public IWebElement lstMaxYear => WebDriver.FindElement(By.Id("max-24"));
        public IWebElement h1Result => WebDriver.FindElement(By.XPath(".//div[@class='search-summary']/h1"));
        public IWebElement h1ResultForKeyword => WebDriver.FindElement(By.XPath(".//h1[@class='inline-block search-results-text']"));
        public IWebElement h1NoResultForKeyword => WebDriver.FindElement(By.XPath(".//div[@id='FiltersContainer']/h1"));
        public IWebElement txtTopSearchKeyword => WebDriver.FindElement(By.Id("searchString"));
        public IWebElement lnkUsedCarListing => WebDriver.FindElement(By.XPath(".//div[@class='tmm-search-card-list-view__card-content']/a"));

        //Turn on case warning for the rest of the code.
#pragma warning restore IDE1006
        //ACTION         
        public void ClickUsedCars() => btnUsedCars.Click();

        public void ClickNewCars() => btnNewCars.Click();

        public void SelectUsedCarListing() => lnkUsedCarListing.Click();

        public void SelectTransmission(string transmissionType)
        {
            SelectFromDropDown(lstTransmission, transmissionType);
            
            /* Possible Transmission options
            //const string TransmissionOpt0 = "Any transmission";
            // const string TransmissionOpt1 = "Manual=1|1";
            // const string TransmissionOpt2 = "Automatic=2|3";
            */

        }

        public void SelectWheelDrive(string wheelDriveType)
        {
            SelectFromDropDown(lstWheelDrive, wheelDriveType);
            /* Possible WheelDrive options
            const string WheelDriveOption0 = "2WD or 4WD";
            const string WheelDriveOption1 = "4WD";
            */
        }
        public void SelectMinPrice(string amount)
        {
           SelectFromDropDown(lstMinPrice, amount);

             /* Possible Price option for Min and Max Prices
             const string PriceOpt0 = "Any";
             const string PriceOpt1 = "$1k";
             const string PriceOpt2 = "$2k";
             const string PriceOpt3 = "$3k";
             const string PriceOpt4 = "$4k";
             const string PriceOpt5 = "$5k";
             const string PriceOpt6 = "$7.5k";
             const string PriceOpt7 = "$10k";
             const string PriceOpt8 = "$12.5k";
             const string PriceOpt9 = "$15k";
             const string PriceOpt10 = "$20k";
             const string PriceOpt11 = "$25k";
             const string PriceOpt12 = "$30k";
             const string PriceOpt13 = "$35k";
             const string PriceOpt14 = "$40k";
             const string PriceOpt15 = "$50k";
             const string PriceOpt16 = "$60k";
             const string PriceOpt17 = "$70k";
             const string PriceOpt18 = "$80k";
             const string PriceOpt19 = "$90k";
             const string PriceOpt20 = "$100k";
             const string PriceOpt21 = "$150k";
             const string PriceOpt22 = "$200k+";
            */
        }
        public void SelectMaxPrice(string amount)
        {
            SelectFromDropDown(lstMaxPrice, amount);
        }

        public void SelectMinOdometer(string odometerKm)
        {
            SelectFromDropDown(lstMinOdometer, odometerKm);
           /* Possible Odometer options for both min and max odometer
                Any
                500
                1k
                5k
                10k
                20k
                30k
                40k
                50k
                60k
                70k
                80k
                90k
                100k
                120k
                140k
                160k
                180k
                200k
                250k
                300k                
           */
        }

        public void SelectMaxOdometer(string odometerKm)
        {
            SelectFromDropDown(lstMaxOdometer, odometerKm);            
        }
        public void SelectMinYear(string year)
        {           
            SelectFromDropDown(lstMinYear, year);     
            /* Possible year options
             * Note after the year the value must have and empty space eg "1950 "
             Any, 1900 , 1910 , 1920 , 1930 , 1940 
             1950 ... to 2021
            */
        }
        public void SelectMaxYear(string year)
        {
            SelectFromDropDown(lstMaxYear, year);
        }
        public void EnterKeyword(string keyword)
        {
            txtKeyword.SendKeys(keyword);
        }

        public void ClickSearch()
        {
            btnSearch.Click();
        }
        public void ClickReset()
        {
            lnkReset.Click();
        }
        public void SelectRegion (string region)
        {
            if (region == "NZ")
            {
                optRegionNZ.Click();
            }
            else
            {
                optRegion.Click();
                drpBoxChangeRegion.Click();
                SelectListItem(lstRegion,region);
            }
            
        }

        // Select option from listbox using text
        public void SelectFromDropDown(IWebElement control, string selectListOption)
        {
            SelectElement selectElement = new SelectElement(control);
            selectElement.Options.ToList().Find(listOption => listOption.Text == selectListOption).Click();
        }

        // Select an unodered list item using text
        public void SelectListItem(IWebElement control, string selectListItem)
        {
            // build a string to locate list item by text
            var listItem = string.Format("/.//a[contains(text(),'{0}')]", selectListItem);
            // select the list item
            control.FindElement(By.XPath(listItem)).Click(); 

        }

       
      
        //VERIFICATION
        // Check Trademe Motors has correct heading
        public bool HasMotorsHeading() => h1PageHeading.GetAttribute("innerHTML").Trim() == "Sell a car or browse Utes, Caravans and more";

        // Check the search has return results for entered keyword from Top Seach Bar
        public bool HasSearchResultsByKeyWord()
        {
            string expectedResultsText = "Search results for '" + txtTopSearchKeyword.GetAttribute("value") + "'";
            if (h1ResultForKeyword.GetAttribute("innerText") == expectedResultsText)
                return true;
            else
                return false;
        }

        // Check the search has return NO results for entered keyword from Top Seach Bar
        public bool HasNoSearchResultsByKeyWord()
        {
            string expectedResultsText = "No results matching '" + txtTopSearchKeyword.GetAttribute("value") + "'";
            if (h1NoResultForKeyword.GetAttribute("innerText") == expectedResultsText)
                return true;
            else
                return false;
        }

        // Check the search has return results from Trademe Motors Search area
        public bool HasSearchResults() => h1Result.GetAttribute("innerHTML") == "Search results";

        // Check the search has return NO results from Trademe Motors Search area
        public bool HasNoSearchResults() => h1Result.GetAttribute("innerHTML") == "No search results";
    }
}
