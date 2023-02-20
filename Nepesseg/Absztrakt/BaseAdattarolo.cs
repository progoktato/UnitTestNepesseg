using Nepesseg.Modellek;

namespace Nepesseg.Interfészek
{
    public abstract class BaseAdattarolo
    {
        //Mező (attribútum)
        private List<Telepules> _telepulesek = new List<Telepules>();

        //Tulajdonság (property), ami GETTER típusú
        /// <summary>
        /// A települések adatait tartalmazó objektumlista.
        /// </summary>
        public List<Telepules> Telepulesek { get => _telepulesek; }
        
        /// <summary>
        /// Konverziós metódus: TelepulesTipus adatot karakterláncra alakít.
        /// </summary>
        public static string TelepulesTipusToString(TelepulesTipus tipus)
        {
            switch (tipus)
            {
                case TelepulesTipus.fővárosi_kerület:
                    return "fővárosi kerület";
                case TelepulesTipus.megye_székhely:
                    return "megye székhely";
                case TelepulesTipus.megyei_jogú_város:
                    return "megyei jogú város";
                case TelepulesTipus.város:
                    return "város";
                case TelepulesTipus.nagyközség:
                    return "nagyközség";
                case TelepulesTipus.község:
                    return "község";
                default:
                    throw new Exception();
            }
        }

        /// <summary>
        /// Konverziós metódus: Helyes tartalmaú karakterláncból TelepulesTipus típusú enum-ot hoz létre.
        /// </summary>
        public static TelepulesTipus TelepulesTipusFromString(string? tipus)
        {
            if (tipus is null)
            {
                throw new ArgumentNullException(nameof(tipus));
            }
            switch (tipus)
            {
                case "fővárosi kerület":
                    return TelepulesTipus.fővárosi_kerület;
                case "megye székhely":
                    return TelepulesTipus.megye_székhely;
                case "megyei jogú város":
                    return TelepulesTipus.megyei_jogú_város;
                case "város":
                    return TelepulesTipus.város;
                case "nagyközség":
                    return TelepulesTipus.nagyközség;
                case "község":
                    return TelepulesTipus.község;
                default:
                    throw new ArgumentException();
            }
        }

        /// <summary>
        /// A megadott település típushoz tartozó települések listáját adja vissza.
        /// </summary>
        /// <param name="tipus">enum ->fővárosi_kerület, megye_székhely, megyei_jogú_város, város, nagyközség, község</param>
        /// <returns>Települések listája</returns>
        public abstract List<Telepules> SzurTelepulesTipusra(TelepulesTipus tipus);

        /// <summary>
        /// A megadott megyéhez tartozó települések listáját adja vissza. 
        /// </summary>
        /// <param name="megye">A megye 3 karakteres kódja.</param>
        /// <returns>Települések listája</returns>
        public abstract List<Telepules> SzurMegyere(string megye);

        /// <summary>
        /// A megadott megye férfi lakosainak létszámát adja vissza.
        /// </summary>
        /// <param name="megye">A megye 3 karakteres kódja.</param>
        public abstract int MegyeFerfiLakosai(string megye);

        /// <summary>
        /// A megadott megye női lakosainak létszámát adja vissza.
        /// </summary>
        /// <param name="megye">A megye 3 karakteres kódja.</param>
        public abstract int MegyeNoiLakosai(string megye);

        /// <summary>
        /// Szótárat készít, ahol a kulcs TelepulesTipus és a hozzátartozó érték az adott településtípusú települések száma.
        /// </summary>
        /// <param name="megye">A megye 3 karakteres kódja.</param>
        public abstract Dictionary<TelepulesTipus, int> MegyeTelepulesSzama(string megye);

        /// <summary>
        /// Szótárat készít, ahol a kulcs TelepulesTipus és a hozzátartozó érték az adott településtípusú településeken élők száma.
        /// </summary>
        /// <param name="megye">A megye 3 karakteres kódja.</param>
        /// <returns></returns>
        public abstract Dictionary<TelepulesTipus, int> MegyeTelepulesenkentiLakossag(string megye);

        /// <summary>
        /// Megadja, hogy az adott településen hányan élnek. Férfiak és nők együttesen.
        /// </summary>
        /// <param name="telepulesNeve">Kis és nagybetűérzékeny a névmegadás</param>
        /// <returns>Ha az adott település nem létezik, akkor -1 a visszatérési érték.</returns>
        public abstract int LakosokSzam(String telepulesNeve);


    }
}
