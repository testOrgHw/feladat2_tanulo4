using System;
using System.Collections.Generic;
using System.Text;

namespace ModernLangToolsApp
{
    class JediCouncil
    {
        private List<Jedi> jedis = new List<Jedi>();

        //Delegate: Metódusreferencia egy string paraméterrel és void visszatérési értékkel
        public delegate void KonzulensValtozasDelegate(string msg);
        //Event: Fent lévő delegate típusú esemény, amire más osztályok feliratkozhatnak, de ezen osztályon belül süthető el
        public event KonzulensValtozasDelegate valtozas;

        public void Add(Jedi j)
        {
            jedis.Add(j);
            if(valtozas != null)
            {
                valtozas("A tanács új taggal bővült.");
            }
        }

        public void Torles()
        {
            jedis.RemoveAt(jedis.Count - 1);
            if (valtozas != null)
            {
                valtozas((jedis.Count > 0) ? "A tanácsból egy tag eltávolításra került." : "A tanácsból az utolsó tag is eltávolításra került.");
            }
        }

        //Szűrőfüggvény, mely igaz értékkel tér vissza ha a Jedi kezdő azaz midichlorain száma < 300, egyébként hamis.
        //Ezt a szűrőt a GetBeginners metódusban használom a 'jedis' listában lévő kezdő Jedik kiválasztásához.
        private bool Filter(Jedi j)
        {
            return j.KoloniaSzam < 300;
        }

        //A Filter metódus segítségével kiválasztja a 'jedis' listában lévő kezdőket és lista formájában visszaadja-
        public List<Jedi> Kezdok()
        {
            return jedis.FindAll(Filter);
        }
    }
}
