using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Laba_8.Pages;
using Laba_8.Another_Classes;
using System.Threading;

namespace UnitTestProject1
{
    [TestClass]
    public class QuotexTests
    {
        [TestMethod]
        public void GetTransactionInDemoAccount()
        {
            List<ItemInHistoryList> testList = new List<ItemInHistoryList>()
            {
                new ItemInHistoryList() {NameOfStock = "AUD/CAD (OTC)", TimeOfTrade = "00:01:00"}
            };

            WebDriver webDriver = new ChromeDriver(@"C:\Users\krayn\Documents\¡√“”\5_semestr\EPAM\Laba 8\Laba 8\Laba 8\Web Driver\");
            LoginPage siteOfDemoAccount = new LoginPage(webDriver);

            MainPage mainPage = siteOfDemoAccount
                                    .TransitionToDemoAccount()
                                    .HidePopup()
                                    .ClickToChangeSet()
                                    .ClickToDemoFromChangeSet()
                                    .ClickToChooseStockButton()
                                    .InputValueInInputOfChooseStock("AUD/CAD")
                                    .ClickToChooseStockItem()
                                    .TypeCostFromTransaction(5)
                                    .TypeTimeFromTransaction(new DateTime(2021, 1, 1, 0, 1, 0))
                                    .ClickToPushTransaction();
            Thread.Sleep(70000);

            List<ItemInHistoryList> resultListFromTest = mainPage.GetItemInHistoryLists();
            Console.WriteLine(resultListFromTest.EqualListsOfItemInHistoryList(testList));

            webDriver.Close();
            webDriver.Quit();
        }

        [TestMethod]
        public void NotCurrectTransaction()
        {
            WebDriver webDriver = new ChromeDriver(@"C:\Users\krayn\Documents\¡√“”\5_semestr\EPAM\Laba 8\Laba 8\Laba 8\Web Driver\");
            LoginPage siteOfDemoAccount = new LoginPage(webDriver);

            MainPage mainPage = siteOfDemoAccount
                                    .TransitionToDemoAccount()
                                    .HidePopup()
                                    .ClickToChangeSet()
                                    .ClickToDemoFromChangeSet()
                                    .TypeCostFromTransaction(0)
                                    .TypeTimeFromTransaction(new DateTime(2021, 1, 1, 0, 0, 0));
            Thread.Sleep(1000);
            Assert.AreNotEqual(("00:00:00", "0"), (mainPage.GetValueFromTimeInTransaction(), mainPage.GetValueFromCostInTransaction()));

            webDriver.Close();
            webDriver.Quit();
        }
    }
}
