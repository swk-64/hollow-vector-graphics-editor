using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hollow_vector_graphics_editor.Shapes
{
    internal abstract class Shape
    {
        private Point startPoint;
        private Point endPoint;
        private Color borderColor;
        private Color fillColor;
        public abstract void previewShape(Point point1, Point point2);
        public abstract void makeShape(Point point1, Point point2);
        public abstract void drawShape();
        public abstract void removeShape();
    }
}
