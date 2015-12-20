using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_MDI_Sample
{
    
    public partial class FormParentMDI : Form
    {
        int view = -1;
        public FormParentMDI()
        {
            InitializeComponent();
          //  this.ActiveMdiChild                                 активна дочірня форма
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Child child = new Child();
            child.MdiParent = this;
            child.Show();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            view++;
            view = view > 3 ? 0 : view;

            switch (view)
            {
                case 0:
                    this.LayoutMdi(MdiLayout.ArrangeIcons);
                    break;
                case 1:
                    this.LayoutMdi(MdiLayout.Cascade);
                    break;
                case 2:
                    this.LayoutMdi(MdiLayout.TileHorizontal);
                    break;
                case 3:
                    this.LayoutMdi(MdiLayout.TileVertical);
                    break;
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null && (this.ActiveMdiChild is Child))
            {
                (this.ActiveMdiChild as Child).Copy();
            }
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null && (this.ActiveMdiChild is Child))
            {
                (this.ActiveMdiChild as Child).Paste();
            }
        }
    }
}
