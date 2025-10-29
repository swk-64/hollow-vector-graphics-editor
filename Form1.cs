using hollow_vector_graphics_editor.Shapes;
using System.Drawing;
using System.Windows.Forms;

namespace hollow_vector_graphics_editor
{
    public partial class Form1 : Form
    {
        // instantiate Tools
        ShapeTool<hollow_vector_graphics_editor.Shapes.Rectangle> RectangleTool = new();
        ShapeTool<hollow_vector_graphics_editor.Shapes.StraightLine> StraightLineTool = new();
        ShapeTool<hollow_vector_graphics_editor.Shapes.Circle> CircleTool = new();

        private IShapeTool? currentTool = null;
        private List<Shape> shapes = new List<Shape>();
        private Point startPoint = new Point(0, 0);
        private Point endPoint = new Point(0, 0);
        private Color fillColor = Color.MistyRose;
        private Color strokeColor = Color.Red;
        private bool isMouseLeftDown = false;

        private TrackBar thicknessSlider;
        ToolStripLabel thicknessLabel = new ToolStripLabel("Thickness: 2");

        public Form1()
        {
            InitializeComponent();

            btn_drw_line.Tag = StraightLineTool;
            btn_drw_circle.Tag = CircleTool;
            btn_drw_rect.Tag = RectangleTool;

            thicknessSlider = new TrackBar
            {
                Minimum = 1,
                Maximum = 10,
                Value = 2,
                TickStyle = TickStyle.None,
                Width = 100
            };

            thicknessSlider.ValueChanged += thicknessSlider_ValueChanged;

            ToolStripControlHost sliderHost = new ToolStripControlHost(thicknessSlider);
            shape_params.Items.Add(thicknessLabel);
            shape_params.Items.Add(sliderHost);

            btn_change_stroke_color.Click += btnStrokeColor_Click;
            btn_change_fill_color.Click += btnFillColor_Click;

        }

        private void btnFillColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                fillColor = colorDialog.Color;
            }
        }
        private void btnStrokeColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                strokeColor = colorDialog.Color;
            }
        }
        private void thicknessSlider_ValueChanged(object sender, EventArgs e)
        {
            thicknessLabel.Text = $"Thickness: {thicknessSlider.Value}";
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
            if (shapes.Any())
            {
                foreach (Shape shape in shapes)
                {
                    shape.drawShape(e.Graphics);
                }
            }
            if (currentTool != null)
            {
                currentTool.Preview(e.Graphics, startPoint, endPoint, strokeColor, fillColor, thicknessSlider.Value);
            }
        }
        private void Canvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMouseLeftDown = true;
                startPoint.X = e.X;
                startPoint.Y = e.Y;

                endPoint.X = e.X;
                endPoint.Y = e.Y;
            }
        }
        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseLeftDown)
            {
                if (e.Button == MouseButtons.Left)
                {

                    if (currentTool != null)
                    {
                        endPoint.X = e.X;
                        endPoint.Y = e.Y;

                        canvas.Invalidate();
                    }
                }
            }
        }
        private void Canvas_MouseUp(object sender, MouseEventArgs e)
        {
            endPoint.X = e.X;
            endPoint.Y = e.Y;
            if (isMouseLeftDown)
            {
                if (e.Button == MouseButtons.Left)
                {
                    isMouseLeftDown = false;

                    if (currentTool != null)
                    {
                        shapes.Add(currentTool.Make(startPoint, endPoint, strokeColor, fillColor, thicknessSlider.Value));
                    }
                }
            }

        }
    }
}
