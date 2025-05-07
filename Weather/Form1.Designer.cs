namespace Weather
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
            this.lblWeather = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.icon = new System.Windows.Forms.PictureBox();
            this.tbTown = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.icon)).BeginInit();
            this.SuspendLayout();
            // 
            // lblWeather
            // 
            this.lblWeather.AutoSize = true;
            this.lblWeather.Location = new System.Drawing.Point(220, 16);
            this.lblWeather.Name = "lblWeather";
            this.lblWeather.Size = new System.Drawing.Size(97, 13);
            this.lblWeather.TabIndex = 0;
            this.lblWeather.Text = "(тут будет погода)";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(113, 11);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(101, 23);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // icon
            // 
            this.icon.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.icon.Location = new System.Drawing.Point(7, 11);
            this.icon.Name = "icon";
            this.icon.Size = new System.Drawing.Size(100, 100);
            this.icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.icon.TabIndex = 2;
            this.icon.TabStop = false;
            // 
            // tbTown
            // 
            this.tbTown.Location = new System.Drawing.Point(114, 41);
            this.tbTown.Name = "tbTown";
            this.tbTown.Size = new System.Drawing.Size(100, 20);
            this.tbTown.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 127);
            this.Controls.Add(this.tbTown);
            this.Controls.Add(this.icon);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.lblWeather);
            this.Name = "Form1";
            this.Text = "Weather";
            ((System.ComponentModel.ISupportInitialize)(this.icon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblWeather;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.PictureBox icon;
        private System.Windows.Forms.TextBox tbTown;
    }
}

