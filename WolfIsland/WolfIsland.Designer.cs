namespace WolfIsland
{
    partial class WolfIsland
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WolfIsland));
            generateButton = new Button();
            panel1 = new Panel();
            restartbtn = new Button();
            stopbtn = new Button();
            panel2 = new Panel();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // generateButton
            // 
            generateButton.BackColor = Color.Green;
            generateButton.Dock = DockStyle.Left;
            generateButton.FlatAppearance.BorderSize = 0;
            generateButton.FlatStyle = FlatStyle.Flat;
            generateButton.Font = new Font("Showcard Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point);
            generateButton.Location = new Point(0, 0);
            generateButton.Name = "generateButton";
            generateButton.Size = new Size(179, 65);
            generateButton.TabIndex = 0;
            generateButton.Text = "Start";
            generateButton.UseVisualStyleBackColor = false;
            generateButton.Click += GenerateButton_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(restartbtn);
            panel1.Controls.Add(stopbtn);
            panel1.Controls.Add(generateButton);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 577);
            panel1.Name = "panel1";
            panel1.Size = new Size(521, 65);
            panel1.TabIndex = 1;
            // 
            // restartbtn
            // 
            restartbtn.BackColor = Color.Yellow;
            restartbtn.Dock = DockStyle.Fill;
            restartbtn.FlatAppearance.BorderSize = 0;
            restartbtn.FlatStyle = FlatStyle.Flat;
            restartbtn.Font = new Font("Showcard Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point);
            restartbtn.Location = new Point(179, 0);
            restartbtn.Name = "restartbtn";
            restartbtn.Size = new Size(163, 65);
            restartbtn.TabIndex = 2;
            restartbtn.Text = "Restart";
            restartbtn.UseVisualStyleBackColor = false;
            restartbtn.Click += restartbtn_Click;
            // 
            // stopbtn
            // 
            stopbtn.BackColor = Color.Red;
            stopbtn.Dock = DockStyle.Right;
            stopbtn.FlatAppearance.BorderSize = 0;
            stopbtn.FlatStyle = FlatStyle.Flat;
            stopbtn.Font = new Font("Showcard Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point);
            stopbtn.Location = new Point(342, 0);
            stopbtn.Name = "stopbtn";
            stopbtn.Size = new Size(179, 65);
            stopbtn.TabIndex = 1;
            stopbtn.Text = "Stop";
            stopbtn.UseVisualStyleBackColor = false;
            stopbtn.Click += stopbtn_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(button3);
            panel2.Controls.Add(button2);
            panel2.Controls.Add(button1);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 535);
            panel2.Name = "panel2";
            panel2.Size = new Size(521, 42);
            panel2.TabIndex = 2;
            // 
            // label3
            // 
            label3.Font = new Font("Showcard Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(400, 2);
            label3.Name = "label3";
            label3.Size = new Size(96, 38);
            label3.TabIndex = 5;
            label3.Text = "shewolf";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.Font = new Font("Showcard Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(46, 2);
            label2.Name = "label2";
            label2.Size = new Size(82, 37);
            label2.TabIndex = 4;
            label2.Text = "wolf";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.Font = new Font("Showcard Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(225, 4);
            label1.Name = "label1";
            label1.Size = new Size(123, 34);
            label1.TabIndex = 3;
            label1.Text = "Rabbit";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button3
            // 
            button3.BackColor = Color.Brown;
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.ForeColor = Color.Brown;
            button3.Location = new Point(354, 11);
            button3.Name = "button3";
            button3.Size = new Size(40, 23);
            button3.TabIndex = 2;
            button3.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.BackColor = Color.DarkMagenta;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Location = new Point(179, 11);
            button2.Name = "button2";
            button2.Size = new Size(40, 23);
            button2.TabIndex = 1;
            button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            button1.BackColor = Color.DarkBlue;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(12, 9);
            button1.Name = "button1";
            button1.Size = new Size(40, 23);
            button1.TabIndex = 0;
            button1.UseVisualStyleBackColor = false;
            // 
            // WolfIsland
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(521, 642);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "WolfIsland";
            Text = "WolfIsland";
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button generateButton;
        private Panel panel1;
        private Button restartbtn;
        private Button stopbtn;
        private Panel panel2;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button button3;
        private Button button2;
        private Button button1;
    }
}