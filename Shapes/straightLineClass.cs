using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hollow_vector_graphics_editor.Shapes
{
    internal class StraightLine : Shape, IShapeStatic<StraightLine>
    {
        public static void previewShape(Graphics g, Point point1, Point point2, Color strokeColor, Color fillColor, int strokeThickness)
        {
            using (Pen pen = new Pen(strokeColor, strokeThickness))
            {
                g.DrawLine(pen, point1, point2);
            }
        }
        public static Shape makeShape(Point point1, Point point2, Color strokeColor, Color fillColor, int strokeThickness)
        {
            return new StraightLine(point1, point2, strokeColor, fillColor, strokeThickness);
        }
        public override void drawShape(Graphics g)
        {
            previewShape(g, this.startPoint, this.endPoint, this.strokeColor, this.fillColor, this.strokeThickness);
        }
        public override void removeShape()
        {
            throw new NotImplementedException();
        }
        public StraightLine(Point startPoint, Point endPoint, Color strokeColor, Color fillColor, int strokeThickness)
            : base(startPoint, endPoint, strokeColor, fillColor, strokeThickness)
        {

        }
    }
}
