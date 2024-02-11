namespace DtoMapperPlugin
{
    partial class SettingsForm
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
            this.codebox = new DtoMapperPlugin.Controllers.Codebox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.dockPanel1 = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.btn_saveclose = new System.Windows.Forms.Button();
            this.chk_onelineattributes = new System.Windows.Forms.CheckBox();
            this.chk_onelinenotes = new System.Windows.Forms.CheckBox();
            this.chk_notes = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // codebox
            // 
            this.codebox.Code = "";
            this.codebox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.codebox.Language = FastColoredTextBoxNS.Language.CSharp;
            this.codebox.Location = new System.Drawing.Point(203, 0);
            this.codebox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.codebox.Name = "codebox";
            this.codebox.Size = new System.Drawing.Size(597, 450);
            this.codebox.TabIndex = 4;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(200, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 450);
            this.splitter1.TabIndex = 5;
            this.splitter1.TabStop = false;
            // 
            // dockPanel1
            // 
            this.dockPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.dockPanel1.Location = new System.Drawing.Point(0, 0);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.Size = new System.Drawing.Size(200, 450);
            this.dockPanel1.TabIndex = 6;
            // 
            // btn_saveclose
            // 
            this.btn_saveclose.Location = new System.Drawing.Point(9, 91);
            this.btn_saveclose.Name = "btn_saveclose";
            this.btn_saveclose.Size = new System.Drawing.Size(109, 23);
            this.btn_saveclose.TabIndex = 11;
            this.btn_saveclose.Text = "Save And Close";
            this.btn_saveclose.UseVisualStyleBackColor = true;
            this.btn_saveclose.Click += new System.EventHandler(this.btn_saveclose_Click);
            // 
            // chk_onelineattributes
            // 
            this.chk_onelineattributes.AutoSize = true;
            this.chk_onelineattributes.Location = new System.Drawing.Point(12, 57);
            this.chk_onelineattributes.Name = "chk_onelineattributes";
            this.chk_onelineattributes.Size = new System.Drawing.Size(167, 17);
            this.chk_onelineattributes.TabIndex = 10;
            this.chk_onelineattributes.Text = "Generate attributes in one line";
            this.chk_onelineattributes.UseVisualStyleBackColor = true;
            // 
            // chk_onelinenotes
            // 
            this.chk_onelinenotes.AutoSize = true;
            this.chk_onelinenotes.Location = new System.Drawing.Point(29, 34);
            this.chk_onelinenotes.Name = "chk_onelinenotes";
            this.chk_onelinenotes.Size = new System.Drawing.Size(150, 17);
            this.chk_onelinenotes.TabIndex = 9;
            this.chk_onelinenotes.Text = "Generate notes in one line";
            this.chk_onelinenotes.UseVisualStyleBackColor = true;
            // 
            // chk_notes
            // 
            this.chk_notes.AutoSize = true;
            this.chk_notes.Location = new System.Drawing.Point(12, 12);
            this.chk_notes.Name = "chk_notes";
            this.chk_notes.Size = new System.Drawing.Size(99, 17);
            this.chk_notes.TabIndex = 8;
            this.chk_notes.Text = "Generate notes";
            this.chk_notes.UseVisualStyleBackColor = true;
            this.chk_notes.CheckedChanged += new System.EventHandler(this.chk_notes_CheckedChanged);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.codebox);
            this.Controls.Add(this.btn_saveclose);
            this.Controls.Add(this.chk_onelineattributes);
            this.Controls.Add(this.chk_onelinenotes);
            this.Controls.Add(this.chk_notes);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.dockPanel1);
            this.Name = "SettingsForm";
            this.Text = "Generation Settigns Settings";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Controllers.Codebox codebox;
        private System.Windows.Forms.Splitter splitter1;
        private WeifenLuo.WinFormsUI.Docking.DockPanel dockPanel1;
        private System.Windows.Forms.Button btn_saveclose;
        private System.Windows.Forms.CheckBox chk_onelineattributes;
        private System.Windows.Forms.CheckBox chk_onelinenotes;
        private System.Windows.Forms.CheckBox chk_notes;
    }
}