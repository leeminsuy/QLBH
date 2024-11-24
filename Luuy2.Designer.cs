namespace quanlykhachsan12345
{
    partial class Luuy2
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
            richTextBox1 = new RichTextBox();
            SuspendLayout();
            // 
            // richTextBox1
            // 
            richTextBox1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            richTextBox1.ForeColor = Color.Red;
            richTextBox1.Location = new Point(21, 12);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(463, 236);
            richTextBox1.TabIndex = 0;
            richTextBox1.Text = "Kiểm tra xem bạn đã xóa hóa đơn chưa mới có thể xóa ";
            // 
            // Luuy2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(496, 260);
            Controls.Add(richTextBox1);
            Name = "Luuy2";
            Text = "Luuy2";
            ResumeLayout(false);
        }

        #endregion

        private RichTextBox richTextBox1;
    }
}