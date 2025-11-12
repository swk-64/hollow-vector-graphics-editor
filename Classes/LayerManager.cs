using hollow_vector_graphics_editor.Classes.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hollow_vector_graphics_editor.Classes
{
    internal class LayerManager
    {
        private List<Layer> layers;
        public List<Layer> Layers { get { return layers; } }

        private Layer? currentLayer;
        public Layer? CurrentLayer { get { return currentLayer; } set { currentLayer = value; } }

        public void addLayer(Layer layer)
        {
            layers.Add(layer);
        }
        public void removeLayer(Layer layer)
        {
            if (currentLayer != null)
            {
                if (!layers.Remove(layer))
                {
                    throw new Exception("Failed to remove layer.");
                }
                currentLayer = null;
            }
        }

        public void moveLayerUp(int initial_pos)
        {
            if (initial_pos > 0)
            {
                Layer temp = layers[initial_pos - 1];
                layers[initial_pos - 1] = layers[initial_pos];
                layers[initial_pos] = temp;
            }

        }
        public void moveLayerDown(int initial_pos)
        {
            if (initial_pos < layers.Count - 1)
            {
                Layer temp = layers[initial_pos + 1];
                layers[initial_pos + 1] = layers[initial_pos];
                layers[initial_pos] = temp;
            }
        }

        public LayerManager()
        {
            layers = new List<Layer>();
        }
    }
}
