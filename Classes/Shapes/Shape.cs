namespace hollow_vector_graphics_editor.Classes.Shapes 
{
    internal abstract class Shape
    {
        protected Point startPoint;
        public Point StartPoint { get { return startPoint; } set { startPoint = value; } }

        protected Point endPoint;
        public Point EndPoint { get { return endPoint; } set { endPoint = value; } }

        protected Pen strokePen;
        protected Brush fillBrush;

        protected int strokeThickness;

        protected bool isVisible;
        protected bool isSelected;


        public void setVisibility(bool visibility)
        {
            isVisible = visibility;
        }
        public void setSelection(bool selection)
        {
            isSelected = selection;
        }

        public abstract void drawShape(Graphics g, DrawingContext context);
        public abstract bool containsPoint(Point p);
        public abstract void moveShape(Point endMovement, Point relativeClickPositionToStartPoint, Point relativeClickPositionToEndPoint);
        protected Shape(Point startPoint, Point endPoint, Pen strokePen, Brush fillBrush, int strokeThickness)
        {
            this.startPoint = startPoint;
            this.endPoint = endPoint;
            this.strokePen = strokePen;
            this.fillBrush = fillBrush;
            this.strokeThickness = strokeThickness;

            isVisible = true;
            isSelected = false;
        }
    }
}