/* This file is part of ThemeMii
 * Copyright (C) 2009 Leathl
 * 
 * ThemeMii is free software: you can redistribute it and/or
 * modify it under the terms of the GNU General Public License as published
 * by the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * ThemeMii is distributed in the hope that it will be
 * useful, but WITHOUT ANY WARRANTY; without even the implied warranty
 * of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */

using System;
using System.IO;
//using System.Windows.Forms;
using System.Drawing;
using Avalonia.Controls;
using Avalonia.Interactivity;


namespace ThemeMii
{
    public partial class ThemeMii_AppBrowse : Window
    {
        private string rootPath;
        private string selectedPath = string.Empty;
        private bool viewOnly;
        private bool containerBrowse;
        private bool onlyTpls;

        public string RootPath 
        { 
            get => rootPath;
            set => rootPath = value;
        }
        
        public string SelectedPath 
        { 
            get => selectedPath;
            set => selectedPath = value;
        }

        public string FullPath => rootPath + selectedPath;

        public bool ViewOnly
        {
            get => viewOnly;
            set => viewOnly = value;
        }

        public bool ContainerBrowse
        {
            get =>  containerBrowse;
            set => containerBrowse = value; 
        } 
        
        public bool OnlyTpls { 
            get => onlyTpls;
            set => onlyTpls = value;
        }

        public ThemeMii_AppBrowse()
        {
            InitializeComponent();
        }

        private void ThemeMii_AppBrowse_Load(object sender, EventArgs e)
        {
            if (viewOnly) 
                SwitchToViewOnly();
            FillTreeView();

            /*
            if (!string.IsNullOrEmpty(this.selectedPath))
            {
                try
                {
                    string[] nodePath = selectedPath.Remove(0, 1).Split('\\');
                    TreeNode node = tvBrowse.Nodes["Root"];

                    foreach (string thisPath in nodePath)
                        node = node.Nodes[thisPath];

                    tvBrowse.SelectedNode = node;
                }
                catch { }
            }
            */
        }

        private void SwitchToViewOnly()
        {
            /*
            btnOK.Visible = false;
            this.AcceptButton = null;

            btnCancel.Text = "Close";
            btnCancel.Location = new System.Drawing.Point(0, btnCancel.Location.Y);
            btnCancel.Size = new System.Drawing.Size(446, btnCancel.Size.Height);
            */
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            //this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            /*
            if (tvBrowse.SelectedNode.Nodes.Count > 0) { tvBrowse.Select(); return; }

            if (onlyTpls && !tvBrowse.SelectedNode.Name.ToLower().EndsWith(".tpl"))
            {
                MessageBox.Show("Only TPLs are allowed for Static or Custom Images!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tvBrowse.Select(); return;
            }

            if (tvBrowse.SelectedNode == null) selectedPath = string.Empty;
            else selectedPath = tvBrowse.SelectedNode.FullPath.Remove(0, 4);
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
            */
        }

        private void FillTreeView()
        {
            /*
            TreeNode rootNode = new TreeNode("Root");
            rootNode.ImageIndex = 0; rootNode.SelectedImageIndex = 0;
            rootNode.Name = rootNode.Text;

            FillRecursive(rootPath, rootNode);
            rootNode.Expand();

            tvBrowse.Nodes.Add(rootNode);
            */
        }

        private void FillRecursive(string path, object node)
        {
            /*
            DirectoryInfo dInfo = new DirectoryInfo(path);

            foreach (DirectoryInfo thisInfo in dInfo.GetDirectories())
            {
                if (containerBrowse && thisInfo.Name.ToLower().Contains("_out")) continue;

                TreeNode newNode = new TreeNode(thisInfo.Name);
                newNode.ImageIndex = 0; newNode.SelectedImageIndex = 0;
                newNode.Name = newNode.Text;

                FillRecursive(thisInfo.FullName, newNode);

                node.Nodes.Add(newNode);
            }

            foreach (FileInfo thisInfo in dInfo.GetFiles())
            {
                if (!containerBrowse && Directory.Exists(Path.GetDirectoryName(thisInfo.FullName) + "\\" + Path.GetFileName(thisInfo.FullName).Replace(".", "_") + "_out")) continue;

                TreeNode newNode = new TreeNode(thisInfo.Name);
                newNode.ImageIndex = 1; newNode.SelectedImageIndex = 1;
                newNode.Name = newNode.Text;

                node.Nodes.Add(newNode);
            }
            */
        }

        private void tvBrowse_AfterSelect(object sender, RoutedEventArgs e)
        {
            /*
            if (tvBrowse.SelectedNode.ImageIndex == 1)
            {
                btnExtract.Enabled = true;

                if (tvBrowse.SelectedNode.Text.ToLower().EndsWith(".tpl") ||
                    tvBrowse.SelectedNode.Text.ToLower().EndsWith(".jpg") ||
                    tvBrowse.SelectedNode.Text.ToLower().EndsWith(".png") ||
                    tvBrowse.SelectedNode.Text.ToLower().EndsWith(".gif"))
                    btnPreview.Enabled = true;
                else btnPreview.Enabled = false;
            }
            else
            {
                btnExtract.Enabled = false;
                btnPreview.Enabled = false;
            }
            */
        }

        private void btnExtract_Click(object sender, EventArgs e)
        {
            /*
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = tvBrowse.SelectedNode.Text;

            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                File.Copy(rootPath + "\\" + tvBrowse.SelectedNode.FullPath.Remove(0, 4), sfd.FileName, true);
                MessageBox.Show("Extracted file to:\n" + sfd.FileName, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            */
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            /*
            try
            {
                string nodePath = rootPath + "\\" + tvBrowse.SelectedNode.FullPath.Remove(0, 4);
                Image img;

                if (nodePath.ToLower().EndsWith(".tpl"))
                    img = Wii.TPL.ConvertFromTPL(nodePath);
                else
                {
                    byte[] fourBytes = Wii.Tools.LoadFileToByteArray(nodePath, 0, 4);

                    if (fourBytes[0] == 'L' && fourBytes[1] == 'Z' && fourBytes[2] == '7' && fourBytes[3] == '7')
                    {
                        byte[] imageFile = Wii.Lz77.Decompress(File.ReadAllBytes(nodePath), 0);
                        img = Image.FromStream(new MemoryStream(imageFile));
                    }
                    else img = Image.FromFile(nodePath);
                }

                PictureBox pb = new PictureBox();
                pb.Dock = DockStyle.Fill;
                pb.SizeMode = PictureBoxSizeMode.CenterImage;
                pb.Image = img;

                Form preview = new Form();
                preview.Controls.Add(pb);
                preview.Size = new Size((img.Width < 300) ? 350 : img.Width + 50, (img.Height < 300) ? 350 : img.Height + 50);
                preview.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
                preview.StartPosition = FormStartPosition.CenterParent;

                if (nodePath.ToLower().EndsWith(".tpl"))
                    preview.Text = string.Format("{0} ({1} x {2}) - TPL Format: {3}", Path.GetFileName(nodePath), img.Width, img.Height, Wii.TPL.GetTextureFormatName(File.ReadAllBytes(nodePath)));
                else
                    preview.Text = string.Format("{0} ({1} x {2})", Path.GetFileName(nodePath), img.Width, img.Height);

                preview.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            */
        }
    }
}
