namespace ProcedureCreator
{
    partial class FrmProcedureCreator
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmProcedureCreator));
            this.panel1 = new System.Windows.Forms.Panel();
            this.gbOperation = new System.Windows.Forms.GroupBox();
            this.rbCRUD = new System.Windows.Forms.RadioButton();
            this.rbSelect = new System.Windows.Forms.RadioButton();
            this.rbDelete = new System.Windows.Forms.RadioButton();
            this.rbUpdate = new System.Windows.Forms.RadioButton();
            this.rbInsert = new System.Windows.Forms.RadioButton();
            this.txtTableName = new System.Windows.Forms.TextBox();
            this.btnGetInfo = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtInput = new System.Windows.Forms.RichTextBox();
            this.pnlCheckBox = new System.Windows.Forms.Panel();
            this.pnlResult = new System.Windows.Forms.Panel();
            this.txtResult = new System.Windows.Forms.RichTextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.gbOperation.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnlResult.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblDescription);
            this.panel1.Controls.Add(this.gbOperation);
            this.panel1.Controls.Add(this.txtTableName);
            this.panel1.Controls.Add(this.btnGetInfo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1251, 79);
            this.panel1.TabIndex = 0;
            // 
            // gbOperation
            // 
            this.gbOperation.Controls.Add(this.rbCRUD);
            this.gbOperation.Controls.Add(this.rbSelect);
            this.gbOperation.Controls.Add(this.rbDelete);
            this.gbOperation.Controls.Add(this.rbUpdate);
            this.gbOperation.Controls.Add(this.rbInsert);
            this.gbOperation.Location = new System.Drawing.Point(555, 11);
            this.gbOperation.Name = "gbOperation";
            this.gbOperation.Size = new System.Drawing.Size(520, 62);
            this.gbOperation.TabIndex = 6;
            this.gbOperation.TabStop = false;
            this.gbOperation.Text = "Select Operation...";
            // 
            // rbCRUD
            // 
            this.rbCRUD.AutoSize = true;
            this.rbCRUD.Location = new System.Drawing.Point(432, 35);
            this.rbCRUD.Name = "rbCRUD";
            this.rbCRUD.Size = new System.Drawing.Size(60, 21);
            this.rbCRUD.TabIndex = 4;
            this.rbCRUD.TabStop = true;
            this.rbCRUD.Text = "CRUD";
            this.rbCRUD.UseVisualStyleBackColor = true;
            this.rbCRUD.CheckedChanged += new System.EventHandler(this.OperationChange);
            // 
            // rbSelect
            // 
            this.rbSelect.AutoSize = true;
            this.rbSelect.Location = new System.Drawing.Point(328, 35);
            this.rbSelect.Name = "rbSelect";
            this.rbSelect.Size = new System.Drawing.Size(60, 21);
            this.rbSelect.TabIndex = 3;
            this.rbSelect.TabStop = true;
            this.rbSelect.Text = "Select";
            this.rbSelect.UseVisualStyleBackColor = true;
            this.rbSelect.CheckedChanged += new System.EventHandler(this.OperationChange);
            // 
            // rbDelete
            // 
            this.rbDelete.AutoSize = true;
            this.rbDelete.Location = new System.Drawing.Point(221, 35);
            this.rbDelete.Name = "rbDelete";
            this.rbDelete.Size = new System.Drawing.Size(63, 21);
            this.rbDelete.TabIndex = 2;
            this.rbDelete.TabStop = true;
            this.rbDelete.Text = "Delete";
            this.rbDelete.UseVisualStyleBackColor = true;
            this.rbDelete.CheckedChanged += new System.EventHandler(this.OperationChange);
            // 
            // rbUpdate
            // 
            this.rbUpdate.AutoSize = true;
            this.rbUpdate.Location = new System.Drawing.Point(108, 35);
            this.rbUpdate.Name = "rbUpdate";
            this.rbUpdate.Size = new System.Drawing.Size(69, 21);
            this.rbUpdate.TabIndex = 1;
            this.rbUpdate.TabStop = true;
            this.rbUpdate.Text = "Update";
            this.rbUpdate.UseVisualStyleBackColor = true;
            this.rbUpdate.CheckedChanged += new System.EventHandler(this.OperationChange);
            // 
            // rbInsert
            // 
            this.rbInsert.AutoSize = true;
            this.rbInsert.Location = new System.Drawing.Point(6, 35);
            this.rbInsert.Name = "rbInsert";
            this.rbInsert.Size = new System.Drawing.Size(58, 21);
            this.rbInsert.TabIndex = 0;
            this.rbInsert.TabStop = true;
            this.rbInsert.Text = "Insert";
            this.rbInsert.UseVisualStyleBackColor = true;
            this.rbInsert.CheckedChanged += new System.EventHandler(this.OperationChange);
            // 
            // txtTableName
            // 
            this.txtTableName.Location = new System.Drawing.Point(274, 50);
            this.txtTableName.Name = "txtTableName";
            this.txtTableName.Size = new System.Drawing.Size(275, 25);
            this.txtTableName.TabIndex = 4;
            // 
            // btnGetInfo
            // 
            this.btnGetInfo.Location = new System.Drawing.Point(274, 12);
            this.btnGetInfo.Name = "btnGetInfo";
            this.btnGetInfo.Size = new System.Drawing.Size(275, 32);
            this.btnGetInfo.TabIndex = 3;
            this.btnGetInfo.Text = "<---Get Columns--->";
            this.btnGetInfo.UseVisualStyleBackColor = true;
            this.btnGetInfo.Click += new System.EventHandler(this.btnGetInfo_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtInput);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 79);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(274, 509);
            this.panel2.TabIndex = 1;
            // 
            // txtInput
            // 
            this.txtInput.BackColor = System.Drawing.Color.White;
            this.txtInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtInput.Location = new System.Drawing.Point(0, 0);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(274, 509);
            this.txtInput.TabIndex = 2;
            this.txtInput.Text = resources.GetString("txtInput.Text");
            // 
            // pnlCheckBox
            // 
            this.pnlCheckBox.AutoScroll = true;
            this.pnlCheckBox.BackColor = System.Drawing.SystemColors.Highlight;
            this.pnlCheckBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlCheckBox.Location = new System.Drawing.Point(274, 79);
            this.pnlCheckBox.Name = "pnlCheckBox";
            this.pnlCheckBox.Size = new System.Drawing.Size(275, 509);
            this.pnlCheckBox.TabIndex = 2;
            // 
            // pnlResult
            // 
            this.pnlResult.Controls.Add(this.txtResult);
            this.pnlResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlResult.Location = new System.Drawing.Point(549, 79);
            this.pnlResult.Name = "pnlResult";
            this.pnlResult.Size = new System.Drawing.Size(702, 509);
            this.pnlResult.TabIndex = 3;
            // 
            // txtResult
            // 
            this.txtResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtResult.Location = new System.Drawing.Point(0, 0);
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(702, 509);
            this.txtResult.TabIndex = 0;
            this.txtResult.Text = "";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(12, 50);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(213, 17);
            this.lblDescription.TabIndex = 7;
            this.lblDescription.Text = "Table->Right Click->Script Table As";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1251, 588);
            this.Controls.Add(this.pnlResult);
            this.Controls.Add(this.pnlCheckBox);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "Procedure Creator";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.gbOperation.ResumeLayout(false);
            this.gbOperation.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.pnlResult.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RichTextBox txtInput;
        private System.Windows.Forms.TextBox txtTableName;
        private System.Windows.Forms.Button btnGetInfo;
        private System.Windows.Forms.Panel pnlCheckBox;
        private System.Windows.Forms.Panel pnlResult;
        private System.Windows.Forms.RichTextBox txtResult;
        private System.Windows.Forms.GroupBox gbOperation;
        private System.Windows.Forms.RadioButton rbCRUD;
        private System.Windows.Forms.RadioButton rbSelect;
        private System.Windows.Forms.RadioButton rbDelete;
        private System.Windows.Forms.RadioButton rbUpdate;
        private System.Windows.Forms.RadioButton rbInsert;
        private System.Windows.Forms.Label lblDescription;
    }
}

