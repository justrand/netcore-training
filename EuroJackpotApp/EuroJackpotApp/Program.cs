using System;

namespace EurojackpotApp
{

    public class Arvontakone
    {

        private int Numerot, Lisanumerot, Numerovali;

        public Arvontakone()
        {

        }

        public Arvontakone(int numerot, int lisanumerot, int numerovali)
        {
            Numerot = numerot;
            Lisanumerot = lisanumerot;
            Numerovali = numerovali;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Arvontakone eurojackpot = new Arvontakone();
        }
    }
}
