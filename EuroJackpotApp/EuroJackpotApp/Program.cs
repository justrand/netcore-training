using System;
using System.Collections.Generic;

/// <summary>
/// 
/// Eurojackpot-arvontakone
/// 
/// Authors: nimu, just
/// 
/// Created: 20.02.2019
/// 
/// </summary>
namespace EurojackpotApp
{
    /// <summary>
    /// Arvontakone-luokka
    /// </summary>
    public class Arvontakone
    {

        public List<int> ArvotutNumerot { get; private set; }
        public List<int> ArvotutLisaNumerot { get; private set; }
        
        private readonly int NumerotLkm, LisanumerotLkm;
        private List<int> ArvontaJoukko;
        private readonly int[] NumeroVali, LisaNumeroVali;
        private Random Rnd;

        /// <summary>
        /// Constructor
        /// Alustetaan random
        /// </summary>
        /// <param name="numerotLkm">Arvottavien numeroiden lukumäärä</param>
        /// <param name="lisanumerotLkm">Arvottavien lisänumeroiden lukumäärä</param>
        /// <param name="numeroVali">Väli, josta numeroita arvotaan</param>
        /// <param name="lisaNumeroVali">Väli, josta lisänumeroita arvotaan</param>
        public Arvontakone(int numerotLkm, int lisanumerotLkm, int[] numeroVali, int[] lisaNumeroVali)
        {
            NumerotLkm = numerotLkm;
            LisanumerotLkm = lisanumerotLkm;
            NumeroVali = numeroVali;
            LisaNumeroVali = lisaNumeroVali;
            Rnd = new Random();
            Reset();
        }

        public void Reset()
        {
            ArvontaJoukko = new List<int>();
            int[] temp = new int[(NumeroVali[1] - NumeroVali[0]+1)];
            for (int i = 0; i < NumeroVali[1]; i++)
            {
                temp[i] = NumeroVali[0]+i;
            }
            ArvontaJoukko.AddRange(temp);
        }

        /// <summary>
        /// Asetetaan arvotut numerot ja lisänumerot
        /// Käytetään excludelistiä, jotta toiseen settiin ei tule
        /// samoja arvoja kuin ekaan
        /// </summary>
        public void CalculateRandomSets()
        {
            ArvotutNumerot = GetRandomSet(NumeroVali, NumerotLkm);
            ArvotutLisaNumerot = GetRandomSet(LisaNumeroVali, LisanumerotLkm);
        }

        /// <summary>
        /// Laskee seuraavan satunnaisen numeron
        /// </summary>
        /// <param name="numeroVali">Väli, josta seuraava numero lasketaan</param>
        /// <returns>Seuraava satunnainen numero</returns>
        private int CalculateNext(int[] numeroVali)
        {
            if (numeroVali.Length == 2) {
                int index = Rnd.Next(0, ArvontaJoukko.Count - 1);
                int rv = ArvontaJoukko[index];
                ArvontaJoukko.RemoveAt(index);
                return rv;
            }
            else
            {
                throw new Exception("Incorrect array size");
            }
        }    

        /// <summary>
        /// Hakee satunnaisen listan annetulta numeroväliltä
        /// Ei salli duplikaattiarvoja
        /// </summary>
        /// <param name="numeroVali">Annettu numeroväli</param>
        /// <param name="lkm">Satunnaisten numerodien lukumäärä listalle</param>
        /// <returns>Satunnainen lista numeroita</returns>
        private List<int> GetRandomSet(int[] numeroVali, int lkm)
        {
            List<int> numeroLista = new List<int>();
            while (numeroLista.Count < lkm)
            {
                try
                {
                    int numero = CalculateNext(numeroVali);
                    numeroLista.Add(numero);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            numeroLista.Sort();
            return numeroLista;
        }
    }

    /// <summary>
    /// Program-luokka
    /// Täällä pääohjelma, joka ajetaan.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Pääohjelma
        /// Kysytään käyttäjältä input (halutaanko uusi rivi)
        /// Luodaan arvontakone ja haetaan numerot, sekä tulostetaan ne
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Arvontakone eurojackpot = new Arvontakone(5, 2, new[] { 1, 50 }, new[] { 1, 10 });

            bool run = true;
            while (run)
            {
                Console.WriteLine("Syötä 1 saadaksesi uuden lottorivin...");
                string input = Console.ReadLine();
                if (input == "1")
                {
                    eurojackpot.CalculateRandomSets();
                    Console.WriteLine("Arvotut numerot:");
                    eurojackpot.ArvotutNumerot.ForEach(i => Console.Write("{0}\t", i));
                    Console.Write("\n");
                    eurojackpot.ArvotutLisaNumerot.ForEach(i => Console.Write("{0}\t", i));
                    Console.Write("\n");
                }
                else
                {
                    run = false;
                }
            }
        }
    }
}