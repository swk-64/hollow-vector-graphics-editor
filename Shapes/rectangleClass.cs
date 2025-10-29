using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hollow_vector_graphics_editor.Shapes
{
    internal class Rectangle : Shape, IShapeStatic<Rectangle>
    {
        public static void previewShape(Graphics g, Point point1, Point point2, Color strokeColor, Color fillColor, int strokeThickness)
        {
            int minX = Math.Min(point1.X, point2.X);
            int minY = Math.Min(point1.Y, point2.Y);

            int width = point1.X + point2.X - minX * 2;
            int height = point1.Y + point2.Y - minY * 2;

            System.Drawing.Rectangle rect = new System.Drawing.Rectangle(minX, minY, width, height);
            using (Brush brush = new SolidBrush(fillColor))
            {
                g.FillRectangle(brush, rect);
            }
            using (Pen pen = new Pen(strokeColor, strokeThickness))
            {
                g.DrawRectangle(pen, rect);
            }

        }
        public static Shape makeShape(Point point1, Point point2, Color strokeColor, Color fillColor, int strokeThickness)
        {
            return new Rectangle(point1, point2, strokeColor, fillColor, strokeThickness);
        }
        public override void drawShape(Graphics g)
        {
            previewShape(g, this.startPoint, this.endPoint, this.strokeColor, this.fillColor, this.strokeThickness);
        }
        public override void removeShape()
        {
            throw new NotImplementedException();
        }

        public Rectangle(Point startPoint, Point endPoint, Color strokeColor, Color fillColor, int strokeThickness)
            : base(startPoint, endPoint, strokeColor, fillColor, strokeThickness)
        {

        }
    }
}
