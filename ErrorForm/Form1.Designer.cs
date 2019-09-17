namespace ErrorForm
{
    partial class Form1
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
            this.excOnUI = new System.Windows.Forms.Button();
            this.excOnBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // excOnUI
            // 
            this.excOnUI.Location = new System.Drawing.Point(12, 12);
            this.excOnUI.Name = "excOnUI";
            this.excOnUI.Size = new System.Drawing.Size(181, 73);
            this.excOnUI.TabIndex = 0;
            this.excOnUI.Text = "Exception on UI thread";
            this.excOnUI.UseVisualStyleBackColor = true;
            this.excOnUI.Click += new System.EventHandler(this.ExcOnUI_Click);
            // 
            // excOnBack
            // 
            this.excOnBack.Location = new System.Drawing.Point(199, 12);
            this.excOnBack.Name = "excOnBack";
            this.excOnBack.Size = new System.Drawing.Size(181, 73);
            this.excOnBack.TabIndex = 1;
            this.excOnBack.Text = "Exception on Background Thread";
            this.excOnBack.UseVisualStyleBackColor = true;
            this.excOnBack.Click += new System.EventHandler(this.ExcOnBack_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 148);
            this.Controls.Add(this.excOnBack);
            this.Controls.Add(this.excOnUI);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button excOnUI;
        private System.Windows.Forms.Button excOnBack;
    }
}

