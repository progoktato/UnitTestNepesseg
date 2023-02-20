using Nepesseg.Modellek;

namespace Nepesseg.Adatkezelők
{
    public class CSVTaroloTest
    {
        CSVtarolo tarolo;

        public CSVTaroloTest()
        {
            String fajlNev = "Adatok\\kozerdeku_lakossag_2022.csv";
            tarolo = new CSVtarolo(fajlNev);
        }

        [Fact]
        public void TelepulesTipusKonverzioStringre()
        {
            //Arrange - konstruktor

            //Act
            var eredmeny = CSVtarolo.TelepulesTipusToString(TelepulesTipus.megye_székhely);

            //Assert
            Assert.Equal("megye székhely", eredmeny);
        }

        [InlineData("város")]
        [InlineData("község")]
        [InlineData("megyei jogú város")]
        [Theory]
        public void TelepulesTipusKonverzioStringbol(string telepulesFajtak)
        {
            //Arrange - konstruktor

            //Act
            var eredmeny = CSVtarolo.TelepulesTipusFromString(telepulesFajtak);

            //Assert
            Assert.InRange(eredmeny, TelepulesTipus.fővárosi_kerület, TelepulesTipus.község);
        }

    }
}
