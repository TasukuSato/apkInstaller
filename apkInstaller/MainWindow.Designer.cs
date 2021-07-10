namespace apkInstaller
{
    partial class MainWindow
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
            this.apkListView = new System.Windows.Forms.ListView();
            this.HeaderApkName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.HeaderStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.UpdateListButton = new System.Windows.Forms.Button();
            this.InstallButton = new System.Windows.Forms.Button();
            this.LogText = new System.Windows.Forms.ListView();
            this.LogHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // apkListView
            // 
            this.apkListView.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.apkListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.HeaderApkName,
            this.HeaderStatus});
            this.apkListView.GridLines = true;
            this.apkListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.apkListView.HideSelection = false;
            this.apkListView.Location = new System.Drawing.Point(28, 77);
            this.apkListView.Name = "apkListView";
            this.apkListView.Size = new System.Drawing.Size(741, 218);
            this.apkListView.TabIndex = 1;
            this.apkListView.UseCompatibleStateImageBehavior = false;
            this.apkListView.View = System.Windows.Forms.View.Details;
            // 
            // HeaderApkName
            // 
            this.HeaderApkName.Text = "apk名";
            this.HeaderApkName.Width = 500;
            // 
            // HeaderStatus
            // 
            this.HeaderStatus.Text = "ステータス";
            this.HeaderStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.HeaderStatus.Width = 100;
            // 
            // UpdateListButton
            // 
            this.UpdateListButton.Location = new System.Drawing.Point(161, 26);
            this.UpdateListButton.Name = "UpdateListButton";
            this.UpdateListButton.Size = new System.Drawing.Size(104, 32);
            this.UpdateListButton.TabIndex = 3;
            this.UpdateListButton.Text = "リスト更新";
            this.UpdateListButton.UseVisualStyleBackColor = true;
            this.UpdateListButton.Click += new System.EventHandler(this.UpdateListButton_Click);
            // 
            // InstallButton
            // 
            this.InstallButton.Location = new System.Drawing.Point(28, 26);
            this.InstallButton.Name = "InstallButton";
            this.InstallButton.Size = new System.Drawing.Size(104, 32);
            this.InstallButton.TabIndex = 4;
            this.InstallButton.Text = "インストール";
            this.InstallButton.UseVisualStyleBackColor = true;
            this.InstallButton.Click += new System.EventHandler(this.InstallButton_Click);
            // 
            // LogText
            // 
            this.LogText.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.LogText.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.LogHeader});
            this.LogText.GridLines = true;
            this.LogText.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.LogText.HideSelection = false;
            this.LogText.Location = new System.Drawing.Point(28, 323);
            this.LogText.Name = "LogText";
            this.LogText.Size = new System.Drawing.Size(741, 116);
            this.LogText.TabIndex = 2;
            this.LogText.UseCompatibleStateImageBehavior = false;
            this.LogText.View = System.Windows.Forms.View.Details;
            // 
            // LogHeader
            // 
            this.LogHeader.Text = "ログ";
            this.LogHeader.Width = 720;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(351, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(348, 50);
            this.label1.TabIndex = 5;
            this.label1.Text = "このアプリの実行ファイルと同じ階層にあるapkフォルダに\r\nインストールしたいapkを入れて\r\nリストを更新後、インストールをしてください。\r\n";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LogText);
            this.Controls.Add(this.InstallButton);
            this.Controls.Add(this.UpdateListButton);
            this.Controls.Add(this.apkListView);
            this.Name = "Form1";
            this.Text = "apkインストーラー";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView apkListView;
        private System.Windows.Forms.ColumnHeader HeaderApkName;
        private System.Windows.Forms.ColumnHeader HeaderStatus;
        private System.Windows.Forms.Button UpdateListButton;
        private System.Windows.Forms.Button InstallButton;
        private System.Windows.Forms.ListView LogText;
        private System.Windows.Forms.ColumnHeader LogHeader;
        private System.Windows.Forms.Label label1;
    }
}

