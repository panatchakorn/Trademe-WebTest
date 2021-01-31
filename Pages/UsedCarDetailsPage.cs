using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace TrademeSandbox.Pages
{
    public class UsedCarDetailsPage
    {
        public IWebDriver WebDriver { get; }
        public UsedCarDetailsPage(IWebDriver webDriver)
        {
            WebDriver = webDriver;
        }
        // UI elements in Used Car Details Page
        // Turn off case warning as I want to keep camelCase for web elements
#pragma warning disable IDE1006
        public IWebElement lblNumberPlate => WebDriver.FindElement(By.XPath(".//label[contains(@class, 'motors-attribute-label') and contains(text(),'Number plate')]"));
        public IWebElement lblKilometre => WebDriver.FindElement(By.XPath(".//label[contains(@class, 'motors-attribute-label') and contains(text(),'Kilometres')]"));
        public IWebElement lblBody => WebDriver.FindElement(By.XPath(".//label[contains(@class, 'motors-attribute-label') and contains(text(),'Body')]"));
        public IWebElement lblSeat => WebDriver.FindElement(By.XPath(".//label[contains(@class, 'motors-attribute-label') and contains(text(),'Seats')]"));
        public IWebElement spnNumberPlateValue => WebDriver.FindElement(By.XPath(".//div[@class='attributes-box key-details-box']/ul/li[1]/./div[@class='key-details-attribute-value']/span"));
        public IWebElement spnKilometreValue => WebDriver.FindElement(By.XPath(".//div[@class='attributes-box key-details-box']/ul/li[2]/./div[@class='key-details-attribute-value']/span"));
        public IWebElement spnBodyValue => WebDriver.FindElement(By.XPath(".//div[@class='attributes-box key-details-box']/ul/li[3]/./div[@class='key-details-attribute-value']/span"));
        public IWebElement spnSeatValue => WebDriver.FindElement(By.XPath(".//div[@class='attributes-box key-details-box']/ul/li[4]/./div[@class='key-details-attribute-value']/span"));

        //Turn on case warning for the rest of the code.
#pragma warning restore IDE1006
        //VERIFICATION
        // Check the used car has number plate label and details        
        public bool HasNumberPlate()
        {
            if (lblNumberPlate.GetAttribute("innerHTML") == "Number plate" && !string.IsNullOrEmpty(spnNumberPlateValue.GetAttribute("innerHTML")))
                return true;
            else
                return false;
        }

        // Check the used car has kilometres label and details
        public bool HasKilometre()
        {
            if (lblKilometre.GetAttribute("innerHTML") == "Kilometres" && !string.IsNullOrEmpty(spnKilometreValue.GetAttribute("innerHTML")))
                return true;
            else
                return false;
        }

        // Check the used car has body label and details      
        public bool HasBody()
        {
            if (lblBody.GetAttribute("innerHTML") == "Body" && !string.IsNullOrEmpty(spnBodyValue.GetAttribute("innerHTML")))
                return true;
            else
                return false;
        }

        // Check the used car has seats label and details
        public bool HasSeat()
        {
            if (lblSeat.GetAttribute("innerHTML") == "Seats" && !string.IsNullOrEmpty(spnSeatValue.GetAttribute("innerHTML")))
                return true;
            else
                return false;
        }
    }
}
