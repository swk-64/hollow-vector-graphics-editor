using hollow_vector_graphics_editor.Classes.Shapes;
using hollow_vector_graphics_editor.Classes.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hollow_vector_graphics_editor.Classes
{
    internal class Editor
    {
        private LayerManager layerManager;
        public LayerManager LayerManager { get { return layerManager; } set { layerManager = value; } }

        private DrawingContext drawingContext;
        public DrawingContext context { get { return drawingContext; } set { drawingContext = value; } }

        private bool isMouseLeftDown;
        public bool IsMouseLeftDown { get { return isMouseLeftDown; } set { isMouseLeftDown = value; } }


        private ShapeTool<Shapes.Rectangle> rectangleTool;
        public ShapeTool<Shapes.Rectangle> RectangleTool => rectangleTool;

        private ShapeTool<StraightLine> straightLineTool;
        public ShapeTool<StraightLine> StraightLineTool => straightLineTool;

        private ShapeTool<Circle> circleTool;
        public ShapeTool<Circle> CircleTool => circleTool;

        private SelectionTool selectionTool;
        public SelectionTool SelectionTool => selectionTool;

        private Tool? currentTool;
        public Tool? CurrentTool { get { return currentTool; }  set { currentTool = value; } }

        public void Render(PaintEventArgs e)
        {
            if (layerManager.layers.Any())
            {
                foreach (Layer layer in layerManager.layers)
                {
                    if (layer.GetShapes() != null)
                    {
                        foreach (Shape shape in layer.GetShapes()!)
                        {
                            shape.drawShape(e.Graphics, context);
                        }
                    }
                }
            }
            if (currentTool is not null && IsMouseLeftDown)
            {
                currentTool.onPaint(e.Graphics, context);
            }
        }
        public Editor()
        {
            layerManager = new();
            drawingContext = new(layerManager, Color.Red, Color.MistyRose, 2);

            isMouseLeftDown = false;

            rectangleTool = new();
            straightLineTool = new();
            circleTool = new();
            selectionTool = new();
            currentTool = null;
        }
    }
}
