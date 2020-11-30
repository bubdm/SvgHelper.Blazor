using CommonBasicStandardLibraries.AdvancedGeneralFunctionsAndProcesses.BasicExtensions;
using CommonBasicStandardLibraries.CollectionClasses;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;
using SvgHelper.Blazor.Logic.Classes;
using SvgHelper.Blazor.Logic.Classes.SubClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.ComTypes;

namespace SvgHelper.Blazor.Logic
{
    public class SvgRenderClass
    {
        public Dictionary<string, ElementReference> ElementReferences = new Dictionary<string, ElementReference>();

        public bool Allow0 { get; set; } = false; //if 0s are allowed, then display when needed.
        public void ResetDictionary()
        {
            ElementReferences = new Dictionary<string, ElementReference>();
        }

        private void ActionClicked(CustomEventClass customEvent)
        {
            customEvent.ActionClicked!.Invoke(customEvent.CommandParameters!, customEvent.ExtraDetails!); //first are parameters before extra details.
        }

        public void RenderSvgTree(CustomBasicList<object> objects, int k, RenderTreeBuilder builder)
        {
            objects.ForEach(obj =>
            {
                RenderSvgTree(obj, k, builder);
            });
        }

        public void RenderSvgTree<T>(T item, int k, RenderTreeBuilder builder)
        {
            //Console.WriteLine($"Open Region {k}");
            builder.OpenRegion(k++);

            bool CaptureRef = false;
            string _value_id = string.Empty;

            string _classID = string.Empty;

            if (item!.GetType().GetProperties().Any(x => x.Name == "CaptureRef"))
            {

                PropertyInfo pi_captureref = item.GetType().GetProperty("CaptureRef");
                if ((bool)pi_captureref.GetValue(item, null))
                {
                    if (item.GetType().GetProperties().Any(x => x.Name == "ID"))
                    {
                        PropertyInfo pi_id = item.GetType().GetProperty("ID");
                        _value_id = pi_id.GetValue(item, null).ToString();

                        CaptureRef = _value_id != null && !string.IsNullOrEmpty(_value_id.ToString());
                    }
                    if (item.GetType().GetProperties().Any(x => x.Name == "CssClass"))
                    {
                        PropertyInfo pi_id = item.GetType().GetProperty("CssClass");
                        _classID = pi_id.GetValue(item, null).ToString();

                    }
                }
            }



            object _value;
            string _attrName = string.Empty;

            bool IsAllowed = true;

            string tempName = FirstAndLastCharacterToLower(item.GetType().Name);
            //Console.WriteLine($"OpenElement {k}, {tempName}");
            builder.OpenElement(k++, tempName);



            CustomBasicList<PropertyInfo> properties = item.GetType().GetProperties().Where(x => !x.PropertyType.Name.Contains("CustomBasicList") && x.Name != "Content" && !x.PropertyType.Name.Contains("CaptureRef")).ToCustomBasicList();

            PropertyInfo property = item.GetType().GetProperties().Where(x => x.Name == "Content").SingleOrDefault();
            if (property != null)
            {
                properties.Add(property);
            }


            foreach (PropertyInfo pi in properties)
            {
                //list can't filter captureref??????
                if (pi.Name != "CaptureRef")
                {

                    IsAllowed = true;

                    _value = pi.GetValue(item, null);

                    if (pi.PropertyType == typeof(double))
                    {
                        if (double.IsNaN((double)_value))
                        {
                            IsAllowed = false;

                        }
                        else
                        {
                            _value = Math.Round((double)_value, 2);
                        }
                    }

                    //future:
                    //since only text obviously allows 0, then instead of setting the property, it will check to see if its text
                    //if text, then allow
                    //if not text, but shows 0, then not allowed.


                    if (IsAllowed)
                    {
                        IsAllowed = _value != null && !string.IsNullOrEmpty(_value.ToString());
                        if (IsAllowed && _value!.ToString() == "0" && Allow0 == false)
                        {
                            IsAllowed = false;
                        }
                        if (_value!.ToString() == "0" && Allow0 && item is Text == false)
                        {
                            IsAllowed = false; //try a different way.
                        }
                        //if (_value!.ToString() == "0" && Allow0 == true && item is Image)
                        //{
                        //    IsAllowed = false; //try this way.
                        //}
                        //if (_value!.ToString() == "0" && Allow0 == true && item is Path)
                        //{
                        //    IsAllowed = false;
                        //}
                        //if (Allow0 && _value!.ToString() == "0")
                        //{
                        //    IsAllowed = false; //for now
                        //}
                    }




                    if (IsAllowed)
                    {
                        _attrName = pi.Name;
                        if (_value is CustomEventClass custom)
                        {
                            if (custom.ActionClicked != null)
                            {
                                //if you don't have delegate set up, then ignore.
                                builder.AddAttribute(1, "onclick", EventCallback.Factory.Create(this, e => ActionClicked(custom)));
                            }
                            if (custom.StopPropagation)
                            {
                                builder.AddEventStopPropagationAttribute(2, "onclick", true);
                            }
                        }
                        else
                        {
                            if (_attrName.Equals("Content"))
                            {
                                //Console.WriteLine($"Adding Content 3, {_value!.ToString()}");
                                builder.AddContent(3, _value!.ToString());

                            }
                            else if (_attrName.Equals("CssClass"))
                            {
                                builder.AddAttribute(4, "class", _value!.ToString());
                            }
                            else
                            {

                                if (_attrName.Contains("_"))
                                {
                                    _attrName = _attrName.Replace("_", "-");
                                }

                                _attrName = FirstAndLastCharacterToLower(_attrName);

                                //Console.WriteLine($"4, { _attrName}, {_value!.ToString()}");
                                builder.AddAttribute(4, _attrName, _value!.ToString());

                            }
                        }

                    }
                }
            }


            PropertyInfo pi_Children = item.GetType().GetProperty("Children");

            if (pi_Children != null)
            {
                CustomBasicList<object>? children = pi_Children.GetValue(item) as CustomBasicList<object>;

                foreach (object others in children!)
                {
                    RenderSvgTree(others, k++, builder); ;
                }
            }



            if (CaptureRef)
            {
                //Console.WriteLine("Builder Add Element Reference Capture 5");
                builder.AddElementReferenceCapture(5, (elementReference) =>
                {
                    
                    ElementReferences.Add(_value_id!, elementReference);

                });
            }
            //Console.WriteLine("Close Element");
            builder.CloseElement();
            //Console.WriteLine("Close Region");
            builder.CloseRegion();
        }

