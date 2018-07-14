namespace IRS_Preparers
{
    partial class IRS_Preparer_Tool
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
            this.BtnGetData = new System.Windows.Forms.Button();
            this.textField = new System.Windows.Forms.TextBox();
            this._web = new System.Windows.Forms.WebBrowser();
            this.label1 = new System.Windows.Forms.Label();
            this._comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnGetData
            // 
            this.BtnGetData.Location = new System.Drawing.Point(12, 38);
            this.BtnGetData.Name = "BtnGetData";
            this.BtnGetData.Size = new System.Drawing.Size(100, 23);
            this.BtnGetData.TabIndex = 0;
            this.BtnGetData.Text = "Submit";
            this.BtnGetData.UseVisualStyleBackColor = true;
            this.BtnGetData.Click += new System.EventHandler(this.BtnGetData_Click);
            // 
            // textField
            // 
            this.textField.Location = new System.Drawing.Point(12, 12);
            this.textField.MaxLength = 5;
            this.textField.Name = "textField";
            this.textField.Size = new System.Drawing.Size(100, 20);
            this.textField.TabIndex = 1;
            // 
            // _web
            // 
            this._web.Location = new System.Drawing.Point(187, 12);
            this._web.MinimumSize = new System.Drawing.Size(20, 20);
            this._web.Name = "_web";
            this._web.Size = new System.Drawing.Size(552, 543);
            this._web.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 131);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 3;
            this.label1.Click += new System.EventHandler(this.Label1_Click);
            // 
            // _comboBox1
            // 
            this._comboBox1.FormattingEnabled = true;
            this._comboBox1.Location = new System.Drawing.Point(12, 147);
            this._comboBox1.Name = "_comboBox1";
            this._comboBox1.Size = new System.Drawing.Size(121, 21);
            this._comboBox1.TabIndex = 4;
            this._comboBox1.Text = "Sort options";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 174);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(118, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Export";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // IRS_Preparer_Tool
            // 
            this.ClientSize = new System.Drawing.Size(751, 782);
            this.Controls.Add(this.button1);
            this.Controls.Add(this._comboBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._web);
            this.Controls.Add(this.textField);
            this.Controls.Add(this.BtnGetData);
            this.Name = "IRS_Preparer_Tool";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox zip_code;
        private System.Windows.Forms.Button load_button;
        private System.Windows.Forms.Label label_title;
        private System.Windows.Forms.Button BtnGetData;
        private System.Windows.Forms.TextBox textField;
        private System.Windows.Forms.WebBrowser _web;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox _comboBox1;
        private System.Windows.Forms.Button button1;
    }
}

