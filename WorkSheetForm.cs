using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Resources;
using System.Text;
using System.Windows.Forms;
using System.Xml;

using LocaleManager.services;
using LocaleManager.data;
using LocaleManager.utils;

namespace LocaleManager
{
    public partial class WorkSheetForm : Form
    {
        private readonly Color BaseColumnColor = Properties.Settings.Default.BaseColumnColor;
        private ResourceBundle _resBundle = ResourceBundle.GetInstance();

        private enum Columns
        {
            No = 0, File, Name, Base, Comment
        };

        private ResourcesFactory _resFactory = ResourcesFactory.GetInstance();
        private IResourceService _resService;

        private int _numOfCols;

        private bool _isDirty = false;

        private int _iLocaleStart = 0;

        private int _rowEdit = 0;
        private int _colEdit = 0;

        public WorkSheetForm()
        {
            InitializeComponent();
            this.m_save.Text = _resBundle.GetString("Forms", "Save");
            this.Text = _resBundle.GetString("Forms", "WorkSheetForm");
        }

        private void FillFileCombo()
        {
            FileInfo[] files = _resFactory.BaseDir.GetFiles("*" + _resFactory.Extension);
            if (null == files || files.Length == 0)
            {
                MessageBox.Show(_resBundle.GetString("Messages", "NoSupportedFielTypesFound"));
                this.Close();
                return;
            }

            m_files.Items.Add(_resBundle.GetString("Messages", "SelectAll"));
            foreach (FileInfo file in files)
                m_files.Items.Add(file.Name);
        }



        private void WorkSheetForm_Load(object sender, EventArgs e)
        {
            _resService = _resFactory.GetResourceService();

            FillFileCombo();

            InitDataGridColumns();

            //load all files to datagrid by Combo SelectedIndex change
            if (m_files.Items.Count > 0)
                m_files.SelectedIndex = 0;
        }

        private void InitDataGridColumns()
        {
            m_grid.ColumnCount = _resFactory.Locales.Length + (int)Columns.Base + 1;
            if (_resFactory.isNetResource)
            {
                m_grid.ColumnCount++;   //add one more column for comments
            }

            _numOfCols = m_grid.ColumnCount;

            m_grid.Columns[(int)Columns.No].Name = "no.";
            m_grid.Columns[(int)Columns.No].ValueType = typeof(int);
            m_grid.Columns[(int)Columns.No].Width = 30;

            m_grid.Columns[(int)Columns.File].Name = "file";
            m_grid.Columns[(int)Columns.Name].Name = "name";
            m_grid.Columns[(int)Columns.Base].Name = _resFactory.BaseDir.Name;

            if (_resFactory.isNetResource)
            {
                m_grid.Columns[(int)Columns.Comment].Name = "comments";
                _iLocaleStart = (int)Columns.Comment + 1;
            }
            else
                _iLocaleStart = (int)Columns.Base +1;

            int i = _iLocaleStart;

            foreach (string locale in _resFactory.Locales)
                m_grid.Columns[i++].Name = locale;
}

        private void m_files_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isDirty)
            {
                DialogResult dr = MessageBox.Show(_resBundle.GetString("Messages", "ChangeFileWarning"),
                     _resBundle.GetString("Messages", "Warning"), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                if (dr == DialogResult.Yes)
                {
                    return;
                }
            }

            m_grid.Rows.Clear();

            string file = (string)m_files.SelectedItem;
            if (file.EndsWith(_resFactory.Extension))
                loadFile(0, file);
            else
            {//all files
                int i = 0;
                foreach (object item in m_files.Items)
                {
                    file = (string)item;

                    if (!file.EndsWith(_resFactory.Extension))
                        continue;

                    i = loadFile(i, (string)item);
                }
            }
        }

        private int loadFile(int rowIndex, string file)
        {
            //load base file first
            string path = _resFactory.BaseDir.FullName + "\\" + file;
            if (!File.Exists(path))
            {
                MessageBox.Show(_resBundle.GetString("Messages", "FileNotExist") + ":  " + path);
                return rowIndex;
            }

            SortedDictionary<string, ResourceItem> kvps = _resService.Load(path);
            foreach (KeyValuePair<string, ResourceItem> kvp in kvps)
            {
                AddRowToGrid(file, rowIndex, kvp.Value);
                rowIndex++;
            }

            //load file for all selected target locales
            for (int i = 0; i < _resFactory.Locales.Length; i++)
            {
                path = GetLocaleFilePath(file, i);
                if (!File.Exists(path))
                {
                    MessageBox.Show(_resBundle.GetString("Messages", "FileNotExist") + ":  " + path);
                    continue;
                }
                kvps = _resService.Load(path);
                AddResourceItemsToGrid(file, i, kvps);
            }

            return rowIndex;
        }

        private string GetLocaleFilePath(string file, int localeIndex)
        {
            return _resFactory.RootDir.FullName + "\\" + _resFactory.Locales[localeIndex] + "\\" + file;
        }

        private void AddResourceItemsToGrid(string file, int localeIndex, SortedDictionary<string, ResourceItem> kvps)
        {
            foreach (KeyValuePair<string, ResourceItem> kvp in kvps)
            {
                ResourceItem item = kvp.Value;
                int row = findRowNo(file, item.key.Trim());
                if (row < 0)
                {//property not found in base
                    string line = item.key + ":  " + item.value + "\n";

                    LogUtils.Log(LogUtils.MismatchLog, line);
                }
                else if (null != item.value)
                    m_grid[getColumnNo(localeIndex),row].Value = item.value;
            }
        }

