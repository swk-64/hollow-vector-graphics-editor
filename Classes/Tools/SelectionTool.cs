using hollow_vector_graphics_editor.Classes.Shapes;
using System.Drawing.Drawing2D;

namespace hollow_vector_graphics_editor.Classes.Tools
{
    internal class SelectionTool : Tool
    {
        private Point relativeClickPositionToStartPoint;
        private Point relativeClickPositionToEndPoint;

        public override void prepareTool(DrawingContext context)
        {
            context.update();

            context.strokePen = new Pen(Color.Purple, 4);
            context.strokePen.DashStyle = DashStyle.Dash;

            context.fillBrush = new HatchBrush(HatchStyle.DarkDownwardDiagonal, Color.Purple, Color.Pink);
        }
        public override void onMouseDown(DrawingContext context)
        {
            if (context.selectedShape is not null)
            {
                context.selectedShape.setSelection(false);
                context.selectedShape = null;
            }
            if (context.layerManager.CurrentLayer!.Shapes.Any())
            {
                foreach (Shape shape in context.layerManager.CurrentLayer.Shapes)
                {

                    if (shape.containsPoint(context.downPoint))
                    {
                        if (context.selectedShape is not null)
                        {
                            context.selectedShape.setSelection(false);
                        }
                        context.selectedShape = shape;
                        context.selectedShape.setSelection(true);

                        relativeClickPositionToStartPoint = new Point(context.downPoint.X - context.selectedShape.StartPoint.X, context.downPoint.Y - context.selectedShape.StartPoint.Y);
                        relativeClickPositionToEndPoint = new Point(context.selectedShape.EndPoint.X - context.downPoint.X, context.selectedShape.EndPoint.Y - context.downPoint.Y);
                    }
                }
            }

        }
        public override void onMouseMove(DrawingContext context)
        {
            if (context.selectedShape is not null)
                context.selectedShape.moveShape(context.currentPoint, relativeClickPositionToStartPoint, relativeClickPositionToEndPoint);
        }
        public override void onPaint(Graphics g, DrawingContext context) { }
        public override void onMouseUp(DrawingContext context) { }
        public override void onKeyDown(DrawingContext context)
        {
            if (context.selectedShape is not null)
            {
                if (!context.layerManager.CurrentLayer!.Shapes.Remove(context.selectedShape)) { throw new Exception("Failed to delete shape"); }
                context.selectedShape = null;
            }
        }
    }
}
