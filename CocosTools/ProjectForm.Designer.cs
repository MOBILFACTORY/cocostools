
partial class CocosToolsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CocosToolsForm));
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableAtlasList = new System.Windows.Forms.TableLayoutPanel();
            this.listAtlas = new System.Windows.Forms.ListBox();
            this.labelAtlas = new System.Windows.Forms.Label();
            this.btnAtlasAdd = new System.Windows.Forms.Button();
            this.imgAtlas = new CocosTools.Atlas.BitmapBox();
            this.imgAnchor = new System.Windows.Forms.PictureBox();
            this.checkBoxCopyBorder = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.numPadding = new System.Windows.Forms.NumericUpDown();
            this.imgSprite = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numOffsetY = new System.Windows.Forms.NumericUpDown();
            this.numOffsetX = new System.Windows.Forms.NumericUpDown();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.menuItemProject = new System.Windows.Forms.ToolStripMenuItem();
            this.newProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemView = new System.Windows.Forms.ToolStripMenuItem();
            this.atlasListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fontsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.encryptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.alliesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enemiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listSprites = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableAtlasList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgAtlas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgAnchor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPadding)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgSprite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOffsetY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOffsetX)).BeginInit();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bitstream Vera Sans Mono", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(15, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Atlas";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Gray;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Bitstream Vera Sans Mono", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button1.Location = new System.Drawing.Point(14, 434);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 33);
            this.button1.TabIndex = 0;
            this.button1.Text = "Export";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.Gray;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer1.Panel1.Controls.Add(this.tableAtlasList);
            this.splitContainer1.Panel1.Controls.Add(this.imgAtlas);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.splitContainer1.Panel2.Controls.Add(this.listSprites);
            this.splitContainer1.Panel2.Controls.Add(this.imgAnchor);
            this.splitContainer1.Panel2.Controls.Add(this.checkBoxCopyBorder);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Panel2.Controls.Add(this.numPadding);
            this.splitContainer1.Panel2.Controls.Add(this.imgSprite);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.numOffsetY);
            this.splitContainer1.Panel2.Controls.Add(this.numOffsetX);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.button1);
            this.splitContainer1.Size = new System.Drawing.Size(1008, 706);
            this.splitContainer1.SplitterDistance = 773;
            this.splitContainer1.SplitterIncrement = 2;
            this.splitContainer1.SplitterWidth = 10;
            this.splitContainer1.TabIndex = 2;
            this.splitContainer1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer1_SplitterMoved);
            // 
            // tableAtlasList
            // 
            this.tableAtlasList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tableAtlasList.ColumnCount = 1;
            this.tableAtlasList.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableAtlasList.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableAtlasList.Controls.Add(this.listAtlas, 0, 1);
            this.tableAtlasList.Controls.Add(this.labelAtlas, 0, 0);
            this.tableAtlasList.Controls.Add(this.btnAtlasAdd, 0, 2);
            this.tableAtlasList.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableAtlasList.Location = new System.Drawing.Point(0, 0);
            this.tableAtlasList.Name = "tableAtlasList";
            this.tableAtlasList.RowCount = 3;
            this.tableAtlasList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.982543F));
            this.tableAtlasList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 93.01746F));
            this.tableAtlasList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableAtlasList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableAtlasList.Size = new System.Drawing.Size(120, 706);
            this.tableAtlasList.TabIndex = 3;
            // 
            // listAtlas
            // 
            this.listAtlas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.listAtlas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listAtlas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listAtlas.Font = new System.Drawing.Font("Bitstream Vera Sans Mono", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.listAtlas.ForeColor = System.Drawing.SystemColors.Window;
            this.listAtlas.FormattingEnabled = true;
            this.listAtlas.ItemHeight = 15;
            this.listAtlas.Location = new System.Drawing.Point(0, 46);
            this.listAtlas.Margin = new System.Windows.Forms.Padding(0);
            this.listAtlas.Name = "listAtlas";
            this.listAtlas.Size = new System.Drawing.Size(120, 614);
            this.listAtlas.TabIndex = 1;
            this.listAtlas.SelectedIndexChanged += new System.EventHandler(this.listAtlas_SelectedIndexChanged);
            // 
            // labelAtlas
            // 
            this.labelAtlas.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelAtlas.AutoSize = true;
            this.labelAtlas.Font = new System.Drawing.Font("Bitstream Vera Sans Mono", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelAtlas.ForeColor = System.Drawing.Color.White;
            this.labelAtlas.Location = new System.Drawing.Point(36, 15);
            this.labelAtlas.Name = "labelAtlas";
            this.labelAtlas.Size = new System.Drawing.Size(47, 15);
            this.labelAtlas.TabIndex = 3;
            this.labelAtlas.Text = "Atlas";
            this.labelAtlas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAtlasAdd
            // 
            this.btnAtlasAdd.BackColor = System.Drawing.Color.Gray;
            this.btnAtlasAdd.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnAtlasAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAtlasAdd.Font = new System.Drawing.Font("Bitstream Vera Sans Mono", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAtlasAdd.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnAtlasAdd.Location = new System.Drawing.Point(3, 663);
            this.btnAtlasAdd.Name = "btnAtlasAdd";
            this.btnAtlasAdd.Size = new System.Drawing.Size(114, 40);
            this.btnAtlasAdd.TabIndex = 4;
            this.btnAtlasAdd.Text = "Add";
            this.btnAtlasAdd.UseVisualStyleBackColor = false;
            this.btnAtlasAdd.Click += new System.EventHandler(this.btnAtlasAdd_Click);
            // 
            // imgAtlas
            // 
            this.imgAtlas.BackColor = System.Drawing.Color.Transparent;
            this.imgAtlas.BackgroundImage = global::CocosTools.Properties.Resources.CgWoU;
            this.imgAtlas.Location = new System.Drawing.Point(120, 0);
            this.imgAtlas.Margin = new System.Windows.Forms.Padding(0);
            this.imgAtlas.Name = "imgAtlas";
            this.imgAtlas.Size = new System.Drawing.Size(200, 200);
            this.imgAtlas.TabIndex = 0;
            this.imgAtlas.TabStop = false;
            this.imgAtlas.MouseClick += new System.Windows.Forms.MouseEventHandler(this.imgAtlas_MouseClick);
            this.imgAtlas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.imgAtlas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.imgAtlas_MouseMove);
            this.imgAtlas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.imgAtlas_MouseUp);
            // 
            // imgAnchor
            // 
            this.imgAnchor.Image = ((System.Drawing.Image)(resources.GetObject("imgAnchor.Image")));
            this.imgAnchor.Location = new System.Drawing.Point(157, 166);
            this.imgAnchor.Name = "imgAnchor";
            this.imgAnchor.Size = new System.Drawing.Size(5, 5);
            this.imgAnchor.TabIndex = 12;
            this.imgAnchor.TabStop = false;
            this.imgAnchor.Visible = false;
            // 
            // checkBoxCopyBorder
            // 
            this.checkBoxCopyBorder.AutoSize = true;
            this.checkBoxCopyBorder.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxCopyBorder.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxCopyBorder.Font = new System.Drawing.Font("Bitstream Vera Sans Mono", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.checkBoxCopyBorder.ForeColor = System.Drawing.Color.White;
            this.checkBoxCopyBorder.Location = new System.Drawing.Point(14, 69);
            this.checkBoxCopyBorder.Name = "checkBoxCopyBorder";
            this.checkBoxCopyBorder.Size = new System.Drawing.Size(114, 19);
            this.checkBoxCopyBorder.TabIndex = 11;
            this.checkBoxCopyBorder.Text = "Copy Border";
            this.checkBoxCopyBorder.UseVisualStyleBackColor = false;
            this.checkBoxCopyBorder.CheckedChanged += new System.EventHandler(this.checkBoxCopyBorder_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Bitstream Vera Sans Mono", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(15, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "Padding";
            // 
            // numPadding
            // 
            this.numPadding.Font = new System.Drawing.Font("Bitstream Vera Sans Mono", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.numPadding.Location = new System.Drawing.Point(92, 39);
            this.numPadding.Name = "numPadding";
            this.numPadding.Size = new System.Drawing.Size(70, 21);
            this.numPadding.TabIndex = 8;
            this.numPadding.ValueChanged += new System.EventHandler(this.numPadding_ValueChanged);
            // 
            // imgSprite
            // 
            this.imgSprite.Location = new System.Drawing.Point(17, 115);
            this.imgSprite.Name = "imgSprite";
            this.imgSprite.Size = new System.Drawing.Size(145, 142);
            this.imgSprite.TabIndex = 7;
            this.imgSprite.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Bitstream Vera Sans Mono", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(15, 299);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Offset Y";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bitstream Vera Sans Mono", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(15, 264);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Offset X";
            // 
            // numOffsetY
            // 
            this.numOffsetY.Font = new System.Drawing.Font("Bitstream Vera Sans Mono", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.numOffsetY.Location = new System.Drawing.Point(92, 299);
            this.numOffsetY.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numOffsetY.Name = "numOffsetY";
            this.numOffsetY.Size = new System.Drawing.Size(70, 21);
            this.numOffsetY.TabIndex = 3;
            this.numOffsetY.ValueChanged += new System.EventHandler(this.offsetY_ValueChanged);
            // 
            // numOffsetX
            // 
            this.numOffsetX.Font = new System.Drawing.Font("Bitstream Vera Sans Mono", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.numOffsetX.Location = new System.Drawing.Point(92, 263);
            this.numOffsetX.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numOffsetX.Name = "numOffsetX";
            this.numOffsetX.Size = new System.Drawing.Size(70, 21);
            this.numOffsetX.TabIndex = 2;
            this.numOffsetX.ValueChanged += new System.EventHandler(this.offsetY_ValueChanged);
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemProject,
            this.menuItemView});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(1008, 24);
            this.menu.TabIndex = 3;
            this.menu.Text = "menuStrip1";
            // 
            // menuItemProject
            // 
            this.menuItemProject.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newProjectToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem1});
            this.menuItemProject.Name = "menuItemProject";
            this.menuItemProject.Size = new System.Drawing.Size(66, 20);
            this.menuItemProject.Text = "PROJECT";
            // 
            // newProjectToolStripMenuItem
            // 
            this.newProjectToolStripMenuItem.Name = "newProjectToolStripMenuItem";
            this.newProjectToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.newProjectToolStripMenuItem.Text = "New";
            this.newProjectToolStripMenuItem.Click += new System.EventHandler(this.newProjectToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem1
            // 
            this.saveToolStripMenuItem1.Name = "saveToolStripMenuItem1";
            this.saveToolStripMenuItem1.Size = new System.Drawing.Size(103, 22);
            this.saveToolStripMenuItem1.Text = "Save";
            this.saveToolStripMenuItem1.Click += new System.EventHandler(this.saveToolStripMenuItem1_Click);
            // 
            // menuItemView
            // 
            this.menuItemView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.atlasListToolStripMenuItem,
            this.fontsToolStripMenuItem,
            this.encryptToolStripMenuItem,
            this.toolStripSeparator1,
            this.alliesToolStripMenuItem,
            this.enemiesToolStripMenuItem});
            this.menuItemView.Name = "menuItemView";
            this.menuItemView.Size = new System.Drawing.Size(47, 20);
            this.menuItemView.Text = "VIEW";
            // 
            // atlasListToolStripMenuItem
            // 
            this.atlasListToolStripMenuItem.Name = "atlasListToolStripMenuItem";
            this.atlasListToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.atlasListToolStripMenuItem.Text = "Animations";
            this.atlasListToolStripMenuItem.Click += new System.EventHandler(this.atlasListToolStripMenuItem_Click);
            // 
            // fontsToolStripMenuItem
            // 
            this.fontsToolStripMenuItem.Name = "fontsToolStripMenuItem";
            this.fontsToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.fontsToolStripMenuItem.Text = "Fonts";
            this.fontsToolStripMenuItem.Click += new System.EventHandler(this.fontsToolStripMenuItem_Click);
            // 
            // encryptToolStripMenuItem
            // 
            this.encryptToolStripMenuItem.Name = "encryptToolStripMenuItem";
            this.encryptToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.encryptToolStripMenuItem.Text = "Encrypt";
            this.encryptToolStripMenuItem.Click += new System.EventHandler(this.encryptToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(132, 6);
            // 
            // alliesToolStripMenuItem
            // 
            this.alliesToolStripMenuItem.Name = "alliesToolStripMenuItem";
            this.alliesToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.alliesToolStripMenuItem.Text = "Allies";
            this.alliesToolStripMenuItem.Click += new System.EventHandler(this.alliesToolStripMenuItem_Click);
            // 
            // enemiesToolStripMenuItem
            // 
            this.enemiesToolStripMenuItem.Name = "enemiesToolStripMenuItem";
            this.enemiesToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.enemiesToolStripMenuItem.Text = "Enemies";
            this.enemiesToolStripMenuItem.Click += new System.EventHandler(this.enemiesToolStripMenuItem_Click);
            // 
            // listSprites
            // 
            this.listSprites.FormattingEnabled = true;
            this.listSprites.ItemHeight = 12;
            this.listSprites.Location = new System.Drawing.Point(18, 332);
            this.listSprites.Name = "listSprites";
            this.listSprites.Size = new System.Drawing.Size(144, 88);
            this.listSprites.TabIndex = 13;
            this.listSprites.SelectedIndexChanged += new System.EventHandler(this.listSprites_SelectedIndexChanged);
            // 
            // CocosToolsForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menu);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CocosToolsForm";
            this.Text = "CocosTools";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableAtlasList.ResumeLayout(false);
            this.tableAtlasList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgAtlas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgAnchor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPadding)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgSprite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOffsetY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOffsetX)).EndInit();
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.SplitContainer splitContainer1;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.NumericUpDown numOffsetY;
    private System.Windows.Forms.NumericUpDown numOffsetX;
    private System.Windows.Forms.PictureBox imgSprite;
    private System.Windows.Forms.ListBox listAtlas;
    private System.Windows.Forms.TableLayoutPanel tableAtlasList;
    private System.Windows.Forms.Label labelAtlas;
    private System.Windows.Forms.Button btnAtlasAdd;
    private System.Windows.Forms.MenuStrip menu;
    private System.Windows.Forms.ToolStripMenuItem menuItemProject;
    private System.Windows.Forms.ToolStripMenuItem menuItemView;
    private System.Windows.Forms.ToolStripMenuItem newProjectToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem1;
    private System.Windows.Forms.CheckBox checkBoxCopyBorder;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.NumericUpDown numPadding;
    private System.Windows.Forms.PictureBox imgAnchor;
    private System.Windows.Forms.ToolStripMenuItem fontsToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem encryptToolStripMenuItem;
    private CocosTools.Atlas.BitmapBox imgAtlas;
    private System.Windows.Forms.ToolStripMenuItem atlasListToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    private System.Windows.Forms.ToolStripMenuItem alliesToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem enemiesToolStripMenuItem;
    private System.Windows.Forms.ListBox listSprites;
}

