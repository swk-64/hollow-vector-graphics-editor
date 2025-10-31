namespace hollow_vector_graphics_editor.Classes.Tools
{
    internal abstract class Tool
    {
        public abstract void prepareTool(DrawingContext context);
        public abstract void onMouseDown(DrawingContext context);
        public abstract void onMouseMove(DrawingContext context);
        public abstract void onMouseUp(DrawingContext context);
        public abstract void onPaint(Graphics g, DrawingContext context);
        public abstract void onKeyDown(DrawingContext context);
    }
}
