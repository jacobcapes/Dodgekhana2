namespace Dodgekhana2
{
    partial class FrmDodge
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
            this.components = new System.ComponentModel.Container();
            this.PnlGame = new System.Windows.Forms.Panel();
            this.TmrTire = new System.Windows.Forms.Timer(this.components);
            this.TmrVehicle = new System.Windows.Forms.Timer(this.components);
            this.LblScore = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // PnlGame
            // 
            this.PnlGame.BackColor = System.Drawing.Color.Gray;
            this.PnlGame.Location = new System.Drawing.Point(2, 41);
            this.PnlGame.Name = "PnlGame";
            this.PnlGame.Size = new System.Drawing.Size(375, 325);
            this.PnlGame.TabIndex = 0;
            this.PnlGame.Paint += new System.Windows.Forms.PaintEventHandler(this.PnlGame_Paint);
            // 
            // TmrTire
            // 
            this.TmrTire.Enabled = true;
            this.TmrTire.Tick += new System.EventHandler(this.TmrTire_Tick);
            // 
            // TmrVehicle
            // 
            this.TmrVehicle.Enabled = true;
            // 
            // LblScore
            // 
            this.LblScore.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblScore.Location = new System.Drawing.Point(12, 9);
            this.LblScore.Name = "LblScore";
            this.LblScore.Size = new System.Drawing.Size(100, 23);
            this.LblScore.TabIndex = 1;
            // 
            // FrmDodge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 368);
            this.Controls.Add(this.LblScore);
            this.Controls.Add(this.PnlGame);
            this.Name = "FrmDodge";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PnlGame;
        private System.Windows.Forms.Timer TmrTire;
        private System.Windows.Forms.Timer TmrVehicle;
        private System.Windows.Forms.Label LblScore;
    }
}

