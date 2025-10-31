using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hollow_vector_graphics_editor.Shapes
{
    internal class Circle : Shape, IShapeStatic<Circle>
    {
        private int radius;
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
                System.Drawing.Rectangle bounds = new System.Drawing.Rectangle(this.startPoint.X - this.radius, this.startPoint.Y - this.radius, this.radius * 2, this.radius * 2);

                if (isSelected)
                {
                    g.FillEllipse(context.fillBrush, bounds);

                    g.DrawEllipse(context.strokePen, bounds);
                }
                else
                {
                    g.FillEllipse(this.fillBrush, bounds);

                    g.DrawEllipse(this.strokePen, bounds);
                }
            }
        }
        public override bool containsPoint(Point p)
        {
            int deltaX = p.X - this.startPoint.X;
            int deltaY = p.Y - this.startPoint.Y;

            return Math.Sqrt(deltaY * deltaY + deltaX * deltaX) <= this.radius;
        }
        public override void moveShape(Point endMovement, Point relativeClickPositionToStartPoint, Point relativeClickPositionToEndPoint)
        {
            this.startPoint = new Point(endMovement.X - relativeClickPositionToStartPoint.X, endMovement.Y - relativeClickPositionToStartPoint.Y);

            this.endPoint = new Point(endMovement.X + relativeClickPositionToEndPoint.X, endMovement.Y + relativeClickPositionToEndPoint.Y);
        }
        public Circle(Point startPoint, Point endPoint, Pen strokePen, Brush fillBrush, int strokeThickness)
            : base(startPoint, endPoint, strokePen, fillBrush, strokeThickness) 
        { 
            this.radius = (int)Math.Round(Math.Sqrt((this.startPoint.X - this.endPoint.X) * (this.startPoint.X - this.endPoint.X) + (this.startPoint.Y - this.endPoint.Y) * (this.startPoint.Y - this.endPoint.Y)));
        }
    }
}
