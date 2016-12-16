using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;

namespace first_project
{
    [TestFixture]
    public class AddItemsToCart : TestBase

    {
        [Test]
        public void TestMethod1()
        {
            
            for (int i = 0; i < 3; i++)
            {
                app.OpenHomePage();
                app.OpenItem(i);
                app.AddItemToCart();
            }

            app.CheckOut();

            List<string> itemsNames = app.getItemsNames();

            for (int i = 0; i < itemsNames.Count; i++)
            {
                IWebElement tableRow = app.GetRow(itemsNames[i]);

                if (i < itemsNames.Count - 1) app.ClickShortCut();

                app.RemoveItem(itemsNames[i]);

                app.CheckStalenessOfElement(tableRow);
            }
        }
    }
}
