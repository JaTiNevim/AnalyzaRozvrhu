﻿// Generated by Xamasoft JSON Class Generator
// http://www.xamasoft.com/json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;

namespace AnalyzaRozvrhu.STAG_Classes
{    

    public class HodinaSkutOd
    {

        [JsonProperty("value")]
        public DateTime Value { get; set; }
    }

    public class HodinaSkutDo
    {

        [JsonProperty("value")]
        public DateTime Value { get; set; }
    }



    /// <summary>
    /// Zakladni objekt pro Rozvrhovou akci tak, jak ji pouziva STAG
    /// </summary>
    public class RozvrhovaAkce
    {
        public RozvrhovaAkce()
        {
            referenceCount = 0;
            VsichniUcitele = new List<Ucitel>(1);
        }
        public int referenceCount;

        [JsonProperty("roakIdno", NullValueHandling = NullValueHandling.Ignore)]
        public int RoakIdno { get; set; }



        [JsonProperty("katedra")]
        public string Katedra { get; set; }

        [JsonProperty("predmet")]
        public string Predmet { get; set; }

        public Predmet PredmetRef;


        [JsonProperty("statut")]
        public string Statut { get; set; }





        [JsonProperty("budova")]
        public string Budova { get; set; }

        [JsonProperty("mistnost")]
        public string Mistnost { get; set; }





        [JsonProperty("obsazeni")]
        public int Obsazeni { get; set; }



        [JsonProperty("typAkceZkr")]
        public string TypAkceZkr { get; set; }

        [JsonProperty("semestr")]
        public string Semestr { get; set; }




        [JsonProperty("denZkr")]
        public string DenZkr { get; set; }

        [JsonProperty("hodinaOd")]
        public int? HodinaOd { get; set; }

        [JsonProperty("hodinaDo")]
        public int? HodinaDo { get; set; }



        [JsonProperty("hodinaSkutOd")]
        private HodinaSkutOd _HodinaSkutOd { get; set; }
        public DateTime HodinaSkutOd { get { return _HodinaSkutOd.Value; } }

        [JsonProperty("hodinaSkutDo")]
        private HodinaSkutDo _HodinaSkutDo { get; set; }
        public DateTime HodinaSkutDo { get { return _HodinaSkutDo.Value; } }



        [JsonProperty("tydenOd")]
        public int TydenOd { get; set; }

        [JsonProperty("tydenDo")]
        public int TydenDo { get; set; }




        [JsonProperty("tydenZkr")]
        public string TydenZkr { get; set; }

        [JsonProperty("grupIdno")]
        public int? GrupIdno { get; set; }







        [JsonProperty("druhAkce")]
        public string DruhAkce { get; set; }

        [JsonProperty("vsichniUciteleUcitIdno")]
        private string _VsichniUciteleUcitIdno { get; set; }
        /// <summary>
        /// Vrati list vsech ucitelu na dane ra
        /// </summary>
        public List<int> VsichniUciteleUcitIdno { get {
                List<int> r = new List<int>(1);

                if (_VsichniUciteleUcitIdno == "")
                {
                    return r;
                }                
                foreach (var id in _VsichniUciteleUcitIdno.Replace(" ", "").Split(','))
                    r.Add(Convert.ToInt32(id));
                return r;
            } }
        public List<Ucitel> VsichniUcitele { get; set; }


        /// <summary>
        /// ToString() pro testovaci vypis
        /// </summary>
        /// <returns>testovaci vypis</returns>
        public override string ToString()
        {
            return string.Format("[O{0}-R{1}]{2}<{3}={4}>", this.Obsazeni, this.referenceCount,this.VsichniUciteleUcitIdno.Count>1?"**":"",this.VsichniUciteleUcitIdno.Count,this.VsichniUcitele.Count);
        }
    }



}
