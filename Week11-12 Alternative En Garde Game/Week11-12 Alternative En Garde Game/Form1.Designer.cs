namespace Week11_12_Alternative_En_Garde_Game
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newGameWithRonzoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBoxMat = new System.Windows.Forms.PictureBox();
            this.listBoxUserHand = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonGoForward = new System.Windows.Forms.Button();
            this.buttonGoBack = new System.Windows.Forms.Button();
            this.textBoxDeckCount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.radioButtonParryOn = new System.Windows.Forms.RadioButton();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMat)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(837, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // newGameToolStripMenuItem
            // 
            this.newGameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameWithRonzoToolStripMenuItem});
            this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            this.newGameToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.newGameToolStripMenuItem.Text = "&New Game";
            // 
            // newGameWithRonzoToolStripMenuItem
            // 
            this.newGameWithRonzoToolStripMenuItem.Name = "newGameWithRonzoToolStripMenuItem";
            this.newGameWithRonzoToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.newGameWithRonzoToolStripMenuItem.Text = "New Game With &Ronzo";
            this.newGameWithRonzoToolStripMenuItem.Click += new System.EventHandler(this.newGameToolStripMenuItem_Click);
            // 
            // pictureBoxMat
            // 
            this.pictureBoxMat.Location = new System.Drawing.Point(22, 27);
            this.pictureBoxMat.Name = "pictureBoxMat";
            this.pictureBoxMat.Size = new System.Drawing.Size(780, 104);
            this.pictureBoxMat.TabIndex = 1;
            this.pictureBoxMat.TabStop = false;
            // 
            // listBoxUserHand
            // 
            this.listBoxUserHand.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxUserHand.FormattingEnabled = true;
            this.listBoxUserHand.ItemHeight = 18;
            this.listBoxUserHand.Items.AddRange(new object[] {
            "G",
            "A",
            "R",
            "D",
            "E"});
            this.listBoxUserHand.Location = new System.Drawing.Point(401, 172);
            this.listBoxUserHand.Name = "listBoxUserHand";
            this.listBoxUserHand.Size = new System.Drawing.Size(19, 94);
            this.listBoxUserHand.TabIndex = 2;
            this.listBoxUserHand.SelectedIndexChanged += new System.EventHandler(this.listBoxUserHand_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(385, 154);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Your Hand";
            // 
            // buttonGoForward
            // 
            this.buttonGoForward.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGoForward.Location = new System.Drawing.Point(439, 188);
            this.buttonGoForward.Name = "buttonGoForward";
            this.buttonGoForward.Size = new System.Drawing.Size(136, 78);
            this.buttonGoForward.TabIndex = 4;
            this.buttonGoForward.Text = "Go &Forward";
            this.buttonGoForward.UseVisualStyleBackColor = true;
            this.buttonGoForward.Click += new System.EventHandler(this.buttonGoForward_Click);
            // 
            // buttonGoBack
            // 
            this.buttonGoBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGoBack.Location = new System.Drawing.Point(250, 188);
            this.buttonGoBack.Name = "buttonGoBack";
            this.buttonGoBack.Size = new System.Drawing.Size(136, 76);
            this.buttonGoBack.TabIndex = 5;
            this.buttonGoBack.Text = "Go &Back";
            this.buttonGoBack.UseVisualStyleBackColor = true;
            this.buttonGoBack.Click += new System.EventHandler(this.buttonGoBack_Click);
            // 
            // textBoxDeckCount
            // 
            this.textBoxDeckCount.Location = new System.Drawing.Point(266, 147);
            this.textBoxDeckCount.Name = "textBoxDeckCount";
            this.textBoxDeckCount.ReadOnly = true;
            this.textBoxDeckCount.Size = new System.Drawing.Size(29, 20);
            this.textBoxDeckCount.TabIndex = 6;
            this.textBoxDeckCount.Text = "EN";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(168, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Cards left in deck:";
            // 
            // radioButtonParryOn
            // 
            this.radioButtonParryOn.AutoSize = true;
            this.radioButtonParryOn.Checked = true;
            this.radioButtonParryOn.Location = new System.Drawing.Point(22, 247);
            this.radioButtonParryOn.Name = "radioButtonParryOn";
            this.radioButtonParryOn.Size = new System.Drawing.Size(150, 17);
            this.radioButtonParryOn.TabIndex = 8;
            this.radioButtonParryOn.TabStop = true;
            this.radioButtonParryOn.Text = "Play next game with parrys";
            this.radioButtonParryOn.UseVisualStyleBackColor = true;
            this.radioButtonParryOn.CheckedChanged += new System.EventHandler(this.radioButtonParryOn_CheckedChanged);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "&Options";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(837, 276);
            this.Controls.Add(this.radioButtonParryOn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxDeckCount);
            this.Controls.Add(this.buttonGoBack);
            this.Controls.Add(this.buttonGoForward);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBoxUserHand);
            this.Controls.Add(this.pictureBoxMat);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "En Garde Game";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMat)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem newGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newGameWithRonzoToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBoxMat;
        private System.Windows.Forms.ListBox listBoxUserHand;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonGoForward;
        private System.Windows.Forms.Button buttonGoBack;
        private System.Windows.Forms.TextBox textBoxDeckCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radioButtonParryOn;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}

