using hollow_vector_graphics_editor.Classes;
using hollow_vector_graphics_editor.Classes.Shapes;
using hollow_vector_graphics_editor.Classes.Tools;

namespace hollow_vector_graphics_editor
{
    public partial class MainForm : Form
    {
        // instantiate Tools
        ShapeTool<Classes.Shapes.Rectangle> RectangleTool = new();
        ShapeTool<StraightLine> StraightLineTool = new();
        ShapeTool<Circle> CircleTool = new();
        SelectionTool SelectionTool = new();

        private Tool? currentTool = null;

        private DrawingContext context = new DrawingContext(Color.Red, Color.MistyRose, 2);

        private bool isMouseLeftDown = false;

        private TrackBar thicknessSlider;

        ToolStripLabel thicknessLabel = new ToolStripLabel("Thickness: 2");

        public MainForm()
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

            btn_layer_down.Click += LayerButton_Click;
            btn_layer_up.Click += LayerButton_Click;

            canvas.PreviewKeyDown += canvas_PreviewKeyDown;
            canvas.KeyDown += canvas_KeyDown;
            canvas.TabStop = true;


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
        private void canvas_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                e.IsInputKey = true;
            }
        }
        private void canvas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                currentTool.onKeyDown(context);
                canvas.Invalidate();
            }
        }
        private void layerButton_Click(object sender, EventArgs e)
        {
            if (currentTool == )
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                context.fillColor = colorDialog.Color;
                if (currentTool != null) currentTool.prepareTool(context);
            }
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
            currentTool = clicked!.Tag as Tool;
            currentTool.prepareTool(context);

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
                canvas.Focus();
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
