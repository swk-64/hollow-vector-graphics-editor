using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hollow_vector_graphics_editor.Shapes
{
    internal class Circle : Shape, IShapeStatic<Circle>
    {
        public static void previewShape(Graphics g, Point point1, Point point2, Color strokeColor, Color fillColor, int strokeThickness)
        {
            throw new NotImplementedException();
        }
        public static Shape makeShape(Point point1, Point point2, Color strokeColor, Color fillColor, int strokeThickness)
        {
            return new Circle(point1, point2, strokeColor, fillColor, strokeThickness);
        }
        public override void drawShape(Graphics g)
        {
            previewShape(g, this.startPoint, this.endPoint, this.strokeColor, this.fillColor, this.strokeThickness);
        }
        public override void removeShape()
        {
            throw new NotImplementedException();
        }
        public Circle(Point startPoint, Point endPoint, Color strokeColor, Color fillColor, int strokeThickness)
            : base(startPoint, endPoint, strokeColor, fillColor, strokeThickness)
        {

        }
    }
}
