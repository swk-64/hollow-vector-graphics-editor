using hollow_vector_graphics_editor.Classes.Shapes;

namespace hollow_vector_graphics_editor.Classes.Tools
{ 
    internal class ShapeTool<T> : Tool where T : IShapeStatic<T>
    {
        public override void prepareTool(DrawingContext context)
        {
            context.update();

            context.strokePen = new Pen(context.strokeColor, context.strokeThickness);

            context.fillBrush = new SolidBrush(context.fillColor);
        }
        public override void onMouseDown(DrawingContext context) { }
        public override void onMouseMove(DrawingContext context) { }
        public override void onPaint(Graphics g, DrawingContext context) => T.previewShape(g, context.downPoint, context.currentPoint, context.strokePen, context.fillBrush, context.strokeThickness);
        public override void onMouseUp(DrawingContext context) => context.layerManager.currentLayer.Shapes.Add(T.makeShape(context.downPoint, context.currentPoint, context.strokePen, context.fillBrush, context.strokeThickness));
        public override void onKeyDown(DrawingContext context) { }
    }
}
