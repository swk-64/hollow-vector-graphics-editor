using System.Windows.Forms;
using hollow_vector_graphics_editor.Shapes;

namespace hollow_vector_graphics_editor
{
    public partial class Form1 : Form
    {
        private string currentTool = "None";
        private Shape currentShape;

        public Form1()
        {
            InitializeComponent();
        }

        private void ToolButton_Click(object sender, EventArgs e)
        {
            ToolStripButton clicked = sender as ToolStripButton;
            currentTool = clicked.Tag.ToString();

            // Optional: highlight selected button
            foreach (ToolStripItem item in clicked.Owner.Items)
                if (item is ToolStripButton btn)
                    btn.Checked = (btn == clicked);
        }

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {

        }
        private void Canvas_MouseDown(object sender, MouseEventArgs e)
        {

        }
        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {

        }
        private void Canvas_Mouse(object sender, MouseEventArgs e)
        {

        }
    }
}
