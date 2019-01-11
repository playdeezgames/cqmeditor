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
    public partial class NewMapDialog : Form
    {
        public NewMapDialog()
        {
            InitializeComponent();
        }

        private void NewMapDialog_Load(object sender, EventArgs e)
        {
            widthComboBox.Items.Clear();
            heightComboBox.Items.Clear();
            fillComboBox.Items.Clear();
            for (int index = byte.MinValue; index < byte.MaxValue - byte.MinValue + 1; ++index)
            {
                fillComboBox.Items.Add(index.ToString());
                if (index > 0)
                {
                    widthComboBox.Items.Add(index.ToString());
                    heightComboBox.Items.Add(index.ToString());
                }
            }
            fillComboBox.SelectedIndex = 0;
            widthComboBox.SelectedIndex = 0;
            heightComboBox.SelectedIndex = 0;
        }
        public byte MapWidth
        {
            get
            {
                return (byte)(widthComboBox.SelectedIndex + 1);
            }
        }
        public byte MapHeight
        {
            get
            {
                return (byte)(heightComboBox.SelectedIndex + 1);
            }
        }
        public byte MapFill
        {
            get
            {
                return (byte)(fillComboBox.SelectedIndex);
            }
        }
    }
}
