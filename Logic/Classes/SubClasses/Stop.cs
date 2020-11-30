using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SvgHelper.Blazor.Logic.Classes.SubClasses
{
    public class Stop
    {
        public string Offset { get; set; } = "";
        public string Stop_Color { get; set; } = "";
        public string Stop_Opacity { get; set; } = "";
        public string Style { get; set; } = ""; //i think no css for this one.
    }
}
