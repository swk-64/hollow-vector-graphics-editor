using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hollow_vector_graphics_editor.Shapes 
{
    internal interface IShapeStatic<TSelf> where TSelf : IShapeStatic<TSelf>
    {
        static abstract void previewShape(Graphics g, Point point1, Point point2, Color strokeColor, Color fillColor, int strokeThickness);
        static abstract Shape makeShape(Point point1, Point point2, Color strokeColor, Color fillColor, int strokeThickness);
    }

    internal interface IShapeTool
    {
        void Preview(Graphics g, Point p1, Point p2, Color strokeColor, Color fillColor, int strokeThickness);
        Shape Make(Point p1, Point p2, Color strokeColor, Color fillColor, int strokeThickness);
    }

    internal abstract class Shape
    {
        protected Point startPoint;
        protected Point endPoint;
        protected Color strokeColor;
        protected Color fillColor;
        protected int strokeThickness;
        public abstract void drawShape(Graphics g);
        public abstract void removeShape();

        protected Shape(Point startPoint, Point endPoint, Color strokeColor, Color fillColor, int strokeThickness)
        {
            this.startPoint = startPoint;
            this.endPoint = endPoint;
            this.strokeColor = strokeColor;
            this.fillColor = fillColor;
            this.strokeThickness = strokeThickness;
        }
    }

    internal class ShapeTool<T> : IShapeTool where T : IShapeStatic<T>
    {
        public void Preview(Graphics g, Point point1, Point point2, Color strokeColor, Color fillColor, int strokeThickness) => T.previewShape(g, point1, point2, strokeColor, fillColor, strokeThickness);
        public Shape Make(Point point1, Point point2, Color strokeColor, Color fillColor, int strokeThickness) => T.makeShape(point1, point2, strokeColor, fillColor, strokeThickness);
    }

}
