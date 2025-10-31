using hollow_vector_graphics_editor.Shapes;

namespace hollow_vector_graphics_editor
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            tableLayoutPanel1 = new TableLayoutPanel();
            shape_params = new ToolStrip();
            btn_change_stroke_color = new ToolStripButton();
            btn_change_fill_color = new ToolStripButton();
            canvas = new Panel();
            tools = new ToolStrip();
            btn_drw_line = new ToolStripButton();
            btn_drw_circle = new ToolStripButton();
            btn_drw_rect = new ToolStripButton();
            btn_selection_tool = new ToolStripButton();
            tableLayoutPanel1.SuspendLayout();
            shape_params.SuspendLayout();
            tools.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 90F));
            tableLayoutPanel1.Controls.Add(shape_params, 2, 0);
            tableLayoutPanel1.Controls.Add(canvas, 1, 0);
            tableLayoutPanel1.Controls.Add(tools, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(800, 450);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // shape_params
            // 
            shape_params.CanOverflow = false;
            shape_params.Dock = DockStyle.Fill;
            shape_params.Items.AddRange(new ToolStripItem[] { btn_change_stroke_color, btn_change_fill_color });
            shape_params.LayoutStyle = ToolStripLayoutStyle.VerticalStackWithOverflow;
            shape_params.Location = new Point(710, 0);
            shape_params.Name = "shape_params";
            shape_params.Size = new Size(90, 450);
            shape_params.TabIndex = 2;
            shape_params.Text = "Tools";
            // 
            // btn_change_stroke_color
            // 
            btn_change_stroke_color.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btn_change_stroke_color.Image = (Image)resources.GetObject("btn_change_stroke_color.Image");
            btn_change_stroke_color.ImageTransparentColor = Color.Magenta;
            btn_change_stroke_color.Name = "btn_change_stroke_color";
            btn_change_stroke_color.Size = new Size(88, 20);
            btn_change_stroke_color.Text = "Change Stroke Color";
            // 
            // btn_change_fill_color
            // 
            btn_change_fill_color.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btn_change_fill_color.Image = (Image)resources.GetObject("btn_change_fill_color.Image");
            btn_change_fill_color.ImageTransparentColor = Color.Magenta;
            btn_change_fill_color.Name = "btn_change_fill_color";
            btn_change_fill_color.Size = new Size(88, 20);
            btn_change_fill_color.Text = "Change Fill Color";
            // 
            // canvas
            // 
            canvas.Dock = DockStyle.Fill;
            canvas.Location = new Point(33, 3);
            canvas.Name = "canvas";
            canvas.Size = new Size(674, 444);
            canvas.TabIndex = 0;
            canvas.Paint += Canvas_Paint;
            canvas.MouseDown += Canvas_MouseDown;
            canvas.MouseMove += Canvas_MouseMove;
            canvas.MouseUp += Canvas_MouseUp;
            // 
            // tools
            // 
            tools.CanOverflow = false;
            tools.Dock = DockStyle.Fill;
            tools.Items.AddRange(new ToolStripItem[] { btn_selection_tool, btn_drw_line, btn_drw_circle, btn_drw_rect });
            tools.LayoutStyle = ToolStripLayoutStyle.VerticalStackWithOverflow;
            tools.Location = new Point(0, 0);
            tools.Name = "tools";
            tools.Size = new Size(30, 450);
            tools.TabIndex = 1;
            tools.Text = "Tools";
            // 
            // btn_drw_line
            // 
            btn_drw_line.CheckOnClick = true;
            btn_drw_line.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btn_drw_line.Image = (Image)resources.GetObject("btn_drw_line.Image");
            btn_drw_line.ImageTransparentColor = Color.Magenta;
            btn_drw_line.Name = "btn_drw_line";
            btn_drw_line.Size = new Size(28, 20);
            btn_drw_line.Text = "Straight Line Tool";
            // 
            // btn_drw_circle
            // 
            btn_drw_circle.CheckOnClick = true;
            btn_drw_circle.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btn_drw_circle.Image = (Image)resources.GetObject("btn_drw_circle.Image");
            btn_drw_circle.ImageTransparentColor = Color.Magenta;
            btn_drw_circle.Name = "btn_drw_circle";
            btn_drw_circle.Size = new Size(28, 20);
            btn_drw_circle.Text = "Circle Tool";
            // 
            // btn_drw_rect
            // 
            btn_drw_rect.CheckOnClick = true;
            btn_drw_rect.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btn_drw_rect.Image = (Image)resources.GetObject("btn_drw_rect.Image");
            btn_drw_rect.ImageTransparentColor = Color.Magenta;
            btn_drw_rect.Name = "btn_drw_rect";
            btn_drw_rect.Size = new Size(28, 20);
            btn_drw_rect.Text = "Rectangle Tool";
            // 
            // btn_selection_tool
            // 
            btn_selection_tool.Checked = true;
            btn_selection_tool.CheckOnClick = true;
            btn_selection_tool.CheckState = CheckState.Checked;
            btn_selection_tool.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btn_selection_tool.Image = (Image)resources.GetObject("btn_selection_tool.Image");
            btn_selection_tool.ImageTransparentColor = Color.Magenta;
            btn_selection_tool.Name = "btn_selection_tool";
            btn_selection_tool.Size = new Size(28, 20);
            btn_selection_tool.Text = "Selection Tool";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tableLayoutPanel1);
            Name = "Form1";
            Text = "Form1";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            shape_params.ResumeLayout(false);
            shape_params.PerformLayout();
            tools.ResumeLayout(false);
            tools.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Panel canvas;
        private ToolStrip tools;
        private ToolStripButton btn_drw_line;
        private ToolStripButton btn_drw_circle;
        private ToolStripButton btn_drw_rect;
        private ToolStrip shape_params;
        private ToolStripButton btn_change_stroke_color;
        private ToolStripButton btn_change_fill_color;
        private ToolStripButton btn_selection_tool;
    }
}
