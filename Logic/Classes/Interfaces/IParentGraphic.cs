using CommonBasicStandardLibraries.CollectionClasses;

namespace SvgHelper.Blazor.Logic.Classes.Interfaces
{
    public interface IParentGraphic
    {
        CustomBasicList<object> Children { get; set; }
    }
}