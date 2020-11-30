using CommonBasicStandardLibraries.CollectionClasses;
using SvgHelper.Blazor.Logic.Classes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SvgHelper.Blazor.Logic.Classes.SubClasses
{
    public class Defs : IParentGraphic
    {
        public CustomBasicList<object> Children { get; set; } = new CustomBasicList<object>(); //this is it for this one.
    }
}
