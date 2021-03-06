using CommonBasicStandardLibraries.CollectionClasses;
using SvgHelper.Blazor.Logic.Classes.Interfaces;

namespace SvgHelper.Blazor.Logic.Classes.SubClasses
{
    public class LinearGradient : IParentGraphic
    {
        public string ID { get; set; } = "";
        public string X1 { get; set; } = "0";
        public string Y1 { get; set; } = "0";
        public string X2 { get; set; } = "0";
        public string Y2 { get; set; } = "0";
        public string GradientUnits { get; set; } = "";
        public CustomBasicList<object> Children { get; set; } = new CustomBasicList<object>();
    }
}
