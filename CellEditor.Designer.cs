namespace LocaleManager
{
    partial class CellEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CellEditor));
            this.m_text = new System.Windows.Forms.RichTextBox();
            this.m_ok = new System.Windows.Forms.Button();
            this.m_cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // m_text
            // 
            resources.ApplyResources(this.m_text, "m_text");
            this.m_text.Name = "m_text";
            this.m_text.TextChanged += new System.EventHandler(this.m_text_TextChanged);
            // 
            // m_ok
            // 
            resources.ApplyResources(this.m_ok, "m_ok");
            this.m_ok.Name = "m_ok";
            this.m_ok.UseVisualStyleBackColor = true;
            this.m_ok.Click += new System.EventHandler(this.m_ok_Click);
            // 
            // m_cancel
            // 
            resources.ApplyResources(this.m_cancel, "m_cancel");
            this.m_cancel.Name = "m_cancel";
            this.m_cancel.UseVisualStyleBackColor = true;
            this.m_cancel.Click += new System.EventHandler(this.m_cancel_Click);
            // 
            // CellEditor
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_cancel);
            this.Controls.Add(this.m_ok);
            this.Controls.Add(this.m_text);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CellEditor";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox m_text;
        private System.Windows.Forms.Button m_ok;
        private System.Windows.Forms.Button m_cancel;
    }
}