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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tsMainMenu = new System.Windows.Forms.ToolStrip();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.grdLogMessages = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.externalIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.bsEventType = new System.Windows.Forms.BindingSource(this.components);
            this.dtsOSAEvent = new LogMessageReviewer.dtsOSAEvent();
            this.contentDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.bsLogMessageStatus = new System.Windows.Forms.BindingSource(this.components);
            this.errorMessageDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsLogMessage = new System.Windows.Forms.BindingSource(this.components);
            this.tsMainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdLogMessages)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsEventType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtsOSAEvent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsLogMessageStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsLogMessage)).BeginInit();
            this.SuspendLayout();
            // 
            // tsMainMenu
            // 
            this.tsMainMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tsMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefresh});
            this.tsMainMenu.Location = new System.Drawing.Point(0, 0);
            this.tsMainMenu.Name = "tsMainMenu";
            this.tsMainMenu.Size = new System.Drawing.Size(1135, 39);
            this.tsMainMenu.TabIndex = 0;
            this.tsMainMenu.Text = "toolStrip1";
            // 
            // btnRefresh
            // 
            this.btnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(36, 36);
            this.btnRefresh.Text = "Обновить сообщения...";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // grdLogMessages
            // 
            this.grdLogMessages.AllowUserToAddRows = false;
            this.grdLogMessages.AllowUserToDeleteRows = false;
            this.grdLogMessages.AutoGenerateColumns = false;
            this.grdLogMessages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdLogMessages.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.externalIdDataGridViewTextBoxColumn,
            this.Column2,
            this.contentDataGridViewTextBoxColumn,
            this.Column3,
            this.errorMessageDataGridViewTextBoxColumn});
            this.grdLogMessages.DataSource = this.bsLogMessage;
            this.grdLogMessages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdLogMessages.Location = new System.Drawing.Point(0, 39);
            this.grdLogMessages.Margin = new System.Windows.Forms.Padding(2);
            this.grdLogMessages.Name = "grdLogMessages";
            this.grdLogMessages.ReadOnly = true;
            this.grdLogMessages.RowHeadersWidth = 51;
            this.grdLogMessages.RowTemplate.Height = 24;
            this.grdLogMessages.Size = new System.Drawing.Size(1135, 532);
            this.grdLogMessages.TabIndex = 1;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Id";
            this.Column1.HeaderText = "№";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 50;
            // 
            // externalIdDataGridViewTextBoxColumn
            // 
            this.externalIdDataGridViewTextBoxColumn.DataPropertyName = "ExternalId";
            this.externalIdDataGridViewTextBoxColumn.HeaderText = "Guid связи";
            this.externalIdDataGridViewTextBoxColumn.Name = "externalIdDataGridViewTextBoxColumn";
            this.externalIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.externalIdDataGridViewTextBoxColumn.Width = 220;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "EventTypeId";
            this.Column2.DataSource = this.bsEventType;
            this.Column2.DisplayMember = "Name";
            this.Column2.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.Column2.HeaderText = "Тип события";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.ValueMember = "Id";
            this.Column2.Width = 150;
            // 
            // bsEventType
            // 
            this.bsEventType.DataMember = "EventType";
            this.bsEventType.DataSource = this.dtsOSAEvent;
            // 
            // dtsOSAEvent
            // 
            this.dtsOSAEvent.DataSetName = "dtsOSAEvent";
            this.dtsOSAEvent.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // contentDataGridViewTextBoxColumn
            // 
            this.contentDataGridViewTextBoxColumn.DataPropertyName = "Content";
            this.contentDataGridViewTextBoxColumn.HeaderText = "Данные для события";
            this.contentDataGridViewTextBoxColumn.Name = "contentDataGridViewTextBoxColumn";
            this.contentDataGridViewTextBoxColumn.ReadOnly = true;
            this.contentDataGridViewTextBoxColumn.Width = 250;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "StatusId";
            this.Column3.DataSource = this.bsLogMessageStatus;
            this.Column3.DisplayMember = "Name";
            this.Column3.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.Column3.HeaderText = "Статус доставки";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.ValueMember = "Id";
            this.Column3.Width = 150;
            // 
            // bsLogMessageStatus
            // 
            this.bsLogMessageStatus.DataMember = "LogMessageStatus";
            this.bsLogMessageStatus.DataSource = this.dtsOSAEvent;
            // 
            // errorMessageDataGridViewTextBoxColumn
            // 
            this.errorMessageDataGridViewTextBoxColumn.DataPropertyName = "ErrorMessage";
            this.errorMessageDataGridViewTextBoxColumn.HeaderText = "Сообщение об ошибке";
            this.errorMessageDataGridViewTextBoxColumn.Name = "errorMessageDataGridViewTextBoxColumn";
            this.errorMessageDataGridViewTextBoxColumn.ReadOnly = true;
            this.errorMessageDataGridViewTextBoxColumn.Width = 250;
            // 
            // bsLogMessage
            // 
            this.bsLogMessage.DataMember = "LogMessage";
            this.bsLogMessage.DataSource = this.dtsOSAEvent;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1135, 571);
            this.Controls.Add(this.grdLogMessages);
            this.Controls.Add(this.tsMainMenu);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Журнал сообщений для сервиса ОСА";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tsMainMenu.ResumeLayout(false);
            this.tsMainMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdLogMessages)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsEventType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtsOSAEvent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsLogMessageStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsLogMessage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMainMenu;
        private System.Windows.Forms.DataGridView grdLogMessages;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.BindingSource bsLogMessage;
        private dtsOSAEvent dtsOSAEvent;
        private System.Windows.Forms.BindingSource bsLogMessageStatus;
        private System.Windows.Forms.BindingSource bsEventType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn externalIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn contentDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn errorMessageDataGridViewTextBoxColumn;
    }
}

