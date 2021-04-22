﻿
namespace BSSceneToHotKey
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtClientIpAddress = new System.Windows.Forms.TextBox();
            this.btnClientReset = new System.Windows.Forms.Button();
            this.lblClientStatus = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSet = new System.Windows.Forms.Button();
            this.btnEndKeyTest = new System.Windows.Forms.Button();
            this.cmbEndKeys = new System.Windows.Forms.ComboBox();
            this.chkEndShift = new System.Windows.Forms.CheckBox();
            this.chkEndAlt = new System.Windows.Forms.CheckBox();
            this.chkEndCtrl = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnStartKeyTest = new System.Windows.Forms.Button();
            this.cmbStartKeys = new System.Windows.Forms.ComboBox();
            this.chkStartShift = new System.Windows.Forms.CheckBox();
            this.chkStartAlt = new System.Windows.Forms.CheckBox();
            this.chkStartCtrl = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnMenuKeyTest = new System.Windows.Forms.Button();
            this.cmbMenuKeys = new System.Windows.Forms.ComboBox();
            this.chkMenuShift = new System.Windows.Forms.CheckBox();
            this.chkMenuAlt = new System.Windows.Forms.CheckBox();
            this.chkMenuCtrl = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnGameKeyTest = new System.Windows.Forms.Button();
            this.cmbGameKeys = new System.Windows.Forms.ComboBox();
            this.chkGemeShift = new System.Windows.Forms.CheckBox();
            this.chkGemeAlt = new System.Windows.Forms.CheckBox();
            this.chkGemeCtrl = new System.Windows.Forms.CheckBox();
            this.nudPort = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSetMessage = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtGameMessage = new System.Windows.Forms.TextBox();
            this.txtMenuMessage = new System.Windows.Forms.TextBox();
            this.txtStartMessage = new System.Windows.Forms.TextBox();
            this.txtEndMessage = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPort)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "WebServer";
            // 
            // txtClientIpAddress
            // 
            this.txtClientIpAddress.Location = new System.Drawing.Point(77, 16);
            this.txtClientIpAddress.Name = "txtClientIpAddress";
            this.txtClientIpAddress.Size = new System.Drawing.Size(185, 19);
            this.txtClientIpAddress.TabIndex = 1;
            this.txtClientIpAddress.Text = "localhost";
            // 
            // btnClientReset
            // 
            this.btnClientReset.Location = new System.Drawing.Point(341, 16);
            this.btnClientReset.Name = "btnClientReset";
            this.btnClientReset.Size = new System.Drawing.Size(58, 19);
            this.btnClientReset.TabIndex = 3;
            this.btnClientReset.Text = "更新";
            this.btnClientReset.UseVisualStyleBackColor = true;
            this.btnClientReset.Click += new System.EventHandler(this.btnClientReset_Click);
            // 
            // lblClientStatus
            // 
            this.lblClientStatus.BackColor = System.Drawing.Color.Red;
            this.lblClientStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblClientStatus.ForeColor = System.Drawing.Color.White;
            this.lblClientStatus.Location = new System.Drawing.Point(414, 16);
            this.lblClientStatus.Name = "lblClientStatus";
            this.lblClientStatus.Size = new System.Drawing.Size(52, 19);
            this.lblClientStatus.TabIndex = 4;
            this.lblClientStatus.Text = "切断";
            this.lblClientStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "GameSeen";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSet);
            this.groupBox1.Controls.Add(this.btnEndKeyTest);
            this.groupBox1.Controls.Add(this.cmbEndKeys);
            this.groupBox1.Controls.Add(this.chkEndShift);
            this.groupBox1.Controls.Add(this.chkEndAlt);
            this.groupBox1.Controls.Add(this.chkEndCtrl);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnStartKeyTest);
            this.groupBox1.Controls.Add(this.cmbStartKeys);
            this.groupBox1.Controls.Add(this.chkStartShift);
            this.groupBox1.Controls.Add(this.chkStartAlt);
            this.groupBox1.Controls.Add(this.chkStartCtrl);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.btnMenuKeyTest);
            this.groupBox1.Controls.Add(this.cmbMenuKeys);
            this.groupBox1.Controls.Add(this.chkMenuShift);
            this.groupBox1.Controls.Add(this.chkMenuAlt);
            this.groupBox1.Controls.Add(this.chkMenuCtrl);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnGameKeyTest);
            this.groupBox1.Controls.Add(this.cmbGameKeys);
            this.groupBox1.Controls.Add(this.chkGemeShift);
            this.groupBox1.Controls.Add(this.chkGemeAlt);
            this.groupBox1.Controls.Add(this.chkGemeCtrl);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(14, 54);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(416, 166);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ホットキー設定";
            // 
            // btnSet
            // 
            this.btnSet.Location = new System.Drawing.Point(279, 140);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(115, 20);
            this.btnSet.TabIndex = 29;
            this.btnSet.Text = "設定反映";
            this.btnSet.UseVisualStyleBackColor = true;
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // btnEndKeyTest
            // 
            this.btnEndKeyTest.Location = new System.Drawing.Point(336, 104);
            this.btnEndKeyTest.Name = "btnEndKeyTest";
            this.btnEndKeyTest.Size = new System.Drawing.Size(58, 20);
            this.btnEndKeyTest.TabIndex = 28;
            this.btnEndKeyTest.Text = "テスト";
            this.btnEndKeyTest.UseVisualStyleBackColor = true;
            this.btnEndKeyTest.Click += new System.EventHandler(this.btnEndKeyTest_Click);
            // 
            // cmbEndKeys
            // 
            this.cmbEndKeys.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEndKeys.FormattingEnabled = true;
            this.cmbEndKeys.Location = new System.Drawing.Point(219, 104);
            this.cmbEndKeys.Name = "cmbEndKeys";
            this.cmbEndKeys.Size = new System.Drawing.Size(102, 20);
            this.cmbEndKeys.TabIndex = 27;
            // 
            // chkEndShift
            // 
            this.chkEndShift.AutoSize = true;
            this.chkEndShift.Location = new System.Drawing.Point(165, 106);
            this.chkEndShift.Name = "chkEndShift";
            this.chkEndShift.Size = new System.Drawing.Size(48, 16);
            this.chkEndShift.TabIndex = 26;
            this.chkEndShift.Text = "Shift";
            this.chkEndShift.UseVisualStyleBackColor = true;
            // 
            // chkEndAlt
            // 
            this.chkEndAlt.AutoSize = true;
            this.chkEndAlt.Location = new System.Drawing.Point(120, 106);
            this.chkEndAlt.Name = "chkEndAlt";
            this.chkEndAlt.Size = new System.Drawing.Size(39, 16);
            this.chkEndAlt.TabIndex = 25;
            this.chkEndAlt.Text = "Alt";
            this.chkEndAlt.UseVisualStyleBackColor = true;
            // 
            // chkEndCtrl
            // 
            this.chkEndCtrl.AutoSize = true;
            this.chkEndCtrl.Location = new System.Drawing.Point(71, 106);
            this.chkEndCtrl.Name = "chkEndCtrl";
            this.chkEndCtrl.Size = new System.Drawing.Size(43, 16);
            this.chkEndCtrl.TabIndex = 24;
            this.chkEndCtrl.Text = "Ctrl";
            this.chkEndCtrl.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 12);
            this.label4.TabIndex = 23;
            this.label4.Text = "EndSeen";
            // 
            // btnStartKeyTest
            // 
            this.btnStartKeyTest.Location = new System.Drawing.Point(336, 78);
            this.btnStartKeyTest.Name = "btnStartKeyTest";
            this.btnStartKeyTest.Size = new System.Drawing.Size(58, 20);
            this.btnStartKeyTest.TabIndex = 22;
            this.btnStartKeyTest.Text = "テスト";
            this.btnStartKeyTest.UseVisualStyleBackColor = true;
            this.btnStartKeyTest.Click += new System.EventHandler(this.btnStartKeyTest_Click);
            // 
            // cmbStartKeys
            // 
            this.cmbStartKeys.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStartKeys.FormattingEnabled = true;
            this.cmbStartKeys.Location = new System.Drawing.Point(219, 78);
            this.cmbStartKeys.Name = "cmbStartKeys";
            this.cmbStartKeys.Size = new System.Drawing.Size(102, 20);
            this.cmbStartKeys.TabIndex = 21;
            // 
            // chkStartShift
            // 
            this.chkStartShift.AutoSize = true;
            this.chkStartShift.Location = new System.Drawing.Point(165, 80);
            this.chkStartShift.Name = "chkStartShift";
            this.chkStartShift.Size = new System.Drawing.Size(48, 16);
            this.chkStartShift.TabIndex = 20;
            this.chkStartShift.Text = "Shift";
            this.chkStartShift.UseVisualStyleBackColor = true;
            // 
            // chkStartAlt
            // 
            this.chkStartAlt.AutoSize = true;
            this.chkStartAlt.Location = new System.Drawing.Point(120, 80);
            this.chkStartAlt.Name = "chkStartAlt";
            this.chkStartAlt.Size = new System.Drawing.Size(39, 16);
            this.chkStartAlt.TabIndex = 19;
            this.chkStartAlt.Text = "Alt";
            this.chkStartAlt.UseVisualStyleBackColor = true;
            // 
            // chkStartCtrl
            // 
            this.chkStartCtrl.AutoSize = true;
            this.chkStartCtrl.Location = new System.Drawing.Point(71, 80);
            this.chkStartCtrl.Name = "chkStartCtrl";
            this.chkStartCtrl.Size = new System.Drawing.Size(43, 16);
            this.chkStartCtrl.TabIndex = 18;
            this.chkStartCtrl.Text = "Ctrl";
            this.chkStartCtrl.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 12);
            this.label5.TabIndex = 17;
            this.label5.Text = "StartSeen";
            // 
            // btnMenuKeyTest
            // 
            this.btnMenuKeyTest.Location = new System.Drawing.Point(336, 52);
            this.btnMenuKeyTest.Name = "btnMenuKeyTest";
            this.btnMenuKeyTest.Size = new System.Drawing.Size(58, 20);
            this.btnMenuKeyTest.TabIndex = 16;
            this.btnMenuKeyTest.Text = "テスト";
            this.btnMenuKeyTest.UseVisualStyleBackColor = true;
            this.btnMenuKeyTest.Click += new System.EventHandler(this.btnMenuKeyTest_Click);
            // 
            // cmbMenuKeys
            // 
            this.cmbMenuKeys.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMenuKeys.FormattingEnabled = true;
            this.cmbMenuKeys.Location = new System.Drawing.Point(219, 52);
            this.cmbMenuKeys.Name = "cmbMenuKeys";
            this.cmbMenuKeys.Size = new System.Drawing.Size(102, 20);
            this.cmbMenuKeys.TabIndex = 15;
            // 
            // chkMenuShift
            // 
            this.chkMenuShift.AutoSize = true;
            this.chkMenuShift.Location = new System.Drawing.Point(165, 54);
            this.chkMenuShift.Name = "chkMenuShift";
            this.chkMenuShift.Size = new System.Drawing.Size(48, 16);
            this.chkMenuShift.TabIndex = 14;
            this.chkMenuShift.Text = "Shift";
            this.chkMenuShift.UseVisualStyleBackColor = true;
            // 
            // chkMenuAlt
            // 
            this.chkMenuAlt.AutoSize = true;
            this.chkMenuAlt.Location = new System.Drawing.Point(120, 54);
            this.chkMenuAlt.Name = "chkMenuAlt";
            this.chkMenuAlt.Size = new System.Drawing.Size(39, 16);
            this.chkMenuAlt.TabIndex = 13;
            this.chkMenuAlt.Text = "Alt";
            this.chkMenuAlt.UseVisualStyleBackColor = true;
            // 
            // chkMenuCtrl
            // 
            this.chkMenuCtrl.AutoSize = true;
            this.chkMenuCtrl.Location = new System.Drawing.Point(71, 54);
            this.chkMenuCtrl.Name = "chkMenuCtrl";
            this.chkMenuCtrl.Size = new System.Drawing.Size(43, 16);
            this.chkMenuCtrl.TabIndex = 12;
            this.chkMenuCtrl.Text = "Ctrl";
            this.chkMenuCtrl.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "MenuSeen";
            // 
            // btnGameKeyTest
            // 
            this.btnGameKeyTest.Location = new System.Drawing.Point(336, 26);
            this.btnGameKeyTest.Name = "btnGameKeyTest";
            this.btnGameKeyTest.Size = new System.Drawing.Size(58, 20);
            this.btnGameKeyTest.TabIndex = 10;
            this.btnGameKeyTest.Text = "テスト";
            this.btnGameKeyTest.UseVisualStyleBackColor = true;
            this.btnGameKeyTest.Click += new System.EventHandler(this.btnGameKeyTest_Click);
            // 
            // cmbGameKeys
            // 
            this.cmbGameKeys.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGameKeys.FormattingEnabled = true;
            this.cmbGameKeys.Location = new System.Drawing.Point(219, 26);
            this.cmbGameKeys.Name = "cmbGameKeys";
            this.cmbGameKeys.Size = new System.Drawing.Size(102, 20);
            this.cmbGameKeys.TabIndex = 9;
            // 
            // chkGemeShift
            // 
            this.chkGemeShift.AutoSize = true;
            this.chkGemeShift.Location = new System.Drawing.Point(165, 28);
            this.chkGemeShift.Name = "chkGemeShift";
            this.chkGemeShift.Size = new System.Drawing.Size(48, 16);
            this.chkGemeShift.TabIndex = 8;
            this.chkGemeShift.Text = "Shift";
            this.chkGemeShift.UseVisualStyleBackColor = true;
            // 
            // chkGemeAlt
            // 
            this.chkGemeAlt.AutoSize = true;
            this.chkGemeAlt.Location = new System.Drawing.Point(120, 28);
            this.chkGemeAlt.Name = "chkGemeAlt";
            this.chkGemeAlt.Size = new System.Drawing.Size(39, 16);
            this.chkGemeAlt.TabIndex = 7;
            this.chkGemeAlt.Text = "Alt";
            this.chkGemeAlt.UseVisualStyleBackColor = true;
            // 
            // chkGemeCtrl
            // 
            this.chkGemeCtrl.AutoSize = true;
            this.chkGemeCtrl.Location = new System.Drawing.Point(71, 28);
            this.chkGemeCtrl.Name = "chkGemeCtrl";
            this.chkGemeCtrl.Size = new System.Drawing.Size(43, 16);
            this.chkGemeCtrl.TabIndex = 6;
            this.chkGemeCtrl.Text = "Ctrl";
            this.chkGemeCtrl.UseVisualStyleBackColor = true;
            // 
            // nudPort
            // 
            this.nudPort.Location = new System.Drawing.Point(268, 17);
            this.nudPort.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.nudPort.Name = "nudPort";
            this.nudPort.Size = new System.Drawing.Size(67, 19);
            this.nudPort.TabIndex = 7;
            this.nudPort.Value = new decimal(new int[] {
            59650,
            0,
            0,
            0});
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtEndMessage);
            this.groupBox2.Controls.Add(this.txtStartMessage);
            this.groupBox2.Controls.Add(this.txtMenuMessage);
            this.groupBox2.Controls.Add(this.txtGameMessage);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.btnSetMessage);
            this.groupBox2.Location = new System.Drawing.Point(14, 226);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(416, 139);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "受信メッセージ設定";
            // 
            // btnSetMessage
            // 
            this.btnSetMessage.Location = new System.Drawing.Point(279, 100);
            this.btnSetMessage.Name = "btnSetMessage";
            this.btnSetMessage.Size = new System.Drawing.Size(115, 20);
            this.btnSetMessage.TabIndex = 30;
            this.btnSetMessage.Text = "設定反映";
            this.btnSetMessage.UseVisualStyleBackColor = true;
            this.btnSetMessage.Click += new System.EventHandler(this.btnSetMessage_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 104);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 12);
            this.label6.TabIndex = 34;
            this.label6.Text = "EndSeen";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 78);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 12);
            this.label7.TabIndex = 33;
            this.label7.Text = "StartSeen";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 52);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 12);
            this.label8.TabIndex = 32;
            this.label8.Text = "MenuSeen";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 26);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 12);
            this.label9.TabIndex = 31;
            this.label9.Text = "GameSeen";
            // 
            // txtGameMessage
            // 
            this.txtGameMessage.Location = new System.Drawing.Point(71, 23);
            this.txtGameMessage.Name = "txtGameMessage";
            this.txtGameMessage.Size = new System.Drawing.Size(185, 19);
            this.txtGameMessage.TabIndex = 35;
            this.txtGameMessage.Text = "BS-Game";
            // 
            // txtMenuMessage
            // 
            this.txtMenuMessage.Location = new System.Drawing.Point(71, 49);
            this.txtMenuMessage.Name = "txtMenuMessage";
            this.txtMenuMessage.Size = new System.Drawing.Size(185, 19);
            this.txtMenuMessage.TabIndex = 36;
            this.txtMenuMessage.Text = "BS-Menu";
            // 
            // txtStartMessage
            // 
            this.txtStartMessage.Location = new System.Drawing.Point(71, 75);
            this.txtStartMessage.Name = "txtStartMessage";
            this.txtStartMessage.Size = new System.Drawing.Size(185, 19);
            this.txtStartMessage.TabIndex = 37;
            this.txtStartMessage.Text = "BS-Start";
            // 
            // txtEndMessage
            // 
            this.txtEndMessage.Location = new System.Drawing.Point(71, 101);
            this.txtEndMessage.Name = "txtEndMessage";
            this.txtEndMessage.Size = new System.Drawing.Size(185, 19);
            this.txtEndMessage.TabIndex = 38;
            this.txtEndMessage.Text = "BS-End";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 375);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.nudPort);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblClientStatus);
            this.Controls.Add(this.btnClientReset);
            this.Controls.Add(this.txtClientIpAddress);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "リュナンさん製HTTPStatusのシーン切り替えをHotKeyに変更するよ";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPort)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtClientIpAddress;
        private System.Windows.Forms.Button btnClientReset;
        private System.Windows.Forms.Label lblClientStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbGameKeys;
        private System.Windows.Forms.CheckBox chkGemeShift;
        private System.Windows.Forms.CheckBox chkGemeAlt;
        private System.Windows.Forms.CheckBox chkGemeCtrl;
        private System.Windows.Forms.Button btnMenuKeyTest;
        private System.Windows.Forms.ComboBox cmbMenuKeys;
        private System.Windows.Forms.CheckBox chkMenuShift;
        private System.Windows.Forms.CheckBox chkMenuAlt;
        private System.Windows.Forms.CheckBox chkMenuCtrl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnGameKeyTest;
        private System.Windows.Forms.Button btnEndKeyTest;
        private System.Windows.Forms.ComboBox cmbEndKeys;
        private System.Windows.Forms.CheckBox chkEndShift;
        private System.Windows.Forms.CheckBox chkEndAlt;
        private System.Windows.Forms.CheckBox chkEndCtrl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnStartKeyTest;
        private System.Windows.Forms.ComboBox cmbStartKeys;
        private System.Windows.Forms.CheckBox chkStartShift;
        private System.Windows.Forms.CheckBox chkStartAlt;
        private System.Windows.Forms.CheckBox chkStartCtrl;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSet;
        private System.Windows.Forms.NumericUpDown nudPort;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSetMessage;
        private System.Windows.Forms.TextBox txtEndMessage;
        private System.Windows.Forms.TextBox txtStartMessage;
        private System.Windows.Forms.TextBox txtMenuMessage;
        private System.Windows.Forms.TextBox txtGameMessage;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
    }
}

