namespace SvgHelper.Blazor.Logic.Classes.SubClasses
{
    public class Use : BaseElement
    {
        public bool CaptureRef { get; set; } = false;
        public string Width { get; set; } = "";
        public string Height { get; set; } = "";
        public string X { get; set; } = "0";
        public string Y { get; set; } = "0";
        public string Href { get; set; } = "";
        public CustomEventClass EventData { get; set; } = new CustomEventClass(); //i like this way better.
        public string Transform { get; set; } = ""; //i think.
        public string ViewBox { get; set; } = "";
        public string Fill { get; set; } = "none";
        public string Fill_Opacity { get; set; } = ""; //might as well have here too.  if does not work, will ignore anyways.
        public string PreserveAspectRatio { get; set; } = "";
    }
}
