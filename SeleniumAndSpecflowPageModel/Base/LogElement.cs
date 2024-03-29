﻿using System;
using OpenQA.Selenium;

namespace SeleniumAndSpecflowPageModel.Base
{
    public class LogElement : ElementDecorator
    {
        public LogElement(Element element) : base(element)
        {
        }

        public override By By => Element?.By;

        public override string Text
        {
            get
            {
                Console.WriteLine($"Element Text = {Element?.Text}");
                return Element?.Text;
            }
        }

        public override bool? Enabled
        {
            get
            {
                Console.WriteLine($"Element Enabled = {Element?.Enabled}");
                return Element?.Enabled;
            }
        }

        public override bool? Displayed
        {
            get
            {
                Console.WriteLine($"Element Displayed = {Element?.Displayed}");
                return Element?.Displayed;
            }
        }

        public override void Click()
        {
            Console.WriteLine($"Click Element: '{By.ToString()}'");
            Element?.Click();
        }

        public override void ScrollTo()
        {
            Console.WriteLine($"Scroll To Element: '{By.ToString()}'");
            Element?.ScrollTo();
        }

        public override void MoveCursorOver()
        {
            Console.WriteLine($"Move Cursor Over Element: '{By.ToString()}'");
            Element?.MoveCursorOver();
        }

        public override Element FindElement(By locator)
        {
            Console.WriteLine($"Find Element with locator = {locator.ToString()}");
            return Element?.FindElement(locator);
        }

        public override string GetAttribute(string attributeName)
        {
            Console.WriteLine($"Get Element's Attribute = {attributeName}");
            return Element?.GetAttribute(attributeName);
        }

        public override string GetTextAttribute()
        {
            Console.WriteLine($"Get Element's '{By.ToString()}' Text Attribute");
            return Element?.GetTextAttribute();
        }

        public override void TypeText(string text)
        {
            Console.WriteLine($"Type Text = {text}");
            Element?.TypeText(text);
        }

        
    }
}
