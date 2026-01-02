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
using System.Threading;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Platform.Storage;
using MsBox.Avalonia;
using MsBox.Avalonia.Enums;


namespace ThemeMii
{
    public partial class ThemeMii_Main : Window
    {
        private mymini ini;
        private string tempDir;
        private string appOut;
        private string mymOut;
        private int lastSelected = -1;
        private string lastSelectedEntry;
        private ThemeMiiSettings? settings;
        private BaseApp lastExtracted = (BaseApp)1;
        private AppBrowseInfo browseInfo;
        private string openedMym;

        public ThemeMii_Main()
        {
            InitializeComponent();

            // TODO: Need equivalent.
            //if (Properties.Settings.Default.firstRun) ShowDisclaimer();
        }

        private bool saveCheckPassed;
        
        private async void ThemeMii_Main_Load(object? sender, RoutedEventArgs e)
        {
            //TODO:  This points to the old update site.  Perhaps implement when we have further updated?
            //Thread updateThread = new Thread(new ThreadStart(this._updateCheck));
            //updateThread.Start();
            var currentVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            Title = Title!.Replace("X", currentVersion?.ToString() ?? "Unknown");
            Initialize();
            LoadSettings();
        }
        
        private async void ThemeMii_Main_FormClosing(object? sender, WindowClosingEventArgs e)
        {
            if (btnCreateCsm.IsEnabled && (settings?.SavePrompt ?? false) && !saveCheckPassed)
            {
                e.Cancel = true;
                
                var disclaimerBox = MessageBoxManager.GetMessageBoxStandard("Question",
                    "Do you want to save your mym before closing?",
                    ButtonEnum.YesNoCancel, MsBox.Avalonia.Enums.Icon.Question);
                var result = await disclaimerBox.ShowAsync();

                if (result != ButtonResult.Yes && result != ButtonResult.No)
                    return; 
                
                if (result == ButtonResult.Yes)
                    SaveMym(true);
                
                //Forces a call to this event a second time.  We should bypass and save as normally.  
                saveCheckPassed = true;
                Close();
                return;
            }
            
            SaveSettings();

            try
            {
                Directory.Delete(tempDir, true);
            }
            catch(Exception ex)
            {
                Console.Error.WriteLine(ex);
            }

        }
        /*

        void ini_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            ReportProgress(e.ProgressPercentage, (string)e.UserState);
        }

        private void msOpen_Click(object sender, EventArgs e)
        {
            if (pbProgress.Value == 100)
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "mym files|*.mym";

                if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    Initialize();

                    Thread workThread = new Thread(new ParameterizedThreadStart(this._loadMym));
                    workThread.Start(ofd.FileName);
                }
            }
        }
        

        private void lbxIniEntrys_SelectedIndexChanged(object sender, EventArgs e)
        {
            SaveLastSelected();

            if (lbxIniEntries.SelectedIndex > -1)
            {
                lastSelected = lbxIniEntries.SelectedIndex;
                lastSelectedEntry = lbxIniEntries.Items[lbxIniEntries.SelectedIndex].ToString();
                iniEntry tempEntry = ini.GetEntry(lbxIniEntries.SelectedItem.ToString());

                if (tempEntry.entryType == iniEntry.EntryType.Container)
                {
                    lbCont.Text = tempEntry.entry;
                    tbContainerFile.Text = tempEntry.file;
                    cmbContainerFormat.SelectedIndex = (tempEntry.type == iniEntry.ContainerType.ASH) ? 0 : 1;

                    if (!panContainer.Visible)
                    {
                        HidePanels();
                        panContainer.Visible = true;
                    }
                }
                else if (tempEntry.entryType == iniEntry.EntryType.CustomImage)
                {
                    lbCimg.Text = tempEntry.entry;
                    tbCustomImageFile.Text = tempEntry.file;
                    tbCustomImageName.Text = tempEntry.name;
                    if (!settings.autoImageSize) tbCustomImageWidth.Text = tempEntry.width.ToString();
                    if (!settings.autoImageSize) tbCustomImageHeight.Text = tempEntry.height.ToString();

                    if (tempEntry.format == iniEntry.TplFormat.RGB5A3) cmbCustomImageFormat.SelectedIndex = 0;
                    else if (tempEntry.format == iniEntry.TplFormat.RGBA8) cmbCustomImageFormat.SelectedIndex = 1;
                    else if (tempEntry.format == iniEntry.TplFormat.RGB565) cmbCustomImageFormat.SelectedIndex = 2;
                    else if (tempEntry.format == iniEntry.TplFormat.I4) cmbCustomImageFormat.SelectedIndex = 3;
                    else if (tempEntry.format == iniEntry.TplFormat.I8) cmbCustomImageFormat.SelectedIndex = 4;
                    else if (tempEntry.format == iniEntry.TplFormat.IA4) cmbCustomImageFormat.SelectedIndex = 5;
                    else if (tempEntry.format == iniEntry.TplFormat.IA8) cmbCustomImageFormat.SelectedIndex = 6;

                    if (!panCustomImage.Visible)
                    {
                        HidePanels();
                        panCustomImage.Visible = true;
                    }
                }
                else if (tempEntry.entryType == iniEntry.EntryType.StaticImage)
                {
                    lbSimg.Text = tempEntry.entry;
                    tbStaticImageFile.Text = tempEntry.file;
                    if (!settings.sourceManage) tbStaticImageSource.Text = tempEntry.source;
                    if (!settings.autoImageSize) tbStaticImageWidth.Text = tempEntry.width.ToString();
                    if (!settings.autoImageSize) tbStaticImageHeight.Text = tempEntry.height.ToString();

                    if (tempEntry.format == iniEntry.TplFormat.RGB5A3) cmbStaticImageFormat.SelectedIndex = 0;
                    else if (tempEntry.format == iniEntry.TplFormat.RGBA8) cmbStaticImageFormat.SelectedIndex = 1;
                    else if (tempEntry.format == iniEntry.TplFormat.RGB565) cmbStaticImageFormat.SelectedIndex = 2;
                    else if (tempEntry.format == iniEntry.TplFormat.I4) cmbStaticImageFormat.SelectedIndex = 3;
                    else if (tempEntry.format == iniEntry.TplFormat.I8) cmbStaticImageFormat.SelectedIndex = 4;
                    else if (tempEntry.format == iniEntry.TplFormat.IA4) cmbStaticImageFormat.SelectedIndex = 5;
                    else if (tempEntry.format == iniEntry.TplFormat.IA8) cmbStaticImageFormat.SelectedIndex = 6;
                    tbStaticImageFilepath.Text = tempEntry.filepath;

                    if (!panStaticImage.Visible)
                    {
                        HidePanels();
                        panStaticImage.Visible = true;
                    }
                }
                else if (tempEntry.entryType == iniEntry.EntryType.CustomData)
                {
                    lbCdta.Text = tempEntry.entry;
                    tbCustomDataFile.Text = tempEntry.file;
                    tbCustomDataName.Text = tempEntry.name;

                    if (!panCustomData.Visible)
                    {
                        HidePanels();
                        panCustomData.Visible = true;
                    }
                }
                else if (tempEntry.entryType == iniEntry.EntryType.StaticData)
                {
                    lbSdta.Text = tempEntry.entry;
                    tbStaticDataFile.Text = tempEntry.file;
                    if (!settings.sourceManage) tbStaticDataSource.Text = tempEntry.source;

                    tbStaticDataFilepath.Text = tempEntry.filepath;

                    if (!panStaticData.Visible)
                    {
                        HidePanels();
                        panStaticData.Visible = true;
                    }
                }
            }
            else HidePanels();
        }

        */
        private void msExit_Click(object? sender, RoutedEventArgs e)
        {
            Close();
        }
        
        
        private void msNew_Click(object? sender, RoutedEventArgs e)
        {
            if (ActionBar.Value == 0 || ActionBar.Value == 100)
            {
                Initialize();
                SetControls(true);
                ini = new mymini();
                openedMym = string.Empty;
            }
        }
        
