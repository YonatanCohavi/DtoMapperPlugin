namespace DtoMapperPlugin
{
    partial class MapperPluginControl
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.toolStripMenu = new System.Windows.Forms.ToolStrip();
            this.tssSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbSample = new System.Windows.Forms.ToolStripButton();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.codeTextbox = new DtoMapperPlugin.Controllers.Codebox();
            this.attributesList = new DtoMapperPlugin.Controllers.FilteredSelectList();
            this.entitilesList = new DtoMapperPlugin.Controllers.FilteredSelectList();
            this.toolStripMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripMenu
            // 
            this.toolStripMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssSeparator1,
            this.tsbSample});
            this.toolStripMenu.Location = new System.Drawing.Point(0, 0);
            this.toolStripMenu.Name = "toolStripMenu";
            this.toolStripMenu.Size = new System.Drawing.Size(1300, 34);
            this.toolStripMenu.TabIndex = 4;
            this.toolStripMenu.Text = "toolStrip1";
            // 
            // tssSeparator1
            // 
            this.tssSeparator1.Name = "tssSeparator1";
            this.tssSeparator1.Size = new System.Drawing.Size(6, 34);
            // 
            // tsbSample
            // 
            this.tsbSample.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbSample.Name = "tsbSample";
            this.tsbSample.Size = new System.Drawing.Size(53, 29);
            this.tsbSample.Text = "Help";
            this.tsbSample.Click += new System.EventHandler(this.tsbSample_Click);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(294, 34);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 602);
            this.splitter1.TabIndex = 8;
            this.splitter1.TabStop = false;
            // 
            // splitter2
            // 
            this.splitter2.Location = new System.Drawing.Point(791, 34);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(3, 602);
            this.splitter2.TabIndex = 9;
            this.splitter2.TabStop = false;
            // 
            // codeTextbox
            // 
            this.codeTextbox.Code = "";
            this.codeTextbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.codeTextbox.Language = FastColoredTextBoxNS.Language.CSharp;
            this.codeTextbox.Location = new System.Drawing.Point(794, 34);
            this.codeTextbox.Name = "codeTextbox";
            this.codeTextbox.Size = new System.Drawing.Size(506, 602);
            this.codeTextbox.TabIndex = 7;
            // 
            // attributesList
            // 
            this.attributesList.CheckBoxes = true;
            this.attributesList.Dock = System.Windows.Forms.DockStyle.Left;
            this.attributesList.HasType = true;
            this.attributesList.Location = new System.Drawing.Point(297, 34);
            this.attributesList.Name = "attributesList";
            this.attributesList.Size = new System.Drawing.Size(494, 602);
            this.attributesList.TabIndex = 6;
            this.attributesList.Title = "Attributes";
            // 
            // entitilesList
            // 
            this.entitilesList.CheckBoxes = false;
            this.entitilesList.Dock = System.Windows.Forms.DockStyle.Left;
            this.entitilesList.HasType = false;
            this.entitilesList.Location = new System.Drawing.Point(0, 34);
            this.entitilesList.Name = "entitilesList";
            this.entitilesList.Size = new System.Drawing.Size(294, 602);
            this.entitilesList.TabIndex = 5;
            this.entitilesList.Title = "Entities";
            // 
            // MapperPluginControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.codeTextbox);
            this.Controls.Add(this.splitter2);
            this.Controls.Add(this.attributesList);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.entitilesList);
            this.Controls.Add(this.toolStripMenu);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MapperPluginControl";
            this.Size = new System.Drawing.Size(1300, 636);
            this.Load += new System.EventHandler(this.MyPluginControl_Load);
            this.toolStripMenu.ResumeLayout(false);
            this.toolStripMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStripMenu;
        private System.Windows.Forms.ToolStripButton tsbSample;
        private System.Windows.Forms.ToolStripSeparator tssSeparator1;
        private Controllers.FilteredSelectList entitilesList;
        private Controllers.FilteredSelectList attributesList;
        private Controllers.Codebox codeTextbox;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Splitter splitter2;
    }
}
