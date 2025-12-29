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
//using System.Windows.Forms;
using ICSharpCode.SharpZipLib.Zip;
using System.IO;
using System.Drawing;
using System.Net;
using System.Threading.Tasks;

namespace ThemeMii
{
    partial class ThemeMii_Main
    {
        /*
        private void _updateCheck()
        {
            if (CheckInet() == true)
            {
                try
                {
                    WebClient GetVersion = new WebClient();
                    string NewVersion = GetVersion.DownloadString("http://thememii.googlecode.com/svn/version.txt");

                    int newVersion = Convert.ToInt32(NewVersion.Replace(".", string.Empty).Length == 2 ? (NewVersion.Replace(".", string.Empty) + "0") : NewVersion.Replace(".", string.Empty));
                    int thisVersion = Convert.ToInt32(version.Replace(".", string.Empty).Length == 2 ? (version.Replace(".", string.Empty) + "0") : version.Replace(".", string.Empty));

                    if (newVersion > thisVersion)
                    {
                        if (MessageBox.Show("Version " + NewVersion +
                            " is available.\nDo you want the download page to be opened?",
                            "Update available", MessageBoxButtons.YesNo, MessageBoxIcon.Information) ==
                            DialogResult.Yes)
                        {
                            System.Diagnostics.Process.Start("http://code.google.com/p/thememii/downloads/list");
                        }
                    }
                }
                catch
                { }
            }
        }

        private void _extractAppForBrowsing(object infos)
        {
            BaseApp standardApp = (BaseApp)(((object[])infos)[0]);
            string browsePath = (string)(((object[])infos)[1]);

            Directory.CreateDirectory(browsePath);

            Wii.U8.UnpackU8(Application.StartupPath + "\\" + ((int)standardApp).ToString("x8") + ".app", browsePath);

            string[] allFiles = Directory.GetFiles(browsePath, "*", SearchOption.AllDirectories);
            int counter = 0;

            foreach (string thisFile in allFiles)
            {
                ReportProgress(++counter * 100 / allFiles.Length, "Extracting App...");

                bool extracted = false;

                while (!extracted)
                {
                    byte[] fourBytes = Wii.Tools.LoadFileToByteArray(thisFile, 0, 4);

                    if (fourBytes[0] == 'A' && fourBytes[1] == 'S' &&
                            fourBytes[2] == 'H' && fourBytes[3] == '0') //ASH0
                    {
                        try
                        {
                            DeASH(thisFile);

                            File.Delete(thisFile);
                            FileInfo fi = new FileInfo(thisFile + ".arc");
                            fi.MoveTo(thisFile);
                        }
                        catch (Exception ex)
                        {
                            SetControls(true);
                            ErrorBox(ex.Message);
                            return;
                        }
                    }
                    else if (fourBytes[0] == 'L' && fourBytes[1] == 'Z' &&
                            fourBytes[2] == '7' && fourBytes[3] == '7') //Lz77
                    {
                        try
                        {
                            byte[] decompressedFile = Wii.Lz77.Decompress(File.ReadAllBytes(thisFile), 0);

                            File.Delete(thisFile);
                            File.WriteAllBytes(thisFile, decompressedFile);
                        }
                        catch (Exception ex)
                        {
                            SetControls(true);
                            ErrorBox(ex.Message);
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
                            Wii.U8.UnpackU8(thisFile, Path.GetDirectoryName(thisFile) + "\\" + Path.GetFileName(thisFile).Replace(".", "_") + "_out");
                            extracted = true;
                        }
                        catch (Exception ex)
                        {
                            SetControls(true);
                            ErrorBox(ex.Message);
                            return;
                        }
                    }
                    else break;
                }
            }

            lastExtracted = standardApp;
            ReportProgress(100, " ");

            boxInvoker b = new boxInvoker(this.OpenAppBrowser);
            this.Invoke(b, browsePath);
        }

        */
        private async Task DownloadBaseApp(string fileName, string titleVersion, string destinationName)
        {
            const string nusUrl = "http://nus.cdn.shop.wii.com/ccs/download";
            var nusTempDir = Path.Combine(tempDir, "nusTemp");
            const string titleId = "0000000100000002";

            //Grab cetk + appfile
            Directory.CreateDirectory(nusTempDir);
            WebClient wcDownload = new WebClient();

            ReportProgress(0, "Grabbing Ticket...");
            try { wcDownload.DownloadFile($"{nusUrl}/{titleId}/cetk", Path.Combine(nusTempDir,"cetk")); }
            catch (Exception ex)
            {
                Directory.Delete(nusTempDir, true);
                ErrorBox("Downloading Failed...\n" + ex.Message);
                ReportProgress(100, " ");
                return;
            }

            ReportProgress(10, "Grabbing Tmd...");
            try { wcDownload.DownloadFile($"{nusUrl}/{titleId}/tmd.{titleVersion}", Path.Combine(nusTempDir,"tmd")); }
            catch (Exception ex)
            {
                Directory.Delete(nusTempDir, true);
                ErrorBox("Downloading Failed...\n" + ex.Message);
                ReportProgress(100, " ");
                return;
            }

            ReportProgress(20, "Grabbing Content...");
            try { wcDownload.DownloadFile($"{nusUrl}/{titleId}/{fileName}", Path.Combine(nusTempDir,fileName)); }
            catch (Exception ex)
            {
                Directory.Delete(nusTempDir, true);
                ErrorBox("Downloading Failed...\n" + ex.Message);
                ReportProgress(100, " ");
                return;
            }

            //Gather information
            ReportProgress(80, "Gathering Data...");
            var encTitleKey = Wii.Tools.GetPartOfByteArray(File.ReadAllBytes(Path.Combine(nusTempDir,"cetk")), 447, 16);
            var decTitleKey = Wii.WadEdit.GetTitleKey(encTitleKey, Wii.Tools.HexStringToByteArray(titleId));

            var contentIndex = -1;
            var contInfo = Wii.WadInfo.GetContentInfo(File.ReadAllBytes(Path.Combine(nusTempDir,"tmd")));
            for (int i = 0; i < contInfo.GetLength(0); i++)
            {
                if (contInfo[i, 0] == fileName) { contentIndex = i; break; }
            }

            var tmdHash = Wii.Tools.HexStringToByteArray(contInfo[contentIndex, 4]);

            //Decrypt appfile
            ReportProgress(85, "Decrypting Content...");
            var decContent = Wii.WadEdit.DecryptContent(
                File.ReadAllBytes(Path.Combine(nusTempDir,fileName)), File.ReadAllBytes(Path.Combine(nusTempDir,"tmd")), contentIndex, decTitleKey);

            Array.Resize(ref decContent, int.Parse(contInfo[contentIndex, 3]));

            //Check SHA1
            ReportProgress(98, "Hash Check...");

            if (!HashCheck(decContent, tmdHash))
            {
                Directory.Delete(nusTempDir, true);
                ErrorBox("Hash check failed!");
                ReportProgress(100, " ");
                return;
            }

            File.WriteAllBytes(destinationName, decContent);

            //Delete Temps
            Directory.Delete(nusTempDir, true);

            ReportProgress(100, $"Downloaded base app to:\n{destinationName}");
            InfoBox($"Downloaded base app to:\n{destinationName}");
        }
        
