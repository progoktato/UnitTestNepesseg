using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nepesseg.Modellek
{
    //"Megye kód";"KSH kód";Megye;Település;"Település típusa";"Állandó férfi lakosság összesen";"Állandó női lakosság összesen"
    public enum TelepulesTipus { fővárosi_kerület, megye_székhely, megyei_jogú_város, város, nagyközség, község };
    public class Telepules
    {

        string megye;
        string telepulesNev;
        TelepulesTipus telepulesTipusa;
        int ferfiLakossag;
        int noiLakossag;

        public Telepules(string megye,
                         string telepulesNev,
                         TelepulesTipus telepulesTipusa,
                         int ferfiLakossag,
                         int noiLakossag)
        {
            this.megye = megye;
            this.telepulesNev = telepulesNev;
            this.telepulesTipusa = telepulesTipusa;
            this.ferfiLakossag = ferfiLakossag;
            this.noiLakossag = noiLakossag;
        }

        public string? Megye { get => megye; }
        public string? TelepulesNev { get => telepulesNev; }
        public TelepulesTipus TelepulesTipusa { get => telepulesTipusa; }
        public int FerfiLakossag { get => ferfiLakossag; }
        public int NoiLakossag { get => noiLakossag; }
    }
}
