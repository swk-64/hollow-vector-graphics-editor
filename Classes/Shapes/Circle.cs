namespace hollow_vector_graphics_editor.Classes.Shapes
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
                System.Drawing.Rectangle bounds = new System.Drawing.Rectangle(startPoint.X - radius, startPoint.Y - radius, radius * 2, radius * 2);

                if (isSelected)
                {
                    g.FillEllipse(context.fillBrush, bounds);

                    g.DrawEllipse(context.strokePen, bounds);
                }
                else
                {
                    g.FillEllipse(fillBrush, bounds);

                    g.DrawEllipse(strokePen, bounds);
                }
            }
        }
        public override bool containsPoint(Point p)
        {
            int deltaX = p.X - startPoint.X;
            int deltaY = p.Y - startPoint.Y;

            return Math.Sqrt(deltaY * deltaY + deltaX * deltaX) <= radius;
        }
        public override void moveShape(Point endMovement, Point relativeClickPositionToStartPoint, Point relativeClickPositionToEndPoint)
        {
            startPoint = new Point(endMovement.X - relativeClickPositionToStartPoint.X, endMovement.Y - relativeClickPositionToStartPoint.Y);

            endPoint = new Point(endMovement.X + relativeClickPositionToEndPoint.X, endMovement.Y + relativeClickPositionToEndPoint.Y);
        }
        public Circle(Point startPoint, Point endPoint, Pen strokePen, Brush fillBrush, int strokeThickness)
            : base(startPoint, endPoint, strokePen, fillBrush, strokeThickness) 
        { 
            radius = (int)Math.Round(Math.Sqrt((this.startPoint.X - this.endPoint.X) * (this.startPoint.X - this.endPoint.X) + (this.startPoint.Y - this.endPoint.Y) * (this.startPoint.Y - this.endPoint.Y)));
        }
    }
}