        private string FirstAndLastCharacterToLower(string str)
        {

            if (string.IsNullOrWhiteSpace(str))
            {
                return str;
            }
            if (str.Count() <= 3)
            {
                return str.ToLower(); //i think even the third one should be lower case as well.
            }
            int lastIndex = str.Count() - 1;
            if (str == "RefX")
            {
                return "refX";
            }
            if (str == "Font-Weight")
            {
                return "font-weight";
            }
            if (str == "RefY")
            {
                return "refY";
            }
            if (str == "Font-Size")
            {
                return "font-size";
            }
            if (str == "Text-Anchor")
            {
                return "text-anchor";
            }
            if (str == "Dominant-Baseline")
            {
                return "dominant-baseline";
            }
            if (str == "Stop-Color")
            {
                return "stop-color"; //looks like many cases must be lower case no matter what.
            }
            if (str == "Stop-Opacity")
            {
                return "stop-opacity";
            }
            if (str == "Fill-Opacity")
            {
                return "fill-opacity";
            }
            if (str == "Href")
            {
                return "href"; //this too.
            }
            if (str == "ClipPath")
            {
                return "clippath";
            }
            if (char.IsLower(str, 0) == false && char.IsLower(str, lastIndex) == false)
            {
                return char.ToLowerInvariant(str[0]) + str.Substring(1, str.Count() - 2) + char.ToLowerInvariant(str[lastIndex]);
            }
            if (char.IsLower(str, 0) == true && char.IsLower(str, lastIndex) == true)
            {
                return str;
            }
            if (char.IsLower(str, 0) == false)
            {
                return char.ToLowerInvariant(str[0]) + str.Substring(1);
            }
            return str.Substring(0, lastIndex - 2) + char.ToLowerInvariant(str[lastIndex]);


        }

    }
}
