using CommonBasicStandardLibraries.CollectionClasses;
using SvgHelper.Blazor.Logic.Classes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SvgHelper.Blazor.Logic.Classes.SubClasses
{
    public class SVG : BaseElement, IImageSize, IParentGraphic, ISvg
    {
        public bool CaptureRef { get; set; } = false;
        public string Width { get; set; } = "";
        public string Height { get; set; } = "";
        public CustomEventClass EventData { get; set; } = new CustomEventClass(); //i like this way better.
        public string Transform { get; set; } = ""; //i think.
        public string Xmlns { get; set; } = "http://www.w3.org/2000/svg";
        public string ViewBox { get; set; } = "";
        public string PreserveAspectRatio { get; set; } = "";
        public string Mask { get; set; } = "";
        public string X { get; set; } = "0";
        public string Y { get; set; } = "0";
        public CustomBasicList<object> Children { get; set; } = new CustomBasicList<object>();

    }
}
