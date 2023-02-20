using Nepesseg.Interfészek;
using Nepesseg.Modellek;

namespace Nepesseg.Adatkezelők
{
    public class CSVtarolo : BaseAdattarolo
    {
        //Osztálymetódus. Feladata miatt nevezik gyártófüggvénynek is.
        //"Megye kód";"KSH kód";Megye;Település;"Település típusa";"Állandó férfi lakosság összesen";"Állandó női lakosság összesen"
        /// <summary>
        /// Egy adott szerkezetű CSV formátumú sorból hoz létre egy Telepules objektumot.
        /// </summary>
        /// <param name="csvSor">Karakterlánc, amiben az adatok ;-vel vannak elválasztva</param>
        /// <returns>Telepules objektum a megadott értékkel</returns>
        private static Telepules TelepulestGyarto(String csvSor)
        {
            string[] tagok = csvSor.Split(';');
            for (int _index = 5; _index < 7; _index++)
            {
                tagok[_index] = tagok[_index].Replace(" ", "");
            }
            Telepules uj = new Telepules(tagok[2],
                                         tagok[3],
                                         TelepulesTipusFromString(tagok[4]),
                                         int.Parse(tagok[5]),
                                         int.Parse(tagok[6]));
            return uj;
        }

        public CSVtarolo(string fajlnev)
        {
            foreach (var CSVsor in File.ReadAllLines(fajlnev).Skip(1))
            {
                Telepulesek.Add(CSVtarolo.TelepulestGyarto(CSVsor));
            }
        }

        public override List<Telepules> SzurTelepulesTipusra(TelepulesTipus tipus)
        {
            throw new NotImplementedException("Ezt még implementálni kellene mielőtt meghívja!");
        }

        public override List<Telepules> SzurMegyere(string megye)
        {
            throw new NotImplementedException("Ezt még implementálni kellene mielőtt meghívja!");
        }
        public override int MegyeFerfiLakosai(string megye)
        {
            throw new NotImplementedException("Ezt még implementálni kellene mielőtt meghívja!");
        }

        public override int MegyeNoiLakosai(string megye)
        {
            throw new NotImplementedException("Ezt még implementálni kellene mielőtt meghívja!");
        }

        public override Dictionary<TelepulesTipus, int> MegyeTelepulesSzama(string? megye)
        {
            throw new NotImplementedException("Ezt még implementálni kellene mielőtt meghívja!");
        }

        public override Dictionary<TelepulesTipus, int> MegyeTelepulesenkentiLakossag(string? megye)
        {
            throw new NotImplementedException("Ezt még implementálni kellene mielőtt meghívja!");
        }

        public override int LakosokSzam(string telepulesNeve)
        {
            throw new NotImplementedException("Ezt még implementálni kellene mielőtt meghívja!");
        }

    }
}
