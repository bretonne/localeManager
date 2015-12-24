namespace LocaleManager
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.m_baseDirBrowserDlg = new System.Windows.Forms.FolderBrowserDialog();
            this.m_browse = new System.Windows.Forms.Button();
            this.m_load = new System.Windows.Forms.Button();
            this.m_baseLocale = new System.Windows.Forms.Label();
            this.m_allLocales = new System.Windows.Forms.ListBox();
            this.m_selectedLocale = new System.Windows.Forms.ListBox();
            this.m_add = new System.Windows.Forms.Button();
            this.m_removeAll = new System.Windows.Forms.Button();
            this.m_remove = new System.Windows.Forms.Button();
            this.m_addAll = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.m_langue = new System.Windows.Forms.ComboBox();
            this.m_create = new System.Windows.Forms.Button();
            this.m_locale = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.m_appLangue = new System.Windows.Forms.ComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_baseDirBrowserDlg
            // 
            this.m_baseDirBrowserDlg.ShowNewFolderButton = false;
            // 
            // m_browse
            // 
            this.m_browse.BackColor = System.Drawing.Color.Olive;
            resources.ApplyResources(this.m_browse, "m_browse");
            this.m_browse.Name = "m_browse";
            this.m_browse.UseVisualStyleBackColor = false;
            this.m_browse.Click += new System.EventHandler(this.m_browse_Click);
            // 
            // m_load
            // 
            this.m_load.BackColor = System.Drawing.Color.Olive;
            resources.ApplyResources(this.m_load, "m_load");
            this.m_load.Name = "m_load";
            this.m_load.UseVisualStyleBackColor = false;
            this.m_load.Click += new System.EventHandler(this.m_load_Click);
            // 
            // m_baseLocale
            // 
            resources.ApplyResources(this.m_baseLocale, "m_baseLocale");
            this.m_baseLocale.ForeColor = System.Drawing.Color.Red;
            this.m_baseLocale.Name = "m_baseLocale";
            // 
            // m_allLocales
            // 
            this.m_allLocales.FormattingEnabled = true;
            resources.ApplyResources(this.m_allLocales, "m_allLocales");
            this.m_allLocales.Name = "m_allLocales";
            // 
            // m_selectedLocale
            // 
            this.m_selectedLocale.FormattingEnabled = true;
            resources.ApplyResources(this.m_selectedLocale, "m_selectedLocale");
            this.m_selectedLocale.Name = "m_selectedLocale";
            // 
            // m_add
            // 
            resources.ApplyResources(this.m_add, "m_add");
            this.m_add.Name = "m_add";
            this.m_add.UseVisualStyleBackColor = true;
            this.m_add.Click += new System.EventHandler(this.m_add_Click);
            // 
            // m_removeAll
            // 
            resources.ApplyResources(this.m_removeAll, "m_removeAll");
            this.m_removeAll.Name = "m_removeAll";
            this.m_removeAll.UseVisualStyleBackColor = true;
            this.m_removeAll.Click += new System.EventHandler(this.m_removeAll_Click);
            // 
            // m_remove
            // 
            resources.ApplyResources(this.m_remove, "m_remove");
            this.m_remove.Name = "m_remove";
            this.m_remove.UseVisualStyleBackColor = true;
            this.m_remove.Click += new System.EventHandler(this.m_remove_Click);
            // 
            // m_addAll
            // 
            resources.ApplyResources(this.m_addAll, "m_addAll");
            this.m_addAll.Name = "m_addAll";
            this.m_addAll.UseVisualStyleBackColor = true;
            this.m_addAll.Click += new System.EventHandler(this.m_addAll_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.m_baseLocale);
            this.groupBox2.Controls.Add(this.m_browse);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.m_addAll);
            this.groupBox2.Controls.Add(this.m_remove);
            this.groupBox2.Controls.Add(this.m_removeAll);
            this.groupBox2.Controls.Add(this.m_add);
            this.groupBox2.Controls.Add(this.m_selectedLocale);
            this.groupBox2.Controls.Add(this.m_allLocales);
            this.groupBox2.Controls.Add(this.m_load);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // m_langue
            // 
            this.m_langue.FormattingEnabled = true;
            resources.ApplyResources(this.m_langue, "m_langue");
            this.m_langue.Name = "m_langue";
            this.m_langue.SelectedIndexChanged += new System.EventHandler(this.m_langue_SelectedIndexChanged);
            // 
            // m_create
            // 
            this.m_create.BackColor = System.Drawing.Color.Olive;
            resources.ApplyResources(this.m_create, "m_create");
            this.m_create.Name = "m_create";
            this.m_create.UseVisualStyleBackColor = false;
            this.m_create.Click += new System.EventHandler(this.m_create_Click);
            // 
            // m_locale
            // 
            resources.ApplyResources(this.m_locale, "m_locale");
            this.m_locale.Name = "m_locale";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.m_locale);
            this.groupBox3.Controls.Add(this.m_langue);
            this.groupBox3.Controls.Add(this.m_create);
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // m_appLangue
            // 
            this.m_appLangue.FormattingEnabled = true;
            resources.ApplyResources(this.m_appLangue, "m_appLangue");
            this.m_appLangue.Name = "m_appLangue";
            this.m_appLangue.SelectedIndexChanged += new System.EventHandler(this.m_appLangue_SelectedIndexChanged);
            // 
            // menuStrip1
            // 
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_appLangue);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.menuStrip1);
            this.Name = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog m_baseDirBrowserDlg;
        private System.Windows.Forms.Button m_browse;
        private System.Windows.Forms.Button m_load;
        private System.Windows.Forms.Label m_baseLocale;
        private System.Windows.Forms.ListBox m_allLocales;
        private System.Windows.Forms.ListBox m_selectedLocale;
        private System.Windows.Forms.Button m_add;
        private System.Windows.Forms.Button m_removeAll;
        private System.Windows.Forms.Button m_remove;
        private System.Windows.Forms.Button m_addAll;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox m_langue;
        private System.Windows.Forms.Button m_create;
        private System.Windows.Forms.TextBox m_locale;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox m_appLangue;
        private System.Windows.Forms.MenuStrip menuStrip1;
    }
}

