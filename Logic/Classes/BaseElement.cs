using System;
using System.Collections.Generic;
using System.Text;

namespace SvgHelper.Blazor.Logic.Classes
{
    //looks like i can't do a base class.
    //because that always show up at the end (wrong).
    //i do have one more idea.

    public abstract class BaseElement
    {
        public string ClassName { get; set; } = "";
        public string ID { get; set; } = "";
        public string Style { get; set; } = ""; //most things can have styles.
    }
}
