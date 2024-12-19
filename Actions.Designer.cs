
namespace ToolCloneDataFromGSHT
{
    partial class Actions
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
            this.txtGetDonViVanTai = new System.Windows.Forms.Button();
            this.txtGetPhuongTien = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtGetDonViVanTai
            // 
            this.txtGetDonViVanTai.Location = new System.Drawing.Point(94, 163);
            this.txtGetDonViVanTai.Name = "txtGetDonViVanTai";
            this.txtGetDonViVanTai.Size = new System.Drawing.Size(132, 55);
            this.txtGetDonViVanTai.TabIndex = 0;
            this.txtGetDonViVanTai.Text = "Lấy đơn vị vận tải";
            this.txtGetDonViVanTai.UseVisualStyleBackColor = true;
            // 
            // txtGetPhuongTien
            // 
            this.txtGetPhuongTien.Location = new System.Drawing.Point(259, 163);
            this.txtGetPhuongTien.Name = "txtGetPhuongTien";
            this.txtGetPhuongTien.Size = new System.Drawing.Size(132, 55);
            this.txtGetPhuongTien.TabIndex = 1;
            this.txtGetPhuongTien.Text = "Lấy phương tiện";
            this.txtGetPhuongTien.UseVisualStyleBackColor = true;
            // 
            // Actions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 370);
            this.Controls.Add(this.txtGetPhuongTien);
            this.Controls.Add(this.txtGetDonViVanTai);
            this.Name = "Actions";
            this.Text = "Actions";
            this.Load += new System.EventHandler(this.Actions_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button txtGetDonViVanTai;
        private System.Windows.Forms.Button txtGetPhuongTien;
    }
}