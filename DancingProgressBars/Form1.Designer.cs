using System.Windows.Forms;

namespace DancingProgressBars
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            btnCreate = new Button();
            btnStart = new Button();
            numericUpDown1 = new NumericUpDown();
            btnPause = new Button();
            btnResume = new Button();
            btnStop = new Button();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Location = new Point(238, 28);
            panel1.Name = "panel1";
            panel1.Size = new Size(500, 400);
            panel1.TabIndex = 0;
            // 
            // btnCreate
            // 
            btnCreate.Location = new Point(78, 51);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(75, 23);
            btnCreate.TabIndex = 1;
            btnCreate.Text = "Create";
            btnCreate.UseVisualStyleBackColor = true;
            // 
            // btnStart
            // 
            btnStart.Location = new Point(78, 80);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(75, 23);
            btnStart.TabIndex = 2;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(49, 134);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(120, 23);
            numericUpDown1.TabIndex = 3;
            // 
            // btnPause
            // 
            btnPause.Location = new Point(27, 185);
            btnPause.Name = "btnPause";
            btnPause.Size = new Size(75, 24);
            btnPause.TabIndex = 4;
            btnPause.Text = "Pause";
            btnPause.UseVisualStyleBackColor = true;
            // 
            // btnResume
            // 
            btnResume.Location = new Point(129, 185);
            btnResume.Name = "btnResume";
            btnResume.Size = new Size(75, 24);
            btnResume.TabIndex = 5;
            btnResume.Text = "Resume";
            btnResume.UseVisualStyleBackColor = true;
            // 
            // btnStop
            // 
            btnStop.Location = new Point(78, 392);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(75, 46);
            btnStop.TabIndex = 6;
            btnStop.Text = "Stop";
            btnStop.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.RosyBrown;
            ClientSize = new Size(800, 450);
            Controls.Add(btnStop);
            Controls.Add(btnResume);
            Controls.Add(btnPause);
            Controls.Add(numericUpDown1);
            Controls.Add(btnStart);
            Controls.Add(btnCreate);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btnCreate;
        private Button btnStart;
        private NumericUpDown numericUpDown1;
        private Button btnPause;
        private Button btnResume;
        private Button btnStop;
    }
}
