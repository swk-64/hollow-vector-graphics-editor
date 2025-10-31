using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hollow_vector_graphics_editor.Shapes
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
                    previewShape(g, this.startPoint, this.endPoint, context.strokePen, context.fillBrush, context.strokeThickness);
                }
                else previewShape(g, this.startPoint, this.endPoint, this.strokePen, this.fillBrush, this.strokeThickness);
            }
        }

        public override bool containsPoint(Point p)
        {
            // Vector from start to end
            float dx = this.endPoint.X - this.startPoint.X;
            float dy = this.endPoint.Y - this.startPoint.Y;

            // Handle degenerate case (line is a point)
            if (dx == 0 && dy == 0)
            {
                float dist = Distance(p, this.startPoint);
                return dist <= this.strokeThickness / 2f;
            }

            // Project point onto line segment
            float lengthSquared = dx * dx + dy * dy;
            float t = ((p.X - this.startPoint.X) * dx + (p.Y - this.startPoint.Y) * dy) / lengthSquared;
            t = Math.Max(0, Math.Min(1, t)); // clamp to segment

            // Closest point on the line
            float projX = this.startPoint.X + t * dx;
            float projY = this.startPoint.Y + t * dy;

            // Distance from click to line
            float distToLine = Distance(p, new PointF(projX, projY));

            return distToLine <= this.strokeThickness / 2f;
        }
        public override void moveShape(Point endMovement, Point relativeClickPositionToStartPoint, Point relativeClickPositionToEndPoint)
        {
            this.startPoint = new Point(endMovement.X - relativeClickPositionToStartPoint.X, endMovement.Y - relativeClickPositionToStartPoint.Y);

            this.endPoint = new Point(endMovement.X + relativeClickPositionToEndPoint.X, endMovement.Y + relativeClickPositionToEndPoint.Y);
        }
        public StraightLine(Point startPoint, Point endPoint, Pen strokePen, Brush fillBrush, int strokeThickness)
            : base(startPoint, endPoint, strokePen, fillBrush, strokeThickness) { }
    }
}
