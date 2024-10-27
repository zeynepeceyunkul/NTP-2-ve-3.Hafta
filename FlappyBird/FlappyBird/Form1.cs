using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlappyBird
{
    public partial class Form1 : Form
    {



        int boruHızı = 8; // Boruların hareket hızı
        int yerçekimi = 8; // Kuşun yerçekimi etkisiyle düşme hızı
        int score = 0; // Oyuncunun puanı
        


        public Form1()
        {
            // Form bileşenlerini başlatır
            InitializeComponent();

            // Oyun sonu mesajlarını başta gizler
            endText1.Visible = false; 
            endText2.Visible = false;
            gameDesigner.Visible = false;
        }

        private void gameTimerEvent(object sender, EventArgs e) // Oyun zamanlayıcısı her tetiklendiğinde çalışır
        {

            flappyBird.Top += yerçekimi; // Yer çekimi etkisi kuşun düşmesini sağlar

            // Boruların sola doğru hareket etmesini sağlar
            pipeBottom.Left -= boruHızı;
            pipeTop.Left -= boruHızı;

            scoreText.Text = "Score: " + score; // Oyuncunun skorunu günceller

            if (pipeBottom.Left < -100) // Alt boru ekranın solundan çıkarsa yeniden konumlandır
            {
                pipeBottom.Left = 400; // Borunun yeni konumu
                score++; // Skoru artır
            }

            if (pipeTop.Left < -110) // Üst boru ekranın solundan çıkarsa yeniden konumlandır
            {
                pipeTop.Left = 500; // Borunun yeni konumu
                score++; // Skoru artır
            }

            if (flappyBird.Bounds.IntersectsWith(pipeBottom.Bounds) || // Kuş alt boruya değerse oyunu bitir
                flappyBird.Bounds.IntersectsWith(pipeTop.Bounds) || // Kuş üst boruya değerse oyunu bitir
                flappyBird.Bounds.IntersectsWith(ground.Bounds) ) // Kuş yere değerse oyunu bitir
            {
                endGame();
            }

            if (score > 5) // Eğer oyuncunun skoru 5'i geçerse boru hızını artır
            {
                boruHızı = 15;
            }

            if (flappyBird.Top < -35) // Eğer kuş ekranın üst kısmına değerse oyunu bitir
            {
                endGame();
            }
        }

        private void gamekeyisdown(object sender, KeyEventArgs e) // Klavyede bir tuşa basıldığında çalışır
        {
            if (e.KeyCode == Keys.Space) // Space tuşuna basıldığında kuşun yukarı çıkmasını sağlar
            {
                yerçekimi = -8;
            }
        }

        private void gamekeyisup(object sender, KeyEventArgs e) // Klavyede bir tuşa basıldığında çalışır
        {
            if (e.KeyCode == Keys.Space) // Space tuşuna basılmadığında kuşun aşağı düşmesini sağlar
            {
                yerçekimi = 8;
            }
        }

        private void endGame() // Oyunu sonlandırır 
        {
            gameTimer.Stop(); // Oyunun zamanlayıcısını durdurur
            
            // Oyun sonu mesajları
            endText1.Text = "GAME OVER!!!";
            endText2.Text = "Final Score: " + score;
            gameDesigner.Text = "Bu oyun Zece tarafından tasarlanmıştır.";

            // Oyun sonu mesajlarını görünür yapar
            endText1.Visible = true;
            endText2.Visible = true;
            gameDesigner.Visible = true;
        }

      
    }
}
