using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LocaleManager
{
    public partial class CellEditor : Form
    {
        public string text;
        public bool changed = false;

        public CellEditor(string value)
        {
            text = value;

            InitializeComponent();
            
            m_text.Text = value;
        }

        private void m_ok_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void m_cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void m_text_TextChanged(object sender, EventArgs e)
        {
            changed = true;
            text = m_text.Text;
        }
    }
}