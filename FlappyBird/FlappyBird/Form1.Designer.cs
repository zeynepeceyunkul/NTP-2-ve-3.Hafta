namespace FlappyBird
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.pipeTop = new System.Windows.Forms.PictureBox();
            this.flappyBird = new System.Windows.Forms.PictureBox();
            this.pipeBottom = new System.Windows.Forms.PictureBox();
            this.ground = new System.Windows.Forms.PictureBox();
            this.scoreText = new System.Windows.Forms.Label();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.endText1 = new System.Windows.Forms.Label();
            this.endText2 = new System.Windows.Forms.Label();
            this.gameDesigner = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pipeTop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.flappyBird)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pipeBottom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ground)).BeginInit();
            this.SuspendLayout();
            // 
            // pipeTop
            // 
            this.pipeTop.Image = global::FlappyBird.Properties.Resources.pipedown;
            this.pipeTop.Location = new System.Drawing.Point(446, -35);
            this.pipeTop.Name = "pipeTop";
            this.pipeTop.Size = new System.Drawing.Size(107, 252);
            this.pipeTop.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pipeTop.TabIndex = 0;
            this.pipeTop.TabStop = false;
            // 
            // flappyBird
            // 
            this.flappyBird.AccessibleName = "";
            this.flappyBird.Image = global::FlappyBird.Properties.Resources.bird;
            this.flappyBird.Location = new System.Drawing.Point(51, 249);
            this.flappyBird.Name = "flappyBird";
            this.flappyBird.Size = new System.Drawing.Size(80, 60);
            this.flappyBird.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.flappyBird.TabIndex = 1;
            this.flappyBird.TabStop = false;
            // 
            // pipeBottom
            // 
            this.pipeBottom.Image = global::FlappyBird.Properties.Resources.pipe;
            this.pipeBottom.Location = new System.Drawing.Point(333, 358);
            this.pipeBottom.Name = "pipeBottom";
            this.pipeBottom.Size = new System.Drawing.Size(107, 288);
            this.pipeBottom.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pipeBottom.TabIndex = 2;
            this.pipeBottom.TabStop = false;
            // 
            // ground
            // 
            this.ground.Image = global::FlappyBird.Properties.Resources.ground;
            this.ground.Location = new System.Drawing.Point(-12, 593);
            this.ground.Name = "ground";
            this.ground.Size = new System.Drawing.Size(971, 95);
            this.ground.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ground.TabIndex = 3;
            this.ground.TabStop = false;
            // 
            // scoreText
            // 
            this.scoreText.AutoSize = true;
            this.scoreText.BackColor = System.Drawing.Color.Khaki;
            this.scoreText.Font = new System.Drawing.Font("Consolas", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.scoreText.Location = new System.Drawing.Point(-7, 639);
            this.scoreText.Name = "scoreText";
            this.scoreText.Size = new System.Drawing.Size(143, 34);
            this.scoreText.TabIndex = 4;
            this.scoreText.Text = "Score: 0";
            // 
            // gameTimer
            // 
            this.gameTimer.Enabled = true;
            this.gameTimer.Interval = 20;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimerEvent);
            // 
            // endText1
            // 
            this.endText1.AutoSize = true;
            this.endText1.Font = new System.Drawing.Font("Consolas", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.endText1.Location = new System.Drawing.Point(244, 249);
            this.endText1.Name = "endText1";
            this.endText1.Size = new System.Drawing.Size(233, 37);
            this.endText1.TabIndex = 5;
            this.endText1.Text = "Game Over!!!";
            // 
            // endText2
            // 
            this.endText2.AutoSize = true;
            this.endText2.Font = new System.Drawing.Font("Consolas", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.endText2.Location = new System.Drawing.Point(247, 298);
            this.endText2.Name = "endText2";
            this.endText2.Size = new System.Drawing.Size(255, 32);
            this.endText2.TabIndex = 6;
            this.endText2.Text = "Final Skorunuz: ";
            // 
            // gameDesigner
            // 
            this.gameDesigner.AutoSize = true;
            this.gameDesigner.BackColor = System.Drawing.Color.Khaki;
            this.gameDesigner.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gameDesigner.Location = new System.Drawing.Point(163, 649);
            this.gameDesigner.Name = "gameDesigner";
            this.gameDesigner.Size = new System.Drawing.Size(390, 22);
            this.gameDesigner.TabIndex = 7;
            this.gameDesigner.Text = "Bu oyun Zece tarfından hazırlanmıştır.";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Aqua;
            this.ClientSize = new System.Drawing.Size(578, 682);
            this.Controls.Add(this.gameDesigner);
            this.Controls.Add(this.endText2);
            this.Controls.Add(this.endText1);
            this.Controls.Add(this.scoreText);
            this.Controls.Add(this.ground);
            this.Controls.Add(this.pipeBottom);
            this.Controls.Add(this.pipeTop);
            this.Controls.Add(this.flappyBird);
            this.Name = "Form1";
            this.Text = " ";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gamekeyisdown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.gamekeyisup);
            ((System.ComponentModel.ISupportInitialize)(this.pipeTop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.flappyBird)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pipeBottom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ground)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pipeTop;
        private System.Windows.Forms.PictureBox flappyBird;
        private System.Windows.Forms.PictureBox pipeBottom;
        private System.Windows.Forms.PictureBox ground;
        private System.Windows.Forms.Label scoreText;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Label endText1;
        private System.Windows.Forms.Label endText2;
        private System.Windows.Forms.Label gameDesigner;
    }
}

