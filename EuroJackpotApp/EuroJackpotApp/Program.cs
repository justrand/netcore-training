using System;
using System.Collections.Generic;

/// <summary>
/// 
/// Eurojackpot-arvontakone
/// 
/// Authors: nimu, just
/// 
/// </summary>
namespace EurojackpotApp
{
    /// <summary>
    /// Arvontakone-luokka
    /// </summary>
    public class Arvontakone
    {

        private int NumerotLkm, LisanumerotLkm;
        public List<int> ArvotutNumerot { get; private set; }
        public List<int> ArvotutLisaNumerot { get; private set; }
        public List<int> ExcludeList { get; private set; } = new List<int>();
        private int[] NumeroVali, LisaNumeroVali;
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
        }

        /// <summary>
        /// Asetetaan arvotut numerot ja lisänumerot
        /// Käytetään excludelistiä, jotta toiseen settiin ei tule
        /// samoja arvoja kuin ekaan
        /// </summary>
        public void CalculateRandomSets()
        {
            ArvotutNumerot = GetRandomSet(NumeroVali, NumerotLkm);
            ExcludeList = ArvotutNumerot;
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
                return Rnd.Next(numeroVali[0], numeroVali[1]);
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
                int numero = CalculateNext(numeroVali);
                if (!numeroLista.Contains(numero) && !ExcludeList.Contains(numero))
                {
                    numeroLista.Add(numero);
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
        /// Luodaan arvontakone ja haetaan numerot, sekä tulostetaan ne
        /// </summary>
        /// <param name="args"></param>
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