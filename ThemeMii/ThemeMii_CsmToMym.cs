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
using System.Threading;
//using System.Windows.Forms;
using ICSharpCode.SharpZipLib.Zip;

/*
namespace ThemeMii
{
    public partial class ThemeMii_CsmToMym : Form
    {
        public string tempDir;
        private string saveFile;
        private bool intensiveAlgorithm = false;

        public ThemeMii_CsmToMym()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.ThemeMii_Icon;
        }

        private void ThemeMii_CsmToMym_Load(object sender, EventArgs e)
        {
            CenterToParent();
            ToolTip tTip = new ToolTip();
            tTip.SetToolTip(cbIntensiveAlgorithm, "Don't uncheck this unless you're facing problems!");
        }

        private void btnCsmBrowse_Click(object sender, EventArgs e)
        {
            if (pbProgress.Value == 100)
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "csm|*.csm";

                if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    tbCsm.Text = ofd.FileName;
            }
        }

        private void btnAppBrowse_Click(object sender, EventArgs e)
        {
            if (pbProgress.Value == 100)
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "app|*.app";

                if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    tbApp.Text = ofd.FileName;
            }
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            if (File.Exists(tbCsm.Text) && File.Exists(tbApp.Text))
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "mym|*.mym";
                sfd.FileName = Path.GetFileNameWithoutExtension(tbCsm.Text);

                if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    saveFile = sfd.FileName;
                    pbProgress.Value = 0;
                    btnConvert.Visible = false;
                    intensiveAlgorithm = cbIntensiveAlgorithm.Checked;

                    Thread workerThread = new Thread(new ThreadStart(this._convertCsm));
                    workerThread.Start();
                }
            }
        }

        private void _convertCsm()
        {
            string appDir = tempDir + "\\appOut\\";
            string csmDir = tempDir + "\\csmOut\\";
            string mymDir = tempDir + "\\mymOut\\";

            if (Directory.Exists(appDir)) Directory.Delete(appDir, true);
            if (Directory.Exists(csmDir)) Directory.Delete(csmDir, true);
            if (Directory.Exists(mymDir)) Directory.Delete(mymDir, true);

            List<iniEntry> entryList = new List<iniEntry>();

            Wii.U8.UnpackU8(tbCsm.Text, csmDir);
            Wii.U8.UnpackU8(tbApp.Text, appDir);

            string[] csmFiles = Directory.GetFiles(csmDir, "*", SearchOption.AllDirectories);

            if (intensiveAlgorithm)
            {
                for (int i = 0; i < csmFiles.Length; i++)
                {
                    ReportProgress((i * 100 / csmFiles.Length) / 2);

                    byte[] temp = Wii.Tools.LoadFileToByteArray(csmFiles[i], 0, 4);
                    if (temp[0] == 'Y' && temp[1] == 'a' && temp[2] == 'z' && temp[3] == '0') continue;

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
                                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                                Wii.U8.UnpackU8(csmFiles[i].Replace(csmDir, appDir), csmFiles[i].Replace(csmDir, appDir).Replace(".", "_") + "_out");
                                File.Delete(csmFiles[i].Replace(csmDir, appDir));
                                extracted = true;
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                                Wii.U8.UnpackU8(csmFiles[i], csmFiles[i].Replace(".", "_") + "_out");
                                File.Delete(csmFiles[i]);
                                extracted = true;
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            MessageBox.Show("Saved mym to:\n" + saveFile, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void DeASH(string file)
        {
            ProcessStartInfo pInfo = new ProcessStartInfo(Application.StartupPath + "\\ASH.exe", string.Format("\"{0}\"", file));
            pInfo.UseShellExecute = false;
            //pInfo.RedirectStandardOutput = true;
            pInfo.CreateNoWindow = true;

            Process p = Process.Start(pInfo);
            p.WaitForExit();

            //ErrorBox(p.StandardOutput.ReadToEnd() + "\n\n" + mymC.file);
        }

        private bool StringExistsInStringArray(string theString, string[] theStringArray)
        {
            return Array.Exists(theStringArray, thisString => thisString.ToLower() == theString.ToLower());
        }

        private void ReportProgress(int progressPercentage)
        {
            SetProgress sp = new SetProgress(this._setProgress);
            this.Invoke(sp, progressPercentage);
        }

        private delegate void SetProgress(int progressPercentage);
        private void _setProgress(int progressPercentage)
        {
            pbProgress.Value = progressPercentage;
            if (pbProgress.Value == 100) btnConvert.Visible = true;
        }
    }
}
*/