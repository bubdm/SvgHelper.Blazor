using CommonBasicStandardLibraries.CollectionClasses;
using SvgHelper.Blazor.Logic.Classes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SvgHelper.Blazor.Logic.Classes.SubClasses
{
    public class Mask : IParentGraphic
    {
        public string ID { get; set; } = "";

        //anything with the fill of white will be visible.
        //anything that is black will be taken away.

        //if a class has one name, the name of a property can't be the same name.  means can't support mask with mask.


        public CustomBasicList<object> Children { get; set; } = new CustomBasicList<object>();
    }
}
