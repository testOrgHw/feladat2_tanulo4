using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ModernLangToolsApp
{
    public class Jedi
    {
        //Attribútum: XML formátumú adatfájlban a tulajdonság attribútumként, "Nev" néven jelenjen meg
        [XmlAttribute("Nev")]
        //Auto implemented property: A jedi nevének lekérdezése és beállítása
        public string Nev { get; set; }

        //Privát tagváltozó a midichlorian számhoz
        private int kolniasize;

        //Attribútum: XML formátumú adatfájlban a tulajdonság attribútumként, "MidiChlorianSzam" néven jelenjen meg
        [XmlAttribute("KoloniaSzam")]
        //Property: A jedi midichlorianjainak számának lekérdezés és beállítása
        public int KoloniaSzam
        {
            //privát tagváltozó lekérdezése
            get { return kolniasize; }
            //privát tagváltozó értékének beállítása a feltételnek megfelelően érékkel
            set
            {
                if(value <= 10)
                {
                    throw new ArgumentException("You are not a true jedi!");
                }
                kolniasize = value;
            }
        }
    }
}
