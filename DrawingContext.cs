using hollow_vector_graphics_editor.Shapes;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hollow_vector_graphics_editor
{
    internal class DrawingContext
    {
        public List<Shape> shapes;
        public hollow_vector_graphics_editor.Shapes.Shape? selectedShape { get; set; }


        public Color strokeColor { get; set; }
        public Color fillColor { get; set; }

        public Pen strokePen;
        public Brush fillBrush;


        public int strokeThickness { get; set; }

        public Point downPoint { get; set; }
        public Point currentPoint { get; set; }

        public void update()
        {
            if (this.selectedShape is not null)
            {
                selectedShape.setSelection(false);
                selectedShape = null;
            }
        }

        public DrawingContext(Color strokeColor, Color fillColor, int strokeThickness)
        {

            this.strokeColor = strokeColor;
            this.fillColor = fillColor;
            this.strokeThickness = strokeThickness;

            this.strokePen = new Pen(strokeColor, strokeThickness);
            this.fillBrush = new SolidBrush(fillColor);

            this.shapes = new List<Shape>();
        }
    }
}
