using PROJET_FINAL___API.Logics.Models;
using System;
using Xunit;

namespace Project_Test
{
    public class UnitTestGarderie
    {
        [Fact]
        public void TestGarderieSetNom()
        {
            //Test avec de bonnes valeurs...

            //Arrange
            GarderieModel uneGarderie = new GarderieModel();
            string nom = "allo";

            //Act 
            uneGarderie.Nom = "allo";

            //Assert
            Assert.Equal(nom, uneGarderie.Nom);

            //Test avec de mauvaises valeurs...

            //Arrange
            uneGarderie = new GarderieModel();

            //Act et Assert
            Assert.Throws<Exception>(() => uneGarderie.Nom = "qqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqq");
        }

        [Fact]
        public void TestGarderieAjouterDepense()
        {
            //Test avec de bonnes valeurs...

            //Arrange
            GarderieModel garderie = new GarderieModel();
            int countGarderie = 1;

            //Act
            garderie.AjouterDepense(new DepenseModel(DateTime.Now.ToString(), 200));

            //Assert
            Assert.Equal(countGarderie, garderie.ObtenirListeDepense().Count);

            //Test avec de mauvaises valeurs...

            //Arrange
            garderie = new GarderieModel();
            DateTime dateTemps = DateTime.Now;
            garderie.AjouterDepense(new DepenseModel(dateTemps.ToString(), 200));
            countGarderie = 1;

            //Act et Assert
            Assert.Throws<Exception>(() => garderie.AjouterDepense(new DepenseModel(dateTemps.ToString(), 400)));
        }

        [Fact]
        public void TestGarderieSetAdresse()
        {
            //Test avec de bonnes valeurs...

            //Arrange
            GarderieModel uneGarderie = new GarderieModel();
            string adresse = "325 rue St-Pierre";

            //Act 
            uneGarderie.Adresse = "325 rue St-Pierre";

            //Assert
            Assert.Equal(adresse, uneGarderie.Adresse);

            //Test avec de mauvaises valeurs...

            //Arrange
            uneGarderie = new GarderieModel();

            //Act et Assert
            Assert.Throws<Exception>(() => uneGarderie.Adresse = "qqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqq");
        }

        [Fact]
        public void TestGarderieSetVille()
        {
            //Test avec de bonnes valeurs...

            //Arrange
            GarderieModel uneGarderie = new GarderieModel();
            string ville = "RdL";

            //Act 
            uneGarderie.Ville = "RdL";

            //Assert
            Assert.Equal(ville, uneGarderie.Ville);

            //Test avec de mauvaises valeurs...

            //Arrange
            uneGarderie = new GarderieModel();

            //Act et Assert
            Assert.Throws<Exception>(() => uneGarderie.Ville = "qqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqq");
        }

        [Fact]
        public void TestGarderieSetProvince()
        {
            //Test avec de bonnes valeurs...

            //Arrange
            GarderieModel uneGarderie = new GarderieModel();
            string province = "Quebec";

            //Act 
            uneGarderie.Province = "Quebec";

            //Assert
            Assert.Equal(province, uneGarderie.Province);

            //Test avec de mauvaises valeurs...

            //Arrange
            uneGarderie = new GarderieModel();

            //Act et Assert
            Assert.Throws<Exception>(() => uneGarderie.Province = "qqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqq");
        }

        [Fact]
        public void TestGarderieSetTelephone()
        {
            //Test avec de bonnes valeurs...

            //Arrange
            GarderieModel uneGarderie = new GarderieModel();
            string telephone = "067 919-0839";

            //Act 
            uneGarderie.Telephone = "067 919-0839";

            //Assert
            Assert.Equal(telephone, uneGarderie.Telephone);

            //Test avec de mauvaises valeurs...

            //Arrange
            uneGarderie = new GarderieModel();

            //Act et Assert
            Assert.Throws<Exception>(() => uneGarderie.Telephone = "qqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqq");
        }

        [Fact]
        public void TestGarderieObtenirListeDepense()
        {
            //Test avec de bonnes valeurs...

            //Arrange
            GarderieModel garderie = new GarderieModel();
            int countGarderie = 1;

            //Act
            garderie.AjouterDepense(new DepenseModel(DateTime.Now.ToString(), 200));

            //Assert
            Assert.Equal(countGarderie, garderie.ObtenirListeDepense().Count);
        }

        [Fact]
        public void TestGarderieViderListeDepense()
        {
            //Test avec de bonnes valeurs...

            //Arrange
            GarderieModel garderie = new GarderieModel();
            int countGarderie = 1;

            //Act
            garderie.AjouterDepense(new DepenseModel(DateTime.Now.ToString(), 200));

            //Assert
            Assert.Equal(countGarderie, garderie.ObtenirListeDepense().Count);
            garderie.ViderListeDepense();
            countGarderie = 0;
            Assert.Equal(countGarderie, garderie.ObtenirListeDepense().Count);

            //Test avec de mauvaises valeurs...

            //Arrange
            garderie = new GarderieModel();
            DateTime dateTemps = DateTime.Now;
            garderie.AjouterDepense(new DepenseModel(dateTemps.ToString(), 200));
            countGarderie = 1;

            //Act et Assert
            garderie.ViderListeDepense();
            Assert.Throws<Exception>(() => garderie.ViderListeDepense());
        }

        [Fact]
        public void TestGarderieSupprimerDepense()
        {
            //Test avec de bonnes valeurs...

            //Arrange
            GarderieModel garderie = new GarderieModel();
            DateTime dateTemp = DateTime.Now;
            int countGarderie = 1;

            //Act
            garderie.AjouterDepense(new DepenseModel(dateTemp.ToString(), 200));

            //Assert
            Assert.Equal(countGarderie, garderie.ObtenirListeDepense().Count);
            garderie.SupprimerDepense(new DepenseModel(dateTemp.ToString(), 200));
            countGarderie = 0;
            Assert.Equal(countGarderie, garderie.ObtenirListeDepense().Count);

            //Test avec de mauvaises valeurs...

            //Arrange
            garderie = new GarderieModel();
            DateTime dateTemps = DateTime.Now;
            garderie.AjouterDepense(new DepenseModel(dateTemps.ToString(), 200));
            countGarderie = 1;

            //Act et Assert
            garderie.SupprimerDepense(new DepenseModel(DateTime.Now.ToString(), 200));
            Assert.Throws<Exception>(() => garderie.SupprimerDepense(new DepenseModel(DateTime.Now.ToString(), 200)));
        }

        [Fact]
        public void TestGarderieModifierDepense()
        {
            //Test avec de bonnes valeurs...

            //Arrange
            GarderieModel garderie = new GarderieModel();

            //Act
            garderie.AjouterDepense(new DepenseModel(DateTime.Now.ToString(), 200));

            //Assert
            garderie.ModifierDepense(new DepenseModel(DateTime.Now.ToString(), 400));
            Assert.Equal(400, garderie.ObtenirListeDepense()[0].Montant);

            //Test avec de mauvaises valeurs...

            //Arrange
            garderie = new GarderieModel();
            DateTime dateTemps = DateTime.Now;
            garderie.AjouterDepense(new DepenseModel(dateTemps.ToString(), 200));

            //Act et Assert
            Assert.Throws<Exception>(() => garderie.ModifierDepense(new DepenseModel("2020-02-02", 400)));
        }
    }
}
