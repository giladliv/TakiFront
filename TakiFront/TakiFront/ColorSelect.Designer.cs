namespace TakiFront
{
    partial class ColorSelect
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Blue;
            this.button1.Location = new System.Drawing.Point(209, 151);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(228, 100);
            this.button1.TabIndex = 0;
            this.button1.Tag = "b";
            this.button1.Text = "blue";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Red;
            this.button2.Location = new System.Drawing.Point(456, 151);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(228, 100);
            this.button2.TabIndex = 1;
            this.button2.Tag = "r";
            this.button2.Text = "red";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.button3.Location = new System.Drawing.Point(209, 273);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(228, 100);
            this.button3.TabIndex = 2;
            this.button3.Tag = "g";
            this.button3.Text = "green";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Yellow;
            this.button4.Location = new System.Drawing.Point(456, 273);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(228, 100);
            this.button4.TabIndex = 3;
            this.button4.Tag = "y";
            this.button4.Text = "yellow";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // ColorSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 541);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "ColorSelect";
            this.Text = "ColorSelect";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}