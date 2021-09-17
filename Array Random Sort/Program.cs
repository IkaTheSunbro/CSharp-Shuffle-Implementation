using System;
using System.Linq;
using System.Threading;
using static System.Console;
using static System.Convert;


namespace Array_Random_Sort
{
    public class Program
    {
        public static Random rnd = new Random();

        public static void Print(int[] pass)
        {

            foreach (var num in pass)
            {
                Write($"{num} ");
            }

            WriteLine();
        }

        static void Main(string[] args)
        {
            int[] password = new int[8];

            Initialize pass = new Initialize(ref password);

            Shuffler shuffle_1 = new ShuffleOne();
            shuffle_1.Shuffle(ref password);

            Shuffler shuffle_2 = new ShuffleTwo();
            shuffle_2.Shuffle(ref password);

            Shuffler shuffle_3 = new ShuffleThree();
            shuffle_3.Shuffle(ref password);

        }
    }

    class Initialize
    {
        public Initialize(ref int[] password)
        {
            for (int i = 0; i < password.Length; i++)
            {
                password[i] = Program.rnd.Next() % 10;
            }
        }
    }

    abstract class Shuffler
    {
        public abstract void Shuffle(ref int[] password);
    }

    class ShuffleOne : Shuffler
    {
        public override void Shuffle(ref int[] password)
        {
            for (int i = 0; i < password.Length; i++)
            {
                int swapIndex = Program.rnd.Next(password.Length - 1);
                int temp = password[swapIndex];
                password[swapIndex] = password[i];
                password[i] = temp;
            }

            Program.Print(password);
        }
    }

    class ShuffleTwo : Shuffler
    {

        public override void Shuffle(ref int[] password)
        {
            int[] selectedIndex = new int[password.Length];
            int[] newPass = new int[password.Length];

            foreach (var item in Enumerable.Range(0, password.Length))
            {
                selectedIndex[item] = password.Length;
            }

            for(int i = 0; i < password.Length; i++)
            {
                while (true)
                {
                    int index = Program.rnd.Next(password.Length);
                    if (selectedIndex.Contains(index))
                    {
                        continue;
                    }

                    selectedIndex[i] = index;
                    newPass[i] = password[index];
                    break;
                }
            }

            foreach (int num in Enumerable.Range(0, password.Length))
            {
                password[num] = newPass[num];
            }

            Program.Print(password);
        }
    }

    class ShuffleThree : Shuffler
    {

        public override void Shuffle(ref int[] password)
        {
            for (int j = 0; j < (Program.rnd.Next() % 10); j++)
            {
                for (int i = 0; i < password.Length - 1; i++)
                {
                    int temp = password[i];
                    password[i] = password[i + 1];
                    password[i + 1] = temp;
                    temp = password[0];
                    password[0] = password[password.Length - 1];
                    password[password.Length - 1] = temp;
                }
            }

            Program.Print(password);
        }
    }
}