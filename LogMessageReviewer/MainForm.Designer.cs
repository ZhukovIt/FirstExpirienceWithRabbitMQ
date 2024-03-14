namespace LogMessageReviewer
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tsMainMenu = new System.Windows.Forms.ToolStrip();
            this.grdLogMessages = new System.Windows.Forms.DataGridView();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.tsMainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdLogMessages)).BeginInit();
            this.SuspendLayout();
            // 
            // tsMainMenu
            // 
            this.tsMainMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tsMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
            this.tsMainMenu.Location = new System.Drawing.Point(0, 0);
            this.tsMainMenu.Name = "tsMainMenu";
            this.tsMainMenu.Size = new System.Drawing.Size(985, 27);
            this.tsMainMenu.TabIndex = 0;
            this.tsMainMenu.Text = "toolStrip1";
            // 
            // grdLogMessages
            // 
            this.grdLogMessages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdLogMessages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdLogMessages.Location = new System.Drawing.Point(0, 27);
            this.grdLogMessages.Name = "grdLogMessages";
            this.grdLogMessages.RowHeadersWidth = 51;
            this.grdLogMessages.RowTemplate.Height = 24;
            this.grdLogMessages.Size = new System.Drawing.Size(985, 578);
            this.grdLogMessages.TabIndex = 1;
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(29, 24);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 605);
            this.Controls.Add(this.grdLogMessages);
            this.Controls.Add(this.tsMainMenu);
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "Form1";
            this.tsMainMenu.ResumeLayout(false);
            this.tsMainMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdLogMessages)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMainMenu;
        private System.Windows.Forms.DataGridView grdLogMessages;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
    }
}

