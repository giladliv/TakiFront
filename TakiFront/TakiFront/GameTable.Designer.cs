namespace TakiFront
{
    partial class GameTable
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.button4 = new System.Windows.Forms.Button();
            this.centerCardBox = new System.Windows.Forms.PictureBox();
            this.CloseButton = new System.Windows.Forms.Button();
            this.LeaveButton = new System.Windows.Forms.Button();
            this.directionRightPic = new System.Windows.Forms.PictureBox();
            this.directionLeftPic = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.centerCardBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.directionRightPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.directionLeftPic)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(905, 502);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(495, 288);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(905, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "label3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1318, 288);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "label4";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(844, 664);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(161, 68);
            this.button1.TabIndex = 4;
            this.button1.Text = "סיים תור";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(778, 578);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(297, 22);
            this.textBox1.TabIndex = 5;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BackgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorker1_RunWorkerCompleted);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(42, 237);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(242, 208);
            this.richTextBox1.TabIndex = 6;
            this.richTextBox1.Text = "";
            this.richTextBox1.Visible = false;
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(1606, 645);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.richTextBox2.Size = new System.Drawing.Size(192, 121);
            this.richTextBox2.TabIndex = 7;
            this.richTextBox2.Text = "";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1625, 772);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(161, 68);
            this.button2.TabIndex = 8;
            this.button2.Text = "תגובה";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(292, 664);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(161, 68);
            this.button3.TabIndex = 9;
            this.button3.Text = "קלף אחרון בידי";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoScroll = true;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Location = new System.Drawing.Point(292, 738);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1268, 258);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox1.Location = new System.Drawing.Point(826, 451);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(204, 115);
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox2.Location = new System.Drawing.Point(416, 240);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(204, 115);
            this.pictureBox2.TabIndex = 12;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox3.Location = new System.Drawing.Point(826, 33);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(204, 115);
            this.pictureBox3.TabIndex = 13;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox4.Location = new System.Drawing.Point(1240, 240);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(204, 115);
            this.pictureBox4.TabIndex = 14;
            this.pictureBox4.TabStop = false;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(1594, 244);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(237, 240);
            this.button4.TabIndex = 15;
            this.button4.Text = "ערימה";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.drawEmpty);
            // 
            // centerCardBox
            // 
            this.centerCardBox.Location = new System.Drawing.Point(826, 192);
            this.centerCardBox.Name = "centerCardBox";
            this.centerCardBox.Size = new System.Drawing.Size(210, 228);
            this.centerCardBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.centerCardBox.TabIndex = 16;
            this.centerCardBox.TabStop = false;
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(12, 12);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(161, 70);
            this.CloseButton.TabIndex = 17;
            this.CloseButton.Text = "CLOSE ROOM";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Visible = false;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // LeaveButton
            // 
            this.LeaveButton.Location = new System.Drawing.Point(12, 29);
            this.LeaveButton.Name = "LeaveButton";
            this.LeaveButton.Size = new System.Drawing.Size(161, 70);
            this.LeaveButton.TabIndex = 18;
            this.LeaveButton.Text = "LEAVE ROOM";
            this.LeaveButton.UseVisualStyleBackColor = true;
            this.LeaveButton.Visible = false;
            this.LeaveButton.Click += new System.EventHandler(this.LeaveButton_Click);
            // 
            // directionRightPic
            // 
            this.directionRightPic.Location = new System.Drawing.Point(1077, 207);
            this.directionRightPic.Name = "directionRightPic";
            this.directionRightPic.Size = new System.Drawing.Size(87, 197);
            this.directionRightPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.directionRightPic.TabIndex = 19;
            this.directionRightPic.TabStop = false;
            // 
            // directionLeftPic
            // 
            this.directionLeftPic.Location = new System.Drawing.Point(697, 207);
            this.directionLeftPic.Name = "directionLeftPic";
            this.directionLeftPic.Size = new System.Drawing.Size(87, 197);
            this.directionLeftPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.directionLeftPic.TabIndex = 20;
            this.directionLeftPic.TabStop = false;
            // 
            // GameTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1890, 1055);
            this.Controls.Add(this.directionLeftPic);
            this.Controls.Add(this.directionRightPic);
            this.Controls.Add(this.LeaveButton);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.centerCardBox);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox4);
            this.Name = "GameTable";
            this.Text = "GameTable";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GameTable_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.centerCardBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.directionRightPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.directionLeftPic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.PictureBox centerCardBox;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Button LeaveButton;
        private System.Windows.Forms.PictureBox directionRightPic;
        private System.Windows.Forms.PictureBox directionLeftPic;
    }
}