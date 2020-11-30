using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SvgHelper.Blazor.Logic.Classes.SubClasses
{
    public class Circle : BaseElement
    {
        public bool CaptureRef { get; set; } = false;
        //has to test with a circle first.
        public string CX { get; set; } = "0"; //the reason it needs to be string is you may have % or other units of measure for this.
        public string CY { get; set; } = "0";
        //if i need to loop through, i would be using something else anyways, not this class for positioning.
        public string R { get; set; } = "0";
        public string Fill { get; set; } = "none"; //decide to default to none already
        public string Fill_Opacity { get; set; } = "";
        public string Transform { get; set; } = "";
        //no need for children since i will not be doing animations.  all of them i will do will be timed ones.
        public CustomEventClass EventData { get; set; } = new CustomEventClass(); //i like this way better.
        public string Marker_Start { get; set; } = "";
        public string Marker_Mid { get; set; } = "";
        public string Marker_End { get; set; } = "";
        public string Mask { get; set; } = "";
    }
}
