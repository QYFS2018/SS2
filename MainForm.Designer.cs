namespace SS2
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.MarkOrderShip = new System.Windows.Forms.Button();
            this.PullOrder = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // MarkOrderShip
            // 
            this.MarkOrderShip.Location = new System.Drawing.Point(46, 41);
            this.MarkOrderShip.Name = "MarkOrderShip";
            this.MarkOrderShip.Size = new System.Drawing.Size(144, 49);
            this.MarkOrderShip.TabIndex = 0;
            this.MarkOrderShip.Text = "Mark Order Ship";
            this.MarkOrderShip.UseVisualStyleBackColor = true;
            this.MarkOrderShip.Click += new System.EventHandler(this.MarkOrderShip_Click);
            // 
            // PullOrder
            // 
            this.PullOrder.Location = new System.Drawing.Point(241, 41);
            this.PullOrder.Name = "PullOrder";
            this.PullOrder.Size = new System.Drawing.Size(144, 49);
            this.PullOrder.TabIndex = 1;
            this.PullOrder.Text = "Pull Order";
            this.PullOrder.UseVisualStyleBackColor = true;
            this.PullOrder.Click += new System.EventHandler(this.PullOrder_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 144);
            this.Controls.Add(this.PullOrder);
            this.Controls.Add(this.MarkOrderShip);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ShipStation2";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button MarkOrderShip;
        private System.Windows.Forms.Button PullOrder;
    }
}

