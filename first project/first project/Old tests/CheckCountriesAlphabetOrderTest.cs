using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace first_project
{
  /*  [TestFixture]
    public class CheckCountriesAlphabetOrderTest : TestBase
    {
        //1(a)
        [Test]
        public void CheckCountriesAlphabetOrder()
        {
            LogintoAdminPanel();

            Driver.Url = "http://localhost:81/litecart/admin/?app=countries&doc=countries";
            ReadOnlyCollection<IWebElement> tableRows =
                Driver.FindElements(By.CssSelector("form[name='countries_form'] table.dataTable tr.row"));

            string previousCountryName = "Aaaaa";

            foreach (var row in tableRows)
            {
                string countryName = row.FindElement(By.TagName("a")).Text;

                Assert.IsTrue(countryName.CompareTo(previousCountryName) > 0, "Country " + countryName + " is not in alphabet order.");

                previousCountryName = countryName;
            }
        }

        //1(b)
        [Test]
        public void CheckCountriesGeoZonesAlphabetOrder()
        {
            LogintoAdminPanel();

            Driver.Url = "http://localhost:81/litecart/admin/?app=countries&doc=countries";
           
            ReadOnlyCollection<IWebElement> tableRows = Driver.FindElements(By.CssSelector("form[name='countries_form'] table.dataTable tr.row"));
            
            List<Int32> countriesIds = new List<Int32>();
            
            foreach (var row in tableRows)
            {
                int id = Int32.Parse(row.FindElements(By.TagName("td"))[2].Text);
                if (id>0)
                {
                    countriesIds.Add(id);
                }
            }

            foreach (var id in countriesIds)
            {
                IWebElement row = Driver.FindElement(By.XPath("//form[@name='countries_form']/table[@class='dataTable']//tr[@class='row']/td[3][.='" + id + "']/.."));
                int zones = Int32.Parse(row.FindElements(By.TagName("td"))[5].Text);
                
                if (zones>0)
                {
                    row.FindElement(By.TagName("a")).Click();
                    List<IWebElement> geozonestableRows = Driver.FindElements(By.CssSelector("table#table-zones tr:not(.header)")).ToList();
                    geozonestableRows.RemoveAt(geozonestableRows.Count-1);

                    string previousCountryName = "Aaaaa";
                    foreach (var gzRows in geozonestableRows)
                    {
                        string countryName = gzRows.FindElements(By.TagName("td"))[2].Text;
                        
                        Assert.IsTrue(countryName.CompareTo(previousCountryName) > 0, "Country " + countryName + " is not in alphabet order.");

                        previousCountryName = countryName;
                    }
                    GoBack();
                }
            }
        }

        

        //2
        [Test]
        public void CheckGeoZonesAlphabetOrder()
        {
            LogintoAdminPanel();

            Driver.Url = "http://localhost:81/litecart/admin/?app=geo_zones&doc=geo_zones";

            ReadOnlyCollection<IWebElement> tableRows = Driver.FindElements(By.CssSelector("form[name='geo_zones_form'] table.dataTable tr.row"));

            List<Int32> countriesIds = new List<Int32>();

            foreach (var row in tableRows)
            {
                int id = Int32.Parse(row.FindElements(By.TagName("td"))[1].Text);
                if (id > 0)
                {
                    countriesIds.Add(id);
                }
            }

            foreach (var id in countriesIds)
            {
                IWebElement row = Driver.FindElement(By.XPath("//form[@name='geo_zones_form']/table[@class='dataTable']//tr[@class='row']/td[2][.='" + id + "']/.."));
               
                row.FindElement(By.TagName("a")).Click();
                    
                List<IWebElement> geozonestableRows = Driver.FindElements(By.CssSelector("table#table-zones tr:not(.header)")).ToList();
                   
                geozonestableRows.RemoveAt(geozonestableRows.Count - 1);

                    string previousCountryName = "Aaaaa";
                    foreach (var gzRows in geozonestableRows)
                    {
                        string countryName = new SelectElement(gzRows.FindElement(By.CssSelector("select[name*='zone_code']")))
                            .SelectedOption.Text;
                        

                        Assert.IsTrue(countryName.CompareTo(previousCountryName) > 0, "Country " + countryName + " is not in alphabet order.");

                        previousCountryName = countryName;
                    }
                   GoBack();
                }
        }
    }*/
}
