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
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Platform.Storage;


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

        private void ThemeMii_AppBrowse_Load(object? sender, RoutedEventArgs e)
        {
            if (viewOnly) 
                SwitchToViewOnly();
            FillTreeView();

            
            if (!string.IsNullOrEmpty(selectedPath))
            {
                try
                {
                    var nodePath = selectedPath.Remove(0, 1).Split('\\');
                    TreeNode node = tvBrowse.ItemsSource!.Cast<TreeNode>().First(x => x.Name == "Root");

                    //What is this for!?!?!?
                    //foreach (string thisPath in nodePath)
                    //    node = node.Nodes[thisPath];

                    tvBrowse.SelectedItem = node;
                }
                catch { }
            }
            
        }

        private void SwitchToViewOnly()
        {
            
            btnOK.IsVisible = false;

            //btnCancel. = "Close";
            //btnCancel.Location = new System.Drawing.Point(0, btnCancel.Location.Y);
            //btnCancel.Size = new System.Drawing.Size(446, btnCancel.Size.Height);
            
        }

        private void btnCancel_Click(object? sender, RoutedEventArgs e)
        {
            Close();
        }

        private async void btnOK_Click(object sender, RoutedEventArgs e)
        {

            if (((TreeNode)tvBrowse.SelectedItem).Children.Count > 0)
            {
                return;
            }

            if (onlyTpls && !((TreeNode)tvBrowse.SelectedItem).Name.ToLower().EndsWith(".tpl"))
            {
                await MessageBoxHelper.DisplayErrorMessage("Only TPLs are allowed for Static or Custom Images!");
                return;
            }

            if (tvBrowse.SelectedItem == null) 
                selectedPath = string.Empty;
            else 
                selectedPath = ((TreeNode)tvBrowse.SelectedItem).Name.Remove(0, 4);
            
            Close();
            
        }

        private void FillTreeView()
        {
            TreeNode rootNode = new TreeNode("Root");
            FillRecursive(rootPath, rootNode);
            tvBrowse.ItemsSource = new List<TreeNode>() { rootNode };
        }

        private void FillRecursive(string path, TreeNode rootNode)
        {
            if (string.IsNullOrEmpty(path))
                return;
            
            DirectoryInfo dInfo = new DirectoryInfo(path);

            foreach (DirectoryInfo thisInfo in dInfo.GetDirectories())
            {
                if (containerBrowse && thisInfo.Name.ToLower().Contains("_out"))
                    continue;

                TreeNode newNode = new TreeNode(thisInfo.Name);
                FillRecursive(thisInfo.FullName, newNode);

                rootNode.Children.Add(newNode);
            }

            foreach (FileInfo thisInfo in dInfo.GetFiles())
            {
                if (!containerBrowse && 
                    Directory.Exists(
                        Path.Combine(
                            Path.GetDirectoryName(thisInfo.FullName) ?? string.Empty,
                            Path.GetFileName(thisInfo.FullName).Replace(".", "_") + "_out")
                        )
                    ) 
                    continue;

                TreeNode newNode = new TreeNode(thisInfo.Name);

                rootNode.Children.Add(newNode);
            }
            
        }

        private void tvBrowse_AfterSelect(object sender, SelectionChangedEventArgs e)
        {
            //This support to represent just one, maybe?
            if (((TreeNode)tvBrowse.SelectedItem).Children.Count == 0)
            {
                btnExtract.IsEnabled = true;

                btnPreview.IsEnabled = ((TreeNode)tvBrowse.SelectedItem).Name.ToLower().EndsWith(".tpl") ||
                                       ((TreeNode)tvBrowse.SelectedItem).Name.ToLower().EndsWith(".jpg") ||
                                       ((TreeNode)tvBrowse.SelectedItem).Name.ToLower().EndsWith(".png") ||
                                       ((TreeNode)tvBrowse.SelectedItem).Name.ToLower().EndsWith(".gif");
            }
            else
            {
                btnExtract.IsEnabled = false;
                btnPreview.IsEnabled = false;
            }
        }

        private async void btnExtract_Click(object? sender, RoutedEventArgs e)
        {
            var fileStorage = StorageProvider;
            var result = await fileStorage.SaveFilePickerAsync(new FilePickerSaveOptions()
            {
                SuggestedFileName = ((TreeNode)tvBrowse.SelectedItem).Name
            });

            if (result != null)
            {
                File.Copy(Path.Combine(rootPath, ((TreeNode)tvBrowse.SelectedItem).Name.Remove(0, 4)), 
                    result.Path.AbsolutePath, true);
                await MessageBoxHelper.DisplayInfoBox($"Extracted file to:\n{result.Path.AbsolutePath}");
            }
            
        }

        private async void btnPreview_Click(object? sender, RoutedEventArgs e)
        {
            try
            {
                /*
                string nodePath = Path.Combine(rootPath, ((TreeNode)tvBrowse.SelectedItem).Name.Remove(0, 4));
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
                */
            }
            catch (Exception ex)
            {
                await MessageBoxHelper.DisplayErrorMessage(ex.Message);
            }
        }
    }
    
    public class TreeNode
    {
        public TreeNode(string name)
        {
            Name = name;
            Children = new List<TreeNode>();
        }
        
        public string Name { get; set; }
        
        public List<TreeNode> Children { get; set; }
    }
}
