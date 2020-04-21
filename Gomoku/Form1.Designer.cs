namespace Gomoku
{
    partial class Gomoku
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Gomoku
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::Gomoku.Properties.Resources.board;
            this.ClientSize = new System.Drawing.Size(748, 703);
            this.Name = "Gomoku";
            this.Text = "Gomoku";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Gomoku_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Gomoku_MouseMove);
            this.ResumeLayout(false);

        }

        #endregion
    }
}

