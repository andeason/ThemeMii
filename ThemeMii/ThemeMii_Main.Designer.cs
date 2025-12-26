//TODO:  This is getting scrapped entirely once we move everything over to Avalonia

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
 
/*
namespace ThemeMii
{
    partial class ThemeMii_Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components;

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
            this.lbxIniEntries = new System.Windows.Forms.ListBox();
            this.panContainer = new System.Windows.Forms.Panel();
            this.lbContainerInfo = new System.Windows.Forms.Label();
            this.btnContainerBrowseFile = new System.Windows.Forms.Button();
            this.lbCont = new System.Windows.Forms.Label();
            this.cmbContainerFormat = new System.Windows.Forms.ComboBox();
            this.lbContainerType = new System.Windows.Forms.Label();
            this.tbContainerFile = new System.Windows.Forms.TextBox();
            this.lbContainerFile = new System.Windows.Forms.Label();
            this.panCustomImage = new System.Windows.Forms.Panel();
            this.btnCustomImageBrowseFile = new System.Windows.Forms.Button();
            this.cmbCustomImageFormat = new System.Windows.Forms.ComboBox();
            this.lbCimg = new System.Windows.Forms.Label();
            this.tbCustomImageHeight = new System.Windows.Forms.TextBox();
            this.tbCustomImageWidth = new System.Windows.Forms.TextBox();
            this.tbCustomImageName = new System.Windows.Forms.TextBox();
            this.lbCustomImageFormat = new System.Windows.Forms.Label();
            this.lbCustomImageHeight = new System.Windows.Forms.Label();
            this.lbCustomImageWidth = new System.Windows.Forms.Label();
            this.lbCustomImageName = new System.Windows.Forms.Label();
            this.tbCustomImageFile = new System.Windows.Forms.TextBox();
            this.lbCustomImageFile = new System.Windows.Forms.Label();
            this.panStaticImage = new System.Windows.Forms.Panel();
            this.btnStaticImageBrowseFile = new System.Windows.Forms.Button();
            this.btnStaticImageBrowse = new System.Windows.Forms.Button();
            this.cmbStaticImageFormat = new System.Windows.Forms.ComboBox();
            this.lbSimg = new System.Windows.Forms.Label();
            this.tbStaticImageFilepath = new System.Windows.Forms.TextBox();
            this.tbStaticImageHeight = new System.Windows.Forms.TextBox();
            this.tbStaticImageWidth = new System.Windows.Forms.TextBox();
            this.tbStaticImageSource = new System.Windows.Forms.TextBox();
            this.lbStaticImageFilepath = new System.Windows.Forms.Label();
            this.lbStaticImageFormat = new System.Windows.Forms.Label();
            this.lbStaticImageHeight = new System.Windows.Forms.Label();
            this.lbStaticImageWidth = new System.Windows.Forms.Label();
            this.lbStaticImageSource = new System.Windows.Forms.Label();
            this.tbStaticImageFile = new System.Windows.Forms.TextBox();
            this.lbStaticImageFile = new System.Windows.Forms.Label();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.msMain = new System.Windows.Forms.MenuStrip();
            this.msFile = new System.Windows.Forms.ToolStripMenuItem();
            this.msNew = new System.Windows.Forms.ToolStripMenuItem();
            this.msOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.msSave = new System.Windows.Forms.ToolStripMenuItem();
            this.msFileSep = new System.Windows.Forms.ToolStripSeparator();
            this.msExit = new System.Windows.Forms.ToolStripMenuItem();
            this.msList = new System.Windows.Forms.ToolStripMenuItem();
            this.msAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.msAddContainer = new System.Windows.Forms.ToolStripMenuItem();
            this.msAddStaticImage = new System.Windows.Forms.ToolStripMenuItem();
            this.msAddStaticData = new System.Windows.Forms.ToolStripMenuItem();
            this.msAddCustomImage = new System.Windows.Forms.ToolStripMenuItem();
            this.msAddCustomData = new System.Windows.Forms.ToolStripMenuItem();
            this.msRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.msMoveUp = new System.Windows.Forms.ToolStripMenuItem();
            this.msMoveDown = new System.Windows.Forms.ToolStripMenuItem();
            this.msMoveStart = new System.Windows.Forms.ToolStripMenuItem();
            this.msMoveEnd = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.msRemoveMissingStatics = new System.Windows.Forms.ToolStripMenuItem();
            this.msOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.msSourceManage = new System.Windows.Forms.ToolStripMenuItem();
            this.msContainerManage = new System.Windows.Forms.ToolStripMenuItem();
            this.msIgnoreMissingEntries = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.msImageSizeFromTpl = new System.Windows.Forms.ToolStripMenuItem();
            this.msImageSizeFromPng = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.msLz77Containers = new System.Windows.Forms.ToolStripMenuItem();
            this.msSaveNandPath = new System.Windows.Forms.ToolStripMenuItem();
            this.msKeepExtractedApp = new System.Windows.Forms.ToolStripMenuItem();
            this.msSavePrompt = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.msStandardSysMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.ms32 = new System.Windows.Forms.ToolStripMenuItem();
            this.ms32J = new System.Windows.Forms.ToolStripMenuItem();
            this.ms32U = new System.Windows.Forms.ToolStripMenuItem();
            this.ms32E = new System.Windows.Forms.ToolStripMenuItem();
            this.ms40 = new System.Windows.Forms.ToolStripMenuItem();
            this.ms40J = new System.Windows.Forms.ToolStripMenuItem();
            this.ms40U = new System.Windows.Forms.ToolStripMenuItem();
            this.ms40E = new System.Windows.Forms.ToolStripMenuItem();
            this.ms41 = new System.Windows.Forms.ToolStripMenuItem();
            this.ms41J = new System.Windows.Forms.ToolStripMenuItem();
            this.ms41U = new System.Windows.Forms.ToolStripMenuItem();
            this.ms41E = new System.Windows.Forms.ToolStripMenuItem();
            this.ms42 = new System.Windows.Forms.ToolStripMenuItem();
            this.ms42J = new System.Windows.Forms.ToolStripMenuItem();
            this.ms42U = new System.Windows.Forms.ToolStripMenuItem();
            this.ms42E = new System.Windows.Forms.ToolStripMenuItem();
            this.msChangeNandPath = new System.Windows.Forms.ToolStripMenuItem();
            this.msTools = new System.Windows.Forms.ToolStripMenuItem();
            this.msCsmToMym = new System.Windows.Forms.ToolStripMenuItem();
            this.msBrowseBaseApp = new System.Windows.Forms.ToolStripMenuItem();
            this.msInstallToNandBackup = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.msDownloadBaseApp = new System.Windows.Forms.ToolStripMenuItem();
            this.msDownload32 = new System.Windows.Forms.ToolStripMenuItem();
            this.msDownload32J = new System.Windows.Forms.ToolStripMenuItem();
            this.msDownload32U = new System.Windows.Forms.ToolStripMenuItem();
            this.msDownload32E = new System.Windows.Forms.ToolStripMenuItem();
            this.msDownload40 = new System.Windows.Forms.ToolStripMenuItem();
            this.msDownload40J = new System.Windows.Forms.ToolStripMenuItem();
            this.msDownload40U = new System.Windows.Forms.ToolStripMenuItem();
            this.msDownload40E = new System.Windows.Forms.ToolStripMenuItem();
            this.msDownload41 = new System.Windows.Forms.ToolStripMenuItem();
            this.msDownload41J = new System.Windows.Forms.ToolStripMenuItem();
            this.msDownload41U = new System.Windows.Forms.ToolStripMenuItem();
            this.msDownload41E = new System.Windows.Forms.ToolStripMenuItem();
            this.msDownload42 = new System.Windows.Forms.ToolStripMenuItem();
            this.msDownload42J = new System.Windows.Forms.ToolStripMenuItem();
            this.msDownload42U = new System.Windows.Forms.ToolStripMenuItem();
            this.msDownload42E = new System.Windows.Forms.ToolStripMenuItem();
            this.msQuestion = new System.Windows.Forms.ToolStripMenuItem();
            this.msHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.msAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.btnMinus = new System.Windows.Forms.Button();
            this.btnPlus = new System.Windows.Forms.Button();
            this.panCustomData = new System.Windows.Forms.Panel();
            this.btnCustomDataBrowseFile = new System.Windows.Forms.Button();
            this.lbCdta = new System.Windows.Forms.Label();
            this.tbCustomDataName = new System.Windows.Forms.TextBox();
            this.lbCustomDataName = new System.Windows.Forms.Label();
            this.tbCustomDataFile = new System.Windows.Forms.TextBox();
            this.lbCustomDataFile = new System.Windows.Forms.Label();
            this.panStaticData = new System.Windows.Forms.Panel();
            this.btnStaticDataBrowseFile = new System.Windows.Forms.Button();
            this.btnStaticDataBrowse = new System.Windows.Forms.Button();
            this.tbStaticDataFilepath = new System.Windows.Forms.TextBox();
            this.lbStaticDataFilepath = new System.Windows.Forms.Label();
            this.lbSdta = new System.Windows.Forms.Label();
            this.tbStaticDataSource = new System.Windows.Forms.TextBox();
            this.lbStaticDataSource = new System.Windows.Forms.Label();
            this.tbStaticDataFile = new System.Windows.Forms.TextBox();
            this.lbStaticDataFile = new System.Windows.Forms.Label();
            this.panEmpty = new System.Windows.Forms.Panel();
            this.ssStatus = new System.Windows.Forms.StatusStrip();
            this.pbProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.lbStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnSaveMym = new System.Windows.Forms.Button();
            this.btnCreateCsm = new System.Windows.Forms.Button();
            this.cmAdd = new System.Windows.Forms.ContextMenuStrip();
            this.cmAddContainer = new System.Windows.Forms.ToolStripMenuItem();
            this.cmAddStaticImage = new System.Windows.Forms.ToolStripMenuItem();
            this.cmAddStaticData = new System.Windows.Forms.ToolStripMenuItem();
            this.cmAddCustomImage = new System.Windows.Forms.ToolStripMenuItem();
            this.cmAddCustomData = new System.Windows.Forms.ToolStripMenuItem();
            this.panList = new System.Windows.Forms.Panel();
            this.panButtons = new System.Windows.Forms.Panel();
            this.panPanels = new System.Windows.Forms.Panel();
            this.msHealthTutorial = new System.Windows.Forms.ToolStripMenuItem();
            this.panContainer.SuspendLayout();
            this.panCustomImage.SuspendLayout();
            this.panStaticImage.SuspendLayout();
            this.msMain.SuspendLayout();
            this.panCustomData.SuspendLayout();
            this.panStaticData.SuspendLayout();
            this.ssStatus.SuspendLayout();
            this.cmAdd.SuspendLayout();
            this.panList.SuspendLayout();
            this.panButtons.SuspendLayout();
            this.panPanels.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbxIniEntries
            // 
            this.lbxIniEntries.AllowDrop = true;
            this.lbxIniEntries.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lbxIniEntries.FormattingEnabled = true;
            this.lbxIniEntries.Location = new System.Drawing.Point(8, 6);
            this.lbxIniEntries.Name = "lbxIniEntries";
            this.lbxIniEntries.Size = new System.Drawing.Size(127, 277);
            this.lbxIniEntries.TabIndex = 0;
            this.lbxIniEntries.SelectedIndexChanged += new System.EventHandler(this.lbxIniEntrys_SelectedIndexChanged);
            this.lbxIniEntries.DragDrop += new System.Windows.Forms.DragEventHandler(this.ThemeMii_Main_DragDrop);
            this.lbxIniEntries.DragEnter += new System.Windows.Forms.DragEventHandler(this.ThemeMii_Main_DragEnter);
            // 
            // panContainer
            // 
            this.panContainer.AllowDrop = true;
            this.panContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panContainer.Controls.Add(this.lbContainerInfo);
            this.panContainer.Controls.Add(this.btnContainerBrowseFile);
            this.panContainer.Controls.Add(this.lbCont);
            this.panContainer.Controls.Add(this.cmbContainerFormat);
            this.panContainer.Controls.Add(this.lbContainerType);
            this.panContainer.Controls.Add(this.tbContainerFile);
            this.panContainer.Controls.Add(this.lbContainerFile);
            this.panContainer.Location = new System.Drawing.Point(8, 6);
            this.panContainer.Name = "panContainer";
            this.panContainer.Size = new System.Drawing.Size(224, 303);
            this.panContainer.TabIndex = 1;
            this.panContainer.Visible = false;
            this.panContainer.DragDrop += new System.Windows.Forms.DragEventHandler(this.ThemeMii_Main_DragDrop);
            this.panContainer.DragEnter += new System.Windows.Forms.DragEventHandler(this.ThemeMii_Main_DragEnter);
            // 
            // lbContainerInfo
            // 
            this.lbContainerInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbContainerInfo.Location = new System.Drawing.Point(13, 109);
            this.lbContainerInfo.Name = "lbContainerInfo";
            this.lbContainerInfo.Size = new System.Drawing.Size(189, 48);
            this.lbContainerInfo.TabIndex = 11;
            this.lbContainerInfo.Text = "Type is obsolete for ThemeMii, as it will automatically check each container for " +
                "compression.";
            this.lbContainerInfo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnContainerBrowseFile
            // 
            this.btnContainerBrowseFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnContainerBrowseFile.Location = new System.Drawing.Point(181, 44);
            this.btnContainerBrowseFile.Name = "btnContainerBrowseFile";
            this.btnContainerBrowseFile.Size = new System.Drawing.Size(21, 20);
            this.btnContainerBrowseFile.TabIndex = 10;
            this.btnContainerBrowseFile.Text = "..";
            this.btnContainerBrowseFile.UseVisualStyleBackColor = true;
            this.btnContainerBrowseFile.Click += new System.EventHandler(this.btnBrowseFile_Click);
            // 
            // lbCont
            // 
            this.lbCont.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbCont.Location = new System.Drawing.Point(0, 16);
            this.lbCont.Name = "lbCont";
            this.lbCont.Size = new System.Drawing.Size(224, 13);
            this.lbCont.TabIndex = 4;
            this.lbCont.Text = "[contX]";
            this.lbCont.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cmbContainerFormat
            // 
            this.cmbContainerFormat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbContainerFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbContainerFormat.FormattingEnabled = true;
            this.cmbContainerFormat.Items.AddRange(new object[] {
            "ASH|U8",
            "U8"});
            this.cmbContainerFormat.Location = new System.Drawing.Point(53, 75);
            this.cmbContainerFormat.Name = "cmbContainerFormat";
            this.cmbContainerFormat.Size = new System.Drawing.Size(149, 21);
            this.cmbContainerFormat.TabIndex = 3;
            // 
            // lbContainerType
            // 
            this.lbContainerType.AutoSize = true;
            this.lbContainerType.Location = new System.Drawing.Point(13, 78);
            this.lbContainerType.Name = "lbContainerType";
            this.lbContainerType.Size = new System.Drawing.Size(34, 13);
            this.lbContainerType.TabIndex = 2;
            this.lbContainerType.Text = "Type:";
            // 
            // tbContainerFile
            // 
            this.tbContainerFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbContainerFile.Location = new System.Drawing.Point(53, 44);
            this.tbContainerFile.Name = "tbContainerFile";
            this.tbContainerFile.Size = new System.Drawing.Size(122, 20);
            this.tbContainerFile.TabIndex = 1;
            // 
            // lbContainerFile
            // 
            this.lbContainerFile.AutoSize = true;
            this.lbContainerFile.Location = new System.Drawing.Point(13, 47);
            this.lbContainerFile.Name = "lbContainerFile";
            this.lbContainerFile.Size = new System.Drawing.Size(26, 13);
            this.lbContainerFile.TabIndex = 0;
            this.lbContainerFile.Text = "File:";
            // 
            // panCustomImage
            // 
            this.panCustomImage.AllowDrop = true;
            this.panCustomImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panCustomImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panCustomImage.Controls.Add(this.btnCustomImageBrowseFile);
            this.panCustomImage.Controls.Add(this.cmbCustomImageFormat);
            this.panCustomImage.Controls.Add(this.lbCimg);
            this.panCustomImage.Controls.Add(this.tbCustomImageHeight);
            this.panCustomImage.Controls.Add(this.tbCustomImageWidth);
            this.panCustomImage.Controls.Add(this.tbCustomImageName);
            this.panCustomImage.Controls.Add(this.lbCustomImageFormat);
            this.panCustomImage.Controls.Add(this.lbCustomImageHeight);
            this.panCustomImage.Controls.Add(this.lbCustomImageWidth);
            this.panCustomImage.Controls.Add(this.lbCustomImageName);
            this.panCustomImage.Controls.Add(this.tbCustomImageFile);
            this.panCustomImage.Controls.Add(this.lbCustomImageFile);
            this.panCustomImage.Location = new System.Drawing.Point(8, 6);
            this.panCustomImage.Name = "panCustomImage";
            this.panCustomImage.Size = new System.Drawing.Size(224, 303);
            this.panCustomImage.TabIndex = 5;
            this.panCustomImage.Visible = false;
            this.panCustomImage.DragDrop += new System.Windows.Forms.DragEventHandler(this.ThemeMii_Main_DragDrop);
            this.panCustomImage.DragEnter += new System.Windows.Forms.DragEventHandler(this.ThemeMii_Main_DragEnter);
            // 
            // btnCustomImageBrowseFile
            // 
            this.btnCustomImageBrowseFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCustomImageBrowseFile.Location = new System.Drawing.Point(181, 44);
            this.btnCustomImageBrowseFile.Name = "btnCustomImageBrowseFile";
            this.btnCustomImageBrowseFile.Size = new System.Drawing.Size(21, 20);
            this.btnCustomImageBrowseFile.TabIndex = 10;
            this.btnCustomImageBrowseFile.Text = "..";
            this.btnCustomImageBrowseFile.UseVisualStyleBackColor = true;
            this.btnCustomImageBrowseFile.Click += new System.EventHandler(this.btnBrowseFile_Click);
            // 
            // cmbCustomImageFormat
            // 
            this.cmbCustomImageFormat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCustomImageFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCustomImageFormat.FormattingEnabled = true;
            this.cmbCustomImageFormat.Items.AddRange(new object[] {
            "RGB5A3",
            "RGBA8",
            "RGB565",
            "I4",
            "I8",
            "IA4",
            "IA8"});
            this.cmbCustomImageFormat.Location = new System.Drawing.Point(61, 172);
            this.cmbCustomImageFormat.Name = "cmbCustomImageFormat";
            this.cmbCustomImageFormat.Size = new System.Drawing.Size(141, 21);
            this.cmbCustomImageFormat.TabIndex = 5;
            // 
            // lbCimg
            // 
            this.lbCimg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbCimg.Location = new System.Drawing.Point(0, 16);
            this.lbCimg.Name = "lbCimg";
            this.lbCimg.Size = new System.Drawing.Size(224, 13);
            this.lbCimg.TabIndex = 4;
            this.lbCimg.Text = "[cimgX]";
            this.lbCimg.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tbCustomImageHeight
            // 
            this.tbCustomImageHeight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbCustomImageHeight.Location = new System.Drawing.Point(61, 140);
            this.tbCustomImageHeight.Name = "tbCustomImageHeight";
            this.tbCustomImageHeight.Size = new System.Drawing.Size(141, 20);
            this.tbCustomImageHeight.TabIndex = 1;
            this.tbCustomImageHeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.intTextBox_KeyPress);
            // 
            // tbCustomImageWidth
            // 
            this.tbCustomImageWidth.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbCustomImageWidth.Location = new System.Drawing.Point(61, 108);
            this.tbCustomImageWidth.Name = "tbCustomImageWidth";
            this.tbCustomImageWidth.Size = new System.Drawing.Size(141, 20);
            this.tbCustomImageWidth.TabIndex = 1;
            this.tbCustomImageWidth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.intTextBox_KeyPress);
            // 
            // tbCustomImageName
            // 
            this.tbCustomImageName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbCustomImageName.Location = new System.Drawing.Point(61, 75);
            this.tbCustomImageName.Name = "tbCustomImageName";
            this.tbCustomImageName.Size = new System.Drawing.Size(141, 20);
            this.tbCustomImageName.TabIndex = 1;
            // 
            // lbCustomImageFormat
            // 
            this.lbCustomImageFormat.AutoSize = true;
            this.lbCustomImageFormat.Location = new System.Drawing.Point(13, 175);
            this.lbCustomImageFormat.Name = "lbCustomImageFormat";
            this.lbCustomImageFormat.Size = new System.Drawing.Size(42, 13);
            this.lbCustomImageFormat.TabIndex = 0;
            this.lbCustomImageFormat.Text = "Format:";
            // 
            // lbCustomImageHeight
            // 
            this.lbCustomImageHeight.AutoSize = true;
            this.lbCustomImageHeight.Location = new System.Drawing.Point(13, 143);
            this.lbCustomImageHeight.Name = "lbCustomImageHeight";
            this.lbCustomImageHeight.Size = new System.Drawing.Size(41, 13);
            this.lbCustomImageHeight.TabIndex = 0;
            this.lbCustomImageHeight.Text = "Height:";
            // 
            // lbCustomImageWidth
            // 
            this.lbCustomImageWidth.AutoSize = true;
            this.lbCustomImageWidth.Location = new System.Drawing.Point(13, 111);
            this.lbCustomImageWidth.Name = "lbCustomImageWidth";
            this.lbCustomImageWidth.Size = new System.Drawing.Size(38, 13);
            this.lbCustomImageWidth.TabIndex = 0;
            this.lbCustomImageWidth.Text = "Width:";
            // 
            // lbCustomImageName
            // 
            this.lbCustomImageName.AutoSize = true;
            this.lbCustomImageName.Location = new System.Drawing.Point(13, 79);
            this.lbCustomImageName.Name = "lbCustomImageName";
            this.lbCustomImageName.Size = new System.Drawing.Size(38, 13);
            this.lbCustomImageName.TabIndex = 0;
            this.lbCustomImageName.Text = "Name:";
            // 
            // tbCustomImageFile
            // 
            this.tbCustomImageFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbCustomImageFile.Location = new System.Drawing.Point(61, 44);
            this.tbCustomImageFile.Name = "tbCustomImageFile";
            this.tbCustomImageFile.Size = new System.Drawing.Size(114, 20);
            this.tbCustomImageFile.TabIndex = 1;
            // 
            // lbCustomImageFile
            // 
            this.lbCustomImageFile.AutoSize = true;
            this.lbCustomImageFile.Location = new System.Drawing.Point(13, 47);
            this.lbCustomImageFile.Name = "lbCustomImageFile";
            this.lbCustomImageFile.Size = new System.Drawing.Size(26, 13);
            this.lbCustomImageFile.TabIndex = 0;
            this.lbCustomImageFile.Text = "File:";
            // 
            // panStaticImage
            // 
            this.panStaticImage.AllowDrop = true;
            this.panStaticImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panStaticImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panStaticImage.Controls.Add(this.btnStaticImageBrowseFile);
            this.panStaticImage.Controls.Add(this.btnStaticImageBrowse);
            this.panStaticImage.Controls.Add(this.cmbStaticImageFormat);
            this.panStaticImage.Controls.Add(this.lbSimg);
            this.panStaticImage.Controls.Add(this.tbStaticImageFilepath);
            this.panStaticImage.Controls.Add(this.tbStaticImageHeight);
            this.panStaticImage.Controls.Add(this.tbStaticImageWidth);
            this.panStaticImage.Controls.Add(this.tbStaticImageSource);
            this.panStaticImage.Controls.Add(this.lbStaticImageFilepath);
            this.panStaticImage.Controls.Add(this.lbStaticImageFormat);
            this.panStaticImage.Controls.Add(this.lbStaticImageHeight);
            this.panStaticImage.Controls.Add(this.lbStaticImageWidth);
            this.panStaticImage.Controls.Add(this.lbStaticImageSource);
            this.panStaticImage.Controls.Add(this.tbStaticImageFile);
            this.panStaticImage.Controls.Add(this.lbStaticImageFile);
            this.panStaticImage.Location = new System.Drawing.Point(8, 6);
            this.panStaticImage.Name = "panStaticImage";
            this.panStaticImage.Size = new System.Drawing.Size(224, 303);
            this.panStaticImage.TabIndex = 6;
            this.panStaticImage.Visible = false;
            this.panStaticImage.DragDrop += new System.Windows.Forms.DragEventHandler(this.ThemeMii_Main_DragDrop);
            this.panStaticImage.DragEnter += new System.Windows.Forms.DragEventHandler(this.ThemeMii_Main_DragEnter);
            // 
            // btnStaticImageBrowseFile
            // 
            this.btnStaticImageBrowseFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStaticImageBrowseFile.Location = new System.Drawing.Point(181, 44);
            this.btnStaticImageBrowseFile.Name = "btnStaticImageBrowseFile";
            this.btnStaticImageBrowseFile.Size = new System.Drawing.Size(21, 20);
            this.btnStaticImageBrowseFile.TabIndex = 10;
            this.btnStaticImageBrowseFile.Text = "..";
            this.btnStaticImageBrowseFile.UseVisualStyleBackColor = true;
            this.btnStaticImageBrowseFile.Click += new System.EventHandler(this.btnBrowseFile_Click);
            // 
            // btnStaticImageBrowse
            // 
            this.btnStaticImageBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStaticImageBrowse.Location = new System.Drawing.Point(174, 257);
            this.btnStaticImageBrowse.Name = "btnStaticImageBrowse";
            this.btnStaticImageBrowse.Size = new System.Drawing.Size(28, 20);
            this.btnStaticImageBrowse.TabIndex = 6;
            this.btnStaticImageBrowse.Text = "...";
            this.btnStaticImageBrowse.UseVisualStyleBackColor = true;
            this.btnStaticImageBrowse.Click += new System.EventHandler(this.btnStaticImageBrowse_Click);
            // 
            // cmbStaticImageFormat
            // 
            this.cmbStaticImageFormat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbStaticImageFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStaticImageFormat.FormattingEnabled = true;
            this.cmbStaticImageFormat.Items.AddRange(new object[] {
            "RGB5A3",
            "RGBA8",
            "RGB565",
            "I4",
            "I8",
            "IA4",
            "IA8"});
            this.cmbStaticImageFormat.Location = new System.Drawing.Point(61, 172);
            this.cmbStaticImageFormat.Name = "cmbStaticImageFormat";
            this.cmbStaticImageFormat.Size = new System.Drawing.Size(141, 21);
            this.cmbStaticImageFormat.TabIndex = 5;
            // 
            // lbSimg
            // 
            this.lbSimg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbSimg.Location = new System.Drawing.Point(0, 16);
            this.lbSimg.Name = "lbSimg";
            this.lbSimg.Size = new System.Drawing.Size(224, 13);
            this.lbSimg.TabIndex = 4;
            this.lbSimg.Text = "[simgX]";
            this.lbSimg.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tbStaticImageFilepath
            // 
            this.tbStaticImageFilepath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbStaticImageFilepath.Location = new System.Drawing.Point(16, 257);
            this.tbStaticImageFilepath.Name = "tbStaticImageFilepath";
            this.tbStaticImageFilepath.Size = new System.Drawing.Size(152, 20);
            this.tbStaticImageFilepath.TabIndex = 1;
            // 
            // tbStaticImageHeight
            // 
            this.tbStaticImageHeight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbStaticImageHeight.Location = new System.Drawing.Point(61, 140);
            this.tbStaticImageHeight.Name = "tbStaticImageHeight";
            this.tbStaticImageHeight.Size = new System.Drawing.Size(141, 20);
            this.tbStaticImageHeight.TabIndex = 1;
            this.tbStaticImageHeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.intTextBox_KeyPress);
            // 
            // tbStaticImageWidth
            // 
            this.tbStaticImageWidth.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbStaticImageWidth.Location = new System.Drawing.Point(61, 108);
            this.tbStaticImageWidth.Name = "tbStaticImageWidth";
            this.tbStaticImageWidth.Size = new System.Drawing.Size(141, 20);
            this.tbStaticImageWidth.TabIndex = 1;
            this.tbStaticImageWidth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.intTextBox_KeyPress);
            // 
            // tbStaticImageSource
            // 
            this.tbStaticImageSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbStaticImageSource.Location = new System.Drawing.Point(61, 75);
            this.tbStaticImageSource.Name = "tbStaticImageSource";
            this.tbStaticImageSource.Size = new System.Drawing.Size(141, 20);
            this.tbStaticImageSource.TabIndex = 1;
            // 
            // lbStaticImageFilepath
            // 
            this.lbStaticImageFilepath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbStaticImageFilepath.AutoSize = true;
            this.lbStaticImageFilepath.Location = new System.Drawing.Point(13, 241);
            this.lbStaticImageFilepath.Name = "lbStaticImageFilepath";
            this.lbStaticImageFilepath.Size = new System.Drawing.Size(47, 13);
            this.lbStaticImageFilepath.TabIndex = 0;
            this.lbStaticImageFilepath.Text = "Filepath:";
            // 
            // lbStaticImageFormat
            // 
            this.lbStaticImageFormat.AutoSize = true;
            this.lbStaticImageFormat.Location = new System.Drawing.Point(13, 175);
            this.lbStaticImageFormat.Name = "lbStaticImageFormat";
            this.lbStaticImageFormat.Size = new System.Drawing.Size(42, 13);
            this.lbStaticImageFormat.TabIndex = 0;
            this.lbStaticImageFormat.Text = "Format:";
            // 
            // lbStaticImageHeight
            // 
            this.lbStaticImageHeight.AutoSize = true;
            this.lbStaticImageHeight.Location = new System.Drawing.Point(13, 143);
            this.lbStaticImageHeight.Name = "lbStaticImageHeight";
            this.lbStaticImageHeight.Size = new System.Drawing.Size(41, 13);
            this.lbStaticImageHeight.TabIndex = 0;
            this.lbStaticImageHeight.Text = "Height:";
            // 
            // lbStaticImageWidth
            // 
            this.lbStaticImageWidth.AutoSize = true;
            this.lbStaticImageWidth.Location = new System.Drawing.Point(13, 111);
            this.lbStaticImageWidth.Name = "lbStaticImageWidth";
            this.lbStaticImageWidth.Size = new System.Drawing.Size(38, 13);
            this.lbStaticImageWidth.TabIndex = 0;
            this.lbStaticImageWidth.Text = "Width:";
            // 
            // lbStaticImageSource
            // 
            this.lbStaticImageSource.AutoSize = true;
            this.lbStaticImageSource.Location = new System.Drawing.Point(13, 79);
            this.lbStaticImageSource.Name = "lbStaticImageSource";
            this.lbStaticImageSource.Size = new System.Drawing.Size(44, 13);
            this.lbStaticImageSource.TabIndex = 0;
            this.lbStaticImageSource.Text = "Source:";
            // 
            // tbStaticImageFile
            // 
            this.tbStaticImageFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbStaticImageFile.Location = new System.Drawing.Point(61, 44);
            this.tbStaticImageFile.Name = "tbStaticImageFile";
            this.tbStaticImageFile.Size = new System.Drawing.Size(114, 20);
            this.tbStaticImageFile.TabIndex = 1;
            // 
            // lbStaticImageFile
            // 
            this.lbStaticImageFile.AutoSize = true;
            this.lbStaticImageFile.Location = new System.Drawing.Point(13, 47);
            this.lbStaticImageFile.Name = "lbStaticImageFile";
            this.lbStaticImageFile.Size = new System.Drawing.Size(26, 13);
            this.lbStaticImageFile.TabIndex = 0;
            this.lbStaticImageFile.Text = "File:";
            // 
            // btnDown
            // 
            this.btnDown.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnDown.Location = new System.Drawing.Point(105, 289);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(30, 20);
            this.btnDown.TabIndex = 2;
            this.btnDown.Text = "↓";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.SwapEntryDown);
            // 
            // btnUp
            // 
            this.btnUp.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnUp.Location = new System.Drawing.Point(73, 289);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(30, 20);
            this.btnUp.TabIndex = 2;
            this.btnUp.Text = "↑";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.SwapEntryUp);
            // 
            // msMain
            // 
            this.msMain.AllowDrop = true;
            this.msMain.BackColor = System.Drawing.SystemColors.Control;
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msFile,
            this.msList,
            this.msOptions,
            this.msTools,
            this.msQuestion});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Size = new System.Drawing.Size(382, 24);
            this.msMain.TabIndex = 3;
            this.msMain.Text = "menuStrip1";
            this.msMain.DragDrop += new System.Windows.Forms.DragEventHandler(this.ThemeMii_Main_DragDrop);
            this.msMain.DragEnter += new System.Windows.Forms.DragEventHandler(this.ThemeMii_Main_DragEnter);
            // 
            // msFile
            // 
            this.msFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msNew,
            this.msOpen,
            this.msSave,
            this.msFileSep,
            this.msExit});
            this.msFile.Name = "msFile";
            this.msFile.Size = new System.Drawing.Size(37, 20);
            this.msFile.Text = "File";
            // 
            // msNew
            // 
            this.msNew.Name = "msNew";
            this.msNew.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.msNew.Size = new System.Drawing.Size(146, 22);
            this.msNew.Text = "New";
            this.msNew.Click += new System.EventHandler(this.msNew_Click);
            // 
            // msOpen
            // 
            this.msOpen.Name = "msOpen";
            this.msOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.msOpen.Size = new System.Drawing.Size(146, 22);
            this.msOpen.Text = "Open";
            this.msOpen.Click += new System.EventHandler(this.msOpen_Click);
            // 
            // msSave
            // 
            this.msSave.Name = "msSave";
            this.msSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.msSave.Size = new System.Drawing.Size(146, 22);
            this.msSave.Text = "Save";
            this.msSave.Click += new System.EventHandler(this.msSave_Click);
            // 
            // msFileSep
            // 
            this.msFileSep.Name = "msFileSep";
            this.msFileSep.Size = new System.Drawing.Size(143, 6);
            // 
            // msExit
            // 
            this.msExit.Name = "msExit";
            this.msExit.Size = new System.Drawing.Size(146, 22);
            this.msExit.Text = "Exit";
            this.msExit.Click += new System.EventHandler(this.msExit_Click);
            // 
            // msList
            // 
            this.msList.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msAdd,
            this.msRemove,
            this.msMoveUp,
            this.msMoveDown,
            this.msMoveStart,
            this.msMoveEnd,
            this.toolStripSeparator1,
            this.msRemoveMissingStatics});
            this.msList.Name = "msList";
            this.msList.Size = new System.Drawing.Size(37, 20);
            this.msList.Text = "List";
            // 
            // msAdd
            // 
            this.msAdd.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msAddContainer,
            this.msAddStaticImage,
            this.msAddStaticData,
            this.msAddCustomImage,
            this.msAddCustomData});
            this.msAdd.Name = "msAdd";
            this.msAdd.Size = new System.Drawing.Size(203, 22);
            this.msAdd.Text = "Add";
            // 
            // msAddContainer
            // 
            this.msAddContainer.Name = "msAddContainer";
            this.msAddContainer.Size = new System.Drawing.Size(152, 22);
            this.msAddContainer.Text = "Container";
            this.msAddContainer.Click += new System.EventHandler(this.msAddContainer_Click);
            // 
            // msAddStaticImage
            // 
            this.msAddStaticImage.Name = "msAddStaticImage";
            this.msAddStaticImage.Size = new System.Drawing.Size(152, 22);
            this.msAddStaticImage.Text = "Static Image";
            this.msAddStaticImage.Click += new System.EventHandler(this.msAddStaticImage_Click);
            // 
            // msAddStaticData
            // 
            this.msAddStaticData.Name = "msAddStaticData";
            this.msAddStaticData.Size = new System.Drawing.Size(152, 22);
            this.msAddStaticData.Text = "Static Data";
            this.msAddStaticData.Click += new System.EventHandler(this.msAddStaticData_Click);
            // 
            // msAddCustomImage
            // 
            this.msAddCustomImage.Name = "msAddCustomImage";
            this.msAddCustomImage.Size = new System.Drawing.Size(152, 22);
            this.msAddCustomImage.Text = "Custom Image";
            this.msAddCustomImage.Click += new System.EventHandler(this.msAddCustomImage_Click);
            // 
            // msAddCustomData
            // 
            this.msAddCustomData.Name = "msAddCustomData";
            this.msAddCustomData.Size = new System.Drawing.Size(152, 22);
            this.msAddCustomData.Text = "Custom Data";
            this.msAddCustomData.Click += new System.EventHandler(this.msAddCustomData_Click);
            // 
            // msRemove
            // 
            this.msRemove.Name = "msRemove";
            this.msRemove.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.msRemove.Size = new System.Drawing.Size(203, 22);
            this.msRemove.Text = "Remove";
            this.msRemove.Click += new System.EventHandler(this.btnMinus_Click);
            // 
            // msMoveUp
            // 
            this.msMoveUp.Name = "msMoveUp";
            this.msMoveUp.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Up)));
            this.msMoveUp.Size = new System.Drawing.Size(203, 22);
            this.msMoveUp.Text = "Move Up";
            this.msMoveUp.Click += new System.EventHandler(this.SwapEntryUp);
            // 
            // msMoveDown
            // 
            this.msMoveDown.Name = "msMoveDown";
            this.msMoveDown.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Down)));
            this.msMoveDown.Size = new System.Drawing.Size(203, 22);
            this.msMoveDown.Text = "Move Down";
            this.msMoveDown.Click += new System.EventHandler(this.SwapEntryDown);
            // 
            // msMoveStart
            // 
            this.msMoveStart.Name = "msMoveStart";
            this.msMoveStart.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Left)));
            this.msMoveStart.Size = new System.Drawing.Size(203, 22);
            this.msMoveStart.Text = "Move to Start";
            this.msMoveStart.Click += new System.EventHandler(this.msMoveStart_Click);
            // 
            // msMoveEnd
            // 
            this.msMoveEnd.Name = "msMoveEnd";
            this.msMoveEnd.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Right)));
            this.msMoveEnd.Size = new System.Drawing.Size(203, 22);
            this.msMoveEnd.Text = "Move to End";
            this.msMoveEnd.Click += new System.EventHandler(this.msMoveEnd_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(200, 6);
            // 
            // msRemoveMissingStatics
            // 
            this.msRemoveMissingStatics.Name = "msRemoveMissingStatics";
            this.msRemoveMissingStatics.Size = new System.Drawing.Size(203, 22);
            this.msRemoveMissingStatics.Text = "Remove Missing Statics";
            this.msRemoveMissingStatics.Click += new System.EventHandler(this.msRemoveMissingStatics_Click);
            // 
            // msOptions
            // 
            this.msOptions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msSourceManage,
            this.msContainerManage,
            this.msIgnoreMissingEntries,
            this.toolStripSeparator6,
            this.msImageSizeFromTpl,
            this.msImageSizeFromPng,
            this.toolStripSeparator4,
            this.msLz77Containers,
            this.msSaveNandPath,
            this.msKeepExtractedApp,
            this.msSavePrompt,
            this.toolStripSeparator2,
            this.msStandardSysMenu,
            this.msChangeNandPath});
            this.msOptions.Name = "msOptions";
            this.msOptions.Size = new System.Drawing.Size(61, 20);
            this.msOptions.Text = "Options";
            // 
            // msSourceManage
            // 
            this.msSourceManage.CheckOnClick = true;
            this.msSourceManage.Name = "msSourceManage";
            this.msSourceManage.Size = new System.Drawing.Size(216, 22);
            this.msSourceManage.Text = "Auto-Source-Manage";
            this.msSourceManage.Click += new System.EventHandler(this.msAutoManage_Click);
            // 
            // msContainerManage
            // 
            this.msContainerManage.CheckOnClick = true;
            this.msContainerManage.Name = "msContainerManage";
            this.msContainerManage.Size = new System.Drawing.Size(216, 22);
            this.msContainerManage.Text = "Auto-Container-Manage";
            this.msContainerManage.Click += new System.EventHandler(this.msContainerManage_Click);
            // 
            // msIgnoreMissingEntries
            // 
            this.msIgnoreMissingEntries.CheckOnClick = true;
            this.msIgnoreMissingEntries.Name = "msIgnoreMissingEntries";
            this.msIgnoreMissingEntries.Size = new System.Drawing.Size(216, 22);
            this.msIgnoreMissingEntries.Text = "Ignore Missing Entries";
            this.msIgnoreMissingEntries.Click += new System.EventHandler(this.msIgnoreMissingEntries_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(213, 6);
            // 
            // msImageSizeFromTpl
            // 
            this.msImageSizeFromTpl.CheckOnClick = true;
            this.msImageSizeFromTpl.Name = "msImageSizeFromTpl";
            this.msImageSizeFromTpl.Size = new System.Drawing.Size(216, 22);
            this.msImageSizeFromTpl.Text = "Image Size from TPL";
            this.msImageSizeFromTpl.Click += new System.EventHandler(this.msImageSizeFromTpl_Click);
            // 
            // msImageSizeFromPng
            // 
            this.msImageSizeFromPng.CheckOnClick = true;
            this.msImageSizeFromPng.Name = "msImageSizeFromPng";
            this.msImageSizeFromPng.Size = new System.Drawing.Size(216, 22);
            this.msImageSizeFromPng.Text = "Image Size from PNG";
            this.msImageSizeFromPng.Click += new System.EventHandler(this.msImageSizeFromPng_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(213, 6);
            // 
            // msLz77Containers
            // 
            this.msLz77Containers.CheckOnClick = true;
            this.msLz77Containers.Name = "msLz77Containers";
            this.msLz77Containers.Size = new System.Drawing.Size(216, 22);
            this.msLz77Containers.Text = "Lz77 Compress Containers";
            this.msLz77Containers.Click += new System.EventHandler(this.msLz77Containers_Click);
            // 
            // msSaveNandPath
            // 
            this.msSaveNandPath.CheckOnClick = true;
            this.msSaveNandPath.Name = "msSaveNandPath";
            this.msSaveNandPath.Size = new System.Drawing.Size(216, 22);
            this.msSaveNandPath.Text = "Save Nand Backup Path";
            this.msSaveNandPath.Click += new System.EventHandler(this.msSaveNandPath_Click);
            // 
            // msKeepExtractedApp
            // 
            this.msKeepExtractedApp.CheckOnClick = true;
            this.msKeepExtractedApp.Name = "msKeepExtractedApp";
            this.msKeepExtractedApp.Size = new System.Drawing.Size(216, 22);
            this.msKeepExtractedApp.Text = "Keep Extracted Base App";
            this.msKeepExtractedApp.Click += new System.EventHandler(this.msKeepExtractedApp_Click);
            // 
            // msSavePrompt
            // 
            this.msSavePrompt.CheckOnClick = true;
            this.msSavePrompt.Name = "msSavePrompt";
            this.msSavePrompt.Size = new System.Drawing.Size(216, 22);
            this.msSavePrompt.Text = "Save Prompt when Exiting";
            this.msSavePrompt.Click += new System.EventHandler(this.msSavePrompt_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(213, 6);
            // 
            // msStandardSysMenu
            // 
            this.msStandardSysMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ms32,
            this.ms40,
            this.ms41,
            this.ms42});
            this.msStandardSysMenu.Name = "msStandardSysMenu";
            this.msStandardSysMenu.Size = new System.Drawing.Size(216, 22);
            this.msStandardSysMenu.Text = "Standard System Menu";
            // 
            // ms32
            // 
            this.ms32.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ms32J,
            this.ms32U,
            this.ms32E});
            this.ms32.Name = "ms32";
            this.ms32.Size = new System.Drawing.Size(89, 22);
            this.ms32.Text = "3.2";
            // 
            // ms32J
            // 
            this.ms32J.CheckOnClick = true;
            this.ms32J.Name = "ms32J";
            this.ms32J.Size = new System.Drawing.Size(111, 22);
            this.ms32J.Text = "Japan";
            this.ms32J.Click += new System.EventHandler(this.StandardSysMenu_Click);
            // 
            // ms32U
            // 
            this.ms32U.CheckOnClick = true;
            this.ms32U.Name = "ms32U";
            this.ms32U.Size = new System.Drawing.Size(111, 22);
            this.ms32U.Text = "USA";
            this.ms32U.Click += new System.EventHandler(this.StandardSysMenu_Click);
            // 
            // ms32E
            // 
            this.ms32E.CheckOnClick = true;
            this.ms32E.Name = "ms32E";
            this.ms32E.Size = new System.Drawing.Size(111, 22);
            this.ms32E.Text = "Europe";
            this.ms32E.Click += new System.EventHandler(this.StandardSysMenu_Click);
            // 
            // ms40
            // 
            this.ms40.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ms40J,
            this.ms40U,
            this.ms40E});
            this.ms40.Name = "ms40";
            this.ms40.Size = new System.Drawing.Size(89, 22);
            this.ms40.Text = "4.0";
            // 
            // ms40J
            // 
            this.ms40J.CheckOnClick = true;
            this.ms40J.Name = "ms40J";
            this.ms40J.Size = new System.Drawing.Size(111, 22);
            this.ms40J.Text = "Japan";
            this.ms40J.Click += new System.EventHandler(this.StandardSysMenu_Click);
            // 
            // ms40U
            // 
            this.ms40U.CheckOnClick = true;
            this.ms40U.Name = "ms40U";
            this.ms40U.Size = new System.Drawing.Size(111, 22);
            this.ms40U.Text = "USA";
            this.ms40U.Click += new System.EventHandler(this.StandardSysMenu_Click);
            // 
            // ms40E
            // 
            this.ms40E.CheckOnClick = true;
            this.ms40E.Name = "ms40E";
            this.ms40E.Size = new System.Drawing.Size(111, 22);
            this.ms40E.Text = "Europe";
            this.ms40E.Click += new System.EventHandler(this.StandardSysMenu_Click);
            // 
            // ms41
            // 
            this.ms41.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ms41J,
            this.ms41U,
            this.ms41E});
            this.ms41.Name = "ms41";
            this.ms41.Size = new System.Drawing.Size(89, 22);
            this.ms41.Text = "4.1";
            // 
            // ms41J
            // 
            this.ms41J.CheckOnClick = true;
            this.ms41J.Name = "ms41J";
            this.ms41J.Size = new System.Drawing.Size(111, 22);
            this.ms41J.Text = "Japan";
            this.ms41J.Click += new System.EventHandler(this.StandardSysMenu_Click);
            // 
            // ms41U
            // 
            this.ms41U.CheckOnClick = true;
            this.ms41U.Name = "ms41U";
            this.ms41U.Size = new System.Drawing.Size(111, 22);
            this.ms41U.Text = "USA";
            this.ms41U.Click += new System.EventHandler(this.StandardSysMenu_Click);
            // 
            // ms41E
            // 
            this.ms41E.CheckOnClick = true;
            this.ms41E.Name = "ms41E";
            this.ms41E.Size = new System.Drawing.Size(111, 22);
            this.ms41E.Text = "Europe";
            this.ms41E.Click += new System.EventHandler(this.StandardSysMenu_Click);
            // 
            // ms42
            // 
            this.ms42.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ms42J,
            this.ms42U,
            this.ms42E});
            this.ms42.Name = "ms42";
            this.ms42.Size = new System.Drawing.Size(89, 22);
            this.ms42.Text = "4.2";
            // 
            // ms42J
            // 
            this.ms42J.CheckOnClick = true;
            this.ms42J.Name = "ms42J";
            this.ms42J.Size = new System.Drawing.Size(111, 22);
            this.ms42J.Text = "Japan";
            this.ms42J.Click += new System.EventHandler(this.StandardSysMenu_Click);
            // 
            // ms42U
            // 
            this.ms42U.CheckOnClick = true;
            this.ms42U.Name = "ms42U";
            this.ms42U.Size = new System.Drawing.Size(111, 22);
            this.ms42U.Text = "USA";
            this.ms42U.Click += new System.EventHandler(this.StandardSysMenu_Click);
            // 
            // ms42E
            // 
            this.ms42E.CheckOnClick = true;
            this.ms42E.Name = "ms42E";
            this.ms42E.Size = new System.Drawing.Size(111, 22);
            this.ms42E.Text = "Europe";
            this.ms42E.Click += new System.EventHandler(this.StandardSysMenu_Click);
            // 
            // msChangeNandPath
            // 
            this.msChangeNandPath.Name = "msChangeNandPath";
            this.msChangeNandPath.Size = new System.Drawing.Size(216, 22);
            this.msChangeNandPath.Text = "Change Nand Backup Path";
            this.msChangeNandPath.Click += new System.EventHandler(this.msChangeNandPath_Click);
            // 
            // msTools
            // 
            this.msTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msCsmToMym,
            this.msBrowseBaseApp,
            this.msInstallToNandBackup,
            this.toolStripSeparator3,
            this.msDownloadBaseApp});
            this.msTools.Name = "msTools";
            this.msTools.Size = new System.Drawing.Size(48, 20);
            this.msTools.Text = "Tools";
            // 
            // msCsmToMym
            // 
            this.msCsmToMym.Name = "msCsmToMym";
            this.msCsmToMym.Size = new System.Drawing.Size(236, 22);
            this.msCsmToMym.Text = "csm to mym";
            this.msCsmToMym.Click += new System.EventHandler(this.msCsmToMym_Click);
            // 
            // msBrowseBaseApp
            // 
            this.msBrowseBaseApp.Name = "msBrowseBaseApp";
            this.msBrowseBaseApp.Size = new System.Drawing.Size(236, 22);
            this.msBrowseBaseApp.Text = "Browse Base App";
            this.msBrowseBaseApp.Click += new System.EventHandler(this.btnBrowseFile_Click);
            // 
            // msInstallToNandBackup
            // 
            this.msInstallToNandBackup.Name = "msInstallToNandBackup";
            this.msInstallToNandBackup.Size = new System.Drawing.Size(236, 22);
            this.msInstallToNandBackup.Text = "Install Theme To Nand Backup";
            this.msInstallToNandBackup.Click += new System.EventHandler(this.msInstallToNandBackup_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(233, 6);
            // 
            // msDownloadBaseApp
            // 
            this.msDownloadBaseApp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msDownload32,
            this.msDownload40,
            this.msDownload41,
            this.msDownload42});
            this.msDownloadBaseApp.Name = "msDownloadBaseApp";
            this.msDownloadBaseApp.Size = new System.Drawing.Size(236, 22);
            this.msDownloadBaseApp.Text = "Download Base App";
            // 
            // msDownload32
            // 
            this.msDownload32.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msDownload32J,
            this.msDownload32U,
            this.msDownload32E});
            this.msDownload32.Name = "msDownload32";
            this.msDownload32.Size = new System.Drawing.Size(89, 22);
            this.msDownload32.Text = "3.2";
            // 
            // msDownload32J
            // 
            this.msDownload32J.Name = "msDownload32J";
            this.msDownload32J.Size = new System.Drawing.Size(111, 22);
            this.msDownload32J.Text = "Japan";
            this.msDownload32J.Click += new System.EventHandler(this.DownloadBaseApp_Click);
            // 
            // msDownload32U
            // 
            this.msDownload32U.Name = "msDownload32U";
            this.msDownload32U.Size = new System.Drawing.Size(111, 22);
            this.msDownload32U.Text = "USA";
            this.msDownload32U.Click += new System.EventHandler(this.DownloadBaseApp_Click);
            // 
            // msDownload32E
            // 
            this.msDownload32E.Name = "msDownload32E";
            this.msDownload32E.Size = new System.Drawing.Size(111, 22);
            this.msDownload32E.Text = "Europe";
            this.msDownload32E.Click += new System.EventHandler(this.DownloadBaseApp_Click);
            // 
            // msDownload40
            // 
            this.msDownload40.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msDownload40J,
            this.msDownload40U,
            this.msDownload40E});
            this.msDownload40.Name = "msDownload40";
            this.msDownload40.Size = new System.Drawing.Size(89, 22);
            this.msDownload40.Text = "4.0";
            // 
            // msDownload40J
            // 
            this.msDownload40J.Name = "msDownload40J";
            this.msDownload40J.Size = new System.Drawing.Size(111, 22);
            this.msDownload40J.Text = "Japan";
            this.msDownload40J.Click += new System.EventHandler(this.DownloadBaseApp_Click);
            // 
            // msDownload40U
            // 
            this.msDownload40U.Name = "msDownload40U";
            this.msDownload40U.Size = new System.Drawing.Size(111, 22);
            this.msDownload40U.Text = "USA";
            this.msDownload40U.Click += new System.EventHandler(this.DownloadBaseApp_Click);
            // 
            // msDownload40E
            // 
            this.msDownload40E.Name = "msDownload40E";
            this.msDownload40E.Size = new System.Drawing.Size(111, 22);
            this.msDownload40E.Text = "Europe";
            this.msDownload40E.Click += new System.EventHandler(this.DownloadBaseApp_Click);
            // 
            // msDownload41
            // 
            this.msDownload41.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msDownload41J,
            this.msDownload41U,
            this.msDownload41E});
            this.msDownload41.Name = "msDownload41";
            this.msDownload41.Size = new System.Drawing.Size(89, 22);
            this.msDownload41.Text = "4.1";
            // 
            // msDownload41J
            // 
            this.msDownload41J.Name = "msDownload41J";
            this.msDownload41J.Size = new System.Drawing.Size(111, 22);
            this.msDownload41J.Text = "Japan";
            this.msDownload41J.Click += new System.EventHandler(this.DownloadBaseApp_Click);
            // 
            // msDownload41U
            // 
            this.msDownload41U.Name = "msDownload41U";
            this.msDownload41U.Size = new System.Drawing.Size(111, 22);
            this.msDownload41U.Text = "USA";
            this.msDownload41U.Click += new System.EventHandler(this.DownloadBaseApp_Click);
            // 
            // msDownload41E
            // 
            this.msDownload41E.Name = "msDownload41E";
            this.msDownload41E.Size = new System.Drawing.Size(111, 22);
            this.msDownload41E.Text = "Europe";
            this.msDownload41E.Click += new System.EventHandler(this.DownloadBaseApp_Click);
            // 
            // msDownload42
            // 
            this.msDownload42.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msDownload42J,
            this.msDownload42U,
            this.msDownload42E});
            this.msDownload42.Name = "msDownload42";
            this.msDownload42.Size = new System.Drawing.Size(89, 22);
            this.msDownload42.Text = "4.2";
            // 
            // msDownload42J
            // 
            this.msDownload42J.Name = "msDownload42J";
            this.msDownload42J.Size = new System.Drawing.Size(111, 22);
            this.msDownload42J.Text = "Japan";
            this.msDownload42J.Click += new System.EventHandler(this.DownloadBaseApp_Click);
            // 
            // msDownload42U
            // 
            this.msDownload42U.Name = "msDownload42U";
            this.msDownload42U.Size = new System.Drawing.Size(111, 22);
            this.msDownload42U.Text = "USA";
            this.msDownload42U.Click += new System.EventHandler(this.DownloadBaseApp_Click);
            // 
            // msDownload42E
            // 
            this.msDownload42E.Name = "msDownload42E";
            this.msDownload42E.Size = new System.Drawing.Size(111, 22);
            this.msDownload42E.Text = "Europe";
            this.msDownload42E.Click += new System.EventHandler(this.DownloadBaseApp_Click);
            // 
            // msQuestion
            // 
            this.msQuestion.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msHelp,
            this.msHealthTutorial,
            this.toolStripSeparator5,
            this.msAbout});
            this.msQuestion.Name = "msQuestion";
            this.msQuestion.Size = new System.Drawing.Size(24, 20);
            this.msQuestion.Text = "?";
            // 
            // msHelp
            // 
            this.msHelp.Name = "msHelp";
            this.msHelp.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.msHelp.Size = new System.Drawing.Size(191, 22);
            this.msHelp.Text = "Help";
            this.msHelp.Click += new System.EventHandler(this.msHelp_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(188, 6);
            // 
            // msAbout
            // 
            this.msAbout.Name = "msAbout";
            this.msAbout.Size = new System.Drawing.Size(191, 22);
            this.msAbout.Text = "About";
            this.msAbout.Click += new System.EventHandler(this.msAbout_Click);
            // 
            // btnMinus
            // 
            this.btnMinus.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnMinus.Location = new System.Drawing.Point(41, 289);
            this.btnMinus.Name = "btnMinus";
            this.btnMinus.Size = new System.Drawing.Size(30, 20);
            this.btnMinus.TabIndex = 2;
            this.btnMinus.Text = "-";
            this.btnMinus.UseVisualStyleBackColor = true;
            this.btnMinus.Click += new System.EventHandler(this.btnMinus_Click);
            // 
            // btnPlus
            // 
            this.btnPlus.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnPlus.Location = new System.Drawing.Point(9, 289);
            this.btnPlus.Name = "btnPlus";
            this.btnPlus.Size = new System.Drawing.Size(30, 20);
            this.btnPlus.TabIndex = 2;
            this.btnPlus.Text = "+";
            this.btnPlus.UseVisualStyleBackColor = true;
            this.btnPlus.Click += new System.EventHandler(this.btnPlus_Click);
            // 
            // panCustomData
            // 
            this.panCustomData.AllowDrop = true;
            this.panCustomData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panCustomData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panCustomData.Controls.Add(this.btnCustomDataBrowseFile);
            this.panCustomData.Controls.Add(this.lbCdta);
            this.panCustomData.Controls.Add(this.tbCustomDataName);
            this.panCustomData.Controls.Add(this.lbCustomDataName);
            this.panCustomData.Controls.Add(this.tbCustomDataFile);
            this.panCustomData.Controls.Add(this.lbCustomDataFile);
            this.panCustomData.Location = new System.Drawing.Point(8, 6);
            this.panCustomData.Name = "panCustomData";
            this.panCustomData.Size = new System.Drawing.Size(224, 303);
            this.panCustomData.TabIndex = 7;
            this.panCustomData.Visible = false;
            this.panCustomData.DragDrop += new System.Windows.Forms.DragEventHandler(this.ThemeMii_Main_DragDrop);
            this.panCustomData.DragEnter += new System.Windows.Forms.DragEventHandler(this.ThemeMii_Main_DragEnter);
            // 
            // btnCustomDataBrowseFile
            // 
            this.btnCustomDataBrowseFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCustomDataBrowseFile.Location = new System.Drawing.Point(181, 44);
            this.btnCustomDataBrowseFile.Name = "btnCustomDataBrowseFile";
            this.btnCustomDataBrowseFile.Size = new System.Drawing.Size(21, 20);
            this.btnCustomDataBrowseFile.TabIndex = 10;
            this.btnCustomDataBrowseFile.Text = "..";
            this.btnCustomDataBrowseFile.UseVisualStyleBackColor = true;
            this.btnCustomDataBrowseFile.Click += new System.EventHandler(this.btnBrowseFile_Click);
            // 
            // lbCdta
            // 
            this.lbCdta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbCdta.Location = new System.Drawing.Point(0, 16);
            this.lbCdta.Name = "lbCdta";
            this.lbCdta.Size = new System.Drawing.Size(224, 13);
            this.lbCdta.TabIndex = 4;
            this.lbCdta.Text = "[cdtaX]";
            this.lbCdta.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tbCustomDataName
            // 
            this.tbCustomDataName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbCustomDataName.Location = new System.Drawing.Point(61, 75);
            this.tbCustomDataName.Name = "tbCustomDataName";
            this.tbCustomDataName.Size = new System.Drawing.Size(141, 20);
            this.tbCustomDataName.TabIndex = 1;
            // 
            // lbCustomDataName
            // 
            this.lbCustomDataName.AutoSize = true;
            this.lbCustomDataName.Location = new System.Drawing.Point(13, 79);
            this.lbCustomDataName.Name = "lbCustomDataName";
            this.lbCustomDataName.Size = new System.Drawing.Size(38, 13);
            this.lbCustomDataName.TabIndex = 0;
            this.lbCustomDataName.Text = "Name:";
            // 
            // tbCustomDataFile
            // 
            this.tbCustomDataFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbCustomDataFile.Location = new System.Drawing.Point(61, 44);
            this.tbCustomDataFile.Name = "tbCustomDataFile";
            this.tbCustomDataFile.Size = new System.Drawing.Size(114, 20);
            this.tbCustomDataFile.TabIndex = 1;
            // 
            // lbCustomDataFile
            // 
            this.lbCustomDataFile.AutoSize = true;
            this.lbCustomDataFile.Location = new System.Drawing.Point(13, 47);
            this.lbCustomDataFile.Name = "lbCustomDataFile";
            this.lbCustomDataFile.Size = new System.Drawing.Size(26, 13);
            this.lbCustomDataFile.TabIndex = 0;
            this.lbCustomDataFile.Text = "File:";
            // 
            // panStaticData
            // 
            this.panStaticData.AllowDrop = true;
            this.panStaticData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panStaticData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panStaticData.Controls.Add(this.btnStaticDataBrowseFile);
            this.panStaticData.Controls.Add(this.btnStaticDataBrowse);
            this.panStaticData.Controls.Add(this.tbStaticDataFilepath);
            this.panStaticData.Controls.Add(this.lbStaticDataFilepath);
            this.panStaticData.Controls.Add(this.lbSdta);
            this.panStaticData.Controls.Add(this.tbStaticDataSource);
            this.panStaticData.Controls.Add(this.lbStaticDataSource);
            this.panStaticData.Controls.Add(this.tbStaticDataFile);
            this.panStaticData.Controls.Add(this.lbStaticDataFile);
            this.panStaticData.Location = new System.Drawing.Point(8, 6);
            this.panStaticData.Name = "panStaticData";
            this.panStaticData.Size = new System.Drawing.Size(224, 303);
            this.panStaticData.TabIndex = 8;
            this.panStaticData.Visible = false;
            this.panStaticData.DragDrop += new System.Windows.Forms.DragEventHandler(this.ThemeMii_Main_DragDrop);
            this.panStaticData.DragEnter += new System.Windows.Forms.DragEventHandler(this.ThemeMii_Main_DragEnter);
            // 
            // btnStaticDataBrowseFile
            // 
            this.btnStaticDataBrowseFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStaticDataBrowseFile.Location = new System.Drawing.Point(181, 44);
            this.btnStaticDataBrowseFile.Name = "btnStaticDataBrowseFile";
            this.btnStaticDataBrowseFile.Size = new System.Drawing.Size(21, 20);
            this.btnStaticDataBrowseFile.TabIndex = 9;
            this.btnStaticDataBrowseFile.Text = "..";
            this.btnStaticDataBrowseFile.UseVisualStyleBackColor = true;
            this.btnStaticDataBrowseFile.Click += new System.EventHandler(this.btnBrowseFile_Click);
            // 
            // btnStaticDataBrowse
            // 
            this.btnStaticDataBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStaticDataBrowse.Location = new System.Drawing.Point(174, 257);
            this.btnStaticDataBrowse.Name = "btnStaticDataBrowse";
            this.btnStaticDataBrowse.Size = new System.Drawing.Size(28, 20);
            this.btnStaticDataBrowse.TabIndex = 9;
            this.btnStaticDataBrowse.Text = "...";
            this.btnStaticDataBrowse.UseVisualStyleBackColor = true;
            this.btnStaticDataBrowse.Click += new System.EventHandler(this.btnStaticDataBrowse_Click);
            // 
            // tbStaticDataFilepath
            // 
            this.tbStaticDataFilepath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbStaticDataFilepath.Location = new System.Drawing.Point(16, 257);
            this.tbStaticDataFilepath.Name = "tbStaticDataFilepath";
            this.tbStaticDataFilepath.Size = new System.Drawing.Size(152, 20);
            this.tbStaticDataFilepath.TabIndex = 8;
            // 
            // lbStaticDataFilepath
            // 
            this.lbStaticDataFilepath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbStaticDataFilepath.AutoSize = true;
            this.lbStaticDataFilepath.Location = new System.Drawing.Point(13, 241);
            this.lbStaticDataFilepath.Name = "lbStaticDataFilepath";
            this.lbStaticDataFilepath.Size = new System.Drawing.Size(47, 13);
            this.lbStaticDataFilepath.TabIndex = 7;
            this.lbStaticDataFilepath.Text = "Filepath:";
            // 
            // lbSdta
            // 
            this.lbSdta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbSdta.Location = new System.Drawing.Point(0, 16);
            this.lbSdta.Name = "lbSdta";
            this.lbSdta.Size = new System.Drawing.Size(224, 13);
            this.lbSdta.TabIndex = 4;
            this.lbSdta.Text = "[sdtaX]";
            this.lbSdta.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tbStaticDataSource
            // 
            this.tbStaticDataSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbStaticDataSource.Location = new System.Drawing.Point(61, 75);
            this.tbStaticDataSource.Name = "tbStaticDataSource";
            this.tbStaticDataSource.Size = new System.Drawing.Size(141, 20);
            this.tbStaticDataSource.TabIndex = 1;
            // 
            // lbStaticDataSource
            // 
            this.lbStaticDataSource.AutoSize = true;
            this.lbStaticDataSource.Location = new System.Drawing.Point(13, 79);
            this.lbStaticDataSource.Name = "lbStaticDataSource";
            this.lbStaticDataSource.Size = new System.Drawing.Size(44, 13);
            this.lbStaticDataSource.TabIndex = 0;
            this.lbStaticDataSource.Text = "Source:";
            // 
            // tbStaticDataFile
            // 
            this.tbStaticDataFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbStaticDataFile.Location = new System.Drawing.Point(61, 44);
            this.tbStaticDataFile.Name = "tbStaticDataFile";
            this.tbStaticDataFile.Size = new System.Drawing.Size(114, 20);
            this.tbStaticDataFile.TabIndex = 1;
            // 
            // lbStaticDataFile
            // 
            this.lbStaticDataFile.AutoSize = true;
            this.lbStaticDataFile.Location = new System.Drawing.Point(13, 47);
            this.lbStaticDataFile.Name = "lbStaticDataFile";
            this.lbStaticDataFile.Size = new System.Drawing.Size(26, 13);
            this.lbStaticDataFile.TabIndex = 0;
            this.lbStaticDataFile.Text = "File:";
            // 
            // panEmpty
            // 
            this.panEmpty.AllowDrop = true;
            this.panEmpty.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panEmpty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panEmpty.Location = new System.Drawing.Point(8, 6);
            this.panEmpty.Name = "panEmpty";
            this.panEmpty.Size = new System.Drawing.Size(224, 303);
            this.panEmpty.TabIndex = 9;
            this.panEmpty.DragDrop += new System.Windows.Forms.DragEventHandler(this.ThemeMii_Main_DragDrop);
            this.panEmpty.DragEnter += new System.Windows.Forms.DragEventHandler(this.ThemeMii_Main_DragEnter);
            // 
            // ssStatus
            // 
            this.ssStatus.AllowDrop = true;
            this.ssStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pbProgress,
            this.lbStatus});
            this.ssStatus.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.ssStatus.Location = new System.Drawing.Point(0, 373);
            this.ssStatus.Name = "ssStatus";
            this.ssStatus.Size = new System.Drawing.Size(382, 22);
            this.ssStatus.SizingGrip = false;
            this.ssStatus.TabIndex = 10;
            this.ssStatus.Text = "statusStrip1";
            this.ssStatus.DragDrop += new System.Windows.Forms.DragEventHandler(this.ThemeMii_Main_DragDrop);
            this.ssStatus.DragEnter += new System.Windows.Forms.DragEventHandler(this.ThemeMii_Main_DragEnter);
            // 
            // pbProgress
            // 
            this.pbProgress.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.Size = new System.Drawing.Size(100, 16);
            this.pbProgress.Value = 100;
            // 
            // lbStatus
            // 
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // btnSaveMym
            // 
            this.btnSaveMym.AllowDrop = true;
            this.btnSaveMym.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnSaveMym.AutoSize = true;
            this.btnSaveMym.Location = new System.Drawing.Point(4, 7);
            this.btnSaveMym.Name = "btnSaveMym";
            this.btnSaveMym.Size = new System.Drawing.Size(173, 23);
            this.btnSaveMym.TabIndex = 11;
            this.btnSaveMym.Text = "Save mym";
            this.btnSaveMym.UseVisualStyleBackColor = true;
            this.btnSaveMym.Click += new System.EventHandler(this.msSave_Click);
            this.btnSaveMym.DragDrop += new System.Windows.Forms.DragEventHandler(this.ThemeMii_Main_DragDrop);
            this.btnSaveMym.DragEnter += new System.Windows.Forms.DragEventHandler(this.ThemeMii_Main_DragEnter);
            // 
            // btnCreateCsm
            // 
            this.btnCreateCsm.AllowDrop = true;
            this.btnCreateCsm.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnCreateCsm.AutoSize = true;
            this.btnCreateCsm.Location = new System.Drawing.Point(197, 7);
            this.btnCreateCsm.Name = "btnCreateCsm";
            this.btnCreateCsm.Size = new System.Drawing.Size(173, 23);
            this.btnCreateCsm.TabIndex = 11;
            this.btnCreateCsm.Text = "Create csm";
            this.btnCreateCsm.UseVisualStyleBackColor = true;
            this.btnCreateCsm.Click += new System.EventHandler(this.btnCreateCsm_Click);
            this.btnCreateCsm.DragDrop += new System.Windows.Forms.DragEventHandler(this.ThemeMii_Main_DragDrop);
            this.btnCreateCsm.DragEnter += new System.Windows.Forms.DragEventHandler(this.ThemeMii_Main_DragEnter);
            // 
            // cmAdd
            // 
            this.cmAdd.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmAddContainer,
            this.cmAddStaticImage,
            this.cmAddStaticData,
            this.cmAddCustomImage,
            this.cmAddCustomData});
            this.cmAdd.Name = "cmAdd";
            this.cmAdd.Size = new System.Drawing.Size(153, 114);
            // 
            // cmAddContainer
            // 
            this.cmAddContainer.Name = "cmAddContainer";
            this.cmAddContainer.Size = new System.Drawing.Size(152, 22);
            this.cmAddContainer.Text = "Container";
            this.cmAddContainer.Click += new System.EventHandler(this.msAddContainer_Click);
            // 
            // cmAddStaticImage
            // 
            this.cmAddStaticImage.Name = "cmAddStaticImage";
            this.cmAddStaticImage.Size = new System.Drawing.Size(152, 22);
            this.cmAddStaticImage.Text = "Static Image";
            this.cmAddStaticImage.Click += new System.EventHandler(this.msAddStaticImage_Click);
            // 
            // cmAddStaticData
            // 
            this.cmAddStaticData.Name = "cmAddStaticData";
            this.cmAddStaticData.Size = new System.Drawing.Size(152, 22);
            this.cmAddStaticData.Text = "Static Data";
            this.cmAddStaticData.Click += new System.EventHandler(this.msAddStaticData_Click);
            // 
            // cmAddCustomImage
            // 
            this.cmAddCustomImage.Name = "cmAddCustomImage";
            this.cmAddCustomImage.Size = new System.Drawing.Size(152, 22);
            this.cmAddCustomImage.Text = "Custom Image";
            this.cmAddCustomImage.Click += new System.EventHandler(this.msAddCustomImage_Click);
            // 
            // cmAddCustomData
            // 
            this.cmAddCustomData.Name = "cmAddCustomData";
            this.cmAddCustomData.Size = new System.Drawing.Size(152, 22);
            this.cmAddCustomData.Text = "Custom Data";
            this.cmAddCustomData.Click += new System.EventHandler(this.msAddCustomData_Click);
            // 
            // panList
            // 
            this.panList.AllowDrop = true;
            this.panList.Controls.Add(this.lbxIniEntries);
            this.panList.Controls.Add(this.btnDown);
            this.panList.Controls.Add(this.btnUp);
            this.panList.Controls.Add(this.btnMinus);
            this.panList.Controls.Add(this.btnPlus);
            this.panList.Dock = System.Windows.Forms.DockStyle.Left;
            this.panList.Location = new System.Drawing.Point(0, 24);
            this.panList.Name = "panList";
            this.panList.Size = new System.Drawing.Size(141, 314);
            this.panList.TabIndex = 12;
            this.panList.DragDrop += new System.Windows.Forms.DragEventHandler(this.ThemeMii_Main_DragDrop);
            this.panList.DragEnter += new System.Windows.Forms.DragEventHandler(this.ThemeMii_Main_DragEnter);
            // 
            // panButtons
            // 
            this.panButtons.AllowDrop = true;
            this.panButtons.Controls.Add(this.btnCreateCsm);
            this.panButtons.Controls.Add(this.btnSaveMym);
            this.panButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panButtons.Location = new System.Drawing.Point(0, 338);
            this.panButtons.Name = "panButtons";
            this.panButtons.Size = new System.Drawing.Size(382, 35);
            this.panButtons.TabIndex = 13;
            this.panButtons.DragDrop += new System.Windows.Forms.DragEventHandler(this.ThemeMii_Main_DragDrop);
            this.panButtons.DragEnter += new System.Windows.Forms.DragEventHandler(this.ThemeMii_Main_DragEnter);
            // 
            // panPanels
            // 
            this.panPanels.AllowDrop = true;
            this.panPanels.Controls.Add(this.panStaticData);
            this.panPanels.Controls.Add(this.panCustomData);
            this.panPanels.Controls.Add(this.panStaticImage);
            this.panPanels.Controls.Add(this.panCustomImage);
            this.panPanels.Controls.Add(this.panContainer);
            this.panPanels.Controls.Add(this.panEmpty);
            this.panPanels.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panPanels.Location = new System.Drawing.Point(141, 24);
            this.panPanels.Name = "panPanels";
            this.panPanels.Size = new System.Drawing.Size(241, 314);
            this.panPanels.TabIndex = 14;
            this.panPanels.DragDrop += new System.Windows.Forms.DragEventHandler(this.ThemeMii_Main_DragDrop);
            this.panPanels.DragEnter += new System.Windows.Forms.DragEventHandler(this.ThemeMii_Main_DragEnter);
            // 
            // msHealthTutorial
            // 
            this.msHealthTutorial.Name = "msHealthTutorial";
            this.msHealthTutorial.Size = new System.Drawing.Size(191, 22);
            this.msHealthTutorial.Text = "Health Screen Tutorial";
            this.msHealthTutorial.Click += new System.EventHandler(this.msHealthTutorial_Click);
            // 
            // ThemeMii_Main
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 395);
            this.Controls.Add(this.panPanels);
            this.Controls.Add(this.panList);
            this.Controls.Add(this.panButtons);
            this.Controls.Add(this.msMain);
            this.Controls.Add(this.ssStatus);
            this.MainMenuStrip = this.msMain;
            this.MinimumSize = new System.Drawing.Size(398, 433);
            this.Name = "ThemeMii_Main";
            this.Text = "ThemeMii X by Leathl";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ThemeMii_Main_FormClosing);
            this.Load += new System.EventHandler(this.ThemeMii_Main_Load);
            this.ResizeEnd += new System.EventHandler(this.ThemeMii_Main_ResizeEnd);
            this.LocationChanged += new System.EventHandler(this.ThemeMii_Main_LocationChanged);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.ThemeMii_Main_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.ThemeMii_Main_DragEnter);
            this.panContainer.ResumeLayout(false);
            this.panContainer.PerformLayout();
            this.panCustomImage.ResumeLayout(false);
            this.panCustomImage.PerformLayout();
            this.panStaticImage.ResumeLayout(false);
            this.panStaticImage.PerformLayout();
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.panCustomData.ResumeLayout(false);
            this.panCustomData.PerformLayout();
            this.panStaticData.ResumeLayout(false);
            this.panStaticData.PerformLayout();
            this.ssStatus.ResumeLayout(false);
            this.ssStatus.PerformLayout();
            this.cmAdd.ResumeLayout(false);
            this.panList.ResumeLayout(false);
            this.panButtons.ResumeLayout(false);
            this.panButtons.PerformLayout();
            this.panPanels.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbxIniEntries;
        private System.Windows.Forms.Panel panContainer;
        private System.Windows.Forms.TextBox tbContainerFile;
        private System.Windows.Forms.Label lbContainerFile;
        private System.Windows.Forms.ComboBox cmbContainerFormat;
        private System.Windows.Forms.Label lbContainerType;
        private System.Windows.Forms.Label lbCont;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Panel panCustomImage;
        private System.Windows.Forms.Label lbCimg;
        private System.Windows.Forms.TextBox tbCustomImageFile;
        private System.Windows.Forms.Label lbCustomImageFile;
        private System.Windows.Forms.TextBox tbCustomImageName;
        private System.Windows.Forms.Label lbCustomImageFormat;
        private System.Windows.Forms.Label lbCustomImageHeight;
        private System.Windows.Forms.Label lbCustomImageWidth;
        private System.Windows.Forms.Label lbCustomImageName;
        private System.Windows.Forms.TextBox tbCustomImageHeight;
        private System.Windows.Forms.TextBox tbCustomImageWidth;
        private System.Windows.Forms.ComboBox cmbCustomImageFormat;
        private System.Windows.Forms.MenuStrip msMain;
        private System.Windows.Forms.ToolStripMenuItem msFile;
        private System.Windows.Forms.ToolStripMenuItem msList;
        private System.Windows.Forms.ToolStripMenuItem msTools;
        private System.Windows.Forms.ToolStripMenuItem msQuestion;
        private System.Windows.Forms.Button btnMinus;
        private System.Windows.Forms.Button btnPlus;
        private System.Windows.Forms.Panel panStaticImage;
        private System.Windows.Forms.ComboBox cmbStaticImageFormat;
        private System.Windows.Forms.Label lbSimg;
        private System.Windows.Forms.TextBox tbStaticImageHeight;
        private System.Windows.Forms.TextBox tbStaticImageWidth;
        private System.Windows.Forms.TextBox tbStaticImageSource;
        private System.Windows.Forms.Label lbStaticImageFormat;
        private System.Windows.Forms.Label lbStaticImageHeight;
        private System.Windows.Forms.Label lbStaticImageWidth;
        private System.Windows.Forms.Label lbStaticImageSource;
        private System.Windows.Forms.TextBox tbStaticImageFile;
        private System.Windows.Forms.Label lbStaticImageFile;
        private System.Windows.Forms.Button btnStaticImageBrowse;
        private System.Windows.Forms.TextBox tbStaticImageFilepath;
        private System.Windows.Forms.Label lbStaticImageFilepath;
        private System.Windows.Forms.Panel panCustomData;
        private System.Windows.Forms.Label lbCdta;
        private System.Windows.Forms.TextBox tbCustomDataName;
        private System.Windows.Forms.Label lbCustomDataName;
        private System.Windows.Forms.TextBox tbCustomDataFile;
        private System.Windows.Forms.Label lbCustomDataFile;
        private System.Windows.Forms.Panel panStaticData;
        private System.Windows.Forms.Label lbSdta;
        private System.Windows.Forms.TextBox tbStaticDataSource;
        private System.Windows.Forms.Label lbStaticDataSource;
        private System.Windows.Forms.TextBox tbStaticDataFile;
        private System.Windows.Forms.Label lbStaticDataFile;
        private System.Windows.Forms.ToolStripMenuItem msOpen;
        private System.Windows.Forms.ToolStripMenuItem msSave;
        private System.Windows.Forms.Panel panEmpty;
        private System.Windows.Forms.ToolStripMenuItem msNew;
        private System.Windows.Forms.StatusStrip ssStatus;
        private System.Windows.Forms.ToolStripProgressBar pbProgress;
        private System.Windows.Forms.ToolStripStatusLabel lbStatus;
        private System.Windows.Forms.ToolStripMenuItem msAbout;
        private System.Windows.Forms.Button btnStaticDataBrowse;
        private System.Windows.Forms.TextBox tbStaticDataFilepath;
        private System.Windows.Forms.Label lbStaticDataFilepath;
        private System.Windows.Forms.ToolStripSeparator msFileSep;
        private System.Windows.Forms.ToolStripMenuItem msExit;
        private System.Windows.Forms.Button btnSaveMym;
        private System.Windows.Forms.Button btnCreateCsm;
        private System.Windows.Forms.ToolStripMenuItem msAdd;
        private System.Windows.Forms.ToolStripMenuItem msRemove;
        private System.Windows.Forms.ToolStripMenuItem msMoveUp;
        private System.Windows.Forms.ToolStripMenuItem msMoveDown;
        private System.Windows.Forms.ToolStripMenuItem msOptions;
        private System.Windows.Forms.ToolStripMenuItem msMoveStart;
        private System.Windows.Forms.ToolStripMenuItem msMoveEnd;
        private System.Windows.Forms.ToolStripMenuItem msSourceManage;
        private System.Windows.Forms.ToolStripMenuItem msAddContainer;
        private System.Windows.Forms.ToolStripMenuItem msAddStaticImage;
        private System.Windows.Forms.ToolStripMenuItem msAddStaticData;
        private System.Windows.Forms.ToolStripMenuItem msAddCustomImage;
        private System.Windows.Forms.ToolStripMenuItem msAddCustomData;
        private System.Windows.Forms.ContextMenuStrip cmAdd;
        private System.Windows.Forms.ToolStripMenuItem cmAddContainer;
        private System.Windows.Forms.ToolStripMenuItem cmAddStaticImage;
        private System.Windows.Forms.ToolStripMenuItem cmAddStaticData;
        private System.Windows.Forms.ToolStripMenuItem cmAddCustomImage;
        private System.Windows.Forms.ToolStripMenuItem cmAddCustomData;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem msRemoveMissingStatics;
        private System.Windows.Forms.ToolStripMenuItem msIgnoreMissingEntries;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem msStandardSysMenu;
        private System.Windows.Forms.ToolStripMenuItem ms32;
        private System.Windows.Forms.ToolStripMenuItem ms40;
        private System.Windows.Forms.ToolStripMenuItem ms41;
        private System.Windows.Forms.ToolStripMenuItem ms42;
        private System.Windows.Forms.ToolStripMenuItem ms32J;
        private System.Windows.Forms.ToolStripMenuItem ms32U;
        private System.Windows.Forms.ToolStripMenuItem ms32E;
        private System.Windows.Forms.ToolStripMenuItem ms40J;
        private System.Windows.Forms.ToolStripMenuItem ms40U;
        private System.Windows.Forms.ToolStripMenuItem ms40E;
        private System.Windows.Forms.ToolStripMenuItem ms41J;
        private System.Windows.Forms.ToolStripMenuItem ms41U;
        private System.Windows.Forms.ToolStripMenuItem ms41E;
        private System.Windows.Forms.ToolStripMenuItem ms42J;
        private System.Windows.Forms.ToolStripMenuItem ms42U;
        private System.Windows.Forms.ToolStripMenuItem ms42E;
        private System.Windows.Forms.ToolStripMenuItem msDownloadBaseApp;
        private System.Windows.Forms.ToolStripMenuItem msDownload32;
        private System.Windows.Forms.ToolStripMenuItem msDownload40;
        private System.Windows.Forms.ToolStripMenuItem msDownload41;
        private System.Windows.Forms.ToolStripMenuItem msDownload42;
        private System.Windows.Forms.ToolStripMenuItem msDownload32J;
        private System.Windows.Forms.ToolStripMenuItem msDownload32U;
        private System.Windows.Forms.ToolStripMenuItem msDownload32E;
        private System.Windows.Forms.ToolStripMenuItem msDownload40J;
        private System.Windows.Forms.ToolStripMenuItem msDownload40U;
        private System.Windows.Forms.ToolStripMenuItem msDownload40E;
        private System.Windows.Forms.ToolStripMenuItem msDownload41J;
        private System.Windows.Forms.ToolStripMenuItem msDownload41U;
        private System.Windows.Forms.ToolStripMenuItem msDownload41E;
        private System.Windows.Forms.ToolStripMenuItem msDownload42J;
        private System.Windows.Forms.ToolStripMenuItem msDownload42U;
        private System.Windows.Forms.ToolStripMenuItem msDownload42E;
        private System.Windows.Forms.ToolStripMenuItem msImageSizeFromPng;
        private System.Windows.Forms.ToolStripMenuItem msCsmToMym;
        private System.Windows.Forms.Button btnStaticDataBrowseFile;
        private System.Windows.Forms.Button btnStaticImageBrowseFile;
        private System.Windows.Forms.ToolStripMenuItem msBrowseBaseApp;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem msContainerManage;
        private System.Windows.Forms.Button btnContainerBrowseFile;
        private System.Windows.Forms.Button btnCustomImageBrowseFile;
        private System.Windows.Forms.Button btnCustomDataBrowseFile;
        private System.Windows.Forms.ToolStripMenuItem msKeepExtractedApp;
        private System.Windows.Forms.ToolStripMenuItem msLz77Containers;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.Panel panList;
        private System.Windows.Forms.Panel panButtons;
        private System.Windows.Forms.Panel panPanels;
        private System.Windows.Forms.ToolStripMenuItem msHelp;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem msInstallToNandBackup;
        private System.Windows.Forms.ToolStripMenuItem msSavePrompt;
        private System.Windows.Forms.Label lbContainerInfo;
        private System.Windows.Forms.ToolStripMenuItem msSaveNandPath;
        private System.Windows.Forms.ToolStripMenuItem msChangeNandPath;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem msImageSizeFromTpl;
        private System.Windows.Forms.ToolStripMenuItem msHealthTutorial;
    }
}

*/