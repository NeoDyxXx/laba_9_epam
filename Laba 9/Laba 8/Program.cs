using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using Laba_8.Pages;
using Laba_8.Another_Classes;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Laba_8
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!Directory.Exists("Screenshots")) Directory.CreateDirectory("Screenshots");
            if (Directory.GetFiles(@"Screenshots\").Length == 0)
                File.Create(@"Screenshots\Screen_0.jpg");
            else
            {
                string fileName = @"Screenshots\Screen_" + System.Convert.ToString(
                    Directory.GetFiles(@"Screenshots\").Select(item => System.Convert.ToInt32(item.Split('_')[1].Split(".")[0]))
                    .OrderByDescending(item => item).First() + 1) + ".jpg";
                File.Create(fileName);
            }
        }
    }
}