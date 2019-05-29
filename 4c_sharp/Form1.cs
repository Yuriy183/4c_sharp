using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _4c_sharp
{
    public partial class Form1 : Form
    {
        OpenFileDialog openFileDialog1;
        SaveFileDialog saveFileDialog1;
        List<Circle> circles = new List<Circle>();
        List<Cylinder> cylinders = new List<Cylinder>();
        
        public Form1()
        {
            InitializeComponent();
            openFileDialog1 = new OpenFileDialog();
            saveFileDialog1 = new SaveFileDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            circles.Add(new Circle() {R = Convert.ToDouble(textBox2.Text == "" || Convert.ToDouble(textBox2.Text) < 0 ? "0" : textBox2.Text) });

            txtResult1.Text = null;
            foreach(var circle in circles)
            {
                txtResult1.Text += circle.ToString() + "\n";
            }
        }

        private void btnRnd_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            textBox2.Text = Convert.ToString(rnd.Next(0, 50));
        }

       

        private void Button2_Click(object sender, EventArgs e)
        {
            foreach (var circle in circles)
            {
                txtResult1.Text += circle.ToString() + "\n";
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = openFileDialog1.FileName;

            FileStream fsR = new FileStream(filename, FileMode.Open, FileAccess.Read);
            // Создаем двоичный поток для чтения
            BinaryReader br = new BinaryReader(fsR, Encoding.UTF8);

            //Считываем длину массива и создаём новый массив объектов
            int circlesLength = br.ReadInt32();
            for (int i = 0; i < circlesLength; i++)
            {
                circles.Add(Circle.Read(br));
            }
           
            // Закрываем потоки
            br.Close();
            fsR.Close();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = saveFileDialog1.FileName;
            
            FileStream fs = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs, Encoding.UTF8);
            int circlesLength = circles.Count;
         
            bw.Write(circlesLength);
          
            //Пишем данные
            foreach (var circle in circles)
                circle.Write(bw);

            // Закрываем потоки
            bw.Close();
            fs.Close();
            MessageBox.Show("Файл сохранен");
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            textBox3.Text = Convert.ToString(rnd.Next(0, 50));
            textBox4.Text = Convert.ToString(rnd.Next(0, 50));
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            cylinders.Add(new Cylinder()
            {
                R = Convert.ToDouble(textBox3.Text == "" || Convert.ToDouble(textBox3.Text) < 0 ? "0" : textBox3.Text),
                H = Convert.ToDouble(textBox4.Text == "" || Convert.ToDouble(textBox4.Text) < 0 ? "0" : textBox4.Text)
            });

            txtResult2.Text = null;
            foreach (var cylinder in cylinders)
            {
                txtResult2.Text += cylinder.ToString() + "\n";
            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            foreach (var cylinder in cylinders)
            {
                txtResult2.Text += cylinder.ToString() + "\n";
            }
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            
            // получаем выбранный файл
            string filename = openFileDialog1.FileName;

            FileStream fsR = new FileStream(filename, FileMode.Open, FileAccess.Read);
            // Создаем двоичный поток для чтения
            BinaryReader br = new BinaryReader(fsR, Encoding.UTF8);

            //Считываем длину массива и создаём новый массив объектов
            int Length = br.ReadInt32();
            
            for (int i = 0; i < Length; i++)
            {
                cylinders.Add(Cylinder.Read(br));
            }

            // Закрываем потоки
            br.Close();
            fsR.Close();
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = saveFileDialog1.FileName;

            FileStream fs = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs, Encoding.UTF8);
            int Length = circles.Count;
            
            bw.Write(Length);
            
            //Пишем данные
            foreach (var cylinder in cylinders)
                cylinder.Write(bw);
            
            // Закрываем потоки
            bw.Close();
            fs.Close();
            MessageBox.Show("Файл сохранен");
        }
    }
}
