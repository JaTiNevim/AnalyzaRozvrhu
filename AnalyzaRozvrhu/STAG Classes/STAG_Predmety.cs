﻿// Generated by Xamasoft JSON Class Generator
// http://www.xamasoft.com/json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AnalyzaRozvrhu.STAG_Classes
{
    /// <summary>
    /// Objektová reprezentace pro predmět ze souboru získaného ze služby getPredmetInfo nebo predmetyByFakultaFullInfo
    /// </summary>
    /// <remarks> Určeno pro návrat z této služby https://ws.ujep.cz/ws/service-help/rest/predmety/getPredmetInfo nebo https://ws.ujep.cz/ws/service-help/rest/predmety/getPredmetyByFakulta. Pro deserializaci je nutný json. Pro lepší pochopení dat v této třídě doporučuji nahlédnout do staženého souboru.
    /// Skutečné názvy soupců (nebo json atributů chceteli) jsou vždy obsaženy v tagu [JsonProperty("nazev")] 
    /// </remarks>
    public class Predmet
    {
        /// <summary>
        /// Konstruktor určený pro inicializaci všech potřebných věcí
        /// </summary>
        public Predmet()
        {
            // Inicializace promennych
            VsechnyAkce = new List<RozvrhovaAkce>();

            // Sem přidejte inicializaci nějakých list, Dictionary když to bude potřeba. 
        }

        /// <summary>
        /// Zkratka katedry pod který patří předmět (např. KI)
        /// </summary>
        [JsonProperty("katedra")]
        public string Katedra { get; set; }

        /// <summary>
        /// Zkratka (kód) předmětu (např. 0192)
        /// </summary>
        [JsonProperty("zkratka")]
        public string Zkratka { get; set; }

       
        /// <summary>
        /// Počet kreditů za splnění předmětu
        /// </summary>
        [JsonProperty("kreditu")]
        public int Kreditu { get; set; }


        [JsonProperty("vyukaZS")]
        private string _VyukaZS;
        /// <summary>
        /// Informace o tom, zda se predmet vyučuje v zimním semestru (true/false)
        /// </summary>
        public bool VyukaZS { get { return _VyukaZS == "A" ? true : false; } }


        [JsonProperty("vyukaLS")]
        private string _VyukaLS;
        /// <summary>
        /// Informace o tom, zda se predmet vyučuje v letním semestru (true/false)
        /// </summary>
        public bool VyukaLS { get { return _VyukaLS == "A" ? true : false; } }

        /// <summary>
        /// Název předmětu - např "Analýza a vizualizace dat"
        /// </summary>
        [JsonProperty("nazev")]
        public string Nazev { get; set; }

        // Informace pro správnou rozvrhovanost 

        /// <summary>
        /// Počet jednotek přednášek
        /// </summary>
        [JsonProperty("jednotekPrednasek")]
        public int JednotekPrednasek { get; set; }
        /// <summary>
        /// Jednotka přednášek (např. HOD/TYD , HOD/SEM, DNU/SEM )
        /// </summary>
        [JsonProperty("jednotkaPrednasky")]
        public string JednotkaPrednasky { get; set; }
        /// <summary>
        /// Počet jednotek cvičení
        /// </summary>
        [JsonProperty("jednotekCviceni")]
        public int JednotekCviceni { get; set; }
        /// <summary>
        /// Jednotka cvičení (např. HOD/TYD , HOD/SEM, DNU/SEM )
        /// </summary>
        [JsonProperty("jednotkaCviceni")]
        public string JednotkaCviceni { get; set; }
        /// <summary>
        /// Počet jednotek semináře
        /// </summary>
        [JsonProperty("jednotekSeminare")]
        public int JednotekSeminare { get; set; }
        /// <summary>
        /// Jednotka seminářů (např. HOD/TYD , HOD/SEM, DNU/SEM )
        /// </summary>
        [JsonProperty("jednotkaSeminare")]
        public string JednotkaSeminare { get; set; }


        // Ucitele k predmetu
        /// <summary>
        /// Řetězec s jmény a tituly všech přednášejících (např. 'Ing. Mgr. Jiří Barilla, CSc.', 'doc. RNDr. Karel Oliva, Ph.D.') 
        /// </summary>
        [JsonProperty("prednasejici")]
        public string Prednasejici { get; set; }
        /// <summary>
        /// Řetězec se všemi ucitIdno přednášejících (např. 449, 2240 )
        /// </summary>
        [JsonProperty("prednasejiciUcitIdno")]
        public string PrednasejiciUcitIdno { get; set; }


        /// <summary>
        /// Řetězec s jmény a tituly všech cvičících (např. 'Ing. Mgr. Jiří Barilla, CSc.', 'doc. RNDr. Karel Oliva, Ph.D.') 
        /// </summary>
        [JsonProperty("cvicici")]
        public string Cvicici { get; set; }
        /// <summary>
        /// Řetězec se všemi ucitIdno cvičících (např. 449, 2240 )
        /// </summary>
        [JsonProperty("cviciciUcitIdno")]
        public string CviciciUcitIdno { get; set; }


        /// <summary>
        /// Řetězec s jmény a tituly všech seminářících (např. 'Ing. Mgr. Jiří Barilla, CSc.', 'doc. RNDr. Karel Oliva, Ph.D.') 
        /// </summary>
        [JsonProperty("seminarici")]
        public string Seminarici { get; set; }
        /// <summary>
        /// Řetězec se všemi ucitIdno seminářících (např. 449, 2240 )
        /// </summary>
        [JsonProperty("seminariciUcitIdno")]
        public string SeminariciUcitIdno { get; set; }



        /// <summary>
        /// Všechny rozvrhové akce které vyučují tento předmět ze studentských rozvrhů
        /// </summary>
        /// <remarks> Obsahuje reference na všechny rozvrhové akce tohoto předmětu, které byly získány z rozvrhů studentů. Doplňují se hned při načítání souborů.</remarks>
        public List<RozvrhovaAkce> VsechnyAkce { get; private set; }


         

        /// <summary>
        /// TODO!
        /// Prepocitany nebo z tabulky zjisteny pocet hodin za semestr pro přednášku
        /// </summary>
        public int HodinZaSemestrPr { get; set; }

        /// <summary>
        /// TODO!
        /// Prepocitany nebo z tabulky zjisteny pocet hodin za semestr pro seminar
        /// </summary>
        public int HodinZaSemestrSe { get; set; }

        /// <summary>
        /// TODO!
        /// Prepocitany nebo z tabulky zjisteny pocet hodin za semestr pro cv
        /// </summary>
        public int HodinZaSemestrCv { get; set; }


        /// <summary>
        /// Maximální velikost skupiny na Pr pokud null tak nebyla zadaná z tabulky
        /// </summary>
        /// <remarks>Pokud je hodnota non-null, používá se při rozpočítávání průměrného počtu studentů na přednáškách tohoto předmětu. Pokud je null, počítá se s obsazením rozvrhových akcích jak jsou zadány v rozvrhových akcích</remarks>
        public int? VelikostSkupinyPr { get; set; }
        /// <summary>
        /// Maximální velikost skupiny na Cv pokud null tak nebyla zadaná z tabulky
        /// </summary>
        /// <remarks>Pokud je hodnota non-null, používá se při rozpočítávání průměrného počtu studentů na cvičeních tohoto předmětu. Pokud je null, počítá se s obsazením rozvrhových akcích jak jsou zadány v rozvrhových akcích</remarks>
        public int? VelikostSkupinyCv { get; set; }
        /// <summary>
        /// Maximální velikost skupiny na Se pokud null tak nebyla zadaná z tabulky
        /// </summary>
        /// <remarks>Pokud je hodnota non-null, používá se při rozpočítávání průměrného počtu studentů na seminářích tohoto předmětu. Pokud je null, počítá se s obsazením rozvrhových akcích jak jsou zadány v rozvrhových akcích</remarks>
        public int? VelikostSkupinySe { get; set; }


        /// <summary>
        /// TODO!
        /// Podil katedry na výuce (Prednaska) key=katedra, value=podíl z intervalu <0,1>
        /// Soucet podilu = 1!
        /// </summary>
        /// <remarks>I v případě, že se jedná o jednuduchý předmět, vždy by se zde měla vyskytovat alespoň jedna katedra, kterou rozvrhová akce tohoto typu a tohoto předmětu zatěžuje.</remarks>
        public Dictionary<string,double> PodilKatedryPrednaska { get; set; }
        /// <summary>
        /// TODO!
        /// Podil katedry na výuce (Cviceni) key=katedra, value=podíl z intervalu <0,1>
        /// Soucet podilu = 1!
        /// </summary>
        /// <remarks>I v případě, že se jedná o jednuduchý předmět, vždy by se zde měla vyskytovat alespoň jedna katedra, kterou rozvrhová akce tohoto typu a tohoto předmětu zatěžuje.</remarks>
        public Dictionary<string, double> PodilKatedryCviceni { get; set; }
        /// <summary>
        /// TODO!
        /// Podil katedry na výuce (Seminar) key=katedra, value=podíl z intervalu <0,1>
        /// Soucet podilu = 1!
        /// </summary>
        /// <remarks>I v případě, že se jedná o jednuduchý předmět, vždy by se zde měla vyskytovat alespoň jedna katedra, kterou rozvrhová akce tohoto typu a tohoto předmětu zatěžuje.</remarks>
        public Dictionary<string, double> PodilKatedrySeminar { get; set; }
                
    }

    public class PredmetResponse
    {

        [JsonProperty("predmetInfo")]
        public Predmet[] PredmetInfo { get; set; }
    }

}
