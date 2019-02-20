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

        public int calculateNext()
        {
            return 1;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Arvontakone eurojackpot = new Arvontakone();

            Console.WriteLine("Hello World!");
        }
    }
}
