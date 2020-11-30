using CommonBasicStandardLibraries.CollectionClasses;
using SvgHelper.Blazor.Logic.Classes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SvgHelper.Blazor.Logic.Classes.SubClasses
{
    public class Text : BaseElement
    {
        public string X { get; set; } = "0";
        public string Y { get; set; } = "0";
        public string Width { get; set; } = "0";
        public string Height { get; set; } = "0";
        public string Transform { get; set; } = "";
        public string Fill { get; set; } = "black"; //i think that text should default as black.
        public double Font_Size { get; set; } = double.NaN;
        public double Opacity { get; set; } = double.NaN;
        public string Font_Weight { get; set; } = "";
        public string Text_Anchor { get; set; } = "";
        public string Dominant_Baseline { get; set; } = "";
        public string Transform_Origin { get; set; } = "";


        public CustomBasicList<object> Children { get; set; } = new CustomBasicList<object>();
        //has to be on last line.
        public string Content { get; set; } = "";
    }
}
