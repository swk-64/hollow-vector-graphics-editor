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

            // Tool instances
            ShapeTool<hollow_vector_graphics_editor.Shapes.Rectangle> RectangleTool = new();
            ShapeTool<hollow_vector_graphics_editor.Shapes.StraightLine> StraightLineTool = new();
            ShapeTool<hollow_vector_graphics_editor.Shapes.Circle> CircleTool = new();

            // ###########################################################################


            tableLayoutPanel1 = new TableLayoutPanel();
            canvas = new Panel();
            tools = new ToolStrip();
            btn_drw_line = new ToolStripButton();
            btn_drw_circle = new ToolStripButton();
            btn_drw_rect = new ToolStripButton();
            tableLayoutPanel1.SuspendLayout();
            tools.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 95F));
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
            // canvas
            // 
            canvas.Dock = DockStyle.Fill;
            canvas.Location = new Point(43, 3);
            canvas.Name = "canvas";
            canvas.Size = new Size(754, 444);
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
            tools.Items.AddRange(new ToolStripItem[] { btn_drw_line, btn_drw_circle, btn_drw_rect });
            tools.LayoutStyle = ToolStripLayoutStyle.VerticalStackWithOverflow;
            tools.Location = new Point(0, 0);
            tools.Name = "tools";
            tools.Size = new Size(40, 450);
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
            btn_drw_line.Size = new Size(38, 20);
            btn_drw_line.Tag = StraightLineTool;
            btn_drw_line.Text = "Line";
            btn_drw_line.Click += ToolButton_Click;
            // 
            // btn_drw_circle
            // 
            btn_drw_circle.CheckOnClick = true;
            btn_drw_circle.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btn_drw_circle.Image = (Image)resources.GetObject("btn_drw_circle.Image");
            btn_drw_circle.ImageTransparentColor = Color.Magenta;
            btn_drw_circle.Name = "btn_drw_circle";
            btn_drw_circle.Size = new Size(38, 20);
            btn_drw_circle.Tag = CircleTool;
            btn_drw_circle.Text = "Circle";
            btn_drw_circle.Click += ToolButton_Click;
            // 
            // btn_drw_rect
            // 
            btn_drw_rect.CheckOnClick = true;
            btn_drw_rect.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btn_drw_rect.Image = (Image)resources.GetObject("btn_drw_rect.Image");
            btn_drw_rect.ImageTransparentColor = Color.Magenta;
            btn_drw_rect.Name = "btn_drw_rect";
            btn_drw_rect.Size = new Size(38, 20);
            btn_drw_rect.Tag = RectangleTool;
            btn_drw_rect.Text = "Rectangle";
            btn_drw_rect.Click += ToolButton_Click;
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
    }
}
