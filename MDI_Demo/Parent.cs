using System;
using System.Windows.Forms;

namespace MDI_Demo
{
    public partial class Parent : Form
    {
        public Parent()
        {
            InitializeComponent();
        }

        private int id = 0;
        public int COUNT_ITEMS => 8; 

        public ToolStripItemCollection WindowDropDownItems => windowToolStripMenuItem.DropDownItems;

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var child = new Child();
            child.MdiParent = this;
            child.Text = $"Child {++id}";

            if (windowToolStripMenuItem.DropDownItems.Count == COUNT_ITEMS - 1)
            {
                var separator = new ToolStripSeparator();
                windowToolStripMenuItem.DropDownItems.Add(separator);
            }

            var item = new ToolStripMenuItem(child.Text, null, new EventHandler((o, s) =>
            {
                child.Activate();
            }));

            windowToolStripMenuItem.DropDownItems.Add(item);

            child.Show();
        }

        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void horizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void verticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void minimizeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var item in this.MdiChildren)
            {
                item.WindowState = FormWindowState.Minimized;
            }
        }
    }
}
