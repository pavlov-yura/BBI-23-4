using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7._3
{
    internal class Program
    {

        abstract class Team
        {
            protected string Name;
            protected int Score;
            public int Result { get { return Score; } }
            public Team(string name, int score)
            {
                Name = name;
                Score = score;
            }
            public abstract void Print();
        }

        class WomanTeam : Team
        {
            public WomanTeam(string name, int score) : base(name, score) { }
            public override void Print()
            {
                Console.WriteLine($"{Name} (Woman): {Score}");
            }
        }

        class ManTeam : Team
        {
            public ManTeam(string name, int score) : base(name, score) { }
            public override void Print()
            {
                Console.WriteLine($"{Name} (Man): {Score}");
            }
        }
        static void Main(string[] args)
        {
            WomanTeam[] groupWoman = new WomanTeam[5] { new WomanTeam("Добровa", 6), new WomanTeam("Злова", 7), new WomanTeam("Шойгу", 3), new WomanTeam("Фетова", 4), new WomanTeam("Чехова", 6) };
            ManTeam[] groupMan = new ManTeam[5] { new ManTeam("Павлов", 5), new ManTeam("Попов", 6), new ManTeam("Ли", 8), new ManTeam("Ким", 4), new ManTeam("Блоков", 9) };

            Console.WriteLine("\nРезультаты женской команды:"); //Исходные результаты женской команды
            Sortirovka(groupWoman);
            PrintResults(groupWoman);

            Console.WriteLine("\nРезультаты мужской команды:"); //Исходные результа мужской команды
            Sortirovka(groupMan);
            PrintResults(groupMan);

            Console.WriteLine($"\nРезультаты команды победителей: "); //Результаты команды победителя
            FindWinner(groupWoman, groupMan).Print();
        }

        static void PrintResults(Team[] group) //вывод
        {
            foreach (var participant in group)
            {
                participant.Print();
            }
        }
        static Team FindWinner(Team[] group1, Team[] group2)  //нахождение команды победителя
        {
            if (group1[0].Result > group2[0].Result) { return group1[0]; }
            else { return group2[0]; };
        }
        static void Sortirovka(Team[] info)
        {
            for (int i = 0; i < info.Length - 1; i++)  //Сортировка пузырьком по убыванию
            {
                for (int j = i + 1; j < info.Length; j++)
                {
                    if (info[j].Result > info[i].Result)
                    {
                        Team pomoch = info[j];
                        info[j] = info[i];
                        info[i] = pomoch;
                    }
                }
            }
        }
    }
}
