/*3. Создать класс окружность, член класса – R. Предусмотреть в классе методы вычисления и вывода
сведений о фигуре – площади, длины окружности.Создать производный класс – круглый прямой
цилиндр с высотой h, добавить в класс метод определения объема фигуры, перегрузить методы
расчета площади и вывода сведений о фигуре.Написать программу, демонстрирующую работу с
классом: дано N окружностей и M цилиндров, найти окружность максимальной площади и средний
объем цилиндров.*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace _4c_sharp
{
    class Circle
    {
        
        private double r;

        public double R { get => r; set => r = value; }

        public Circle()
        {

        }

        public Circle(double r)
        {
            //переменная используемая в поле класса
            this.R = r;
        }

        public double GetSquare()//площадь
        {
            return Math.Round(Math.PI * Math.Pow(this.R, 2),3);
        }

        public double GetL()//длина
        {
            return Math.Round(2 * Math.PI * this.R,3);
        }

        public override string ToString()//вывод информации
        {
            return $"\nРадиус: {this.R} \nДлина: { this.GetL()} \nПлощадь: { this.GetSquare()}";
        
        }

        public void Write(BinaryWriter bw)
        {
            // Все данные записываются по отдельности
            bw.Write(R);
            

        }

        public static Circle Read(BinaryReader br)
        {
            Circle f = new Circle();
            f.R = br.ReadDouble();
            
           
            return f;
        }


    }
}
