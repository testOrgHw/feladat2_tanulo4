using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Xml.Serialization;

namespace ModernLangToolsApp
{
    class Program
    {
        [Description("Feladat2")]
        static void serializeTest()
        {
            Console.WriteLine("2. Feladat: ");

            Jedi j = new Jedi();
            j.Nev = "Anakin Skywalker";
            j.KoloniaSzam = 20000;

            //'j' Jedi objektum kiíratása XML forátumú adatfájlba
            FileStream stream = null;
            try
            {
                stream = new FileStream("jedi.txt", FileMode.Create);
                XmlSerializer serializer = new XmlSerializer(typeof(Jedi));
                serializer.Serialize(stream, j);
            }
            catch (Exception e)
            {
                Console.WriteLine("Az objektum kiíratása nem sikerült!");
                Console.WriteLine(e.Message);
            }
            finally
            {
                if(stream != null)
                {
                    stream.Close();
                }
            }

            //Az XML forátumú adatfájl beolvasása
            stream = null;
            try
            {
                stream = new FileStream("jedi.txt", FileMode.Open);
                XmlSerializer serializer = new XmlSerializer(typeof(Jedi));
                Jedi clone = (Jedi)serializer.Deserialize(stream);
                Console.WriteLine("Nev: {0}\tMidiChlorian szam: {1}", clone.Nev, clone.KoloniaSzam);
            }
            catch (Exception e)
            {
                Console.WriteLine("Az fájl beolvasása nem sikerült!");
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                }
            }
        }

        static void dzsedikInicializálása(JediCouncil council)
        {
            Jedi elsoJedi = new Jedi();
            elsoJedi.Nev = "Anakin Skywalker";
            elsoJedi.KoloniaSzam = 20000;

            Jedi masodik = new Jedi();
            masodik.Nev = "Obi-Wan Kenobi";
            masodik.KoloniaSzam = 10000;

            Jedi mace = new Jedi();
            mace.Nev = "Mace Windu";
            mace.KoloniaSzam = 299;

            Jedi plo = new Jedi();
            plo.Nev = "plo koon";
            plo.KoloniaSzam = 100;

            council.Add(elsoJedi);
            council.Add(masodik);
            council.Add(mace);
            council.Add(plo);
        }

        //CouncilChangingDelegate-nek megfelelő felépítésű metódus
        //Az üzenetek consolra íratásához
        static void MessageReceived(string msg)
        {
            Console.WriteLine(msg);
        }

        [Description("Feladat3")]
        static void jediCouncilTest()
        {
            Console.WriteLine("\n3. Feladat: ");

            JediCouncil council = new JediCouncil();
            //A MessageReceived metódus beregisztrálása a CouncilChanging eseményre
            council.valtozas += MessageReceived;

            dzsedikInicializálása(council);

            council.Torles();
            council.Torles();
            council.Torles();
            council.Torles();

            //A MessageReceived metódus leiratkoztatása a CouncilChanging eseményre
            council.valtozas -= MessageReceived;
        }

        [Description("Feladat4")]
        static void beginnersTest()
        {
            Console.WriteLine("\n4. Feladat: ");

            JediCouncil council = new JediCouncil();

            dzsedikInicializálása(council);

            //A kezdő Jedik lekérése és kilistázása
            List<Jedi> beginners = council.Kezdok();
            foreach (Jedi j in beginners)
            {
                Console.WriteLine("Nev: {0}\tMidiChlorian szam: {1}", j.Nev, j.KoloniaSzam);
            }
        }

        static void Main(string[] args)
        {
            serializeTest();
            jediCouncilTest();
            beginnersTest();

            Console.ReadKey();
        }
    }
}
