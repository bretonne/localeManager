namespace LocaleManager
{
    partial class WorkSheetForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WorkSheetForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.m_grid = new System.Windows.Forms.DataGridView();
            this.m_files = new System.Windows.Forms.ComboBox();
            this.m_menu = new System.Windows.Forms.MenuStrip();
            this.m_save = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.m_grid)).BeginInit();
            this.m_menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_grid
            // 
            this.m_grid.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.m_grid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            resources.ApplyResources(this.m_grid, "m_grid");
            this.m_grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.m_grid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.m_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.m_grid.DefaultCellStyle = dataGridViewCellStyle2;
            this.m_grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.m_grid.Name = "m_grid";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            this.m_grid.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.m_grid.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.m_grid_CellContentClick);
            this.m_grid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.m_grid_CellEndEdit);
            // 
            // m_files
            // 
            this.m_files.FormattingEnabled = true;
            resources.ApplyResources(this.m_files, "m_files");
            this.m_files.Name = "m_files";
            this.m_files.SelectedIndexChanged += new System.EventHandler(this.m_files_SelectedIndexChanged);
            // 
            // m_menu
            // 
            this.m_menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_save});
            resources.ApplyResources(this.m_menu, "m_menu");
            this.m_menu.Name = "m_menu";
            // 
            // m_save
            // 
            this.m_save.Name = "m_save";
            resources.ApplyResources(this.m_save, "m_save");
            this.m_save.Click += new System.EventHandler(this.saveChangesToolStripMenuItem_Click);
            // 
            // WorkSheetForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_files);
            this.Controls.Add(this.m_grid);
            this.Controls.Add(this.m_menu);
            this.MainMenuStrip = this.m_menu;
            this.Name = "WorkSheetForm";
            this.Load += new System.EventHandler(this.WorkSheetForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WorkSheetForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.m_grid)).EndInit();
            this.m_menu.ResumeLayout(false);
            this.m_menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView m_grid;
        private System.Windows.Forms.ComboBox m_files;
        private System.Windows.Forms.MenuStrip m_menu;
        private System.Windows.Forms.ToolStripMenuItem m_save;

    }
}