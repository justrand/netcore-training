using System;
using System.Collections.Generic;
namespace EurojackpotApp
{

    public class Arvontakone
    {

        private int NumerotLkm, LisanumerotLkm;
        public List<int> ArvotutNumerot { get; private set; }
        public List<int> ArvotutLisaNumerot { get; private set; }
        private int[] NumeroVali, LisaNumeroVali;
        private Random Rnd;
        
        public Arvontakone()
        {

        }

        public Arvontakone(int numerotLkm, int lisanumerotLkm, int[] numeroVali, int[] lisaNumeroVali)
        {
            NumerotLkm = numerotLkm;
            LisanumerotLkm = lisanumerotLkm;
            NumeroVali = numeroVali;
            LisaNumeroVali = lisaNumeroVali;
            Rnd = new Random();
        }

        public void CalculateRandomSets()
        {
            ArvotutNumerot = GetRandomSet(NumeroVali, NumerotLkm);
            ArvotutLisaNumerot = GetRandomSet(LisaNumeroVali, LisanumerotLkm);

        }

        private int CalculateNext(int[] numeroVali)
        {
            if (numeroVali.Length == 2) {
                return Rnd.Next(numeroVali[0], numeroVali[1]);
            }
            else
            {
                throw new Exception("Incorrect array size");
            }
        }    

        private List<int> GetRandomSet(int[] numeroVali, int lkm)
        {
            List<int> numeroLista = new List<int>();
            while (numeroLista.Count < lkm)
            {
                int numero = CalculateNext(numeroVali);
                if (!numeroLista.Contains(numero))
                {
                    numeroLista.Add(numero);
                }
            }
            numeroLista.Sort();
            return numeroLista;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            
            Arvontakone eurojackpot = new Arvontakone(5, 2, new[] { 1, 50 }, new[] { 1, 10 });
            eurojackpot.CalculateRandomSets();
            Console.WriteLine("Arvotut numerot:");
            eurojackpot.ArvotutNumerot.ForEach(i => Console.Write("{0}\t", i));
            Console.Write("\n");
            eurojackpot.ArvotutLisaNumerot.ForEach(i => Console.Write("{0}\t", i));
            Console.Write("\n");
        }
    }
}
