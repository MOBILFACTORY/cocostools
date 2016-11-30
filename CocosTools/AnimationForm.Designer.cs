
partial class AnimationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnimationForm));
            this.btnAddAnimation = new System.Windows.Forms.Button();
            this.listAnimation = new System.Windows.Forms.ListBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnMovePrev = new System.Windows.Forms.Button();
            this.listFrames = new System.Windows.Forms.ListView();
            this.checkBoxRestoreOriginalFrame = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDelay = new System.Windows.Forms.TextBox();
            this.listDir = new System.Windows.Forms.ListBox();
            this.labelName = new System.Windows.Forms.Label();
            this.btnRemoveAnimation = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtLoops = new System.Windows.Forms.TextBox();
            this.checkBoxLoop = new System.Windows.Forms.CheckBox();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnMoveNext = new System.Windows.Forms.Button();
            this.btnCopyFrame = new System.Windows.Forms.Button();
            this.btnDeleteFrame = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAddAnimation
            // 
            this.btnAddAnimation.BackColor = System.Drawing.Color.Gray;
            this.btnAddAnimation.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnAddAnimation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddAnimation.Font = new System.Drawing.Font("Bitstream Vera Sans Mono", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnAddAnimation.ForeColor = System.Drawing.Color.White;
            this.btnAddAnimation.Location = new System.Drawing.Point(463, 90);
            this.btnAddAnimation.Name = "btnAddAnimation";
            this.btnAddAnimation.Size = new System.Drawing.Size(80, 80);
            this.btnAddAnimation.TabIndex = 0;
            this.btnAddAnimation.Text = ">>\r\nAdd";
            this.btnAddAnimation.UseVisualStyleBackColor = false;
            this.btnAddAnimation.Click += new System.EventHandler(this.btnAddAnimation_Click);
            // 
            // listAnimation
            // 
            this.listAnimation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.listAnimation.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listAnimation.Font = new System.Drawing.Font("Bitstream Vera Sans Mono", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.listAnimation.ForeColor = System.Drawing.Color.White;
            this.listAnimation.FormattingEnabled = true;
            this.listAnimation.ItemHeight = 15;
            this.listAnimation.Location = new System.Drawing.Point(556, 27);
            this.listAnimation.Name = "listAnimation";
            this.listAnimation.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listAnimation.Size = new System.Drawing.Size(440, 345);
            this.listAnimation.TabIndex = 1;
            this.listAnimation.SelectedIndexChanged += new System.EventHandler(this.listAnimation_SelectedIndexChanged);
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.Gray;
            this.btnExport.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Bitstream Vera Sans Mono", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnExport.ForeColor = System.Drawing.Color.White;
            this.btnExport.Location = new System.Drawing.Point(893, 378);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(103, 36);
            this.btnExport.TabIndex = 7;
            this.btnExport.Text = "EXPORT";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnMovePrev
            // 
            this.btnMovePrev.BackColor = System.Drawing.Color.Gray;
            this.btnMovePrev.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnMovePrev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMovePrev.Font = new System.Drawing.Font("Bitstream Vera Sans Mono", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnMovePrev.ForeColor = System.Drawing.Color.White;
            this.btnMovePrev.Location = new System.Drawing.Point(637, 428);
            this.btnMovePrev.Name = "btnMovePrev";
            this.btnMovePrev.Size = new System.Drawing.Size(52, 23);
            this.btnMovePrev.TabIndex = 4;
            this.btnMovePrev.Text = "<<";
            this.btnMovePrev.UseVisualStyleBackColor = false;
            this.btnMovePrev.Click += new System.EventHandler(this.btnMovePrev_Click);
            // 
            // listFrames
            // 
            this.listFrames.BackColor = System.Drawing.Color.White;
            this.listFrames.BackgroundImage = global::CocosTools.Properties.Resources.CgWoU;
            this.listFrames.BackgroundImageTiled = true;
            this.listFrames.Font = new System.Drawing.Font("Bitstream Vera Sans Mono", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.listFrames.Location = new System.Drawing.Point(131, 457);
            this.listFrames.Name = "listFrames";
            this.listFrames.Size = new System.Drawing.Size(865, 93);
            this.listFrames.TabIndex = 8;
            this.listFrames.UseCompatibleStateImageBehavior = false;
            this.listFrames.SelectedIndexChanged += new System.EventHandler(this.listFrames_SelectedIndexChanged);
            // 
            // checkBoxRestoreOriginalFrame
            // 
            this.checkBoxRestoreOriginalFrame.AutoSize = true;
            this.checkBoxRestoreOriginalFrame.Font = new System.Drawing.Font("Bitstream Vera Sans Mono", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.checkBoxRestoreOriginalFrame.ForeColor = System.Drawing.Color.White;
            this.checkBoxRestoreOriginalFrame.Location = new System.Drawing.Point(379, 429);
            this.checkBoxRestoreOriginalFrame.Name = "checkBoxRestoreOriginalFrame";
            this.checkBoxRestoreOriginalFrame.Size = new System.Drawing.Size(202, 19);
            this.checkBoxRestoreOriginalFrame.TabIndex = 11;
            this.checkBoxRestoreOriginalFrame.Text = "Restore Original Frame";
            this.checkBoxRestoreOriginalFrame.UseVisualStyleBackColor = true;
            this.checkBoxRestoreOriginalFrame.CheckedChanged += new System.EventHandler(this.checkBoxRestoreOriginalFrame_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bitstream Vera Sans Mono", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(134, 429);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 15);
            this.label1.TabIndex = 13;
            this.label1.Text = "Delay";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bitstream Vera Sans Mono", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(254, 430);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 15);
            this.label2.TabIndex = 14;
            this.label2.Text = "Loops";
            // 
            // txtDelay
            // 
            this.txtDelay.Font = new System.Drawing.Font("Bitstream Vera Sans Mono", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtDelay.Location = new System.Drawing.Point(180, 426);
            this.txtDelay.MaxLength = 5;
            this.txtDelay.Name = "txtDelay";
            this.txtDelay.Size = new System.Drawing.Size(61, 23);
            this.txtDelay.TabIndex = 15;
            this.txtDelay.TextChanged += new System.EventHandler(this.txtDelay_TextChanged);
            // 
            // listDir
            // 
            this.listDir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.listDir.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listDir.Font = new System.Drawing.Font("Bitstream Vera Sans Mono", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.listDir.ForeColor = System.Drawing.Color.White;
            this.listDir.FormattingEnabled = true;
            this.listDir.ItemHeight = 15;
            this.listDir.Location = new System.Drawing.Point(12, 27);
            this.listDir.Name = "listDir";
            this.listDir.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listDir.Size = new System.Drawing.Size(440, 345);
            this.listDir.TabIndex = 17;
            this.listDir.SelectedIndexChanged += new System.EventHandler(this.listDir_SelectedIndexChanged);
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Bitstream Vera Sans Mono", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelName.ForeColor = System.Drawing.Color.White;
            this.labelName.Location = new System.Drawing.Point(134, 389);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(39, 15);
            this.labelName.TabIndex = 18;
            this.labelName.Text = "Name";
            // 
            // btnRemoveAnimation
            // 
            this.btnRemoveAnimation.BackColor = System.Drawing.Color.Gray;
            this.btnRemoveAnimation.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnRemoveAnimation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveAnimation.Font = new System.Drawing.Font("Bitstream Vera Sans Mono", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnRemoveAnimation.ForeColor = System.Drawing.Color.White;
            this.btnRemoveAnimation.Location = new System.Drawing.Point(463, 200);
            this.btnRemoveAnimation.Name = "btnRemoveAnimation";
            this.btnRemoveAnimation.Size = new System.Drawing.Size(80, 80);
            this.btnRemoveAnimation.TabIndex = 19;
            this.btnRemoveAnimation.Text = "<<\r\nRemove";
            this.btnRemoveAnimation.UseVisualStyleBackColor = false;
            this.btnRemoveAnimation.Click += new System.EventHandler(this.btnRemoveAnimation_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Bitstream Vera Sans Mono", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 15);
            this.label3.TabIndex = 20;
            this.label3.Text = "Directories";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Bitstream Vera Sans Mono", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(553, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 15);
            this.label4.TabIndex = 21;
            this.label4.Text = "Animations";
            // 
            // txtLoops
            // 
            this.txtLoops.Font = new System.Drawing.Font("Bitstream Vera Sans Mono", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtLoops.Location = new System.Drawing.Point(301, 425);
            this.txtLoops.MaxLength = 5;
            this.txtLoops.Name = "txtLoops";
            this.txtLoops.Size = new System.Drawing.Size(61, 23);
            this.txtLoops.TabIndex = 22;
            this.txtLoops.TextChanged += new System.EventHandler(this.txtLoops_TextChanged);
            // 
            // checkBoxLoop
            // 
            this.checkBoxLoop.AutoSize = true;
            this.checkBoxLoop.Font = new System.Drawing.Font("Bitstream Vera Sans Mono", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.checkBoxLoop.ForeColor = System.Drawing.Color.White;
            this.checkBoxLoop.Location = new System.Drawing.Point(301, 404);
            this.checkBoxLoop.Name = "checkBoxLoop";
            this.checkBoxLoop.Size = new System.Drawing.Size(82, 19);
            this.checkBoxLoop.TabIndex = 23;
            this.checkBoxLoop.Text = "Unlimit";
            this.checkBoxLoop.UseVisualStyleBackColor = true;
            this.checkBoxLoop.CheckedChanged += new System.EventHandler(this.checkBoxLoop_CheckedChanged);
            // 
            // txtFilter
            // 
            this.txtFilter.Font = new System.Drawing.Font("Bitstream Vera Sans Mono", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtFilter.Location = new System.Drawing.Point(614, 378);
            this.txtFilter.MaxLength = 5;
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(219, 23);
            this.txtFilter.TabIndex = 24;
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Bitstream Vera Sans Mono", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(556, 382);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 15);
            this.label5.TabIndex = 25;
            this.label5.Text = "Filter";
            // 
            // btnMoveNext
            // 
            this.btnMoveNext.BackColor = System.Drawing.Color.Gray;
            this.btnMoveNext.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnMoveNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMoveNext.Font = new System.Drawing.Font("Bitstream Vera Sans Mono", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnMoveNext.ForeColor = System.Drawing.Color.White;
            this.btnMoveNext.Location = new System.Drawing.Point(695, 428);
            this.btnMoveNext.Name = "btnMoveNext";
            this.btnMoveNext.Size = new System.Drawing.Size(52, 23);
            this.btnMoveNext.TabIndex = 26;
            this.btnMoveNext.Text = ">>";
            this.btnMoveNext.UseVisualStyleBackColor = false;
            this.btnMoveNext.Click += new System.EventHandler(this.btnMoveNext_Click);
            // 
            // btnCopyFrame
            // 
            this.btnCopyFrame.BackColor = System.Drawing.Color.Gray;
            this.btnCopyFrame.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnCopyFrame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopyFrame.Font = new System.Drawing.Font("Bitstream Vera Sans Mono", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCopyFrame.ForeColor = System.Drawing.Color.White;
            this.btnCopyFrame.Location = new System.Drawing.Point(770, 428);
            this.btnCopyFrame.Name = "btnCopyFrame";
            this.btnCopyFrame.Size = new System.Drawing.Size(52, 23);
            this.btnCopyFrame.TabIndex = 27;
            this.btnCopyFrame.Text = "COPY";
            this.btnCopyFrame.UseVisualStyleBackColor = false;
            this.btnCopyFrame.Click += new System.EventHandler(this.btnCopyFrame_Click);
            // 
            // btnDeleteFrame
            // 
            this.btnDeleteFrame.BackColor = System.Drawing.Color.Gray;
            this.btnDeleteFrame.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnDeleteFrame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteFrame.Font = new System.Drawing.Font("Bitstream Vera Sans Mono", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnDeleteFrame.ForeColor = System.Drawing.Color.White;
            this.btnDeleteFrame.Location = new System.Drawing.Point(828, 428);
            this.btnDeleteFrame.Name = "btnDeleteFrame";
            this.btnDeleteFrame.Size = new System.Drawing.Size(52, 23);
            this.btnDeleteFrame.TabIndex = 28;
            this.btnDeleteFrame.Text = "DEL";
            this.btnDeleteFrame.UseVisualStyleBackColor = false;
            this.btnDeleteFrame.Click += new System.EventHandler(this.btnDeleteFrame_Click);
            // 
            // AnimationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(1008, 562);
            this.Controls.Add(this.btnDeleteFrame);
            this.Controls.Add(this.btnCopyFrame);
            this.Controls.Add(this.btnMoveNext);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.checkBoxLoop);
            this.Controls.Add(this.txtLoops);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnRemoveAnimation);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.listAnimation);
            this.Controls.Add(this.btnAddAnimation);
            this.Controls.Add(this.listDir);
            this.Controls.Add(this.txtDelay);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBoxRestoreOriginalFrame);
            this.Controls.Add(this.listFrames);
            this.Controls.Add(this.btnMovePrev);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AnimationForm";
            this.Text = "Animation";
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button btnAddAnimation;
    private System.Windows.Forms.ListBox listAnimation;
    private System.Windows.Forms.Button btnMovePrev;
    private System.Windows.Forms.Button btnExport;
    private System.Windows.Forms.ListView listFrames;
    private System.Windows.Forms.CheckBox checkBoxRestoreOriginalFrame;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox txtDelay;
    private System.Windows.Forms.ListBox listDir;
    private System.Windows.Forms.Label labelName;
    private System.Windows.Forms.Button btnRemoveAnimation;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox txtLoops;
    private System.Windows.Forms.CheckBox checkBoxLoop;
    private System.Windows.Forms.TextBox txtFilter;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Button btnMoveNext;
    private System.Windows.Forms.Button btnCopyFrame;
    private System.Windows.Forms.Button btnDeleteFrame;
}