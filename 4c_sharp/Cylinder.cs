using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace _4c_sharp
{
    class Cylinder:Circle
    {
        private double h;

        public double H { get => h; set => h = value; }

        public Cylinder()
        {

        }

        public Cylinder(double h)
        {
            this.H = h;
        }

        public double GetVolume()//объём цилиндра
        {
            return Math.Round(Math.PI * Math.Pow(base.R, 2) * this.H,3);
        }

        new public double GetSquare()//полная площадь
        {
            return Math.Round(2 * Math.PI * base.R * (base.R + this.H),3);

        }

        public double GetSquareOfSideSurface()//площадь боковой поверхности
        {
            return Math.Round(2 * Math.PI * base.R * this.H,3);
        }

        new public string ToString()
        {
            return $"\nРадиус:  {this.R} \nВысота:  {this.H} \nОбъем:  {this.GetVolume()} \nПлощадь боковой поверхности: {this.GetSquareOfSideSurface()} \nПлощадь полной поверхности: {this.GetSquare()}";
         
        }

        public void Write(BinaryWriter bw)
        {
            // Все данные записываются по отдельности
            bw.Write(R);
            bw.Write(H);


        }

        public static Cylinder Read(BinaryReader br)
        {
            Cylinder f = new Cylinder();
            f.R = br.ReadDouble();
            f.H = br.ReadDouble();

            return f;
        }
    }
}
