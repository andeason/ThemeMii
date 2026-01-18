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
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Platform.Storage;
//using System.Windows.Forms;
using ICSharpCode.SharpZipLib.Zip;
using MsBox.Avalonia;
using MsBox.Avalonia.Enums;
using ThemeMii.Extractors;


namespace ThemeMii
{
    public partial class ThemeMii_CsmToMym : Window
    {
        public string tempDir;
        private string saveFile;
        private bool intensiveAlgorithm = false;

        public ThemeMii_CsmToMym()
        {
            InitializeComponent();
        }

        private void ThemeMii_CsmToMym_Load(object? sender, RoutedEventArgs e)
        {
            //CenterToParent();
        }

        private async void btnCsmBrowse_Click(object? sender, RoutedEventArgs e)
        {
            if (pbProgress.Value == 0 || pbProgress.Value == 100)
            {
                var fileStorage = StorageProvider;
                var result = await fileStorage.OpenFilePickerAsync(new FilePickerOpenOptions
                {
                    FileTypeFilter =
                    [
                        new FilePickerFileType("csm files")
                        {
                            Patterns = ["*.csm"]
                        }
                    ]
                });

                CsmPath.Text = result.Count > 0 ? result[0].Path.AbsolutePath : string.Empty;

            }
        }

        private async void btnAppBrowse_Click(object? sender, RoutedEventArgs e)
        {
            if (pbProgress.Value == 0 || pbProgress.Value == 100)
            {
                var fileStorage = StorageProvider;
                var result = await fileStorage.OpenFilePickerAsync(new FilePickerOpenOptions
                {
                    FileTypeFilter =
                    [
                        new FilePickerFileType("app files")
                        {
                            Patterns = ["*.app"]
                        }
                    ]
                });

                AppPath.Text = result.Count > 0 ? result[0].Path.AbsolutePath : string.Empty;
            }
            
        }

        private async void btnConvert_Click(object? sender, RoutedEventArgs e)
        {
            
            if (File.Exists(CsmPath.Text) && File.Exists(AppPath.Text))
            {
                var fileStorage = StorageProvider;
                var result = await fileStorage.SaveFilePickerAsync(new FilePickerSaveOptions()
                    {
                        DefaultExtension = "mym",
                        FileTypeChoices = [new FilePickerFileType("mym")
                        {
                            Patterns = ["*.mym"]
                        }],
                        SuggestedFileName = Path.GetFileNameWithoutExtension(CsmPath.Text)
                    });

                if (result == null)
                    return;
                
                saveFile = result.Name;
                pbProgress.Value = 0;
                ConvertButton.IsVisible = false;
                intensiveAlgorithm = IntensiveAlgorithm.IsChecked ?? false;

                await _convertCsm();
            }
            else
            {
                await MessageBoxHelper.DisplayErrorMessage("Please give a valid path for the App/CSM path before running.");
            }
            
        }

