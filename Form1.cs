using System.Windows.Forms;
using hollow_vector_graphics_editor.Shapes;

namespace hollow_vector_graphics_editor
{
    public partial class Form1 : Form
    {
        private ShapeTool<hollow_vector_graphics_editor.Shapes.Rectangle> RectangleTool = new();
        private ShapeTool<hollow_vector_graphics_editor.Shapes.StraightLine> StraightLineTool = new();
        private ShapeTool<hollow_vector_graphics_editor.Shapes.Circle> CircleTool = new();

        private IShapeTool? currentTool = null;
        private List<Shape> shapes = new List<Shape>();
        private Point startPoint = new Point(0, 0);
        private Point endPoint = new Point(0, 0);


        public Form1()
        {
            InitializeComponent();
        }

        private void ToolButton_Click(object sender, EventArgs e)
        {
            var clicked = sender as ToolStripButton;
            currentTool = clicked!.Tag as IShapeTool;

            foreach (ToolStripItem item in clicked.Owner!.Items)
                if (item is ToolStripButton btn)
                    btn.Checked = (btn == clicked);
        }

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            if (currentTool != null)
            {
                currentTool.Preview(startPoint, endPoint);
            }
        }
        private void Canvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                startPoint.X = e.X;
                startPoint.Y = e.Y;

                endPoint.X = e.X;
                endPoint.Y = e.Y;
            }
        }
        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            endPoint.X = e.X;
            endPoint.Y = e.Y;

            canvas.Invalidate();
        }
        private void Canvas_MouseUp(object sender, MouseEventArgs e)
        {
            endPoint.X = e.X;
            endPoint.Y = e.Y;

            if (currentTool != null)
            {
                shapes.Add(currentTool.Make(startPoint, endPoint));
            }
        }
    }
}
