using hollow_vector_graphics_editor.Classes;
using hollow_vector_graphics_editor.Classes.Shapes;
using hollow_vector_graphics_editor.Classes.Tools;
using System;
using System.Data.Common;
using System.Windows.Forms;

namespace hollow_vector_graphics_editor
{
    public partial class MainForm : Form
    {
        private Editor editor = new();

        public MainForm()
        {
            InitializeComponent();

            btn_drw_line.Tag = editor.StraightLineTool;
            btn_drw_line.Click += ToolButton_Click;

            btn_drw_circle.Tag = editor.CircleTool;
            btn_drw_circle.Click += ToolButton_Click;

            btn_drw_rect.Tag = editor.RectangleTool;
            btn_drw_rect.Click += ToolButton_Click;

            btn_selection_tool.Tag = editor.SelectionTool;
            btn_selection_tool.Click += ToolButton_Click;

            btn_change_stroke_color.Click += StrokeColorButton_Click;
            btn_change_fill_color.Click += FillColorButton_Click;

            btn_layer_down.Click += LayerDownButton_Click;
            btn_layer_up.Click += LayerUpButton_Click;
            btn_layer_add.Click += AddLayerButton_Click;
            btn_layer_remove.Click += RemoveLayerButton_Click;


            dgv_layer.Columns.Add(new DataGridViewCheckBoxColumn
            {
                Name = "Visible",
                HeaderText = "Visible",
                Width = 50,
                SortMode = DataGridViewColumnSortMode.NotSortable

            });

            dgv_layer.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Layer",
                HeaderText = "Layer",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                SortMode = DataGridViewColumnSortMode.NotSortable

            });

            dgv_layer.Rows.Add(true, "Layer 1");
            dgv_layer.Rows[0].Tag = new Layer();
            dgv_layer.SelectionChanged += DGVLayer_SelectionChanged;
            dgv_layer.CellValueChanged += DGVLayer_CellValueChanged;
            dgv_layer.CurrentCellDirtyStateChanged += DGVLayer_CurrentCellDirtyStateChanged;

            editor.LayerManager.addLayer(dgv_layer.Rows[0].Tag as Layer);
            editor.LayerManager.CurrentLayer = editor.LayerManager.Layers[0];

            canvas.PreviewKeyDown += canvas_PreviewKeyDown;
            canvas.KeyDown += canvas_KeyDown;
            canvas.TabStop = true;

            thicknessSlider.Minimum = 1;
            thicknessSlider.Maximum = 10;
            thicknessSlider.Value = 2;
            thicknessSlider.TickStyle = TickStyle.None;
            thicknessSlider.Width = 100;

