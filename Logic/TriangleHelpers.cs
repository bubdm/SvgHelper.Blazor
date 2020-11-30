using CommonBasicStandardLibraries.AdvancedGeneralFunctionsAndProcesses.BasicExtensions;
using CommonBasicStandardLibraries.CollectionClasses;
using SvgHelper.Blazor.Logic.Classes.SubClasses;
using System.Drawing;
namespace SvgHelper.Blazor.Logic
{
    public static class TriangleHelpers
    {


        private static float GetCenterX(RectangleF bounds) => (bounds.X + bounds.Right) / 2;


        private static CustomBasicList<PointF> GetTrianglePoints(RectangleF bounds)
        {
            PointF topCenter;
            PointF bottomLeft;
            PointF bottomRight;
            topCenter = new PointF(GetCenterX(bounds), bounds.Y);
            bottomLeft = new PointF(bounds.X, bounds.Bottom);
            bottomRight = new PointF(bounds.Right, bounds.Bottom);
            return new CustomBasicList<PointF>() { bottomLeft, topCenter, bottomRight };
        }

        public static Polygon PopulateTrianglePolygon(this RectangleF bounds, string customColor)
        {
            CustomBasicList<PointF> points = GetTrianglePoints(bounds);
            Polygon output = points.CreatePolygon();
            output.Fill = customColor.ToWebColor();
            return output;
        }

    }
}
