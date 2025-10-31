namespace hollow_vector_graphics_editor.Classes.Shapes
{
    internal interface IShapeStatic<TSelf> where TSelf : IShapeStatic<TSelf>
    {
        static abstract void previewShape(Graphics g, Point point1, Point point2, Pen strokePen, Brush fillBrush, int strokeThickness);
        static abstract Shape makeShape(Point point1, Point point2, Pen strokePen, Brush fillBrush, int strokeThickness);
    }
}
