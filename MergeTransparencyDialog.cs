using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CQMEditor
{
    public partial class MergeTransparencyDialog : Form
    {
        public MergeTransparencyDialog()
        {
            InitializeComponent();
        }

        private void MergeTransparencyDialog_Load(object sender, EventArgs e)
        {
            transparentValueComboBox.Items.Clear();
            for (int index = 0; index < byte.MaxValue - byte.MinValue + 1; ++index)
            {
                transparentValueComboBox.Items.Add(index.ToString());
            }
            transparentValueComboBox.SelectedIndex = 0;
        }
        public byte TransparentValue
        {
            get
            {
                return (byte)transparentValueComboBox.SelectedIndex;
            }
        }
    }
}
