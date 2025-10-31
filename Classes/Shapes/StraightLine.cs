namespace hollow_vector_graphics_editor.Classes.Shapes
{
    internal class StraightLine : Shape, IShapeStatic<StraightLine>
    {
        private float Distance(PointF a, PointF b)
        {
            float dx = a.X - b.X;
            float dy = a.Y - b.Y;
            return (float)Math.Sqrt(dx * dx + dy * dy);
        }

        public static void previewShape(Graphics g, Point point1, Point point2, Pen strokePen, Brush fillBrush, int strokeThickness)
        {
            g.DrawLine(strokePen, point1, point2);
        }
        public static Shape makeShape(Point point1, Point point2, Pen strokePen, Brush fillBrush, int strokeThickness)
        {
            return new StraightLine(point1, point2, strokePen, fillBrush, strokeThickness);
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
            float dx = endPoint.X - startPoint.X;
            float dy = endPoint.Y - startPoint.Y;

            if (dx == 0 && dy == 0)
            {
                float dist = Distance(p, startPoint);
                return dist <= strokeThickness / 2f;
            }

            float lengthSquared = dx * dx + dy * dy;
            float t = ((p.X - startPoint.X) * dx + (p.Y - startPoint.Y) * dy) / lengthSquared;
            t = Math.Max(0, Math.Min(1, t));

            float projX = startPoint.X + t * dx;
            float projY = startPoint.Y + t * dy;

            float distToLine = Distance(p, new PointF(projX, projY));

            return distToLine <= strokeThickness / 2f;
        }
        public override void moveShape(Point endMovement, Point relativeClickPositionToStartPoint, Point relativeClickPositionToEndPoint)
        {
            startPoint = new Point(endMovement.X - relativeClickPositionToStartPoint.X, endMovement.Y - relativeClickPositionToStartPoint.Y);

            endPoint = new Point(endMovement.X + relativeClickPositionToEndPoint.X, endMovement.Y + relativeClickPositionToEndPoint.Y);
        }
        public StraightLine(Point startPoint, Point endPoint, Pen strokePen, Brush fillBrush, int strokeThickness)
            : base(startPoint, endPoint, strokePen, fillBrush, strokeThickness) { }
    }
}
