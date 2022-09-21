
namespace Costura_Decompress
{
    partial class Form1
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
			btnDeCompress = new System.Windows.Forms.Button();
			label1 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			txtInput = new System.Windows.Forms.TextBox();
			txtOutput = new System.Windows.Forms.TextBox();
			txtLog = new System.Windows.Forms.TextBox();
			SuspendLayout();
			btnDeCompress.Location = new System.Drawing.Point(537, 19);
			btnDeCompress.Name = "btnDeCompress";
			btnDeCompress.Size = new System.Drawing.Size(97, 61);
			btnDeCompress.TabIndex = 1;
			btnDeCompress.Text = "反解压";
			btnDeCompress.UseVisualStyleBackColor = true;
			btnDeCompress.Click += new System.EventHandler(btnDeCompress_Click);
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(34, 23);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(53, 12);
			label1.TabIndex = 2;
			label1.Text = "文件路径";
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(34, 62);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(53, 12);
			label2.TabIndex = 3;
			label2.Text = "输出目录";
			txtInput.Location = new System.Drawing.Point(104, 19);
			txtInput.Name = "txtInput";
			txtInput.Size = new System.Drawing.Size(414, 21);
			txtInput.TabIndex = 4;
			txtOutput.Location = new System.Drawing.Point(104, 59);
			txtOutput.Name = "txtOutput";
			txtOutput.Size = new System.Drawing.Size(414, 21);
			txtOutput.TabIndex = 5;
			txtLog.Location = new System.Drawing.Point(36, 86);
			txtLog.Multiline = true;
			txtLog.Name = "txtLog";
			txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			txtLog.Size = new System.Drawing.Size(598, 315);
			txtLog.TabIndex = 6;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(655, 423);
			base.Controls.Add(txtLog);
			base.Controls.Add(txtOutput);
			base.Controls.Add(txtInput);
			base.Controls.Add(label2);
			base.Controls.Add(label1);
			base.Controls.Add(btnDeCompress);
			base.Name = "Form1";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "Costura反编译(会将打包的exe解压成dll到输出目录，然后用ILSpy或dnSpy反编译即可)";
			ResumeLayout(false);
			PerformLayout();
		}

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.Button btnDeCompress;
		private System.Windows.Forms.TextBox txtLog;
	}
}

