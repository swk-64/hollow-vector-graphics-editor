using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hollow_vector_graphics_editor.Shapes 
{
    internal interface IShapeStatic<TSelf> where TSelf : IShapeStatic<TSelf>
    {
        static abstract void previewShape(Point point1, Point point2);
        static abstract Shape makeShape(Point point1, Point point2);
    }

    internal interface IShapeTool
    {
        void Preview(Point p1, Point p2);
        Shape Make(Point p1, Point p2);
    }

    internal abstract class Shape
    {
        private Point startPoint;
        private Point endPoint;
        private Color borderColor;
        private Color fillColor;
        public abstract void drawShape(Graphics g);
        public abstract void removeShape();
    }

    internal class ShapeTool<T> : IShapeTool where T : IShapeStatic<T>
    {
        public void Preview(Point point1, Point point2) => T.previewShape(point1, point2);
        public Shape Make(Point point1, Point point2) => T.makeShape(point1, point2);
    }

}
