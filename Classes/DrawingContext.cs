using hollow_vector_graphics_editor.Classes.Shapes;

namespace hollow_vector_graphics_editor.Classes
{
    internal class DrawingContext
    {
        public List<Shape> shapes;
        public Shape? selectedShape { get; set; }


        public Color strokeColor { get; set; }
        public Color fillColor { get; set; }

        public Pen strokePen;
        public Brush fillBrush;


        public int strokeThickness { get; set; }

        public Point downPoint { get; set; }
        public Point currentPoint { get; set; }

        public void update()
        {
            if (selectedShape is not null)
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

            strokePen = new Pen(strokeColor, strokeThickness);
            fillBrush = new SolidBrush(fillColor);

            shapes = new List<Shape>();
        }
    }
}