        /*

        private void msSave_Click(object sender, EventArgs e)
        {
            if (pbProgress.Value == 100)
                SaveMym(false);
        }

        private void intTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != '\b';
        }

        private void SwapEntryUp(object sender, EventArgs e)
        {
            SwapEntries(lbxIniEntries.SelectedIndex, true);
        }

        private void SwapEntryDown(object sender, EventArgs e)
        {
            SwapEntries(lbxIniEntries.SelectedIndex, false);
        }

        private void msMoveStart_Click(object sender, EventArgs e)
        {
            if (lbxIniEntries.SelectedIndex > -1)
            {
                SaveSelected();
                object temp = lbxIniEntries.Items[lbxIniEntries.SelectedIndex];
                lbxIniEntries.Items.RemoveAt(lbxIniEntries.SelectedIndex);
                lbxIniEntries.Items.Insert(0, temp);
                lbxIniEntries.SelectedIndex = 0;
            }
        }

        private void msMoveEnd_Click(object sender, EventArgs e)
        {
            if (lbxIniEntries.SelectedIndex > -1)
            {
                SaveSelected();
                object temp = lbxIniEntries.Items[lbxIniEntries.SelectedIndex];
                lbxIniEntries.Items.RemoveAt(lbxIniEntries.SelectedIndex);
                lbxIniEntries.Items.Add(temp);
                lbxIniEntries.SelectedIndex = lbxIniEntries.Items.Count - 1;
            }
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            RemoveEntry(lbxIniEntries.SelectedIndex);
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            cmAdd.Show(MousePosition);
        }

        private void msAddContainer_Click(object sender, EventArgs e)
        {
            AddEntry(iniEntry.EntryType.Container);
        }

        private void msAddStaticImage_Click(object sender, EventArgs e)
        {
            AddEntry(iniEntry.EntryType.StaticImage);
        }

        private void msAddStaticData_Click(object sender, EventArgs e)
        {
            AddEntry(iniEntry.EntryType.StaticData);
        }

        private void msAddCustomImage_Click(object sender, EventArgs e)
        {
            AddEntry(iniEntry.EntryType.CustomImage);
        }

        private void msAddCustomData_Click(object sender, EventArgs e)
        {
            AddEntry(iniEntry.EntryType.CustomData);
        }

        private void btnStaticDataBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (File.Exists(tbStaticDataFilepath.Text)) ofd.InitialDirectory = Path.GetDirectoryName(tbStaticDataFilepath.Text);

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                tbStaticDataFilepath.Text = ofd.FileName;
            }
        }

        private void btnStaticImageBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "PNG|*.png";
            if (File.Exists(tbStaticImageFilepath.Text)) ofd.InitialDirectory = Path.GetDirectoryName(tbStaticImageFilepath.Text);

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                tbStaticImageFilepath.Text = ofd.FileName;
            }
        }

        private void msRemoveMissingStatics_Click(object sender, EventArgs e)
        {
            for (int i = lbxIniEntries.Items.Count - 1; i > -1; i--)
            {
                if (lbxIniEntries.Items[i].ToString().StartsWith("[s"))
                {
                    iniEntry tempEntry = ini.GetEntry(lbxIniEntries.Items[i].ToString());
                    if (!File.Exists(tempEntry.filepath))
                        RemoveEntry(i);
                }
            }
        }

        private void msIgnoreMissingEntries_Click(object sender, EventArgs e)
        {
            settings.ignoreMissing = msIgnoreMissingEntries.Checked;
        }

        private void msAutoManage_Click(object sender, EventArgs e)
        {
            if (!msSourceManage.Checked)
            {
                settings.sourceManage = false;

                if (panStaticImage.Visible)
                { tbStaticImageSource.Text = ini.GetEntry(lbxIniEntries.SelectedItem.ToString()).source; }
                else if (panStaticData.Visible)
                { tbStaticDataSource.Text = ini.GetEntry(lbxIniEntries.SelectedItem.ToString()).source; }

                tbStaticDataSource.Enabled = true;
                tbStaticImageSource.Enabled = true;
            }
            else
            {
                settings.sourceManage = true;
                tbStaticDataSource.Text = string.Empty;
                tbStaticImageSource.Text = string.Empty;
                tbStaticDataSource.Enabled = false;
                tbStaticImageSource.Enabled = false;
            }
        }

        private void msImageSizeFromPng_Click(object sender, EventArgs e)
        {
            if (!msImageSizeFromPng.Checked)
            {
                settings.autoImageSize = false;

                if (panStaticImage.Visible)
                {
                    iniEntry tempEntry = ini.GetEntry(lbxIniEntries.SelectedItem.ToString());
                    tbStaticImageWidth.Text = tempEntry.width.ToString();
                    tbStaticImageHeight.Text = tempEntry.height.ToString();
                }
                else if (panCustomImage.Visible)
                {
                    iniEntry tempEntry = ini.GetEntry(lbxIniEntries.SelectedItem.ToString());
                    tbCustomImageWidth.Text = tempEntry.width.ToString();
                    tbCustomImageHeight.Text = tempEntry.height.ToString();
                }

                tbStaticImageWidth.Enabled = true;
                tbStaticImageHeight.Enabled = true;
                tbCustomImageWidth.Enabled = true;
                tbCustomImageHeight.Enabled = true;
            }
            else
            {
                settings.autoImageSize = true;
                tbStaticImageWidth.Text = string.Empty;
                tbStaticImageHeight.Text = string.Empty;
                tbCustomImageWidth.Text = string.Empty;
                tbCustomImageHeight.Text = string.Empty;
                tbStaticImageWidth.Enabled = false;
                tbStaticImageHeight.Enabled = false;
                tbCustomImageWidth.Enabled = false;
                tbCustomImageHeight.Enabled = false;

                if (msImageSizeFromTpl.Checked)
                {
                    msImageSizeFromTpl.Checked = false;
                    settings.imageSizeFromTpl = false;
                }

                MessageBox.Show("Be sure that your PNG images have the same size as the original TPLs they will replace," +
                                " else you might get a brick!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void StandardSysMenu_Click(object sender, EventArgs e)
        {
            bool state = ((ToolStripMenuItem)sender).Checked;

            if (state)
            {
                UncheckSysMenus();

                ToolStripMenuItem cmSender = sender as ToolStripMenuItem;
                BaseApp bApp;
                string titleVersion;

                switch (cmSender.Name)
                {
                    case "ms32J":
                        bApp = BaseApp.J32;
                        titleVersion = "288";
                        break;
                    case "ms32U":
                        bApp = BaseApp.U32;
                        titleVersion = "289";
                        break;
                    case "ms32E":
                        bApp = BaseApp.E32;
                        titleVersion = "290";
                        break;
                    case "ms40J":
                        bApp = BaseApp.J40;
                        titleVersion = "416";
                        break;
                    case "ms40U":
                        bApp = BaseApp.U40;
                        titleVersion = "417";
                        break;
                    case "ms40E":
                        bApp = BaseApp.E40;
                        titleVersion = "418";
                        break;
                    case "ms41J":
                        bApp = BaseApp.J41;
                        titleVersion = "448";
                        break;
                    case "ms41U":
                        bApp = BaseApp.U41;
                        titleVersion = "449";
                        break;
                    case "ms41E":
                        bApp = BaseApp.E41;
                        titleVersion = "450";
                        break;
                    case "ms42J":
                        bApp = BaseApp.J42;
                        titleVersion = "480";
                        break;
                    case "ms42U":
                        bApp = BaseApp.U42;
                        titleVersion = "481";
                        break;
                    case "ms42E":
                        bApp = BaseApp.E42;
                        titleVersion = "482";
                        break;
                    default: return;
                }

                if (!File.Exists(Application.StartupPath + "\\" + ((int)bApp).ToString("x8") + ".app"))
                {
                    if (MessageBox.Show(string.Format("{0}.app wasn't found in the application directory.\nDo you want to download it?", ((int)bApp).ToString("x8")),
                        "Download Base App?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.Yes) return;

                    if (CommonKeyCheck())
                    {
                        Thread workerThread = new Thread(new ParameterizedThreadStart(this._downloadBaseApp));
                        workerThread.Start(new string[] { ((int)bApp).ToString("x8"), titleVersion, Application.StartupPath + "\\" + ((int)bApp).ToString("x8") + ".app" });
                    }
                }

                ((ToolStripMenuItem)sender).Checked = state;
            }
        }

        private void btnCreateCsm_Click(object sender, EventArgs e)
        {
            if (lbxIniEntries.Items.Count > 0 && pbProgress.Value == 100)
            {
                BaseApp bApp = GetBaseApp();
                string baseApp = Application.StartupPath + "\\" + ((int)bApp).ToString("x8") + ".app";
                if (!File.Exists(baseApp) || (int)bApp == 0)
                {
                    OpenFileDialog ofd = new OpenFileDialog();
                    if ((int)bApp > 0) ofd.Title = "Standard System Menu base app wasn't found";
                    ofd.Filter = "app|*.app";

                    if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK) baseApp = ofd.FileName;
                    else return;
                }

                CreateCsm(baseApp, string.Empty);
            }
        }

        */
        private void msAbout_Click(object sender, RoutedEventArgs e)
        {
            var windowOwner = this;
            var aboutWindow = new ThemeMii_About();
            aboutWindow.ShowDialog(windowOwner);
        }
        
        
        private async void DownloadBaseApp_Click(object sender, RoutedEventArgs e)
        {
            if (ActionBar.Value != 0 && ActionBar.Value != 100)
                return;
            
            var commonKeyCreated = await CommonKeyCheck(this);
            if (!commonKeyCreated)
                return;

            var menuSource = e.Source as MenuItem;
            if (menuSource == null)
                return;

            string titleVersion;
            BaseApp bApp;

            switch (menuSource.Name)
            {
                case "msDownload32J":
                    bApp = BaseApp.J32;
                    titleVersion = "288";
                    break;
                case "msDownload32U":
                    bApp = BaseApp.U32;
                    titleVersion = "289";
                    break;
                case "msDownload32E":
                    bApp = BaseApp.E32;
                    titleVersion = "290";
                    break;
                case "msDownload40J":
                    bApp = BaseApp.J40;
                    titleVersion = "416";
                    break;
                case "msDownload40U":
                    bApp = BaseApp.U40;
                    titleVersion = "417";
                    break;
                case "msDownload40E":
                    bApp = BaseApp.E40;
                    titleVersion = "418";
                    break;
                case "msDownload41J":
                    bApp = BaseApp.J41;
                    titleVersion = "448";
                    break;
                case "msDownload41U":
                    bApp = BaseApp.U41;
                    titleVersion = "449";
                    break;
                case "msDownload41E":
                    bApp = BaseApp.E41;
                    titleVersion = "450";
                    break;
                case "msDownload42J":
                    bApp = BaseApp.J42;
                    titleVersion = "480";
                    break;
                case "msDownload42U":
                    bApp = BaseApp.U42;
                    titleVersion = "481";
                    break;
                case "msDownload42E":
                    bApp = BaseApp.E42;
                    titleVersion = "482";
                    break;
                case "msDownload43J":
                    bApp = BaseApp.J43;
                    titleVersion = "512";
                    break;
                case "msDownload43E":
                    bApp = BaseApp.E43;
                    titleVersion = "513";
                    break;
                case "msDownload43U":
                    bApp = BaseApp.U43;
                    titleVersion = "514";
                    break;
                case "msDownload43K":
                    bApp = BaseApp.K43;
                    titleVersion = "518";
                    break;
                default: 
                    return;
            }

            var fileStorage = StorageProvider;
            var result = await fileStorage.SaveFilePickerAsync(new FilePickerSaveOptions()
            {
                DefaultExtension = "app",
                FileTypeChoices = [new FilePickerFileType("app")
                {
                    Patterns = ["*.app"]
                }],
                SuggestedFileName = ((int)bApp).ToString("x8")
            });

            if (result != null)
                await DownloadBaseApp(((int)bApp).ToString("x8"), titleVersion, result.Path.AbsolutePath);
        }

        
        private void msCsmToMym_Click(object sender, RoutedEventArgs e)
        {
            if (ActionBar.Value == 0 || ActionBar.Value == 100)
            {
                ThemeMii_CsmToMym ctm = new ThemeMii_CsmToMym();
                ctm.tempDir = tempDir + "compare";
                var windowOwner = this;
                ctm.ShowDialog(windowOwner);
            }
        }

        
        private async void btnBrowseFile_Click(object? sender, RoutedEventArgs e)
        {
            if (ActionBar.Value != 0 && ActionBar.Value != 100)
                return;

            browseInfo.viewOnly = sender!.Equals(msBrowseBaseApp);
            //browseInfo.containerBrowse = (menuItemSender.Name == btnContainerBrowseFile);

            /*
             * TODO:  Investigate what this logic was for.  
            if (sender != msBrowseBaseApp)
            {
                if (panContainer.Visible) 
                    browseInfo.selectedNode = tbContainerFile.Text;
                else if (panCustomImage.Visible) 
                    browseInfo.selectedNode = tbCustomImageFile.Text;
                else if (panCustomData.Visible)
                    browseInfo.selectedNode = tbCustomDataFile.Text;
                else if (panStaticImage.Visible) 
                    browseInfo.selectedNode = tbStaticImageFile.Text;
                else if (panStaticData.Visible)
                    browseInfo.selectedNode = tbStaticDataFile.Text;
                else browseInfo.selectedNode = string.Empty;

                if (panStaticImage.Visible || panCustomImage.Visible) 
                    browseInfo.onlyTpls = true;
                else 
                    browseInfo.onlyTpls = false;
            }
            else
                browseInfo.selectedNode = string.Empty;
            */

            await AppBrowse();
        }
        
