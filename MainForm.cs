using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Windows.Forms;

using LocaleManager.services;
using LocaleManager.utils;

namespace LocaleManager
{
    public partial class MainForm : Form
    {
        private ResourcesFactory _resFactory = ResourcesFactory.GetInstance();

        private ResourceBundle resBundle;

        public MainForm()
        {
            InitializeComponent();
            resBundle = ResourceBundle.GetInstance();

        }

        public override void Refresh()
        {
            this.m_browse.Text = resBundle.GetString("Forms", "SelectBase");
            this.m_load.Text = resBundle.GetString("Forms", "Load");
            this.m_baseLocale.Text = "";
            this.label1.Text = resBundle.GetString("Forms", "ExistingLocales");
            this.label2.Text = resBundle.GetString("Forms", "SelectedLocales");
            this.m_create.Text = resBundle.GetString("Forms", "CreateNewLocale");
            this.Text = resBundle.GetString("Forms", "MainFormCaption");
            m_appLangue.Text = resBundle.GetString("Forms", "ChangeLanguage");

            base.Refresh();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Refresh();

            fillAppLangueCombo();
        }

        private void fillAppLangueCombo()
        {
            CultureInfo enCulture = new CultureInfo(SpecificCultures.EN_US);
            CultureInfo zhCulture = new CultureInfo(SpecificCultures.ZH_CN);
//            CultureInfo frCulture = new CultureInfo(SpecificCultures.FR_FR);
            m_appLangue.Items.Add(enCulture);
            m_appLangue.Items.Add(zhCulture);
//            m_appLangue.Items.Add(frCulture);
        }

        private void m_browse_Click(object sender, EventArgs e)
        {
            string lastDir = Properties.Settings.Default.LastBaseDir;
            if ( lastDir!= null && lastDir.Length>0)
                m_baseDirBrowserDlg.SelectedPath = lastDir;
            else
                m_baseDirBrowserDlg.SelectedPath = Environment.CurrentDirectory;
            if (m_baseDirBrowserDlg.ShowDialog(this) != DialogResult.OK)
                return;

            _resFactory.BaseDir = new DirectoryInfo(m_baseDirBrowserDlg.SelectedPath);
            Properties.Settings.Default.LastBaseDir = m_baseDirBrowserDlg.SelectedPath;
            Properties.Settings.Default.Save();

            m_baseLocale.Text = _resFactory.BaseDir.Name;

            if (!_resFactory.IsSupported)
                MessageBox.Show(resBundle.GetString("Messages", "NoSupportedFielTypesFound"));
            else
                fillLocaleList();
        }

        private void fillLocaleList()
        {
            m_allLocales.Items.Clear();
            m_selectedLocale.Items.Clear();

            DirectoryInfo[] subs = _resFactory.RootDir.GetDirectories();

            foreach (DirectoryInfo sub in subs)
            {
                String dirName = sub.Name;
                if (dirName != _resFactory.BaseDir.Name)
                    m_allLocales.Items.Add(dirName);
            }

            initCreate();

            if (m_allLocales.Items.Count > 0)
            {
                initAddLocale();
            }
            else
                MessageBox.Show(resBundle.GetString("Messages", "NoOtherLocalesFound"));
        }

        private void initCreate()
        {
            m_create.Enabled = true;

            CultureInfo[] allCultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
          //Array.Sort(allCultures);

            foreach (CultureInfo c in allCultures)
            {
                m_langue.Items.Add(c);
            }
            
            m_langue.SelectedIndex = 0;
        }

        private void initAddLocale()
        {
            m_add.Enabled = true;
            m_addAll.Enabled = true;
            m_allLocales.SelectedIndex = 0;
        }

        private void m_langue_SelectedIndexChanged(object sender, EventArgs e)
        {
            CultureInfo c = (CultureInfo)(m_langue.SelectedItem);
            m_locale.Text = c.Name;
        }


        private void m_load_Click(object sender, EventArgs e)
        {
            _resFactory.Locales = new string[m_selectedLocale.Items.Count];
            int i=0;
            foreach (object item in m_selectedLocale.Items)
                _resFactory.Locales[i++] = (string)item;

            WorkSheetForm wrkForm = new WorkSheetForm();
            wrkForm.ShowDialog();
        }

        private void m_add_Click(object sender, EventArgs e)
        {
            object item = m_allLocales.SelectedItem;
            if (null != item)
            {
                m_allLocales.Items.Remove(item);
                m_selectedLocale.Items.Add(item);
            }
            checkButtonsEnable();
        }

        private void m_addAll_Click(object sender, EventArgs e)
        {
            foreach (object item in m_allLocales.Items)
            {
                m_selectedLocale.Items.Add(item);
            }
            m_allLocales.Items.Clear();
            checkButtonsEnable();
        }

        private void m_remove_Click(object sender, EventArgs e)
        {
            object item = m_selectedLocale.SelectedItem;
            if (null != item)
            {
                m_selectedLocale.Items.Remove(item);
                m_allLocales.Items.Add(item);
            }
            checkButtonsEnable();
        }

        private void m_removeAll_Click(object sender, EventArgs e)
        {
            foreach (object item in m_selectedLocale.Items)
            {
                m_allLocales.Items.Add(item);
            }
            m_selectedLocale.Items.Clear();

            checkButtonsEnable();
        }

        private void checkButtonsEnable()
        {
            if (m_selectedLocale.Items.Count > 0)
            {
                m_remove.Enabled = true;
                m_removeAll.Enabled = true;
                m_load.Enabled = true;
            }

            if (m_allLocales.Items.Count > 0)
            {
                m_add.Enabled = true;
                m_addAll.Enabled = true;
            }
        }


        private void m_create_Click(object sender, EventArgs e)
        {
            if (m_locale.Text.Length == 0)
            {
                MessageBox.Show(resBundle.GetString("Messages", "LocaleNameBlankError"));
                return;
            }
            else
            {   
                string path = _resFactory.RootDir.FullName + "\\" + m_locale.Text;
                //create new locale dir
                _resFactory.RootDir.CreateSubdirectory(m_locale.Text);
                //copy all files in base locale to new locale dir
                FileInfo[] files = _resFactory.BaseDir.GetFiles("*" + _resFactory.Extension);
                foreach (FileInfo file in files)
                {
                    string copyToPath=path + "\\" + file.Name;
                    if (File.Exists(path))
                    {
                        DialogResult dr = MessageBox.Show(String.Format(resBundle.GetString("Messages", "FileExistWarning"), path),
                            resBundle.GetString("Messages", "Warning"),
                            MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                        if (dr != DialogResult.Yes)
                            continue; //skip this file

                    }
                    file.CopyTo(copyToPath, true);
                }
                m_selectedLocale.Items.Add(m_locale.Text);

                checkButtonsEnable();
            }
        }

        private void m_appLangue_SelectedIndexChanged(object sender, EventArgs e)
        {
            CultureInfo culture = (CultureInfo)m_appLangue.SelectedItem;
            resBundle.Locale = culture.Name;

            Application.CurrentCulture = culture;
            Properties.Settings.Default.LastCulture = culture.Name;
            Properties.Settings.Default.Save();
            this.Refresh();
        }
    }
}