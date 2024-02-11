namespace DtoMapperPlugin.Controllers
{
    partial class FilteredSelectList
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FilteredSelectList));
            this.title = new System.Windows.Forms.Label();
            this.listView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.filtertextBox = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.selectAll = new System.Windows.Forms.ToolStripButton();
            this.clearSelection = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Dock = System.Windows.Forms.DockStyle.Top;
            this.title.Location = new System.Drawing.Point(0, 25);
            this.title.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(23, 13);
            this.title.TabIndex = 0;
            this.title.Text = "title";
            // 
            // listView
            // 
            this.listView.CheckBoxes = true;
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView.FullRowSelect = true;
            this.listView.HideSelection = false;
            this.listView.Location = new System.Drawing.Point(0, 58);
            this.listView.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(287, 322);
            this.listView.TabIndex = 1;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.ItemChecked);
            this.listView.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Logicalname";
            this.columnHeader1.Width = 369;
            // 
            // filtertextBox
            // 
            this.filtertextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.filtertextBox.Location = new System.Drawing.Point(0, 38);
            this.filtertextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.filtertextBox.Name = "filtertextBox";
            this.filtertextBox.Size = new System.Drawing.Size(287, 20);
            this.filtertextBox.TabIndex = 2;
            this.filtertextBox.TextChanged += new System.EventHandler(this.filterChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectAll,
            this.clearSelection});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(287, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // selectAll
            // 
            this.selectAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.selectAll.Image = ((System.Drawing.Image)(resources.GetObject("selectAll.Image")));
            this.selectAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.selectAll.Name = "selectAll";
            this.selectAll.Size = new System.Drawing.Size(59, 22);
            this.selectAll.Text = "Select All";
            this.selectAll.Click += new System.EventHandler(this.selectAll_Click);
            // 
            // clearSelection
            // 
            this.clearSelection.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.clearSelection.Image = ((System.Drawing.Image)(resources.GetObject("clearSelection.Image")));
            this.clearSelection.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.clearSelection.Name = "clearSelection";
            this.clearSelection.Size = new System.Drawing.Size(89, 22);
            this.clearSelection.Text = "Clear Selection";
            this.clearSelection.Click += new System.EventHandler(this.clearSelection_Click);
            // 
            // FilteredSelectList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listView);
            this.Controls.Add(this.filtertextBox);
            this.Controls.Add(this.title);
            this.Controls.Add(this.toolStrip1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FilteredSelectList";
            this.Size = new System.Drawing.Size(287, 380);
            this.Resize += new System.EventHandler(this.FilteredSelectList_Resize);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label title;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.TextBox filtertextBox;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton selectAll;
        private System.Windows.Forms.ToolStripButton clearSelection;
    }
}