        /*

        private void msContainerManage_Click(object sender, EventArgs e)
        {
            settings.containerManage = msContainerManage.Checked;
        }

        private void msKeepExtractedApp_Click(object sender, EventArgs e)
        {
            settings.keepExtractedApp = msKeepExtractedApp.Checked;
        }

        private void msLz77Containers_Click(object sender, EventArgs e)
        {
            settings.lz77Containers = msLz77Containers.Checked;
        }
        
        */

        private void msHelp_Click(object? sender, RoutedEventArgs e)
        {
            var windowOwner = this;
            var helpWindow = new ThemeMii_Help();
            helpWindow.ShowDialog(windowOwner);
        }

        /*
        private void msInstallToNandBackup_Click(object sender, EventArgs e)
        {
            if (lbxIniEntries.Items.Count > 0 && pbProgress.Value == 100)
            {

                string sysMenuPath = settings.nandBackupPath + "\\title\\00000001\\00000002\\content\\";

                if (!Directory.Exists(sysMenuPath) || !settings.saveNandPath)
                {
                    FolderBrowserDialog fbd = new FolderBrowserDialog();
                    fbd.Description = "Choose the drive or directory where the 8 folders of the NAND backup are (ticket, title, shared1, ...)";

                    if (fbd.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;

                    settings.nandBackupPath = fbd.SelectedPath;
                    sysMenuPath = fbd.SelectedPath + "\\title\\00000001\\00000002\\content\\";

                    if (!Directory.Exists(sysMenuPath))
                    { ErrorBox("Directory wasn't found:\n" + sysMenuPath); return; }
                }

                if (!File.Exists(sysMenuPath + "title.tmd"))
                { ErrorBox("File wasn't found:\n" + sysMenuPath + "title.tmd"); return; }

                BaseApp bApp = GetBaseAppFromTitleVersion(Wii.WadInfo.GetTitleVersion(sysMenuPath + "title.tmd"));

                if ((int)bApp == 0)
                { ErrorBox("Incompatible System Menu found. You must either have 3.2, 4.0, 4.1 or 4.2 (J/U/E)!"); return; }

                string baseAppFile = sysMenuPath + ((int)bApp).ToString("x8") + ".app";

                if (!File.Exists(baseAppFile))
                { ErrorBox("Base app file wasn't found:\n" + baseAppFile); return; }

                BaseApp standardApp = GetBaseApp();
                string baseApp = Application.StartupPath + "\\" + ((int)standardApp).ToString("x8") + ".app";
                if (!File.Exists(baseApp) || (int)standardApp == 0 || standardApp != bApp)
                {
                    OpenFileDialog ofd = new OpenFileDialog();
                    if ((int)standardApp > 0) ofd.Title = "Standard System Menu base app wasn't found";
                    ofd.Filter = "app|*.app";
                    ofd.FileName = ((int)standardApp).ToString("x8") + ".app";

                    if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK) baseApp = ofd.FileName;
                    else return;
                }

                CreateCsm(baseApp, baseAppFile);
            }
        }

        private void msSavePrompt_Click(object sender, EventArgs e)
        {
            settings.savePrompt = msSavePrompt.Checked;
        }

        private void ThemeMii_Main_LocationChanged(object sender, EventArgs e)
        {
            if (settings.saveWindowChanges && this.WindowState != FormWindowState.Maximized)
                Properties.Settings.Default.windowLocation = this.Location;
        }

        private void ThemeMii_Main_ResizeEnd(object sender, EventArgs e)
        {
            if (settings.saveWindowChanges)
            {
                Properties.Settings.Default.windowLocation = this.Location;
                Properties.Settings.Default.windowSize = this.Size;
            }
        }

        private void msSaveNandPath_Click(object sender, EventArgs e)
        {
            settings.saveNandPath = msSaveNandPath.Checked;
            msChangeNandPath.Visible = msSaveNandPath.Checked;
        }

        private void msChangeNandPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "Choose the drive or directory where the 8 folders of the NAND backup are (ticket, title, shared1, ...)";
            fbd.SelectedPath = settings.nandBackupPath;

            if (fbd.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;

            settings.nandBackupPath = fbd.SelectedPath;
        }

        private void ThemeMii_Main_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop) && pbProgress.Value == 100)
            {
                string[] drop = (string[])e.Data.GetData(DataFormats.FileDrop);

                if (drop.Length == 1 && drop[0].ToLower().EndsWith(".mym"))
                    e.Effect = DragDropEffects.Copy;
            }
        }

        private void ThemeMii_Main_DragDrop(object sender, DragEventArgs e)
        {
            if (pbProgress.Value == 100)
            {
                string[] drop = (string[])e.Data.GetData(DataFormats.FileDrop);
                Initialize();

                Thread workThread = new Thread(new ParameterizedThreadStart(this._loadMym));
                workThread.Start(drop[0]);
            }
        }

        */
        private void msHealthTutorial_Click(object? sender, RoutedEventArgs e)
        {
            var windowOwner = this;
            var helpWindow = new ThemeMii_Help();
            helpWindow.Tutorial = true;
            helpWindow.ShowDialog(windowOwner);
        }
        
        /*

        private void msImageSizeFromTpl_Click(object sender, EventArgs e)
        {
            settings.imageSizeFromTpl = msImageSizeFromTpl.Checked;

            if (msImageSizeFromPng.Checked)
            {
                msImageSizeFromPng.Checked = false;
                msImageSizeFromPng_Click(null, null);
            }
        }
        */
    }
}
