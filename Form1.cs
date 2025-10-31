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
        SelectionTool SelectionTool = new();

        private Tool? currentTool = null;

        private DrawingContext context = new DrawingContext(Color.Red, Color.MistyRose, 2);

        private bool isMouseLeftDown = false;

        private TrackBar thicknessSlider;

        ToolStripLabel thicknessLabel = new ToolStripLabel("Thickness: 2");

        public Form1()
        {
            InitializeComponent();

            btn_drw_line.Tag = StraightLineTool;
            btn_drw_line.Click += ToolButton_Click;

            btn_drw_circle.Tag = CircleTool;
            btn_drw_circle.Click += ToolButton_Click;

            btn_drw_rect.Tag = RectangleTool;
            btn_drw_rect.Click += ToolButton_Click;

            btn_selection_tool.Tag = SelectionTool;
            btn_selection_tool.Click += ToolButton_Click;

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
                context.fillColor = colorDialog.Color;
                if (currentTool != null) currentTool.prepareTool(context);
            }
        }
        private void btnStrokeColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                context.strokeColor = colorDialog.Color;
                if (currentTool != null) currentTool.prepareTool(context);
            }
        }
        private void thicknessSlider_ValueChanged(object sender, EventArgs e)
        {
            thicknessLabel.Text = $"Thickness: {thicknessSlider.Value}";
            context.strokeThickness = thicknessSlider.Value;
            if (currentTool != null) currentTool.prepareTool(context);
        }
        private void ToolButton_Click(object sender, EventArgs e)
        {
            var clicked = sender as ToolStripButton;
            if (clicked!.Tag == null) currentTool = null;
            else 
            {
                currentTool = clicked!.Tag as Tool;
                currentTool.prepareTool(context);
            }

            foreach (ToolStripItem item in clicked.Owner!.Items)
                if (item is ToolStripButton btn)
                    btn.Checked = (btn == clicked);
        }
        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            if (context.shapes.Any())
            {
                foreach (Shape shape in context.shapes)
                {
                    shape.drawShape(e.Graphics, context);
                }
            }
            if (currentTool is not null)
            {
                currentTool.onPaint(e.Graphics, context);
            }
        }
        private void Canvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMouseLeftDown = true;

                context.downPoint = e.Location;

                context.currentPoint = e.Location;

                if (currentTool is not null)
                {
                    currentTool.onMouseDown(context);
                    canvas.Invalidate();
                }
            }
        }
        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseLeftDown)
            {
                if (e.Button == MouseButtons.Left)
                {

                    if (currentTool is not null)
                    {
                        context.currentPoint = e.Location;

                        currentTool.onMouseMove(context);

                        canvas.Invalidate();
                    }
                }
            }
        }
        private void Canvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (isMouseLeftDown)
            {
                if (e.Button == MouseButtons.Left)
                {
                    context.currentPoint = e.Location;

                    if (currentTool is not null)
                    {
                        currentTool.onMouseUp(context);
                    }

                    isMouseLeftDown = false;
                }
            }

        }
    }
}
