namespace TestPostPay
{
    partial class Form2
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this._btnQueryOrder = new System.Windows.Forms.Button();
            this._btnCommitOrder = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(92, 111);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(298, 281);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // _btnQueryOrder
            // 
            this._btnQueryOrder.Location = new System.Drawing.Point(496, 188);
            this._btnQueryOrder.Name = "_btnQueryOrder";
            this._btnQueryOrder.Size = new System.Drawing.Size(99, 23);
            this._btnQueryOrder.TabIndex = 8;
            this._btnQueryOrder.Text = "查询订单状态";
            this._btnQueryOrder.UseVisualStyleBackColor = true;
            this._btnQueryOrder.Click += new System.EventHandler(this._btnQueryOrder_Click);
            // 
            // _btnCommitOrder
            // 
            this._btnCommitOrder.Location = new System.Drawing.Point(496, 111);
            this._btnCommitOrder.Name = "_btnCommitOrder";
            this._btnCommitOrder.Size = new System.Drawing.Size(99, 23);
            this._btnCommitOrder.TabIndex = 7;
            this._btnCommitOrder.Text = "预下单";
            this._btnCommitOrder.UseVisualStyleBackColor = true;
            this._btnCommitOrder.Click += new System.EventHandler(this._btnCommitOrder_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(496, 261);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "测试登录";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 555);
            this.Controls.Add(this.button1);
            this.Controls.Add(this._btnQueryOrder);
            this.Controls.Add(this._btnCommitOrder);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form2";
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button _btnQueryOrder;
        private System.Windows.Forms.Button _btnCommitOrder;
        private System.Windows.Forms.Button button1;
    }
}