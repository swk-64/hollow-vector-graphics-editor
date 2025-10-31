using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hollow_vector_graphics_editor.Shapes
{
    internal class Circle : Shape, IShapeStatic<Circle>
    {
        public static void previewShape(Graphics g, Point point1, Point point2, Pen strokePen, Brush fillBrush, int strokeThickness)
        {
            int radius = (int)Math.Round(Math.Sqrt((point1.X - point2.X) * (point1.X - point2.X) + (point1.Y - point2.Y) * (point1.Y - point2.Y)));
            System.Drawing.Rectangle bounds = new System.Drawing.Rectangle(point1.X - radius, point1.Y - radius, radius * 2, radius * 2);

            g.FillEllipse(fillBrush, bounds);

            g.DrawEllipse(strokePen, bounds);

        }
        public static Shape makeShape(Point point1, Point point2, Pen strokePen, Brush fillBrush, int strokeThickness)
        {
            return new Circle(point1, point2, strokePen, fillBrush, strokeThickness);
        }
        public override void drawShape(Graphics g, DrawingContext context)
        {
            if (isVisible)
            {
                if (isSelected)
                {
                    previewShape(g, this.startPoint, this.endPoint, context.strokePen, context.fillBrush, context.strokeThickness);
                }
                else previewShape(g, this.startPoint, this.endPoint, this.strokePen, this.fillBrush, this.strokeThickness);
            }
        }
        public override bool containsPoint(Point p)
        {
            throw new NotImplementedException();
        }
        public override void moveShape(Point endMovement, Point relativeClickPositionToStartPoint, Point relativeClickPositionToEndPoint)
        {

        }
        public Circle(Point startPoint, Point endPoint, Pen strokePen, Brush fillBrush, int strokeThickness)
            : base(startPoint, endPoint, strokePen, fillBrush, strokeThickness)
        {

        }
    }
}
