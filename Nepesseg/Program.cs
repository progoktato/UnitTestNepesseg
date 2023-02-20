using Nepesseg.Adatkezelők;
using Nepesseg.Megoldások;
using Nepesseg.Modellek;

String fajlNev = "Adatok\\kozerdeku_lakossag_2022.csv";

//Ezt a sort használja, ha a saját implemntációs megoldását akarja tesztelni!
//CSVtarolo tarolo = new CSVtarolo(fajlNev);

//Ezt a sort használja, ha a kész megoldást akarja kipróbálni!
Megoldás_CSVtarolo tarolo = new Megoldás_CSVtarolo(fajlNev);

Console.WriteLine("Megye székhelyek adatai:");
foreach (var item in tarolo.SzurTelepulesTipusra(TelepulesTipus.megye_székhely))
{
    Console.WriteLine($"{item.TelepulesNev}:férfi:{item.FerfiLakossag}fő, nő:{item.NoiLakossag}fő");
}

Console.WriteLine(new String('─', 50));

Console.Write("Kérem a megye (3 karakteres) kódját!");
string? megye = Console.ReadLine();

Dictionary<TelepulesTipus, int> telepulesSzamok = tarolo.MegyeTelepulesSzama(megye);
Dictionary<TelepulesTipus, int> lakossagSzamok = tarolo.MegyeTelepulesenkentiLakossag(megye);

for (TelepulesTipus tipus = TelepulesTipus.fővárosi_kerület; tipus <= TelepulesTipus.község; tipus++)
{
    Console.WriteLine($"{Megoldás_CSVtarolo.TelepulesTipusToString(tipus)} : {telepulesSzamok[tipus]} db, ahol {lakossagSzamok[tipus]} lakos él");
}
Console.ReadKey();

