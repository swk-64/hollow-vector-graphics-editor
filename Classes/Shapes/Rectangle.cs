namespace hollow_vector_graphics_editor.Classes.Shapes
{
    internal class Rectangle : Shape, IShapeStatic<Rectangle>
    {
        public static void previewShape(Graphics g, Point point1, Point point2, Pen strokePen, Brush fillBrush, int strokeThickness)
        {
            int minX = Math.Min(point1.X, point2.X);
            int minY = Math.Min(point1.Y, point2.Y);

            int width = point1.X + point2.X - minX * 2;
            int height = point1.Y + point2.Y - minY * 2;

            System.Drawing.Rectangle rect = new System.Drawing.Rectangle(minX, minY, width, height);

            g.FillRectangle(fillBrush, rect);

            g.DrawRectangle(strokePen, rect);

        }
        public static Shape makeShape(Point point1, Point point2, Pen strokePen, Brush fillBrush, int strokeThickness)
        {
            int minX = Math.Min(point1.X, point2.X);
            int minY = Math.Min(point1.Y, point2.Y);

            int width = point1.X + point2.X - minX * 2;
            int height = point1.Y + point2.Y - minY * 2;

            Point start = new Point(minX,  minY);
            Point end = new Point(minX + width, minY + height);

            return new Rectangle(start, end, strokePen, fillBrush, strokeThickness);
        }
        public override void drawShape(Graphics g, DrawingContext context)
        {
            if (isVisible)
            {
                if (isSelected)
                {
                    previewShape(g, startPoint, endPoint, context.strokePen, context.fillBrush, context.strokeThickness);
                }
                else previewShape(g, startPoint, endPoint, strokePen, fillBrush, strokeThickness);
            }
        }
        public override bool containsPoint(Point p)
        {
            return startPoint.X <= p.X && p.X <= endPoint.X && startPoint.Y <= p.Y && p.Y <= endPoint.Y;
        }
        public override void moveShape(Point endMovement, Point relativeClickPositionToStartPoint, Point relativeClickPositionToEndPoint)
        {
            startPoint = new Point(endMovement.X - relativeClickPositionToStartPoint.X, endMovement.Y - relativeClickPositionToStartPoint.Y);

            endPoint = new Point(endMovement.X + relativeClickPositionToEndPoint.X, endMovement.Y + relativeClickPositionToEndPoint.Y);
        }
        public Rectangle(Point startPoint, Point endPoint, Pen strokePen, Brush fillBrush, int strokeThickness)
            : base(startPoint, endPoint, strokePen, fillBrush, strokeThickness)
        {

        }
    }
}
