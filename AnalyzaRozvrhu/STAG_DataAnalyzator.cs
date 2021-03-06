﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnalyzaRozvrhu.STAG_Classes;
using System.Diagnostics;

namespace AnalyzaRozvrhu
{
    public enum Method
    {
        Hloupa_metoda,
        Normalni_metoda
    }

    public static class STAG_DataAnalyzator
    {
        public static void Analyzuj(this STAG_Classes.STAG_Database data, Method method)
        {
            // analyzuje, upravi objektz studenta a pod...
            switch (method)
            {
                case Method.Hloupa_metoda:
                    Fandova_hloupa_metoda(data);
                    break;
                case Method.Normalni_metoda:
                    Normalni_metoda(data);
                    break;
            }
        }

        #region Normalni metoda

        /// <summary>
        /// Analyza zateze pomoci SRA.
        /// </summary>
        /// <param name="data"></param>
        private static void Normalni_metoda(STAG_Database data)
        {
            Console.WriteLine("Nepoustej me! Ja nic neumim... :(");
        }

        #endregion

        #region Fandova metoda 

        private static void Fandova_hloupa_metoda(STAG_Database data)
        {
            foreach (var student in data.Students)
            {
                List<Predmet> kredityLS = new List<Predmet>();
                List<Predmet> kredityZS = new List<Predmet>();
                int maxKredituZS = 0;
                int maxKredituLS = 0;
                // projdu vsechny akce na ktere student chodi a ulozim nazev predmetu
                foreach (var akce in student.Rozvrh)
                {

                    if (akce.Semestr == "LS")
                    {
                        if (!kredityLS.Contains(akce.PredmetRef))
                            kredityLS.Add(akce.PredmetRef);
                    }
                    else
                    {
                        if (!kredityZS.Contains(akce.PredmetRef))
                            kredityZS.Add(akce.PredmetRef);
                    }
                }

                int a;
                if (student.OsCislo == "F13104")
                    a = 5;
                // spocteni kreditu ze vsech predmetu v ZS a LS
                maxKredituZS = (from predmet in kredityZS select predmet.Kreditu).Sum();
                maxKredituLS = (from predmet in kredityLS select predmet.Kreditu).Sum();
                if (maxKredituZS == 0)
                    continue;
                // spocteni zatizeni kateder v zimnim semestru
                SpoctiPodil(student.PodilKatedryZS, kredityZS, maxKredituZS);
                SpoctiPodil(student.PodilKatedry, kredityZS, maxKredituZS + maxKredituLS); // podil za oba semestry
                if (maxKredituLS == 0)
                    continue;
                // spocteni zatizeni kateder v letnim semestru
                SpoctiPodil(student.PodilKatedryLS, kredityLS, maxKredituLS);
                SpoctiPodil(student.PodilKatedry, kredityLS, maxKredituZS + maxKredituLS); // podil za oba semestry
                Debug.WriteLine("Hloupá analýza hotavá");
            }
        }

        private static void SpoctiPodil(Dictionary<string, double> podilKatedry, List<Predmet> kredity, int maxKreditu)
        {
            foreach (var predmet in kredity)
            {
                double podilPredmetu = (predmet.Kreditu / (double)maxKreditu * 100);

                int n = 0;
                if (predmet.JednotekCviceni != 0)
                    n++;
                if (predmet.JednotekPrednasek != 0)
                    n++;
                if (predmet.JednotekSeminare != 0)
                    n++;
                if (n == 0)
                { // pokud je pocet typu akci 0 tak se jedná o bp
                    if (!podilKatedry.ContainsKey(predmet.Katedra))
                        podilKatedry.Add(predmet.Katedra, 0);
                    podilKatedry[predmet.Katedra] += podilPredmetu;
                    continue;
                }

                if (predmet.JednotekCviceni != 0)
                    foreach (var katedra in predmet.PodilKatedryCviceni)
                    {
                        if (!podilKatedry.ContainsKey(katedra.Key))
                            podilKatedry.Add(katedra.Key, 0);
                        podilKatedry[katedra.Key] += podilPredmetu * (katedra.Value / n);
                    }

                if (predmet.JednotekPrednasek != 0)
                    foreach (var katedra in predmet.PodilKatedryPrednaska)
                    {
                        if (!podilKatedry.ContainsKey(katedra.Key))
                            podilKatedry.Add(katedra.Key, 0);
                        podilKatedry[katedra.Key] += podilPredmetu * (katedra.Value / n);
                    }

                if (predmet.JednotekSeminare != 0)
                    foreach (var katedra in predmet.PodilKatedrySeminar)
                    {
                        if (!podilKatedry.ContainsKey(katedra.Key))
                            podilKatedry.Add(katedra.Key, 0);
                        podilKatedry[katedra.Key] += podilPredmetu * (katedra.Value / n);
                    }

            }
        }

        #endregion
    }
}
