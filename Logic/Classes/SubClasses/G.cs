using CommonBasicStandardLibraries.CollectionClasses;
using SvgHelper.Blazor.Logic.Classes.Interfaces;

namespace SvgHelper.Blazor.Logic.Classes.SubClasses
{
    public class G : IParentGraphic
    {
        public string ID { get; set; } = "";
        public string Transform { get; set; } = "";
        public string Font_Family { get; set; } = ""; //has to have _ otherwise, can't separate out.
        public string Text_Anchor { get; set; } = "";
        public string Fill { get; set; } = "";
        public string Mask { get; set; } = "";
        public CustomEventClass EventData { get; set; } = new CustomEventClass(); //i like this way better.
        public CustomBasicList<object> Children { get; set; } = new CustomBasicList<object>();

        public string ClipPath { get; set; } = "";


        //if i need anything else for this, add to it.



    }
}