        /*

        private void _createCsm(string savePath, string appPath, string mymPath)
        {
            ReportProgress(0, "Unpacking base app...");

            tempDir = Path.GetTempPath() + Guid.NewGuid().ToString() + "\\";
            string appOut = tempDir + "appOut\\";
            string mymOut = tempDir + "mymOut\\";
            List<iniEntry> editedContainers = new List<iniEntry>();
            Directory.CreateDirectory(appOut);
            int counter = 1;

            //Unpack .app
            try
            {
                Wii.U8.UnpackU8(File.ReadAllBytes(appPath), appOut);
            }
            catch (Exception ex) { SetControls(true); ErrorBox(ex.Message); return; }

            //Unpack .mym
            try
            {
                FastZip zFile = new FastZip();
                zFile.ExtractZip(mymPath, mymOut, "");
            }
            catch (Exception ex) { SetControls(true); ErrorBox(ex.Message); return; }

            //Parse ini
            if (!File.Exists(mymOut + "mym.ini")) { SetControls(true); ErrorBox("mym.ini wasn't found!"); return; }
            mymini ini = mymini.LoadIni(mymOut + "mym.ini");

            foreach (iniEntry tempEntry in ini.Entries)
            {
                ReportProgress(counter++ * 100 / ini.Entries.Length, "Parsing mym.ini...");

                if (tempEntry.entryType == iniEntry.EntryType.Container)
                {
                    if (!File.Exists(appOut + tempEntry.file))
                        continue;

                    bool extracted = false;

                    while (!extracted)
                    {
                        byte[] fourBytes = Wii.Tools.LoadFileToByteArray(appOut + tempEntry.file, 0, 4);

                        if (fourBytes[0] == 'A' && fourBytes[1] == 'S' &&
                                fourBytes[2] == 'H' && fourBytes[3] == '0') //ASH0
                        {
                            try
                            {
                                DeASH(tempEntry, appOut);

                                File.Delete(appOut + tempEntry.file);
                                FileInfo fi = new FileInfo(appOut + tempEntry.file + ".arc");
                                fi.MoveTo(appOut + tempEntry.file);
                            }
                            catch
                            {
                                SetControls(true);
                                ErrorBox("Entry: " + tempEntry.entry + "\n\nASH.exe returned an error!\nYou may try to decompress the ASH files manually...");
                                return;
                            }
                        }
                        else if (fourBytes[0] == 'L' && fourBytes[1] == 'Z' &&
                                fourBytes[2] == '7' && fourBytes[3] == '7') //Lz77
                        {
                            try
                            {
                                byte[] decompressedFile = Wii.Lz77.Decompress(File.ReadAllBytes(appOut + tempEntry.file), 0);

                                File.Delete(appOut + tempEntry.file);
                                File.WriteAllBytes(appOut + tempEntry.file, decompressedFile);
                            }
                            catch (Exception ex)
                            {
                                SetControls(true);
                                ErrorBox("Entry: " + tempEntry.entry + "\n\n" + ex.Message);
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
                                Wii.U8.UnpackU8(appOut + tempEntry.file, appOut + tempEntry.file.Replace('.', '_') + "_out");
                                File.Delete(appOut + tempEntry.file);
                                extracted = true;
                            }
                            catch (Exception ex)
                            {
                                SetControls(true);
                                ErrorBox("Entry: " + tempEntry.entry + "\n\n" + ex.Message);
                                return;
                            }
                        }
                        else break;
                    }

                    editedContainers.Add(tempEntry);
                }
                else if (tempEntry.entryType == iniEntry.EntryType.CustomImage)
                {
                    try
                    {
                        if (File.Exists(appOut + tempEntry.file))
                        {
                            OpenFileDialog ofd = new OpenFileDialog();
                            ofd.Title = tempEntry.name;
                            ofd.Filter = "PNG|*.png";

                            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                            {
                                Image img = Image.FromFile(ofd.FileName);
                                img = ResizeImage(img, tempEntry.width, tempEntry.height);

                                if (File.Exists(appOut + tempEntry.file)) File.Delete(appOut + tempEntry.file);
                                Wii.TPL.ConvertToTPL(img, appOut + tempEntry.file, (int)tempEntry.format);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        SetControls(true);
                        ErrorBox("Entry: " + tempEntry.entry + "\n\n" + ex.Message);
                        return;
                    }
                }
                else if (tempEntry.entryType == iniEntry.EntryType.StaticImage)
                {
                    try
                    {
                        if (File.Exists(mymOut + tempEntry.source))
                        {
                            Image img = Image.FromFile(mymOut + tempEntry.source);
                            img = ResizeImage(img, tempEntry.width, tempEntry.height);

                            if (File.Exists(appOut + tempEntry.file)) File.Delete(appOut + tempEntry.file);
                            Wii.TPL.ConvertToTPL(img, appOut + tempEntry.file, (int)tempEntry.format);
                        }
                    }
                    catch (Exception ex)
                    {
                        SetControls(true);
                        ErrorBox("Entry: " + tempEntry.entry + "\n\n" + ex.Message);
                        return;
                    }
                }
                else if (tempEntry.entryType == iniEntry.EntryType.CustomData)
                {
                    try
                    {
                        if (File.Exists(appOut + tempEntry.file))
                        {
                            OpenFileDialog ofd = new OpenFileDialog();
                            ofd.FileName = tempEntry.name;

                            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                            {
                                File.Copy(ofd.FileName, appOut + tempEntry.file, true);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        SetControls(true);
                        ErrorBox("Entry: " + tempEntry.entry + "\n\n" + ex.Message);
                        return;
                    }
                }
                else if (tempEntry.entryType == iniEntry.EntryType.StaticData)
                {
                    try
                    {
                        if (File.Exists(mymOut + tempEntry.source))
                        {
                            File.Copy(mymOut + tempEntry.source, appOut + tempEntry.file, true);
                        }
                    }
                    catch (Exception ex)
                    {
                        SetControls(true);
                        ErrorBox("Entry: " + tempEntry.entry + "\n\n" + ex.Message);
                        return;
                    }
                }
            }

            //Repack Containers
            foreach (iniEntry tempEntry in editedContainers)
            {
                if (!settings.lz77Containers)
                {
                    Wii.U8.PackU8(appOut + tempEntry.file.Replace('.', '_') + "_out", appOut + tempEntry.file);
                }
                else
                {
                    byte[] u8Container = Wii.U8.PackU8(appOut + tempEntry.file.Replace('.', '_') + "_out");
                    Wii.Lz77.Compress(u8Container, appOut + tempEntry.file);

                }

                Directory.Delete(appOut + tempEntry.file.Replace('.', '_') + "_out", true);
            }

            //Repack app
            Wii.U8.PackU8(appOut, savePath);

            CsmFinish finish = new CsmFinish(this._csmFinish);
            this.Invoke(finish, savePath, mymPath);
        }

        private delegate void CsmFinish(string savePath, string mymPath);
        private void _csmFinish(string savePath, string mymPath)
        {
            if (MessageBox.Show("Saved csm to:\n" + savePath + "\n\nDo you want to save the mym file?", "Save mym?",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "mym|*.mym";

                if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    File.Copy(mymPath, sfd.FileName);

                InfoBox("Saved mym to:\n" + sfd.FileName);
            }

            ReportProgress(100, " ");
            SetControls(true);
        }

        private void _saveMym(object _creationInfo)
        {
            SetControls(false);
            CreationInfo cInfo = (CreationInfo)_creationInfo;
            string outDir = tempDir + "newMym\\";
            if (Directory.Exists(outDir)) Directory.Delete(outDir, true);
            Directory.CreateDirectory(outDir);

            int counter = 0;
            int[] counters = new int[5];

            //Build new ini
            List<iniEntry> tempEntries = new List<iniEntry>();
            List<string[]> dataSources = new List<string[]>();
            List<string[]> imageSources = new List<string[]>();

            foreach (object tempObject in cInfo.lbEntries)
            {
                ReportProgress(++counter * 100 / cInfo.lbEntries.Length, "Building mym.ini...");

                try
                {
                    iniEntry tempEntry = ini.GetEntry(tempObject.ToString());
                    if (!CheckEntry(tempEntry))
                    {
                        if (!settings.ignoreMissing) { ReportProgress(100, " "); SetControls(true); return; }
                        else continue;
                    }

                    if (settings.sourceManage)
                    {
                        //Manage source
                        if (tempEntry.entryType == iniEntry.EntryType.StaticData)
                        {
                            if (Path.HasExtension(tempEntry.filepath))
                            {
                                tempEntry.source = "\\" + Path.GetExtension(tempEntry.filepath).Remove(0, 1) + "\\" + Path.GetFileName(tempEntry.filepath);

                                string tempSource = "\\" + Path.GetExtension(tempEntry.filepath).Remove(0, 1) + "\\" + Path.GetFileName(tempEntry.filepath);
                                int i = 1;

                                while (EntryExists(tempEntry, dataSources))
                                {
                                    tempEntry.source = tempSource.Insert(tempSource.LastIndexOf('.'), (++i).ToString());
                                }

                                FileInfo fi = new FileInfo(tempEntry.filepath);
                                dataSources.Add(new string[] { tempEntry.source, fi.Length.ToString() });
                            }
                            else
                            {
                                tempEntry.source = "\\" + Path.GetFileName(tempEntry.filepath);

                                string tempSource = "\\" + "\\" + Path.GetFileName(tempEntry.filepath);
                                int i = 1;

                                while (EntryExists(tempEntry, dataSources))
                                {
                                    tempEntry.source = tempSource.Insert(tempSource.LastIndexOf('.'), (++i).ToString());
                                }

                                FileInfo fi = new FileInfo(tempEntry.filepath);
                                dataSources.Add(new string[] { tempEntry.source, fi.Length.ToString() });
                            }
                        }
                        else if (tempEntry.entryType == iniEntry.EntryType.StaticImage)
                        {
                            tempEntry.source = "\\images\\" + Path.GetFileName(tempEntry.filepath);

                            string tempSource = "\\images\\" + Path.GetFileName(tempEntry.filepath);
                            int i = 1;

                            while (EntryExists(tempEntry, imageSources))
                            {
                                tempEntry.source = tempSource.Insert(tempSource.LastIndexOf('.'), (++i).ToString());
                            }

                            FileInfo fi = new FileInfo(tempEntry.filepath);
                            imageSources.Add(new string[] { tempEntry.source, fi.Length.ToString() });
                        }
                    }
                    if (settings.autoImageSize)
                    {
                        if (tempEntry.entryType == iniEntry.EntryType.CustomImage ||
                            tempEntry.entryType == iniEntry.EntryType.StaticImage)
                        {
                            //Get png width and height
                            Image img = Image.FromFile(tempEntry.filepath);
                            tempEntry.width = img.Width;
                            tempEntry.height = img.Height;
                        }
                    }

                    tempEntries.Add(tempEntry);
                }
                catch { }
            }

            if (tempEntries.Count < 1)
            {
                ErrorBox("No entries left...");
                SetControls(true);
                return;
            }

            //Manage Containers
            if (settings.containerManage)
            {
                List<string> containersToManage = new List<string>();
                List<string> managedContainers = new List<string>();

                foreach (iniEntry tempEntry in tempEntries)
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

                    newList.AddRange(tempEntries);
                    tempEntries = newList;
                }
            }

            ini = new mymini();
            ini.EntryList = tempEntries;
            ini.Save(outDir + "mym.ini");
            counter = 0;

            //Copy files
            foreach (iniEntry tempEntry in ini.EntryList)
            {
                ReportProgress(++counter * 100 / ini.EntryList.Count, "Copying files...");

                if (tempEntry.entryType == iniEntry.EntryType.StaticImage ||
                    tempEntry.entryType == iniEntry.EntryType.StaticData)
                {
                    string sourceFile = tempEntry.filepath;
                    string destFile = outDir + tempEntry.source;

                    if (!Directory.Exists(Path.GetDirectoryName(destFile))) Directory.CreateDirectory(Path.GetDirectoryName(destFile));
                    File.Copy(sourceFile, destFile, true);
                }
            }

            //Zip file
            ReportProgress(0, "Packing mym...");
            ReportProgress(80, ""); // Fake, hm?!
            FastZip fZip = new FastZip();
            fZip.CreateZip((cInfo.createCsm) ? tempDir + "temp.mym" : cInfo.savePath, outDir, true, "");
            ReportProgress(100, " ");

            if (cInfo.closeAfter) { MethodInvoker m = new MethodInvoker(this.ExitApplication); this.Invoke(m); return; }
            if (!cInfo.createCsm) { InfoBox("Saved mym to:\n" + cInfo.savePath); SetControls(true); return; }

            _createCsm(cInfo.savePath, cInfo.appFile, tempDir + "temp.mym");
        }

        private void _loadMym(object mymFile)
        {
            //Unzip mym file
            try
            {
                ReportProgress(0, "Unpacking mym...");
                FastZip fZip = new FastZip();
                fZip.ExtractZip((string)mymFile, mymOut, "");
                ReportProgress(100, " ");
            }
            catch (Exception ex) { ErrorBox(ex.Message); return; }

            //Parse ini
            try
            {
                ini = new mymini();
                ini.ProgressChanged += new EventHandler<System.ComponentModel.ProgressChangedEventArgs>(ini_ProgressChanged);
                ini.Load(mymOut + "mym.ini");
                ReportProgress(100, " ");
            }
            catch (Exception ex) { ErrorBox(ex.Message); return; }

            openedMym = Path.GetFileNameWithoutExtension((string)mymFile);

            //Add entries
            MethodInvoker m = new MethodInvoker(this.AddEntries);
            this.Invoke(m);
        }

        private delegate void boxInvoker(string message);
        private void _errorBox(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void _infoBox(string message)
        {
            MessageBox.Show(message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void _setControlsFalse()
        {
            SetControlsRecursive(this, false);

            foreach (object tsItem in msList.DropDownItems)
            {
                if (tsItem is ToolStripMenuItem) ((ToolStripMenuItem)tsItem).Enabled = false;
            }

            msSave.Enabled = false;
            msInstallToNandBackup.Enabled = false;
        }

        private void _setControlsTrue()
        {
            SetControlsRecursive(this, true);

            foreach (object tsItem in msList.DropDownItems)
            {
                if (tsItem is ToolStripMenuItem) ((ToolStripMenuItem)tsItem).Enabled = true;
            }

            msSave.Enabled = true;
            msInstallToNandBackup.Enabled = true;
        }

        private delegate void _progressReporter(ProgressChangedEventArgs e);
        private void _reportProgress(ProgressChangedEventArgs e)
        {
            if (pbProgress.Value != e.ProgressPercentage)
                pbProgress.Value = e.ProgressPercentage;
            if (lbStatus.Text != (string)e.UserState && !string.IsNullOrEmpty((string)e.UserState))
                lbStatus.Text = (string)e.UserState;
        }
        */
    }
}
