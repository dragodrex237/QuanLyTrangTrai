namespace QuanLyTrangTrai
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
            System.Windows.Forms.Label label3;
            this.btVN = new System.Windows.Forms.Button();
            this.btLoai = new System.Windows.Forms.Button();
            this.btCH = new System.Windows.Forms.Button();
            this.labelTK = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label3
            // 
            label3.Dock = System.Windows.Forms.DockStyle.Top;
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label3.Location = new System.Drawing.Point(0, 10);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(602, 38);
            label3.TabIndex = 7;
            label3.Text = "QUẢN LÝ TRANG TRẠI";
            label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btVN
            // 
            this.btVN.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btVN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btVN.Location = new System.Drawing.Point(68, 69);
            this.btVN.Name = "btVN";
            this.btVN.Size = new System.Drawing.Size(150, 59);
            this.btVN.TabIndex = 0;
            this.btVN.Text = "VẬT NUÔI";
            this.btVN.UseVisualStyleBackColor = true;
            this.btVN.Click += new System.EventHandler(this.btVN_Click);
            // 
            // btLoai
            // 
            this.btLoai.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btLoai.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btLoai.Location = new System.Drawing.Point(224, 69);
            this.btLoai.Name = "btLoai";
            this.btLoai.Size = new System.Drawing.Size(150, 59);
            this.btLoai.TabIndex = 1;
            this.btLoai.Text = "LOÀI";
            this.btLoai.UseVisualStyleBackColor = true;
            this.btLoai.Click += new System.EventHandler(this.btLoai_Click);
            // 
            // btCH
            // 
            this.btCH.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btCH.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCH.Location = new System.Drawing.Point(380, 69);
            this.btCH.Name = "btCH";
            this.btCH.Size = new System.Drawing.Size(150, 59);
            this.btCH.TabIndex = 2;
            this.btCH.Text = "CHUỒNG";
            this.btCH.UseVisualStyleBackColor = true;
            this.btCH.Click += new System.EventHandler(this.btCH_Click);
            // 
            // labelTK
            // 
            this.labelTK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelTK.AutoSize = true;
            this.labelTK.ForeColor = System.Drawing.Color.Red;
            this.labelTK.Location = new System.Drawing.Point(4, 424);
            this.labelTK.Name = "labelTK";
            this.labelTK.Size = new System.Drawing.Size(20, 17);
            this.labelTK.TabIndex = 3;
            this.labelTK.Text = "...";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(319, 410);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 45);
            this.button1.TabIndex = 4;
            this.button1.Text = "Tài Khoản";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(440, 410);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(150, 45);
            this.button2.TabIndex = 5;
            this.button2.Text = "Đổi Mật Khẩu";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(68, 134);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(150, 59);
            this.button3.TabIndex = 8;
            this.button3.Text = "NHÂN VIÊN";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 467);
            this.Controls.Add(this.button3);
            this.Controls.Add(label3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.labelTK);
            this.Controls.Add(this.btCH);
            this.Controls.Add(this.btLoai);
            this.Controls.Add(this.btVN);
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btVN;
        private System.Windows.Forms.Button btLoai;
        private System.Windows.Forms.Button btCH;
        private System.Windows.Forms.Label labelTK;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}

