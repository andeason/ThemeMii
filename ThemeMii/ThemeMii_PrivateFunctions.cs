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
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Media.Imaging;
using Avalonia.Platform.Storage;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using MsBox.Avalonia;
using MsBox.Avalonia.Enums;
using Image = Avalonia.Controls.Image;

//using System.Windows.Forms;


namespace ThemeMii
{
    partial class ThemeMii_Main
    {
        private async void ShowDisclaimer()
        {
            var disclaimerBox = MessageBoxManager.GetMessageBoxStandard("Warning",
                "Only install themes if you have a proper brickprotection or you might get a brick beyond repair!",
                ButtonEnum.Ok, MsBox.Avalonia.Enums.Icon.Warning);
            await disclaimerBox.ShowAsync();
        }

        private bool CheckInet()
        {
            try
            {
                System.Net.IPHostEntry ipHost = System.Net.Dns.GetHostEntry("www.google.com");
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void Initialize()
        {
            lastSelected = -1;
            SetControls(false);
            HidePanels();
            if (!string.IsNullOrEmpty(tempDir))
                ClearTempDir();
            GetTempDir();
        }

        private void GetTempDir()
        {
            tempDir = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            appOut = Path.Combine(tempDir,"appOut");
            mymOut = Path.Combine(tempDir,"mymOut");

            Directory.CreateDirectory(appOut);
            Directory.CreateDirectory(mymOut);
        }

        private void ClearTempDir()
        {
            try { Directory.Delete(tempDir, true); }
            catch { }
        }

        public void ExitApplication()
        {
            SaveSettings();

            try
            {
                Directory.Delete(tempDir, true);
            }
            catch { }

            Environment.Exit(0);
        }

        private void SetControls(bool enable)
        {
            ChangeControls(enable);
        }
        

        private void HidePanels()
        {
            ContainerStack.IsVisible = false;
            CustomImageStack.IsVisible = false;
            StaticImageStack.IsVisible = false;
            CustomDataStack.IsVisible = false;
            StaticDataStack.IsVisible = false;
        }

        private void LoadSettings()
        {
            if (File.Exists("Settings.json"))
            {
                try
                {
                    using StreamReader sr = new StreamReader("Settings.json");
                    settings = JsonSerializer.Deserialize<ThemeMiiSettings>(sr.ReadToEnd()) ?? null;
                }
                catch (Exception e)
                {
                    Console.Error.WriteLine(e);
                }
            }
            
            if (settings == null)
            {
                ShowDisclaimer();
            }

            settings ??= new ThemeMiiSettings();
            
            SavePrompt.IsChecked = settings.SavePrompt;
            Lz77Containers.IsChecked = settings.Lz77Containers;
            KeepExtractedApp.IsChecked = settings.KeepExtractedApp;
            ContainerManage.IsChecked = settings.ContainerManage;
            SourceManage.IsChecked = settings.SourceManage;
            IgnoreMissing.IsChecked = settings.IgnoreMissing;
            ImageSizeFromTpl.IsChecked = settings.ImageSizeFromTpl;
            SaveNandPath.IsChecked = settings.SaveNandPath;
            ChangeNandPath.IsVisible = SaveNandPath.IsChecked;
            Position = new PixelPoint(settings.LastLocationX, settings.LastLocationY);
            WindowState = settings.LastWindowState;


            //TODO:  Another one I don't have an idea yet....
            //lastExtracted = (BaseApp)Properties.Settings.Default.lastExtracted;
            //BaseApp bApp = (BaseApp)Properties.Settings.Default.standardMenu;
            //UncheckSysMenus();
            //if (bApp == BaseApp.E32) ms32E.Checked = true;
            //else if (bApp == BaseApp.E40) ms40E.Checked = true;
            //else if (bApp == BaseApp.E41) ms41E.Checked = true;
            //else if (bApp == BaseApp.E42) ms42E.Checked = true;
            //else if (bApp == BaseApp.J32) ms32J.Checked = true;
            //else if (bApp == BaseApp.J40) ms40J.Checked = true;
            //else if (bApp == BaseApp.J41) ms41J.Checked = true;
            //else if (bApp == BaseApp.J42) ms42J.Checked = true;
            //else if (bApp == BaseApp.U32) ms32U.Checked = true;
            //else if (bApp == BaseApp.U40) ms40U.Checked = true;
            //else if (bApp == BaseApp.U41) ms41U.Checked = true;
            //else if (bApp == BaseApp.U42) ms42U.Checked = true;

            if (settings?.SourceManage ?? false)
            {
                //tbStaticDataSource.Enabled = false;
                //tbStaticImageSource.Enabled = false;
            }
            if (settings?.AutoImageSize ?? false)
            {
                //tbStaticImageWidth.Enabled = false;
                //tbStaticImageHeight.Enabled = false;
                //tbCustomImageWidth.Enabled = false;
                //tbCustomImageHeight.Enabled = false;
            }
        }

        private void SaveSettings()
        {
            
            var settingsToSave = new ThemeMiiSettings
            {
                SavePrompt = SavePrompt.IsChecked,
                Lz77Containers = Lz77Containers.IsChecked,
                KeepExtractedApp = KeepExtractedApp.IsChecked,
                ContainerManage = ContainerManage.IsChecked,
                SourceManage = SourceManage.IsChecked,
                IgnoreMissing = IgnoreMissing.IsChecked,
                ImageSizeFromTpl = ImageSizeFromTpl.IsChecked,
                SaveNandPath = SaveNandPath.IsChecked,
                //I don't really like this, but for now we will assume settings has a purpose JUST for this.
                NandBackupPath = settings?.NandBackupPath ?? "",
                LastLocationX = Position.X,
                LastLocationY =  Position.Y,
                LastWindowState = WindowState
            };
            
            using var writer = new StreamWriter("Settings.json");
            writer.Write(JsonSerializer.Serialize(settingsToSave, new JsonSerializerOptions
            {
                WriteIndented = true
            })); 
        }

        private BaseApp GetBaseApp()
        {
            if (ms32E.IsChecked) 
                return BaseApp.E32;
            if (ms32J.IsChecked) 
                return BaseApp.J32;
            if (ms32U.IsChecked) 
                return BaseApp.U32;
            if  (ms40E.IsChecked)
                return BaseApp.E40;
            if (ms40J.IsChecked) 
                return BaseApp.J40;
            if (ms40U.IsChecked) 
                return BaseApp.U40;
            if (ms41E.IsChecked) 
                return BaseApp.E41;
            if (ms41J.IsChecked) 
                return BaseApp.J41;
            if (ms41U.IsChecked) 
                return BaseApp.U41;
            if (ms42E.IsChecked) 
                return BaseApp.E42;
            if (ms42J.IsChecked) 
                return BaseApp.J42;
            if (ms42U.IsChecked) 
                return BaseApp.U42;
            
            return 0;
        }

        private void UncheckSysMenus()
        {
            ms32E.IsChecked = false;
            ms32J.IsChecked = false;
            ms32U.IsChecked = false;

            ms40E.IsChecked = false;
            ms40J.IsChecked = false;
            ms40U.IsChecked = false;

            ms41E.IsChecked = false;
            ms41J.IsChecked = false;
            ms41U.IsChecked = false;

            ms42E.IsChecked = false;
            ms42J.IsChecked = false;
            ms42U.IsChecked = false;
            
            ms43E.IsChecked = false;
            ms43U.IsChecked = false;
            ms43J.IsChecked = false;
            ms43K.IsChecked = false;
        }

        private void ReportProgress(int progressPercentage, string statusText)
        {
            ActionBar.ProgressTextFormat = statusText;
            ActionBar.Value = progressPercentage;
        }

        private async Task AddEntries()
        {
            List<string> entriesList = new List<string>();
            try
            {
                for (int i = 0; i < ini.Entries.Length; i++)
                {
                    ReportProgress((i + 1) * 100 / ini.Entries.Length, "Loading entries...");
                    entriesList.Add(ini.Entries[i].entry);
                }

                lbxIniEntries.ItemsSource = entriesList;

                ReportProgress(100, "Entries from mym have been loaded.");
                SetControls(true);
            }
            catch (Exception ex)
            {
                await MessageBoxHelper.DisplayErrorMessage(ex.Message);
            }
        }
        
        private void SwapEntries(int selectedIndex, bool up)
        {
            if (selectedIndex > -1)
            {
                int bIndex = up ? selectedIndex - 1 : selectedIndex + 1;

                if (bIndex > -1 && bIndex < lbxIniEntries.Items.Count)
                {
                    SaveSelected();
                    //TODO: Yet another scuffed thing...
                    var list = lbxIniEntries.ItemsSource!.Cast<string>().ToList();
                    var selectedObject = list[selectedIndex];
                    list[selectedIndex] = list[bIndex];
                    list[bIndex] = selectedObject!;

                    lbxIniEntries.ItemsSource = list;
                    lbxIniEntries.SelectedIndex = bIndex;
                }
            }
            
        }

        private void SaveSelected()
        {
            if (lbxIniEntries.SelectedIndex == -1) return;

            iniEntry tempEntry = ini.GetEntry(lbxIniEntries.Items[lbxIniEntries.SelectedIndex].ToString());

            if (tempEntry.entryType == iniEntry.EntryType.Container)
            {
                tempEntry.file = tbContainerFile.Text.StartsWith("\\")
                    ? tbContainerFile.Text :
                    tbContainerFile.Text.Insert(0, "\\");
                tempEntry.type = cmbContainerFormat.SelectedIndex == 0 ? 
                    iniEntry.ContainerType.ASH : 
                    iniEntry.ContainerType.U8;
            }
            else if (tempEntry.entryType == iniEntry.EntryType.CustomImage)
            {
                tempEntry.file = (tbCustomImageFile.Text.StartsWith("\\")) ? tbCustomImageFile.Text : tbCustomImageFile.Text.Insert(0, "\\");
                tempEntry.name = tbCustomImageName.Text;
                if (ImageSizeFromTpl.IsChecked)
                {
                    tempEntry.width = int.Parse(tbCustomImageWidth.Text);
                    tempEntry.height = int.Parse(tbCustomImageHeight.Text);
                } 

                if (cmbCustomImageFormat.SelectedIndex == 0) 
                    tempEntry.format = iniEntry.TplFormat.RGB5A3;
                else if (cmbCustomImageFormat.SelectedIndex == 1) 
                    tempEntry.format = iniEntry.TplFormat.RGBA8;
                else if (cmbCustomImageFormat.SelectedIndex == 2)
                    tempEntry.format = iniEntry.TplFormat.RGB565;
                else if (cmbCustomImageFormat.SelectedIndex == 3) 
                    tempEntry.format = iniEntry.TplFormat.I4;
                else if (cmbCustomImageFormat.SelectedIndex == 4) 
                    tempEntry.format = iniEntry.TplFormat.I8;
                else if (cmbCustomImageFormat.SelectedIndex == 5) 
                    tempEntry.format = iniEntry.TplFormat.IA4;
                else if (cmbCustomImageFormat.SelectedIndex == 6) 
                    tempEntry.format = iniEntry.TplFormat.IA8;

            }
            else if (tempEntry.entryType == iniEntry.EntryType.StaticImage)
            {
                tempEntry.file = tbStaticImageFile.Text.StartsWith("\\") ? tbStaticImageFile.Text : tbStaticImageFile.Text.Insert(0, "\\");
                
                if (SourceManage.IsChecked) 
                    tempEntry.source = tbStaticImageSource.Text.StartsWith("\\") ? tbStaticImageSource.Text : tbStaticImageSource.Text.Insert(0, "\\");
                if (!ImageSizeFromTpl.IsChecked)
                {
                    tempEntry.width = int.Parse(tbStaticImageWidth.Text);
                    tempEntry.height = int.Parse(tbStaticImageHeight.Text);

                }

                if (cmbStaticImageFormat.SelectedIndex == 0) 
                    tempEntry.format = iniEntry.TplFormat.RGB5A3;
                else if (cmbStaticImageFormat.SelectedIndex == 1)
                    tempEntry.format = iniEntry.TplFormat.RGBA8;
                else if (cmbStaticImageFormat.SelectedIndex == 2) 
                    tempEntry.format = iniEntry.TplFormat.RGB565;
                else if (cmbStaticImageFormat.SelectedIndex == 3) 
                    tempEntry.format = iniEntry.TplFormat.I4;
                else if (cmbStaticImageFormat.SelectedIndex == 4) 
                    tempEntry.format = iniEntry.TplFormat.I8;
                else if (cmbStaticImageFormat.SelectedIndex == 5) 
                    tempEntry.format = iniEntry.TplFormat.IA4;
                else if (cmbStaticImageFormat.SelectedIndex == 6) 
                    tempEntry.format = iniEntry.TplFormat.IA8;

                tempEntry.filepath = tbStaticImageFilepath.Text;
            }
            else if (tempEntry.entryType == iniEntry.EntryType.CustomData)
            {
                tempEntry.file = tbCustomDataFile.Text.StartsWith("\\") ? tbCustomDataFile.Text : tbCustomDataFile.Text.Insert(0, "\\");
                tempEntry.name = tbCustomDataName.Text;
            }
            else if (tempEntry.entryType == iniEntry.EntryType.StaticData)
            {
                tempEntry.file = tbStaticDataFile.Text.StartsWith("\\") ? tbStaticDataFile.Text : tbStaticDataFile.Text.Insert(0, "\\");
                if (!SourceManage.IsChecked) 
                    tempEntry.source = (tbStaticDataSource.Text.StartsWith("\\")) ? tbStaticDataSource.Text : tbStaticDataSource.Text.Insert(0, "\\");

                tempEntry.filepath = tbStaticDataFilepath.Text;
            }

            ini.EditEntry(tempEntry);
        }

        private void SaveLastSelected()
        {
            if (lastSelected > -1 && lastSelected < lbxIniEntries.Items.Count && lbxIniEntries.Items[lastSelected].ToString() == lastSelectedEntry)
            {
                iniEntry tempEntry = ini.GetEntry(lbxIniEntries.Items[lastSelected].ToString());

                if (tempEntry.entryType == iniEntry.EntryType.Container)
                {
                    tempEntry.file = (tbContainerFile.Text?.StartsWith("\\") ?? false) ? tbContainerFile.Text : tbContainerFile.Text?.Insert(0, "\\") ?? "";
                    tempEntry.type = (cmbContainerFormat.SelectedIndex == 0) ? iniEntry.ContainerType.ASH : iniEntry.ContainerType.U8;
                }
                else if (tempEntry.entryType == iniEntry.EntryType.CustomImage)
                {
                    tempEntry.file = (tbCustomImageFile.Text?.StartsWith("\\") ?? false) ? tbCustomImageFile.Text : tbCustomImageFile.Text?.Insert(0, "\\") ?? "";
                    tempEntry.name = tbCustomImageName.Text;
                    if (ImageSizeFromTpl.IsChecked)
                    {
                        tempEntry.width = int.Parse(tbCustomImageWidth.Text);
                        tempEntry.height = int.Parse(tbCustomImageHeight.Text);
                    }

                    if (cmbCustomImageFormat.SelectedIndex == 0) 
                        tempEntry.format = iniEntry.TplFormat.RGB5A3;
                    else if (cmbCustomImageFormat.SelectedIndex == 1) 
                        tempEntry.format = iniEntry.TplFormat.RGBA8;
                    else if (cmbCustomImageFormat.SelectedIndex == 2) 
                        tempEntry.format = iniEntry.TplFormat.RGB565;
                    else if (cmbCustomImageFormat.SelectedIndex == 3) 
                        tempEntry.format = iniEntry.TplFormat.I4;
                    else if (cmbCustomImageFormat.SelectedIndex == 4) 
                        tempEntry.format = iniEntry.TplFormat.I8;
                    else if (cmbCustomImageFormat.SelectedIndex == 5) 
                        tempEntry.format = iniEntry.TplFormat.IA4;
                    else if (cmbCustomImageFormat.SelectedIndex == 6) 
                        tempEntry.format = iniEntry.TplFormat.IA8;
                }
                else if (tempEntry.entryType == iniEntry.EntryType.StaticImage)
                {
                    tempEntry.file = tbStaticImageFile.Text?.StartsWith("\\") ?? false ? tbStaticImageFile.Text : tbStaticImageFile.Text?.Insert(0, "\\") ?? "";
                    if (!SourceManage.IsChecked) 
                        tempEntry.source = tbStaticImageSource.Text?.StartsWith("\\") ?? false ? tbStaticImageSource.Text : tbStaticImageSource.Text?.Insert(0, "\\") ?? "";
                    if (!ImageSizeFromTpl.IsChecked)
                    {
                        tempEntry.width = int.Parse(tbStaticImageWidth.Text);
                        tempEntry.height = int.Parse(tbStaticImageHeight.Text);
                    }

                    if (cmbStaticImageFormat.SelectedIndex == 0) 
                        tempEntry.format = iniEntry.TplFormat.RGB5A3;
                    else if (cmbStaticImageFormat.SelectedIndex == 1) 
                        tempEntry.format = iniEntry.TplFormat.RGBA8;
                    else if (cmbStaticImageFormat.SelectedIndex == 2) 
                        tempEntry.format = iniEntry.TplFormat.RGB565;
                    else if (cmbStaticImageFormat.SelectedIndex == 3) 
                        tempEntry.format = iniEntry.TplFormat.I4;
                    else if (cmbStaticImageFormat.SelectedIndex == 4) 
                        tempEntry.format = iniEntry.TplFormat.I8;
                    else if (cmbStaticImageFormat.SelectedIndex == 5) 
                        tempEntry.format = iniEntry.TplFormat.IA4;
                    else if (cmbStaticImageFormat.SelectedIndex == 6) 
                        tempEntry.format = iniEntry.TplFormat.IA8;

                    tempEntry.filepath = tbStaticImageFilepath.Text;
                }
                else if (tempEntry.entryType == iniEntry.EntryType.CustomData)
                {
                    tempEntry.file = tbCustomDataFile.Text?.StartsWith("\\") ?? false ? tbCustomDataFile.Text : tbCustomDataFile.Text?.Insert(0, "\\") ?? "";
                    tempEntry.name = tbCustomDataName.Text;
                }
                else if (tempEntry.entryType == iniEntry.EntryType.StaticData)
                {
                    tempEntry.file = tbStaticDataFile.Text?.StartsWith("\\") ?? false ? tbStaticDataFile.Text : tbStaticDataFile.Text?.Insert(0, "\\") ?? "";
                    if (!SourceManage.IsChecked)
                        tempEntry.source = tbStaticDataSource.Text?.StartsWith("\\") ?? false ? tbStaticDataSource.Text : tbStaticDataSource.Text?.Insert(0, "\\") ?? "";

                    tempEntry.filepath = tbStaticDataFilepath.Text;
                }

                ini.EditEntry(tempEntry);
            }
        }

        private void AddEntry(iniEntry.EntryType entryType)
        {
            int newIndex = GetLastEntryNum(entryType) + 1;
            
            string type = "[cont";
            if (entryType == iniEntry.EntryType.CustomImage) 
                type = "[cimg";
            else if (entryType == iniEntry.EntryType.StaticImage) 
                type = "[simg";
            else if (entryType == iniEntry.EntryType.CustomData) 
                type = "[cdta";
            else if (entryType == iniEntry.EntryType.StaticData)
                type = "[sdta";

            iniEntry newEntry = new iniEntry();
            newEntry.entryType = entryType;
            newEntry.entry = type + newIndex + "]";
            newEntry.format = iniEntry.TplFormat.RGB5A3;

            ini.EntryList.Add(newEntry);
            
            //TODO:  Scuffed.  Is there a way to do this without essentially remaking the entire thing?
            var list = lbxIniEntries.ItemsSource?.Cast<string>().ToList() ?? [];
            list.Add(newEntry.entry);
            lbxIniEntries.ItemsSource = list;
            lbxIniEntries.SelectedIndex = list.Count - 1;
        }

        private int GetLastEntryNum(iniEntry.EntryType entryType)
        {
            int highestIndex = 0;

            string type = "[cont";
            if (entryType == iniEntry.EntryType.CustomImage) type = "[cimg";
            else if (entryType == iniEntry.EntryType.StaticImage) type = "[simg";
            else if (entryType == iniEntry.EntryType.CustomData) type = "[cdta";
            else if (entryType == iniEntry.EntryType.StaticData) type = "[sdta";

            foreach (iniEntry entry in ini.EntryList)
            {
                if (entry.entryType == entryType)
                {
                    int newIndex = int.Parse(entry.entry.Replace(type, "").Replace("]", ""));
                    if (newIndex > highestIndex) highestIndex = newIndex;
                }
            }

            return highestIndex;
        }

        private async void CreateCsm(string appFile, string nandBackupAppPath)
        {
            SaveSelected();
            
            if (string.IsNullOrEmpty(nandBackupAppPath))
            {
                var fileStorage = StorageProvider;
                var result = await fileStorage.SaveFilePickerAsync(new FilePickerSaveOptions()
                {
                    DefaultExtension = "csm",
                    FileTypeChoices = [new FilePickerFileType("csm")
                    {
                        Patterns = ["*.csm"]
                    }],
                    SuggestedFileName = !string.IsNullOrEmpty(openedMym) ? openedMym : string.Empty
                });

                if (result == null)
                    return;
                
                ReportProgress(0, "Collecting data...");

                var cInfo = new CreationInfo()
                {
                    savePath = result.Name,
                    lbEntries = lbxIniEntries.Items.Select(entry => entry!).ToArray(),
                    createCsm = true,
                    appFile = appFile,
                    closeAfter = false
                };
                await _saveMym(cInfo);
            }
            else
            {
                ReportProgress(0, "Collecting data...");

                List<object> lbEntries = new List<object>();

                foreach (var entry in lbxIniEntries.Items)
                    lbEntries.Add(entry!);

                var cInfo = new CreationInfo()
                {
                    savePath = nandBackupAppPath,
                    lbEntries =  lbxIniEntries.Items.Select(entry => entry!).ToArray(),
                    createCsm = true,
                    appFile = appFile,
                    closeAfter = false
                };
                await _saveMym(cInfo);
            }
        }

        private async Task SaveMym(bool exitAfter)
        {
            if (lbxIniEntries.ItemsSource!.Cast<string>().ToList().Count > 0)
            {
                SaveSelected();
                
                var fileStorage = StorageProvider;
                var result = await fileStorage.SaveFilePickerAsync(new FilePickerSaveOptions()
                {
                    DefaultExtension = "mym",
                    FileTypeChoices = [new FilePickerFileType("mym")
                    {
                        Patterns = ["*.mym"]
                    }],
                    SuggestedFileName = !string.IsNullOrEmpty(openedMym) ? openedMym : ""
                });

                if (result == null)
                    return;
                
                ReportProgress(0, "Collecting data...");

                List<object> lbEntries = new List<object>();

                foreach (object entry in lbxIniEntries.Items)
                    lbEntries.Add(entry);

                CreationInfo cInfo = new CreationInfo();
                cInfo.savePath = result.Name;
                cInfo.lbEntries = lbEntries.ToArray();
                cInfo.createCsm = false;
                cInfo.closeAfter = exitAfter;

                await _saveMym(cInfo);
            }
            
        }

        private bool CheckEntry(iniEntry entry)
        {
            if (entry.entryType == iniEntry.EntryType.Container)
            {
                if (string.IsNullOrEmpty(entry.file) || entry.file.Length < 2)
                { 
                    if (!IgnoreMissing.IsChecked) 
                        MessageBoxHelper.DisplayErrorMessage($"Entry: {entry.entry}\nInvalid argument \"file\"..."); 
                    return false; 
                }
            }
            else if (entry.entryType == iniEntry.EntryType.CustomImage)
            {
                if (string.IsNullOrEmpty(entry.file) || entry.file.Length < 2)
                {
                    if (!IgnoreMissing.IsChecked) 
                        MessageBoxHelper.DisplayErrorMessage($"Entry: {entry.entry}\nInvalid argument \"file\"..."); 
                    return false;
                }

                if (string.IsNullOrEmpty(entry.name))
                {
                    if (!IgnoreMissing.IsChecked)
                        MessageBoxHelper.DisplayErrorMessage($"Entry: {entry.entry}\nInvalid argument \"name\"..."); 
                    return false;
                }
            }
            else if (entry.entryType == iniEntry.EntryType.StaticImage)
            {
                if (string.IsNullOrEmpty(entry.file) || entry.file.Length < 2)
                {
                    if (!IgnoreMissing.IsChecked)
                        MessageBoxHelper.DisplayErrorMessage($"Entry: {entry.entry}\nInvalid argument \"file\"..."); 
                    return false;
                }
                if (!SourceManage.IsChecked)
                {
                    if (string.IsNullOrEmpty(entry.source))
                    {
                        if (!IgnoreMissing.IsChecked) 
                            MessageBoxHelper.DisplayErrorMessage($"Entry: {entry.entry}\nInvalid argument \"source\"...");
                        return false;
                    }
                }

                if (!File.Exists(entry.filepath))
                {
                    if (!IgnoreMissing.IsChecked)
                        MessageBoxHelper.DisplayErrorMessage(
                            $"Entry: {entry.entry}\nFile not found...\n\n{entry.filepath}");
                    return false;
                }
            }
            else if (entry.entryType == iniEntry.EntryType.CustomData)
            {
                if (string.IsNullOrEmpty(entry.file) || entry.file.Length < 2)
                {
                    if (!IgnoreMissing.IsChecked)
                        MessageBoxHelper.DisplayErrorMessage($"Entry: {entry.entry}\nInvalid argument \"file\"..."); 
                    return false;
                }

                if (string.IsNullOrEmpty(entry.name))
                {
                    if (!IgnoreMissing.IsChecked)
                        MessageBoxHelper.DisplayErrorMessage($"Entry: {entry.entry}\nInvalid argument \"name\"..."); 
                    return false;
                }
            }
            else if (entry.entryType == iniEntry.EntryType.StaticData)
            {
                if (string.IsNullOrEmpty(entry.file) || entry.file.Length < 2)
                {
                    if (!IgnoreMissing.IsChecked) 
                        MessageBoxHelper.DisplayErrorMessage($"Entry: {entry.entry}\nInvalid argument \"file\"..."); 
                    return false;
                }
                if (!SourceManage.IsChecked)
                {
                    if (string.IsNullOrEmpty(entry.source))
                    { 
                        if (!SourceManage.IsChecked) 
                            MessageBoxHelper.DisplayErrorMessage($"Entry: {entry.entry}\nInvalid argument \"source\"...");
                        return false;
                        
                    }
                }

                if (!File.Exists(entry.filepath))
                {
                    if (!IgnoreMissing.IsChecked)
                        MessageBoxHelper.DisplayErrorMessage($"Entry: {entry.entry}\nFile not found...\n\n{entry.filepath}");
                    return false;
                }
            }

            return true;
        }

        private async Task RemoveEntry(int index)
        {
            if (index == -1 || (lbxIniEntries.SelectedItems?.Count ?? 0) - 1 < index)
                return; 
            
            try
            {
                //TODO:  Scuffed again....
                string entry = lbxIniEntries.Items[index].ToString();
                var list = lbxIniEntries.ItemsSource?.Cast<string>().ToList() ?? [];
                list.RemoveAt(index);
                lbxIniEntries.ItemsSource = list;
                
                ini.EntryList.Remove(ini.GetEntry(entry));

                if (lbxIniEntries.Items.Count > index)
                    lbxIniEntries.SelectedIndex = index;
                else
                    lbxIniEntries.SelectedIndex = index - 1;
            }
            catch
            {
                await MessageBoxHelper.DisplayErrorMessage("Unable to delete.  ");
            }
            
        }

        private void DeASH(iniEntry mymC, string appOut)
        {
            //TODO:  This is a major roadblock, ASH.exe relies on an actual exe.
            //I don't even like using this weird separate file.  We probably should see if we can implement this ourselves....
            var ashExePath = Path.Combine(Directory.GetCurrentDirectory(), "ASH.exe");
            ProcessStartInfo pInfo = new ProcessStartInfo(ashExePath, $"\"{Path.Combine(appOut, mymC.file)}\"")
            {
                UseShellExecute = false,
                CreateNoWindow = true
            };

            var p = Process.Start(pInfo);
            if (p == null)
                throw new Exception("Ash.exe did not start.  Aborting...");
            
            p.WaitForExit();
        }
        
        private void  DeASH(string path)
        {
            //TODO:  This is a major roadblock, ASH.exe relies on an actual exe.
            //I don't even like using this weird separate file.  We probably should see if we can implement this ourselves....
            var ashExePath = Path.Combine(Directory.GetCurrentDirectory(), "ASH.exe");
            ProcessStartInfo pInfo = new ProcessStartInfo(ashExePath, $"\"{path}\"")
            {
                UseShellExecute = false,
                CreateNoWindow = true
            };

            var p = Process.Start(pInfo);
            if (p == null)
                throw new Exception("Ash.exe did not start.  Aborting...");
            
            p.WaitForExit();
        }

        private Image ResizeImage(Image img, int x, int y)
        {
            return null;
            /*
            Image newimage = new Bitmap(x, y);
            using (Graphics gfx = Graphics.FromImage(newimage))
            {
                gfx.DrawImage(img, 0, 0, x, y);
            }
            return newimage;
            */
        }

        private bool HashCheck(byte[] newFile, byte[] tmdHash)
        {
            System.Security.Cryptography.SHA1 sha = System.Security.Cryptography.SHA1.Create();
            byte[] fileHash = sha.ComputeHash(newFile);

            return Wii.Tools.CompareByteArrays(fileHash, tmdHash);
        }

        private async Task<bool> CommonKeyCheck(Window currentWindow)
        {
            var commonKeyPath = Path.Combine(Directory.GetCurrentDirectory(), "common-key.bin");
            if (!File.Exists(commonKeyPath))
            {
                ThemeMii_ckInput ib = new ThemeMii_ckInput();
                ib.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                var result = await ib.ShowDialog<string>(currentWindow);
                
                if (!string.IsNullOrEmpty(result))
                {
                    Wii.Tools.CreateCommonKey(result, commonKeyPath);
                    return true;
                }
            }
            else
            {
                return true;
            }

            return false;
        }
        
        private BaseApp GetStandardBaseApp()
        {
            if (ms32E.IsChecked)
                return BaseApp.E32;
            if (ms32U.IsChecked)
                return BaseApp.U32;
            if (ms32J.IsChecked)
                return BaseApp.J32;
            if (ms40E.IsChecked)
                return BaseApp.E40;
            if (ms40U.IsChecked)
                return BaseApp.U40;
            if (ms40J.IsChecked)
                return BaseApp.J40;
            if (ms41E.IsChecked)
                return BaseApp.E41;
            if (ms41U.IsChecked)
                return BaseApp.U41;
            if (ms41J.IsChecked)
                return BaseApp.J41;
            if (ms42E.IsChecked)
                return BaseApp.E42;
            if (ms42U.IsChecked)
                return BaseApp.U42;
            if (ms42J.IsChecked)
                return BaseApp.J42;
            if(ms43J.IsChecked)
                return BaseApp.J43;
            if(ms43E.IsChecked)
                return BaseApp.E43;
            if(ms43U.IsChecked)
                return BaseApp.U43;

            return 0;
        }

        private bool EntryExists(iniEntry entry, List<string[]> list)
        {
            foreach (string[] array in list)
            {
                if (array[0] == entry.source)
                {
                    FileInfo fi = new FileInfo(entry.filepath);
                    if (fi.Length != int.Parse(array[1]))
                        return true;
                }
            }

            return false;
        }

        private async Task AppBrowse()
        {
            BaseApp standardApp = GetStandardBaseApp();
            if (standardApp == 0)
            {
                await MessageBoxHelper.DisplayErrorMessage("You have to choose a Standard System Menu!");
                return;
            }
            
            var browsePath = KeepExtractedApp.IsChecked
                ? Path.Combine(tempDir, "appBrowse")
                : Path.Combine(Directory.GetCurrentDirectory(), "ExtractedBaseApp");
            var altPath = KeepExtractedApp.IsChecked 
                ? Path.Combine(tempDir, "appBrowse") 
                : Path.Combine(Directory.GetCurrentDirectory(), "ExtractedBaseApp");

            if (standardApp != lastExtracted || !Directory.Exists(browsePath))
            {
                //Extract app
                if (!File.Exists(Path.Combine(Directory.GetCurrentDirectory(),((int)standardApp).ToString("x8") + ".app")))
                {
                    await MessageBoxHelper.DisplayErrorMessage("app file wasn't found!"); 
                    return;
                }

                if (Directory.Exists(browsePath)) 
                    Directory.Delete(browsePath, true);
                
                if (Directory.Exists(altPath)) 
                    Directory.Delete(altPath, true);

                await _extractAppForBrowsing(standardApp, browsePath);
            }
            else
                OpenAppBrowser(browsePath);
            
        }

        private async Task OpenAppBrowser(string browsePath)
        {

            if (!Directory.Exists(browsePath))
            {
                await MessageBoxHelper.DisplayErrorMessage("The browse path does not exist!");
                return;
            }

            /*
            ThemeMii_AppBrowse appBrowser = new ThemeMii_AppBrowse();
            appBrowser.RootPath = browsePath;
            appBrowser.ViewOnly = browseInfo.viewOnly;
            appBrowser.ContainerBrowse = browseInfo.containerBrowse;
            appBrowser.SelectedPath = browseInfo.selectedNode;
            appBrowser.OnlyTpls = browseInfo.onlyTpls;

            if (appBrowser.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (panStaticData.Visible) tbStaticDataFile.Text = appBrowser.SelectedPath;
                else if (panStaticImage.Visible)
                {
                    tbStaticImageFile.Text = appBrowser.SelectedPath;

                    if (settings.imageSizeFromTpl)
                    {
                        try
                        {
                            byte[] tempTpl = Wii.Tools.LoadFileToByteArray(appBrowser.FullPath, 0, 500);
                            tbStaticImageWidth.Text = Wii.TPL.GetTextureWidth(tempTpl).ToString();
                            tbStaticImageHeight.Text = Wii.TPL.GetTextureHeight(tempTpl).ToString();
                        }
                        catch { }
                    }
                }
                else if (panCustomData.Visible) tbCustomDataFile.Text = appBrowser.SelectedPath;
                else if (panCustomImage.Visible)
                {
                    tbCustomImageFile.Text = appBrowser.SelectedPath;

                    if (settings.imageSizeFromTpl)
                    {
                        try
                        {
                            byte[] tempTpl = Wii.Tools.LoadFileToByteArray(appBrowser.FullPath, 0, 500);
                            tbCustomImageWidth.Text = Wii.TPL.GetTextureWidth(tempTpl).ToString();
                            tbCustomImageHeight.Text = Wii.TPL.GetTextureHeight(tempTpl).ToString();
                        }
                        catch { }
                    }
                }
                else if (panContainer.Visible) tbContainerFile.Text = appBrowser.SelectedPath;
            }
            */
        }

        private bool StringExistsInStringArray(string theString, string[] theStringArray)
        {
            return Array.Exists(theStringArray, thisString => thisString.ToLower() == theString.ToLower());
        }

        private BaseApp GetBaseAppFromTitleVersion(int titleVersion)
        {
            switch (titleVersion)
            {
                case 288:
                    return BaseApp.J32;
                case 289:
                    return BaseApp.U32;
                case 290:
                    return BaseApp.E32;
                case 416:
                    return BaseApp.J40;
                case 417:
                    return BaseApp.U40;
                case 418:
                    return BaseApp.E40;
                case 448:
                    return BaseApp.J41;
                case 449:
                    return BaseApp.U41;
                case 450:
                    return BaseApp.E41;
                case 480:
                    return BaseApp.J42;
                case 481:
                    return BaseApp.U42;
                case 482:
                    return BaseApp.E42;
                default:
                    return (BaseApp)0;
            }
        }
    }
}

