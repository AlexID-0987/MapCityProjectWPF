using GMap.NET.MapProviders;
using GMap.NET.WindowsPresentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapCityProject.Model
{
    internal class Direction
    {
       

        public void SetStartCoordinates(GMapControl myDrawMap, float[] to, float[]end )
        {
            myDrawMap.MapProvider= GMapProviders.GoogleMap;
            myDrawMap.Position = new GMap.NET.PointLatLng(to[0], to[1]);
            myDrawMap.MinZoom = 2;
            myDrawMap.MaxZoom = 17;
            myDrawMap.Zoom = 6;
            myDrawMap.ShowCenter = false;
            myDrawMap.CanDragMap = true;
            myDrawMap.DragButton = System.Windows.Input.MouseButton.Left;
            var points= new List<GMap.NET.PointLatLng>
            {
                new GMap.NET.PointLatLng(to[0], to[1]),
                new GMap.NET.PointLatLng(end[0], end[1])
            };
            var manual=new GMapPolygon(points)
            {
                Shape = new System.Windows.Shapes.Path
                {
                    Stroke = System.Windows.Media.Brushes.Red,
                    StrokeThickness = 3
                }
            };
            myDrawMap.Markers.Add(manual);
        }
        public void UpdateMap(GMapControl myMap)
        {
            myMap.Markers.Clear();
        }
    }
}
