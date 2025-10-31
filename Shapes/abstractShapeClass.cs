using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace hollow_vector_graphics_editor.Shapes 
{
    internal interface IShapeStatic<TSelf> where TSelf : IShapeStatic<TSelf>
    {
        static abstract void previewShape(Graphics g, Point point1, Point point2, Pen strokePen, Brush fillBrush, int strokeThickness);
        static abstract Shape makeShape(Point point1, Point point2, Pen strokePen, Brush fillBrush, int strokeThickness);
    }

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
            this.isVisible = visibility;
        }
        public void setSelection(bool selection)
        {
            this.isSelected = selection;
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

            this.isVisible = true;
            this.isSelected = false;
        }
    }
    internal abstract class Tool
    {
        public abstract void prepareTool(DrawingContext context);
        public abstract void onMouseDown(DrawingContext context);
        public abstract void onMouseMove(DrawingContext context);
        public abstract void onMouseUp(DrawingContext context);
        public abstract void onPaint(Graphics g, DrawingContext context);
        public abstract void onKeyDown(DrawingContext context);
    }

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
        public override void onMouseUp(DrawingContext context) => context.shapes.Add(T.makeShape(context.downPoint, context.currentPoint, context.strokePen, context.fillBrush, context.strokeThickness));
        public override void onKeyDown(DrawingContext context) { }
    }

    internal class SelectionTool : Tool
    {
        private Point relativeClickPositionToStartPoint;
        private Point relativeClickPositionToEndPoint;

        public override void prepareTool(DrawingContext context)
        {
            context.update();

            context.strokePen = new Pen(Color.Purple, 4);
            context.strokePen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;

            context.fillBrush = new HatchBrush(HatchStyle.DarkDownwardDiagonal, Color.Purple, Color.Pink);
        }
        public override void onMouseDown(DrawingContext context)
        {
            if (context.selectedShape is not null)
            {
                context.selectedShape.setSelection(false);
                context.selectedShape = null;
            }
            if (context.shapes.Any())
            {
                foreach (Shape shape in context.shapes)
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
                if (!context.shapes.Remove(context.selectedShape)) { throw new Exception("Failed to delete shape"); }
                context.selectedShape = null;
            }
        }
    }
}