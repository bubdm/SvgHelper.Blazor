using CommonBasicStandardLibraries.CollectionClasses;
using SvgHelper.Blazor.Logic.Classes.Interfaces;

namespace SvgHelper.Blazor.Logic.Classes.SubClasses
{
    public class ClipPath : BaseElement, IParentGraphic
    {


        public CustomBasicList<object> Children { get; set; } = new CustomBasicList<object>();
    }
}
