namespace Caelum.Banco
{
    partial class FrmArquivo
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
            this.cmdGravar = new System.Windows.Forms.Button();
            this.txtEditor = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cmdGravar
            // 
            this.cmdGravar.Location = new System.Drawing.Point(191, 390);
            this.cmdGravar.Name = "cmdGravar";
            this.cmdGravar.Size = new System.Drawing.Size(75, 23);
            this.cmdGravar.TabIndex = 0;
            this.cmdGravar.Text = "Gravar";
            this.cmdGravar.UseVisualStyleBackColor = true;
            this.cmdGravar.Click += new System.EventHandler(this.cmdGravar_Click);
            // 
            // txtEditor
            // 
            this.txtEditor.Location = new System.Drawing.Point(23, 33);
            this.txtEditor.Multiline = true;
            this.txtEditor.Name = "txtEditor";
            this.txtEditor.Size = new System.Drawing.Size(398, 331);
            this.txtEditor.TabIndex = 1;
            // 
            // FrmArquivo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 450);
            this.Controls.Add(this.txtEditor);
            this.Controls.Add(this.cmdGravar);
            this.Name = "FrmArquivo";
            this.Text = "Arquivo";
            this.Load += new System.EventHandler(this.FrmArquivo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdGravar;
        private System.Windows.Forms.TextBox txtEditor;
    }
}