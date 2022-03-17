using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRace
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        Random random = new Random();
        
        bool startbuttun = true;
        
        #region createsrandomNumbers
        public void creatsRandomNumber()
        {
            // random number between 2-10 is added to left side of pictureboxes
            // they move from left to right wiht a random number between 2-10
            pictureBox1.Left += random.Next(2, 10);
            pictureBox2.Left += random.Next(2, 10);
            pictureBox3.Left += random.Next(2, 10);
        }
        #endregion

        #region Horses get to first position
        public void getHorsesFirstPosition()
        {
            pictureBox1.Location = new Point(44, 12);
            pictureBox2.Location = new Point(44, 100);
            pictureBox3.Location = new Point(44, 200);
        }
        #endregion

        #region timer
        private void timer1_Tick(object sender, EventArgs e)
        {
            //the finishline is left side position of label4
            int finishline = label4.Left;

            creatsRandomNumber();

            #region comentary

            //this part add comments to label 4 according to their condition.
            // according condition inside if block program runs what it says inside the block
           
            if (pictureBox1.Left>pictureBox2.Left+2 && pictureBox1.Left> pictureBox3.Left+2 && pictureBox1.Location.X <500)
            {
                label8.Text = "1. Horse is leading..";
            }
           if (pictureBox3.Left > pictureBox2.Left+2 && pictureBox3.Left > pictureBox1.Left+2&&pictureBox2.Location.X<500)
            {
                label8.Text = "3. Horse is getting faster";
            }
            if (pictureBox2.Left > pictureBox1.Left+2 && pictureBox2.Left > pictureBox3.Left+2&&pictureBox3.Location.X<500)
            {
                label8.Text = "2. Horse  is in first place";
            }
            if ((pictureBox1.Location.X > 550 && pictureBox1.Location.X < 600 ) || (pictureBox2.Location.X > 550 && pictureBox2.Location.X < 600 )|| (pictureBox3.Location.X > 550 && pictureBox3.Location.X < 600))
            {
                label8.Text = "The winner is...";
            }
            if (pictureBox1.Width + pictureBox1.Left >= finishline)
            {
                timer1.Enabled = false;
                label8.Text = "   Number 1 ";

            }
            if (pictureBox2.Width + pictureBox2.Left >= finishline)
            {
                timer1.Enabled = false;
                label8.Text = "    Number 2 ";
            }
            if (pictureBox3.Width + pictureBox3.Left >= finishline)
            {
                timer1.Enabled = false;
                label8.Text = "    Number 3 ";
            }
        }
        #endregion

        #region start buttun
        private void button1_Click(object sender, EventArgs e)
        {           
            if (startbuttun==true)
            {           
               timer1.Enabled = true;
               button1.Text = "Stop Race";
                startbuttun = false;
            }
            else
            {          
                timer1.Enabled = false;
                startbuttun = true;
                button1.Text = "Start Race";
                label8.Text = "";
                getHorsesFirstPosition();
            }
        }
        #endregion
    }
}
#endregion
