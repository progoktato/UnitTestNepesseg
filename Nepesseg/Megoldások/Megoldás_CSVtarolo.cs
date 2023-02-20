using Nepesseg.Interfészek;
using Nepesseg.Modellek;

namespace Nepesseg.Megoldások
{
    public class Megoldás_CSVtarolo : BaseAdattarolo
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

        public Megoldás_CSVtarolo(string fajlnev)
        {
            foreach (var CSVsor in File.ReadAllLines(fajlnev).Skip(1))
            {
                Telepulesek.Add(Megoldás_CSVtarolo.TelepulestGyarto(CSVsor));
            }
        }

        public override List<Telepules> SzurTelepulesTipusra(TelepulesTipus tipus)
        {
            List<Telepules> szurtLista = Telepulesek.Where(tel => tel.TelepulesTipusa == tipus).ToList();
            return szurtLista;
        }

        public override List<Telepules> SzurMegyere(string megye)
        {
            List<Telepules> szurtLista = Telepulesek.Where(tel => tel.Megye == megye).ToList();
            return szurtLista;
        }
        public override int MegyeFerfiLakosai(string megye)
        {
            return Telepulesek.Where(t => t.Megye == megye).Sum(t => t.FerfiLakossag);
        }

        public override int MegyeNoiLakosai(string megye)
        {
            return Telepulesek.Where(t => t.Megye == megye).Sum(t => t.NoiLakossag);
        }

        public override Dictionary<TelepulesTipus, int> MegyeTelepulesSzama(string? megye)
        {
            Dictionary<TelepulesTipus, int> _szotar = new Dictionary<TelepulesTipus, int>();
            for (TelepulesTipus i = TelepulesTipus.fővárosi_kerület; i <= TelepulesTipus.község; i++)
                _szotar.Add(i, 0);
            foreach (var item in Telepulesek.Where(tel => tel.Megye == megye))
            {
                _szotar[item.TelepulesTipusa]++;
            }
            return _szotar;
        }

        public override Dictionary<TelepulesTipus, int> MegyeTelepulesenkentiLakossag(string? megye)
        {
            Dictionary<TelepulesTipus, int> _szotar = new Dictionary<TelepulesTipus, int>();
            for (TelepulesTipus i = TelepulesTipus.fővárosi_kerület; i <= TelepulesTipus.község; i++)
                _szotar.Add(i, 0);
            foreach (var item in Telepulesek.Where(tel => tel.Megye == megye))
            {
                _szotar[item.TelepulesTipusa] += item.NoiLakossag + item.FerfiLakossag;
            }
            return _szotar;
        }

        public override int LakosokSzam(string telepulesNeve)
        {
            throw new NotImplementedException();
        }

    }
}