        private async Task _convertCsm()
        {
            string appDir = tempDir + "\\appOut\\";
            string csmDir = tempDir + "\\csmOut\\";
            string mymDir = tempDir + "\\mymOut\\";

            if (Directory.Exists(appDir)) Directory.Delete(appDir, true);
            if (Directory.Exists(csmDir)) Directory.Delete(csmDir, true);
            if (Directory.Exists(mymDir)) Directory.Delete(mymDir, true);

            List<iniEntry> entryList = new List<iniEntry>();

            if (CsmPath.Text == null || AppPath.Text == null)
                throw new Exception("App/Csm path are empty!");
            
            await U8Extractor.UnpackU8(CsmPath.Text, csmDir);
            await U8Extractor.UnpackU8(AppPath.Text, appDir);

            string[] csmFiles = Directory.GetFiles(csmDir, "*", SearchOption.AllDirectories);

            if (intensiveAlgorithm)
            {
                for (int i = 0; i < csmFiles.Length; i++)
                {
                    ReportProgress((i * 100 / csmFiles.Length) / 2);

                    byte[] temp = Wii.Tools.LoadFileToByteArray(csmFiles[i], 0, 4);
                    if (temp[0] == 'Y' && temp[1] == 'a' && temp[2] == 'z' && temp[3] == '0')
                        continue;

                    bool extracted = false;

                    while (!extracted)
                    {
                        byte[] fourBytes = Wii.Tools.LoadFileToByteArray(csmFiles[i].Replace(csmDir, appDir), 0, 4);

                        if (fourBytes[0] == 'A' && fourBytes[1] == 'S' &&
                                fourBytes[2] == 'H' && fourBytes[3] == '0') //ASH0
                        {
                            try
                            {
                                DeASH(csmFiles[i].Replace(csmDir, appDir));

                                File.Delete(csmFiles[i].Replace(csmDir, appDir));
                                FileInfo fi = new FileInfo(csmFiles[i].Replace(csmDir, appDir) + ".arc");
                                fi.MoveTo(csmFiles[i].Replace(csmDir, appDir));
                            }
                            catch (Exception ex)
                            {
                                await MessageBoxHelper.DisplayErrorMessage(ex.Message);
                                return;
                            }
                        }
                        else if (fourBytes[0] == 'L' && fourBytes[1] == 'Z' &&
                                fourBytes[2] == '7' && fourBytes[3] == '7') //Lz77
                        {
                            try
                            {
                                byte[] decompressedFile = Wii.Lz77.Decompress(File.ReadAllBytes(csmFiles[i].Replace(csmDir, appDir)), 0);

                                File.Delete(csmFiles[i].Replace(csmDir, appDir));
                                File.WriteAllBytes(csmFiles[i].Replace(csmDir, appDir), decompressedFile);
                            }
                            catch (Exception ex)
                            {
                                await MessageBoxHelper.DisplayErrorMessage(ex.Message);
                                return;
                            }
                        }
                        else if (fourBytes[0] == 'Y' && fourBytes[1] == 'a' &&
                                fourBytes[2] == 'z' && fourBytes[3] == '0') //Yaz0
                        {
                            //Nothing to do about yet...
                            break;
                        }
                        else if (fourBytes[0] == 0x55 && fourBytes[1] == 0xaa &&
                                fourBytes[2] == 0x38 && fourBytes[3] == 0x2d) //U8
                        {
                            try
                            {
                                await U8Extractor.UnpackU8(
                                    csmFiles[i].Replace(csmDir, appDir),
                                    $"{csmFiles[i].Replace(csmDir, appDir).Replace(".", "_")}_out");
                                File.Delete(csmFiles[i].Replace(csmDir, appDir));
                                extracted = true;
                            }
                            catch (Exception ex)
                            {
                                await MessageBoxHelper.DisplayErrorMessage(ex.Message);
                                return;
                            }
                        }
                        else break;
                    }

                    extracted = false;

                    while (!extracted)
                    {
                        byte[] fourBytes = Wii.Tools.LoadFileToByteArray(csmFiles[i], 0, 4);

                        if (fourBytes[0] == 'A' && fourBytes[1] == 'S' &&
                                fourBytes[2] == 'H' && fourBytes[3] == '0') //ASH0
                        {
                            try
                            {
                                DeASH(csmFiles[i]);

                                File.Delete(csmFiles[i]);
                                FileInfo fi = new FileInfo(csmFiles[i] + ".arc");
                                fi.MoveTo(csmFiles[i]);
                            }
                            catch (Exception ex)
                            {
                                await MessageBoxHelper.DisplayErrorMessage(ex.Message);
                                return;
                            }
                        }
                        else if (fourBytes[0] == 'L' && fourBytes[1] == 'Z' &&
                                fourBytes[2] == '7' && fourBytes[3] == '7') //Lz77
                        {
                            try
                            {
                                byte[] decompressedFile = Wii.Lz77.Decompress(File.ReadAllBytes(csmFiles[i]), 0);

                                File.Delete(csmFiles[i]);
                                File.WriteAllBytes(csmFiles[i], decompressedFile);
                            }
                            catch (Exception ex)
                            {
                                await MessageBoxHelper.DisplayErrorMessage(ex.Message);
                                return;
                            }
                        }
                        else if (fourBytes[0] == 'Y' && fourBytes[1] == 'a' &&
                                fourBytes[2] == 'z' && fourBytes[3] == '0') //Yaz0
                        {
                            //Nothing to do about yet...
                            break;
                        }
                        else if (fourBytes[0] == 0x55 && fourBytes[1] == 0xaa &&
                                fourBytes[2] == 0x38 && fourBytes[3] == 0x2d) //U8
                        {
                            try
                            {
                                await U8Extractor.UnpackU8(csmFiles[i], 
                                    $"{csmFiles[i].Replace(".", "_")}_out");
                                File.Delete(csmFiles[i]);
                                extracted = true;
                            }
                            catch (Exception ex)
                            {
                                await MessageBoxHelper.DisplayErrorMessage(ex.Message);
                                return;
                            }
                        }
                        else break;
                    }
                }

                csmFiles = Directory.GetFiles(csmDir, "*", SearchOption.AllDirectories);
            }

            for (int i = 0; i < csmFiles.Length; i++)
            {
                ReportProgress(((i * 100 / csmFiles.Length) / (intensiveAlgorithm ? 2 : 1)) + (intensiveAlgorithm ? 50 : 0));

                if (File.Exists(csmFiles[i].Replace(csmDir, appDir)))
                {
                    //File exists in original app
                    FileInfo fi = new FileInfo(csmFiles[i]);
                    FileInfo fi2 = new FileInfo(csmFiles[i].Replace(csmDir, appDir));

                    if (fi.Length == fi2.Length) //Same file
                        continue;
                }

                iniEntry tempEntry = new iniEntry();
                tempEntry.entryType = iniEntry.EntryType.StaticData;
                tempEntry.file = csmFiles[i].Replace(csmDir, string.Empty);
                if (!tempEntry.file.StartsWith("\\")) tempEntry.file = tempEntry.file.Insert(0, "\\");

                if (!Directory.Exists(Path.GetDirectoryName(mymDir + Path.GetExtension(csmFiles[i]).Remove(0, 1) + "\\" + Path.GetFileName(csmFiles[i]))))
                    Directory.CreateDirectory(Path.GetDirectoryName(mymDir + Path.GetExtension(csmFiles[i]).Remove(0, 1) + "\\" + Path.GetFileName(csmFiles[i])));

                string destFile = mymDir + Path.GetExtension(csmFiles[i]).Remove(0, 1) + "\\" + Path.GetFileName(csmFiles[i]);

                int counter = 0;
                FileInfo fi1 = new FileInfo(csmFiles[i]);
                string tempFile = destFile;

                while (File.Exists(destFile))
                {
                    FileInfo fi2 = new FileInfo(destFile);
                    if (fi1.Length == fi2.Length) break;

                    destFile = tempFile.Replace(Path.GetExtension(tempFile), (++counter).ToString() + Path.GetExtension(tempFile));
                }

                File.Copy(csmFiles[i], destFile, true);
                tempEntry.source = "\\" + Path.GetExtension(destFile).Remove(0, 1) + "\\" + Path.GetFileName(destFile);
                entryList.Add(tempEntry);
            }

            //---

            List<string> containersToManage = new List<string>();
            List<string> managedContainers = new List<string>();

            foreach (iniEntry tempEntry in entryList)
            {
                if (tempEntry.entryType == iniEntry.EntryType.Container)
                    managedContainers.Add(tempEntry.file);
                else
                {
                    if (tempEntry.file.Contains("_out"))
                    {
                        string tmpString = tempEntry.file.Remove(tempEntry.file.IndexOf("_out"));
                        tmpString = tmpString.Substring(0, tmpString.Length - 5) + tmpString.Substring(tmpString.Length - 5).Replace("_", ".");

                        if (!StringExistsInStringArray(tmpString, containersToManage.ToArray()))
                            containersToManage.Add(tmpString);
                    }
                }
            }

            List<string> leftContainers = new List<string>();

            foreach (string thisContainer in containersToManage)
            {
                if (!StringExistsInStringArray(thisContainer, managedContainers.ToArray()))
                    leftContainers.Add(thisContainer);
            }

            if (leftContainers.Count > 0)
            {
                List<iniEntry> newList = new List<iniEntry>();

                foreach (string thisContainer in leftContainers)
                {
                    iniEntry tempEntry = new iniEntry();
                    tempEntry.entryType = iniEntry.EntryType.Container;
                    tempEntry.file = thisContainer;
                    tempEntry.type = iniEntry.ContainerType.ASH;

                    newList.Add(tempEntry);
                }

                newList.AddRange(entryList);
                entryList = newList;
            }

            //---

            mymini ini = mymini.CreateIni(entryList.ToArray());
            ini.Save(mymDir + "mym.ini");

            FastZip fZip = new FastZip();
            fZip.CreateZip(saveFile, mymDir, true, "");

            if (Directory.Exists(appDir)) Directory.Delete(appDir, true);
            if (Directory.Exists(csmDir)) Directory.Delete(csmDir, true);
            if (Directory.Exists(mymDir)) Directory.Delete(mymDir, true);

            ReportProgress(100);
            await MessageBoxHelper.DisplayInfoBox("Saved mym to:\n" + saveFile);
        }

        //This also just appears to be duplicated?
        private void DeASH(string file)
        {
            //TODO:  This is a major roadblock, ASH.exe relies on an actual exe.
            //I don't even like using this weird separate file.  We probably should see if we can implement this ourselves....
            var ashExePath = Path.Combine(Directory.GetCurrentDirectory(), "ASH.exe");
            ProcessStartInfo pInfo = new ProcessStartInfo(ashExePath, $"\"{file}\"")
            {
                UseShellExecute = false,
                CreateNoWindow = true
            };

            var p = Process.Start(pInfo);
            if (p == null)
                throw new Exception("Ash.exe did not start.  Aborting...");
            
            p.WaitForExit();
        }

        private bool StringExistsInStringArray(string theString, string[] theStringArray)
        {
            return Array.Exists(theStringArray, thisString => thisString.ToLower() == theString.ToLower());
        }

        private void ReportProgress(int progressPercentage)
        {
            pbProgress.Value = progressPercentage;
            if (pbProgress.Value == 100 || pbProgress.Value == 0)
                ConvertButton.IsVisible = true;
        }
    }
}
