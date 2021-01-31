using BoDi;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using TrademeSandbox.Context;
using TrademeSandbox.Pages;


namespace TrademeSandbox.StepDefinitions
{
    [Binding]
    public sealed class SearchUsedCarsSteps : WebDriverContext
    {
        private HomePage _homePage = null;
        private TrademeMotorsPage _motorsPage = null;
        private UsedCarDetailsPage _usedCarDetailsPage = null;
        
       
        //Initiate a web driver. Options are Chrome and Firefox. Just need to change the BrowserType in this method
        public SearchUsedCarsSteps() : base(BrowserType.Firefox)
        {
          
        }
        

        [Given(@"user has navigated to the Homepage")]
        public void GivenUserHasNavigatedToTheHomepage()
        {
            // Nothing needs to be done, user is already on the homepage
        }

        [When(@"user enter a (.*) for cars category")]
        public void WhenUserEnterAForCarsCategory(string keyword)
        {
            _homePage.SearchTrademe(keyword,"Cars, bikes & boats");
        }

        [When(@"user presses Search Magnifier")]
        public void WhenUserPressesSearchMagnifier()
        {
            _homePage.ClickSearchMagnifier();
        }

        [Given(@"user has navigated to Trademe Motors page")]
        public void GivenUserHasNavigatedToTrademeMotorsPage()
        {
             Assert.That(_motorsPage.HasMotorsHeading(), Is.True);
        }

        [Given(@"user enter used cars search details (.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*)")]
        public void GivenUserEnterUsedCarsSearchDetails(string wheelDrive, string transmission, string keyword, string minPrice, string maxPrice, string minOdometer, string maxOdometer, string min_Year, string max_Year, string region)
        {
            // adding a space at the end of year per Trademe Data. Note specflow table ignore spaces
            string minYear;
            string maxYear;
            if (min_Year != "Any")
                minYear = min_Year + " ";
            else minYear = min_Year;

            if (max_Year != "Any")
                maxYear = max_Year + " ";
            else
                maxYear = max_Year;

            _motorsPage.ClickUsedCars();
            _motorsPage.SelectWheelDrive(wheelDrive);
            _motorsPage.SelectTransmission(transmission);
            _motorsPage.EnterKeyword(keyword);
            _motorsPage.SelectMinPrice(minPrice);
            _motorsPage.SelectMaxPrice(maxPrice);
            _motorsPage.SelectMinOdometer(minOdometer);
            _motorsPage.SelectMaxOdometer(maxOdometer);
            _motorsPage.SelectMinYear(minYear);
            _motorsPage.SelectMaxYear(maxYear);
            _motorsPage.SelectRegion(region);
        }

        [When(@"user presses Search")]
        public void WhenUserPressesSearch()
        {
            _motorsPage.ClickSearch();

        }

        [Then(@"the page displays used car listing based on keyword")]
        public void ThenThePageDisplaysUsedCarListingBasedOnKeyword()
        {
            Assert.That(_motorsPage.HasSearchResultsByKeyWord(), Is.True);

        }

        [Then(@"the page displays no results based on keyword")]
        public void ThenThePageDisplaysNoResultsBasedOnKeyword()
        {
            Assert.That(_motorsPage.HasNoSearchResultsByKeyWord(), Is.True);
        }


        [Then(@"the page displays used car listing")]
        public void ThenThePageDisplaysUsedCarListing()
        {
            Assert.That(_motorsPage.HasSearchResults(), Is.True);
        }
       
        [When(@"user selects a used car listing")]
        public void WhenUserSelectsAUsedCarListing()
        {
            _motorsPage.SelectUsedCarListing();
        }

        [Then(@"the page displays selected used cars listing details")]
        public void ThenThePageDisplaysSelectedUsedCarsListingDetails()
        {
            Assert.That(_usedCarDetailsPage.HasNumberPlate, Is.True);
            Assert.That(_usedCarDetailsPage.HasKilometre, Is.True);
            Assert.That(_usedCarDetailsPage.HasBody, Is.True);
            Assert.That(_usedCarDetailsPage.HasSeat, Is.True);
        }

        [Then(@"the page displays no search results")]
        public void ThenThePageDisplaysNoSearchResults()
        {
            Assert.That(_motorsPage.HasNoSearchResults(), Is.True);
        }
        
        [BeforeScenario(Order = 1)]
        public void BeforeScenario_GotoHomePage()
        {
            // Navigate to Homepage
            Driver.Navigate().GoToUrl("https://www.tmsandbox.co.nz");

            // Initiate page object            
            _homePage = new HomePage(Driver);
            _motorsPage = new TrademeMotorsPage(Driver);
            _usedCarDetailsPage = new UsedCarDetailsPage(Driver);
            
            Console.WriteLine("Before Scenario: Go to Trademe Home Page");
        }
        [BeforeScenario(Order = 2)]
        [Scope(Tag = "smokeMotorsPageSearch")]
        public void BeforeScenario_GotoMotorsPage()
        {
           // To perform search from Trademe Motors, go there first.
            _homePage.ClickMotors();

            Console.WriteLine("Before Scenario: Go to Trademe Motors Page");
        }

        [AfterScenario]
        public void AfterScenario()
        {
            
            if (Driver != null)
            {
                Driver.Dispose();
                Driver = null;
                Console.WriteLine("After Sceanrio: Web driver is cleared");
            }
        } 
    }
}
