using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7._2
{
    public abstract class Jump
    {
        protected string Name;
        protected double[] Marks;
        protected double Summ;
        public double SummMarks => Summ;
        public Jump(string name, double[] marks)
        {
            Name = name;
            Marks = marks;
            Summ = 0;
            for (int i = 0; i < Marks.Length; i++) { Summ += Marks[i]; }
        }
        public void Print() => Console.WriteLine("{0}\t {1}", Name, Summ);
        public static void QuickSort(Jump[] sportsman, int a, int b)
        {
            Jump mind = sportsman[(a + b) / 2];
            int i = a;
            int j = b;
            while (i <= j)
            {
                while (sportsman[i].SummMarks > mind.SummMarks)
                {
                    i++;
                }
                while (sportsman[j].SummMarks < mind.SummMarks)
                {
                    j--;
                }
                if (i <= j)
                {
                    Jump jump = sportsman[i];
                    sportsman[i] = sportsman[j];
                    sportsman[j] = jump;
                    i++;
                    j--;
                }
            }
        }
        public abstract string Discipline { get; }
    }
    public class Jumpin3m : Jump
    {
        public override string Discipline => "Прыжки с 3-метровой доски";
        public Jumpin3m(string name, double[] marks) : base(name, marks) { }
    }

    public class Jumpin5m : Jump
    {
        public override string Discipline => "Прыжки с 5-метровой доски";
        public Jumpin5m(string name, double[] marks) : base(name, marks) { }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Jump[] sportsman = new Jump[5];
            sportsman[0] = new Jumpin3m("Павлов", new double[] { 0.5, 0, 0, 0.5, 1, 0 });
            sportsman[1] = new Jumpin3m("Попов", new double[] { 1, 1, 0, 0.5, 0, 0.5 });
            sportsman[2] = new Jumpin3m("Ли", new double[] { 0, 1, 1, 0.5, 0, 1 });
            sportsman[3] = new Jumpin5m("Ким", new double[] { 0, 0, 1, 0.5, 0, 1 });
            sportsman[4] = new Jumpin5m("Блоков", new double[] { 1, 1, 1, 0.5, 0, 0 });

            Console.WriteLine("Фамилия\t Набранные баллы");
            foreach (var sportsmen in sportsman)
                sportsmen.Print();

            Jump.QuickSort(sportsman, 0, sportsman.Length - 1);

            Console.WriteLine();
            Console.WriteLine("Место\tФамилия\t Набранные баллы");
            for (int i = 0; i < sportsman.Length; i++)
            {
                Console.Write($"{i + 1}\t");
                sportsman[i].Print();
            }
        }
    }

}
