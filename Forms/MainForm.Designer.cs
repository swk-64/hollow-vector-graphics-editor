using hollow_vector_graphics_editor.Classes.Shapes;

namespace hollow_vector_graphics_editor
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            tableLayoutPanel1 = new TableLayoutPanel();
            canvas = new Panel();
            tools = new ToolStrip();
            btn_selection_tool = new ToolStripButton();
            btn_drw_line = new ToolStripButton();
            btn_drw_circle = new ToolStripButton();
            btn_drw_rect = new ToolStripButton();
            tableLayoutPanel2 = new TableLayoutPanel();
            tableLayoutPanel3 = new TableLayoutPanel();
            btn_change_fill_color = new Button();
            btn_change_stroke_color = new Button();
            thicknessSlider = new TrackBar();
            thicknessLabel = new Label();
            tableLayoutPanel4 = new TableLayoutPanel();
            btn_layer_up = new Button();
            btn_layer_down = new Button();
            btn_layer_add = new Button();
            btn_layer_remove = new Button();
            dgv_layer = new DataGridView();
            lbl_note = new Label();
            tableLayoutPanel1.SuspendLayout();
            tools.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)thicknessSlider).BeginInit();
            tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_layer).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 75F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.Controls.Add(canvas, 1, 0);
            tableLayoutPanel1.Controls.Add(tools, 0, 0);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 2, 0);
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
            canvas.BackColor = SystemColors.ControlLightLight;
            canvas.Dock = DockStyle.Fill;
            canvas.Location = new Point(43, 3);
            canvas.Name = "canvas";
            canvas.Size = new Size(594, 444);
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
            tools.Padding = new Padding(0, 0, 2, 0);
            tools.RenderMode = ToolStripRenderMode.System;
            tools.Size = new Size(40, 450);
            tools.TabIndex = 1;
            tools.Text = "Tools";
            // 
            // btn_selection_tool
            // 
            btn_selection_tool.BackgroundImageLayout = ImageLayout.Center;
            btn_selection_tool.CheckOnClick = true;
            btn_selection_tool.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btn_selection_tool.Image = (Image)resources.GetObject("btn_selection_tool.Image");
            btn_selection_tool.ImageTransparentColor = Color.Magenta;
            btn_selection_tool.Name = "btn_selection_tool";
            btn_selection_tool.Size = new Size(37, 20);
            btn_selection_tool.Text = "Selection Tool";
            // 
            // btn_drw_line
            // 
            btn_drw_line.BackgroundImageLayout = ImageLayout.None;
            btn_drw_line.CheckOnClick = true;
            btn_drw_line.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btn_drw_line.Image = (Image)resources.GetObject("btn_drw_line.Image");
            btn_drw_line.ImageTransparentColor = Color.Magenta;
            btn_drw_line.Name = "btn_drw_line";
            btn_drw_line.Size = new Size(37, 20);
            btn_drw_line.Text = "Straight Line Tool";
            // 
            // btn_drw_circle
            // 
            btn_drw_circle.BackgroundImageLayout = ImageLayout.Center;
            btn_drw_circle.CheckOnClick = true;
            btn_drw_circle.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btn_drw_circle.Image = (Image)resources.GetObject("btn_drw_circle.Image");
            btn_drw_circle.ImageTransparentColor = Color.Magenta;
            btn_drw_circle.Name = "btn_drw_circle";
            btn_drw_circle.Size = new Size(37, 20);
            btn_drw_circle.Text = "Circle Tool";
            // 
            // btn_drw_rect
            // 
            btn_drw_rect.BackgroundImageLayout = ImageLayout.Center;
            btn_drw_rect.CheckOnClick = true;
            btn_drw_rect.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btn_drw_rect.Image = (Image)resources.GetObject("btn_drw_rect.Image");
            btn_drw_rect.ImageTransparentColor = Color.Magenta;
            btn_drw_rect.Name = "btn_drw_rect";
            btn_drw_rect.Size = new Size(37, 20);
            btn_drw_rect.Text = "Rectangle Tool";
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(tableLayoutPanel3, 0, 0);
            tableLayoutPanel2.Controls.Add(tableLayoutPanel4, 0, 1);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(643, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(154, 444);
            tableLayoutPanel2.TabIndex = 2;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 2;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 49.9999962F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50.0000076F));
            tableLayoutPanel3.Controls.Add(btn_change_fill_color, 0, 0);
            tableLayoutPanel3.Controls.Add(btn_change_stroke_color, 1, 0);
            tableLayoutPanel3.Controls.Add(thicknessSlider, 0, 2);
            tableLayoutPanel3.Controls.Add(thicknessLabel, 0, 1);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(3, 3);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 3;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Size = new Size(148, 94);
            tableLayoutPanel3.TabIndex = 0;
            // 
            // btn_change_fill_color
            // 
            btn_change_fill_color.Dock = DockStyle.Fill;
            btn_change_fill_color.Image = Properties.Resources.changeFillTool;
            btn_change_fill_color.Location = new Point(3, 3);
            btn_change_fill_color.Name = "btn_change_fill_color";
            btn_change_fill_color.Size = new Size(67, 34);
            btn_change_fill_color.TabIndex = 0;
            btn_change_fill_color.UseVisualStyleBackColor = true;
            // 
            // btn_change_stroke_color
            // 
            btn_change_stroke_color.Dock = DockStyle.Fill;
            btn_change_stroke_color.Image = Properties.Resources.changeStrokeTool;
            btn_change_stroke_color.Location = new Point(76, 3);
            btn_change_stroke_color.Name = "btn_change_stroke_color";
            btn_change_stroke_color.Size = new Size(69, 34);
            btn_change_stroke_color.TabIndex = 1;
            btn_change_stroke_color.UseVisualStyleBackColor = true;
            // 
            // thicknessSlider
            // 
            tableLayoutPanel3.SetColumnSpan(thicknessSlider, 2);
            thicknessSlider.Dock = DockStyle.Fill;
            thicknessSlider.Location = new Point(3, 70);
            thicknessSlider.Name = "thicknessSlider";
            thicknessSlider.Size = new Size(142, 21);
            thicknessSlider.TabIndex = 2;
            // 
            // thicknessLabel
            // 
            thicknessLabel.AutoSize = true;
            tableLayoutPanel3.SetColumnSpan(thicknessLabel, 2);
            thicknessLabel.Dock = DockStyle.Fill;
            thicknessLabel.Location = new Point(3, 40);
            thicknessLabel.Name = "thicknessLabel";
            thicknessLabel.Size = new Size(142, 27);
            thicknessLabel.TabIndex = 3;
            thicknessLabel.Text = "Thickness: 2";
            thicknessLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 4;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel4.Controls.Add(btn_layer_up, 0, 1);
            tableLayoutPanel4.Controls.Add(btn_layer_down, 1, 1);
            tableLayoutPanel4.Controls.Add(btn_layer_add, 2, 1);
            tableLayoutPanel4.Controls.Add(btn_layer_remove, 3, 1);
            tableLayoutPanel4.Controls.Add(dgv_layer, 0, 0);
            tableLayoutPanel4.Controls.Add(lbl_note, 0, 2);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(3, 103);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 3;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 40F));
            tableLayoutPanel4.Size = new Size(148, 338);
            tableLayoutPanel4.TabIndex = 1;
            // 
            // btn_layer_up
            // 
            btn_layer_up.Dock = DockStyle.Fill;
            btn_layer_up.Image = (Image)resources.GetObject("btn_layer_up.Image");
            btn_layer_up.Location = new Point(3, 172);
            btn_layer_up.Name = "btn_layer_up";
            btn_layer_up.Size = new Size(31, 27);
            btn_layer_up.TabIndex = 1;
            btn_layer_up.UseVisualStyleBackColor = true;
            // 
            // btn_layer_down
            // 
            btn_layer_down.Dock = DockStyle.Fill;
            btn_layer_down.Image = (Image)resources.GetObject("btn_layer_down.Image");
            btn_layer_down.Location = new Point(40, 172);
            btn_layer_down.Name = "btn_layer_down";
            btn_layer_down.Size = new Size(31, 27);
            btn_layer_down.TabIndex = 2;
            btn_layer_down.UseVisualStyleBackColor = true;
            // 
            // btn_layer_add
            // 
            btn_layer_add.Dock = DockStyle.Fill;
            btn_layer_add.Image = (Image)resources.GetObject("btn_layer_add.Image");
            btn_layer_add.Location = new Point(77, 172);
            btn_layer_add.Name = "btn_layer_add";
            btn_layer_add.Size = new Size(31, 27);
            btn_layer_add.TabIndex = 3;
            btn_layer_add.UseVisualStyleBackColor = true;
            // 
            // btn_layer_remove
            // 
            btn_layer_remove.Dock = DockStyle.Fill;
            btn_layer_remove.Image = (Image)resources.GetObject("btn_layer_remove.Image");
            btn_layer_remove.Location = new Point(114, 172);
            btn_layer_remove.Name = "btn_layer_remove";
            btn_layer_remove.Size = new Size(31, 27);
            btn_layer_remove.TabIndex = 4;
            btn_layer_remove.UseVisualStyleBackColor = true;
            // 
            // dgv_layer
            // 
            dgv_layer.AllowUserToAddRows = false;
            dgv_layer.AllowUserToDeleteRows = false;
            dgv_layer.AllowUserToResizeColumns = false;
            dgv_layer.AllowUserToResizeRows = false;
            dgv_layer.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tableLayoutPanel4.SetColumnSpan(dgv_layer, 4);
            dgv_layer.Dock = DockStyle.Fill;
            dgv_layer.Location = new Point(3, 3);
            dgv_layer.MultiSelect = false;
            dgv_layer.Name = "dgv_layer";
            dgv_layer.RowHeadersVisible = false;
            dgv_layer.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgv_layer.RowTemplate.Resizable = DataGridViewTriState.False;
            dgv_layer.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_layer.Size = new Size(142, 163);
            dgv_layer.TabIndex = 5;
            // 
            // lbl_note
            // 
            lbl_note.AutoSize = true;
            tableLayoutPanel4.SetColumnSpan(lbl_note, 4);
            lbl_note.Dock = DockStyle.Fill;
            lbl_note.ForeColor = Color.Red;
            lbl_note.Location = new Point(3, 202);
            lbl_note.Name = "lbl_note";
            lbl_note.Size = new Size(142, 136);
            lbl_note.TabIndex = 6;
            lbl_note.Text = "To remove a shape, press Del while the shape is selected.";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tableLayoutPanel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            Text = "Hollow Vector Graphics Editor";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tools.ResumeLayout(false);
            tools.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)thicknessSlider).EndInit();
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_layer).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Panel canvas;
        private ToolStrip tools;
        private ToolStripButton btn_drw_line;
        private ToolStripButton btn_drw_circle;
        private ToolStripButton btn_drw_rect;
        private ToolStripButton btn_selection_tool;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel3;
        private TableLayoutPanel tableLayoutPanel4;
        private Button btn_change_fill_color;
        private Button btn_change_stroke_color;
        private Button btn_layer_up;
        private Button btn_layer_down;
        private Button btn_layer_add;
        private TrackBar thicknessSlider;
        private Label thicknessLabel;
        private Button btn_layer_remove;
        private DataGridView dgv_layer;
        private Label lbl_note;
    }
}
