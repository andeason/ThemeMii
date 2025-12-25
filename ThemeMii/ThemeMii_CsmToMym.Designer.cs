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
    partial class ThemeMii_CsmToMym
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
            this.lbCsm = new System.Windows.Forms.Label();
            this.btnCsmBrowse = new System.Windows.Forms.Button();
            this.tbCsm = new System.Windows.Forms.TextBox();
            this.lbApp = new System.Windows.Forms.Label();
            this.tbApp = new System.Windows.Forms.TextBox();
            this.btnAppBrowse = new System.Windows.Forms.Button();
            this.btnConvert = new System.Windows.Forms.Button();
            this.pbProgress = new System.Windows.Forms.ProgressBar();
            this.cbIntensiveAlgorithm = new System.Windows.Forms.CheckBox();
            this.lbInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbCsm
            // 
            this.lbCsm.AutoSize = true;
            this.lbCsm.Location = new System.Drawing.Point(12, 47);
            this.lbCsm.Name = "lbCsm";
            this.lbCsm.Size = new System.Drawing.Size(29, 13);
            this.lbCsm.TabIndex = 0;
            this.lbCsm.Text = "csm:";
            // 
            // btnCsmBrowse
            // 
            this.btnCsmBrowse.Location = new System.Drawing.Point(204, 44);
            this.btnCsmBrowse.Name = "btnCsmBrowse";
            this.btnCsmBrowse.Size = new System.Drawing.Size(63, 20);
            this.btnCsmBrowse.TabIndex = 1;
            this.btnCsmBrowse.Text = "Browse...";
            this.btnCsmBrowse.UseVisualStyleBackColor = true;
            this.btnCsmBrowse.Click += new System.EventHandler(this.btnCsmBrowse_Click);
            // 
            // tbCsm
            // 
            this.tbCsm.Location = new System.Drawing.Point(47, 44);
            this.tbCsm.Name = "tbCsm";
            this.tbCsm.Size = new System.Drawing.Size(151, 20);
            this.tbCsm.TabIndex = 2;
            // 
            // lbApp
            // 
            this.lbApp.AutoSize = true;
            this.lbApp.Location = new System.Drawing.Point(12, 80);
            this.lbApp.Name = "lbApp";
            this.lbApp.Size = new System.Drawing.Size(28, 13);
            this.lbApp.TabIndex = 0;
            this.lbApp.Text = "app:";
            // 
            // tbApp
            // 
            this.tbApp.Location = new System.Drawing.Point(47, 77);
            this.tbApp.Name = "tbApp";
            this.tbApp.Size = new System.Drawing.Size(151, 20);
            this.tbApp.TabIndex = 2;
            // 
            // btnAppBrowse
            // 
            this.btnAppBrowse.Location = new System.Drawing.Point(204, 76);
            this.btnAppBrowse.Name = "btnAppBrowse";
            this.btnAppBrowse.Size = new System.Drawing.Size(63, 20);
            this.btnAppBrowse.TabIndex = 1;
            this.btnAppBrowse.Text = "Browse...";
            this.btnAppBrowse.UseVisualStyleBackColor = true;
            this.btnAppBrowse.Click += new System.EventHandler(this.btnAppBrowse_Click);
            // 
            // btnConvert
            // 
            this.btnConvert.Location = new System.Drawing.Point(15, 139);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(252, 23);
            this.btnConvert.TabIndex = 3;
            this.btnConvert.Text = "Convert";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // pbProgress
            // 
            this.pbProgress.Location = new System.Drawing.Point(15, 139);
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.Size = new System.Drawing.Size(252, 23);
            this.pbProgress.TabIndex = 4;
            this.pbProgress.Value = 100;
            // 
            // cbIntensiveAlgorithm
            // 
            this.cbIntensiveAlgorithm.AutoSize = true;
            this.cbIntensiveAlgorithm.Checked = true;
            this.cbIntensiveAlgorithm.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbIntensiveAlgorithm.Location = new System.Drawing.Point(15, 110);
            this.cbIntensiveAlgorithm.Name = "cbIntensiveAlgorithm";
            this.cbIntensiveAlgorithm.Size = new System.Drawing.Size(182, 17);
            this.cbIntensiveAlgorithm.TabIndex = 5;
            this.cbIntensiveAlgorithm.Text = "Intensive Algorithm (Smaller mym)";
            this.cbIntensiveAlgorithm.UseVisualStyleBackColor = true;
            // 
            // lbInfo
            // 
            this.lbInfo.AutoSize = true;
            this.lbInfo.Location = new System.Drawing.Point(8, 9);
            this.lbInfo.Name = "lbInfo";
            this.lbInfo.Size = new System.Drawing.Size(265, 26);
            this.lbInfo.TabIndex = 6;
            this.lbInfo.Text = "Be sure to use the same app as the csm was built with.\r\nIf the csm is for 4.2U, u" +
                "se the 4.2U base app!";
            this.lbInfo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ThemeMii_CsmToMym
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(281, 172);
            this.Controls.Add(this.lbInfo);
            this.Controls.Add(this.cbIntensiveAlgorithm);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.tbApp);
            this.Controls.Add(this.tbCsm);
            this.Controls.Add(this.btnAppBrowse);
            this.Controls.Add(this.btnCsmBrowse);
            this.Controls.Add(this.lbApp);
            this.Controls.Add(this.lbCsm);
            this.Controls.Add(this.pbProgress);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ThemeMii_CsmToMym";
            this.Text = "csm to mym";
            this.Load += new System.EventHandler(this.ThemeMii_CsmToMym_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbCsm;
        private System.Windows.Forms.Button btnCsmBrowse;
        private System.Windows.Forms.TextBox tbCsm;
        private System.Windows.Forms.Label lbApp;
        private System.Windows.Forms.TextBox tbApp;
        private System.Windows.Forms.Button btnAppBrowse;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.ProgressBar pbProgress;
        private System.Windows.Forms.CheckBox cbIntensiveAlgorithm;
        private System.Windows.Forms.Label lbInfo;
    }
}
*/