            thicknessSlider.ValueChanged += thicknessSlider_ValueChanged;

        }
        private void DGVLayer_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgv_layer.IsCurrentCellDirty)
            {
                dgv_layer.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }

        }
        private void DGVLayer_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_layer.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn)
            {
                bool isChecked = (bool)dgv_layer.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                editor.LayerManager.CurrentLayer!.IsVisible = isChecked;
                canvas.Invalidate();
            }
        }
        private void DGVLayer_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_layer.SelectedRows.Count > 0)
            {
                editor.LayerManager.CurrentLayer = dgv_layer.SelectedRows[0].Tag as Layer;
            }
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
            if (editor.CurrentTool != null)
            {
                if (e.KeyCode == Keys.Delete)
                {
                    editor.CurrentTool.onKeyDown(editor.context);
                    canvas.Invalidate();
                }
            }
        }
        private void LayerUpButton_Click(object sender, EventArgs e)
        {
            if (dgv_layer.SelectedRows.Count == 0) return;

            int index = dgv_layer.SelectedRows[0].Index;
            if (index == 0) return;

            DataGridViewRow row = dgv_layer.Rows[index];
            dgv_layer.Rows.RemoveAt(index);
            dgv_layer.Rows.Insert(index - 1, row);
            dgv_layer.ClearSelection();
            dgv_layer.Rows[index - 1].Selected = true;

            editor.LayerManager.moveLayerUp(index);
            canvas.Invalidate();
        }
        private void LayerDownButton_Click(object sender, EventArgs e)
        {
            if (dgv_layer.SelectedRows.Count == 0) return;

            int index = dgv_layer.SelectedRows[0].Index;
            if (index >= dgv_layer.Rows.Count - 1) return;

            DataGridViewRow row = dgv_layer.Rows[index];
            dgv_layer.Rows.RemoveAt(index);
            dgv_layer.Rows.Insert(index + 1, row);
            dgv_layer.ClearSelection();
            dgv_layer.Rows[index + 1].Selected = true;

            editor.LayerManager.moveLayerDown(index);
            canvas.Invalidate();
        }
        private void AddLayerButton_Click(object sender, EventArgs e)
        {
            int index = dgv_layer.Rows.Count;
            dgv_layer.Rows.Insert(0, true, $"Layer {index + 1}");
            dgv_layer.Rows[0].Tag = new Layer();

            dgv_layer.ClearSelection();
            dgv_layer.Rows[0].Selected = true;

            editor.LayerManager.addLayer(dgv_layer.Rows[0].Tag as Layer);
            editor.LayerManager.CurrentLayer = dgv_layer.Rows[0].Tag as Layer;
            canvas.Invalidate();
        }
        private void RemoveLayerButton_Click(object sender, EventArgs e)
        {
            if (dgv_layer.Rows.Count > 0)
            {
                editor.LayerManager.removeLayer(dgv_layer.SelectedRows[0].Tag as Layer);

                int index = dgv_layer.SelectedRows[0].Index;
                dgv_layer.Rows.RemoveAt(index);
                dgv_layer.ClearSelection();

                if (dgv_layer.Rows.Count > index)
                {
                    dgv_layer.Rows[index].Selected = true;

                    editor.LayerManager.CurrentLayer = editor.LayerManager.Layers[index];
                }
                else if (dgv_layer.Rows.Count > 0)
                {
                    dgv_layer.Rows[dgv_layer.Rows.Count - 1].Selected = true;

                    editor.LayerManager.CurrentLayer = editor.LayerManager.Layers[dgv_layer.Rows.Count - 1];
                }
                canvas.Invalidate();
            }
        }
        private void FillColorButton_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                editor.context.fillColor = colorDialog.Color;
                if (editor.CurrentTool != null) editor.CurrentTool.prepareTool(editor.context);
            }
        }
        private void StrokeColorButton_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                editor.context.strokeColor = colorDialog.Color;
                if (editor.CurrentTool != null) editor.CurrentTool.prepareTool(editor.context);
            }
        }
        private void thicknessSlider_ValueChanged(object sender, EventArgs e)
        {
            thicknessLabel.Text = $"Thickness: {thicknessSlider.Value}";
            editor.context.strokeThickness = thicknessSlider.Value;
            if (editor.CurrentTool != null) editor.CurrentTool.prepareTool(editor.context);
        }
        private void ToolButton_Click(object sender, EventArgs e)
        {
            var clicked = sender as ToolStripButton;
            editor.CurrentTool = clicked!.Tag as Tool;
            editor.CurrentTool.prepareTool(editor.context);

            foreach (ToolStripItem item in clicked.Owner!.Items)
                if (item is ToolStripButton btn)
                    btn.Checked = (btn == clicked);
        }
        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            editor.Render(e);
        }
        private void Canvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (editor.LayerManager.CurrentLayer != null)
            {
                if (e.Button == MouseButtons.Left)
                {
                    canvas.Focus();
                    editor.IsMouseLeftDown = true;

                    editor.context.downPoint = e.Location;

                    editor.context.currentPoint = e.Location;

                    if (editor.CurrentTool is not null)
                    {
                        editor.CurrentTool.onMouseDown(editor.context);
                        canvas.Invalidate();
                    }
                }
            }
        }
        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (editor.LayerManager.CurrentLayer != null)
            {
                if (editor.IsMouseLeftDown)
                {
                    if (e.Button == MouseButtons.Left)
                    {

                        if (editor.CurrentTool is not null)
                        {
                            editor.context.currentPoint = e.Location;

                            editor.CurrentTool.onMouseMove(editor.context);

                            canvas.Invalidate();
                        }
                    }
                }
            }
        }
        private void Canvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (editor.LayerManager.CurrentLayer != null)
            {
                if (editor.IsMouseLeftDown)
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        editor.context.currentPoint = e.Location;

                        if (editor.CurrentTool is not null)
                        {
                            editor.CurrentTool.onMouseUp(editor.context);
                        }

                        editor.IsMouseLeftDown = false;
                    }
                }
            }
        }
    }
}
