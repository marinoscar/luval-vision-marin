﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace luval.vision.core
{
    public class OcrElement
    {

        private string _text;

        public OcrElement()
        {
            Location = new OcrLocation() { RelativeLocation = new OcrRelativeLocation() };
        }
        public int Id { get; set; }
        public string Code { get; set; }
        public virtual OcrLocation Location { get; set; }
        public virtual string Text
        {
            get { return _text; }
            set
            {
                _text = CleanText(value);
            }
        }

        private string CleanText(string text)
        {
            var options = RegexOptions.None;
            var regex = new Regex("[ ]{2,}", options);
            text = text.Trim();
            text = text.Replace(":", "");
            text = regex.Replace(text, " ");
            return text;
        }

    }
}
