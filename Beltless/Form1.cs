﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

using System.Threading;
using hakaton;

namespace Beltless
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        
        public void showImage(int th)
        {


            //Thread th = new Thread(() => showImage(100));
            //th.Start();

            for (int i = 1; i < 11; i++)
            {
                string myString = string.Format(@"D:\Documents\Visual Studio 2017\Projets\Beltless\Beltless\Resources\{0}.png", i);
                Thread.Sleep(th);
                pictureBox1.ImageLocation = myString;
            }
        }

        public int[] getSpeed()
        {
            int[] d = Conected.ConnectAzure();
            return d;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int[]d=getSpeed();
            getİnfo(d);
        }

        private void getİnfo(int[]array)
        {
            LinearMotion car = new LinearMotion();
            LinearMotion armchairLinearMotion = new LinearMotion();
            Circular_Motion armchairCircularMotion = new Circular_Motion();

            for (int i = 0; i < array.Length; i++)
            {
                double acceleration_car = car.acceleration(0, array[i], 1);//arabanın ivmesi
                double speed_armchair = car.final_speed(acceleration_car, 0, 0.15);//koltuk track sonunda hız
                double circleAccelerationArmchair = armchairCircularMotion.acceleration(speed_armchair, 0.15);//dairesel ivme
                double dete = armchairCircularMotion.angel(speed_armchair, 0.2);//açma hesaplama
            }
            
            
            
            

        }
    }
}
