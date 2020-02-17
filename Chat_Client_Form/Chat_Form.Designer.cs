namespace Chat_Client_Form
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.SendBox = new System.Windows.Forms.Button();
            this.EnterBox = new System.Windows.Forms.Button();
            this.NickBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ChatBox = new System.Windows.Forms.RichTextBox();
            this.TextBox = new System.Windows.Forms.RichTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Show_Setting = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SendBox
            // 
            this.SendBox.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.SendBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SendBox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.SendBox.Location = new System.Drawing.Point(389, 502);
            this.SendBox.Name = "SendBox";
            this.SendBox.Size = new System.Drawing.Size(97, 51);
            this.SendBox.TabIndex = 0;
            this.SendBox.Text = "Отправить";
            this.SendBox.UseVisualStyleBackColor = false;
            this.SendBox.Click += new System.EventHandler(this.SendBox_Click);
            // 
            // EnterBox
            // 
            this.EnterBox.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.EnterBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EnterBox.Location = new System.Drawing.Point(245, 40);
            this.EnterBox.Name = "EnterBox";
            this.EnterBox.Size = new System.Drawing.Size(105, 40);
            this.EnterBox.TabIndex = 1;
            this.EnterBox.Text = "Вход";
            this.EnterBox.UseVisualStyleBackColor = false;
            this.EnterBox.Click += new System.EventHandler(this.EnterBox_Click);
            // 
            // NickBox
            // 
            this.NickBox.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NickBox.Location = new System.Drawing.Point(15, 57);
            this.NickBox.Name = "NickBox";
            this.NickBox.Size = new System.Drawing.Size(209, 20);
            this.NickBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Ваш ник:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Чат";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 422);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Ваш текст";
            // 
            // ChatBox
            // 
            this.ChatBox.BackColor = System.Drawing.SystemColors.Window;
            this.ChatBox.EnableAutoDragDrop = true;
            this.ChatBox.Font = new System.Drawing.Font("MV Boli", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChatBox.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ChatBox.Location = new System.Drawing.Point(15, 96);
            this.ChatBox.Name = "ChatBox";
            this.ChatBox.ReadOnly = true;
            this.ChatBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ChatBox.Size = new System.Drawing.Size(471, 304);
            this.ChatBox.TabIndex = 7;
            this.ChatBox.Text = "";
            this.ChatBox.TextChanged += new System.EventHandler(this.ChatBox_TextChanged);
            // 
            // TextBox
            // 
            this.TextBox.EnableAutoDragDrop = true;
            this.TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TextBox.Location = new System.Drawing.Point(15, 438);
            this.TextBox.Name = "TextBox";
            this.TextBox.Size = new System.Drawing.Size(368, 115);
            this.TextBox.TabIndex = 8;
            this.TextBox.Text = "";
            this.TextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuStrip1.BackgroundImage = global::Chat_Client_Form.Properties.Resources._1404_1186;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(500, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.menuToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Black", 8F);
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.menuToolStripMenuItem.Text = "Меню";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.settingsToolStripMenuItem.Text = "Настройки";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.exitToolStripMenuItem.Text = "Выход";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // Show_Setting
            // 
            this.Show_Setting.AutoSize = true;
            this.Show_Setting.BackColor = System.Drawing.Color.Transparent;
            this.Show_Setting.Location = new System.Drawing.Point(362, 40);
            this.Show_Setting.Name = "label4";
            this.Show_Setting.Size = new System.Drawing.Size(0, 13);
            this.Show_Setting.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.BackgroundImage = global::Chat_Client_Form.Properties.Resources._1404_1186;
            this.ClientSize = new System.Drawing.Size(500, 562);
            this.Controls.Add(this.Show_Setting);
            this.Controls.Add(this.TextBox);
            this.Controls.Add(this.ChatBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.NickBox);
            this.Controls.Add(this.EnterBox);
            this.Controls.Add(this.SendBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Чат СТ.19.Б.1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SendBox;
        private System.Windows.Forms.Button EnterBox;
        private System.Windows.Forms.TextBox NickBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox ChatBox;
        private System.Windows.Forms.RichTextBox TextBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Label Show_Setting;
    }
}

