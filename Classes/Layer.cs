using hollow_vector_graphics_editor.Classes.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hollow_vector_graphics_editor.Classes
{
    internal class Layer
    {
        private bool isVisible;
        public bool IsVisible { get { return isVisible; } set { isVisible = value; } }

        private List<Shape> shapes;

        public List<Shape> Shapes { get { return shapes; } set { shapes = value; } }

        public List<Shape>? GetShapes()
        {
            if (isVisible && shapes.Any()) return Shapes;
            return null;
        }

        public Layer()
        {
            isVisible = true;
            shapes = new List<Shape>();
        }
    }
}