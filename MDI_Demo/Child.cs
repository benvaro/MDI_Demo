using System;
using System.Windows.Forms;

namespace MDI_Demo
{
    public partial class Child : Form
    {
        public Child()
        {
            InitializeComponent();
        }

        private void Child_FormClosing(object sender, FormClosingEventArgs e)
        {
            var items = ((Parent)this.MdiParent).WindowDropDownItems;
            foreach (var item in items)
            {
                if (item is ToolStripMenuItem)
                {
                    if ((item as ToolStripMenuItem).Text == this.Text)
                    {
                        items.Remove(item as ToolStripMenuItem);

                        break;
                    }
                }
            }

            if (((Parent)this.MdiParent).COUNT_ITEMS == items.Count)
            {
                items.RemoveAt(items.Count - 1);
            }
        }

        private void Child_Activated(object sender, EventArgs e)
        {
            ClearCheckBoxes(this);
        }

        private void ClearCheckBoxes(Child child)
        {
            var items = ((Parent)this.MdiParent).WindowDropDownItems;
            foreach (ToolStripItem window in items)
            {
                if (window is ToolStripMenuItem)
                {
                    (window as ToolStripMenuItem).Checked = false;


                    if ((window as ToolStripMenuItem).Text == child.Text)
                    {
                        (window as ToolStripMenuItem).Checked = true;
                    }
                }
            }
        }
    }
}
