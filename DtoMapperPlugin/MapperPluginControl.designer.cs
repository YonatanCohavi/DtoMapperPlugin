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
            this.cleanupRegex = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStripMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
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
            this.toolStripMenu.Size = new System.Drawing.Size(867, 25);
            this.toolStripMenu.TabIndex = 4;
            this.toolStripMenu.Text = "toolStrip1";
            // 
            // tssSeparator1
            // 
            this.tssSeparator1.Name = "tssSeparator1";
            this.tssSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbSample
            // 
            this.tsbSample.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbSample.Name = "tsbSample";
            this.tsbSample.Size = new System.Drawing.Size(36, 22);
            this.tsbSample.Text = "Help";
            this.tsbSample.Click += new System.EventHandler(this.tsbSample_Click);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(196, 25);
            this.splitter1.Margin = new System.Windows.Forms.Padding(2);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(2, 388);
            this.splitter1.TabIndex = 8;
            this.splitter1.TabStop = false;
            // 
            // splitter2
            // 
            this.splitter2.Location = new System.Drawing.Point(527, 25);
            this.splitter2.Margin = new System.Windows.Forms.Padding(2);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(2, 388);
            this.splitter2.TabIndex = 9;
            this.splitter2.TabStop = false;
            // 
            // codeTextbox
            // 
            this.codeTextbox.Code = "";
            this.codeTextbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.codeTextbox.Language = FastColoredTextBoxNS.Language.CSharp;
            this.codeTextbox.Location = new System.Drawing.Point(0, 52);
            this.codeTextbox.Margin = new System.Windows.Forms.Padding(1);
            this.codeTextbox.Name = "codeTextbox";
            this.codeTextbox.Size = new System.Drawing.Size(338, 336);
            this.codeTextbox.TabIndex = 7;
            // 
            // attributesList
            // 
            this.attributesList.CheckBoxes = true;
            this.attributesList.Dock = System.Windows.Forms.DockStyle.Left;
            this.attributesList.HasType = true;
            this.attributesList.Location = new System.Drawing.Point(198, 25);
            this.attributesList.Margin = new System.Windows.Forms.Padding(1);
            this.attributesList.Name = "attributesList";
            this.attributesList.Size = new System.Drawing.Size(329, 388);
            this.attributesList.TabIndex = 6;
            this.attributesList.Title = "Attributes";
            // 
            // entitilesList
            // 
            this.entitilesList.CheckBoxes = false;
            this.entitilesList.Dock = System.Windows.Forms.DockStyle.Left;
            this.entitilesList.HasType = false;
            this.entitilesList.Location = new System.Drawing.Point(0, 25);
            this.entitilesList.Margin = new System.Windows.Forms.Padding(1);
            this.entitilesList.Name = "entitilesList";
            this.entitilesList.Size = new System.Drawing.Size(196, 388);
            this.entitilesList.TabIndex = 5;
            this.entitilesList.Title = "Entities";
            // 
            // cleanupRegex
            // 
            this.cleanupRegex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cleanupRegex.Font = new System.Drawing.Font("JetBrains Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cleanupRegex.Location = new System.Drawing.Point(3, 23);
            this.cleanupRegex.Name = "cleanupRegex";
            this.cleanupRegex.Size = new System.Drawing.Size(332, 29);
            this.cleanupRegex.TabIndex = 10;
            this.cleanupRegex.Text = "[^_]*_";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.codeTextbox);
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(529, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(338, 388);
            this.panel1.TabIndex = 11;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.cleanupRegex);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(338, 52);
            this.flowLayoutPanel1.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 20);
            this.label1.TabIndex = 11;
            this.label1.Text = "Property Cleanup Regex";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MapperPluginControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.splitter2);
            this.Controls.Add(this.attributesList);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.entitilesList);
            this.Controls.Add(this.toolStripMenu);
            this.Name = "MapperPluginControl";
            this.Size = new System.Drawing.Size(867, 413);
            this.Load += new System.EventHandler(this.MyPluginControl_Load);
            this.toolStripMenu.ResumeLayout(false);
            this.toolStripMenu.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
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
        private System.Windows.Forms.TextBox cleanupRegex;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}
