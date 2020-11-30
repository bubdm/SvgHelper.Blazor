using CommonBasicStandardLibraries.CollectionClasses;
using SvgHelper.Blazor.Logic.Classes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SvgHelper.Blazor.Logic.Classes.SubClasses
{
    public class RadialGradient : IParentGraphic
    {
        public string ID { get; set; } = "";
        public string CX { get; set; } = "0";
        public string CY { get; set; } = "0";
        public string R { get; set; } = "";
        public string FX { get; set; } = "0";
        public string FY { get; set; } = "0";
        public string FR { get; set; } = "0";
        public CustomBasicList<object> Children { get; set; } = new CustomBasicList<object>();
    }
}
