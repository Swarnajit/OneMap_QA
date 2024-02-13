﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UiAutomation.Tests
{
    public class SharedMethods
    {
        public static void typeInSearch(IWebElement element, string textToType)
        {
            element.Click();
            element.Clear();

            foreach (char letter in textToType)
            {
                element.SendKeys(letter.ToString());
                Thread.Sleep(5);
            }

            element.SendKeys(Keys.Enter);
        }
    }
}
