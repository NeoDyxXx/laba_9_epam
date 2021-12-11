using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using Laba_8.Pages;
using Laba_8.Another_Classes;
using System.Collections.Generic;

namespace Laba_8
{
    class Program
    {
        static void Main(string[] args)
        {
            List<ItemInHistoryList> testList = new List<ItemInHistoryList>()
            {
                new ItemInHistoryList() {NameOfStock = "USD/CAD (OTC)", TimeOfTrade = "00:02:00"}
            };

            WebDriver webDriver = new ChromeDriver(@"C:\Users\krayn\Documents\БГТУ\5_semestr\EPAM\Laba 8\Laba 8\Laba 8\Web Driver\");
            LoginPage siteOfDemoAccount = new LoginPage(webDriver);

            MainPage mainPage = siteOfDemoAccount
                                    .TransitionToDemoAccount()
                                    .HidePopup()
                                    .ClickToChangeSet()
                                    .ClickToDemoFromChangeSet()
                                    .TypeCostFromTransaction(0)
                                    .TypeTimeFromTransaction(new DateTime(2021, 1, 1, 0, 0, 0))
                                    .ClickToPushTransaction();
            Thread.Sleep(125000);

            List<ItemInHistoryList> resultListFromTest = mainPage.GetItemInHistoryLists();

            webDriver.Close();
            webDriver.Quit();
        }
    }
}