        private void AddRowToGrid(string file, int i, ResourceItem kvp)
        {
            string[] row;
            row = new string[_numOfCols];
            row[(int)Columns.No] = i.ToString();
            row[(int)Columns.File] = file;
            row[(int)Columns.Name] = kvp.key.Trim();
            row[(int)Columns.Base] = kvp.value.Trim();

            m_grid.Rows.Add(row);

            m_grid[(int)Columns.No, i].Value = i;  //restate it as a number

            m_grid[(int)Columns.Base, i].Style.BackColor = BaseColumnColor;
            m_grid[(int)Columns.Name, i].Style.BackColor = BaseColumnColor;

            if (_resFactory.isNetResource)
            {
                m_grid[(int)Columns.Comment, i].Value = kvp.comment.Trim();
                m_grid[(int)Columns.Comment, i].Style.BackColor = BaseColumnColor;
            }
        }
        
        private int getColumnNo(int localeIndex)
        {
            return _iLocaleStart + localeIndex;
        }

        //value is for saving to the log.  It won't be displayed
        private int findRowNo(string file, string name)
        {
            foreach (DataGridViewRow row in m_grid.Rows)
            {
                string baseFile=null;
                string baseName=null;
                if (null!=row.Cells[(int)Columns.File].Value)
                    baseFile = row.Cells[(int)Columns.File].Value.ToString();

                if (null != row.Cells[(int)Columns.Name].Value)
                    baseName = row.Cells[(int)Columns.Name].Value.ToString();

                if (file == baseFile && name == baseName)
                    return row.Index;
            }
            return -1;
        }

        private void saveChangesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Update();
            DialogResult dr = MessageBox.Show(_resBundle.GetString("Messages", "SaveWarning"), _resBundle.GetString("Messages", "Warning"), 
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

            if (dr != DialogResult.Yes)
                return;

            string file = (string)m_files.SelectedItem;

            if (file.EndsWith(_resFactory.Extension))
            {//save for a single property file
                saveLocaleFiles(file);
            }
            else
            {//save all files
                foreach (object item in m_files.Items)
                {
                    file = (string)item;
                    if (!file.EndsWith(_resFactory.Extension))
                        continue;

                    saveLocaleFiles(file);
                }
            }
        }

        private void saveLocaleFiles(string file)
        {
            for (int i = 0; i < _resFactory.Locales.Length; i++)
            {
                string path = GetLocaleFilePath(file, i);

                SortedDictionary<string, ResourceItem> kvps = GetResourceItemsFromGrid(file, i);
                
                _resService.Save(path, kvps);
            }

            _isDirty = false;
        }

        private SortedDictionary<string, ResourceItem> GetResourceItemsFromGrid(String file, int localeIndex)
        {
            SortedDictionary<string, ResourceItem> kvps = new SortedDictionary<string, ResourceItem>();
            foreach (DataGridViewRow row in m_grid.Rows)
            {
                ResourceItem kvp = getKeyValueFromGrid(file, localeIndex, row);
                if (kvp != null)
                    kvps.Add(kvp.key, kvp);
            }
            return kvps;
        }

        private ResourceItem getKeyValueFromGrid(string fileToSave, int localeIndex, DataGridViewRow row)
        {
            string baseFile = null;
            if (null != row.Cells[(int)Columns.File].Value)
                baseFile = row.Cells[(int)Columns.File].Value.ToString();
            else
            {//not supposed to happen
                throw new Exception("base file name was not found.");
            }

            if (baseFile != fileToSave)
                return null;  //not the file we are trying to save

            ResourceItem kvp = new ResourceItem();

            if (null != row.Cells[(int)Columns.Name].Value)
                kvp.key = row.Cells[(int)Columns.Name].Value.ToString();
            else
                kvp.key = "";

            if (null != row.Cells[getColumnNo(localeIndex)].Value)
                kvp.value = row.Cells[getColumnNo(localeIndex)].Value.ToString();
            else
                kvp.value = "";

            return kvp;
        }

        private void WorkSheetForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_isDirty)
                return;

            DialogResult dr = MessageBox.Show(_resBundle.GetString("Messages", "CloseWarning"),
                _resBundle.GetString("Messages", "Warning"), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

            if (dr != DialogResult.Yes)
            {
                e.Cancel = true;
                return;
            }
        }


        private void m_grid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            _isDirty = true;
        }

        private void m_grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < _iLocaleStart)
                return;

            _rowEdit = e.RowIndex;
            _colEdit = e.ColumnIndex;

            CellEditor editor = new CellEditor(m_grid[e.ColumnIndex, e.RowIndex].Value.ToString());
            editor.FormClosing += new FormClosingEventHandler(CellEditor_FormClosing);
            editor.Show(this);
        }

        private void CellEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            CellEditor editor = (CellEditor)sender;
            if (editor.DialogResult == DialogResult.OK)
            {
                if (editor.changed)
                {
                    m_grid[_colEdit, _rowEdit].Value = editor.text;
                }
            }

        }
    }
}