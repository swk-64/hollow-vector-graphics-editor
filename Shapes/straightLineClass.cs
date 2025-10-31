using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hollow_vector_graphics_editor.Shapes
{
    internal class StraightLine : Shape, IShapeStatic<StraightLine>
    {

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
            throw new NotImplementedException();
        }
        public override void moveShape(Point endMovement, Point relativeClickPositionToStartPoint, Point relativeClickPositionToEndPoint)
        {

        }
        public StraightLine(Point startPoint, Point endPoint, Pen strokePen, Brush fillBrush, int strokeThickness)
            : base(startPoint, endPoint, strokePen, fillBrush, strokeThickness)
        {

        }
    }
}
