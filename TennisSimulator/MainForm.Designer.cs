namespace TennisSimulator
{
    partial class MainForm
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.ButtonOpenJson = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ButtonOpenJson
            // 
            this.ButtonOpenJson.Location = new System.Drawing.Point(54, 12);
            this.ButtonOpenJson.Name = "ButtonOpenJson";
            this.ButtonOpenJson.Size = new System.Drawing.Size(196, 23);
            this.ButtonOpenJson.TabIndex = 0;
            this.ButtonOpenJson.Text = "Open Json And Start Simulation";
            this.ButtonOpenJson.UseVisualStyleBackColor = true;
            this.ButtonOpenJson.Click += new System.EventHandler(this.ButtonOpenJson_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 121);
            this.Controls.Add(this.ButtonOpenJson);
            this.Name = "MainForm";
            this.Text = "Tennis Simulator";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ButtonOpenJson;
    }
}

