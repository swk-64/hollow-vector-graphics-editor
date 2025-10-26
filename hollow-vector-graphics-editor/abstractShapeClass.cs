using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hollow_vector_graphics_editor
{
    internal abstract class Shape
    {
        private Point startPoint;
        private Point endPoint;
        public abstract void drawShape();
        public abstract void fillShape();
        public abstract void removeShape();
    }
}
